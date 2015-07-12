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

        #endregion Properties

        #region Methods

        void Start() { controller = GetComponent<StatusController>(); }

        void OnEnable() { StatusController.OnStatusChange += OnStateChange; }

        void OnDisable() { StatusController.OnStatusChange -= OnStateChange; }

		void FixedUpdate() { OnStateCycle (); }

        void OnStateCycle()
        {
            switch (currentStatus)
            {
                case StatusController.Status.WalkingLeft:
                    break;
                case StatusController.Status.WalkingRight:
                    break;
                case StatusController.Status.WalkingDown:
                    break;
                case StatusController.Status.WalkingUp:
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
                case StatusController.Status.Idle:
                    controller.Idle();
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
                case StatusController.Status.Idle:
                    if (currentStatus == StatusController.Status.Idle)
                        hasToAbort = true;
                    break;
            }

            return hasToAbort;
        }

        #endregion Methods
    }
}