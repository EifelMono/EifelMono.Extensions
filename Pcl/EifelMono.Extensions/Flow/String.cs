using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region ...

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        #endregion

        #region InContains

        public static bool InContains(this string value, IEnumerable<string> choices)
        {
            foreach (var choice in choices)
                if (value.Contains(choice))
                    return true;
            return false;
        }

        public static bool InContains(this string value, params string[] choices)
        {
            return InContains(value, choices as IEnumerable<string>);
        }

        public static bool InContains(this IEnumerable<string> values, IEnumerable<string> choices)
        {
            foreach (var value in values)
                if (value.InContains(choices))
                    return true;
            return false;
        }

        public static bool InContains(this IEnumerable<string> values, params string[] choices)
        {
            return InContains(values, choices as IEnumerable<string>);
        }

        #endregion

        #region InStartsWith

        public static bool InStartsWith(this string value, IEnumerable<string>  choices)
        {
            foreach (string choice in choices)
                if (value.StartsWith(choice))
                    return true;
            return false;
        }

        public static bool InStartsWith(this string value, params string[] choices)
        {
            return InStartsWith(value, choices as IEnumerable<string>);
        }

        public static bool InStartsWith(this IEnumerable<string> values, IEnumerable<string> choices)
        {
            foreach (var value in values)
                if (value.InStartsWith(choices))
                    return true;
            return false;
        }

        public static bool InStartsWith(this IEnumerable<string> values, params string[] choices)
        {
            return InStartsWith(values, choices  as IEnumerable<string>);
        }

        #endregion

        #region InEndsWith

        public static bool InEndsWith(this string value, IEnumerable<string> choices)
        {
            foreach (var choice in choices)
                if (value.EndsWith(choice))
                    return true;
            return false;
        }

        public static bool InEndsWith(this string value, params string[] choices)
        {
            return InEndsWith(value, choices as IEnumerable<string>);
        }

        public static bool InEndsWith(this IEnumerable<string> values, IEnumerable<string> choices)
        {
            foreach (var value in values)
                if (value.InEndsWith(choices))
                    return true;
            return false;
        }

        public static bool InEndsWith(this IEnumerable<string> values, params string[] choices)
        {
            return InEndsWith(values, choices as IEnumerable<string>);
        }

        #endregion

        #region InLength

        public static bool InLength(this string value, IEnumerable<int> choices)
        {
            foreach (var choice in choices)
                if (value.Length == choice)
                    return true;
            return false;
        }

        public static bool InLength(this string value, params int[] choices)
        {
            return InLength(value, choices as IEnumerable<int>);
        }

        public static bool InLength(this IEnumerable<string> values, IEnumerable<int> choices)
        {
            foreach (var value in values)
                if (value.InLength(choices))
                    return true;
            return false;
        }

        public static bool InLength(this IEnumerable<string> values, params int[] choices)
        {
            return InLength(values, choices as IEnumerable<int>);
        }

        #endregion
    }
}

