using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class BoundsIntConverter : JsonConverter<BoundsInt>
    {
        public override void WriteJson(JsonWriter writer, BoundsInt value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("position");
            serializer.Serialize(writer, value.position);
            writer.WritePropertyName("size");
            serializer.Serialize(writer, value.size);
            writer.WriteEndObject();
        }

        public override BoundsInt ReadJson(JsonReader reader, System.Type objectType, BoundsInt existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Vector3Int position = Vector3Int.zero;
            Vector3Int size = Vector3Int.zero;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "position":
                            position = serializer.Deserialize<Vector3Int>(reader);
                            break;
                        case "size":
                            size = serializer.Deserialize<Vector3Int>(reader);
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new BoundsInt(position, size);
        }
    }
}