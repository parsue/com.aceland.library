using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class BoundsIntSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (BoundsInt)obj;
            info.AddValue("position", value.position);
            info.AddValue("size", value.size);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (BoundsInt)obj;
            value.position = (Vector3Int)info.GetValue("position", typeof(Vector3Int));
            value.size = (Vector3Int)info.GetValue("size", typeof(Vector3Int));
            obj = value;
            return obj;
        }
    }
}