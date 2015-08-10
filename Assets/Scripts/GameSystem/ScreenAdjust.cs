using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class ScreenAdjust : MonoBehaviour
    {
        void Start() { Camera.main.aspect = 16.0f/9.0f; }
    }
}
