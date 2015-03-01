using System;
using System.Collections.Generic;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        /// <summary>
        /// Switch case result.
        /// </summary>
        public class SwitchResult<T>: FlowResult<T>
        {
        }

        /// <summary>
        /// Switch default result.
        /// </summary>
        public class SwitchDefaultResult<T>: SwitchResult<T>
        {
        }

        /// <summary>
        /// Switch case result.
        /// </summary>
        public class SwitchCaseResult<T>: SwitchDefaultResult<T>
        {
        }

        #region Switch

        /// <summary>
        /// Switch the specified value and mutipleCase.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="mutipleCase">If set to <c>true</c> mutiple case.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchCaseResult<T> Switch<T>(this T value)  where T : IComparable
        {
            SwitchCaseResult<T> result = new SwitchCaseResult<T>();
            result.Value = value;

            return result;
        }

        #endregion

        #region Case/Default

        /// <summary>
        /// Case the specified result, compareValue and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="compareValue">Compare value.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchCaseResult<T> Case<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (result.Value.Equals(compareValue))
            {
                result.Return =true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        public static SwitchCaseResult<T> CaseIs<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return Case(result, compareValue, action);
        }

        /// <summary>
        /// Default the specified result and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchDefaultResult<T> Default<T>(this SwitchCaseResult<T> result, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (! result.Return)
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        #endregion

        #region Execute

        public static SwitchCaseResult<T> Execute<T>(this SwitchCaseResult<T> result, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (action != null)
                action(result);
            return result;
        }

        #endregion

        #region Bool

        /// <summary>
        /// Case the specified result, doIt and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="doIt">If set to <c>true</c> do it.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchCaseResult<T> CaseTrue<T>(this SwitchCaseResult<T> result, bool doIt, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (doIt)
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        public static SwitchCaseResult<T> CaseFalse<T>(this SwitchCaseResult<T> result, bool doIt, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseTrue(result, !doIt, action);
        }

        public static SwitchCaseResult<T> CaseGtr<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseTrue(result, result.Value.CompareTo(compareValue) > 0, action);
        }

        public static SwitchCaseResult<T> CaseGeq<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseTrue(result, result.Value.CompareTo(compareValue) >= 0, action);
        }

        public static SwitchCaseResult<T> CaseLss<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseTrue(result, result.Value.CompareTo(compareValue) < 0, action);
        }

        public static SwitchCaseResult<T> CaseLeq<T>(this SwitchCaseResult<T> result, T compareValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseTrue(result, result.Value.CompareTo(compareValue) <= 0, action);
        }

        #endregion

        #region In

        /// <summary>
        /// Case the specified result, compareValues and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="compareValues">Compare values.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchCaseResult<T> CaseIn<T>(this SwitchCaseResult<T> result, T[] compareValues, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (result.Value.In(compareValues))
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        public static SwitchCaseResult<T> CaseIn<T>(this SwitchCaseResult<T> result, T compareValue1, T compareValue2, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseIn(result, new T[] { compareValue1, compareValue2 }, action);
        }

        public static SwitchCaseResult<T> CaseIn<T>(this SwitchCaseResult<T> result, T compareValue1, T compareValue2, T compareValue3, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseIn(result, new T[] { compareValue1, compareValue2, compareValue3 }, action);
        }

        public static SwitchCaseResult<T> CaseIn<T>(this SwitchCaseResult<T> result, T compareValue1, T compareValue2, T compareValue3, T compareValue4, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseIn(result, new T[] { compareValue1, compareValue2, compareValue3, compareValue4 }, action);
        }

        public static SwitchCaseResult<T> CaseIn<T>(this SwitchCaseResult<T> result, T compareValue1, T compareValue2, T compareValue3, T compareValue4, T compareValue5, FlowResult<T>.FlowAction action) where T : IComparable
        {
            return CaseIn(result, new T[] { compareValue1, compareValue2, compareValue3, compareValue4, compareValue5 }, action);
        }

        #endregion

        #region InRange

        /// <summary>
        /// Case the specified result, minValue, maxValue and action.
        /// </summary>
        /// <param name="result">Result.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Max value.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static SwitchCaseResult<T> CaseInRange<T>(this SwitchCaseResult<T> result, T minValue, T maxValue, FlowResult<T>.FlowAction action) where T : IComparable
        {
            if (result.Return)
                return result;

            if (result.Value.InRange(minValue, maxValue))
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        #endregion


        #region String

        public static SwitchCaseResult<string> CaseStartsWith(this SwitchCaseResult<string> result, string startWith, FlowResult<string>.FlowAction action)
        {
            if (result.Return)
                return result;

            if (result.Value.StartsWith(startWith))
            {
                result.Return = true;
                if (action != null)
                    action(result);
            }
            return result;
        }

        #endregion
    }
}

