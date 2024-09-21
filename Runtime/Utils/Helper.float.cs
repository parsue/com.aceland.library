using Unity.Mathematics;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = math.max(0.0001f, smoothTime);
            var frequency = 2f / smoothTime;
            var dampingRatio = frequency * deltaTime;
            var dampingFactor = 1f / (1f + dampingRatio + 0.48f * dampingRatio * dampingRatio + 0.235f * dampingRatio * dampingRatio * dampingRatio);
            var distance = current - target;
            var maxSpeedSquared = maxSpeed * smoothTime;
            var maxSpeedSquaredThreshold = maxSpeedSquared * maxSpeedSquared;
            if (distance * distance > maxSpeedSquaredThreshold)
            {
                distance = math.sign(distance) * maxSpeedSquared;
            }

            target = current - distance;
            var velocityUpdate = (currentVelocity + frequency * distance) * deltaTime;
            currentVelocity = (currentVelocity - frequency * velocityUpdate) * dampingFactor;
            var smoothedTarget = target + (distance + velocityUpdate) * dampingFactor;
            var targetDirection = target - current;
            var smoothedDirection = smoothedTarget - target;
            if (!(targetDirection * smoothedDirection > 0f)) return smoothedTarget;

            smoothedTarget = target;
            currentVelocity = (smoothedTarget - target) / deltaTime;

            return smoothedTarget;
        }
        
        public static float InverseLerp(float a, float b, float value)
        {
            return math.abs(a - b) > float.Epsilon ? math.clamp((value - a) / (b - a), 0, 1) : 0.0f;
        }
    }
}