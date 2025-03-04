using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Hash128SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Hash128)obj;
            info.AddValue("hash", value.ToString());
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var hashString = (string)info.GetValue("hash", typeof(string));
            obj = Hash128.Parse(hashString);
            return obj;
        }
    }
}