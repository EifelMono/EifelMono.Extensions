using System;

namespace EifelMono.Extensions
{
    public static partial class NumericalExtensions
    {
        #region Math

        public static float Abs(this float value)
        {
            return Math.Abs(value);
        }

        public static float Min(this float value, float otherValue)
        {
            return Math.Min(value, otherValue);
        }

        public static float Max(this float value, float otherValue)
        {
            return Math.Max(value, otherValue);
        }

        public static bool InRangeOffset(this float value, float baseValue, float offset) 
        {
            return value.InRange(baseValue - offset, baseValue + offset);
        }

        #endregion
    }
}