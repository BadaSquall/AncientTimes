using System.Collections.Generic;

/// <summary>
/// Class containing all the volatile properties of a pokemon in battle.
/// </summary>
public class PokemonVolatileState
{
    #region Public Properties

    /// <summary>
    /// Gets or sets a value indicating whether this instance is levitating.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is levitating; otherwise, <c>false</c>.
    /// </value>
    public bool IsLevitating { get; set; }

    /// <summary>
    /// Gets or sets the current gravity.
    /// </summary>
    /// <value>
    /// The current gravity.
    /// </value>
    public Gravity CurrentGravity { get; set; }

    /// <summary>
    /// Gets or sets the stat levels.
    /// </summary>
    /// <value>
    /// The stat levels.
    /// </value>
    public Dictionary<VolatileStat, int> StatLevels { get; set; } 

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="PokemonVolatileState"/> class.
    /// </summary>
    public PokemonVolatileState()
    {
        CurrentGravity = Gravity.Normal;
        IsLevitating = false;

        StatLevels = new Dictionary<VolatileStat, int>
        {
            { VolatileStat.Accuracy, 0 },
            { VolatileStat.Attack, 0 },
            { VolatileStat.Critical, 0 },
            { VolatileStat.Defense, 0 },
            { VolatileStat.Evasion, 0 },
            { VolatileStat.MovePriority, 0 },
            { VolatileStat.SpecialAttack, 0 },
            { VolatileStat.SpecialDefense, 0 },
            { VolatileStat.Speed, 0 }
        };
    }

    #endregion
}
