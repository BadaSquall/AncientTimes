using System;
using UnityEditor;
using UnityEngine;
using AncientTimes.Assets.Scripts.Events.Actions;

public class IfElseNode : BaseNode
{
	#region Properties

	private bool isIfTransition;
	private BaseNode ifOutput;
	private BaseNode elseOutput;

	#endregion Properties

	#region Constructor

	public IfElseNode()
	{
		Name = "If else node";
		CollapsedWindowBackup = new Vector2(300, 130);
		ActionType = typeof(IfElse);
		HasPersonalizedContextMenu = true;
	}

	public override void DrawWindow()
	{
		var ifElse = EventAction as IfElse;

		EditorGUILayout.BeginVertical();
		{
			EditorGUILayout.LabelField("Condition", EditorStyles.label);
			ifElse.VariableName = EditorGUILayout.TextArea(ifElse.VariableName, EditorStyles.textArea);

			GUILayout.BeginArea(new Rect(0, 0, Window.width, Window.height));
			GUILayout.FlexibleSpace();
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("If", EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Else", EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		EditorGUILayout.EndVertical();

		base.DrawWindow();
	}

	public override void DrawWindowCollapsed()
	{
		EditorGUILayout.BeginVertical();
		{
			GUILayout.BeginArea(new Rect(0, 0, Window.width, Window.height));
			GUILayout.FlexibleSpace();
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("If", EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Else", EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		EditorGUILayout.EndVertical();

		base.DrawWindowCollapsed ();
	}

	public override void CreatePersonalizedContextMenu(GenericMenu menu)
	{
		menu.AddItem(new GUIContent("If transition"), false, () => { IsInTransition = true; isIfTransition = true; } );
		menu.AddItem(new GUIContent("Else transition"), false, () => { IsInTransition = true; isIfTransition = false; });
		menu.AddItem(new GUIContent("Delete if transition"), false, () => RemoveOutput(ifOutput));
		menu.AddItem(new GUIContent("Delete else transition"), false, () => RemoveOutput(elseOutput));

		base.CreatePersonalizedContextMenu(menu);
	}

	public bool ChangeOutput(BaseNode node, bool isIf)
	{
		isIfTransition = isIf;
		return ChangeOutput(node);
	}

	public override bool ChangeOutput(BaseNode node)
	{
		if (node == null) return false;

		var changed = !node.IsFirstInput && node.Output != this && !node.HasInput;

		if (changed)
		{
			var ifElse = EventAction as IfElse;

			if (isIfTransition) 
			{
				ifOutput = node;
				ifOutput.HasInput = true;
				ifElse.IfAction = node.EventAction;
			}
			else
			{
				elseOutput = node;
				elseOutput.HasInput = true;
				ifElse.ElseAction = node.EventAction;
			}
			node.Deleted += RemoveOutput;
		}

		return changed;
	}

	public override void HandleTransition(Vector2 mousePosition)
	{
		if (isIfTransition) IfTransition(mousePosition);
		else ElseTransition(mousePosition);

		base.HandleTransition(mousePosition);
	}

	public override void RemoveOutput(BaseNode node)
	{
		var ifElse = EventAction as IfElse;

		if (node == ifOutput)
		{
			if (ifOutput != null) ifOutput.HasInput = false;
			ifOutput = null;
			ifElse.IfAction = null;
		}
		else
		{
			if (elseOutput != null) elseOutput.HasInput = false;
			elseOutput = null;
			ifElse.ElseAction = null;
		}
	}

	private void IfTransition(Vector2 mousePosition)
	{
		var sPos = new Vector3(Window.x + Window.width / 4.0f, Window.y + Window.height);
		var ePos = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
		var sTan = sPos + Vector3.up * 50.0f;
		var eTan = ePos + Vector3.right * 50.0f;
		
		Handles.DrawBezier(sPos, ePos, sTan, eTan, Color.black, null, 5);
	}

	private void ElseTransition(Vector2 mousePosition)
	{
		var sPos = new Vector3(Window.x + 3.0f * Window.width / 4.0f, Window.y + Window.height);
		var ePos = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
		var sTan = sPos + Vector3.up * 50.0f;
		var eTan = ePos + Vector3.down * 50.0f;
		
		Handles.DrawBezier(sPos, ePos, sTan, eTan, Color.black, null, 5);
	}

	public override void CreateConnection()
	{
		if (ifOutput == null && elseOutput == null) return;
		if (ifOutput != null)
		{
			var ifEndPos = ifOutput.Window.position;
			var ifSPos = new Vector3(Window.x + Window.width / 4.0f, Window.y + Window.height);
			var ifEPos = new Vector3(ifEndPos.x +  Window.width / 2.0f, ifEndPos.y);
			var ifSTan = ifSPos + Vector3.up * 50.0f;
			var ifETan = ifEPos + Vector3.down * 50.0f;
			Handles.DrawBezier(ifSPos, ifEPos, ifSTan, ifETan, Color.black, null, 5);
		}
		if (elseOutput != null)
		{
			var elseEndPos = elseOutput.Window.position;
			var elseSPos = new Vector3(Window.x + 3.0f * Window.width / 4.0f, Window.y + Window.height);
			var elseEPos = new Vector3(elseEndPos.x +  Window.width / 2.0f, elseEndPos.y);
			var elseSTan = elseSPos + Vector3.up * 50.0f;
			var elseETan = elseEPos + Vector3.down * 50.0f;
			Handles.DrawBezier(elseSPos, elseEPos, elseSTan, elseETan, Color.black, null, 5);
		}
	}

	public override bool GetOutputEquals(BaseNode node) { return ifOutput == node || elseOutput == node; }

	public override void CreateInitialOutput(BaseNode node)
	{
		var ifElse = EventAction as IfElse;

		if (node.EventAction == ifElse.IfAction)
		{
			isIfTransition = true;
			ChangeOutput(node);
		}
		else if (node.EventAction == ifElse.ElseAction)
		{
			isIfTransition = false;
			ChangeOutput(node);
		}
	}

	#endregion Constructor
}