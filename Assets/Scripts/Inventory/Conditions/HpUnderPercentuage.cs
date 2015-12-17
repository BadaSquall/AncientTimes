using System;
using System.Collections.Generic;

/// <summary>
/// This Condition return if the Pokemon Hp are under a given threshold.
/// </summary>
public class HpUnderPercentuage : Condition
{
	#region properties
	
	public int Percentuage { get; set; }
	public int HpToCheck { get; set; }
	public int HpMax { get; set; }
	
	#endregion
	
	#region Constructor
	
	public HpUnderPercentuage()
	{ }
	
	#endregion
	
	#region Methods
	
	/// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public override bool CheckCondition()
	{
		if (HpToCheck < ((HpMax * Percentuage)/100) && HpToCheck != 0) 
			return true;
		else 
			return false;
	}
    
	#endregion
}
