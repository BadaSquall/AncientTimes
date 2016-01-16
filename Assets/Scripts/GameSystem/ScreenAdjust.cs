using UnityEngine;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class ScreenAdjust : MonoBehaviour
    {
        #region Methods

        void Start() { Camera.main.aspect = 16.0f / 9.0f; }

        #endregion Methods
    }
}