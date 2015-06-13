using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events
{
    public class Container
    {
        #region Properties

        public string Condition { get; set; }
        public List<ActionBase> Actions { get; set; }

        #endregion Properties

        #region Constructor

        public Container() { Actions = new List<ActionBase>(); }

        #endregion Constructor
    }
}
