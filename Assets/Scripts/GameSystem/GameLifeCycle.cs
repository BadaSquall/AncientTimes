using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;

public class GameLifeCycle : MonoBehaviour
{
	void Start ()
    {
        Console.MessageStarted += () => GameVariables.UpdateSwitch("Pause", true);
        Console.MessageComplete += () => GameVariables.UpdateSwitch("Pause", false);
	}
}