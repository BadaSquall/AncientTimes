using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ShowDialogueLayoutManager : EventLayoutManagerBase
{
    #region Properties

    private Dictionary<ShowDialogue, bool> ShowDialogueVisibles;

    #endregion Properties

    #region Constructors

    public ShowDialogueLayoutManager()
    {
        EventType = typeof(ShowDialogue);
        ShowDialogueVisibles = new Dictionary<ShowDialogue, bool>();
    }

    #endregion Constructors

    #region Methods

    public override void OnGUI(ActionBase instance)
    {
        var showDialogue = instance as ShowDialogue;
        if (showDialogue == null) return;
        if (!ShowDialogueVisibles.ContainsKey(showDialogue)) ShowDialogueVisibles.Add(showDialogue, true);

        for (var dialogueIndex = 0; dialogueIndex < showDialogue.Dialogues.Count; dialogueIndex++)
        {
            var dialogue = showDialogue.Dialogues[dialogueIndex];
            ShowDialogueVisibles[showDialogue] = EditorGUILayout.Foldout(ShowDialogueVisibles[showDialogue], "    Dialogue n° " + dialogueIndex + ":", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name:");
            dialogue.Name = GUILayout.TextArea(dialogue.Name);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Image Path: Assets/Sprites/Resources/");
            dialogue.ImagePath = GUILayout.TextArea(dialogue.ImagePath);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Text:");
            dialogue.Text = GUILayout.TextArea(dialogue.Text);
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Dialogue")) showDialogue.Dialogues.Add(new AncientTimes.Assets.Scripts.Events.Actions.Helpers.Dialogue());
    }

    public override void FreeMemory() { }

    #endregion Methods
}