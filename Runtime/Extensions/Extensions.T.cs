using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AceLand.Library.SerializationSurrogate;
using AceLand.Library.Utils;
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
            var formatter = Helper.GetBinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(memoryStream);
        }
    }
}