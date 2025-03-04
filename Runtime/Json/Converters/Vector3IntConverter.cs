using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json.Converters
{
    public class Vector3IntConverter : JsonConverter<Vector3Int>
    {
        public override void WriteJson(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);
            writer.WritePropertyName("z");
            writer.WriteValue(value.z);
            writer.WriteEndObject();
        }

        public override Vector3Int ReadJson(JsonReader reader, System.Type objectType, Vector3Int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            int x = 0, y = 0, z = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "x":
                            x = (int)(double)reader.Value;
                            break;
                        case "y":
                            y = (int)(double)reader.Value;
                            break;
                        case "z":
                            z = (int)(double)reader.Value;
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new Vector3Int(x, y, z);
        }
    }
}