using AncientTimes.Assets.Scripts.Events.Actions.Helpers;
using AncientTimes.Assets.Scripts.GameSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class ShowDialogue : ActionBase
    {
        #region Properties

        public List<Dialogue> Dialogues { get; set; }
        private bool firstExecute;

        #endregion Properties

        #region Constructor

        public ShowDialogue()
        {
            Dialogues = new List<Dialogue>();
            firstExecute = true;
        }

        #endregion Constructor

        #region Methods

        public override void Execute(float deltaTime)
        {
            if (firstExecute && !IsFinished)
            {
                if (Dialogues.Count == 0)
                {
                    IsFinished = true;
                    return;
                }

                Console.Write(Dialogues[0].Text, Dialogues[0].ImagePath);
                Console.MessageComplete += PopDialogue;
                firstExecute = false;
            }
        }

        public override ActionBase Clone()
        {
            var action = new ShowDialogue();
            action.IsParallel = this.IsParallel;

            Dialogues.ForEach(dialogue => action.Dialogues.Add(dialogue.Clone()));

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        private void PopDialogue()
        {
            Dialogues.RemoveAt(0);

            if (Dialogues.Count == 0)
            {
                MessageCompleted();
                return;
            }

            Console.Write(Dialogues[0].Text, Dialogues[0].ImagePath);
        }

        private void MessageCompleted()
        {
            IsFinished = true;
            firstExecute = true;
            Console.MessageComplete -= PopDialogue;
        }

        #endregion Methods
    }
}