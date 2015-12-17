using System;
using System.Collections.Generic;

/// <summary>
/// This Condition return if the Pokemon Status are changed.
/// </summary>
public class StatusAsAlterate : Condition
{
	#region properties
	
	public PokemonStatus Status { get; set; }
	public TypeOfHeal TypeOfHeal { get; set; }
	public PokemonStatus StatusToCheck { get; set; }
	
	#endregion
	
	#region Constructor
	
	public StatusAsAlterate()
	{ }
	
	#endregion
	
	#region Methods
	
	/// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public override bool CheckCondition()
	{
		if (TypeOfHeal == TypeOfHeal.Total && Status != PokemonStatus.Normal) 
			return true;
		if (StatusToCheck == Status)
			return true;
		else 
			return false;
	}
    
	#endregion
}
