using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class MoveCharacterLayoutManager : EventLayoutManagerBase
{
    #region Methods

    public MoveCharacterLayoutManager() { EventType = typeof(MoveCharacter); }

    #endregion Methods

    public override void OnGUI(ActionBase instance)
    {
        var moveCharacter = instance as MoveCharacter;

        if (moveCharacter == null) return;

        moveCharacter.Direction = (Direction)Enum.Parse(typeof(Direction), EditorGUILayout.TextField("Direction:", moveCharacter.Direction.ToString()));
        moveCharacter.ObjectToMove = EditorGUILayout.TextField("Target object name:", moveCharacter.ObjectToMove);
        moveCharacter.Speed = EditorGUILayout.FloatField("Movement speed:", moveCharacter.Speed);
        moveCharacter.Distance = EditorGUILayout.FloatField("Distance to move:", moveCharacter.Distance);
    }

    public override void FreeMemory() { }
}