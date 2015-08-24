using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using AncientTimes.Assets.Scripts.Utilities;

public class BattleSystem : MonoBehaviour 
{
	#region Private

	private readonly Dictionary<BattlePhase, IPriorityQueue<BattleAction>> phaseQueue = 
		new Dictionary<BattlePhase, IPriorityQueue<BattleAction>>();

	private BattlePhase currentPhase = BattlePhase.Choice;

    private readonly List<GameObject> playerGameObjects = new List<GameObject>();
    private readonly List<GameObject> enemyGameObjects = new List<GameObject>(); 

	#endregion

    #region Public Static
    // TODO: put into a static struct if they get too many, maybe BattleInfo?
    public static List<Pokemon> EnemyTeam = new List<Pokemon>();
    public static Trainer Trainer;

    #endregion

    // Use this for initialization
	void Start() 
	{
		InitializeQueue();

        // test
        StaticVariables.PlayerTeam.Add(new Pokemon
        {
            Name = "Hanemode"
        });

        EnemyTeam.Add(new Pokemon
        {
            Name = "Hanemode"
        });

	    var activePokemonsNo = 1;

	    if (Trainer != null)
	    {
	        activePokemonsNo = Trainer.ActivePokemons;
	    }

        // Player Pokemon prefab istantiation
	    foreach (var pokemon in StaticVariables.PlayerTeam.Take(activePokemonsNo))
	    {
            // example prefab istantiation
            var tmpPrefab = Resources.Load("Prefab/Pokemon/" + pokemon.Name + "Rear");

            var tmpGameObject = Instantiate(tmpPrefab) as GameObject;
            playerGameObjects.Add(tmpGameObject);
	    }    

        // Enemy Pokemon prefab istantiation
	    foreach (var pokemon in EnemyTeam.Take(activePokemonsNo))
	    {
            // example prefab istantiation
            var tmpPrefab = Resources.Load("Prefab/Pokemon/" + pokemon.Name + "Front");

            var tmpGameObject = Instantiate(tmpPrefab) as GameObject;
            enemyGameObjects.Add(tmpGameObject);
	    }
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (phaseQueue[currentPhase].Count() == 0) 
		{
			if(currentPhase == BattlePhase.AbilityCheck9)
				currentPhase = BattlePhase.Choice;
			else 
				currentPhase = (BattlePhase)((int) currentPhase + 1);
		}

		if (currentPhase == BattlePhase.Choice) 
		{
			LetPlayerChooseAndRegister();
			LetAiChooseAndRegister();

			currentPhase = BattlePhase.AbilityCheck1;
		} 
		else 
		{
			var currentAction = phaseQueue[currentPhase].Dequeue();

			// execute currentAction
		}
	}

    void OnDestroy()
    {
        foreach (var gameObj in playerGameObjects)
        {
            Destroy(gameObj);
        }

        foreach (var gameObj in enemyGameObjects)
        {
            Destroy(gameObj);
        }
    }

    /// <summary>
    /// Initializes the queue.
    /// </summary>
	private void InitializeQueue()
	{
		var phases = Enum.GetValues(typeof(BattlePhase));

		foreach (var phase in phases) 
		{
			phaseQueue.Add((BattlePhase) phase, new PriorityQueue<BattleAction>());
		}
	}

    /// <summary>
    /// Lets the player choose and registers the chosen actions.
    /// </summary>
	private void LetPlayerChooseAndRegister()
	{

	}

    /// <summary>
    /// Lets the AI choose and registers the chosen actions.
    /// </summary>
	private void LetAiChooseAndRegister()
	{

	}

    /// <summary>
    /// Starts the wild battle.
    /// </summary>
    /// <param name="pokemonName">Name of the pokemon.</param>
    /// <param name="level">The level.</param>
    public static void StartWildBattle(string pokemonName, int level)
    {
        var pokemon = RandomPokemonGenerator.GenerateWildPokemon(pokemonName, level);

        EnemyTeam = new List<Pokemon> { pokemon };

        Application.LoadLevel("Battle");
    }

    /// <summary>
    /// Starts the trainer battle.
    /// </summary>
    /// <param name="trainer">The trainer.</param>
    public static void StartTrainerBattle(Trainer trainer)
    {
        EnemyTeam = trainer.Team;
        Trainer = trainer;

        Application.LoadLevel("Battle");
    }
}