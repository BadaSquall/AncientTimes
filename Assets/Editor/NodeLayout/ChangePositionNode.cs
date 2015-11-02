using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ChangePositionNode : BaseNode
{
    #region Constructor

    public ChangePositionNode()
    {
        Name = "Change position";
        CollapsedWindowBackup = new Vector2(500, 300);
        ActionType = typeof(ChangePosition);
    }

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var changePosition = EventAction as ChangePosition;
        var directionSelected = Convert.ToInt32(changePosition.DirectionToLook);

        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.LabelField("Object to reposition:", EditorStyles.boldLabel);
            changePosition.ObjectToReposition = EditorGUILayout.TextArea(changePosition.ObjectToReposition);

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Position X:");
                changePosition.PositionX = EditorGUILayout.FloatField(changePosition.PositionX);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Position Y:");
                changePosition.PositionY = EditorGUILayout.FloatField(changePosition.PositionY);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Direction to look after repositioning:");
            directionSelected = Convert.ToInt32(EditorGUILayout.EnumPopup("", (Direction)directionSelected));
            changePosition.DirectionToLook = (Direction)directionSelected;
        }
        EditorGUILayout.EndVertical();

        base.DrawWindow();
    }

    #endregion Methods
}