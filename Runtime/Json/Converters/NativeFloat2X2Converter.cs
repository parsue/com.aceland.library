using Newtonsoft.Json;
using Unity.Mathematics;

namespace AceLand.Library.Json.Converters
{
    public class NativeFloat2X2Converter : JsonConverter<float2x2>
    {
        public override void WriteJson(JsonWriter writer, float2x2 value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            for (var i = 0; i < 4; i++)
            {
                writer.WriteValue(value[i]);
            }
            writer.WriteEndArray();
        }

        public override float2x2 ReadJson(JsonReader reader, System.Type objectType, float2x2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var matrix = new float2x2();
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