using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AceLand.Library.SerializationSurrogate;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static T DeepClone<T>(this T obj)
        {
            if (typeof(T).IsValueType)
                return obj;

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            using var memoryStream = new MemoryStream();
            var formatter = GetBinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(memoryStream);
        }

        private static IFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new();
            SurrogateSelector selector = new();
            ColorSerializationSurrogate colorSurrogate = new();
            QuaternionSerializationSurrogate quaternionSurrogate = new();
            Vector2SerializationSurrogate vector2Surrogate = new();
            Vector2IntSerializationSurrogate vector2IntSurrogate = new();
            Vector3SerializationSurrogate vector3Surrogate = new();
            Vector3IntSerializationSurrogate vector3IntSurrogate = new();
            Vector4SerializationSurrogate vector4Surrogate = new();

            selector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colorSurrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSurrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2Surrogate);
            selector.AddSurrogate(typeof(Vector2Int), new StreamingContext(StreamingContextStates.All), vector2IntSurrogate);
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
            selector.AddSurrogate(typeof(Vector3Int), new StreamingContext(StreamingContextStates.All), vector3IntSurrogate);
            selector.AddSurrogate(typeof(Vector4), new StreamingContext(StreamingContextStates.All), vector4Surrogate);
            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}