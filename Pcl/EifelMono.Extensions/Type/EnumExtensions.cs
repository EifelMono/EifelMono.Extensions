using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EifelMono.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> EnumerateAllValues<T>(this T value)
        {
            #if NOPCL
            if (!typeof(T).IsEnum)
            #else
            if (!typeof(T).GetTypeInfo().IsEnum)
            #endif
                throw new ArgumentException("T is not an enum");
            return Enum.GetValues(typeof(T)).OfType<T>();
        }

        public static IEnumerable<int> EnumerateAllValuesAsInt<T>(this T value)
        {
            #if NOPCL
            if (!typeof(T).IsEnum)
            #else
            if (!typeof(T).GetTypeInfo().IsEnum)
            #endif
                throw new ArgumentException("T is not an enum");
            List<int> result = new List<int>();
            foreach (var e in EnumerateAllValues(value))
                result.Add(Convert.ToInt32(e));
            return result;
        }

        public static IEnumerable<string> EnumerateAllNames<T>(this T value)
        {
            #if NOPCL
            if (!typeof(T).IsEnum)
            #else
            if (!typeof(T).GetTypeInfo().IsEnum)
            #endif
                throw new ArgumentException("T is not an enum");
            return Enum.GetNames(typeof(T));
        }
    }

    public static partial class Static
    {
        /// <summary>
        /// Enums the values.
        /// </summary>
        /// <returns>The values.</returns>
        /// <typeparam name="T">T must be an enum</typeparam>
        public static IEnumerable<T> EnumValues<T>() => Enum.GetValues(typeof(T)).OfType<T>();
    
        /// <summary>
        /// Enums the names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <typeparam name="T">T must be an enum</typeparam>
        public static IEnumerable<T> EnumNames<T>() => Enum.GetNames(typeof(T)).OfType<T>();
    }
}

