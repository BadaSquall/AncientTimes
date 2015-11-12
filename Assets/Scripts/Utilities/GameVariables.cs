using System;
using System.Collections.Generic;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Utilities
{
    public static class GameVariables
    {
        #region Properties

        /// <summary>
        /// The collection of dynamic variables
        /// </summary>
        private static Dictionary<string, object> collection;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes the <see cref="GameVariables"/> class.
        /// </summary>
        static GameVariables() { collection = new Dictionary<string, object>(); }

        #endregion Constructor

        #region Methods

        [ObsoleteAttribute("use Update method instead")]
        public static void UpdateVariable(string variableName, string value)
        {
            if (collection.ContainsKey(variableName)) collection[variableName] = value;
            else collection.Add(variableName, value);
        }

        [ObsoleteAttribute("use Update method instead")]
        public static void UpdateSwitch(string switchName, bool value)
        {
            if (collection.ContainsKey(switchName)) collection[switchName] = value.ToString();
            else collection.Add(switchName, value.ToString());
        }

        /// <summary>
        /// Updates the variable if exists, create it otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable to update/create.</param>
        /// <param name="value">The value we want to give to the variable.</param>
        public static void Update(string variableName, string value)
        {
            if (collection.ContainsKey(variableName)) collection[variableName] = value;
            else collection.Add(variableName, value);
        }

        /// <summary>
        /// Updates the variable if exists, create it otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable to update/create.</param>
        /// <param name="value">The value we want to give to the variable. (The value will be saved as it is)</param>
        public static void Update(string variableName, object value)
        {
            if (collection.ContainsKey(variableName)) collection[variableName] = value;
            else collection.Add(variableName, value);
        }

        [ObsoleteAttribute("use Get method instead")]
        public static string GetVariable(string variableName)
        {
            if (collection.ContainsKey(variableName)) return (string) collection[variableName];
            else return "";
        }

        [ObsoleteAttribute("use Get method instead")]
        public static bool GetSwitch(string switchName)
        {
            if (collection.ContainsKey(switchName)) return bool.Parse((string) collection[switchName]);
            else return false;
        }

        /// <summary>
        /// Gets the variable if exists, defaultValue otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable we want to get.</param>
        /// <param name="defaultValue">The value to return if the variable has been not initialized.</param>
        /// <returns>
        /// The variable.
        /// </returns>
        public static string Get(string variableName, string defaultValue)
        {
            if (collection.ContainsKey(variableName)) return (string) collection[variableName];
            else return defaultValue;
        }

        /// <summary>
        /// Gets the variable if exists, "" otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable we want to get.</param>
        /// <param name="defaultValue">The value to return if the variable has been not initialized. (The value will be returned calling ToString() method)</param>
        /// <returns>
        /// The variable.
        /// </returns>
        public static object Get(string variableName, object defaultValue)
        {
            if (collection.ContainsKey(variableName)) return collection[variableName];
            else return defaultValue;
        }

        /// <summary>
        /// Deletes the specified variable if exists.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        public static void Delete(string variableName) { if (collection.ContainsKey(variableName)) collection.Remove(variableName); }

        #endregion Methods
    }
}
