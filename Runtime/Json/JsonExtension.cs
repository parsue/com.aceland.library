using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        
        private static readonly JsonSerializerSettings JSON_SERIALIZER_SETTINGS_WITH_TYPE = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = new List<JsonConverter>()
        };

        public static string ToJson<T>(this T data, bool withTypeName = false)
        {
            var settings = withTypeName ? JSON_SERIALIZER_SETTINGS_WITH_TYPE : JSON_SERIALIZER_SETTINGS;
            return JsonConvert.SerializeObject(data, Formatting.None, settings);
        }

        public static T ToData<T>(this string json, bool withTypeName = false)
        {
            var settings = withTypeName ? JSON_SERIALIZER_SETTINGS_WITH_TYPE : JSON_SERIALIZER_SETTINGS;
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static Task<string> ToJsonAsync<T>(this T data, CancellationToken token, bool withTypeName = false)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var settings = withTypeName ? JSON_SERIALIZER_SETTINGS_WITH_TYPE : JSON_SERIALIZER_SETTINGS;
                    var json = JsonConvert.SerializeObject(data, Formatting.None, settings);
                    return json;
                }
                catch (Exception e)
                {
                    if (token.IsCancellationRequested) return null;
                    throw new Exception($"Serialize {typeof(T).Name} to json error\n{e}");
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public static Task<T> ToDataAsync<T>(this string json, CancellationToken token, bool withTypeName = false)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    var settings = withTypeName ? JSON_SERIALIZER_SETTINGS_WITH_TYPE : JSON_SERIALIZER_SETTINGS;
                    var data = JsonConvert.DeserializeObject<T>(json, settings);
                    return data;
                }
                catch (Exception e)
                {
                    throw new Exception($"Deserialize json to {typeof(T).Name} error\n{e}");
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public static Task<T> ToDataAsync<T>(this TextAsset json, CancellationToken token) =>
            ToDataAsync<T>(json.text, token);
        
        public static bool IsValidJson(this string json)
        {
            if (json == null) return false;
            if (json.Trim() == string.Empty) return true; 
            
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool IsValidJson(this TextAsset json)
        {
            return IsValidJson(json.text);
        }
    }
}
