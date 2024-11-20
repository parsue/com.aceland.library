using Unity.Mathematics;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static bool AllClose(float3 a, float3 b, float epsilon) =>
            math.abs(a.x - b.x) < epsilon &&
            math.abs(a.y - b.y) < epsilon &&
            math.abs(a.z - b.z) < epsilon;
        
        public static float3 Remap(float3 value, float3 from1, float3 to1, float3 from2, float3 to2)
        {
            var normalizedValueX = Helper.InverseLerp(from1.x, to1.x, value.x);
            var normalizedValueY = Helper.InverseLerp(from1.y, to1.y, value.y);
            var normalizedValueZ = Helper.InverseLerp(from1.z, to1.z, value.z);

            var remappedValueX = math.lerp(from2.x, to2.x, normalizedValueX);
            var remappedValueY = math.lerp(from2.y, to2.y, normalizedValueY);
            var remappedValueZ = math.lerp(from2.z, to2.z, normalizedValueZ);

            return new float3(remappedValueX, remappedValueY, remappedValueZ);
        }

        public static float3 MoveTowards(float3 current, float3 target, float maxDistanceDelta)
        {
            var direction = target - current;
            var lenSq = math.lengthsq(direction);

            if (lenSq <= maxDistanceDelta * maxDistanceDelta || lenSq == 0f)
                return target;

            var length = math.sqrt(lenSq);
            var clampedDirection = direction / length * maxDistanceDelta;
            return current + clampedDirection;
        }

        public static float3 ClampLength(float3 value, float maxLength)
        {
            var sqLen = math.lengthsq(value);
            if (sqLen <= maxLength * maxLength) return value;

            var norValue = math.normalizesafe(value);
            return norValue * maxLength;
        }

        public static float3 SmoothDamp(float3 current, float3 target, ref float3 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = math.max(0.0001f, smoothTime);
            var frequency = 2f / smoothTime;
            var dampingRatio = frequency * deltaTime;
            var dampingFactor = 1f / (1f + dampingRatio + 0.48f * dampingRatio * dampingRatio + 0.235f * dampingRatio * dampingRatio * dampingRatio);
            var distanceX = current.x - target.x;
            var distanceY = current.y - target.y;
            var distanceZ = current.z - target.z;
            var targetVector = target;
            var maxSpeedSquared = maxSpeed * smoothTime;
            var maxSpeedSquaredThreshold = maxSpeedSquared * maxSpeedSquared;
            var distanceSquared = distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ;
            if (distanceSquared > maxSpeedSquaredThreshold)
            {
                var distance = math.sqrt(distanceSquared);
                distanceX = distanceX / distance * maxSpeedSquared;
                distanceY = distanceY / distance * maxSpeedSquared;
                distanceZ = distanceZ / distance * maxSpeedSquared;
            }

            target.x = current.x - distanceX;
            target.y = current.y - distanceY;
            target.z = current.z - distanceZ;
            var velocityUpdateX = (currentVelocity.x + frequency * distanceX) * deltaTime;
            var velocityUpdateY = (currentVelocity.y + frequency * distanceY) * deltaTime;
            var velocityUpdateZ = (currentVelocity.z + frequency * distanceZ) * deltaTime;
            currentVelocity.x = (currentVelocity.x - frequency * velocityUpdateX) * dampingFactor;
            currentVelocity.y = (currentVelocity.y - frequency * velocityUpdateY) * dampingFactor;
            currentVelocity.z = (currentVelocity.z - frequency * velocityUpdateZ) * dampingFactor;
            var smoothedTargetX = target.x + (distanceX + velocityUpdateX) * dampingFactor;
            var smoothedTargetY = target.y + (distanceY + velocityUpdateY) * dampingFactor;
            var smoothedTargetZ = target.z + (distanceZ + velocityUpdateZ) * dampingFactor;
            var targetDirectionX = targetVector.x - current.x;
            var targetDirectionY = targetVector.y - current.y;
            var targetDirectionZ = targetVector.z - current.z;
            var smoothedDirectionX = smoothedTargetX - targetVector.x;
            var smoothedDirectionY = smoothedTargetY - targetVector.y;
            var smoothedDirectionZ = smoothedTargetZ - targetVector.z;
            if (!(targetDirectionX * smoothedDirectionX + targetDirectionY * smoothedDirectionY + targetDirectionZ * smoothedDirectionZ > 0f))
                return new float3(smoothedTargetX, smoothedTargetY, smoothedTargetZ);
            
            smoothedTargetX = targetVector.x;
            smoothedTargetY = targetVector.y;
            smoothedTargetZ = targetVector.z;
            currentVelocity.x = (smoothedTargetX - targetVector.x) / deltaTime;
            currentVelocity.y = (smoothedTargetY - targetVector.y) / deltaTime;
            currentVelocity.z = (smoothedTargetZ - targetVector.z) / deltaTime;

            return new float3(smoothedTargetX, smoothedTargetY, smoothedTargetZ);
        }
    }
}