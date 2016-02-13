﻿using System;
using System.Threading;
using EifelMono.Extensions;
using System.Linq.Expressions;

namespace EifelMono.Extensions
{
    public class First
    {
        public First()
        {
            Reset();
        }

        private bool m_IsFirst = true;

        public bool IsFirst
        {
            get
            {
                if (m_IsFirst)
                {
                    m_IsFirst = false;
                    return true;
                }
                return false;
            }
        }

        public virtual void Reset()
        {
            m_IsFirst = true;
        }
    }

    public class First<T>: First where T: IComparable
    {
        public First()
        {
            DefaultValue = default(T);
            Reset(true);
        }

        public First(T defaultValue)
        {
            DefaultValue = defaultValue;
            Reset(true);
        }

        public void Reset(bool withDefaultValue)
        {
            base.Reset();
            if (withDefaultValue)
                Value = DefaultValue;
        }

        public T DefaultValue { get; private set; }

        public T Value { get; set; }

        public bool IsFirstOrEqlValue(T value, bool setValue = true)
        {
            bool result = false;
            if (IsFirst || Value.CompareTo(value) == 0)
                result = true;
            if (setValue)
                Value = value;
            return result;
        }

        public bool IsFirstOrNotEqlValue(T value, bool setValue = true)
        {
            bool result = false;
            if (IsFirst || Value.CompareTo(value) != 0)
                result = true;
            if (setValue)
                Value = value;
            return result;
        }
    }
}
