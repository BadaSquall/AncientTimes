using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class LookAtDirection : ActionBase
    {
        #region Properties

        public string ObjectToMakeLooking;
        public Direction Direction;
        public float TimeToWait;

        private float timeElapsed;

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            if (timeElapsed == 0) GameObject.Find(ObjectToMakeLooking).GetComponent<Animator>().SetTrigger("Idle" + Direction.ToString());

            timeElapsed += deltaTime;
            if (timeElapsed >= TimeToWait) IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new LookAtDirection()
            {
                IsParallel = this.IsParallel,
                ObjectToMakeLooking = this.ObjectToMakeLooking,
                Direction = this.Direction,
                TimeToWait = this.TimeToWait
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}