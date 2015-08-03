using System.Collections.Generic;

public class Ability
{
	/// <summary>
	/// BattleAction describing this move.
	/// </summary>
	public BattleAction BattleAction { get; set; }
	
	/// <summary>
	/// Ability name.
	/// </summary>
	public string Name { get; set; }
	
	/// <summary>
	/// Ability description.
	/// </summary>
	public string Description { get; set; }
	
	/// <summary>
	/// Ability power.
	/// </summary>
	public int Power { get; set; }
	
	/// <summary>
	/// Ability accuracy.
	/// </summary>
	public int Accuracy { get; set; }
	
	/// <summary>
	/// Ability priority.
	/// </summary>
	public int Priority { get; set; }
	
	/// <summary>
	/// Ability inflicted status.
	/// </summary>
	public PokemonStatus Status { get; set; }
	
	/// <summary>
	/// Ability inflicted status accuracy.
	/// </summary>
	public int StatusAccuracy { get; set; }
	
	/// <summary>
	/// Volatile stat level diffs
	/// </summary>
	public Dictionary<VolatileStat, int> StatLevelDiffs { get; private set; }
	
	/// <summary>
	/// Ability number of turns duration.
	/// </summary>
	public int NumberOfTurns { get; set; }
	
	/// <summary>
	/// List of phases in which the ability applies.
	/// </summary>
	public List<BattlePhase> Phases { get; set; }
	
	/// <summary>
	/// Returns true if ability has animation.
	/// </summary>
	public bool HasAnimation { get; set; }
	
	#region Constructor
	
	public Ability()
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
		
		Phases = new List<BattlePhase>();
	}
	
	#endregion
	
	#region Methods

	/// <summary>
	/// Method called during the turn
	/// </summary>
	public virtual void Action()
	{ }
	
	#endregion
}
