using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events
{
    public class GameEvent
    {
        #region Properties

        public List<Container> Containers { get; set; }

        #endregion Properties

        #region Constructor

        public GameEvent() { Containers = new List<Container>(); }

        #endregion Constructor
    }
}
