using UnityEngine;

namespace Assets.Scripts.Catch
{
    public class ProgressBar : MonoBehaviour
    {
        //public GameStatus GameStatus;
        public Texture2D bar;

        public Texture2D barFull;
        private Vector2 pos = new Vector2(20, 40);
        private Vector2 size = new Vector2(180, 60);
        private GUIStyle style;
        private Texture2D transparent;

        private void OnGUI()
        {
            // draw the background: 
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), bar, style);

            // draw the filled-in part:
            var Balance = CatchHUDManager.GetPressures()/10;
            GUI.BeginGroup(new Rect(0, 0, size.x * Balance / 30.0f, size.y), style);
            GUI.Box(new Rect(0, 0, size.x, size.y), barFull, style);
            GUI.EndGroup();

            GUI.EndGroup();
        }

        private void Start()
        {
            transparent = new Texture2D(1, 1);
            transparent.SetPixels(new[] { new Color(0.0f, 0.0f, 0.0f, 0.0f) });
            transparent.Apply();
            style = new GUIStyle { normal = new GUIStyleState { background = transparent } };
        }
    }
}