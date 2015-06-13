using System.Collections.Generic;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class ShowDialogue : ActionBase
    {
        #region Properties

        public List<Dialogue> Dialogues { get; set; }

        #endregion Properties

        #region Constructor

        public ShowDialogue() { Dialogues = new List<Dialogue>(); }

        #endregion Constructor

        #region Methods

        public override bool Execute(float deltaTime)
        {
            var hasFinished = false;



            return hasFinished;
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
