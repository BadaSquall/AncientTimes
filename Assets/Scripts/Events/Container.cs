using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events
{
    public class Container
    {
        #region Properties

        public EventTrigger Trigger { get; set; }
        public string Condition { get; set; }
        public List<ActionBase> Actions { get; set; }

        #endregion Properties

        #region Constructor

        public Container() { Actions = new List<ActionBase>(); }

        #endregion Constructor

        #region Methods

        public Container Clone()
        {
            var container = new Container()
            {
                Trigger = this.Trigger,
                Condition = this.Condition,
            };

            this.Actions.ForEach(action => container.Actions.Add(action.Clone()));

            return container;
        }

        #endregion Methods
    }
}
