using System;
using UnityEngine;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        public static Vector3 GetRotateAxis(TransformDirection transformDirection)
        {
            return transformDirection switch
            {
                TransformDirection.Left => Vector3.left,
                TransformDirection.Right => Vector3.right,
                TransformDirection.Up => Vector3.up,
                TransformDirection.Down => Vector3.down,
                TransformDirection.Forward => Vector3.forward,
                TransformDirection.Back => Vector3.back,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static Vector3 SmoothDirection(Vector3 normal, Vector3 inDirection)
        {
            var v3 = Vector3.Cross(normal, inDirection);
            v3 = Vector3.Cross(v3, normal);
            return v3;
        }
    }
}