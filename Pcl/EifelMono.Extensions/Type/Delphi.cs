using System;

namespace EifelMono.Extensions
{
    public static partial class TypeExtensions
    {
        #region ...

        public static bool Assigned(this object value)
        {
            return value != null;
        }

        public static bool IsNull(this object value)
        {
            return value == null;
        }
        #endregion
    }
}

