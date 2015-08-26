using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;

public class GameLifeCycle : MonoBehaviour
{
	void Start ()
    {
        Console.MessageStarted += () => GameVariables.Update("Pause", true);
        Console.MessageComplete += () => GameVariables.Update("Pause", false);
	}
}