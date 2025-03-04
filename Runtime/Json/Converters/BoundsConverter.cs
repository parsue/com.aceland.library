using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class BoundsConverter : JsonConverter<Bounds>
    {
        public override void WriteJson(JsonWriter writer, Bounds value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("center");
            serializer.Serialize(writer, value.center);
            writer.WritePropertyName("size");
            serializer.Serialize(writer, value.size);
            writer.WriteEndObject();
        }

        public override Bounds ReadJson(JsonReader reader, System.Type objectType, Bounds existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var center = Vector3.zero;
            var size = Vector3.zero;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "center":
                            center = serializer.Deserialize<Vector3>(reader);
                            break;
                        case "size":
                            size = serializer.Deserialize<Vector3>(reader);
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new Bounds(center, size);
        }
    }
}