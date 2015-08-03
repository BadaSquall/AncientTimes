using System.Collections.Generic;

/// <summary>
/// Data-class containing all properties of a trainer battle, such as trainer name and team.
/// </summary>
public class Trainer 
{
	/// <summary>
	/// Trainer name.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Trainer type.
	/// </summary>
	public string TrainerType { get; set; }

	/// <summary>
	/// Text displayed when a battle is won against this trainer.
	/// </summary>
	public string LossText { get; set; }

	/// <summary>
	/// Text display when a battle is lost against this trainer.
	/// </summary>
	public string WinText { get; set; }

	/// <summary>
	/// Money dropped when a battle is won against this trainer.
	/// </summary>
	public int DroppedMoney { get; set; }

	/// <summary>
	/// Trainer team as a generic list of pokemons. NB: it uses the order in which the pokemons are added.
	/// </summary>
	public List<Pokemon> Team { get; private set; }

	#region Constructor

	/// <summary>
	/// Inizializes a new instance of the <see cref="Trainer"/> class.
	/// </summary>
	public Trainer() 
	{ 
		Team = new List<Pokemon> ();
	}

	#endregion
}
