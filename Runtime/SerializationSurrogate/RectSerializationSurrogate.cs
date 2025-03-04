using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class RectSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Rect)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
            info.AddValue("width", value.width);
            info.AddValue("height", value.height);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Rect)obj;
            value.x = (float)info.GetValue("x", typeof(float));
            value.y = (float)info.GetValue("y", typeof(float));
            value.width = (float)info.GetValue("width", typeof(float));
            value.height = (float)info.GetValue("height", typeof(float));
            obj = value;
            return obj;
        }
    }
}