using System;
using UnityEngine;
using System.Collections;

namespace AncientTimes.Assets.Scripts.GameSystem
{
    public class Fading : GameSystemObject
    {
        #region Inner Enums

        public enum FadeStatus
        {
            FadingOut = 0,
            RestInZero,
            FadingIn,
            RestInOne,
        }

        #endregion Inner Enums

        #region Properties

        private static Fading instance;

        public static Fading Instance
        {
            get
            {
                instance = instance ?? new Fading();
                return instance;
            }
        }

        public static FadeStatus Status { get; private set; }

        public static Texture2D FadeTexture;
        private const float fadeSpeed = 0.3f;
        private const int drawDepth = -10;
        private float alpha = 1.0f;
        private int fadeDir = -1;
        private Color customColor;

        #endregion Properties

        #region Constructor

        private Fading() { customColor = Color.black; }

        #endregion Constructor

        #region Methods

        public static void OnGUI()
        {
            GUI.color = new Color(Instance.customColor.r, Instance.customColor.g, Instance.customColor.b, Instance.alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeTexture);

            if (Status != FadeStatus.FadingIn && Status != FadeStatus.FadingOut) return;
            Instance.alpha += Instance.fadeDir * fadeSpeed * Time.deltaTime;
            Instance.alpha = Mathf.Clamp01(Instance.alpha);

            if (Instance.alpha == 0) Status = FadeStatus.RestInZero;
            else if (Instance.alpha == 1) Status = FadeStatus.RestInOne;
        }

        public static void Update() { }

        public static void FadeIn() { BeginFade(-1); }

        public static void FadeIn(Color fadeColor)
        {
            Instance.customColor = fadeColor;
            BeginFade(-1);
        }

        public static void FadeOut() { BeginFade(1); }

        public static void FadeOut(Color fadeColor)
        {
            Instance.customColor = fadeColor;
            BeginFade(1);
        }

        private static float BeginFade(int direction)
        {
            Instance.fadeDir = direction;

            if (direction != -1 && Status != FadeStatus.RestInOne)
            {
                Instance.alpha = 0;
                Status = FadeStatus.FadingOut;
            }
            else if (direction == -1 && Status != FadeStatus.RestInZero)
            {
                Instance.alpha = 1;
                Status = FadeStatus.FadingIn;
            }

            return (fadeSpeed);
        }

        #endregion Methods
    }
}