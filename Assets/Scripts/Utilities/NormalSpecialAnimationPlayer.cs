using UnityEngine;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities
{
    [RequireComponent(typeof(Animator))]
    public class NormalSpecialAnimationPlayer : MonoBehaviour
    {
        #region Properties

        public int NormalLoopsCount = 1;
        public int SpecialLoopsCount = 1;
        private Animator animator;
        private int normalCount;
        private int specialCount;

        #endregion Properties

        #region Methods

        void Start() { animator = GetComponent<Animator>(); }

        public void NormalFinished()
        {
            normalCount++;
            Debug.Log("Ci sono");
            if (normalCount >= NormalLoopsCount)
            {
                normalCount = 0;
                animator.SetTrigger("Special");
            }
        }

        public void SpecialFinished()
        {
            specialCount++;

            if (specialCount >= SpecialLoopsCount)
            {
                specialCount = 0;
                animator.SetTrigger("Normal");
            }
        }

        #endregion Methods
    }
}
