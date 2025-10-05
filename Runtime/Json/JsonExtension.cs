using System;
using AceLand.Library.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace AceLand.Library.Json
{
    public static class JsonExtension
    {
        public static JsonData ToJson<T>(this T data, bool withTypeName = false)
        {
            var settings = withTypeName ? ALib.JsonSerializerSettingsWithType : ALib.JsonSerializerSettings;
            var text = JsonConvert.SerializeObject(data, Formatting.None, settings);
            var builder = JsonData.Builder().WithText(text);
            return withTypeName
                ? builder.WithTypeName().Build()
                : builder.Build();
        }

        public static T ToData<T>(this JsonData jsonData)
        {
            var settings = jsonData.WithTypeName ? ALib.JsonSerializerSettingsWithType : ALib.JsonSerializerSettings;
            return JsonConvert.DeserializeObject<T>(jsonData.Text, settings);
        }
        
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
