using UnityEngine;
using AncientTimes.Assets.Scripts.GameSystem;
using System.Collections;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class Intro : MonoBehaviour
    {
        #region Properties

        Animator animator;
        GameObject Kerneth;
        #endregion Properties

        #region Methods
        void Start()
        {
            Kerneth = GameObject.Find("KernethSprite");
            animator = Kerneth.GetComponent<Animator>();
        }

        void Update()
        {
            Console.Write("Ciao");
            if (Input.GetKeyDown("t"))
            {
                animator.SetBool("isOut", true);
            }
        }

        #endregion Methods

    }
}
