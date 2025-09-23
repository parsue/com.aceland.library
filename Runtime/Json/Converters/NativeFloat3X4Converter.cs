using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeFloat3X4Converter : JsonConverter<float3x4>
    {
        public override void WriteJson(JsonWriter writer, float3x4 value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            for (var i = 0; i < 12; i++)
            {
                writer.WriteValue(value[i]);
            }
            writer.WriteEndArray();
        }

        public override float3x4 ReadJson(JsonReader reader, System.Type objectType, float3x4 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var matrix = new float3x4();
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