using UnityEngine;
using UnityEditor;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System;

public class LookAtDirectionNode : BaseNode
{
    #region Constructor

    public LookAtDirectionNode()
	{
		Name = "Look at direction";
		CollapsedWindowBackup = new Vector2(300, 130);
		ActionType = typeof(LookAtDirection);
	}

	#endregion Constructor

	#region Methods

	public override void DrawWindow()
	{
		var lookAtDirection = EventAction as LookAtDirection;
        var directionSelected = Convert.ToInt32(lookAtDirection.Direction);

		EditorGUILayout.BeginVertical();
		{
			EditorGUILayout.LabelField("Object to make looking at:", EditorStyles.boldLabel);
			lookAtDirection.ObjectToMakeLooking = EditorGUILayout.TextArea(lookAtDirection.ObjectToMakeLooking);

			EditorGUILayout.BeginHorizontal();
			{
                directionSelected = Convert.ToInt32(EditorGUILayout.EnumPopup("Direction:", (Direction)directionSelected));
                lookAtDirection.Direction = (Direction)directionSelected;
			}
			EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Time to wait:");
                lookAtDirection.TimeToWait = EditorGUILayout.FloatField(lookAtDirection.TimeToWait);
            }
            EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndVertical();

		base.DrawWindow();
	}

	#endregion Methods
}