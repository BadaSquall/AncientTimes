using System;
using UnityEngine;

namespace Assets.Scripts.Catch
{
    public class ProgressBar : MonoBehaviour
    {
        //public GameStatus GameStatus;
        public Texture2D bar;
        public Texture2D barFull;
        private Vector2 pos = new Vector2(10, 130);
        private Vector2 size = new Vector2(180, 60);
        private GUIStyle style;
        private Texture2D transparent;
        private float barPercentage;
        private int count;
        private int pressuresNeeded;
        private float timer;

        private void OnGUI()
        {
            // draw the background: 
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), bar, style);

            // draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, (float)size.x * (float)barPercentage, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), barFull, style);
            GUI.EndGroup();

            GUI.EndGroup();

            GUI.Label(new Rect(5, 0, 30, 30), (Math.Round(timer, 2)).ToString());
        }

        private void Start()
        {
            transparent = new Texture2D(1, 1);
            transparent.SetPixels(new[] { new Color(0.0f, 0.0f, 0.0f, 0.0f) });
            transparent.Apply();
            style = new GUIStyle { normal = new GUIStyleState { background = transparent } };
            barPercentage = 0;
            count = 0;
            pressuresNeeded = CatchHUDManager.GetMaxPressures();
            timer = 3;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                barPercentage = (float)count/(float)pressuresNeeded;   
            }
            if (timer <= 0 || count >= pressuresNeeded)
                Application.LoadLevel("");
            
        }
    }
}