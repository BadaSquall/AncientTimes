using UnityEngine;
using System.Collections.Generic;
using System;
using AncientTimes.Assets.Scripts.Events.Actions;

public abstract class EventLayoutManagerBase
{
    #region Properties

    public Type EventType { get; protected set; }

    #endregion Properties

    #region Methods

    public abstract void OnGUI(ActionBase instance);
    public abstract void FreeMemory();

    #endregion Methods
}