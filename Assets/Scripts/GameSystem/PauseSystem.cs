using UnityEngine;
using System.Collections;

public class PauseSystem : MonoBehaviour {

	#region Properties

    public GUIStyle ButtonStyle;
	private bool isPaused = false;

	#endregion Properties

	#region Methods

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	void Pause()
	{
		if (!isPaused) 
		{
			Time.timeScale = 0f;
			isPaused = true;
		}else if (isPaused) 
		{
			Time.timeScale = 1f;
			isPaused = false;
		}
	}

	void OnGUI()
	{
        if (isPaused)
        {
            GUILayout.BeginArea(new Rect(Screen.width/2 -100 , Screen.height/5 -50 , Screen.width, Screen.height));
            GUILayout.Button("Pokedex", ButtonStyle);
            GUILayout.Button("Pokemon", ButtonStyle);
            GUILayout.Button("Zaino", ButtonStyle);
            GUILayout.Button("Save", ButtonStyle);
            if (GUILayout.Button("Esci dal gioco", ButtonStyle))
                Application.Quit();
            GUILayout.EndArea();
        } else if(!isPaused)
        {
            GUI.enabled = false;
        }

	}

	#endregion Methods

}
