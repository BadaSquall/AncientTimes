using UnityEngine;
using System.Collections;
using AncientTimes.Assets.Scripts.GameSystem;
using AncientTimes.Assets.Scripts.Events;
using AncientTimes.Assets.Scripts.Events.Actions;

namespace AncientTimes.Assets.Scripts.PG
{
    [RequireComponent(typeof(Animator))]
    public class StatusController : MonoBehaviour
    {
        #region Properties

        public enum Status { Idle = 0, WalkingRight, WalkingLeft, WalkingDown, WalkingUp, RunningRight, RunningLeft, RunningDown, RunningUp, StatusCount }
        public delegate void OnStatusChangeHandler(Status newStatus);
        public static event OnStatusChangeHandler OnStatusChange;
        private Animator animator;
        private float walkSpeed;
        public Console Dialogue;

        #endregion Properties

        #region Methods

        void Start()
        {
            animator = GetComponent<Animator>();
            walkSpeed = 300.0f;
        }

        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                var ge = new GameEvent();
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

                Utilities.XMLSerializer.Serialize(ge, @"Assets/Events/Temple/CapoTerra.xml");

                var evt = (GameEvent)Utilities.XMLDeserializer.Deserialize(typeof(GameEvent), @"Assets/Events/Temple/CapoTerra.xml");
                Debug.Log(evt);
            }

            if (OnStatusChange == null) return;

            if (Input.GetKey("right")) OnStatusChange(Status.WalkingRight);
            else if (Input.GetKey("left")) OnStatusChange(Status.WalkingLeft);
            else if (Input.GetKey("down")) OnStatusChange(Status.WalkingDown);
            else if (Input.GetKey("up")) OnStatusChange(Status.WalkingUp);
       		else OnStatusChange(Status.Idle);
		}

        public void WalkRight()
        {
            rigidbody2D.velocity = new Vector2(walkSpeed * Time.deltaTime, 0.0f);
			animator.SetTrigger ("WalkRight");
        }

        public void WalkLeft()
        {
            rigidbody2D.velocity = new Vector2(walkSpeed * Time.deltaTime * (-1.0f), 0.0f);
			animator.SetTrigger("WalkLeft");
        }

        public void WalkDown()
        {
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed * Time.deltaTime * (-1.0f));
			animator.SetTrigger("WalkDown");

        }

        public void WalkUp()
        {
            rigidbody2D.velocity = new Vector2(0.0f, walkSpeed * Time.deltaTime);
			animator.SetTrigger("WalkUp");
        }

        public void Idle()
        {
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
            animator.SetTrigger("Idle");
        }

        #endregion Methods
    }
}