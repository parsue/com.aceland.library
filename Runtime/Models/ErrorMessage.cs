using System.Collections.Generic;

namespace AceLand.Library.Models
{
    public class ErrorMessage
    {
        private ErrorMessage((string key, string msg)[] msgs)
        {
            foreach (var (key, msg) in msgs)
            {
                Add(key, msg);
            }
        }

        public static ErrorMessageBuilder Builder() => new();
        public class ErrorMessageBuilder
        {
            private readonly List<(string key, string msg)> _msgs = new();

            public ErrorMessage Build() => new(_msgs.ToArray());
            
            public ErrorMessageBuilder WithMessage(string key, string msg)
            {
                _msgs.Add((key, msg));
                return this;
            }
        }
        
        private readonly Dictionary<string, string> _errors = new();

        public IEnumerable<KeyValuePair<string, string>> Errors => _errors;
        public void Add(string key, string value) => _errors[key] = value;
        public bool TryGetMessage(string key, out string message) => _errors.TryGetValue(key, out message);
        public bool HasMessage(string key) => _errors.ContainsKey(key);
        public int Count => _errors.Count;
        public string Messages => GetAllMsg();
        public override string ToString() => Messages;

        private string GetAllMsg()
        {
            var msg = string.Empty;
            foreach (var item in _errors)
            {
                msg += item.Key + " - " + item.Value + "\n";
            }
            msg = msg.TrimEnd('\n');
            return msg;
        }
    }
}