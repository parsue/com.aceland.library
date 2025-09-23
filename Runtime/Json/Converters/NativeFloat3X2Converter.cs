using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeFloat3X2Converter : JsonConverter<float3x2>
    {
        public override void WriteJson(JsonWriter writer, float3x2 value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            for (var i = 0; i < 6; i++)
            {
                writer.WriteValue(value[i]);
            }
            writer.WriteEndArray();
        }

        public override float3x2 ReadJson(JsonReader reader, System.Type objectType, float3x2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var matrix = new float3x2();
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