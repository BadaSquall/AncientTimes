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
            if (actionContainer != null) return;

            foreach (var container in evt.Containers)
            {
                if (!GameVariables.Switches.ContainsKey(container.Condition)) return;

                if (GameVariables.Switches[container.Condition])
                {
                    actionContainer = container;
                    return;
                }
            }
        }

        #endregion Methods
    }
}
