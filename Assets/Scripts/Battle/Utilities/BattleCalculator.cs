using System;
using System.CodeDom;
using System.Linq;

/// <summary>
/// Helper class for doing all math work regarding damage calculation.
/// </summary>
public static class BattleCalculator 
{
    /// <summary>
    /// Calculates the parameters.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    public static void CalculateParameters(BattleAction action, BattleState state)
    {
        var randomGenerator = new Random();

        if (action.ExecutingPokemon == null || action.TargetPokemons.Count == 0) return;

        if (action.ExecutedMove != null)
        {
            action.Failed = action.ExecutedMove.Accuracy != -1 && CheckIfFailed(action, state, randomGenerator);
        }
        else
        {
            action.Failed = false;
        }

        if (action.Failed) return;

        if (action.ExecutedMove != null)
        {
            var stab = 1.0f;
            if (TypeChart.IsStab(action.ExecutingPokemon, action.ExecutedMove.Type)) stab = 1.5f;

            var atkStat = CalculateAttackStat(action, state);
            var defStat = CalculateDefenseStat(action, state);

            var typeModifier = CalculateTypeModifier(action);

            if (typeModifier > 1.0f)
            {
                action.IsSupereffective = true;
            }
            else if (typeModifier == 0.0f)
            {
                action.HasNoEffect = true;
            }
            else if (typeModifier < 1.0f)
            {
                action.IsResistant = true;
            }

            var critical = CheckIfCritical(action, state, randomGenerator);
            var randomDamage = (randomGenerator.Next(85, 100)) / 100.0f;

            // Calculate damage at last!
            if (action.ExecutedMove.Category != MoveCategory.Status)
            {
                action.HpDiff = -1*(int) Math.Floor(((
                    (2 * action.ExecutingPokemon.Level + 10) / 250.0f * atkStat * action.ExecutedMove.Power / defStat) + 2) * stab * typeModifier * randomDamage * critical);
            }
            else
            {
                action.HpDiff = 0;
                action.IsSupereffective = false;
                action.IsCritical = false;
                action.IsResistant = false;
            }

            CheckIfStatus(action, randomGenerator);
            ApplyStatLevels(action, state);
        }
    }

    /// <summary>
    /// Checks if the action has failed.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    /// <param name="rng">The RNG.</param>
    /// <returns></returns>
    private static bool CheckIfFailed(BattleAction action, BattleState state, Random rng)
    {
        var random = rng.Next(0, 100);

        var baseAccuracy = 1.0f;
        int accuracyLevel = 0, evasionLevel = 0;

        if (action.ExecutedMove != null)
        {
            baseAccuracy = action.ExecutedMove.Accuracy / 100.0f;
        }

        // TODO: support for double and triple battles
        if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
        {
            accuracyLevel = state.GetStatLevel(VolatileStat.Accuracy, Target.Enemy);
            evasionLevel = state.GetStatLevel(VolatileStat.Evasion, Target.Ally);
        }
        else if(state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
        {
            accuracyLevel = state.GetStatLevel(VolatileStat.Accuracy, Target.Ally);
            evasionLevel = state.GetStatLevel(VolatileStat.Evasion, Target.Enemy);
        }

        var probability = baseAccuracy * GetPercentageFromAccuracyLevel(accuracyLevel) /
                          GetPercentageFromAccuracyLevel(evasionLevel);

        return !(random <= (probability * 100.0f));
    }

    /// <summary>
    /// Calculates the attack stat.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    /// <returns></returns>
    private static double CalculateAttackStat(BattleAction action, BattleState state)
    {
        if (action.ExecutedMove == null) return 0.0f;

        var attackModifier = 1.0;
        var baseAttack = 1.0;
        var attackLevel = 0.0f;

        switch (action.ExecutedMove.Category)
        {
            case MoveCategory.Physic:
                baseAttack = action.ExecutingPokemon.Attack;
                attackModifier = NatureChart.GetChartEntryFromNature(action.ExecutingPokemon.PokemonNature).AttackModifier;

                if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
                {
                    attackLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.Attack, Target.Enemy));
                }
                else if (state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
                {
                    attackLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.Attack, Target.Ally));
                }

                break;
            case MoveCategory.Special:
                baseAttack = action.ExecutingPokemon.SpecialDefense;
                attackModifier = NatureChart.GetChartEntryFromNature(action.ExecutingPokemon.PokemonNature).SpecialAttackModifier;

                if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
                {
                    attackLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.SpecialAttack, Target.Enemy));
                }
                else if (state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
                {
                    attackLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.SpecialAttack, Target.Ally));
                }

                break;
        }

        return baseAttack * attackModifier * attackLevel;
    }

    /// <summary>
    /// Calculates the defense stat.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    /// <returns></returns>
    private static double CalculateDefenseStat(BattleAction action, BattleState state)
    {
        if (action.ExecutedMove == null) return 0.0f;

        var defenseModifier = 1.0;
        var baseDefense = 1.0;
        var defenseLevel = 0.0f;

        switch (action.ExecutedMove.Category)
        {
            case MoveCategory.Physic:
                baseDefense = action.ExecutingPokemon.Defense;
                defenseModifier = NatureChart.GetChartEntryFromNature(action.TargetPokemons.First().PokemonNature).DefenseModifier;

                if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
                {
                    defenseLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.Defense, Target.Ally));
                }
                else if (state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
                {
                    defenseLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.Defense, Target.Enemy));
                }

                break;
            case MoveCategory.Special:
                baseDefense = action.ExecutingPokemon.SpecialDefense;
                defenseModifier = NatureChart.GetChartEntryFromNature(action.TargetPokemons.First().PokemonNature).SpecialDefenseModifier;

                if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
                {
                    defenseLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.SpecialDefense, Target.Ally));
                }
                else if (state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
                {
                    defenseLevel = GetPercentageFromStatLevel(state.GetStatLevel(VolatileStat.SpecialDefense, Target.Enemy));
                }

                break;
        }

        return baseDefense * defenseModifier * defenseLevel;
    }

    /// <summary>
    /// Calculates the type modifier.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <returns></returns>
    private static float CalculateTypeModifier(BattleAction action)
    {
        var weakness = 1.0f;
        var resistance = 1.0f;

        var moveType = action.ExecutedMove.Type;

        var firstModifiers = TypeChart.GetChartEntryFromType(action.TargetPokemons.First().TypeOne);
        var secondModifiers = TypeChart.GetChartEntryFromType(action.TargetPokemons.First().TypeTwo);

        if ((firstModifiers != null && firstModifiers.NoEffect.Contains(moveType)) ||
            (secondModifiers != null && secondModifiers.NoEffect.Contains(moveType)))
        {
            weakness = 0.0f;
        }
        else
        {
            if (firstModifiers != null)
            {
                if (firstModifiers.Weak.Contains(moveType))
                {
                    weakness *= 2.0f;
                }

                if (firstModifiers.Resistant.Contains(moveType))
                {
                    resistance *= 2.0f;
                }
            }

            if (secondModifiers != null)
            {
                if (secondModifiers.Weak.Contains(moveType))
                {
                    weakness *= 2.0f;
                }

                if (secondModifiers.Resistant.Contains(moveType))
                {
                    resistance *= 2.0f;
                }
            }
        }

        return weakness / resistance;
    }

    /// <summary>
    /// Checks if critical.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    /// <returns></returns>
    private static float CheckIfCritical(BattleAction action, BattleState state, Random rng)
    {
        var critical = 1.0f;
        var criticalLevel = 0;

        if (state.EnemyActivePokemons.Contains(action.ExecutingPokemon))
        {
            criticalLevel = state.GetStatLevel(VolatileStat.Critical, Target.Enemy);
        }
        else if (state.PlayerActivePokemons.Contains(action.ExecutingPokemon))
        {
            criticalLevel = state.GetStatLevel(VolatileStat.Critical, Target.Ally);
        }

        var criticalProbability = GetPercentageFromCritLevel(criticalLevel);

        if (rng.Next(0, 100) <= criticalProbability)
        {
            action.IsCritical = true;
            critical = 1.5f;
        }

        return critical;
    }

    /// <summary>
    /// Checks if status.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="rng">The RNG.</param>
    private static void CheckIfStatus(BattleAction action, Random rng)
    {
        if (rng.Next(0, 100) <= action.ExecutedMove.StatusAccuracy)
        {
            action.Status = action.ExecutedMove.Status;
        }    
    }

    /// <summary>
    /// Applies the stat levels.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="state">The state.</param>
    private static void ApplyStatLevels(BattleAction action, BattleState state)
    {
        var volatileStats = (VolatileStat[]) Enum.GetValues(typeof (VolatileStat));

        foreach (var stat in volatileStats)
        {
            state.AddStatLevel(action.ExecutedMove.StatLevelDiffs[stat], stat, action.ExecutedMove.Target);
        }
    }

    /// <summary>
    /// Gets the percentage from stat level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <returns></returns>
    private static float GetPercentageFromStatLevel(int level)
    {
        var result = 0.0f;

        switch (level)
        {
            case -6:
                result = 0.25f;
                break;
            case -5:
                result = 0.29f;
                break;
            case -4:
                result = 0.33f;
                break;
            case -3:
                result = 0.40f;
                break;
            case -2:
                result = 0.50f;
                break;
            case -1:
                result = 0.66f;
                break;
            case 0:
                result = 1.0f;
                break;
            case 1:
                result = 1.5f;
                break;
            case 2:
                result = 2.0f;
                break;
            case 3:
                result = 2.5f;
                break;
            case 4:
                result = 3.0f;
                break;
            case 5:
                result = 3.5f;
                break;
            case 6:
                result = 4.0f;
                break;
        }

        return result;
    }

    /// <summary>
    /// Gets the percentage from crit level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <returns></returns>
    private static float GetPercentageFromCritLevel(int level)
    {
        var result = 0.0f;

        switch (level)
        {
            case 0:
                result = 0.0625f;
                break;
            case 1:
                result = 0.125f;
                break;
            case 2:
                result = 0.50f;
                break;
            case 3:
                result = 1.0f;
                break;
        }

        return result * 100.0f;
    }

    /// <summary>
    /// Gets the percentage from accuracy level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <returns></returns>
    public static float GetPercentageFromAccuracyLevel(int level)
    {
        var result = 0.0f;

        switch (level)
        {
            case 0:
                result = 1.00f;
                break;
            case 1:
                result = 1.330f;
                break;
            case 2:
                result = 1.67f;
                break;
            case 3:
                result = 2.00f;
                break;
            case 4:
                result = 2.33f;
                break;
            case 5:
                result = 2.67f;
                break;
            case 6:
                result = 3.00f;
                break;
            case -1:
                result = 0.75f;
                break;
            case -2:
                result = 0.60f;
                break;
            case -3:
                result = 0.50f;
                break;
            case -4:
                result = 0.43f;
                break;
            case -5:
                result = 0.38f;
                break;
            case -6:
                result = 0.33f;
                break;
        }

        return result;
    }
}
