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
        public Texture2D FadeTexture;
        public bool ManageMapLoader;
		#endregion Properties

		#region Methods

		private void Start()
		{
			Console.Background = ConsoleBackground;
			Console.NextMessageTriangle = NextMessageTriangle;

			Console.Instance.Destroy += DestroyManager;
			EventManager.Instance.Destroy += DestroyManager;
            MapLoader.Instance.Destroy += DestroyManager;

            Console.Instance.Instantiate += InstantiateManager;
            EventManager.Instance.Instantiate += InstantiateManager;
            MapLoader.Instance.Instantiate += InstantiateManager;

            EventManager.EventStarted += () => GameVariables.Update("PlayerInputOff", true);
            EventManager.EventFinished += () => GameVariables.Update("PlayerInputOff", false);

            Fading.FadeTexture = FadeTexture;

            if (ManageMapLoader) MapLoader.Load(GameVariables.Get("CurrentMap", "Isola"));
		}

		private void Update()
		{
			EventManager.Update();
            Fading.Update();
			Console.Update();

            if (Input.GetKeyDown(KeyCode.Q)) Fading.FadeOut();
		}

		private void OnGUI()
        {
            Console.OnGUI();
            Fading.OnGUI();
        }

		private void DestroyManager(GameObject objectToDestroy) { Destroy(objectToDestroy); }
        private Object InstantiateManager(Object objectToInstantiate) { return Instantiate(objectToInstantiate); }

		#endregion Methods
	}
}