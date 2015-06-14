using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.CuctomWindows
{
    public class EventManagerWindow : EditorWindow
    {
        string myString = "Hello World";
        bool groupEnabled;
        bool myBool = true;
        float myFloat = 1.23f;

        [MenuItem("Window/Event Manager")]
        public static void ShowWindow() { EditorWindow.GetWindow(typeof(EventManagerWindow)); }

        void OnGUI()
        {
            GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextField("Text Field", myString);

            groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup();
        }
    }
}
