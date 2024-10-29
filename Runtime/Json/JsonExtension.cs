using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerSettings JSON_SERIALIZER_SETTINGS = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = new List<JsonConverter>()
        };

        public static Task<string> ToJson<T>(this T data, CancellationToken token)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var json = JsonConvert.SerializeObject(data, Formatting.None, JSON_SERIALIZER_SETTINGS);
                    return json;
                }
                catch (Exception e)
                {
                    if (token.IsCancellationRequested) return null;
                    throw new Exception($"Serialize {typeof(T).Name} to json error\n{e}");
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public static Task<T> ToData<T>(this string json, CancellationToken token)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var data = JsonConvert.DeserializeObject<T>(json, JSON_SERIALIZER_SETTINGS);
                    return data;
                }
                catch (Exception e)
                {
                    throw new Exception($"Deserialize json to {typeof(T).Name} error\n{e}");
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public static Task<T> ToData<T>(this TextAsset json, CancellationToken token) =>
            ToData<T>(json.text, token);
    }
}
