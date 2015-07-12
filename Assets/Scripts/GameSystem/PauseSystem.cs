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

	    // Update is called once per frame
	    void Update () { if (Input.GetKeyDown (KeyCode.Escape)) Pause(); }

	    void Pause()
	    {
            if (!GameVariables.Switches["IsPaused"]) GameVariables.Switches["IsPaused"] = true;
            else if (GameVariables.Switches["IsPaused"]) GameVariables.Switches["IsPaused"] = false;
	    }

	    void OnGUI()
	    {
            if (GameVariables.Switches["IsPaused"])
            {
                GUILayout.BeginArea(new Rect(Screen.width/2 -100 , Screen.height/5 -50 , Screen.width, Screen.height));
                GUILayout.Button("Pokedex", ButtonStyle);
                GUILayout.Button("Pokemon", ButtonStyle);
                GUILayout.Button("Zaino", ButtonStyle);
                GUILayout.Button("Save", ButtonStyle);

                if (GUILayout.Button("Esci dal gioco", ButtonStyle)) Application.Quit();

                GUILayout.EndArea();
            }
            else if (!GameVariables.Switches["IsPaused"]) GUI.enabled = false;
	    }   

	    #endregion Methods
    }
}