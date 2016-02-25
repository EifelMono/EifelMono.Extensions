using System;
using System.Linq;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public class Static
    {
        /// <summary>
        /// Enumerate this enums
        /// 
        /// Thank you to
        /// http://dotnet-snippets.de/snippet/enum-werte-aufzaehlen/14116
        /// </summary>
        /// <typeparam name="TEnum">enum definition</typeparam>
        public static IEnumerable<TEnum> Enumerate<TEnum>() => Enum.GetValues(typeof(TEnum)).OfType<TEnum>();
    }
}

