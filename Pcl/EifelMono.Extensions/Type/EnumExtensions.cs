using System;
using System.Threading.Tasks;
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
}

