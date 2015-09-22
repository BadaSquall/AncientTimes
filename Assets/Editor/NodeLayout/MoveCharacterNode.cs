using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;

public class MoveCharacterNode : BaseNode
{ 
    #region Constructor

    public MoveCharacterNode()
    {
        Name = "Move Character";
        CollapsedWindowBackup = new Vector2(300, 230);
        ActionType = typeof(MoveCharacter);
    }

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var moveCharacter = EventAction as MoveCharacter;
        var directionSelected = Convert.ToInt32(moveCharacter.Direction);

        EditorGUILayout.BeginVertical();
        {
            directionSelected = Convert.ToInt32(EditorGUILayout.EnumPopup("Direction:", (Direction)directionSelected ));
            moveCharacter.Direction = (Direction)directionSelected;

            EditorGUILayout.LabelField("Object Name to move:", EditorStyles.boldLabel);
            moveCharacter.ObjectToMove = EditorGUILayout.TextArea(moveCharacter.ObjectToMove);

            EditorGUILayout.LabelField("Distance:", EditorStyles.boldLabel);
            moveCharacter.Distance = EditorGUILayout.FloatField(moveCharacter.Distance);

            EditorGUILayout.LabelField("Speed:", EditorStyles.boldLabel);
            moveCharacter.Speed = EditorGUILayout.FloatField(moveCharacter.Speed);

        }
        EditorGUILayout.EndVertical();

        base.DrawWindow();
    }

    #endregion Methods
}