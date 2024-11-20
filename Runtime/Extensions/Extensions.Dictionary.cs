using System.Collections.Generic;
using UnityEngine;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool TryGetFirstKeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue val, out TKey key)
        {
            foreach (var pair in dict)
            {
                if (!EqualityComparer<TValue>.Default.Equals(pair.Value, val)) continue;
                key = pair.Key;
                return true;
            }
            key = default;
            return false;
        }

        public static TKey GetKeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue val, TKey defaultValue)
        {
            return TryGetFirstKeyByValue(dict, val, out var key) ? key : defaultValue;
        }

        public static IEnumerable<T> GetKeysByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            foreach (var pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    yield return pair.Key;
                }
            }
        }
        
        public static void SwapValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key1, TKey key2)
        {
            if (!dictionary.ContainsKey(key1) || !dictionary.ContainsKey(key2))
            {
                Debug.LogWarning("One or both keys do not exist in the dictionary.");
                return;
            }

            var value1 = dictionary[key1];
            var value2 = dictionary[key2];

            dictionary[key1] = value2;
            dictionary[key2] = value1;
        }
    }
}