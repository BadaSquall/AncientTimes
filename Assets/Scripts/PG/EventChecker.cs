using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.PG
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EventChecker : MonoBehaviour
    {
        #region Properties

        private EventManager eventManager;

        #endregion Properties

        #region Methods

        void Start() { eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>(); }

        void OnTriggerStay2D(Collider2D other)
        {
            if (GameVariables.GetSwitch("Pause")) return;
            if (Input.GetButtonDown("Submit"))
            {
                var gameEvent = other.GetComponent<GameEvent>();
                if (gameEvent != null) eventManager.RegisterEvent(gameEvent);
            }
        }

        #endregion Methods
    }
}
