using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events
{
    public class SerializableGameEvent
    {
        #region Properties

        public List<Container> Containers { get; set; }

        #endregion Properties

        #region Constructor

        public SerializableGameEvent() { Containers = new List<Container>(); }

        #endregion Constructor
    }
}
