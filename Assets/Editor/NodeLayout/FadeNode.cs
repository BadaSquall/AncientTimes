using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class FadeNode : BaseNode
{
    #region Properties

    #endregion Properties

    #region Constructor

    public FadeNode()
    {
        Name = "Fade";
        CollapsedWindowBackup = new Vector2(300, 130);
        ActionType = typeof(Fade);
    }

    #endregion Constructor

    #region Methods

    public override void DrawWindow()
    {
        var action = EventAction as Fade;

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("Is parallel in the middle?");
            action.ParallelInMiddle = EditorGUILayout.Popup(action.ParallelInMiddle ? 0 : 1, new[] { "true", "false" }) == 0 ? true : false;
        }
        EditorGUILayout.EndHorizontal();

        base.DrawWindow();
    }

    #endregion Methods
}