using System;

namespace EifelMono.Extensions
{
    public static class ObjectExtensions
    {
        #region Delphi

        public static bool Assigned(this object value)
        {
            return value != null;
        }

        #endregion

        #region

        public static bool IsNull(this object value)
        {
            return value == null;
        }
        #endregion
    }
}

