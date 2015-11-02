using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class Empty : ActionBase
    {
        #region Properties

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime) { IsFinished = true; }

        public override ActionBase Clone()
        {
            var action = new Empty() { IsParallel = this.IsParallel };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}
