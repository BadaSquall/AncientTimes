using System;
using System.Collections;

/// <summary>
/// Data-class containing all properties of a single pokemon.
/// It also containing some convenience static methods for the creation of a random pokemon.
/// TODO: define set of rules for the random creation.
/// </summary>
public class Pokemon
{
	/// <summary>
	/// Pokémon number on pokédex.
	/// </summary>
	public int Number { get; set; }
	
	/// <summary>
	/// Pokémon name.
	/// </summary>
	public string Name { get; set; }
	
	/// <summary>
	/// Pokémon nickname.
	/// </summary>
	public string Nickname { get; set; }
	
	/// <summary>
	/// Pokémon trainer's name.
	/// </summary>
	public string TrainerName { get; set; }
	
	/// <summary>
	/// Pokémon trainer's ID.
	/// </summary>
	public int TrainerID { get; set; }
	
	/// <summary>
	/// Pokémon trainer's Secret ID.
	/// </summary>
	public int SecretID { get; set; }
	
	/// <summary>
	/// Pokémon level.
	/// </summary>
	public int Level { get; set; }
	
	/// <summary>
	/// Pokémon base life points.
	/// </summary>
	public int HpBase { get; set; }
	
	/// <summary>
	/// Pokémon base attack.
	/// </summary>
	public int AttackBase { get; set; }
	
	/// <summary>
	/// Pokémon base defense.
	/// </summary>
	public int DefenseBase { get; set; }
	
	/// <summary>
	/// Pokémon base special attack.
	/// </summary>
	public int SpecialAttackBase { get; set; }
	
	/// <summary>
	/// Pokémon base special defense.
	/// </summary>
	public int SpecialDefenseBase { get; set; }
	
	/// <summary>
	/// Pokémon base speed.
	/// </summary>
	public int SpeedBase { get; set; }
	
	/// <summary>
	/// Pokémon maximum life points.
	/// </summary>
	public int HpMax { get; set; }
	
	/// <summary>
	/// Pokémon remaining life points.
	/// </summary>
	public int Hp
	{
		get
		{
			return hp_;
		}
		
		set
		{
			if (hp_ == value) return;
			
			hp_ = value;
			
			if (HpPropertyChanged != null) HpPropertyChanged.Invoke(this, new EventArgs());
		}
	}
	
	/// <summary>
	/// Pokémon attack.
	/// </summary>
	public int Attack { get; set; }
	
	/// <summary>
	/// Pokémon defense.
	/// </summary>
	public int Defense { get; set; }
	
	/// <summary>
	/// Pokémon special attack.
	/// </summary>
	public int SpecialAttack { get; set; }
	
	/// <summary>
	/// Pokémon special defense.
	/// </summary>
	public int SpecialDefense { get; set; }
	
	/// <summary>
	/// Pokémon speed.
	/// </summary>
	public int Speed { get; set; }
	
	/// <summary>
	/// Pokémon life point Individual Value.
	/// </summary>
	public int IVHp { get; set; }
	
	/// <summary>
	/// Pokémon attack Individual Value.
	/// </summary>
	public int IVAttack { get; set; }
	
	/// <summary>
	/// Pokémon defense Individual Value.
	/// </summary>
	public int IVDefense { get; set; }
	
	/// <summary>
	/// Pokémon special attack Individual Value.
	/// </summary>
	public int IVSpecialAttack { get; set; }
	
	/// <summary>
	/// Pokémon special defense Individual Value.
	/// </summary>
	public int IVSpecialDefense { get; set; }
	
	/// <summary>
	/// Pokémon speed Individual Value.
	/// </summary>
	public int IVSpeed { get; set; }
	
	/// <summary>
	/// Pokémon life point Effort Value.
	/// </summary>
	public int EVHp { get; set; }
	
	/// <summary>
	/// Pokémon attack Effort Value.
	/// </summary>
	public int EVAttack { get; set; }
	
	/// <summary>
	/// Pokémon defense Effort Value.
	/// </summary>
	public int EVDefense { get; set; }
	
	/// <summary>
	/// Pokémon special attack Effort Value.
	/// </summary>
	public int EVSpecialAttack { get; set; }
	
	/// <summary>
	/// Pokémon special defense Effort Value.
	/// </summary>
	public int EVSpecialDefense { get; set; }
	
	/// <summary>
	/// Pokémon speed Effort Value.
	/// </summary>
	public int EVSpeed { get; set; }
	
	/// <summary>
	/// Pokémon first type.
	/// </summary>
	public PokemonType TypeOne { get; set; }
	
	/// <summary>
	/// Pokémon second type.
	/// </summary>
	public PokemonType TypeTwo { get; set; }
	
	/// <summary>
	/// Pokémon current status.
	/// </summary>
	public PokemonStatus Status { 
		get
		{
			return status_;
		} 
		
		set
		{
			if (status_ == value) return;
			
			status_ = value;
			
			if (StatusPropertyChanged != null) StatusPropertyChanged.Invoke(this, new EventArgs());
		}
	}
	
	/// <summary>
	/// Pokémon nature.
	/// </summary>
	public PokemonNature PokemonNature { get; set; }
	
	/// <summary>
	/// Pokémon gender.
	/// </summary>
	public PokemonSex Sex { get; set; }
	
	/// <summary>
	/// If true the pokémon is shiny.
	/// </summary>
	public bool IsShiny { get; set; }
	
	/// <summary>
	/// If true the ability of the pokémon is the first one.
	/// </summary>
	public bool HasFirstAbility { get; set; }

	/// <summary>
	/// If true the pokemon has the hidden ability.
	/// </summary>
	public bool HasHiddenAbility { get; set; }
	
	/// <summary>
	/// If true the pokémon is an egg.
	/// </summary>
	public bool IsEgg { get; set; }
	
	/// <summary>
	/// Animation speed.
	/// </summary>
	public int TimePerFrame { get; set; }

	/// <summary>
	/// Pokémon first move.
	/// </summary>
	public Move MoveOne { get; set; }
	
	/// <summary>
	/// Pokémon second move.
	/// </summary>
	public Move MoveTwo { get; set; }
	
	/// <summary>
	/// Pokémon third move.
	/// </summary>
	public Move MoveThree { get; set; }
	
	/// <summary>
	/// Pokémon fourth move.
	/// </summary>
	public Move MoveFour { get; set; }
	
	/// <summary>
	/// Pokémon ability
	/// </summary>
	public Ability Ability { get; set; }
	
	/// <summary>
	/// Pokémon capture rate.
	/// </summary>
	public CatchCategory CatchCategory { get; set; }

	#region Private

	private int hp_;
	private PokemonStatus status_;
	
	#endregion
	
	#region Constructor
	
	/// <summary>
	/// Empty constructor.
	/// </summary>
	public Pokemon() { }
	
	#endregion
	
	#region Events
	
	public event EventHandler HpPropertyChanged;
	public event EventHandler StatusPropertyChanged;
	
	#endregion

	#region Static Methods

	/// <summary>
	/// Method which generates a wild random pokemon providing the name and level. TODO: istantiate the pokemon based on certain rules.
	/// </summary>
	public static Pokemon GenerateWildPokemon(string name, int level) 
	{
		return null;
	}

	#endregion
}
