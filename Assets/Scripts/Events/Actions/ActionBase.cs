using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
	[XmlInclude(typeof(ShowDialogue))]
	[XmlInclude(typeof(ChangeSwitch))]
	[XmlInclude(typeof(IfElse))]
    [XmlInclude(typeof(MoveCharacter))]
    [XmlInclude(typeof(PlayAnimation))]
    [XmlInclude(typeof(LookAtDirection))]
    [XmlInclude(typeof(Wait))]
	public abstract class ActionBase
	{
		#region Properties

		public ActionBase NextAction { get; set; }
        public bool IsParallel { get; set; }

		public string Label { get; set; }
		public float WindowX { get; set; }
		public float WindowY { get; set; }

        [System.NonSerialized]
        public bool IsFinished;

		#endregion Properties

		#region Methods
		
		public abstract void Execute(float deltaTime);
		public abstract ActionBase Clone();
		
		#endregion Methods
	}
}