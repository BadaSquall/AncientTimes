using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Events.Actions.Helpers;

public class ShowDialogueNode : BaseNode
{
	#region Properties

	private Vector2 scrollPosition;
	private List<bool> dialogueFoldouts;
	
	#endregion Properties

	#region Constructor

	public ShowDialogueNode()
	{
		Name = "Show Dialogue";
		CollapsedWindowBackup = new Vector2(500, 130);
		ActionType = typeof(ShowDialogue);
		scrollPosition = new Vector2();
		dialogueFoldouts = new List<bool>();
	}

	#endregion Constructor

	#region Methods

	public override void DrawWindow()
	{
		var dialogue = EventAction as ShowDialogue;

		if (dialogueFoldouts.Count < dialogue.Dialogues.Count) FoldoutCountBalancer(dialogue);

		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
		{
			var index = -1;

			for (var dialogueIndex = 0; dialogueIndex < dialogue.Dialogues.Count; dialogueIndex++)
			{
				var dial = dialogue.Dialogues[dialogueIndex];
				EditorGUILayout.BeginVertical();
				{
					dialogueFoldouts[dialogueIndex] = EditorGUILayout.Foldout(dialogueFoldouts[dialogueIndex], "Dialogue n° " + (dialogueIndex + 1));

					if (dialogueFoldouts[dialogueIndex])
					{
						EditorGUILayout.LabelField("Image Path: Assets/Sprites/Resources/", EditorStyles.miniBoldLabel);
						dial.ImagePath = EditorGUILayout.TextArea(dial.ImagePath, EditorStyles.textArea);
						EditorGUILayout.BeginHorizontal();
						EditorGUILayout.LabelField("Text:", EditorStyles.miniBoldLabel);
						GUILayout.Space(-300);
						dial.Text = EditorGUILayout.TextArea(dial.Text, EditorStyles.textArea);
						EditorGUILayout.EndHorizontal();
						if (GUILayout.Button("Remove Dialogue")) index = dialogueIndex;
					}
				}
				EditorGUILayout.EndVertical();
			}

			if (index != -1)
			{
				dialogue.Dialogues.RemoveAt(index);
				dialogueFoldouts.RemoveAt(index);
			}
			
			if (GUILayout.Button("Add Dialogue")) dialogue.Dialogues.Add(new AncientTimes.Assets.Scripts.Events.Actions.Helpers.Dialogue());
		}
		EditorGUILayout.EndScrollView();

		base.DrawWindow();
	}

	private void FoldoutCountBalancer(ShowDialogue dialogue) { while (dialogueFoldouts.Count < dialogue.Dialogues.Count) dialogueFoldouts.Add(false); }

	#endregion Methods
}