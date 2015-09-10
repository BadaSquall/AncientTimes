using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using AncientTimes.Assets.Scripts.Events.Actions;

public class PlayAnimationNode : BaseNode
{
    #region Constructor

    public PlayAnimationNode()
    {
        Name = "Play Animation";
        CollapsedWindowBackup = new Vector2(300, 130);
        ActionType = typeof(PlayAnimation);
    }

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var playAnimation = EventAction as PlayAnimation;

        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.LabelField("Trigger:", EditorStyles.boldLabel);
            playAnimation.Trigger = EditorGUILayout.TextArea(playAnimation.Trigger);
            EditorGUILayout.LabelField("Object to animate:", EditorStyles.boldLabel);
            playAnimation.ObjectToAnimate = EditorGUILayout.TextArea(playAnimation.ObjectToAnimate);
        }
        EditorGUILayout.EndVertical();
        base.DrawWindow();
    }

    #endregion Methods
}
