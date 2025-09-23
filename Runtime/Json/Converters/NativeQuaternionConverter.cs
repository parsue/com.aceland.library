using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeQuaternionConverter : JsonConverter<quaternion>
    {
        public override void WriteJson(JsonWriter writer, quaternion value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(value.value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.value.y);
            writer.WritePropertyName("z");
            writer.WriteValue(value.value.z);
            writer.WritePropertyName("w");
            writer.WriteValue(value.value.w);
            writer.WriteEndObject();
        }

        public override quaternion ReadJson(JsonReader reader, System.Type objectType, quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            float x = 0, y = 0, z = 0, w = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "x":
                            x = (float)(double)reader.Value;
                            break;
                        case "y":
                            y = (float)(double)reader.Value;
                            break;
                        case "z":
                            z = (float)(double)reader.Value;
                            break;
                        case "w":
                            w = (float)(double)reader.Value;
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new quaternion(x, y, z, w);
        }
    }
}