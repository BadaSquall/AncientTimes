using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class Console : MonoBehaviour
    {
        #region Inner Structs

        public struct MessageComposition
        {
            public string Text { get; set; }
            public string Name { get; set; }
            public GameObject Image { get; set; }
        }

        #endregion

        #region Properties

        public static GUISkin Skin;
        private float blinkMilliseconds;
        private int blinkTimes;
        private static GameObject consoleBackground;
        private static GameObject nextMessageTriangle;
        private static List<MessageComposition> compositions;
        private const int MaximumWritingSpeed = 5;
        private static string message;
        private static bool waitForInsert;
        private static string messageInserted;
        private static string variable;

        /// <summary>
        /// Occurs when [message complete].
        /// </summary>
        public static event Action MessageComplete;

        #endregion Properties

        #region Constructor

        void Awake()
        {
            compositions = new List<MessageComposition>();
 
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
            var labelPosition = new Vector2(gameObject.transform.position.x - 8.2f, gameObject.transform.position.y + 6.5f);
            labelPosition = Camera.main.WorldToScreenPoint(labelPosition);
            GUI.Label(new Rect(labelPosition.x, labelPosition.y, 50, 50), message + '\n' +  messageInserted, new GUIStyle() { fontSize = 40, normal = new GUIStyleState() { textColor = Color.black } });
		}

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="text">The message.</param>
        public static void Write(string text, string name = "", string imagePath = "")
        {
            var composition = new MessageComposition() { Text = text, Name = name };

            if (imagePath != null)
            {
                SpriteRenderer renderer;
                (renderer = (composition.Image = new GameObject()).AddComponent<SpriteRenderer>()).sprite = Resources.Load<Sprite>(imagePath);
                renderer.sortingLayerName = "Foreground";
                renderer.sortingOrder = 49;
                composition.Image.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                composition.Image.transform.localPosition = Vector3.zero;
            }

            Console.compositions.Add(composition);
            consoleBackground.SetActive(true);
        }

        public static void Write(string text, bool waitInsert, string variable, string name = "", string imagePath = "")
        {
            waitForInsert = waitInsert;
            Console.variable = variable;
            Write(text, name, imagePath);
        }

        /// <summary>
        /// Clears the message.
        /// </summary>
        private void ClearText()
        {
            message = "";
            messageInserted = "";
        }

        /// <summary>
        /// Updates the Console.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void Update()
        {
            if (compositions.Count != 0 && compositions.First().Text != message) { TypeMessage(); return; }

            if (compositions.Count == 0) return;

            if (!TriangleBlink()) return;

            if (ListenToInsert()) return;

            if (!Input.GetButtonDown("Submit")) return;

            blinkMilliseconds = 0;
            blinkTimes = 0;
            if (compositions.First().Image != null) Destroy(compositions.First().Image);
            compositions.Remove(compositions.First());

            if (compositions.Count == 0 && MessageComplete != null) MessageComplete();

            ClearText();
            if (compositions.Count == 0) consoleBackground.SetActive(false);
            nextMessageTriangle.SetActive(false);
        }

        /// <summary>
        /// Types the message.
        /// </summary>
        private void TypeMessage()
        {
            var numberOfLetters = 1;

            if (Input.GetButtonDown("Submit")) numberOfLetters = MaximumWritingSpeed;

            numberOfLetters = numberOfLetters == 1 || compositions.First().Text.Length - message.Length < MaximumWritingSpeed ? 1 : MaximumWritingSpeed;
            message = compositions.First().Text.Substring(0, message.Length + numberOfLetters);
        }

        private bool ListenToInsert()
        {
            if (!waitForInsert) return false;

            foreach (var c in Input.inputString)
            {
                if (c == "\b"[0])
                {
                    if (messageInserted.Length != 0) messageInserted = messageInserted.Substring(0, messageInserted.Length - 1);
                }

                else
                    if (c == "\n"[0] || c == "\r"[0])
                    {
                        GameVariables.UpdateVariable(variable, messageInserted);
                        waitForInsert = false;
                        return false;
                    }
                    else messageInserted += c;
            }

            return true;
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