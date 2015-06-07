using UnityEngine;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.PG
{
    [RequireComponent(typeof(StatusController))]
    public class StatusListener : MonoBehaviour
    {
        #region Properties

        private StatusController controller;
        private StatusController.Status currentStatus;
        private float walkSpeed;

        #endregion Properties

        #region Methods

        void Start()
        {
            controller = GetComponent<StatusController>();
            walkSpeed = 3.0f;
        }

        void OnEnable() { StatusController.OnStatusChange += OnStateChange; }

        void OnDisable() { StatusController.OnStatusChange -= OnStateChange; }

        void Update()
        {
            OnStateCycle();
        }

        void OnStateCycle()
        {
            switch (currentStatus)
            {
                case StatusController.Status.WalkingLeft:
                    transform.Translate(new Vector3((walkSpeed * -1.0f) * Time.deltaTime, 0.0f, 0.0f));
                    break;
                case StatusController.Status.WalkingRight:
                    transform.Translate(new Vector3(walkSpeed * Time.deltaTime, 0.0f, 0.0f));
                    break;
                case StatusController.Status.WalkingDown:
                    transform.Translate(new Vector3(0.0f, (walkSpeed * -1.0f) * Time.deltaTime, 0.0f));
                    break;
                case StatusController.Status.WalkingUp:
                    transform.Translate(new Vector3(0.0f, walkSpeed * Time.deltaTime, 0.0f));
                    break;
            }
        }

        void OnStateChange(StatusController.Status newStatus)
        {
            if (AbortDependingOnCurrentState(newStatus)) return;

            switch (newStatus)
            {
                case StatusController.Status.WalkingLeft:
                    controller.WalkLeft();
                    break;
                case StatusController.Status.WalkingRight:
                    controller.WalkRight();
                    break;
                case StatusController.Status.WalkingDown:
                    controller.WalkDown();
                    break;
                case StatusController.Status.WalkingUp:
                    controller.WalkUp();
                    break;
            }

            currentStatus = newStatus;
        }

        bool AbortDependingOnCurrentState(StatusController.Status newStatus)
        {
            var hasToAbort = false;

            switch (newStatus)
            {
                case StatusController.Status.WalkingLeft:
                    if (currentStatus == StatusController.Status.WalkingLeft)
                        hasToAbort = true;
                    break;
                case StatusController.Status.WalkingRight:
                    if (currentStatus == StatusController.Status.WalkingRight)
                        hasToAbort = true;
                    break;
                case StatusController.Status.WalkingDown:
                    if (currentStatus == StatusController.Status.WalkingDown)
                        hasToAbort = true;
                    break;
                case StatusController.Status.WalkingUp:
                    if (currentStatus == StatusController.Status.WalkingUp)
                        hasToAbort = true;
                    break;
            }

            return hasToAbort;
        }

        #endregion Methods
    }
}
