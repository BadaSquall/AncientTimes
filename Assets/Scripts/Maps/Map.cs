using UnityEngine;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.Maps
{
    public class Map : MonoBehaviour
    {
        #region Properties

        void Start()
        {
            EventManager.LoadEvents();
            EventManager.CheckAutoEvent();
        }

        #endregion Properties
    }
}