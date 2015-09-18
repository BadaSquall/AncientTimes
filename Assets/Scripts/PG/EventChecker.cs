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
        #region Methods

        private void OnTriggerStay2D(Collider2D other)
        {
            if (bool.Parse(GameVariables.Get("Pause", false))) return;
            if (Input.GetButtonDown("Submit"))
            {
                var gameEvent = other.GetComponent<GameEvent>();
                if (gameEvent != null) EventManager.RegisterEvent(gameEvent);
            }
        }

        #endregion Methods
    }
}