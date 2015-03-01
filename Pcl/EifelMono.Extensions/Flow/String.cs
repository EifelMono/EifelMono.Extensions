using System;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        /// <summary>
        /// Same as string.IsNullOrEmpty but as Excetion
        /// </summary>
        /// <returns><c>true</c> if is null or empty the specified value; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Determines if is the specified value is assigned.
        /// </summary>
        /// <returns><c>true</c> if is assigned the specified value; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        public static bool Assigned(this object value)
        {
            return value != null;
        }
        #region In

        /// <summary>
        /// Returns true if the value contains in items or false if not found.
        /// </summary>
        /// <returns><c>true</c>, if contains was ined, <c>false</c> otherwise.</returns>
        /// <param name="value">Value.</param>
        /// <param name="items">Items.</param>
        public static bool InContains(this string value, params string[] items)
        {
            foreach (var item in items)
                if (item.Contains(value))
                    return true;
            return false;
        }

        #endregion


    }
}

