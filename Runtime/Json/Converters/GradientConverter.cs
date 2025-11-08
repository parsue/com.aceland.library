using System;
using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json.Converters
{
    public class GradientConverter : JsonConverter<Gradient>
    {
        public override void WriteJson(JsonWriter writer, Gradient value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("colorKeys");
            writer.WriteStartArray();
            var colorKeys = value.colorKeys;
            foreach (var ck in colorKeys)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("time");
                writer.WriteValue(ck.time);

                writer.WritePropertyName("color");
                writer.WriteStartObject();
                writer.WritePropertyName("r");
                writer.WriteValue(ck.color.r);
                writer.WritePropertyName("g");
                writer.WriteValue(ck.color.g);
                writer.WritePropertyName("b");
                writer.WriteValue(ck.color.b);
                writer.WritePropertyName("a");
                writer.WriteValue(ck.color.a);
                writer.WriteEndObject(); // color

                writer.WriteEndObject(); // colorKey
            }
            writer.WriteEndArray();

            writer.WritePropertyName("alphaKeys");
            writer.WriteStartArray();
            var alphaKeys = value.alphaKeys;
            foreach (var ak in alphaKeys)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("time");
                writer.WriteValue(ak.time);

                writer.WritePropertyName("alpha");
                writer.WriteValue(ak.alpha);

                writer.WriteEndObject(); // alphaKey
            }
            writer.WriteEndArray();

#if UNITY_2022_1_OR_NEWER
            writer.WritePropertyName("mode");
            writer.WriteValue((int)value.mode);
#endif

            writer.WriteEndObject();
        }

        public override Gradient ReadJson(JsonReader reader, System.Type objectType, Gradient existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var gradient = new Gradient();
            GradientColorKey[] colorKeys = null;
            GradientAlphaKey[] alphaKeys = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "colorKeys":
                            var colorKeyList = new System.Collections.Generic.List<GradientColorKey>();
                            if (reader.TokenType == JsonToken.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                                {
                                    var time = 0f;
                                    float r = 0f, g = 0f, b = 0f, a = 0f;

                                    while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                                    {
                                        if (reader.TokenType == JsonToken.PropertyName)
                                        {
                                            var keyProp = (string)reader.Value;
                                            reader.Read();
                                            switch (keyProp)
                                            {
                                                case "time":
                                                    time = (float)(double)reader.Value;
                                                    break;
                                                case "color" when reader.TokenType == JsonToken.StartObject:
                                                {
                                                    // color object
                                                    while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                                                    {
                                                        if (reader.TokenType == JsonToken.PropertyName)
                                                        {
                                                            var cProp = (string)reader.Value;
                                                            reader.Read();
                                                            switch (cProp)
                                                            {
                                                                case "r": r = (float)(double)reader.Value; break;
                                                                case "g": g = (float)(double)reader.Value; break;
                                                                case "b": b = (float)(double)reader.Value; break;
                                                                case "a": a = (float)(double)reader.Value; break;
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    colorKeyList.Add(new GradientColorKey(new Color(r, g, b, a), time));
                                }
                            }
                            colorKeys = colorKeyList.ToArray();
                            break;

                        case "alphaKeys":
                            var alphaKeyList = new System.Collections.Generic.List<GradientAlphaKey>();
                            if (reader.TokenType == JsonToken.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                                {
                                    var time = 0f;
                                    var alpha = 0f;

                                    while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                                    {
                                        if (reader.TokenType != JsonToken.PropertyName) continue;
                                        
                                        var aProp = (string)reader.Value;
                                        reader.Read();
                                        switch (aProp)
                                        {
                                            case "time":
                                                time = (float)(double)reader.Value;
                                                break;
                                            case "alpha":
                                                alpha = (float)(double)reader.Value;
                                                break;
                                        }
                                    }

                                    alphaKeyList.Add(new GradientAlphaKey(alpha, time));
                                }
                            }
                            alphaKeys = alphaKeyList.ToArray();
                            break;

#if UNITY_2022_1_OR_NEWER
                        case "mode":
                            var modeInt = Convert.ToInt32(reader.Value);
                            gradient.mode = (GradientMode)modeInt;
                            break;
#endif
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            if (colorKeys != null && alphaKeys != null)
                gradient.SetKeys(colorKeys, alphaKeys);

            return gradient;
        }
    }
}