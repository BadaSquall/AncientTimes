using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class PlayAnimation : ActionBase
    {
        #region Properties

        public string Animation { get; set; }
        public string ObjectToAnimate { get; set; }
        private bool firstCycle = true;
        private Animator animator;

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            if (firstCycle)
            {
                animator = GameObject.Find(ObjectToAnimate).GetComponent<Animator>();
                animator.Play(Animation);
                firstCycle = false;
                return;
            }

            var state = animator.GetCurrentAnimatorStateInfo(0);
            if ((state.IsName(Animation) && state.normalizedTime >= 1.0f) || !state.IsName(Animation)) IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new PlayAnimation()
            {
                IsParallel = this.IsParallel,
                Animation = this.Animation,
                ObjectToAnimate = this.ObjectToAnimate
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}
