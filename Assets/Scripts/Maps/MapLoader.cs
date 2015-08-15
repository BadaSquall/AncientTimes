using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class MapLoader : MonoBehaviour
    {
        #region Methods

        void Start() { Load(GameVariables.GetVariable("CurrentMap")); }

        public static void Load(string mapName)
        {
            Destroy(GameObject.FindGameObjectWithTag("Places"));
            Instantiate(Resources.Load("Maps/" + mapName, typeof(GameObject)));
            GameVariables.UpdateVariable("CurrentMap", mapName);
        }

        #endregion Methods
    }
}