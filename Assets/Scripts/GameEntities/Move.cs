using System.Collections.Generic;

/// <summary>
/// Class containing all the necessary properties for a Move to be shown and executed.
/// </summary>
public class Move
{
	/// <summary>
	/// Move name.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Move description.
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// Move power.
	/// </summary>
	public int Power { get; set; }

	/// <summary>
	/// Move accuracy.
	/// </summary>
	public int Accuracy { get; set; }

	/// <summary>
	/// Move priority.
	/// </summary>
	public int Priority { get; set; }

	/// <summary>
	/// Move inflicted status.
	/// </summary>
	public PokemonStatus Status { get; set; }

	/// <summary>
	/// Move inflicted status accuracy.
	/// </summary>
	public int StatusAccuracy { get; set; }

	/// <summary>
	/// Move type.
	/// </summary>
	public PokemonType Type { get; set; }

	/// <summary>
	/// Move category.
	/// </summary>
	public MoveCategory Category { get; set; }

	/// <summary>
	/// Volatile stat level diffs
	/// </summary>
	public Dictionary<VolatileStat, int> StatLevelDiffs { get; private set; }

	/// <summary>
	/// Move number of turns duration.
	/// </summary>
	public int NumberOfTurns { get; set; }

	/// <summary>
	/// Gets if the move has an action to be executed at the beginning of the turn.
	/// </summary>
	public bool HasBeginAction { get; set; }

	/// <summary>
	/// Gets if the move has an action to be executed at the end of the turn.
	/// </summary>
	public bool HasEndAction { get; set; }

	/// <summary>
	/// Defines if the message shown when the move is used must contain the pokemon name.
	/// </summary>
	public bool UsePokemonName { get; set; }

	/// <summary>
	/// Defines if the prefab of the move must shown on the attacker instead of the attacked pokemon.
	/// </summary>
	public bool OnAttacker { get; set; }

    /// <summary>
    /// Specify which pokemon will be targeted by this move.
    /// </summary>
    public Target Target { get; set; }

	#region Constructor
	
	public Move()
	{
		StatLevelDiffs = new Dictionary<VolatileStat, int>();
		StatLevelDiffs[VolatileStat.Accuracy] = 0;
		StatLevelDiffs[VolatileStat.Attack] = 0;
		StatLevelDiffs[VolatileStat.Defense] = 0;
		StatLevelDiffs[VolatileStat.Evasion] = 0;
		StatLevelDiffs[VolatileStat.MovePriority] = 0;
		StatLevelDiffs[VolatileStat.SpecialAttack] = 0;
		StatLevelDiffs[VolatileStat.SpecialDefense] = 0;
		StatLevelDiffs[VolatileStat.Speed] = 0;
		StatLevelDiffs[VolatileStat.Critical] = 0;
	}
	
	#endregion
	
	#region Methods

	/// <summary>
	/// Method called at the beginning of the turn
	/// </summary>
	public virtual void BeginTurnAction()
	{ }

	/// <summary>
	/// Method called during the turn
	/// </summary>
	public virtual void Action()
	{ }

	/// <summary>
	/// Method called at the end of the turn
	/// </summary>
	public virtual void EndTurnAction()
	{ }
	
	#endregion
}
