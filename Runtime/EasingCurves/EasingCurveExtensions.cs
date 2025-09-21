using UnityEngine;
#if DOTWEEN
using DG.Tweening;
#endif

namespace AceLand.Library.EasingCurves
{
    public static class EasingCurveExtensions
    {
        // Back overshoot constant (1.70158 by convention)
        private const float BACK_OVERSHOOT = 1.70158f;

#if DOTWEEN
        public static Ease ToDoTweenEase(this EasingCurve easingCurve)
        {
            var curveName = easingCurve.ToString();
            var ease = Enum.GetValues(typeof(Ease)).AsValueEnumerable()
                .FirstOrDefault(e => e.ToString() == curveName);
            if (ease == null) return Ease.Linear;
            return (Ease)ease;
        }
#endif

        // New overload that applies loop/wrap mode before easing
        public static float Evaluate(this EasingCurve easing, float t, CurveLoopMode curveLoopMode = CurveLoopMode.Clamp)
        {
            // Map t according to loop mode
            switch (curveLoopMode)
            {
                case CurveLoopMode.Once:
                    // leave t as-is
                    break;

                case CurveLoopMode.Clamp:
                    t = Mathf.Clamp01(t);
                    break;

                case CurveLoopMode.Loop:
                {
                    // Repeat t into [0,1). Mathf.Repeat handles negatives correctly.
                    t = Mathf.Repeat(t, 1f);
                    break;
                }

                case CurveLoopMode.PingPong:
                {
                    // PingPong t into [0,1]. Handles negatives correctly.
                    t = Mathf.PingPong(t, 1f);
                    break;
                }
            }

            // For numerical stability with easing functions expecting [0,1],
            // clamp mildly when Once is used but t falls slightly outside.
            // This keeps extreme inputs behaving sanely while not forcing wrap.
            if (curveLoopMode == CurveLoopMode.Once)
                t = Mathf.Clamp01(t);

            switch (easing)
            {
                case EasingCurve.Linear: return t;

                // Sine
                case EasingCurve.InSine: return 1f - Mathf.Cos((t * Mathf.PI) * 0.5f);
                case EasingCurve.OutSine: return Mathf.Sin((t * Mathf.PI) * 0.5f);
                case EasingCurve.InOutSine: return -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f);

                // Quad
                case EasingCurve.InQuad: return t * t;
                case EasingCurve.OutQuad: return 1f - (1f - t) * (1f - t);
                case EasingCurve.InOutQuad: return t < 0.5f ? 2f * t * t : 1f - Mathf.Pow(-2f * t + 2f, 2f) * 0.5f;

                // Cubic
                case EasingCurve.InCubic: return t * t * t;
                case EasingCurve.OutCubic:
                {
                    var u = 1f - t;
                    return 1f - u * u * u;
                }
                case EasingCurve.InOutCubic:
                    return t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f) * 0.5f;

                // Quart
                case EasingCurve.InQuart:
                {
                    var t2 = t * t;
                    return t2 * t2;
                }
                case EasingCurve.OutQuart:
                {
                    var u = 1f - t;
                    var u2 = u * u;
                    return 1f - u2 * u2;
                }
                case EasingCurve.InOutQuart:
                    if (t < 0.5f)
                    {
                        var a = t * 2f;
                        a *= a;
                        return 0.5f * a * a;
                    }
                    else
                    {
                        var a = (1f - t) * 2f;
                        a *= a;
                        return 1f - 0.5f * a * a;
                    }

                // Quint
                case EasingCurve.InQuint: return t * t * t * t * t;
                case EasingCurve.OutQuint:
                {
                    var u = 1f - t;
                    return 1f - u * u * u * u * u;
                }
                case EasingCurve.InOutQuint:
                    return t < 0.5f
                        ? 16f * t * t * t * t * t
                        : 1f - Mathf.Pow(-2f * t + 2f, 5f) * 0.5f;

                // Expo
                case EasingCurve.InExpo: return t <= 0f ? 0f : Mathf.Pow(2f, 10f * (t - 1f));
                case EasingCurve.OutExpo: return t >= 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
                case EasingCurve.InOutExpo:
                    return t switch
                    {
                        <= 0f => 0f,
                        >= 1f => 1f,
                        _ => t < 0.5f
                            ? Mathf.Pow(2f, 20f * t - 10f) * 0.5f
                            : (2f - Mathf.Pow(2f, -20f * t + 10f)) * 0.5f
                    };

                // Circ
                case EasingCurve.InCirc: return 1f - Mathf.Sqrt(1f - t * t);
                case EasingCurve.OutCirc:
                {
                    var u = t - 1f;
                    return Mathf.Sqrt(1f - u * u);
                }
                case EasingCurve.InOutCirc:
                    if (t < 0.5f)
                        return 0.5f * (1f - Mathf.Sqrt(1f - 4f * t * t));
                {
                    var u = 2f * t - 2f;
                    return 0.5f * (Mathf.Sqrt(1f - u * u) + 1f);
                }

                // Back
                case EasingCurve.InBack:
                {
                    return (BACK_OVERSHOOT + 1f) * t * t * t - BACK_OVERSHOOT * t * t;
                }
                case EasingCurve.OutBack:
                {
                    var u = t - 1f;
                    return 1f + (BACK_OVERSHOOT + 1f) * u * u * u + BACK_OVERSHOOT * u * u;
                }
                case EasingCurve.InOutBack:
                {
                    const float s = BACK_OVERSHOOT * 1.525f;
                    if (t < 0.5f)
                    {
                        var a = t * 2f;
                        return 0.5f * (a * a * ((s + 1f) * a - s));
                    }
                    else
                    {
                        var a = t * 2f - 2f;
                        return 0.5f * (a * a * ((s + 1f) * a + s) + 2f);
                    }
                }

                // Elastic
                case EasingCurve.InElastic:
                    if (t is 0f or 1f) return t;
                    return -Mathf.Pow(2f, 10f * (t - 1f)) * Mathf.Sin((t - 1.075f) * (2f * Mathf.PI) / 0.3f);
                case EasingCurve.OutElastic:
                    if (t is 0f or 1f) return t;
                    return Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - 0.075f) * (2f * Mathf.PI) / 0.3f) + 1f;
                case EasingCurve.InOutElastic:
                    if (t is 0f or 1f) return t;
                    t *= 2f;
                    if (t < 1f)
                        return -0.5f * Mathf.Pow(2f, 10f * (t - 1f)) *
                               Mathf.Sin((t - 1.1125f) * (2f * Mathf.PI) / 0.45f);
                    return Mathf.Pow(2f, -10f * (t - 1f)) * Mathf.Sin((t - 1.1125f) * (2f * Mathf.PI) / 0.45f) * 0.5f +
                           1f;

                // Bounce
                case EasingCurve.InBounce: return 1f - OutBounceUnclamped(1f - t);
                case EasingCurve.OutBounce: return OutBounceUnclamped(t);
                case EasingCurve.InOutBounce:
                    return t < 0.5f
                        ? (1f - OutBounceUnclamped(1f - 2f * t)) * 0.5f
                        : (1f + OutBounceUnclamped(2f * t - 1f)) * 0.5f;

                default: return t;
            }
        }

        // Separated for reuse
        private static float OutBounceUnclamped(float t)
        {
            // piecewise polynomial per Penner
            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            switch (t)
            {
                case < 1f / d1:
                    return n1 * t * t;
                case < 2f / d1:
                    t -= 1.5f / d1;
                    return n1 * t * t + 0.75f;
                case < 2.5f / d1:
                    t -= 2.25f / d1;
                    return n1 * t * t + 0.9375f;
                default:
                    t -= 2.625f / d1;
                    return n1 * t * t + 0.984375f;
            }
        }
    }
}