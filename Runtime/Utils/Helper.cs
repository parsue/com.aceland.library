using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AceLand.Library.SerializationSurrogate;
using UnityEngine;

namespace AceLand.Library.Utils
{
    public sealed partial class Helper
    {
        internal Helper() { }
        
        public IFormatter GetBinaryFormatter()
        {
            const StreamingContextStates states = StreamingContextStates.All;
            
            var formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();
            var animationCurveSurrogate = new AnimationCurveSerializationSurrogate();
            var boundsIntSurrogate = new BoundsIntSerializationSurrogate();
            var boundsSurrogate = new BoundsSerializationSurrogate();
            var colorSurrogate = new ColorSerializationSurrogate();
            var gradientSurrogate = new GradientSerializationSurrogate();
            var hash128Surrogate = new Hash128SerializationSurrogate();
            var layerMaskSurrogate = new LayerMaskSerializationSurrogate();
            var matrix4X4Surrogate = new Matrix4x4SerializationSurrogate();
            var quaternionSurrogate = new QuaternionSerializationSurrogate();
            var rectIntSurrogate = new RectIntSerializationSurrogate();
            var rectSurrogate = new RectSerializationSurrogate();
            var vector2Surrogate = new Vector2SerializationSurrogate();
            var vector2IntSurrogate = new Vector2IntSerializationSurrogate();
            var vector3Surrogate = new Vector3SerializationSurrogate();
            var vector3IntSurrogate = new Vector3IntSerializationSurrogate();
            var vector4Surrogate = new Vector4SerializationSurrogate();

            selector.AddSurrogate(typeof(AnimationCurve), new StreamingContext(states), animationCurveSurrogate);
            selector.AddSurrogate(typeof(BoundsInt), new StreamingContext(states), boundsIntSurrogate);
            selector.AddSurrogate(typeof(Bounds), new StreamingContext(states), boundsSurrogate);
            selector.AddSurrogate(typeof(Color), new StreamingContext(states), colorSurrogate);
            selector.AddSurrogate(typeof(Gradient), new StreamingContext(states), gradientSurrogate);
            selector.AddSurrogate(typeof(Hash128), new StreamingContext(states), hash128Surrogate);
            selector.AddSurrogate(typeof(LayerMask), new StreamingContext(states), layerMaskSurrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(states), quaternionSurrogate);
            selector.AddSurrogate(typeof(RectInt), new StreamingContext(states), rectIntSurrogate);
            selector.AddSurrogate(typeof(Rect), new StreamingContext(states), rectSurrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(states), vector2Surrogate);
            selector.AddSurrogate(typeof(Vector2Int), new StreamingContext(states), vector2IntSurrogate);
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(states), vector3Surrogate);
            selector.AddSurrogate(typeof(Vector3Int), new StreamingContext(states), vector3IntSurrogate);
            selector.AddSurrogate(typeof(Vector4), new StreamingContext(states), vector4Surrogate);
            selector.AddSurrogate(typeof(Matrix4x4), new StreamingContext(states), matrix4X4Surrogate);
            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}