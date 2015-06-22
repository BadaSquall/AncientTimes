using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ChangeSwitchLayoutManager : EventLayoutManagerBase
{
    #region Constructors

    public ChangeSwitchLayoutManager() { EventType = typeof(ChangeSwitch); }

    #endregion Constructors

    #region Methods

    public override void OnGUI(ActionBase instance)
    {
        var changeSwitch = instance as ChangeSwitch;
        if (changeSwitch == null) return;

        changeSwitch.Name = EditorGUILayout.TextField("   Name:", changeSwitch.Name);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("   Value:");
        var value = 0;
        value = EditorGUILayout.Popup(changeSwitch.Value ? 0 : 1, new[] { "true", "false" });
        if (value == 0) changeSwitch.Value = true;
        else changeSwitch.Value = false;
        EditorGUILayout.EndHorizontal();
    }

    public override void FreeMemory() { }

    #endregion Methods
}