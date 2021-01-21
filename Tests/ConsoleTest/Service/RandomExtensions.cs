using System;
using System.Collections.Generic;

namespace ConsoleTest.Service
{
    internal static class RandomExtensions
    {
        public static List<int> GetValues(this Random rnd, int Count, int Min, int Max)
        {
            var result = new List<int>(Count);

            for(var i = 0; i < Count; i++)
                result.Add(rnd.Next(Min, Max));

            return result;
        }

        public static T GetValue<T>(this Random rnd, params T[] items)
        {
            return items[rnd.Next(0, items.Length)];
        }
    }
}
