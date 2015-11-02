using AncientTimes.Assets.Scripts.GameSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events.Actions
{
    public class Fade : ActionBase
    {
        #region Properties

        public bool ParallelInMiddle { get; set; }

        private bool firstCycle = true;
        private const float timeToWaitInMiddle = 1.0f;
        private float timeElapsed;

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            if (Fading.Status == Fading.FadeStatus.RestInZero && firstCycle) Fading.FadeOut();
            else if (Fading.Status == Fading.FadeStatus.RestInZero) IsFinished = true;
            else if (Fading.Status == Fading.FadeStatus.RestInOne)
            {
                IsParallel = ParallelInMiddle || IsParallel;
                timeElapsed += deltaTime;
                if (timeElapsed >= timeToWaitInMiddle) Fading.FadeIn();
            }

            if (firstCycle) firstCycle = false;
        }

        public override ActionBase Clone()
        {
            var action = new Fade()
            {
                IsParallel = this.IsParallel,
                ParallelInMiddle = this.ParallelInMiddle
            };

            if (NextAction != null) action.NextAction = NextAction.Clone();

            return action;
        }

        #endregion Methods
    }
}
