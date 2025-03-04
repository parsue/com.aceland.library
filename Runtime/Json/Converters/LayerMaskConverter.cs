using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class LayerMaskConverter : JsonConverter<LayerMask>
    {
        public override void WriteJson(JsonWriter writer, LayerMask value, JsonSerializer serializer)
        {
            writer.WriteValue(value.value);
        }

        public override LayerMask ReadJson(JsonReader reader, System.Type objectType, LayerMask existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new LayerMask { value = (int)(long)reader.Value };
        }
    }
}