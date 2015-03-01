using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        /// <summary>
        /// Switch result.
        /// </summary>
        public class IfResult<T>: FlowResult<T>
        {
        }

        public class IfElseResult<T>: IfResult<T>
        {
        }

        public class IfThenResult<T>: IfElseResult<T>
        {
        }

        public class IfLogikResult<T>: IfThenResult<T>
        {
        }

        /// <summary>
        /// Switch the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> If<T>(this T value)  where T : IComparable
        {
            IfLogikResult<T> result = new IfLogikResult<T>();
            result.Value = value;
            return result;
        }

        /// <summary>
        /// Determines if is  result.
        /// </summary>
        /// <returns><c>true</c> if is result; otherwise, <c>false</c>.</returns>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> Is<T>(this IfLogikResult<T> result, T value)  where T : IComparable
        {
            result.CalcState(result.Value.CompareTo(value)== 0);
            return result;
        }

        public static IfLogikResult<T> IsTrue<T>(this IfLogikResult<T> result, bool value)  where T : IComparable
        {
            result.CalcState(value);
            return result;
        }

        public static IfLogikResult<T> IsFalse<T>(this IfLogikResult<T> result, bool value)  where T : IComparable
        {
            result.CalcState(!value);
            return result;
        }

        /// <summary>
        /// In the specified result and values.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="values">Values.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> IsIn<T>(this IfLogikResult<T> result, params T[] values)  where T : IComparable
        {
            result.CalcState(result.Value.In(values));
            return result;
        }

        public static IfLogikResult<T> IsInRange<T>(this IfLogikResult<T> result, T minvalue, T maxValue)  where T : IComparable
        {
            result.CalcState(result.Value.InRange(minvalue, maxValue));
            return result;
        }

        /// <summary>
        /// Or the specified result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> Or<T>(this IfLogikResult<T> result)  where T : IComparable
        {
            result.Operator = FlowOperator.And;
            return result;
        }

        /// <summary>
        /// And the specified result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> And<T>(this IfLogikResult<T> result)  where T : IComparable
        {
            result.Operator = FlowOperator.And;
            return result;
        }

        /// <summary>
        /// Not the specified result.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfLogikResult<T> Not<T>(this IfLogikResult<T> result)  where T : IComparable
        {
            result.InvertOperator();
            return result;
        }


        /// <summary>
        /// Case the specified result, item and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="item">Item.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfThenResult<T> Then<T>(this IfLogikResult<T> result, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (result.State)
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
            ;
        }

        /// <summary>
        /// Case the specified result, item and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="item">Item.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IfElseResult<T> Else<T>(this IfThenResult<T> result, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (!result.State)
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }
    }
}

