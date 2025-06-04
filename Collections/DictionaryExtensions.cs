namespace MK.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                dictionary.Add(key, value = factory.Invoke());
            }

            return value;
        }
    }
}