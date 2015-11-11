using System.Collections.Generic;

/// <summary>
/// Data-class containing all properties required for executing (graphically and logically) a battle action.
/// </summary>
public class BattleAction
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the prefab path.
    /// </summary>
    /// <value>
    /// The prefab path.
    /// </value>
    public string PrefabPath { get; set; }

    /// <summary>
    /// Gets or sets the executing pokemon.
    /// </summary>
    /// <value>
    /// The executing pokemon.
    /// </value>
    public Pokemon ExecutingPokemon { get; set; }

    /// <summary>
    /// Gets or sets the target pokemon.
    /// </summary>
    /// <value>
    /// The target pokemon.
    /// </value>
    public List<Pokemon> TargetPokemons { get; set; }

    /// <summary>
    /// Gets or sets the move.
    /// </summary>
    /// <value>
    /// The move.
    /// </value>
    public Move ExecutedMove { get; set; }

    /// <summary>
    /// Gets or sets the executing ability.
    /// </summary>
    /// <value>
    /// The executing ability.
    /// </value>
    public Ability ExecutedAbility { get; set; }

    /// <summary>
    /// Gets or sets the executing item.
    /// </summary>
    /// <value>
    /// The executing item.
    /// </value>
    public Item ExecutedItem { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="BattleAction"/> is failed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if failed; otherwise, <c>false</c>.
    /// </value>
    public bool Failed { get; set; }

    /// <summary>
    /// Gets or sets the priority.
    /// </summary>
    /// <value>
    /// The priority.
    /// </value>
    public int Priority { get; set; }

    /// <summary>
    /// Gets or sets the calculated HP difference to be applied after the action.
    /// </summary>
    /// <value>
    /// The calculated HP difference.
    /// </value>
    public int HpDiff { get; set; }

    /// <summary>
    /// Gets or sets the calculated status to be applied after the action.
    /// </summary>
    /// <value>
    /// The calculated status.
    /// </value>
    public PokemonStatus Status { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="BattleAction"/> is cancel.
    /// </summary>
    /// <value>
    ///   <c>true</c> if cancel; otherwise, <c>false</c>.
    /// </value>
    public bool Cancel { get; set; }

    /// <summary>
    /// Gets or sets the number of turns the action will last.
    /// </summary>
    /// <value>
    /// The number of turns the action will last.
    /// </value>
    public int Turns { get; set; }

    /// <summary>
    /// Gets or sets the current turn.
    /// </summary>
    /// <value>
    /// The current turn.
    /// </value>
    public int CurrentTurn { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is action completed.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is action completed; otherwise, <c>false</c>.
    /// </value>
    public bool IsActionCompleted { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance has no effect.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has no effect; otherwise, <c>false</c>.
    /// </value>
    public bool HasNoEffect { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is supereffective.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is supereffective; otherwise, <c>false</c>.
    /// </value>
    public bool IsSupereffective { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is resistant.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is resistant; otherwise, <c>false</c>.
    /// </value>
    public bool IsResistant { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is critical.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is critical; otherwise, <c>false</c>.
    /// </value>
    public bool IsCritical { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="BattleAction"/> class.
    /// </summary>
    public BattleAction()
    {
        ExecutingPokemon = null;
        TargetPokemons = new List<Pokemon>();

        ExecutedAbility = null;
        ExecutedItem = null;
        ExecutedMove = null;

        Failed = false;
        Cancel = false;
        PrefabPath = "";
        
        HpDiff = 0;
        Status = PokemonStatus.Normal;

        IsResistant = false;
        IsCritical = false;
        HasNoEffect = false;
        IsSupereffective = false;

        IsActionCompleted = false;

        CurrentTurn = 0;
    }

    #endregion

    /// <summary>
    /// Executes the action.
    /// </summary>
    /// <param name="time">The game time.</param>
    /// <param name="state">The state.</param>
    public void Execute(float time, BattleState state)
    {
        BattleCalculator.CalculateParameters(this, state);
    }
}
