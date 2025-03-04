using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class RectIntSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (RectInt)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
            info.AddValue("width", value.width);
            info.AddValue("height", value.height);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (RectInt)obj;
            value.x = (int)info.GetValue("x", typeof(int));
            value.y = (int)info.GetValue("y", typeof(int));
            value.width = (int)info.GetValue("width", typeof(int));
            value.height = (int)info.GetValue("height", typeof(int));
            obj = value;
            return obj;
        }
    }
}