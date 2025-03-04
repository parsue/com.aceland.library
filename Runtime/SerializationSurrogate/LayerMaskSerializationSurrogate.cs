using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class LayerMaskSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (LayerMask)obj;
            info.AddValue("value", value.value);
        }

        public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = (LayerMask)obj;
            value.value = (int)info.GetValue("value", typeof(int));
            obj = value;
            return obj;
        }
    }
}