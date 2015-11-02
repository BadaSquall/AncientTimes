using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class ChangePosition : ActionBase
    {
        #region Properties

        public string ObjectToReposition { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public Direction DirectionToLook { get; set; }

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            var obj = GameObject.Find(ObjectToReposition);
            obj.GetComponent<Animator>().SetTrigger("Idle" + DirectionToLook.ToString());
            obj.transform.localPosition = new Vector2(PositionX, PositionY);
            IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new ChangePosition()
            {
                IsParallel = this.IsParallel,
                ObjectToReposition = this.ObjectToReposition,
                PositionX = this.PositionX,
                PositionY = this.PositionY,
                DirectionToLook = this.DirectionToLook
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}
