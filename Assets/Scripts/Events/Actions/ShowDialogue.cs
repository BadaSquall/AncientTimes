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
                foreach (var dialogue in Dialogues) Console.Write(dialogue.Text);
                Console.MessageComplete += MessageCompleted;
                firstExecute = false;
            }

            return hasFinished;
        }

        void MessageCompleted()
        {
            hasFinished = true;
            firstExecute = true;
            Console.MessageComplete -= MessageCompleted;
        }

        #endregion Methods
    }

    public class Dialogue
    {
        #region Properties

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }

        #endregion Properties
    }
}
