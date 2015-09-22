using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using System.IO;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Utilities;

[InitializeOnLoad]
public class EventManagerWindow : EditorWindow
{
	#region Properties

	private List<Type> nodeTypes;

	private int actionTypeIndex;
	private bool exitFromPlay;
	
	private GameObject previousGameObject;
	private bool isPlaying;
	private bool isInTransition;
	private int nodeClicked;

	private Vector2 scrollPosition;

	private Vector2 mousePosition;

	private bool isActiveObject;

	#endregion Properties
	
	#region Constructors
	
	public EventManagerWindow()
	{
		nodeTypes = Assembly.GetAssembly(typeof(BaseNode)).GetTypes()
			.Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseNode))).ToList();
		scrollPosition = Vector2.zero;
	}
	
	#endregion Constructors
	
	#region Methods
	
	[MenuItem("Window/Event Manager")]
	public static void ShowWindow() { EditorWindow.GetWindow(typeof(EventManagerWindow)); }
	
	private void OnEnable() { title = "Event Manager"; }

	private void ConditionWindow(int id)
	{
		if (previousGameObject == null) return;
		var gameEvent = previousGameObject.GetComponent<GameEvent>();
		if (gameEvent == null) return;
		gameEvent.Event.Condition = EditorGUILayout.TextArea(previousGameObject.GetComponent<GameEvent>().Event.Condition, EditorStyles.textArea);
	}

	private void DrawWindow(int id)
	{
		var window = NodesList.Nodes[previousGameObject][id];
		EditorGUILayout.BeginHorizontal();
		window.IsNotCollapsed = EditorGUILayout.Foldout(window.IsNotCollapsed, "");

		if (window.IsNotCollapsed)
        {
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Label: ");
                window.EventAction.Label = EditorGUILayout.TextArea(window.EventAction.Label);
            }
            EditorGUILayout.EndHorizontal();

            if (window.ActionType != typeof(IfElse))
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField("Is parallel: ");
                    window.EventAction.IsParallel = EditorGUILayout.Toggle(window.EventAction.IsParallel);
                }
                EditorGUILayout.EndHorizontal();
            }

            window.DrawWindow();
        }
		else
		{
			EditorGUILayout.LabelField(window.EventAction.Label);
			window.DrawWindowCollapsed();
			EditorGUILayout.EndHorizontal();
		}
		if (!window.IsResizingWindow) GUI.DragWindow();
		else window.ResizeWindow();
	}
	
	void OnGUI()
	{
		if (isPlaying && !EditorApplication.isPlaying)
		{
			previousGameObject = null;
			isPlaying = false;
			NodesList.Nodes.Clear();
		}

		if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
		{
			previousGameObject = null;
			NodesList.Nodes.Clear();
		}
		else if (EditorApplication.isPlaying && !isPlaying) isPlaying = true;

		if (!isActiveObject)
		{
			GUI.Label(new Rect(0, 0, 500, 500), new GUIContent("Start selecting an object in the Hierarchy window"));
			return;
		}

		if (previousGameObject == null) return;

		if (!NodesList.Nodes.ContainsKey(previousGameObject)) return;

		if (previousGameObject.GetComponent<GameEvent>() == null)
			GUI.Label(new Rect(0, 0, 500, 500), new GUIContent("Right click to create a new node and begin"));

		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
		{
			var evt = Event.current;
			mousePosition = evt.mousePosition;
			var clickedOnNode = false;

			if (NodesList.Nodes[previousGameObject].Count > nodeClicked)
			{
				var lastClickedNode = NodesList.Nodes[previousGameObject][nodeClicked];

				NodesList.Nodes[previousGameObject].ForEach(node => node.CreateConnection());

				if (isInTransition || lastClickedNode.IsInTransition)
				{
					if (lastClickedNode.IsInTransition) lastClickedNode.HandleTransition(mousePosition);
					else CreateConnection(lastClickedNode.Window, evt.mousePosition);

					if (evt.type == EventType.MouseDown && evt.button == 0)
					{
						var transitioningNode = lastClickedNode;

						clickedOnNode = ClickedOnNode(evt);

						lastClickedNode = NodesList.Nodes[previousGameObject][nodeClicked];

						if (clickedOnNode && transitioningNode != lastClickedNode)
						{
							if (transitioningNode.ChangeOutput(lastClickedNode))
							{
								isInTransition = false;
								lastClickedNode.IsInTransition = false;
							}
							else nodeClicked = NodesList.Nodes[previousGameObject].IndexOf(transitioningNode);
						}
						else if (!clickedOnNode)
						{
							isInTransition = false;
							lastClickedNode.IsInTransition = false;
						}
					}
				}
			}

			if (evt.type == EventType.MouseDown && evt.button == 1 && !isInTransition)
			{
				clickedOnNode = ClickedOnNode(evt);

				var menu = new GenericMenu();

				if (!clickedOnNode)
				{
					for (var nodeIndex = 0; nodeIndex < nodeTypes.Count; nodeIndex++)
					{
						var nodeType = nodeTypes[nodeIndex];
						menu.AddItem(new GUIContent("Add " + nodeType.Name), false, () => CreateNodeCallback(nodeType));
					}
				}
				else
				{
					var node = NodesList.Nodes[previousGameObject][nodeClicked];

					menu.AddItem(new GUIContent("Set as entry point"), false, EntryPointCallBack);

					if (!node.HasPersonalizedContextMenu)
					{
						menu.AddItem(new GUIContent("Create transition"), false, () => isInTransition = true);
						menu.AddItem(new GUIContent("Delete transition"), false, () => node.RemoveOutput(null));
					}
					else node.CreatePersonalizedContextMenu(menu);

					menu.AddItem(new GUIContent("Delete node"), false, () => node.Delete());
				}

				menu.ShowAsContext();
				evt.Use();
			}

			if (NodesList.Nodes[previousGameObject].Count != 0)
			{
				BeginWindows();
				{
					GUI.Window(-1, new Rect(0, 0, 100, 50), ConditionWindow, "Condition");

					NodesList.Nodes[previousGameObject].ForEach
					(
						x =>
						{
							if (x.IsFirstInput) GUI.color = Color.green;
							else GUI.color = Color.cyan;
							x.Window = GUI.Window(NodesList.Nodes[previousGameObject].IndexOf(x), x.Window, DrawWindow, new GUIContent(x.Name));
		              	}
					);
				}
				EndWindows();
			}
		}
		EditorGUILayout.EndScrollView();
	}

	private void CreateNodeCallback(Type type, bool gameEventAdded = false)
	{
		var gameEvent = previousGameObject.GetComponent<GameEvent>();

		if (gameEvent == null)
		{
			previousGameObject.AddComponent(typeof(GameEvent));
			CreateNodeCallback(type, true);
			return;
		}
		else if (gameEventAdded)
		{
			var source = EditorUtility.SaveFilePanelInProject("Save event", gameEvent.gameObject.name + ".xml", "xml", "Please save in a Reources folder");
			if(source.Length != 0)
			{
				File.WriteAllText(source, "");
				AssetDatabase.Refresh();
				var asset = AssetDatabase.LoadAssetAtPath(source, typeof(TextAsset)) as TextAsset;
				gameEvent.EventFile = asset;
			}
			else
			{
				DestroyImmediate(previousGameObject.GetComponent<GameEvent>());
				return;
			}
		}

		var node = Activator.CreateInstance(type) as BaseNode;
		node.Window = new Rect(mousePosition.x, mousePosition.y, node.Window.width, node.Window.height);
		AddToNodesList(node);

		if (gameEvent.Event.FirstAction == null) 
		{
			var index = -1;

			foreach (var firstNode in NodesList.Nodes[previousGameObject])
			{
				if (firstNode.IsFirstInput)
				{
					index = NodesList.Nodes[previousGameObject].IndexOf(firstNode);
					break;
				}
			}

			if(index == -1)
			{
				gameEvent.Event.FirstAction = node.EventAction;
				node.IsFirstInput = true;
			}
			else gameEvent.Event.FirstAction = NodesList.Nodes[previousGameObject][index].EventAction;
		}

		if (gameEventAdded) EventManagerSaveHook.Save(gameEvent.gameObject, NodesList.Nodes[gameEvent.gameObject]);
	}
	
	private void EntryPointCallBack()
	{
		var firstNode = NodesList.Nodes[previousGameObject][nodeClicked];
		firstNode.IsFirstInput = true;
		firstNode.Parent.Event.FirstAction = firstNode.EventAction;

		foreach (var obj in NodesList.Nodes)
		{
			obj.Value.ForEach
			(
				node =>
				{
					if (node.GetOutputEquals(firstNode)) node.RemoveOutput(null);
					if (node != firstNode && node.IsFirstInput) node.IsFirstInput = false;
				}
			);
		}
	}

	private void AddToNodesList(BaseNode node)
	{
		node.Parent = previousGameObject.GetComponent<GameEvent>();
		NodesList.Nodes[previousGameObject].Add(node);
		node.Deleted += DeleteNode;
	}

	private void DeleteNode(BaseNode deletedNode)
	{
		GameObject inObject = null;

		foreach(var obj in NodesList.Nodes)
		{
			obj.Value.ForEach
			(
				node =>
				{
					if (node == deletedNode) inObject = obj.Key;
				}
			);
		}

		NodesList.Nodes[inObject].Remove(deletedNode);
		if (NodesList.Nodes[inObject].Count == 0) DestroyImmediate(inObject.GetComponent<GameEvent>());
		deletedNode = null;
	}

	private bool ClickedOnNode(Event evt)
	{
		var clickedOnNode = false;

		NodesList.Nodes[previousGameObject].ForEach
		(
			node =>
			{
				if (node.Window.Contains(evt.mousePosition))
				{
					clickedOnNode = true;
					nodeClicked = NodesList.Nodes[previousGameObject].IndexOf(node);
				}
			}
		);

		return clickedOnNode;
	}

	private void CreateConnection(Rect startPos, Vector2 endPos)
	{
		var sPos = new Vector3(startPos.x + startPos.width / 2.0f, startPos.y + startPos.height, 0.0f);
		var ePos = new Vector3(endPos.x, endPos.y, 0.0f);
		var sTan = sPos + Vector3.up * 50.0f;
		var eTan = ePos + Vector3.right * 50.0f;

		Handles.DrawBezier(sPos, ePos, sTan, eTan, Color.black, null, 5);
	}
	
	private void CreateList()
	{
		if (previousGameObject == null) return;
		if (NodesList.Nodes.ContainsKey(previousGameObject)) return;

		NodesList.Nodes.Add(previousGameObject, new List<BaseNode>());
		var currentEvent = previousGameObject.GetComponent<GameEvent>();
		
		if (!currentEvent) return;

		var file = currentEvent.EventFile;

		currentEvent.Event = (SerializableGameEvent)AncientTimes.Assets.Scripts.Utilities.XMLDeserializer.Deserialize(typeof(SerializableGameEvent), file);

		var action = currentEvent.Event.FirstAction;

		CreateNodes(action, true);

		for (int nodeIndex = 0; nodeIndex < NodesList.Nodes[previousGameObject].Count - 1; nodeIndex++)
		{
			for (int outputIndex = 1; outputIndex < NodesList.Nodes[previousGameObject].Count; outputIndex++)
			{
				NodesList.Nodes[previousGameObject][nodeIndex].CreateInitialOutput(NodesList.Nodes[previousGameObject][nodeIndex + 1]);
			}
		}
	}

	private BaseNode CreateNodes(ActionBase action, bool firstNode = false)
	{
		if (action != null)
		{
			BaseNode node = null;

			foreach (var nodeType in nodeTypes)
			{
				node = Activator.CreateInstance(nodeType) as BaseNode;
				
				if (action.GetType() == node.ActionType)
				{
					if (firstNode)
					{
						node.IsFirstInput = true;
						firstNode = false;
					}

					AddToNodesList(node);
					NodesList.Nodes[previousGameObject][NodesList.Nodes[previousGameObject].Count - 1].FillNode(action);

					if (!(node is IfElseNode))
					{
						action = action.NextAction;
						CreateNodes(action);
					}
					else
					{
						var ifAction = (action as IfElse).IfAction;
						var elseAction = (action as IfElse).ElseAction;
						var ifNode = CreateNodes(ifAction);
						var elseNode = CreateNodes(elseAction);
						(node as IfElseNode).ChangeOutput(ifNode, true);
						(node as IfElseNode).ChangeOutput(elseNode, false);
					}
					break;
				}
			}
			
			return node;
		}
		return null;
	}

	void Update()
	{
		isActiveObject = Selection.activeGameObject;

		if (Selection.activeGameObject != previousGameObject && previousGameObject != null)
		{
			nodeClicked = 0;
			previousGameObject = Selection.activeGameObject;
			CreateList();
		}
		else
		{
			previousGameObject = Selection.activeGameObject;
			CreateList();
		}

		if (EditorApplication.isPlaying) isPlaying = true;
		else if (isPlaying)
		{
			isPlaying = false;
			previousGameObject = null;
			Repaint();
		}
	}

	#region Messages

	private void OnInspectorUpdate() { Repaint(); }
	
	private void OnSelectionChange() { Repaint(); }

	private void OnHierarchyChange() { Repaint(); }

	#endregion Messages

	#endregion Methods
}