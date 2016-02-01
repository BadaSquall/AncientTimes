using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AncientTimes.Assets.Scripts.Utilities;

public class BattleSystem : MonoBehaviour 
{
	#region Private

	private readonly Dictionary<BattlePhase, IPriorityQueue<BattleAction>> phaseQueue = 
		new Dictionary<BattlePhase, IPriorityQueue<BattleAction>>();

    private GameObject backgroundObject;
    private readonly List<GameObject> playerGameObjects = new List<GameObject>();
    private readonly List<GameObject> enemyGameObjects = new List<GameObject>();
    private GameObject moveObject;

    private readonly BattleState battleState = new BattleState();

    private BattleAction currentAction = null;

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

	    var mapName = GameVariables.Get("CurrentMap", "");

        // Resources.Load("BattleMaps/" + mapName");

        // test
	    backgroundObject = Instantiate(Resources.Load("BattleMaps/TempioNight"), 
            new Vector3(0, 0, 1), new Quaternion(0, 0, 0, 0)) as GameObject;

        // test
	    var playerTeam = (List<Pokemon>) GameVariables.Get("PlayerTeam", new List<Pokemon>());
        playerTeam.Add(new Pokemon
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
	    foreach (var pokemon in playerTeam.Take(activePokemonsNo))
	    {
            // example prefab istantiation
            var tmpPrefab = Resources.Load("Prefab/Pokemon/" + pokemon.Name + "Rear");

            var tmpGameObject = Instantiate(tmpPrefab) as GameObject;

	        if (tmpGameObject == null) continue;
	        tmpGameObject.transform.position = SpritePositionCalculator.GetOffsetForPokemon(tmpGameObject, true);

	        playerGameObjects.Add(tmpGameObject);
	    }    

        // Enemy Pokemon prefab istantiation
	    foreach (var pokemon in EnemyTeam.Take(activePokemonsNo))
	    {
            // example prefab istantiation
            var tmpPrefab = Resources.Load("Prefab/Pokemon/" + pokemon.Name + "Front");

            var tmpGameObject = Instantiate(tmpPrefab) as GameObject;

            if (tmpGameObject == null) continue;
            tmpGameObject.transform.position = SpritePositionCalculator.GetOffsetForPokemon(tmpGameObject, false);

            enemyGameObjects.Add(tmpGameObject);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
        // Check if action animation completed
	    if (moveObject != null && currentAction != null)
	    {
	        var stateInfo = moveObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

	        if (stateInfo.IsName(currentAction.ExecutedMove.Name) && stateInfo.normalizedTime >= 1.0f)
	        {
	            currentAction.IsActionCompleted = true;
	        }
	    }

	    if (currentAction != null && !currentAction.IsActionCompleted) return;

        if (phaseQueue[battleState.CurrentPhase].Count() == 0) 
		{
            if (battleState.CurrentPhase == BattlePhase.AbilityCheck9)
                battleState.CurrentPhase = BattlePhase.Choice;
			else
                battleState.CurrentPhase = (BattlePhase)((int) battleState.CurrentPhase + 1);
		}

        if (battleState.CurrentPhase == BattlePhase.Choice) 
		{
			LetPlayerChooseAndRegister();
			LetAiChooseAndRegister();

            battleState.CurrentPhase = BattlePhase.AbilityCheck1;
		} 
		else 
		{
            currentAction = phaseQueue[battleState.CurrentPhase].Dequeue();

		    if (currentAction != null)
		    {
                var actionPrefab = Resources.Load(currentAction.PrefabPath);
                moveObject = Instantiate(actionPrefab) as GameObject;

		        currentAction.Execute(Time.time, battleState);
		    }
		}
	}

    /// <summary>
    /// Called when the GameObject is destroyed.
    /// </summary>
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

        Destroy(backgroundObject);
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