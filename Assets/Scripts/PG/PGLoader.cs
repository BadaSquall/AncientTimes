using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.Intro
{
    public class PGLoader : MonoBehaviour
    {
        #region Methods

        void Start() { Load((GameVariables.Get("IsMan", true))); }

        public static void Load(string isMan)
        {
            if (isMan.Equals("True")) Instantiate(Resources.Load("PG/" + "Leon", typeof(GameObject)));
            else Instantiate(Resources.Load("PG/" + "Clarity", typeof(GameObject)));
        }

        #endregion Methods
    }
}
