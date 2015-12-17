using System;
using System.Collections.Generic;

/// <summary>
/// This Condition return if the Pokemon is K.O.
/// </summary>
public class IsKo : Condition
{
	#region properties
	
	/// <summary>
	/// The Pokemon Hp to check if that are K.O.
	/// </summary>
	public int HpToCheck { get; set; }
	
	#endregion
	
	#region Constructor
	
	public IsKo()
	{ }
	
	public IsKo(int hpToCheck)
	{
		this.HpToCheck = hpToCheck;			
	}
	
	#endregion
	
	#region Methods
	
	/// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public override bool CheckCondition()
	{
		if (HpToCheck == 0) return true;
		else return false;	
	}
    
	#endregion
}