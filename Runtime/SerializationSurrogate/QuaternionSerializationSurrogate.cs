using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class QuaternionSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Quaternion)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
            info.AddValue("z", value.z);
            info.AddValue("w", value.w);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Quaternion)obj;
            value.x = (float)info.GetValue("x", typeof(float));
            value.y = (float)info.GetValue("y", typeof(float));
            value.z = (float)info.GetValue("z", typeof(float));
            value.w = (float)info.GetValue("w", typeof(float));
            obj = value;
            return obj;
        }
    }
}