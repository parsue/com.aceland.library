using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeFloat4X3Converter : JsonConverter<float4x3>
    {
        public override void WriteJson(JsonWriter writer, float4x3 value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            for (var i = 0; i < 12; i++)
            {
                writer.WriteValue(value[i]);
            }
            writer.WriteEndArray();
        }

        public override float4x3 ReadJson(JsonReader reader, System.Type objectType, float4x3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var matrix = new float4x3();
            var index = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
                {
                    matrix[index] = (float)(double)reader.Value;
                    index++;
                }
                else if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }
            }

            return matrix;
        }
    }
}