using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.PG
{
    [RequireComponent(typeof(Animator))]
    public class StatusController : MonoBehaviour
    {
        #region Properties

        public enum Status { Idle = 0, WalkingRight, WalkingLeft, WalkingDown, WalkingUp, RunningRight, RunningLeft, RunningDown, RunningUp, StatusCount }
        public delegate void OnStatusChangeHandler(Status newStatus);
        public static event OnStatusChangeHandler OnStatusChange;
        private Animator animator;

        #endregion Properties

        #region Methods

        void Start() { animator = GetComponent<Animator>(); }

        void LateUpdate()
        {
            if (OnStatusChange == null) return;

            if (Input.GetKey("right")) OnStatusChange(Status.WalkingRight);
            else if (Input.GetKey("left")) OnStatusChange(Status.WalkingLeft);
            else if (Input.GetKey("down")) OnStatusChange(Status.WalkingDown);
            else if (Input.GetKey("up")) OnStatusChange(Status.WalkingUp);
            else OnStatusChange(Status.Idle);
        }

        public void WalkRight() { animator.SetTrigger("WalkRight"); }

        public void WalkLeft() { animator.SetTrigger("WalkLeft"); }

        public void WalkDown() { animator.SetTrigger("WalkDown"); }

        public void WalkUp() { animator.SetTrigger("WalkUp"); }

        #endregion Methods
    }
}