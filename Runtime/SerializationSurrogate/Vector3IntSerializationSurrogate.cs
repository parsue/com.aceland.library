using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Vector3IntSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Vector3Int)obj;
            info.AddValue("x", value.x);
            info.AddValue("y", value.y);
            info.AddValue("z", value.z);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Vector3Int)obj;
            value.x = (int)info.GetValue("x", typeof(int));
            value.y = (int)info.GetValue("y", typeof(int));
            value.z = (int)info.GetValue("z", typeof(int));
            obj = value;
            return obj;
        }
    }
}