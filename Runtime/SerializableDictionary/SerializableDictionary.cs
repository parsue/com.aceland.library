using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AceLand.Library.SerializableDictionaryModel
{
	public static class SerializableDictionary
	{
		public class Storage<T> : SerializableDictionaryBase.Storage
		{
			public T data;
		}
	}

	[Serializable]
	public class SerializableDictionary<TKey, TValue> : SerializableDictionaryBase<TKey, TValue, TValue>
	{
		public SerializableDictionary() { }
		public SerializableDictionary(IDictionary<TKey, TValue> dict) : base(dict) { }
		protected SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

		protected override TValue GetValue(TValue[] storage, int i)
		{
			return storage[i];
		}

		protected override void SetValue(TValue[] storage, int i, TValue value)
		{
			storage[i] = value;
		}
	}

	[Serializable]
	public class SerializableDictionary<TKey, TValue, TValueStorage> : SerializableDictionaryBase<TKey, TValue, TValueStorage> where TValueStorage : SerializableDictionary.Storage<TValue>, new()
	{
		public SerializableDictionary() { }
		public SerializableDictionary(IDictionary<TKey, TValue> dict) : base(dict) { }
		protected SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

		protected override TValue GetValue(TValueStorage[] storage, int i)
		{
			return storage[i].data;
		}

		protected override void SetValue(TValueStorage[] storage, int i, TValue value)
		{
			storage[i] = new TValueStorage();
			storage[i].data = value;
		}
	}
}
