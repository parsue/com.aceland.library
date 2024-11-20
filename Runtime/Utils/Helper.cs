using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AceLand.Library.SerializationSurrogate;
using UnityEngine;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static BinaryFormatter GetBinaryFormatter()
        {
            var formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), new Vector2SerializationSurrogate());
            selector.AddSurrogate(typeof(Vector2Int), new StreamingContext(StreamingContextStates.All), new Vector2IntSerializationSurrogate());
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), new Vector3SerializationSurrogate());
            selector.AddSurrogate(typeof(Vector3Int), new StreamingContext(StreamingContextStates.All), new Vector3IntSerializationSurrogate());
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), new QuaternionSerializationSurrogate());
            selector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), new ColorSerializationSurrogate());
            formatter.SurrogateSelector = selector;
            return formatter;
        }
    }
}