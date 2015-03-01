using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region Position

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="items">Items.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static int PositionOf<T>(this T value, params T[] compareValues)
        {
            int index = -1;
            foreach (var compareValue in compareValues)
            {
                index++;
                if (compareValue.Equals(value))
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Position the specified value and items.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="items">Items.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static int PositionOf<T>(this T value, IEnumerable<T> compareValues)
        {
            int index = -1;
            foreach (var compareValue in compareValues)
            {
                index++;
                if (compareValue.Equals(value))
                    return index;
            }
            return -1;
        }

        #endregion

    }
}

