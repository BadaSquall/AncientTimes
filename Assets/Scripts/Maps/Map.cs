using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.Maps
{
    public class Map : MonoBehaviour
    {
        void Start()
        {
            var eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
            eventManager.CheckAutoEvent();
        }
    }
}