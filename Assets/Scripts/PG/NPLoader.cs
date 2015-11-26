using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;
using System.Linq;

namespace AncientTimes.Assets.Scripts.PG
{
    public class NPLoader : MonoBehaviour
    {
        #region Properties

        private GameObject NPIstantiated;

        #endregion Properties

        #region Methods

        void Start() { Load(GameVariables.Get("IsMan", true)); }

        void Load(string isMan)
        {
            if (isMan.Equals("True")) SetPlayer("Clarity/Clarity");
            else SetPlayer("Leon/Leon");
            NPIstantiated = GameObject.FindGameObjectWithTag("NonPlayer");
            SetPosition(NPIstantiated, this.gameObject.transform.position);
        }

        void SetPlayer(string path)
        {
            foreach (var NoPlayer in GameObject.FindGameObjectsWithTag("NonPlayer")) 
                NoPlayer.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(path) as RuntimeAnimatorController;
        }

        void SetPosition(GameObject player, Vector3 coordinates) { player.transform.position = coordinates; }

        #endregion Methods
    }
}
