using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class PlayCharacterAnimationNode : BaseNode
{
    #region Constructor

    public PlayCharacterAnimationNode()
    {
        Name = "Play Character Animation";
        CollapsedWindowBackup = new Vector2(300, 160);
        ActionType = typeof(PlayCharacterAnimation);
    }

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var playCharacterAnimation = EventAction as PlayCharacterAnimation;
        var animationIndex = (int)playCharacterAnimation.Animation;

        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.LabelField("Animation:", EditorStyles.boldLabel);
            animationIndex = Convert.ToInt32(EditorGUILayout.EnumPopup("", (CharacterAnimation)animationIndex));
            playCharacterAnimation.Animation = (CharacterAnimation)animationIndex;
            EditorGUILayout.LabelField("Character to animate:", EditorStyles.boldLabel);
            playCharacterAnimation.CharacterToAnimate = EditorGUILayout.TextArea(playCharacterAnimation.CharacterToAnimate);
        }
        EditorGUILayout.EndVertical();
        base.DrawWindow();
    }

    #endregion Methods
}