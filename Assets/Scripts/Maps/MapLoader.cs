using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.Maps
{
    public class MapLoader : MonoBehaviour
    {
        #region Methods

        void Start() { Load(GameVariables.Get("CurrentMap", "Isola")); }

        public static void Load(string mapName)
        {
            Destroy(GameObject.FindGameObjectWithTag("Places"));
            Instantiate(Resources.Load("Maps/" + mapName, typeof(GameObject)));
            GameVariables.Update("CurrentMap", mapName);
        }

        #endregion Methods
    }
}