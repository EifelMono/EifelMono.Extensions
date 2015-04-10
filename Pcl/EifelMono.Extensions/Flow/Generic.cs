using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region In

        public static bool In<T>(this T value, IEnumerable<T> choices)
        {
            foreach (var choice in choices)
                if (choice.Equals(value))
                    return true;
            return false;
        }

        public static bool In<T>(this T value, params T[] choices)
        {
            return In(value, choices as  IEnumerable<T>);
        }

        public static bool In<T>(this IEnumerable<T> values, IEnumerable<T> choices)
        {
            foreach (var value in values)
                foreach (var choice in choices)
                    if (choice.Equals(value))
                        return true;
            return false;
        }

        public static bool In<T>(this IEnumerable<T> values, params T[] choices)
        {
            return In(values, choices as  IEnumerable<T>);
        }

        #endregion

        #region Out

        public static bool Out<T>(this T value, IEnumerable<T> choices)
        {
            return !In(value, choices);
        }

        public static bool Out<T>(this T value, params T[] choices)
        {
            return !In(value, choices);
        }

        public static bool Out<T>(this IEnumerable<T> values, IEnumerable<T> choices)
        {
            return !In(values, choices);
        }

        public static bool Out<T>(this IEnumerable<T> values, params T[] choices)
        {
            return !In(values, choices);
        }

        #endregion

        #region InRange

        public static bool InRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return value.CompareTo(minChoice) >= 0 && value.CompareTo(maxChoise) <= 0;
        }

        public static bool InRange<T>(this IEnumerable<T> values, T minChoice, T maxChoise) where T : IComparable
        {
            bool result = false;
            foreach (var value in values)
            {
                result = value.CompareTo(minChoice) >= 0 && value.CompareTo(maxChoise) <= 0;
                if (result)
                    return result;
            }
            return result;
        }

        #endregion

        #region OutRange

        public static bool OutRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return !InRange(value, minChoice, maxChoise);
        }

        public static bool OutRange<T>(this IEnumerable<T> values, T minChoice, T maxChoise) where T : IComparable
        {
            return !InRange(values, minChoice, maxChoise);
        }

        #endregion

        #region PositionOf

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

        public static int PositionOf<T>(this T value, params T[] compareValues)
        {
            return PositionOf(value, compareValues as IEnumerable<T>);
        }

        #endregion
    }
}

