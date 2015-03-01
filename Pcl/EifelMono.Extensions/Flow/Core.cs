using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        public enum FlowOperator
        {
            Or,
            And
        }

        /// <summary>
        /// Switch result.
        /// </summary>
        public class FlowResult<T>
        {
            public T Value = default(T);

            public bool Return = false;
            public bool State = false;
            public bool First = true;
      
            public FlowOperator Operator = FlowOperator.Or;

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
                        case FlowOperator.Or:
                            State = State | value;
                            break;
                        case FlowOperator.And:
                            State = State & value;
                            break;
                    }
                First = false;
            }


            public object Data = null;

            public delegate void FlowAction(FlowResult<T> r);
        }

        public static T Result<T>(this FlowResult<T> result, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (action != null)
                action(result);
            return result.Value;
        }
    }
}
