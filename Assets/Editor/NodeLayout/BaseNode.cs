using System;
using System.Collections.Generic;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Events;
using UnityEngine;
using UnityEditor;

public abstract class BaseNode
{
	#region Inner Enums

	private enum ResizeType
	{
		Horizontal,
		Vertical,
		Diagonal
	}

	#endregion Inner Enums

	#region Properties

	private ActionBase eventAction;
	public ActionBase EventAction
	{
		get
		{
			if (eventAction == null) eventAction = Activator.CreateInstance(ActionType) as ActionBase;
			return eventAction;
		}
		protected set { eventAction = value; }
	}
	public GameEvent Parent;
	public string Name { get; set; }
	public bool IsResizingWindow { get; private set; }
	public bool IsNotCollapsed
	{
		get { return isNotCollapsed; }
		set
		{
			if (isNotCollapsed != value)
			{
				isNotCollapsed = value;
				Collapse();
			}
		}
	}
	public bool IsFirstInput { get; set; }
	public Rect Window { get;  set; }
	public Type ActionType { get; protected set; }
	public bool HasPersonalizedContextMenu { get; protected set; }
	public bool IsInTransition { get; set; }

	public event Action<BaseNode> Deleted;

	protected Vector2 CollapsedWindowBackup;
	
	private bool isNotCollapsed;
	private ResizeType resizeType;

	private const float minX = 200.0f;
	private const float minY = 50.0f;
	public bool HasInput { get; set; }
	public BaseNode Output { get; private set; }

	#endregion Properties

	#region Constructor

	public BaseNode()
	{
		CollapsedWindowBackup = new Vector2(minX, minY);
		Window = new Rect(0, 0, minX, minY);
	}

	#endregion Constructor

	#region Methods

	public virtual void CreateInitialOutput(BaseNode node)
	{
		if (node.EventAction == EventAction.NextAction) ChangeOutput(node);
	}

	public void FillNode(ActionBase action)
	{
		EventAction = action;
		//Debug.Log("X: " + EventAction.WindowX + ", Y: " + EventAction.WindowY);
		Window = new Rect(EventAction.WindowX, EventAction.WindowY, Window.width, Window.height);
	}

	public virtual void DrawWindow()
	{
		var evt = Event.current;
		var isInResizingArea = CheckIfInResizingArea(evt);

		if (isInResizingArea && evt.type == EventType.MouseDown && evt.button == 0) IsResizingWindow = true;
		else if (IsResizingWindow && evt.type == EventType.MouseUp && evt.button == 0) IsResizingWindow = false;
	}

	public virtual void DrawWindowCollapsed() {}

	public bool CheckIfInResizingArea(Event evt)
	{
		var horizontalResizer = new Rect(Window.width - 5, 0, 5, Window.height - 5);
		var verticalResizer = new Rect(0, Window.height - 5, Window.width - 5, 5);
		var diagonalResizer = new Rect(Window.width - 5, Window.height - 5, 5, 5);
		var isInResizingArea = false;
		var screenRect = new Rect(0, 0, Screen.width, Screen.height);
		
		if (horizontalResizer.Contains(evt.mousePosition))
		{
			EditorGUIUtility.AddCursorRect(screenRect, MouseCursor.ResizeHorizontal);
			isInResizingArea = true;
			resizeType = IsResizingWindow ? resizeType : ResizeType.Horizontal;
		}
		else if (verticalResizer.Contains(evt.mousePosition))
		{
			EditorGUIUtility.AddCursorRect(screenRect, MouseCursor.ResizeVertical);
			isInResizingArea = true;
			resizeType = IsResizingWindow ? resizeType : ResizeType.Vertical;
		}
		else if (diagonalResizer.Contains(evt.mousePosition))
		{
			EditorGUIUtility.AddCursorRect(screenRect, MouseCursor.ResizeUpLeft);
			isInResizingArea = true;
			resizeType = IsResizingWindow ? resizeType : ResizeType.Diagonal;
		}

		return isInResizingArea;
	}

	public void ResizeWindow()
	{
		var mousePos = Event.current.mousePosition;

		switch (resizeType)
		{
			case ResizeType.Horizontal:
				Window = new Rect(Window.x, Window.y, Mathf.Max(mousePos.x + 5, minX), Window.height);
				break;
			case ResizeType.Vertical:
				Window = new Rect(Window.x, Window.y, Window.width, Mathf.Max(mousePos.y + 5, minY));
				break;
			case ResizeType.Diagonal:
				Window = new Rect(Window.x, Window.y, Mathf.Max(mousePos.x + 5, minX), Mathf.Max(mousePos.y + 5, minY));
				break;
		}
	}

	private void Collapse()
	{
		if (isNotCollapsed) Window = new Rect(Window.x, Window.y, CollapsedWindowBackup.x, CollapsedWindowBackup.y);
		else
		{
			CollapsedWindowBackup = new Vector2(Window.width, Window.height);
			Window = new Rect(Window.x, Window.y, minX, minY);
		}
	}

	public virtual bool ChangeOutput(BaseNode node)
	{
		var changed = !node.IsFirstInput && node.Output != this && !node.HasInput;
		if (changed)
		{
			node.HasInput = true;
			Output = node;
			EventAction.NextAction = Output.EventAction;
			Output.Deleted += RemoveOutput;
		}
		return changed;
	}

	public virtual void CreateConnection()
	{
		if (Output == null) return;
		var endPos = Output.Window.position;
		var sPos = new Vector3(Window.position.x + Window.width / 2.0f, Window.position.y + Window.height);
		var ePos = new Vector3(endPos.x + Window.width / 2.0f, endPos.y, 0.0f);
		var sTan = sPos + Vector3.up * 50.0f;
		var eTan = ePos + Vector3.down * 50.0f;
		Handles.DrawBezier(sPos, ePos, sTan, eTan, Color.black, null, 5);
	}

	public void Delete()
	{
		if (Deleted != null) Deleted(this);
		eventAction = null;
		if (IsFirstInput) Parent.Event.FirstAction = null;
	}

	public virtual void RemoveOutput(BaseNode node)
	{
		if (Output != null) Output.HasInput = false;
		Output = null;
		EventAction.NextAction = null;
	}

	public virtual bool GetOutputEquals(BaseNode node) { return Output == node; }

	public virtual void CreatePersonalizedContextMenu(GenericMenu menu) {}

	public virtual void HandleTransition(Vector2 mousePosition) {}

	#endregion Methods
}