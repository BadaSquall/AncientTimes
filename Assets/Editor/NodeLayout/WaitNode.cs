using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using AncientTimes.Assets.Scripts.Events.Actions;

public class WaitNode : BaseNode
{
    #region Constructor

    public WaitNode()
	{
		Name = "Wait";
		CollapsedWindowBackup = new Vector2(300, 130);
		ActionType = typeof(Wait);
	}

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var lookAtDirection = EventAction as Wait;

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("Seconds to wait:", EditorStyles.boldLabel);
            lookAtDirection.TimeToWait = EditorGUILayout.FloatField(lookAtDirection.TimeToWait);
        }
        EditorGUILayout.EndHorizontal();

        base.DrawWindow();
    }

    #endregion Methods
}