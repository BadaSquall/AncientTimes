using System;
using System.Collections.Generic;

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
	/// If true the pokémon is exotic.
	/// </summary>
	public bool IsExotic { get; set; }
	
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
	/// Pokémon special move.
	/// </summary>
	public Move SpecialMove { get; set; }

	/// <summary>
	/// Pokémon special move condition.
	/// </summary>
	public SpecialMoveCondition SpecialMoveCondition { get; set; }
	
	/// <summary>
	/// Pokémon ability
	/// </summary>
	public Ability Ability { get; set; }
	
	/// <summary>
	/// Pokémon capture rate.
	/// </summary>
	public CatchCategory CatchCategory { get; set; }

	/// <summary>
	/// Pokémon generation.
	/// </summary>
	public int Generation { get; set; }

	/// <summary>
	/// Pokémon friendship.
	/// </summary>
	public int Friendship { get; set; }

	/// <summary>
	/// Pokémon affinities for every type.
	/// </summary>
	public Dictionary<PokemonType, int> Affinities { get; set; }

	/// <summary>
	/// Pokémon resistences for every type.
	/// </summary>
	public Dictionary<PokemonType, int> Resistences { get; set; }

	#region Private

	private int hp_;
	private PokemonStatus status_;
	
	#endregion
	
	#region Constructor
	
	/// <summary>
	/// Empty constructor.
	/// </summary>
	public Pokemon() 
	{
		Affinities = new Dictionary<PokemonType, int>();
		Resistences = new Dictionary<PokemonType, int>();

		Generation = 0;
		Friendship = 0;
	}

	#endregion
	
	#region Events
	
	public event EventHandler HpPropertyChanged;
	public event EventHandler StatusPropertyChanged;
	
	#endregion
}