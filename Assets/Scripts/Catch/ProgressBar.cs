using System;
using System.Reflection.Emit;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Catch
{
    public class ProgressBar : MonoBehaviour
    {
        public Texture2D bar;
        public Texture2D barFull;
        private Vector2 pos = new Vector2(223, 691);
        private Vector2 size = new Vector2(900, 62);
        private GUIStyle style;
        private GUIStyle labelStyle;
        private Texture2D transparent;
        private float barPercentage;
        private int count;
        private double pressuresNeeded;
        private float timer;

        private void OnGUI()
        {
            GUISizer.BeginGUI();
            // draw the background: 
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), bar, style);

            // draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, (float)size.x * (float)barPercentage, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), barFull, style);
            GUI.EndGroup();

            GUI.EndGroup();

            GUI.skin.label = labelStyle;
            GUI.Label(new Rect(5, 0, 30, 30), (Math.Round(timer, 2)).ToString(), labelStyle);

            GUISizer.EndGUI();
        }

        private void Start()
        {
            ScenesCommunicator.IsCatched = false;
            labelStyle = new GUIStyle { normal = new GUIStyleState { background = transparent, textColor = Color.white}, fontSize = 50};

            //Pokemon pokemon = ScenesCommunicator.Pokemon;
            Pokemon pokemon = new Pokemon() {Hp = 100, HpMax = 100, CatchCategory = CatchCategory.NonCommon, Level = 50};


            transparent = new Texture2D(1, 1);
            transparent.SetPixels(new[] { new Color(0.0f, 0.0f, 0.0f, 0.0f) });
            transparent.Apply();
            style = new GUIStyle { normal = new GUIStyleState { background = transparent } };
            barPercentage = 0;
            count = 0;
            pressuresNeeded = CatchHUDManager.GetMaxPressures(pokemon);
            timer = 3;
            Camera.main.aspect = 16.0f/9.0f;
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
            {
                ScenesCommunicator.IsCatched = true;
                Application.LoadLevel("Battle");
            }
        }
    }
}