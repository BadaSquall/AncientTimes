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
        private string name;
        #endregion Properties

        #region Methods


        // Use this for initialization
        void Start()
        {
            name = this.gameObject.name;

            if (name == "male") 
            { 
                shadow = GameObject.Find("shadowM");
                shadow.SetActive(false);
            }
            else if (name == "female")
            { 
                shadow = GameObject.Find("shadowF");
                shadow.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseEnter()
        {
            shadow.SetActive(true);
        }

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (name == "male")
                {
                    GameVariables.UpdateSwitch("IsMan", true);
                    GameVariables.UpdateSwitch("IsChosen", true);
                    GameObject.Find("female").SetActive(false);
                    this.gameObject.SetActive(false);
                }
                else if (name == "female")
                {
                    GameVariables.UpdateSwitch("IsMan", false);
                    GameVariables.UpdateSwitch("IsChosen",true);
                    GameObject.Find("male").SetActive(false);
                    this.gameObject.SetActive(false);
                }

                
            }
        }

        void OnMouseExit()
        {
            shadow.SetActive(false);
        }

        #endregion Methods

    }
}
