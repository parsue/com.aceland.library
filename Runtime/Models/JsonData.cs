using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace AceLand.Library.Models
{
    public sealed class JsonData
    {
        public static IJsonDataContentBuilder Builder() => new JsonDataBuilder();
        
        private JsonData(JContainer container, bool withTypeName)
        {
            var settings = withTypeName ? ALib.JsonSerializerSettingsWithType : ALib.JsonSerializerSettings;
            Container = container;
            Text = JsonConvert.SerializeObject(container, Formatting.None, settings);
            WithTypeName = withTypeName;
        }
        
        private JsonData(string text, bool withTypeName)
        {
            Text = text;
            Container = JsonConvert.DeserializeObject<JContainer>(text);
            WithTypeName = withTypeName;
        }
        
        public JContainer Container { get; }
        public string Text { get; }
        public bool WithTypeName { get; }
        
        // builder

        public interface IJsonDataContentBuilder
        {
            IJsonDataBuilder WithJContainer(JContainer container);
            IJsonDataBuilder WithText(string text);
            IJsonDataBuilder WithText(TextAsset textAsset);
        }

        public interface IJsonDataBuilder
        {
            IJsonDataBuilder WithTypeName();
            JsonData Build();
        }

        private class JsonDataBuilder : IJsonDataContentBuilder, IJsonDataBuilder
        {
            private JContainer _container = null;
            private string _text = null;
            private bool _withTypeName = false;

            public JsonData Build()
            {
                if (_container != null) return new JsonData(_container, _withTypeName);
                if (_text != null) return new JsonData(_text, _withTypeName);
                
                Debug.LogError("JsonDataBuilder.Build: No container or text set");
                return null;
            }
            
            public IJsonDataBuilder WithJContainer(JContainer container)
            {
                _container = container;
                return this;
            }

            public IJsonDataBuilder WithText(string text)
            {
                _text = text;
                return this;
            }

            public IJsonDataBuilder WithText(TextAsset textAsset)
            {
                _text = textAsset.text;
                return this;
            }

            public IJsonDataBuilder WithTypeName()
            {
                _withTypeName = true;
                return this;
            }
        }
    }
}