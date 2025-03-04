using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json.Converters
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            // Serialize the Color as an array of RGBA values
            writer.WriteStartObject();
            writer.WritePropertyName("r");
            writer.WriteValue(value.r);
            writer.WritePropertyName("g");
            writer.WriteValue(value.g);
            writer.WritePropertyName("b");
            writer.WriteValue(value.b);
            writer.WritePropertyName("a");
            writer.WriteValue(value.a);
            writer.WriteEndObject();
        }

        public override Color ReadJson(JsonReader reader, System.Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Deserialize the Color from an object with RGBA values
            float r = 0, g = 0, b = 0, a = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "r":
                            r = (float)(double)reader.Value;
                            break;
                        case "g":
                            g = (float)(double)reader.Value;
                            break;
                        case "b":
                            b = (float)(double)reader.Value;
                            break;
                        case "a":
                            a = (float)(double)reader.Value;
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new Color(r, g, b, a);
        }
    }
}