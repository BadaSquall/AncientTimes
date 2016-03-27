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
        public GameObject Squad;
        private GameObject Bag;
        private GameObject Pokedex;
        private GameObject TeamBg;

	    #endregion Properties

	    #region Methods

        void Start()
        {
            PauseMenu = GameObject.Find("PauseMenu");
            LoadButtons();
            TeamBg = GameObject.Find("TeamBg");
            Squad.SetActive(false);
 
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
            //GameObject.Find("Bag").GetComponent<Button>().onClick.AddListener(DoThing("Bag"));
            //GameObject.Find("Exit").GetComponent<Button>().onClick.AddListener(DoThing("Exit"));
            GameObject.Find("Squad").GetComponent<Button>().onClick.AddListener(OpenSquad);
            //GameObject.Find("Save").GetComponent<Button>().onClick.AddListener(DoThing("Save"));
            //GameObject.Find("Pokedex").GetComponent<Button>().onClick.AddListener(DoThing("Pokedex"));
            PauseMenu.SetActive(false);
        }

        void OpenSquad()
        {
            Squad.SetActive(true);
            TeamBg.SetActive(true);
            Squad.transform.GetChild(1).gameObject.SetActive(true);
            PauseMenu.SetActive(false);
            foreach ( GameObject place in GameObject.FindGameObjectsWithTag("Places")){
                place.SetActive(false);
            }
        }

        UnityEngine.Events.UnityAction DoThing(string thing)
        {
            switch (thing)
            {
                case "Bag": //Bag.SetActive(true);
                    break;
                case "Exit":
                    break;
                case "Squad":
                    {
                        
                    }
                    break;
                case "Save": //Save.SetActive(true);
                    break;
                case "Pokedex": //Pokedex.SetActive(true);
                    break; 
            }
            PauseMenu.SetActive(false);
            return null;
        }

	    #endregion Methods
    }
}