using System;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public struct GameVariables
    {
        #region Properties

        public static Dictionary<string, bool> Switches;
        public static Dictionary<string, string> Variables;

        #endregion Properties

        #region Constructor

        static GameVariables()
        {
            Switches = new Dictionary<string, bool>();
            Switches.Add("IsPaused", false);
            Variables = new Dictionary<string, string>();
        }

        #endregion Constructor
    }
}
