using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library.Json
{
    public class GradientConverter : JsonConverter<Gradient>
    {
        public override void WriteJson(JsonWriter writer, Gradient value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("colorKeys");
            serializer.Serialize(writer, value.colorKeys);
            writer.WritePropertyName("alphaKeys");
            serializer.Serialize(writer, value.alphaKeys);
            writer.WriteEndObject();
        }

        public override Gradient ReadJson(JsonReader reader, System.Type objectType, Gradient existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = null;
            GradientAlphaKey[] alphaKeys = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = (string)reader.Value;
                    reader.Read();
                    switch (propertyName)
                    {
                        case "colorKeys":
                            colorKeys = serializer.Deserialize<GradientColorKey[]>(reader);
                            break;
                        case "alphaKeys":
                            alphaKeys = serializer.Deserialize<GradientAlphaKey[]>(reader);
                            break;
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }
            }

            if (colorKeys != null && alphaKeys != null)
            {
                gradient.SetKeys(colorKeys, alphaKeys);
            }

            return gradient;
        }
    }
}