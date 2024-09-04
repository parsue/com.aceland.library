using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Vector2SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Vector2)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Vector2)obj;
            value.x = (float)info.GetValue("x", typeof(float));
            value.y = (float)info.GetValue("y", typeof(float));
            obj = value;
            return obj;
        }
    }
}