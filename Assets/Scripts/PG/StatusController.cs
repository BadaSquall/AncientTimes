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
        private float walkSpeed;

        #endregion Properties

        #region Methods

        void Start()
        {
            animator = GetComponent<Animator>();
            walkSpeed = 300.0f;
        }

        void LateUpdate()
        {
            if (OnStatusChange == null) return;

            if (Input.GetKey("right")) OnStatusChange(Status.WalkingRight);
            else if (Input.GetKey("left")) OnStatusChange(Status.WalkingLeft);
            else if (Input.GetKey("down")) OnStatusChange(Status.WalkingDown);
            else if (Input.GetKey("up")) OnStatusChange(Status.WalkingUp);
       		else OnStatusChange(Status.Idle);
		}

        public void WalkRight()
        {
            rigidbody2D.velocity = new Vector2(walkSpeed * Time.deltaTime, 0.0f);
			animator.SetTrigger ("WalkRight");
        }

        public void WalkLeft()
        {
            Debug.Log("eccomi");
            rigidbody2D.velocity = new Vector2(walkSpeed * Time.deltaTime * (-1.0f), 0.0f);
			animator.SetTrigger("WalkLeft");
        }

        public void WalkDown()
        {
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed * Time.deltaTime * (-1.0f));
			animator.SetTrigger("WalkDown");
        }

        public void WalkUp()
        { 
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed * Time.deltaTime);
			animator.SetTrigger("WalkUp");
        }

        public void Idle() { rigidbody2D.velocity = new Vector2(0.0f, 0.0f); }

        #endregion Methods
    }
}