using System;
using System.Collections.Generic;

/// <summary>
/// This Action restore an HP of Pokemon that use this Item.
/// </summary>
public class RestoreHpAction : ItemAction
{
	#region Constructor
	
	public RestoreHpAction()
	{

	}
	
	#endregion
	
	#region Methods
	
	/// <summary>
    /// This method execute The Item Action. In this case calculate and restore the Pokemon Hp.
    /// </summary>
    /// <param name="parameters">This is a generic list of parameters to pass to generic action. There VALUE are identified by KEY ParameterToItemAction</param>
    /// <returns>Return the number of Hp restored. Return 0 if the Pokemon have Max Hp, -1 if the Pokemon is K.O., NULL if the parameters aren't valid</returns>
	public override object Exec(Dictionary<ParameterToItemAction,object> parameters)
	{
		object value;
		if (parameters.TryGetValue(ParameterToItemAction.POKEMON, out value))
		{
			Pokemon pokemonToCure = (Pokemon) value;
			var HpCalculate = 0;
			switch (TypeOfHeal)
			{
				case TypeOfHeal.Percentuage:
					HpCalculate = (pokemonToCure.HpMax * HpQuantity)/100;
					return RestoreHp(pokemonToCure,HpCalculate,false);
				case TypeOfHeal.Effective:
					return RestoreHp(pokemonToCure,HpQuantity,false);
				case TypeOfHeal.Revive:
					pokemonToCure.Status = PokemonStatus.Normal;
					HpCalculate = (pokemonToCure.HpMax * HpQuantity)/100;
					return RestoreHp(pokemonToCure,HpCalculate,true);
				case TypeOfHeal.Total:
					pokemonToCure.Status = PokemonStatus.Normal;
					return RestoreHp(pokemonToCure,pokemonToCure.HpMax,true);
				default:
					return null;
			}		
		}
		else return null;
	}
	
	/// <summary>
    /// This method restore the Pokemon HP
    /// </summary>
    /// <param name="pokemonToCure">The Pokemon to cure</param>
    /// <param name="HpToRestore">The number of Hp to restore</param>
    /// <param name="isRevive">if the item is a Revive or not</param>
    /// <returns>Return the number of Hp restored. Return 0 if the Pokemon have Max Hp, -1 if the Pokemon is K.O.</returns>
	public int RestoreHp(Pokemon pokemonToCure, int HpToRestore, bool isRevive)
	{
		if (pokemonToCure.Hp == 0 && isRevive == false) return -1;
		if ((pokemonToCure.Hp + HpToRestore) > pokemonToCure.HpMax)
		{
			int previousHp = pokemonToCure.Hp;
			pokemonToCure.Hp = pokemonToCure.HpMax;
			return pokemonToCure.HpMax - previousHp;
		}	
		else
		{
			pokemonToCure.Hp += HpToRestore;
			return HpToRestore;
		}
	}
	
	#endregion
}

