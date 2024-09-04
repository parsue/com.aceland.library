using Unity.Mathematics;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static bool AllClose(float2 a, float2 b, float epsilon)
        {
            return math.abs(a.x - b.x) < epsilon && math.abs(a.y - b.y) < epsilon;
        }

        public static float2 MoveTowards(float2 current, float2 target, float maxDistanceDelta)
        {
            var direction = target - current;
            var lenSq = math.lengthsq(direction);

            if (lenSq <= maxDistanceDelta * maxDistanceDelta || lenSq == 0f)
                return target;

            var length = math.sqrt(lenSq);
            var clampedDirection = direction / length * maxDistanceDelta;
            return current + clampedDirection;
        }

        public static float2 ClampLength(float2 value, float maxLength)
        {
            var sqLen = math.lengthsq(value);
            if (sqLen <= maxLength * maxLength) return value;

            var norValue = math.normalizesafe(value);
            return norValue * maxLength;
        }

        public static float2 SmoothDamp(float2 current, float2 target, ref float2 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = math.max(0.0001f, smoothTime);
            var frequency = 2f / smoothTime;
            var dampingRatio = frequency * deltaTime;
            var dampingFactor = 1f / (1f + dampingRatio + 0.48f * dampingRatio * dampingRatio + 0.235f * dampingRatio * dampingRatio * dampingRatio);
            var distanceX = current.x - target.x;
            var distanceY = current.y - target.y;
            var targetVector = target;
            var maxSpeedSquared = maxSpeed * smoothTime;
            var maxSpeedSquaredThreshold = maxSpeedSquared * maxSpeedSquared;
            var distanceSquared = distanceX * distanceX + distanceY * distanceY;
            if (distanceSquared > maxSpeedSquaredThreshold)
            {
                var distance = math.sqrt(distanceSquared);
                distanceX = distanceX / distance * maxSpeedSquared;
                distanceY = distanceY / distance * maxSpeedSquared;
            }

            target.x = current.x - distanceX;
            target.y = current.y - distanceY;
            var velocityUpdateX = (currentVelocity.x + frequency * distanceX) * deltaTime;
            var velocityUpdateY = (currentVelocity.y + frequency * distanceY) * deltaTime;
            currentVelocity.x = (currentVelocity.x - frequency * velocityUpdateX) * dampingFactor;
            currentVelocity.y = (currentVelocity.y - frequency * velocityUpdateY) * dampingFactor;
            var smoothedTargetX = target.x + (distanceX + velocityUpdateX) * dampingFactor;
            var smoothedTargetY = target.y + (distanceY + velocityUpdateY) * dampingFactor;
            var targetDirectionX = targetVector.x - current.x;
            var targetDirectionY = targetVector.y - current.y;
            var smoothedDirectionX = smoothedTargetX - targetVector.x;
            var smoothedDirectionY = smoothedTargetY - targetVector.y;
            if (!(targetDirectionX * smoothedDirectionX + targetDirectionY * smoothedDirectionY > 0f)) return new(smoothedTargetX, smoothedTargetY);
            
            smoothedTargetX = targetVector.x;
            smoothedTargetY = targetVector.y;
            currentVelocity.x = (smoothedTargetX - targetVector.x) / deltaTime;
            currentVelocity.y = (smoothedTargetY - targetVector.y) / deltaTime;

            return new(smoothedTargetX, smoothedTargetY);
        }
    }
}