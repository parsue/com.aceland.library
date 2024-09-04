using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class ColorSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Color)obj;
            info.AddValue("r", value.r);
            info.AddValue("g", value.g);
            info.AddValue("b", value.b);
            info.AddValue("a", value.a);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Color)obj;
            value.r = (float)info.GetValue("r", typeof(float));
            value.g = (float)info.GetValue("g", typeof(float));
            value.b = (float)info.GetValue("b", typeof(float));
            value.a = (float)info.GetValue("a", typeof(float));
            obj = value;
            return obj;
        }
    }
}