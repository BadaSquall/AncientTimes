using System.Net.Mime;
using UnityEngine;
using System.Collections;
//using AncientTimes.Assets.Scripts.Maps;
using AncientTimes.Assets.Scripts.GameSystem;

namespace AncientTimes.Assets.Scripts.WildPokemon
{

    public class WarpToMap : MonoBehaviour
    {
        #region Properties

        private GameObject Player;
        private bool IsIn = false;
        public string mapToWarp;
        public string EndWarp;

        #endregion Properties

        #region Methods

        private void Start() {  }

        private void FixedUpdate() { if (IsIn) ChangeMap(); }

        private void OnTriggerEnter2D(Collider2D coll) { IsIn = true; }

        private void OnTriggerStay2D(Collider2D coll) { IsIn = false; }

        private void OnTriggerExit2D(Collider2D coll) { IsIn = false; }

        private void ChangeMap()
        {
            MapLoader.Load(mapToWarp);
            GameObject.Find("Player").transform.position = new Vector2(GameObject.Find(EndWarp).transform.position.x, GameObject.Find(EndWarp).transform.position.y);
        }
        #endregion Methods
    }
}