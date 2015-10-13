using AncientTimes.Assets.Scripts.Events.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EmptyNode : BaseNode
{
    #region Constructor

    public EmptyNode()
	{
		Name = "Empty";
		CollapsedWindowBackup = new Vector2(300, 130);
		ActionType = typeof(Empty);
	}

	#endregion Constructor

	#region Methods

	public override void DrawWindow() { base.DrawWindow(); }

    #endregion Methods
}