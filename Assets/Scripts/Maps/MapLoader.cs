using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class MapLoader : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Load(GameVariables.GetVariable("CurrentMap"));
        }

        public static void Load(string mapName)
        {
            Destroy(GameObject.FindGameObjectWithTag("Places"));
            GameObject instance = Instantiate(Resources.Load("Maps/" + mapName, typeof(GameObject))) as GameObject;
            GameVariables.UpdateVariable("CurrentMap",mapName);
        }
    }
}
