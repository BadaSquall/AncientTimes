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
	public abstract class ActionBase
	{
		#region Properties

		public ActionBase NextAction { get; set; }
		public string Label { get; set; }
		public float WindowX { get; set; }
		public float WindowY { get; set; }

		#endregion Properties

		#region Methods
		
		public abstract bool Execute(float deltaTime);
		public abstract ActionBase Clone();
		
		#endregion Methods
	}
}