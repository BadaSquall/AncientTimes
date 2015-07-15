using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class MoveCharacter : ActionBase
    {
        #region Properties

        public Direction Direction { get; set; }
        public string ObjectToMove { get; set; }
        public float Distance = 5.0f;
        public float Speed = 5.0f;
        private GameObject objectToMoveInstance;
        private bool isMoving;
        private Vector2 startingPosition;

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        public override bool Execute(float deltaTime)
        {
            var hasFinished = false;

            if (!isMoving)
            {
                objectToMoveInstance = GameObject.Find(ObjectToMove);
                if (!objectToMoveInstance) return true;
                isMoving = true;
                var animator = objectToMoveInstance.GetComponent<Animator>();
                if (animator) animator.SetTrigger("Walk" + Direction.ToString());
                startingPosition = objectToMoveInstance.transform.position;

                SetSpeed();
            }

            hasFinished = CheckRemainingDistance();

            if (hasFinished)
            {
                objectToMoveInstance.rigidbody2D.velocity = Vector2.zero;
                var animator = objectToMoveInstance.GetComponent<Animator>();
                if (animator) animator.SetTrigger("Idle");
            }

            return hasFinished;
        }

        public override ActionBase Clone()
        {
            var action = new MoveCharacter()
            {
                Direction = this.Direction,
                ObjectToMove = this.ObjectToMove,
                Distance = this.Distance,
                Speed = this.Speed
            };

            return action;
        }

        private void SetSpeed()
        {
            switch (Direction)
            {
                case Direction.Right:
                    objectToMoveInstance.rigidbody2D.velocity = new Vector2(Speed, 0.0f);
                    break;
                case Direction.Left:
                    objectToMoveInstance.rigidbody2D.velocity = new Vector2(Speed * (-1.0f), 0.0f);
                    break;
                case Direction.Up:
                    objectToMoveInstance.rigidbody2D.velocity = new Vector2(0.0f, Speed);
                    break;
                case Direction.Down:
                    objectToMoveInstance.rigidbody2D.velocity = new Vector2(0.0f, Speed * (-1.0f));
                    break;
            }
        }

        private bool CheckRemainingDistance()
        {
            var hasFinished = false;

            switch (Direction)
            {
                case Direction.Right:
                    if (objectToMoveInstance.transform.position.x - startingPosition.x >= Distance) hasFinished = true;
                    break;
                case Direction.Left:
                    if (objectToMoveInstance.transform.position.x + Distance <= startingPosition.x) hasFinished = true;
                    break;
                case Direction.Up:
                    if (objectToMoveInstance.transform.position.y - Distance >= startingPosition.y) hasFinished = true;
                    break;
                case Direction.Down:
                    if (objectToMoveInstance.transform.position.y + Distance <= startingPosition.y) hasFinished = true;
                    break;
            }

            return hasFinished;
        }

        #endregion Methods
    }
}