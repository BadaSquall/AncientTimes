using AncientTimes.Assets.Scripts.Events.Actions;
using AncientTimes.Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.Events
{
    public class PlayCharacterAnimation : ActionBase
    {
        #region Properties

        public string CharacterToAnimate { get; set; }
        public CharacterAnimation Animation { get; set; }

        #endregion Properties

        #region Methods

        public override void Execute(float deltaTime)
        {
            var anim = Resources.Load("CharacterAnimations/" + Animation.ToString()) as GameObject;
            anim.transform.position = GameObject.Find(CharacterToAnimate).transform.position;
            IsFinished = true;
        }

        public override ActionBase Clone()
        {
            var action = new PlayCharacterAnimation()
            {
                IsParallel = this.IsParallel,
                CharacterToAnimate = this.CharacterToAnimate,
                Animation = this.Animation
            };

            if (NextAction != null) action.NextAction = NextAction;

            return action;
        }

        #endregion Methods
    }
}