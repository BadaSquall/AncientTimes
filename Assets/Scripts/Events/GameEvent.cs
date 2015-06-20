using UnityEngine;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events.Actions;
using System.IO;

namespace AncientTimes.Assets.Scripts.Events
{
    public class GameEvent : MonoBehaviour
    {
        #region Properties

        private SerializableGameEvent evt;

        public SerializableGameEvent Event
        {
            get
            {
                foreach (var container in evt.Containers)
                {
                    if (!ContainersVisibles.ContainsKey(container)) ContainersVisibles.Add(container, true);

                    foreach (var action in container.Actions)
                    {
                        if (ActionsVisibles.ContainsKey(container))
                            if (ActionsVisibles[container].ContainsKey(action)) continue;
                            else ActionsVisibles[container].Add(action, true);
                        else
                        {
                            ActionsVisibles.Add(container, new Dictionary<ActionBase, bool>());
                            ActionsVisibles[container].Add(action, true);
                        }
                    }
                }

                return evt;
            }

            set { evt = value; }
        }

        public Dictionary<Container, bool> ContainersVisibles { get; private set; }
        public Dictionary<Container, Dictionary<ActionBase, bool>> ActionsVisibles { get; private set; }

        #endregion Properties

        #region Constructors

        public GameEvent()
        {
            Event = new SerializableGameEvent();
            ContainersVisibles = new Dictionary<Container, bool>();
            ActionsVisibles = new Dictionary<Container, Dictionary<ActionBase, bool>>();
            Debug.Log("Fregato");
        }

        #endregion Constructor

        #region Methods

        void Start()
        {
            var filePath = @"Assets/Events/" + Application.loadedLevelName + "/" + name + ".xml";
            if (File.Exists(filePath)) Event = (SerializableGameEvent)Utilities.XMLDeserializer.Deserialize(typeof(SerializableGameEvent), filePath);
        }

        #endregion Methods
    }
}
