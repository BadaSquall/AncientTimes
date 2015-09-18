using System.Net.Mime;
using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.Maps;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.WildPokemon
{

    public class WarpToMap : MonoBehaviour
    {

        #region Properties

        private GameObject Player;
        private bool IsIn = false;
        public string mapToWarp;
        public float posX;
        public float posY;
        public string EndWarp;

        #endregion Properties

        #region Methods

        private void Start() { Player = GameObject.FindGameObjectWithTag("Player"); }

        private void Update()
        {
            if (IsIn)
            {
                MapLoader.Load(mapToWarp);
                Player.transform.position = GameObject.Find(EndWarp).transform.position; 
            }
        }

        private void OnTriggerEnter2D(Collider2D coll) { IsIn = true; }

        private void OnTriggerStay2D(Collider2D coll) { IsIn = false; }

        private void OnTriggerExit2D(Collider2D coll) { IsIn = false; }

        #endregion Methods
    }
}