using System;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerFilePathAttribute : Attribute
    {
        //
        // Constructors
        //
        public CallerFilePathAttribute()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerLineNumberAttribute : Attribute
    {
        //
        // Constructors
        //
        public CallerLineNumberAttribute()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerMemberNameAttribute : Attribute
    {
        //
        // Constructors
        //
        public CallerMemberNameAttribute()
        {

        }
    }
}

