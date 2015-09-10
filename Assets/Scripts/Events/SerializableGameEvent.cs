using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.Events
{
	public class SerializableGameEvent
	{
		#region Properties
		
		public EventTrigger Trigger { get; set; }
		public string Condition { get; set; }
		public ActionBase FirstAction { get; set; }
		
		#endregion Properties
	}
}