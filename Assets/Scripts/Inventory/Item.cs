using System;
using System.Collections.Generic;

/// <summary>
/// Class containing all the necessary properties for a Generic Item, into and out of battle.
/// </summary>
public class Item
{
	#region Properties
	
	/// <summary>
	/// Item name.
	/// </summary>
	public string Name { get; set; }
	
	/// <summary>
	/// Item description.
	/// </summary>
	public string Description { get; set; }
	
	/// <summary>
	/// Image path of the item.
	/// </summary>
	public string Image { get; set; }
	
	/// <summary>
	/// Return if the item can be discarded or not.
	/// </summary>
	public bool CanBeDiscarded { get; set; }
	
	/// <summary>
	/// Return if the item can be used on a Pokemon in a team.
	/// </summary>
	public bool IsUsableOnPokemon { get; set; }
	
	/// <summary>
	/// Return if the item can be assigned on Pokemon in a team or not.
	/// </summary>
	public bool CanBeAssigned { get; set; }
	
	/// <summary>
	/// The item action when it is used in the bag, with effect out of the battle.
	/// </summary>
	public ItemAction BagAction { get; set; }
	
	/// <summary>
	/// The item action when it is held by Pokemon, with effect out of the battle.
	/// </summary>
	public ItemAction HoldAction { get; set; }
	
	/// <summary>
	/// The item action when it is used in the bag, during the battle.
	/// </summary>
	public ItemAction BattleBagAction { get; set; }
	
	/// <summary>
	/// The item action when it is is held by Pokemon, during the battle.
	/// </summary>
	public ItemAction BattleHoldAction { get; set; }
	
	/// <summary>
	/// The item category.
	/// </summary>
	public ItemCategory Category { get; set; }
	
	/// <summary>
	/// The price of the single item.
	/// </summary>
	public int Price { get; set; }
	
	#endregion
	
	#region Constructor
	
	public Item()
	{
		
	}
	
	public Item(string name, string description, string image, bool canBeDiscarded)
	{
		this.Name = name;
		this.Description = description;
		this.Image = image;
		this.CanBeDiscarded = canBeDiscarded;
	}
	
	#endregion
	
}