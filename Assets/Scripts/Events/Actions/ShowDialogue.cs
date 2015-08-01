using AncientTimes.Assets.Scripts.Events.Actions.Helpers;
using AncientTimes.Assets.Scripts.GameSystem;
using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class ShowDialogue : ActionBase
    {
        #region Properties

        public List<Dialogue> Dialogues { get; set; }
        private bool firstExecute;
        private bool hasFinished;

        #endregion Properties

        #region Constructor

        public ShowDialogue()
        {
            Dialogues = new List<Dialogue>();
            firstExecute = true;
        }

        #endregion Constructor

        #region Methods

        public override bool Execute(float deltaTime)
        {
            if (firstExecute)
            {
                Dialogues.ForEach(dialogue => Console.Write(dialogue.Text));
                Console.MessageComplete += MessageCompleted;
                firstExecute = false;
            }

            return hasFinished;
        }

        public override ActionBase Clone()
        {
            var action = new ShowDialogue();

            Dialogues.ForEach(dialogue => action.Dialogues.Add(dialogue.Clone()));

            return action;
        }

        void MessageCompleted()
        {
            hasFinished = true;
            firstExecute = true;
            Console.MessageComplete -= MessageCompleted;
        }

        #endregion Methods
    }
}
