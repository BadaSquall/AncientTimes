using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.Maps
{
    public class Map : MonoBehaviour
    {
        void Start() { EventManager.CheckAutoEvent(); }
    }
}