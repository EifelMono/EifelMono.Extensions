using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region In

        /// <summary>
        /// Returns true if the value is in items or false if not found.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="items">Items</param>
        /// <typeparam name="T">T must have the IComparable interface</typeparam>
        public static bool In<T>(this T value, params T[] items) where T : IComparable
        {
            foreach (var item in items)
                if (item.Equals(value))
                    return true;
            return false;
        }

        /// <summary>
        /// Returns true if the value is in items or false if not found.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="items">Items</param>
        /// <typeparam name="T">T must have the IComparable interface</typeparam>
        public static bool In<T>(this T value, IEnumerable<T> items) where T : IComparable
        {
            foreach (var item in items)
                if (item.Equals(value))
                    return true;
            return false;
        }

        #endregion

        #region InRange

        /// <summary>
        /// Ins the range.
        /// </summary>
        /// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
        /// <param name="value">Value.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool InRange<T>(this T value, T minValue, T maxValue) where T : IComparable
        {
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }

        #endregion
    }
}

