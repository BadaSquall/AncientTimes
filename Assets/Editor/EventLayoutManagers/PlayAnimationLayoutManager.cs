using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

public class PlayAnimationLayoutManager : EventLayoutManagerBase
{
    public PlayAnimationLayoutManager() { EventType = typeof(PlayAnimation); }

    public override void OnGUI(ActionBase instance)
    {
        var playAnimation = instance as PlayAnimation;

        if (playAnimation == null) return;

        playAnimation.Trigger = EditorGUILayout.TextField("Trigger:", playAnimation.Trigger);
        playAnimation.ObjectToAnimate = EditorGUILayout.TextField("Object to animate:", playAnimation.ObjectToAnimate);
    }

    public override void FreeMemory() { }
}