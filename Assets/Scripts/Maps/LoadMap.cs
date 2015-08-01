using AncientTimes.Assets.Scripts.Utilities;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.WildPokemon
{
    public class LoadMap : MonoBehaviour
    {
        private string currentNameMap;
        private GameObject Places;

        // Use this for initialization
        void Start()
        {
            Places = GameObject.Find("Places");
            Destroy(GameObject.FindGameObjectWithTag("Places"));
            currentNameMap = GameVariables.GetVariable("CurrentMap");
            Debug.Log(currentNameMap);
            GameObject instance = Instantiate(Resources.Load(  "Maps/"+ currentNameMap, typeof(GameObject))) as GameObject;
            instance.transform.parent = Places.transform;
            instance.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
