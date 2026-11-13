using UnityEngine;

namespace AceLand.Library.Attribute
{
    public class HintBoxAttribute : PropertyAttribute
    {
        public HintBoxAttribute(string hint)
        {
            Hint = hint;
            MessageType = MessageType.Info;
            Position = HintBoxPosition.AfterTheField;
        }
        
        public HintBoxAttribute(string hint, MessageType messageType)
        {
            Hint = hint;
            MessageType = messageType is MessageType.None ? MessageType.Info : messageType;
            Position = HintBoxPosition.AfterTheField;
        }
        
        public HintBoxAttribute(string hint, HintBoxPosition position)
        {
            Hint = hint;
            MessageType = MessageType.Info;
            Position = position;
        }
        
        public HintBoxAttribute(string hint, MessageType messageType, HintBoxPosition position)
        {
            Hint = hint;
            MessageType = messageType is MessageType.None ? MessageType.Info : messageType;
            Position = position;
        }
        
        public string Hint { get; }
        public MessageType  MessageType { get; }
        public HintBoxPosition Position { get; }
    }
}