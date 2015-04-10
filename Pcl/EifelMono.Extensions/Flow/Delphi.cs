using System;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region ...

        public static bool Assigned(this object value)
        {
            return value != null;
        }

        #endregion
    }
}

