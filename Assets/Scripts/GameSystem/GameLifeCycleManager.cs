using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.GameSystem
{
	public class GameLifeCycleManager : MonoBehaviour
	{
		#region Properties

		public Texture2D ConsoleBackground;
		public Texture2D NextMessageTriangle;

		#endregion Properties

		#region Methods

		private void Start()
		{
	//		Camera.main.aspect = 16.0f / 9.0f;
			Console.MessageStarted += () => GameVariables.Update("PlayerInputOff", true);
			Console.MessageComplete += () => GameVariables.Update("PlayerInputOff", false);
			Console.Background = ConsoleBackground;
			Console.NextMessageTriangle = NextMessageTriangle;
			Console.Instance.Destroy += DestroyManager;
			EventManager.Instance.Destroy += DestroyManager;
			EventManager.LoadEvents();
            EventManager.CheckAutoEvent();
		}

		private void Update()
		{
			EventManager.Update();
			Console.Update();
		}

		private void OnGUI() { Console.OnGUI(); }

		private void DestroyManager(GameObject objectToDestroy) { Destroy(objectToDestroy); }

		#endregion Methods
	}
}