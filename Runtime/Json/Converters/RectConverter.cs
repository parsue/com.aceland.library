using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json.Converters
{
    public class RectConverter : JsonConverter<Rect>
    {
        public override void WriteJson(JsonWriter writer, Rect value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);
            writer.WritePropertyName("width");
            writer.WriteValue(value.width);
            writer.WritePropertyName("height");
            writer.WriteValue(value.height);
            writer.WriteEndObject();
        }

        public override Rect ReadJson(JsonReader reader, System.Type objectType, Rect existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            float x = 0, y = 0, width = 0, height = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "x": x = (float)(double)reader.Value; break;
                        case "y": y = (float)(double)reader.Value; break;
                        case "width": width = (float)(double)reader.Value; break;
                        case "height": height = (float)(double)reader.Value; break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new Rect(x, y, width, height);
        }
    }
}