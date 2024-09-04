using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Vector3SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Vector3)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
            info.AddValue("z", value.z);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Vector3)obj;
            value.x = (float)info.GetValue("x", typeof(float));
            value.y = (float)info.GetValue("y", typeof(float));
            value.z = (float)info.GetValue("z", typeof(float));
            obj = value;
            return obj;
        }
    }
}