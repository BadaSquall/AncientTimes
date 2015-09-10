using UnityEngine;
using UnityEditor;
using System.Collections;
using AncientTimes.Assets.Scripts.Events;
using System.IO;
using System.Collections.Generic;

public class EventManagerSaveHook : UnityEditor.AssetModificationProcessor
{
	#region Methods

	private static string[] OnWillSaveAssets(string[] paths)
	{
		foreach(string path in paths)
		{
			if (path.Contains(".unity"))
			{
				Save();
				break;
			}
		}

		return paths;
	}

	private static void Save()
	{
		foreach (var obj in NodesList.Nodes) Save(obj.Key, obj.Value);
	}

	public static void Save(GameObject objToSave, List<BaseNode> nodes)
	{
		var gameEvent = objToSave.GetComponent<GameEvent>();
		if (gameEvent == null) return;
		
		var evt = gameEvent.Event;
		
		nodes.ForEach
		(
			node =>
			{
				node.EventAction.WindowX = node.Window.x;
				node.EventAction.WindowY = node.Window.y;
			}
		);
		
		if (gameEvent.EventFile == null) throw new System.Exception("The event file of the " + objToSave.name + " is not assigned! Cannot save!");
		File.WriteAllText(AssetDatabase.GetAssetPath(gameEvent.EventFile), AncientTimes.Assets.Scripts.Utilities.XMLSerializer.GetSerializedString(evt));

		AssetDatabase.Refresh();
	}

	#endregion Methods
}