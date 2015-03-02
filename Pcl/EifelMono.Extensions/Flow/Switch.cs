using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region Pipes

        public class Pipe<T>: Flow.Pipe<T>
        {
        }

        public class SwitchDefaultPipe<T>: Pipe<T>
        {
        }

        public class SwitchCasePipe<T>: SwitchDefaultPipe<T>
        {
        }

        #endregion

        #region Switch

        public static SwitchCasePipe<T> Switch<T>(this T value)  where T : IComparable
        {
            SwitchCasePipe<T> pipe = new SwitchCasePipe<T>();
            pipe.Value = value;

            return pipe;
        }

        #endregion

        #region Case Default

        public static SwitchCasePipe<T> Case<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (pipe.Value.Equals(compareValue))
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseIs<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return Case(pipe, compareValue, action);
        }

        public static SwitchDefaultPipe<T> Default<T>(this SwitchCasePipe<T> pipe, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (!pipe.Return)
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Execute

        public static SwitchCasePipe<T> Execute<T>(this SwitchCasePipe<T> pipe, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (action != null)
                action(pipe);
            return pipe;
        }

        #endregion

        #region Bool

        public static SwitchCasePipe<T> CaseTrue<T>(this SwitchCasePipe<T> pipe, bool doIt, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (doIt)
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseFalse<T>(this SwitchCasePipe<T> pipe, bool doIt, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseTrue(pipe, !doIt, action);
        }

        public static SwitchCasePipe<T> CaseGtr<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseTrue(pipe, pipe.Value.CompareTo(compareValue) > 0, action);
        }

        public static SwitchCasePipe<T> CaseGeq<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseTrue(pipe, pipe.Value.CompareTo(compareValue) >= 0, action);
        }

        public static SwitchCasePipe<T> CaseLss<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseTrue(pipe, pipe.Value.CompareTo(compareValue) < 0, action);
        }

        public static SwitchCasePipe<T> CaseLeq<T>(this SwitchCasePipe<T> pipe, T compareValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseTrue(pipe, pipe.Value.CompareTo(compareValue) <= 0, action);
        }

        #endregion

        #region In

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T[] compareValues, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (pipe.Value.In(compareValues))
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T compareValue1, T compareValue2, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseIn(pipe, new T[] { compareValue1, compareValue2 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T compareValue1, T compareValue2, T compareValue3, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseIn(pipe, new T[] { compareValue1, compareValue2, compareValue3 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T compareValue1, T compareValue2, T compareValue3, T compareValue4, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseIn(pipe, new T[] { compareValue1, compareValue2, compareValue3, compareValue4 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T compareValue1, T compareValue2, T compareValue3, T compareValue4, T compareValue5, Flow.Pipe<T>.Action action) where T : IComparable
        {
            return CaseIn(pipe, new T[] { compareValue1, compareValue2, compareValue3, compareValue4, compareValue5 }, action);
        }

        #endregion

        #region InRange

        public static SwitchCasePipe<T> CaseInRange<T>(this SwitchCasePipe<T> pipe, T minValue, T maxValue, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (pipe.Value.InRange(minValue, maxValue))
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region String

        public static SwitchCasePipe<string> CaseStartsWith(this SwitchCasePipe<string> pipe, string startWith, Flow.Pipe<string>.Action action)
        {
            if (pipe.Return)
                return pipe;

            if (pipe.Value.StartsWith(startWith))
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion
    }
}

