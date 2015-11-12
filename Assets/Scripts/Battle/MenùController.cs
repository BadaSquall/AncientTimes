using UnityEngine;
using System.Collections;
public class MenùController : MonoBehaviour
{
	public enum Menù ()
	{
		idle = 0,
		left,
		rigth,
		up,
		down
	}
	public delegate void MenùHandler(MenùController.MenùnewState);
	public static event MenùHandleronStateChange;
	void LateUpdate ()
	{
		// Detect the current input of the Horizontal axis, then
		// broadcast a state update for the player as needed.
		// Do this on each frame to make sure the state is always
		// set properly based on the current user input
		float horizontal = Input.GetAxis("Horizontal");
		if(horizontal !=0f)
		{
			if(horizontal < 0f)
			{
				if(onStateChange != null) onStateChange(MenùController.Menù.left);
			}
			else
			{
				if(onStateChange != null) onStateChange(MenùController.Menù.right);
			}
		}
		else
		{
			if(onStateChange != null) onStateChange(MenùController.Menù.idle)
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
				if(onStateChange != null) onStateChange(MenùController.Menù.down);
			}
			else
			{
				if(onStateChange != null) onStateChange(MenùController.Menù.up);
			}
		}
		else
		{
			if(onStateChange != null) onStateChange(MenùController.Menù.idle)
		}
	}
}