﻿using System;

namespace EifelMono.Extensions
{
    public static partial class NumericalExtensions
    {
        #region Math

        public static double Abs(this double value)
        {
            return Math.Abs(value);
        }

        public static double Min(this double value, double otherValue)
        {
            return Math.Min(value, otherValue);
        }

        public static double Max(this double value, double otherValue)
        {
            return Math.Max(value, otherValue);
        }

        #endregion
    }
}