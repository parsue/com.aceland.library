using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class Hash128Converter : JsonConverter<Hash128>
    {
        public override void WriteJson(JsonWriter writer, Hash128 value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override Hash128 ReadJson(JsonReader reader, System.Type objectType, Hash128 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Hash128.Parse((string)reader.Value);
        }
    }
}