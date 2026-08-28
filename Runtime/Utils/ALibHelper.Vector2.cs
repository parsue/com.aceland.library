using System;
using UnityEngine;

namespace AceLand.Library.Utils
{
    public partial class ALibHelper
    {
        public Vector2 GetRotateAxis(TransformDirection2D transformDirection) =>
            transformDirection switch
            {
                TransformDirection2D.Left => Vector2.left,
                TransformDirection2D.Right => Vector2.right,
                TransformDirection2D.Up => Vector2.up,
                TransformDirection2D.Down => Vector2.down,
                _ => throw new ArgumentOutOfRangeException()
            };

        public Vector2 SmoothDirection(Vector2 normal, Vector2 inDirection)
        {
            var p = Vector2.Perpendicular(inDirection);
            var d = Vector2.Dot(p, inDirection);
            return d >= 0 ? p : -p;
        }
    }
}