using UnityEngine;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events.Actions;
using System.IO;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.Events
{
	public class GameEvent : MonoBehaviour
	{
		#region Properties

		public SerializableGameEvent Event;
		public TextAsset EventFile;
		
		#endregion Properties
		
		#region Constructors
		
		public GameEvent() { Event = new SerializableGameEvent(); }
		
		#endregion Constructor
		
		#region Methods
		
		private void Start()
		{
			if (EventFile == null)
			{
				Debug.LogWarning("An event file should be attached to a Game Event object");
				return;
			}

            ForceLoad();
		}

        public void ForceLoad() { Event = (SerializableGameEvent)Utilities.XMLDeserializer.Deserialize(typeof(SerializableGameEvent), EventFile); }
		
		#endregion Methods
	}
}