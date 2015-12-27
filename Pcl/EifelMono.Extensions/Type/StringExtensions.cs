using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static class StringExtensions
    {
        #region ...

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNull(this string value)
        {
            return value == null;
        }

        public static bool IsEmpty(this string value)
        {
            if (value != null)
                return value == "";
            else
                return false;
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

        #region Dot...

        public static string DotPart(this string value, int index, int range = 1)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            var items = value.Split('.');
            switch (index)
            {
            // First
                case -1:
                    return items.Length > 0 ? items[0] : "";
            // Last
                case -2:
                    return items.Length > 0 ? items[items.Length - 1] : "";
            }
            string result = "";
            for (int i = index; i < index + 1; i++)
                result += (i == index ? "" : ".") + items[i];
            return result;
        }

        public static string DotFirst(this string value)
        {
            return value.DotPart(-1);
        }

        public static string DotLast(this string value)
        {
            return value.DotPart(-2);
        }

        #endregion

        #region SubString

        public static string Before(this string value, string search)
        {
            int pos = value.IndexOf(search);
            return pos != -1 ? value.Substring(0, pos - search.Length + 1) : "";
        }

        public static string LastBefore(this string value, string search)
        {
            int pos = value.LastIndexOf(search);
            return pos != -1 ? value.Substring(0, pos - search.Length + 1) : "";
        }

        public static string After(this string value, string search)
        {
            int pos = value.IndexOf(search);
            return pos != -1 ? value.Substring(pos + 1) : "";
        }

        public static string LastAfter(this string value, string search)
        {
            int pos = value.LastIndexOf(search);
            return pos != -1 ? value.Substring(pos + 1) : "";
        }

        #endregion




    }
}

