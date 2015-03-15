using System;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool Assigned(this object value)
        {
            return value != null;
        }

        #region In

        public static bool InContains(this string value, params string[] choices)
        {
            foreach (var choice in choices)
                if (choice.Contains(value))
                    return true;
            return false;
        }

        public static bool InStartsWith(this string value, params string[] choices)
        {
            foreach (var choice in choices)
                if (value.StartsWith(choice))
                    return true;
            return false;
        }

        public static bool InEndsWith(this string value, params string[] choices)
        {
            foreach (var choice in choices)
                if (value.EndsWith(choice))
                    return true;
            return false;
        }

        #endregion


    }
}

