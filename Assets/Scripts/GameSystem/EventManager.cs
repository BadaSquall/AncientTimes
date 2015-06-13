using UnityEngine;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Utilities;

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
