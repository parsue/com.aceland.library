using System.Runtime.Serialization;
using UnityEngine;
using Object = System.Object;

namespace AceLand.Library.SerializationSurrogate
{
    public sealed class Matrix4x4SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var value = (Matrix4x4)obj;
            info.AddValue("m00", value.m00);
            info.AddValue("m01", value.m01);
            info.AddValue("m02", value.m02);
            info.AddValue("m03", value.m03);
            info.AddValue("m10", value.m10);
            info.AddValue("m11", value.m11);
            info.AddValue("m12", value.m12);
            info.AddValue("m13", value.m13);
            info.AddValue("m20", value.m20);
            info.AddValue("m21", value.m21);
            info.AddValue("m22", value.m22);
            info.AddValue("m23", value.m23);
            info.AddValue("m30", value.m30);
            info.AddValue("m31", value.m31);
            info.AddValue("m32", value.m32);
            info.AddValue("m33", value.m33);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var value = new Matrix4x4();
            value.m00 = info.GetSingle("m00");
            value.m01 = info.GetSingle("m01");
            value.m02 = info.GetSingle("m02");
            value.m03 = info.GetSingle("m03");
            value.m10 = info.GetSingle("m10");
            value.m11 = info.GetSingle("m11");
            value.m12 = info.GetSingle("m12");
            value.m13 = info.GetSingle("m13");
            value.m20 = info.GetSingle("m20");
            value.m21 = info.GetSingle("m21");
            value.m22 = info.GetSingle("m22");
            value.m23 = info.GetSingle("m23");
            value.m30 = info.GetSingle("m30");
            value.m31 = info.GetSingle("m31");
            value.m32 = info.GetSingle("m32");
            value.m33 = info.GetSingle("m33");

            obj = value;
            return obj;
        }
    }
}