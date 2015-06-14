﻿using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;

namespace AncientTimes.Assets.Scripts.System
{
    public class Console : MonoBehaviour
    {
        #region Properties

        public GUISkin Skin;
        private float blinkMilliseconds;
        private int blinkTimes;
        private GameObject consoleBackground;
        private GameObject nextMessageTriangle;
        private List<string> text;
        private const int MaximumWritingSpeed = 5;
        private static event Action messageComplete;
        private string message;

        /// <summary>
        /// Occurs when [message complete].
        /// </summary>
        public event Action MessageComplete
        {
            add { messageComplete = messageComplete == null ? new Action(value) : value; }
            remove { if (string.IsNullOrEmpty(message)) return; messageComplete = value; }
        }

        #endregion Properties

        #region Constructor

        void Start()
        {
            text = new List<string>();
            ClearText();

            foreach (Transform child in transform)
            {
                switch (child.name)
                {
                    case "Background":
                        consoleBackground = child.gameObject;
                        break;
                    case "NextMessageTriangle":
                        nextMessageTriangle = child.gameObject;
                        break;
                }
            }
        }

        #endregion Constructor

        #region Methods
	


        void OnGUI()
        {
            if (!consoleBackground.activeInHierarchy) return;
           	 GUI.skin = Skin;
            var labelPosition = Camera.main.WorldToScreenPoint(new Vector2(consoleBackground.transform.position.x + 0.2f,
                consoleBackground.transform.position.y - 0.05f));
            GUI.Label(new Rect(labelPosition.x, Screen.height - labelPosition.y, 50, 50), message, new GUIStyle() { fontSize = 40, normal = new GUIStyleState() { textColor = Color.black } });
		}

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="text">The message.</param>
        public void Write(string text)
        {
            this.text.Add(text);
            consoleBackground.SetActive(true);
        }

        /// <summary>
        /// Clears the message.
        /// </summary>
        private void ClearText() { message = ""; }

        /// <summary>
        /// Updates the Console.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void Update()
        {
            	if (text.Count != 0 && text.First() != message) { TypeMessage(); return; }

            	if (text.Count == 0) return;

            	if (!TriangleBlink()) return;
            
            	if (!Input.GetKeyDown(KeyCode.Return)) return;

            	blinkMilliseconds = 0;
            	blinkTimes = 0;
            	text.Remove(text.First());

            	if (text.Count == 0 && messageComplete != null) messageComplete();

            	ClearText();
            	if (text.Count == 0) consoleBackground.SetActive(false);
            	nextMessageTriangle.SetActive(false);
        }

        /// <summary>
        /// Types the message.
        /// </summary>
        private void TypeMessage()
        {
            var numberOfLetters = 1;

            if (Input.GetKeyDown(KeyCode.Return)) numberOfLetters = MaximumWritingSpeed;

            numberOfLetters = numberOfLetters == 1 || text.First().Length - message.Length < MaximumWritingSpeed ? 1 : MaximumWritingSpeed;
            Debug.Log(message);
            message = text.First().Substring(0, message.Length + numberOfLetters);
        }

        /// <summary>
        /// Makes the triangle blinking.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns></returns>
        private bool TriangleBlink()
        {
            blinkMilliseconds += Time.deltaTime * 1000;
            
            if (blinkMilliseconds < 300.0f) return blinkTimes >= 1;
            blinkMilliseconds = 0;
            ++blinkTimes;
            nextMessageTriangle.SetActive(!nextMessageTriangle.activeInHierarchy);
            
            return false;
        }

        #endregion Methods
    }
}