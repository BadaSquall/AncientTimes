using System.Collections.Generic;

/// <summary>
/// Class containing the informations describing an actual state of battle.
/// </summary>
public class BattleState
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the current weather.
    /// </summary>
    /// <value>
    /// The current weather.
    /// </value>
    public Weather CurrentWeather { get; set; }

    /// <summary>
    /// Gets or sets the current gravity.
    /// </summary>
    /// <value>
    /// The current gravity.
    /// </value>
    public Gravity CurrentGravity { get; set; }

    /// <summary>
    /// Gets or sets the escape count.
    /// </summary>
    /// <value>
    /// The escape count.
    /// </value>
    public int EscapeCount { get; set; }

    /// <summary>
    /// Gets or sets the current phase.
    /// </summary>
    /// <value>
    /// The current phase.
    /// </value>
    public BattlePhase CurrentPhase { get; set; }

    /// <summary>
    /// Gets or sets the current turn.
    /// </summary>
    /// <value>
    /// The current turn.
    /// </value>
    public int CurrentTurn { get; set; }

    /// <summary>
    /// Gets or sets the player pokemon states.
    /// </summary>
    /// <value>
    /// The player pokemon states.
    /// </value>
    public List<PokemonVolatileState> PlayerPokemonStates { get; set; }

    /// <summary>
    /// Gets or sets the enemy pokemon states.
    /// </summary>
    /// <value>
    /// The enemy pokemon states.
    /// </value>
    public List<PokemonVolatileState> EnemyPokemonStates { get; set; }

    /// <summary>
    /// Gets or sets the player active pokemons.
    /// </summary>
    /// <value>
    /// The player active pokemons.
    /// </value>
    public List<Pokemon> PlayerActivePokemons { get; set; }

    /// <summary>
    /// Gets or sets the enemy active pokemons.
    /// </summary>
    /// <value>
    /// The enemy active pokemons.
    /// </value>
    public List<Pokemon> EnemyActivePokemons { get; set; } 

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="BattleState"/> class.
    /// </summary>
    public BattleState()
    {
        CurrentTurn = 0;
        EscapeCount = 0;

        PlayerActivePokemons = new List<Pokemon>();
        EnemyActivePokemons = new List<Pokemon>();
        PlayerPokemonStates = new List<PokemonVolatileState>();
        EnemyPokemonStates = new List<PokemonVolatileState>();

        CurrentGravity = Gravity.Normal;
        CurrentPhase = BattlePhase.Choice;
        CurrentWeather = Weather.None;
    }

    #endregion

    /// <summary>
    /// Adds the stat level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="stat">The stat.</param>
    /// <param name="target">The target.</param>
    /// <param name="pokemonIndex">Index of the pokemon.</param>
    public void AddStatLevel(int level, VolatileStat stat, Target target, int pokemonIndex = 0)
    {
        if (level == 0) return;

        if (target == Target.Ally)
        {
            if (pokemonIndex >= PlayerPokemonStates.Count) return;
            var pokemonState = PlayerPokemonStates[pokemonIndex];

            if (pokemonState.StatLevels[stat] + level > 6)
            {
                pokemonState.StatLevels[stat] = 6;
            }
            else if (pokemonState.StatLevels[stat] + level < -6)
            {
                pokemonState.StatLevels[stat] = -6;
            }
            else
            {
                pokemonState.StatLevels[stat] += level;
            }
        }
        else if (target == Target.Enemy)
        {
            if (pokemonIndex >= EnemyPokemonStates.Count) return;
            var pokemonState = EnemyPokemonStates[pokemonIndex];

            if (pokemonState.StatLevels[stat] + level > 6)
            {
                pokemonState.StatLevels[stat] = 6;
            }
            else if (pokemonState.StatLevels[stat] + level < -6)
            {
                pokemonState.StatLevels[stat] = -6;
            }
            else
            {
                pokemonState.StatLevels[stat] += level;
            }
        }
    }

    /// <summary>
    /// Gets the stat level.
    /// </summary>
    /// <param name="stat">The stat.</param>
    /// <param name="target">The target.</param>
    /// <param name="pokemonIndex">Index of the pokemon.</param>
    /// <returns></returns>
    public int GetStatLevel(VolatileStat stat, Target target, int pokemonIndex = 0)
    {
        if ((target == Target.Enemy && pokemonIndex >= EnemyPokemonStates.Count)) return 0;
        if ((target == Target.Ally && pokemonIndex >= PlayerPokemonStates.Count)) return 0;

        return target == Target.Enemy
            ? EnemyPokemonStates[pokemonIndex].StatLevels[stat]
            : PlayerPokemonStates[pokemonIndex].StatLevels[stat];
    }
}
