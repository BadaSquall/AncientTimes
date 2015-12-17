using System;
using System.Collections.Generic;

/// <summary>
/// Class containing all activating condition of Generic Item, into the battle.
/// </summary>
public abstract class Condition
{
	#region Properties
	
	#endregion
	
	#region Constructor
	
	public Condition()
	{
		
	}
	
	#endregion
	
	#region Methods
	
	/// <summary>
	/// A generic Check of the Item condition for activate Item effect.
	/// </summary>
	public abstract bool CheckCondition();
	
	#endregion	
}