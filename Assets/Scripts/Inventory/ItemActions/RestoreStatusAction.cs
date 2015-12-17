using System;
using System.Collections.Generic;

/// <summary>
/// This Action restorethe Status of Pokemon that use this Item.
/// </summary>
public class RestoreStatusAction : ItemAction
{
	#region Constructor
	
	public RestoreStatusAction()
	{

	}
	
	#endregion
	
	#region Methods
	
	/// <summary>
    /// This method execute The Item Action. In case this Restore the Pokemon Status.
    /// </summary>
    /// <param name="parameters">This is a generic list of parameters to pass to generic action. There VALUE are identified by KEY ParameterToItemAction</param>
    /// <returns>Return the Status restored. Return 0 if the Pokemon have different Status, -1 if the Pokemon is K.O.,  NULL if the parameters aren't valid</returns>
	public override object Exec(Dictionary<ParameterToItemAction,object> parameters)
	{
		object value;
		if (parameters.TryGetValue(ParameterToItemAction.POKEMON, out value))
		{
			Pokemon pokemonToCure = (Pokemon) value;
			if (pokemonToCure.Hp == 0) return -1;
			switch (TypeOfHeal)
			{
				case TypeOfHeal.Effective:
					if (StatusToRestore == pokemonToCure.Status)
						return RestoreStatus(pokemonToCure, StatusToRestore);
					else return 0;
				case TypeOfHeal.Total:
					return RestoreStatus(pokemonToCure, pokemonToCure.Status);
				default:
					return null;
			}		
		}
		else return null;
	}
	
	/// <summary>
    /// This method restore the Pokemon Status
    /// </summary>
    /// <param name="pokemonToCure">The Pokemon to cure</param>
    /// <param name="StatusToRestore">The Status to restore</param>
    /// <returns>Return the Status restored. </returns>
	public PokemonStatus RestoreStatus(Pokemon pokemonToCure, PokemonStatus StatusToRestore)
	{
		pokemonToCure.Status = PokemonStatus.Normal;
		return StatusToRestore;
	}
	
	#endregion
}



