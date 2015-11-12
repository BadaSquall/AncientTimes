using System.Runtime.InteropServices;

/// <summary>
/// Class doing all the hard work of instantiating a BattleAction from the other classes or enums.
/// </summary>
public static class BattleActionFactory 
{
    /// <summary>
    /// Generates a BattleAction from an ability.
    /// </summary>
    /// <param name="ability">The ability.</param>
    /// <returns></returns>
    public static BattleAction FromAbility(Ability ability)
    {
        return new BattleAction
        {
            ExecutedAbility = ability,
            Turns = ability.NumberOfTurns,
            PrefabPath = "Prefab/Abilities/" + ability.Name
        };
    }

    /// <summary>
    /// Generates a BattleAction from a move.
    /// </summary>
    /// <param name="move">The move.</param>
    /// <returns></returns>
    public static BattleAction FromMove(Move move)
    {
        return new BattleAction
        {
            ExecutedMove = move,
            Turns = move.NumberOfTurns,
            PrefabPath = "Prefab/Moves/" + move.Name,
        };
    }
}
