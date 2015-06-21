using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientTimes.Assets.Scripts.Events.Actions.Helpers
{
    public class Dialogue
    {
        #region Properties

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }

        #endregion Properties

        #region Constructors

        public Dialogue()
        {
            Name = "";
            ImagePath = "";
            Text = "";
        }

        #endregion Constructors
    }
}
