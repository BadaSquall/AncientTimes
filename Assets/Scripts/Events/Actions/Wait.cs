using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class Wait : ActionBase
    {
        #region Properties

        public float TimeToWait;
        private float timeElapsed;

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            timeElapsed += deltaTime;

            if (timeElapsed >= TimeToWait) IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new Wait()
            {
                IsParallel = this.IsParallel,
                TimeToWait = this.TimeToWait
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }


        #endregion Methods
    }
}
