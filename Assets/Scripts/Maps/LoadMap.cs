using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class LoadMap : MonoBehaviour
    {
        private string currentNameMap;

        // Use this for initialization
        void Start()
        {
            Destroy(GameObject.FindGameObjectWithTag("Places"));
            currentNameMap = GameVariables.GetVariable("CurrentMap");
            Debug.Log(currentNameMap);
            /* var instance = */Instantiate(Resources.Load("Maps/"+ currentNameMap, typeof(GameObject)))/* as GameObject */;
        }
    }
}
