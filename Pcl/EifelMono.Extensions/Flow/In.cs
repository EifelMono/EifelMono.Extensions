using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region In

        public static bool In<T>(this T value, params T[] items) where T : IComparable
        {
            foreach (var item in items)
                if (item.Equals(value))
                    return true;
            return false;
        }

        public static bool In<T>(this T value, IEnumerable<T> items) where T : IComparable
        {
            foreach (var item in items)
                if (item.Equals(value))
                    return true;
            return false;
        }

        #endregion

        #region InRange

        public static bool InRange<T>(this T value, T minValue, T maxValue) where T : IComparable
        {
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }

        #endregion
    }
}

