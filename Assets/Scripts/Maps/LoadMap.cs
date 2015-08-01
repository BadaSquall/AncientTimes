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
            currentNameMap = GameVariables.Variables["CurrentMap"];
            Debug.Log(currentNameMap);
            GameObject instance = Instantiate(Resources.Load(currentNameMap, typeof(GameObject))) as GameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}