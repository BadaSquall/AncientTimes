using System;
using System.Collections.Generic;
using UnityEngine;

public static class NodesList
{
	#region Properties

	public static Dictionary<GameObject, List<BaseNode>> Nodes { get; set; }

	#endregion Properties

	#region Constructor

	static NodesList() { Nodes = new Dictionary<GameObject, List<BaseNode>>(); }

	#endregion Constructor
}