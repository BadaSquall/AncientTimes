﻿using System;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public struct GameVariables
    {
        #region Properties

        private static Dictionary<string, bool> switches;
        private static Dictionary<string, string> variables;

        #endregion Properties

        #region Constructor

        static GameVariables()
        {
            switches = new Dictionary<string, bool>();
            switches.Add("IsFirstEncounter", true);
            variables = new Dictionary<string, string>();
        }

        #endregion Constructor

        #region Methods

        public static void UpdateSwitch(string switchName, bool value)
        {
            if (!switches.ContainsKey(switchName)) switches.Add(switchName, value);
            else switches[switchName] = value;
        }

        public static bool GetSwitch(string switchName)
        {
            if (!switches.ContainsKey(switchName)) return false;
            else return switches[switchName];
        }

        public static void UpdateVariable(string variableName, string value)
        {
            if (!variables.ContainsKey(variableName)) variables.Add(variableName, value);
            else variables[variableName] = value;
        }

        public static string GetVariable(string variableName)
        {
            if (!variables.ContainsKey(variableName)) return "";
            else return variables[variableName];
        }

        #endregion Methods
    }
}
