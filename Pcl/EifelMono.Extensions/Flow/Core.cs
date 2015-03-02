using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        /// <summary>
        /// Flow.
        /// Its more a container
        /// </summary>
        public class Flow
        {
            public enum Operator
            {
                Or,
                And
            }

            public class Pipe<T>
            {
                public T Value = default(T);

                public bool Return = false;
                public bool State = false;
                public bool First = true;

                public Flow.Operator Operator = Flow.Operator.Or;

                public void InvertOperator()
                {
                    State = !State;
                }

                public void CalcState(bool value)
                {
                    if (First)
                        State = value;
                    else
                        switch (Operator)
                        {
                            case Flow.Operator.Or:
                                State = State | value;
                                break;
                            case Flow.Operator.And:
                                State = State & value;
                                break;
                        }
                    First = false;
                }

                public object Data = null;

                public delegate void Action(Pipe<T> r);
            }
        }

        public static T Result<T>(this Flow.Pipe<T> pipe, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (action != null)
                action(pipe);
            return pipe.Value;
        }

        public static T Pipe<T>(this T pipe, Func<T, T> func) where T: struct
        {
            if (func != null)
                pipe = func(pipe);
            return pipe;
        }
    }
}
