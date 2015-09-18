using System;
using AncientTimes.Assets.Scripts.Utilities;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
	public class IfElse : ActionBase
	{
		#region Properties

		public string VariableName { get; set; }
		public ActionBase IfAction { get; set; }
		public ActionBase ElseAction { get; set; }

		#endregion Properties

		#region Methods

		public override bool Execute(float deltaTime)
		{
			if (bool.Parse(GameVariables.Get(VariableName, true))) NextAction = IfAction;
			else NextAction = ElseAction;

			return true;
		}

		public override ActionBase Clone()
		{
			var action = new IfElse()
			{
				VariableName = this.VariableName
			};

			action.IfAction = IfAction.Clone();
			action.ElseAction = ElseAction.Clone();

			if (NextAction != null) action.NextAction = NextAction.Clone();

			return action;
		}

		#endregion Methods
	}
}