using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Matrix4x4SerializationSurrogate : ISerializationSurrogate
    {
        private readonly string[] keys = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Matrix4x4)obj;
            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                info.AddValue(key, value[i]);
            }
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (Matrix4x4)obj;
            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                value[i] = (float)info.GetValue(key, typeof(Matrix4x4));
            }
            obj = value;
            return obj;
        }
    }
}