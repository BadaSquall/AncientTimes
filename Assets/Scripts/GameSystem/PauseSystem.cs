using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class PauseSystem : MonoBehaviour
    {
	    #region Properties

        private GameObject PauseMenu;
        private GameObject Save;
        private GameObject Squad;
        private GameObject Bag;
        private GameObject Pokedex;

	    #endregion Properties

	    #region Methods

        void Start()
        {
            PauseMenu = GameObject.Find("PauseMenu");
            PauseMenu.SetActive(false);
            Save.SetActive(false);
            Squad.SetActive(false);
            Bag.SetActive(false);
            Pokedex.SetActive(false);
        }

	    void Update () { if (Input.GetKeyDown (KeyCode.Escape)) Pause(); }

	    void Pause()
	    {
            if (!bool.Parse(GameVariables.Get("IsPaused", false)))
            {
                GameVariables.Update("IsPaused", true);
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
            }
            else if (bool.Parse(GameVariables.Get("IsPaused", false)))
            {
                GameVariables.Update("IsPaused", false);
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
            }
        }

        void LoadButtons()
        {
            GameObject.Find("Bag").GetComponent<Button>().onClick.AddListener(DoThing("Bag"));
            GameObject.Find("Exit").GetComponent<Button>().onClick.AddListener(DoThing("Exit"));
            GameObject.Find("Squad").GetComponent<Button>().onClick.AddListener(DoThing("Squad"));
            GameObject.Find("Save").GetComponent<Button>().onClick.AddListener(DoThing("Save"));
            GameObject.Find("Pokedex").GetComponent<Button>().onClick.AddListener(DoThing("Pokedex"));
        }

        UnityEngine.Events.UnityAction DoThing(string thing)
        {
            switch (thing)
            {
                case "Bag": Bag.SetActive(true);
                    break;
                case "Exit":
                    break;
                case "Squad": Squad.SetActive(true);
                    break;
                case "Save": Save.SetActive(true);
                    break;
                case "Pokedex": Pokedex.SetActive(true);
                    break; 
            }
            PauseMenu.SetActive(false);
            return null;
        }

	    #endregion Methods
    }
}