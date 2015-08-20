using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    [XmlInclude(typeof(ShowDialogue))]
    [XmlInclude(typeof(ChangeSwitch))]
    [XmlInclude(typeof(MoveCharacter))]
    [XmlInclude(typeof(PlayAnimation))]
    public abstract class ActionBase
    {
        #region Methods

        public abstract bool Execute(float deltaTime);
        public abstract ActionBase Clone();

        #endregion Methods
    }
}