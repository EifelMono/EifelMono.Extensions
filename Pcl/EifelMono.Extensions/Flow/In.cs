using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region In

        public static bool In<T>(this T value, params T[] choices) 
        {
            foreach (var choice in choices)
                if (choice.Equals(value))
                    return true;
            return false;
        }

        public static bool In<T>(this T value, IEnumerable<T> choices) 
        {
            foreach (var choice in choices)
                if (choice.Equals(value))
                    return true;
            return false;
        }
      
        #endregion

        #region Out

        public static bool Out<T>(this T value, params T[] choices) 
        {
            return !In(value, choices);
        }

        public static bool Out<T>(this T value, IEnumerable<T> choices) 
        {
            return !In(value, choices);
        }

        #endregion

        #region Range

        public static bool InRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return value.CompareTo(minChoice) >= 0 && value.CompareTo(maxChoise) <= 0;
        }

        public static bool OutRange<T>(this T value, T minChoice, T maxChoise) where T : IComparable
        {
            return !InRange(value, minChoice, maxChoise);
        }

        #endregion
    }
}

