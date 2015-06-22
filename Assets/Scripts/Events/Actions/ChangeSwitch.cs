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

        public override bool Execute(float deltaTime)
        {
            if (GameVariables.Switches.ContainsKey(Name)) GameVariables.Switches[Name] = Value;
            else GameVariables.Switches.Add(Name, Value);

            return true;
        }

        #endregion Methods
    }
}
