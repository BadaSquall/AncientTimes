using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.PG
{
    public class PGLoader : MonoBehaviour
    {
        #region Properties

        private GameObject PlayerIstantiated;
        private string PlayerPositionX;
        private string PlayerPositionY;

        #endregion Properties

        #region Methods

        void Start()
        {
            Load((GameVariables.Get("IsMan", true)));
        }

        void Load(string isMan)
        {
            if (isMan.Equals("True")) Instantiate(Resources.Load("PG/" + "Leon", typeof(GameObject)));
            else Instantiate(Resources.Load("PG/" + "Clarity", typeof(GameObject)));

            PlayerIstantiated = GameObject.FindGameObjectWithTag("Player");
            PlayerPositionX = GameVariables.Get("PlayerPositionX",this.gameObject.transform.position.x);
            PlayerPositionY = GameVariables.Get("PlayerPositionY", this.gameObject.transform.position.y);

            SetPosition(PlayerIstantiated, float.Parse(PlayerPositionX), float.Parse(PlayerPositionY));
        }

        void SetPosition(GameObject player, float x, float y)
        {
            player.transform.position = new Vector3(x, y);
        }

        #endregion Methods
    }
}
