using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.GameSystem
{
	public class Console : GameSystemObject
	{
		#region Inner Structs
		
		private struct MessageComposition
		{
			public string Text { get; set; }
			public GameObject Image { get; set; }
		}
		
		#endregion Inner Structs
		
		#region Properties

		private static Console instance;

		public static Console Instance
		{
			get
			{
				instance = instance ?? new Console();
				return instance;
			}
		}

		public static GUISkin Skin;
		private static float blinkMilliseconds;
		private static int blinkTimes;
		public static Texture2D Background { get; set; }
		public static Texture2D NextMessageTriangle { get; set; }
		private static List<MessageComposition> compositions = new List<MessageComposition>();
		private const int MaximumWritingSpeed = 5;
		private static string message;
		private static bool waitForInsert;
		private static string messageInserted;
		private static string variable;
		private static bool isWriting;
		private static bool isMessageWrote;
		
		/// <summary>
		/// Occurs when [message started].
		/// </summary>
		public static event Action MessageStarted;
		
		/// <summary>
		/// Occurs when [message complete].
		/// </summary>
		public static event Action MessageComplete;
		
		#endregion Properties
		
		#region Constructor
		
		private Console() { ClearText(); }
		
		#endregion Constructor
		
		#region Methods

        /// <summary>
        /// Used to draw GUI elements on the screen.
        /// </summary>
		public static void OnGUI()
		{
            if (!isWriting) return;

			GUISizer.BeginGUI();

			GUI.skin = Skin;
			
			var labelPosition = new Vector2(100, GUISizer.HEIGHT - 200);

			if (Background != null)
			{
				var height = GUISizer.WIDTH / Background.width * Background.height;
				GUI.DrawTexture(new Rect(50, GUISizer.HEIGHT - height - 25, GUISizer.WIDTH - 100, height), Background);
			}

			if (isMessageWrote && NextMessageTriangle)
			{
				GUI.DrawTexture(new Rect(GUISizer.WIDTH - 150, GUISizer.HEIGHT - 80, 30, 30), NextMessageTriangle);
			}

			GUI.Label(new Rect(labelPosition.x, labelPosition.y, 50, 50), message + '\n' +  messageInserted, new GUIStyle() { fontSize = 40, normal = new GUIStyleState() { textColor = Color.black } });

			GUISizer.EndGUI();
		}
		
		/// <summary>
		/// Writes the specified message.
		/// </summary>
		/// <param name="text">The message.</param>
		public static void Write(string text, string imagePath = "")
        {
			var composition = new MessageComposition() { Text = text };
			
			if (imagePath != null && imagePath != "")
			{
				SpriteRenderer renderer;
				(renderer = (composition.Image = new GameObject()).AddComponent<SpriteRenderer>()).sprite = Resources.Load<Sprite>(imagePath);
				renderer.sortingLayerName = "Foreground";
				renderer.sortingOrder = 49;
				composition.Image.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
				composition.Image.transform.localPosition = Vector3.zero;
			}
			
			Console.compositions.Add(composition);
			isWriting = true;
			
			if (MessageStarted != null) MessageStarted();
		}

		/// <summary>
		/// Writes the specified message and wait for the user to insert a text.
		/// </summary>
		/// <param name="text">The message.</param>
		public static void Write(string text, bool waitInsert, string variable, string imagePath = "")
		{
			waitForInsert = waitInsert;
			
			if (waitForInsert) messageInserted = "_";
			
			Console.variable = variable;
			Write(text, imagePath);
		}
		
		/// <summary>
		/// Clears the message.
		/// </summary>
		private static void ClearText()
		{
			message = "";
			messageInserted = "";
		}
		
		/// <summary>
		/// Updates the Console.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		public static void Update()
		{
			if (compositions.Count != 0 && compositions.First().Text != message) { TypeMessage(); return; }
			
			if (compositions.Count == 0) return;
			
			if (!TriangleBlink()) return;
			
			if (ListenToInsert()) return;

			if (!Input.GetButtonDown("Submit")) return;
			
			blinkMilliseconds = 0;
			blinkTimes = 0;
			if (compositions.First().Image != null) Instance.RaiseDestroy(compositions.First().Image);
			compositions.Remove(compositions.First());
			
			if (compositions.Count == 0 && MessageComplete != null) MessageComplete();
			
			ClearText();
			if (compositions.Count == 0) isWriting = false;
			isMessageWrote = false;
		}
		
		/// <summary>
		/// Types the message.
		/// </summary>
		private static void TypeMessage()
		{
			var numberOfLetters = 1;

#if UNITY_EDITOR
			if (Input.GetButton("Submit"))
#else
			if (Input.touchCount > 0)
#endif
				numberOfLetters = MaximumWritingSpeed;
			
			numberOfLetters = numberOfLetters == 1 || compositions.First().Text.Length - message.Length < MaximumWritingSpeed ? 1 : MaximumWritingSpeed;
			message = compositions.First().Text.Substring(0, message.Length + numberOfLetters);
		}

        /// <summary>
        /// Keeps listening the input from the keyboard and writes in the console whatever is inserted.
        /// </summary>
        /// <returns>Returns true when return key is pressed.</returns>
		private static bool ListenToInsert()
		{
			if (!waitForInsert) return false;
			
			foreach (var c in Input.inputString)
			{
				if (c == "\b"[0])
				{
					if (messageInserted.Length != 0) messageInserted = messageInserted.Substring(0, messageInserted.Length - 2) + "_";
				}
				else if ((c == "\n"[0] || c == "\r"[0]))
				{
					if (messageInserted == "_") return false;
					GameVariables.Update(variable, messageInserted.Substring(0, messageInserted.Length - 1));
					waitForInsert = false;
					return false;
				}
				else messageInserted = messageInserted.Substring(0, messageInserted.Length - 1) + c + "_";
			}
			
			return true;
		}
		
		/// <summary>
		/// Makes the triangle blinking.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <returns></returns>
		private static bool TriangleBlink()
		{
			blinkMilliseconds += Time.deltaTime * 1000;
			
			if (blinkMilliseconds < 300.0f) return blinkTimes >= 1;
			blinkMilliseconds = 0;
			++blinkTimes;
			isMessageWrote = !isMessageWrote;
			
			return false;
		}
		
		#endregion Methods
	}
}