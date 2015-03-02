using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        #region Pipes

        public class IfPipe<T>: Flow.Pipe<T>
        {
        }

        public class IfElsePipe<T>: IfPipe<T>
        {
        }

        public class IfThenPipe<T>: IfElsePipe<T>
        {
        }

        public class IfLogikPipe<T>: IfThenPipe<T>
        {
        }

        #endregion

        #region If Is

        public static IfLogikPipe<T> If<T>(this T value)  where T : IComparable
        {
            IfLogikPipe<T> pipe = new IfLogikPipe<T>();
            pipe.Value = value;
            return pipe;
        }

        public static IfLogikPipe<T> Is<T>(this IfLogikPipe<T> pipe, T value)  where T : IComparable
        {
            pipe.CalcState(pipe.Value.CompareTo(value) == 0);
            return pipe;
        }

        #endregion

        #region Then Else

        public static IfThenPipe<T> Then<T>(this IfLogikPipe<T> pipe, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (pipe.State)
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
            ;
        }

        public static IfElsePipe<T> Else<T>(this IfThenPipe<T> pipe, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Return)
                return pipe;

            if (!pipe.State)
            {
                pipe.Return = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Logik

        public static IfLogikPipe<T> IsTrue<T>(this IfLogikPipe<T> pipe, bool value)  where T : IComparable
        {
            pipe.CalcState(value);
            return pipe;
        }

        public static IfLogikPipe<T> IsFalse<T>(this IfLogikPipe<T> pipe, bool value)  where T : IComparable
        {
            pipe.CalcState(!value);
            return pipe;
        }

        public static IfLogikPipe<T> IsIn<T>(this IfLogikPipe<T> pipe, params T[] values)  where T : IComparable
        {
            pipe.CalcState(pipe.Value.In(values));
            return pipe;
        }

        public static IfLogikPipe<T> IsInRange<T>(this IfLogikPipe<T> pipe, T minvalue, T maxValue)  where T : IComparable
        {
            pipe.CalcState(pipe.Value.InRange(minvalue, maxValue));
            return pipe;
        }

        public static IfLogikPipe<T> Or<T>(this IfLogikPipe<T> pipe)  where T : IComparable
        {
            pipe.Operator = Flow.Operator.And;
            return pipe;
        }

        public static IfLogikPipe<T> And<T>(this IfLogikPipe<T> pipe)  where T : IComparable
        {
            pipe.Operator = Flow.Operator.And;
            return pipe;
        }

        public static IfLogikPipe<T> Not<T>(this IfLogikPipe<T> pipe)  where T : IComparable
        {
            pipe.InvertOperator();
            return pipe;
        }

        #endregion
    }
}

