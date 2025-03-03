using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AceLand.Library.SerializationSurrogate;
using UnityEngine;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static IFormatter GetBinaryFormatter()
        {
            const StreamingContextStates states = StreamingContextStates.All;
            
            var formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();
            var colorSurrogate = new ColorSerializationSurrogate();
            var quaternionSurrogate = new QuaternionSerializationSurrogate();
            var vector2Surrogate = new Vector2SerializationSurrogate();
            var vector2IntSurrogate = new Vector2IntSerializationSurrogate();
            var vector3Surrogate = new Vector3SerializationSurrogate();
            var vector3IntSurrogate = new Vector3IntSerializationSurrogate();
            var vector4Surrogate = new Vector4SerializationSurrogate();
            var matrix4X4Surrogate = new Matrix4x4SerializationSurrogate();
            var boundsSurrogate = new BoundsSerializationSurrogate();

            selector.AddSurrogate(typeof(Color), new StreamingContext(states), colorSurrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(states), quaternionSurrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(states), vector2Surrogate);
            selector.AddSurrogate(typeof(Vector2Int), new StreamingContext(states), vector2IntSurrogate);
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(states), vector3Surrogate);
            selector.AddSurrogate(typeof(Vector3Int), new StreamingContext(states), vector3IntSurrogate);
            selector.AddSurrogate(typeof(Vector4), new StreamingContext(states), vector4Surrogate);
            selector.AddSurrogate(typeof(Matrix4x4), new StreamingContext(states), matrix4X4Surrogate);
            selector.AddSurrogate(typeof(Bounds), new StreamingContext(states), boundsSurrogate);
            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}