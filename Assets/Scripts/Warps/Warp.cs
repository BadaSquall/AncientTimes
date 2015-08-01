using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.Warps
{
    public class Warp : MonoBehaviour
    {

        #region Properties

        public GameObject InB;
        private GameObject Player;
        private bool IsIn = false;

        #endregion Properties

        #region Methods


        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        // Update is called once per frame
        void Update()
        {
            if (IsIn)
            {
                Player.transform.position = new Vector3(InB.transform.position.x, InB.transform.position.y);
            }

        }


        void OnTriggerEnter2D(Collider2D coll)
        {
            IsIn = true;
        }

        void OnTriggerStay2D(Collider2D coll)
        {
            IsIn = false;
        }

        void OnTriggerExit2D(Collider2D coll)
        {
            IsIn = false;
        }

        #endregion Methods

    }
}