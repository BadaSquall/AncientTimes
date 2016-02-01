using UnityEngine;
using System;
using System.Collections;

public class MenuController : MonoBehaviour
{
	#region MenuState

	public enum MenuState
	{
		Idle,
		Left,
		Right,
		Up,
		Down
	}

	#endregion
	
	#region Events

	public class MenuStateChangeEventArgs : EventArgs 
	{
		public MenuState NewState { get; set; }
	}

	public event EventHandler<MenuStateChangeEventArgs> StateChanged;

	#endregion

	#region Private
	
	private MenuState _lastState = MenuState.Idle;

	#endregion

	void LateUpdate ()
	{
		var currentState = MenuState.Idle;

		// Detect the current input of the Horizontal axis, then
		// broadcast a state update for the player as needed.
		// Do this on each frame to make sure the state is always
		// set properly based on the current user input
		float horizontal = Input.GetAxis("Horizontal");
		if(horizontal !=0f)
		{
			if(horizontal < 0f)
			{
				currentState = MenuState.Left;
			}
			else
			{
				currentState = MenuState.Right;
			}
		}
		else
		{
			currentState = MenuState.Idle;
		}
		// Detect the current input of the Vertical axis, then
		// broadcast a state update for the player as needed.
		// Do this on each frame to make sure the state is always
		// set properly based on the current user input
		float vertical = Input.GetAxis("Vertical");
		if(vertical !=0f)
		{
			if(vertical < 0f)
			{
				currentState = MenuState.Down;
			}
			else
			{
				currentState = MenuState.Up;
			}
		}
		else
		{
			currentState = MenuState.Idle;
		}

		if (currentState == _lastState) return;

		_lastState = currentState;

		if(StateChanged == null) return;
		
		StateChanged.Invoke (this, new MenuStateChangeEventArgs {
			NewState = currentState
		});
	}
}