using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.PG
{
    public class NPLoader : MonoBehaviour
    {
        #region Properties

        private GameObject NPIstantiated;

        #endregion Properties

        #region Methods

        void Start()
        {
            Load((GameVariables.Get("IsMan", true)));
        }

        void Load(string isMan)
        {
            if (isMan.Equals("True")) Instantiate(Resources.Load("PG/" + "NPClarity", typeof(GameObject)));
            else Instantiate(Resources.Load("PG/" + "NPLeon", typeof(GameObject)));

            NPIstantiated = GameObject.FindGameObjectWithTag("NonPlayer");
            SetPosition(NPIstantiated, this.gameObject.transform.position);
        }

        void SetPosition(GameObject player, Vector3 coordinates)
        {
            player.transform.position = coordinates;
        }

        #endregion Methods
    }
}
