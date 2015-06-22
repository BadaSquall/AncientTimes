using UnityEngine;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public class ScreenMoveAndResize : MonoBehaviour
    {
        public Vector2 ScreenDefinition = new Vector2(1920, 1080);

        void Start()
        {
			var scaleX = Screen.width / ScreenDefinition.x;
			var scaleY = Screen.height / ScreenDefinition.y;
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * scaleX, gameObject.transform.localScale.y * scaleY, 1.0f);
			gameObject.transform.position = new Vector3(gameObject.transform.position.x * scaleX, gameObject.transform.position.y * scaleY, 1.0f);
		
		}
    }
}