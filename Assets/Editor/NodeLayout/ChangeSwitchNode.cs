using UnityEditor;
using UnityEngine;
using System;
using AncientTimes.Assets.Scripts.Events.Actions;

public class ChangeSwitchNode : BaseNode
{
	#region Constructor

	public ChangeSwitchNode()
	{
		Name = "Change switch";
		CollapsedWindowBackup = new Vector2(300, 130);
		ActionType = typeof(ChangeSwitch);
	}

	#endregion Constructor

	#region Methods

	public override void DrawWindow()
	{
		var changeSwitch = EventAction as ChangeSwitch;

		EditorGUILayout.BeginVertical();
		{
			EditorGUILayout.LabelField("Variable name:", EditorStyles.boldLabel);
			changeSwitch.Name = EditorGUILayout.TextArea(changeSwitch.Name);

			EditorGUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField("Value:", EditorStyles.boldLabel);
				changeSwitch.Value = EditorGUILayout.Popup(changeSwitch.Value ? 0 : 1, new[] { "true", "false" }) == 0 ? true : false;
			}
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndVertical();

		base.DrawWindow();
	}

	#endregion Methods
}