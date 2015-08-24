using UnityEngine;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Utilities;
using System.Linq;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class EventManager : MonoBehaviour
    {
        #region Properties

        private Container actionContainer;

        #endregion Properties

        #region Methods
        
        void Update()
        {
            if (actionContainer == null) return;

            var action = actionContainer.Actions[0];

            if (action.Execute(Time.deltaTime)) actionContainer.Actions.Remove(action);

            if (actionContainer.Actions.Count == 0) actionContainer = null;
        }

        public void RegisterEvent(GameEvent evt)
        {
			if (evt == null || evt.Event == null) return;
            if (actionContainer != null) return;
            
            foreach (var container in evt.Event.Containers)
            {
                if (string.IsNullOrEmpty(container.Condition) || bool.Parse((string) (GameVariables.Get(container.Condition, true))) )
                {
                    actionContainer = container.Clone();
                    return;
                }
            }
        }

        /// <summary>
        /// Checks if an automatic event exists and plays it if it does.
        /// </summary>
        public void CheckAutoEvent()
        {
            var auto = GameObject.FindGameObjectWithTag("AutoEvent");
            if (auto != null) RegisterEvent(auto.GetComponent<GameEvent>());
        }

        #endregion Methods
    }
}