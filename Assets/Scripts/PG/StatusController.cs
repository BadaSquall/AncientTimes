using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Events.Actions.Helpers;
using AncientTimes.Assets.Scripts.Utilities;

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

        public EventManager eventManager;

        #endregion Properties

        #region Methods

        void Start()
        {
            animator = GetComponent<Animator>();
            walkSpeed = 5.0f;
          /*  eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>(); */
            Console.MessageComplete += () => Debug.Log("Ci sono");
        }

        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.K)) Console.Write("Ciao"); //SerializeDeserializeEvent();
            if (Input.GetKeyDown(KeyCode.A)) LookAt(Direction.Left);
            //if (Input.GetKeyDown(KeyCode.Return)) eventManager.RegisterEvent(FocusedEvent);

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

		void OnCollisionEnter2D(Collision2D coll)
		{
			var gameevent = coll.gameObject.GetComponent<GameEvent>();
			if (gameevent != null)	FocusedEvent = gameevent;
		}

		void OnCollisionExit2D(Collision2D coll)
		{
				
		}

        public void LookAt(GameObject egocentric)
        {
            if (egocentric.transform.position.x > transform.position.x) LookAt(Direction.Right);
            if (egocentric.transform.position.x < transform.position.x) LookAt(Direction.Left);
            if (egocentric.transform.position.y > transform.position.y) LookAt(Direction.Up);
            if (egocentric.transform.position.y < transform.position.y) LookAt(Direction.Down);
        }

        public void LookAt(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    animator.SetTrigger("IdleRight");
                    break;
                case Direction.Left:
                    animator.SetTrigger("IdleLeft");
                    break;
                case Direction.Up:
                    animator.SetTrigger("IdleUp");
                    break;
                case Direction.Down:
                    animator.SetTrigger("IdleDown");
                    break;
            }
        }

        #endregion Methods

        #region JustForTest

        private void SerializeDeserializeEvent()
        {
            var test = new GameObject();
            test.AddComponent<GameEvent>();
            var ge = test.GetComponent<GameEvent>();
            ge.Event = new SerializableGameEvent();
            ge.Event.Containers.Add(new Container()
            {
                Condition = "IsFirstEncounter"
            });
            ge.Event.Containers[0].Actions.Add(new ShowDialogue());
            (ge.Event.Containers[0].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Hey come stai?"
            });
            (ge.Event.Containers[0].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Sapevo saresti venuto"
            });
            ge.Event.Containers[0].Actions.Add(new ChangeSwitch()
            {
                Name = "IsFirstEncounter",
                Value = false
            });
            ge.Event.Containers[0].Actions.Add(new ChangeSwitch()
            {
                Name = "IsSecondEncounter",
                Value = true
            });
            ge.Event.Containers.Add(new Container()
            {
                Condition = "IsSecondEncounter"
            });
            ge.Event.Containers[1].Actions.Add(new ShowDialogue());
            (ge.Event.Containers[1].Actions[0] as ShowDialogue).Dialogues.Add(new Dialogue()
            {
                Text = "Mia sorella è un uomo :'("
            });
            ge.Event.Containers[1].Actions.Add(new ChangeSwitch()
            {
                Name = "IsSecondEncounter",
                Value = false
            });
            ge.Event.Containers[1].Actions.Add(new ChangeSwitch()
            {
                Name = "IsThirdEncounter",
                Value = true
            });
            ge.Event.Containers.Add(new Container()
            {
                Condition = "IsThirdEncounter"
            });
            ge.Event.Containers[2].Actions.Add(new MoveCharacter()
            {
                Direction = Direction.Right,
                ObjectToMove = "CapoTerra"
            });
            ge.Event.Containers[2].Actions.Add(new MoveCharacter()
            {
                Direction = Direction.Down,
                ObjectToMove = "CapoTerra"
            });
            //Utilities.XMLSerializer.Serialize(ge, @"Assets/Events/Temple/CapoTerra.xml");

            eventManager.RegisterEvent(ge);
        }

        #endregion JustForTest
    }
}