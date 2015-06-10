using UnityEngine;
using System.Collections;


namespace AncientTimes.Assets.Scripts.PG
{
	[RequireComponent(typeof(Animator))]
	public class DialogueSystem : MonoBehaviour 
	{

		#region Properties

		public string button;
		public GameObject Text;
		public GameObject DialogueSys;
		public GameObject TextName;
		public GameObject TextChat;

		private Animation anim;

		private bool Contact = false;
		private bool AnimationOpen = false;
		private bool AnimationClose = false;
		private bool Control = false;
		private bool Last = false;

		#endregion Properties

		#region Methods

		// Use this for initialization
		void Start () 
		{
			Text.SetActive (false);
			DialogueSys.SetActive (false);
			TextName.SetActive (false);

			anim = DialogueSys.GetComponent<Animation> ();
		}
	
		// Update is called once per frame
		void Update () 
		{
			if (Contact)
				DialogueControl ();
		}

		void DialogueControl()
		{
			if (Input.GetKeyDown ("k") && !AnimationOpen && !Control && !Last) {
				AnimationOpen = true;
				Control = true;
			} else if (Input.GetKeyDown ("k") && Control && !Last) {
				//Slide ad animazioni fino a Last = true	
				Last = true;
			} else if (Input.GetKeyDown ("k") && Last) {
				AnimationClose = true;
				Control = false;
			}
		}

		void AnimationTrigger()
		{
			if (AnimationOpen && !AnimationClose) 
			{
				AnimationOp();
				AnimationOpen = false;
			} else if (AnimationClose && Last)
			{
				AnimationCl();
				AnimationClose = false;
				Last = false;
			}
		}
		
		void OnTriggerEnter2D(Collider2D coll)
		{
			Contact = true;
			Text.SetActive (true);
		}

		void OnTriggerExit2D(Collider2D coll)
		{
			Contact = false;
			Text.SetActive (false);
		}

		void FixedUpdate()
		{
			AnimationTrigger ();
		}

		void AnimationOp(){
			Text.SetActive (false);
			DialogueSys.SetActive (true);
			anim.Play ("OpenDialogue");
			TextName.SetActive (true);
			TextChat.SetActive (true);
		}

		void AnimationCl()
		{
			anim.Play ("CloseDialogue");
			Text.SetActive (true);
		}



		#endregion Methods
	}
}