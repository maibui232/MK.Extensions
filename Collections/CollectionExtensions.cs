namespace MK.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionExtensions
    {
        public static T[] Sort<T>(this IEnumerable<T> sequence)
        {
            if (sequence is T[] array) return array;
            array = sequence.ToArray();
            Array.Sort(array);

            return array;
        }
        
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var element in sequence)
            {
                action(element);
            }
        }

        public static T Random<T>(this IEnumerable<T> sequence)
        {
            return sequence switch
                   {
                       ICollection<T> collection          => collection.Count  > 0 ? collection.ElementAt(NumericExtensions.Random(0,  collection.Count)) : throw new ArgumentException("Sequence has no element!"),
                       IReadOnlyCollection<T> collection1 => collection1.Count > 0 ? collection1.ElementAt(NumericExtensions.Random(0, collection1.Count)) : throw new ArgumentException("Sequence has no element!"),
                       _                                  => sequence.ToArray().Random()
                   };
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> sequence)
        {
            return sequence switch
                   {
                       ICollection<T> collection          => collection.Count  > 0 ? collection.ElementAt(NumericExtensions.Random(0,  collection.Count)) : default,
                       IReadOnlyCollection<T> collection1 => collection1.Count > 0 ? collection1.ElementAt(NumericExtensions.Random(0, collection1.Count)) : default,
                       _                                  => sequence.ToArray().RandomOrDefault()
                   };
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> sequence, T defaultElement)
        {
            return sequence switch
                   {
                       ICollection<T> collection          => collection.Count  > 0 ? collection.ElementAt(NumericExtensions.Random(0,  collection.Count)) : defaultElement,
                       IReadOnlyCollection<T> collection1 => collection1.Count > 0 ? collection1.ElementAt(NumericExtensions.Random(0, collection1.Count)) : defaultElement,
                       _                                  => sequence.ToArray().RandomOrDefault(defaultElement)
                   };
        }

        public static T Random<T>(this IEnumerable<T> sequence, Func<T, float> weightPointFunc)
        {
            var   enumerable         = sequence as T[] ?? sequence.ToArray();
            var   totalWeight        = enumerable.Sum(weightPointFunc);
            var   itemWeightIndex    = (float)new Random().NextDouble() * totalWeight;
            float currentWeightIndex = 0;

            foreach (var item in from weightedItem in enumerable select new { Value = weightedItem, Weight = weightPointFunc(weightedItem) })
            {
                currentWeightIndex += item.Weight;

                if (currentWeightIndex >= itemWeightIndex) return item.Value;
            }

            return default;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable) { return enumerable.OrderBy(e => new Guid()); }
    }
}