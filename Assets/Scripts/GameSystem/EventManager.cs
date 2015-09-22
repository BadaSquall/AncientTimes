using UnityEngine;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System.Linq;

namespace AncientTimes.Assets.Scripts.GameSystem
{
	/// <summary>
	/// The event manager class.
	/// </summary>
	public class EventManager : GameSystemObject
	{
		#region Properties

		private static EventManager instance;

		public static EventManager Instance
		{
			get
			{
				instance = instance ?? new EventManager();
				return instance;
			}
		}

		private static ActionBase action;

        public static event System.Action EventStarted;

        public static event System.Action EventFinished;

		/// <summary>
		/// The current event being executed.
		/// </summary>
		public static GameEvent CurrentEvent;

		private static List<GameEvent> eventsInScene;
		
		#endregion Properties

		#region Constructor

		private EventManager() {}

		#endregion Constructor

		#region Methods

		/// <summary>
		/// Update this instance.
		/// </summary>
		public static void Update()
		{
			if (eventsInScene == null) return;

			CheckActiveEvents();

            if (action == null) return;

            if (ExecuteActions(action))
            {
                action = null;
                CurrentEvent = null;
                if (EventFinished != null) EventFinished();
            }
		}

		/// <summary>
		/// Registers the event and plays it.
		/// </summary>
		/// <param name="evt">The event.</param>
		public static void RegisterEvent(GameEvent evt)
		{
			if (evt == null || evt.Event == null) return;
            if (action != null) return;
			action = evt.Event.FirstAction.Clone();
			CurrentEvent = evt;
            if (EventStarted != null) EventStarted();

			return;
		}
		
		/// <summary>
		/// Checks if an automatic event exists and plays it if it does.
		/// </summary>
		public static void CheckAutoEvent()
		{
			var auto = GameObject.FindGameObjectWithTag("AutoEvent");
			if (auto != null) RegisterEvent(auto.GetComponent<GameEvent>());
		}

		/// <summary>
		/// Loads the events in the current scene.
		/// </summary>
		public static void LoadEvents() { eventsInScene = Object.FindObjectsOfType<GameEvent>().ToList(); }

        /// <summary>
        /// Checks the active events.
        /// </summary>
		private static void CheckActiveEvents()
		{
			eventsInScene.ForEach
			(
				evt =>
				{
					if (bool.Parse(GameVariables.Get(evt.Event.Condition ?? "TrickyAlwaysExists!", true))) evt.gameObject.SetActive(true);
					else evt.gameObject.SetActive(false);
				}
			);
		}

        /// <summary>
        /// Executes the actions.
        /// </summary>
        /// <param name="actionToExecute">The action to execute.</param>
        private static bool ExecuteActions(ActionBase actionToExecute)
        {
            if (actionToExecute == null) return true;

            if (!actionToExecute.IsFinished) actionToExecute.Execute(Time.deltaTime);

            return actionToExecute.IsParallel ? ExecuteActions(actionToExecute.NextAction) && actionToExecute.IsFinished :
                actionToExecute.IsFinished ? ExecuteActions(actionToExecute.NextAction) :
                    false;
        }
		
		#endregion Methods
	}
}