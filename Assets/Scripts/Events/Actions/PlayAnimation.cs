﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class PlayAnimation : ActionBase
    {
        #region Properties

        public string Trigger { get; set; }
        public string ObjectToAnimate { get; set; }
        //private GameObject objectToAnimateInstance;

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            GameObject.Find(ObjectToAnimate).GetComponent<Animator>().SetTrigger(Trigger);
            IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new PlayAnimation()
            {
                IsParallel = this.IsParallel,
                Trigger = this.Trigger,
                ObjectToAnimate = this.ObjectToAnimate
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}
