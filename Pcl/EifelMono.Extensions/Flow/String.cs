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

        public static bool InContains(this string value, IEnumerable<string>  choices)
        {
            foreach (var choice in choices)
                if (choice.Contains(value))
                    return true;
            return false;
        }

        public static bool InContains(this string value, params string[] choices)
        {
            return InContains(value, choices as IEnumerable<string>);
        }

        public static bool InContains(this IEnumerable<string> values, IEnumerable<string>  choices)
        {
            foreach (var value in values)
                foreach (var choice in choices)
                    if (choice.Contains(value))
                        return true;
            return false;
        }

        public static bool InContains(this IEnumerable<string> values, params string[] choices)
        {
            return InContains(values, choices as IEnumerable<string>);
        }

        #endregion

        #region OutContains

        public static bool OutContains(this string value, IEnumerable<string> choices)
        {
            return !InContains(value, choices);
        }

        public static bool OutContains(this string value, params string[] choices)
        {
            return !InContains(value, choices);
        }

        public static bool OutContains(this IEnumerable<string> values, IEnumerable<string>  choices)
        {
            return !InContains(values, choices);
        }

        public static bool OutContains(this IEnumerable<string> values, params string[] choices)
        {
            return !InContains(values, choices);
        }

        #endregion

        #region InStartsWith

        public static bool InStartsWith(this string value, IEnumerable<string>  choices)
        {
            foreach (var choice in choices)
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
                foreach (var choice in choices)
                    if (value.StartsWith(choice))
                        return true;
            return false;
        }

        public static bool InStartsWith(this IEnumerable<string> values, params string[] choices)
        {
            return InStartsWith(values, choices  as IEnumerable<string>);
        }

        #endregion

        #region InInEndsWith

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
                foreach (var choice in choices)
                    if (value.EndsWith(choice))
                        return true;
            return false;
        }

        public static bool InEndsWith(this IEnumerable<string> values, params string[] choices)
        {
            return InEndsWith(values, choices as IEnumerable<string>);
        }

        #endregion
    }
}

