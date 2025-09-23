using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeFloat3Converter : JsonConverter<float3>
    {
        public override void WriteJson(JsonWriter writer, float3 value, JsonSerializer serializer)
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

        public override float3 ReadJson(JsonReader reader, System.Type objectType, float3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            float x = 0, y = 0, z = 0;

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
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            return new float3(x, y, z);
        }
    }
}