using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Events.Actions.Helpers;

namespace AncientTimes.Assets.Scripts.PG
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class StatusController : MonoBehaviour
    {
        #region Properties

        public enum Status { Idle = 0, WalkingRight, WalkingLeft, WalkingDown, WalkingUp, RunningRight, RunningLeft, RunningDown, RunningUp, StatusCount }
        public delegate void OnStatusChangeHandler(Status newStatus);
        public static event OnStatusChangeHandler OnStatusChange;
        private Animator animator;
        private float walkSpeed;
        public Console Dialogue;
		public GameEvent FocusedEvent;

        #endregion Properties

        #region Methods

        void Start()
        {
            animator = GetComponent<Animator>();
            walkSpeed = 5.0f;
        }

        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return)) EventManager.RegisterEvent

            if (OnStatusChange == null) return;

            if (Input.GetKey("right")) OnStatusChange(Status.WalkingRight);
            else if (Input.GetKey("left")) OnStatusChange(Status.WalkingLeft);
            else if (Input.GetKey("down")) OnStatusChange(Status.WalkingDown);
            else if (Input.GetKey("up")) OnStatusChange(Status.WalkingUp);
       		else OnStatusChange(Status.Idle);
		}
		

        public void WalkRight()
        {
            rigidbody2D.velocity = new Vector2(walkSpeed, 0.0f);
			animator.SetTrigger("WalkRight");
        }

        public void WalkLeft()
        {
            rigidbody2D.velocity = new Vector2(walkSpeed * (-1.0f), 0.0f);
			animator.SetTrigger("WalkLeft");
        }

        public void WalkDown()
        {
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed * (-1.0f));
			animator.SetTrigger("WalkDown");
        }

        public void WalkUp()
        {
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed);
			animator.SetTrigger("WalkUp");
        }

        public void Idle()
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetTrigger("Idle");
        }

		void OnCollisionEnter2D(Collider2D coll)
		{
			var gameevent = coll.GetComponent<GameEvent> ();
			if (gameevent != null)	FocusedEvent = gameevent;
		}

		void OnCollisionExit2D(Collider2D coll)
		{
				
		}

        #endregion Methods

        #region JustForTest

        private void SerializeDeserializeEvent()
        {
            var ge = new SerializableGameEvent();
            ge.Containers.Add(new Container()
            {
                Condition = "IsFirstEncounter"
            });
            ge.Containers[0].Actions.Add(new ShowDialogue());
            (ge.Containers[0].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Hey come stai?"
            });
            (ge.Containers[0].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Sapevo saresti venuto"
            });
            ge.Containers[0].Actions.Add(new ChangeSwitch()
            {
                Name = "IsFirstEncounter",
                Value = false
            });
            ge.Containers[0].Actions.Add(new ChangeSwitch()
            {
                Name = "IsSecondEncounter",
                Value = true
            });
            ge.Containers.Add(new Container()
            {
                Condition = "IsSecondEncounter"
            });
            ge.Containers[1].Actions.Add(new ShowDialogue());
            (ge.Containers[1].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Mia sorella è un uomo :'("
            });

            //Utilities.XMLSerializer.Serialize(ge, @"Assets/Events/Temple/CapoTerra.xml");

            var evt = (SerializableGameEvent) Utilities.XMLDeserializer.Deserialize(typeof(SerializableGameEvent), @"Assets/Events/Temple/CapoTerra.xml");
            Debug.Log(evt);
        }

        #endregion JustForTest
    }
}