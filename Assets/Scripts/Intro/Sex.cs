using UnityEngine;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;
using System.Collections;

namespace AncientTimes.Assets.Scripts.Intro
{
    public class Sex : MonoBehaviour
    {
        #region Properties

        private GameObject shadow;
        private string characterName;

        #endregion Properties

        #region Methods

        // Use this for initialization
        void Awake()
        {
            characterName = this.gameObject.name;

            if (characterName == "male") 
            { 
                shadow = GameObject.Find("shadowM");
                shadow.SetActive(false);
            }
            else if (characterName == "female")
            { 
                shadow = GameObject.Find("shadowF");
                shadow.SetActive(false);
            }
        }


        void OnMouseEnter()
        {
            shadow.SetActive(true);
        }

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (characterName == "male")
                {
                    GameVariables.Update("IsMan", true);
                    GameObject.Find("female").SetActive(false);
                    this.gameObject.SetActive(false);
                }
                else if (characterName == "female")
                {
                    GameVariables.Update("IsMan", false);
                    GameObject.Find("male").SetActive(false);
                    this.gameObject.SetActive(false);
                }
                GameVariables.Update("IsChosen", true);
                GameObject.Find("Intro").GetComponent<Intro>().SendMessage("SexConfirmed");
            }
        }

        void OnMouseExit()
        {
            shadow.SetActive(false);
        }

        #endregion Methods

    }
}
