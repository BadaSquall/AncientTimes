using UnityEngine;
using System;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour 
{
	#region Private Properties

	private Dictionary<BattlePhase, IPriorityQueue<BattleAction>> phaseQueue = 
		new Dictionary<BattlePhase, IPriorityQueue<BattleAction>>();
	private BattlePhase currentPhase = BattlePhase.Choice;

	#endregion

	// Use this for initialization
	void Start() 
	{
		InitializeQueue();
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
			var currentAction = phaseQueue [currentPhase].Dequeue ();

			// execute currentAction
		}
	}

	private void InitializeQueue()
	{
		var phases = Enum.GetValues (typeof(BattlePhase));

		foreach (var phase in phases) 
		{
			phaseQueue.Add((BattlePhase) phase, new PriorityQueue<BattleAction>());
		}
	}

	private void LetPlayerChooseAndRegister()
	{

	}

	private void LetAiChooseAndRegister()
	{

	}
}
