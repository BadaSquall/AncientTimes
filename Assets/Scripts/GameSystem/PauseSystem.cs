using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class PauseSystem : MonoBehaviour
    {
	    #region Properties

        public GUIStyle ButtonStyle;

	    #endregion Properties

	    #region Methods
        /*
	    // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

	    void Pause()
	    {
            if (!bool.Parse(GameVariables.Get("IsPaused", false)))
            {
                GameVariables.Update("IsPaused", true);
                Time.timeScale = 0f;
            }
            else if (bool.Parse(GameVariables.Get("IsPaused", false)))
            {
                GameVariables.Update("IsPaused", false);
                Time.timeScale = 1f;
            }
        }

	    void OnGUI()
	    {
            if (bool.Parse(GameVariables.Get("IsPaused", false)))
            {
                GUILayout.BeginArea(new Rect(Screen.width/2 -100 , Screen.height/5 -50 , Screen.width, Screen.height));
                GUILayout.Button("Pokedex", ButtonStyle);
                GUILayout.Button("Pokemon", ButtonStyle);
                GUILayout.Button("Zaino", ButtonStyle);
                GUILayout.Button("Save", ButtonStyle);

                if (GUILayout.Button("Esci dal gioco", ButtonStyle)) Application.Quit();

                GUILayout.EndArea();
            }
            else if (!bool.Parse(GameVariables.Get("IsPaused", false))) GUI.enabled = false;
	    }   
        */
	    #endregion Methods
    }
}