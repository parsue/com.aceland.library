using System.Runtime.Serialization;
using UnityEngine;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class AnimationCurveSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (AnimationCurve)obj;

            var keys = value.keys;
            var keyCount = keys.Length;
            info.AddValue("keyCount", keyCount);

            for (var i = 0; i < keyCount; i++)
            {
                info.AddValue($"key{i}_time", keys[i].time);
                info.AddValue($"key{i}_value", keys[i].value);
                info.AddValue($"key{i}_inTangent", keys[i].inTangent);
                info.AddValue($"key{i}_outTangent", keys[i].outTangent);
                info.AddValue($"key{i}_inWeight", keys[i].inWeight);
                info.AddValue($"key{i}_outWeight", keys[i].outWeight);
                info.AddValue($"key{i}_weightedMode", keys[i].weightedMode);
            }

            info.AddValue("preWrapMode", value.preWrapMode);
            info.AddValue("postWrapMode", value.postWrapMode);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
            ISurrogateSelector selector)
        {
            var value = new AnimationCurve();
            var keyCount = info.GetInt32("keyCount");
            var keys = new Keyframe[keyCount];

            for (var i = 0; i < keyCount; i++)
            {
                var time = info.GetSingle($"key{i}_time");
                var valueProp = info.GetSingle($"key{i}_value");
                var inTangent = info.GetSingle($"key{i}_inTangent");
                var outTangent = info.GetSingle($"key{i}_outTangent");
                var inWeight = info.GetSingle($"key{i}_inWeight");
                var outWeight = info.GetSingle($"key{i}_outWeight");
                var weightedMode = (WeightedMode)info.GetValue($"key{i}_weightedMode", typeof(WeightedMode));

                keys[i] = new Keyframe(time, valueProp, inTangent, outTangent, inWeight, outWeight);
                keys[i].weightedMode = weightedMode;
            }

            value.keys = keys;
            value.preWrapMode = (WrapMode)info.GetValue("preWrapMode", typeof(WrapMode));
            value.postWrapMode = (WrapMode)info.GetValue("postWrapMode", typeof(WrapMode));

            obj = value;
            return obj;
        }
    }
}