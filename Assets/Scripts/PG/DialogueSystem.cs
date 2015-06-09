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
		private bool animation = false;
		private bool opened = false;

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
		}

		void OnTriggerEnter2D(Collider2D coll)
		{
			Text.SetActive (true);
		}

		void OnTriggerStay2D(Collider2D coll)
		{
			if (Input.GetKey("k")) 
			{
				Text.SetActive(false);
				animation = true;
			}
		}


		void K ()
		{

		}

		void FixedUpdate()
		{
			if (Input.GetKeyDown("k") && opened)
			{
				anim.Play("CloseDialogue");
				opened = false;
				TextName.SetActive(false);
				TextChat.SetActive(false);
			}

			if (animation) 
			{
				DialogueSys.SetActive(true);
				anim.Play("OpenDialogue");
				TextName.SetActive(true);
				TextChat.SetActive(true);
				animation = false;
				opened = true;
			}
		}

		void OnTriggerExit2D(Collider2D coll)
		{
			Text.SetActive (false);
		}

		#endregion Methods
	}
}