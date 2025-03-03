using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class BoundsSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Bounds)obj;
            info.AddValue("center", value.center);
            info.AddValue("size", value.size);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Bounds)obj;
            value.center = (Vector3)info.GetValue("center", typeof(Vector3));
            value.size = (Vector3)info.GetValue("size", typeof(Vector3));
            obj = value;
            return obj;
        }
    }
}