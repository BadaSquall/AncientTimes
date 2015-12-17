using System;
using System.Collections.Generic;

/// <summary>
/// Class containing all action of Generic Item, into and out of battle.
/// </summary>
public abstract class ItemAction
{
	#region Properties
	
	public MomentToExec Moment { get; set; }
	
	public Condition Condition { get; set; }
	
	#endregion
	
	#region Attributes
	
	/// <summary>
	/// The number of HP to restore at Pokemon
	/// </summary>
	public int HpQuantity { get; set; }
	
	/// <summary>
	/// The percentage of the HP to restore at Pokemon
	/// </summary>
	public TypeOfHeal TypeOfHeal { get; set; }
	
	/// <summary>
	/// The threshould in percentage of item that activate the particular effect (for example a percentage of Hp to activate berry) 
	/// </summary>
	public int Threshould { get; set; }
	
	/// <summary>
	/// The status that the item restore.
	/// </summary>
	public PokemonStatus StatusToRestore { get; set; }
	
	#endregion
	
	#region Constructor
	
	public ItemAction()
	{
		
	}
	
	#endregion
	
	#region Methods
	
	/// <summary>
	/// A generic execution of the item action.
	/// </summary>
	public abstract object Exec(Dictionary<ParameterToItemAction,object> parameters);
	
	#endregion	
}