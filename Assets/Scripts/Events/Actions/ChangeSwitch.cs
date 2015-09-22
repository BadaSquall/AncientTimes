using AncientTimes.Assets.Scripts.Utilities;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class ChangeSwitch : ActionBase
    {
        #region Properties

        public string Name { get; set; }
        public bool Value { get; set; }

        #endregion Propeties

        #region Methods

        public override void Execute(float deltaTime)
        {
            GameVariables.Update(Name, Value);
            IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new ChangeSwitch()
            {
                IsParallel = this.IsParallel,
                Name = this.Name,
                Value = this.Value
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}