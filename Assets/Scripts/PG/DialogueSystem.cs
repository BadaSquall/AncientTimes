using UnityEngine;
using System.Collections;


namespace AncientTimes.Assets.Scripts.PG
{
	public class DialogueSystem : MonoBehaviour 
	{

		#region Properties

		public string button;
		public GameObject Text;
		public GameObject DialogueSys;
		public GameObject TextName;
		public GameObject TextChat;

		private Animation dyalogueAnimation;

		private bool thereWasContact;
		private bool isAnimationOpen;
		private bool isAnimationClose ;
		private bool Control;
		private bool isLast;

		#endregion Properties

		#region Methods

		void Start () 
		{
			Text.SetActive(false);
			DialogueSys.SetActive(false);
			TextName.SetActive(false);

			dyalogueAnimation = DialogueSys.GetComponent<Animation>();
		}

		void Update () { if (thereWasContact) DialogueControl(); }

        void FixedUpdate() { AnimationTrigger(); }

		void DialogueControl()
		{
			if (Input.GetKeyDown("k") && !isAnimationOpen && !Control && !isLast)
            {
				isAnimationOpen = true;
				Control = true;
			}
            else if (Input.GetKeyDown("k") && Control && !isLast) isLast = true;
            else if (Input.GetKeyDown("k") && isLast)
            {
				isAnimationClose = true;
				Control = false;
			}
		}

		void AnimationTrigger()
		{
			if (isAnimationOpen && !isAnimationClose) 
			{
				AnimateOpen();
				isAnimationOpen = false;
			}
            else if (isAnimationClose && isLast)
			{
				AnimateClose();
				isAnimationClose = false;
				isLast = false;
			}
		}
		
		void OnTriggerEnter2D(Collider2D coll)
		{
			thereWasContact = true;
			Text.SetActive(true);
		}

		void OnTriggerExit2D(Collider2D coll)
		{
			thereWasContact = false;
			Text.SetActive(false);
		}

		void AnimateOpen()
        {
			Text.SetActive(false);
			DialogueSys.SetActive(true);
			dyalogueAnimation.Play("OpenDialogue");
			TextName.SetActive(true);
			TextChat.SetActive(true);
		}

		void AnimateClose()
		{
			dyalogueAnimation.Play("CloseDialogue");
			Text.SetActive(true);
		}

		#endregion Methods
	}
}