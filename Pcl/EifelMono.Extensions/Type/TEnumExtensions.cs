using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EifelMono.Extensions
{
    public static class TEnumExtensions
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
            return Array.ConvertAll<T,int>(
                Enum.GetValues(typeof(T)).OfType<T>().ToArray(), 
                (enumValue) =>
                {
                    return Convert.ToInt32(enumValue);
                });
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
}

