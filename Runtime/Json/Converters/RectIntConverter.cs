using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json.Converters
{
    public class RectIntConverter : JsonConverter<RectInt>
    {
        public override void WriteJson(JsonWriter writer, RectInt value, JsonSerializer serializer)
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

        public override RectInt ReadJson(JsonReader reader, System.Type objectType, RectInt existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            int x = 0, y = 0, width = 0, height = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "x": x = (int)(long)reader.Value; break;
                        case "y": y = (int)(long)reader.Value; break;
                        case "width": width = (int)(long)reader.Value; break;
                        case "height": height = (int)(long)reader.Value; break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new RectInt(x, y, width, height);
        }
    }
}