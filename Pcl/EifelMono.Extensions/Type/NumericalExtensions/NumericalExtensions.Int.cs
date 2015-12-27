using System;

namespace EifelMono.Extensions
{
    public static partial class NumericalExtensions
    {
        #region Math

        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        public static int Min(this int value, int otherValue)
        {
            return Math.Min(value, otherValue);
        }

        public static int Max(this int value, int otherValue)
        {
            return Math.Max(value, otherValue);
        }

        public static bool InRangeOffset(this int value, int baseValue, int offset) 
        {
            return value.InRange(baseValue - offset, baseValue + offset);
        }

        #endregion
    }
}