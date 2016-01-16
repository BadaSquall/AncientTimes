using System;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Utilities
{
    /// <summary>
    /// Utilities for the game variables management.
    /// </summary>
    public static class GameVariables
    {
        #region Properties
        /// <summary>
        /// The collection of dynamic variables.
        /// </summary>
        public static Dictionary<string, string> Collection { get; private set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes the <see cref="GameVariables"/> class.
        /// </summary>
        static GameVariables() { Collection = new Dictionary<string, string>(); }

        #endregion Constructor

        #region Methods

        [ObsoleteAttribute("use Update method instead")]
        public static void UpdateVariable(string variableName, string value)
        {
            if (Collection.ContainsKey(variableName)) Collection[variableName] = value;
            else Collection.Add(variableName, value);
        }

        [ObsoleteAttribute("use Update method instead")]
        public static void UpdateSwitch(string switchName, bool value)
        {
            if (Collection.ContainsKey(switchName)) Collection[switchName] = value.ToString();
            else Collection.Add(switchName, value.ToString());
        }

        /// <summary>
        /// Updates the variable if exists, create it otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable to update/create.</param>
        /// <param name="value">The value we want to give to the variable.</param>
        public static void Update(string variableName, string value)
        {
            if (Collection.ContainsKey(variableName)) Collection[variableName] = value;
            else Collection.Add(variableName, value);
        }

        /// <summary>
        /// Updates the variable if exists, create it otherwise.
        /// </summary>
        /// <param name="variableName">Name of the variable to update/create.</param>
        /// <param name="value">The value we want to give to the variable. (The value will be saved calling ToString() method)</param>
        public static void Update(string variableName, object value)
        {
            if (Collection.ContainsKey(variableName)) Collection[variableName] = value.ToString();
            else Collection.Add(variableName, value.ToString());
        }

        [ObsoleteAttribute("use Get method instead")]
        public static string GetVariable(string variableName)
        {
            if (Collection.ContainsKey(variableName)) return Collection[variableName];
            else return "";
        }

        [ObsoleteAttribute("use Get method instead")]
        public static bool GetSwitch(string switchName)
        {
            if (Collection.ContainsKey(switchName)) return bool.Parse(Collection[switchName]);
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
            if (Collection.ContainsKey(variableName)) return Collection[variableName];
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
        public static string Get(string variableName, object defaultValue)
        {
            if (Collection.ContainsKey(variableName)) return Collection[variableName];
            else return defaultValue.ToString();
        }

        /// <summary>
        /// Deletes the specified variable if exists.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        public static void Delete(string variableName) { if (Collection.ContainsKey(variableName)) Collection.Remove(variableName); }

        #endregion Methods
    }
}