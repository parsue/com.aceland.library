using System;
using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class AnimationCurveConverter : JsonConverter<AnimationCurve>
    {
        public override void WriteJson(JsonWriter writer, AnimationCurve value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keys");
            serializer.Serialize(writer, value.keys);
            writer.WritePropertyName("preWrapMode");
            writer.WriteValue(value.preWrapMode.ToString());
            writer.WritePropertyName("postWrapMode");
            writer.WriteValue(value.postWrapMode.ToString());
            writer.WriteEndObject();
        }

        public override AnimationCurve ReadJson(JsonReader reader, Type objectType, AnimationCurve existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Keyframe[] keys = null;
            WrapMode preWrapMode = WrapMode.Default;
            WrapMode postWrapMode = WrapMode.Default;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "keys":
                            keys = serializer.Deserialize<Keyframe[]>(reader);
                            break;
                        case "preWrapMode":
                            preWrapMode = (WrapMode)Enum.Parse(typeof(WrapMode), (string)reader.Value);
                            break;
                        case "postWrapMode":
                            postWrapMode = (WrapMode)Enum.Parse(typeof(WrapMode), (string)reader.Value);
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new AnimationCurve(keys) { preWrapMode = preWrapMode, postWrapMode = postWrapMode };
        }
    }
}