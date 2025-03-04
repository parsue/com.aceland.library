using System.Runtime.Serialization;
using UnityEngine;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class GradientSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Gradient)obj;

            var colorKeys = value.colorKeys;
            var colorKeyCount = colorKeys.Length;
            info.AddValue("colorKeyCount", colorKeyCount);

            for (var i = 0; i < colorKeyCount; i++)
            {
                info.AddValue($"colorKey{i}_color", colorKeys[i].color);
                info.AddValue($"colorKey{i}_time", colorKeys[i].time);
            }

            var alphaKeys = value.alphaKeys;
            var alphaKeyCount = alphaKeys.Length;
            info.AddValue("alphaKeyCount", alphaKeyCount);

            for (var i = 0; i < alphaKeyCount; i++)
            {
                info.AddValue($"alphaKey{i}_alpha", alphaKeys[i].alpha);
                info.AddValue($"alphaKey{i}_time", alphaKeys[i].time);
            }

            info.AddValue("mode", value.mode);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
            ISurrogateSelector selector)
        {
            var gradient = new Gradient();
            var colorKeyCount = info.GetInt32("colorKeyCount");
            var colorKeys = new GradientColorKey[colorKeyCount];

            for (var i = 0; i < colorKeyCount; i++)
            {
                var color = (Color)info.GetValue($"colorKey{i}_color", typeof(Color));
                var time = info.GetSingle($"colorKey{i}_time");
                colorKeys[i] = new GradientColorKey(color, time);
            }

            var alphaKeyCount = info.GetInt32("alphaKeyCount");
            var alphaKeys = new GradientAlphaKey[alphaKeyCount];

            for (var i = 0; i < alphaKeyCount; i++)
            {
                var alpha = info.GetSingle($"alphaKey{i}_alpha");
                var time = info.GetSingle($"alphaKey{i}_time");
                alphaKeys[i] = new GradientAlphaKey(alpha, time);
            }

            gradient.SetKeys(colorKeys, alphaKeys);
            gradient.mode = (GradientMode)info.GetValue("mode", typeof(GradientMode));
            obj = gradient;
            return obj;
        }
    }
}