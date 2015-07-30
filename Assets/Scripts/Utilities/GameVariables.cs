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
            Switches.Add("IsFirstEncounter", true);
            Switches.Add("IsPaused", false);
            Switches.Add("IsMan", false);
            Switches.Add("IsChosen", false);
            Variables = new Dictionary<string, string>();
            Variables.Add("Name", "PG");
            Variables.Add("CurrentMap", "Altaquercia");
        }

        #endregion Constructor
    }
}
