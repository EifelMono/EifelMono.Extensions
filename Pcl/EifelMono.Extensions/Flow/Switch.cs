using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
            public void Continue()
            {
                Executed = false;
            }

            public new delegate void Action(SwitchCasePipe<T> a);

            public delegate void Action<T1>(SwitchCasePipe<T> a,T1 o);
        }

        #endregion

        #region Execute

        public static SwitchCasePipe<T> Execute<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action)
        {
            if (action != null)
                action(pipe);
            return pipe;
        }

        private static SwitchCasePipe<T> ExecuteCaseAction<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action)
        {
            if (action != null)
            {
                pipe.PopDecisions();
                if (pipe.CurrentDecision.Value)
                {
                    pipe.Executed = true;
                    if (action != null)
                        action(pipe);
                }
                pipe.CurrentDecision.First = true;
            }
            return pipe;
        }

        #endregion

        #region Switch case default

        public static SwitchCasePipe<T> Switch<T>(this T value)
        {
            SwitchCasePipe<T> pipe = new SwitchCasePipe<T>();
            pipe.CompareValue = value;

            return pipe;
        }

        public static SwitchCasePipe<T> Case<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Equals(choice)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchDefaultPipe<T> Default<T>(this SwitchCasePipe<T> pipe, SwitchDefaultPipe<T>.Action action)
        {
            if (!pipe.Executed)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Case bool

        public static SwitchCasePipe<T> CaseTrue<T>(this SwitchCasePipe<T> pipe, bool choice, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(choice); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseFalse<T>(this SwitchCasePipe<T> pipe, bool choice, SwitchCasePipe<T>.Action action = null)
        {
            return CaseTrue(pipe, !choice, action);
        }

        #endregion

        #region Case in out

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T[] choices, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.In(choices)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, T choice9, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8, choice9 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, T choice9, T choice10, SwitchCasePipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8, choice9, choice10 }, action);
        }


        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T[] choices, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Out(choices)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, T choice9, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8, choice9 }, action);
        }

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, T choice6, T choice7, T choice8, T choice9, T choice10, SwitchCasePipe<T>.Action action = null)
        {
            return CaseOut(pipe, new T[] { choice1, choice2, choice3, choice4, choice5, choice6, choice7, choice8, choice9, choice10 }, action);
        }

        #endregion

        #region Case in out range

        public static SwitchCasePipe<T> CaseInRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRange(minChoice, maxChoice)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseOutRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, SwitchCasePipe<T>.Action action) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.OutRange(minChoice, maxChoice)); 
            return ExecuteCaseAction(pipe, action);
        }

        #endregion

        #region case operator

        public static SwitchCasePipe<T> And<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.And;
            return pipe;
        }

        public static SwitchCasePipe<T> Or<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.Or;
            return pipe;
        }

        public static SwitchCasePipe<T> AndPush<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.PushDecision(Flow.Operator.And);
            return pipe;
        }

        public static SwitchCasePipe<T> OrPush<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.PushDecision(Flow.Operator.Or);
            return pipe;
        }

        public static SwitchCasePipe<T> Pop<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.PopDecision();
            return pipe;
        }

        #endregion

        #region Case comparable

        public static SwitchCasePipe<T> CaseEql<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) == 0, action);
        }

        public static SwitchCasePipe<T> CaseGtr<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) > 0, action);
        }

        public static SwitchCasePipe<T> CaseGeq<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) >= 0, action);
        }

        public static SwitchCasePipe<T> CaseLss<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) < 0, action);
        }

        public static SwitchCasePipe<T> CaseLeq<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) <= 0, action);
        }

        #endregion

        #region Case string

        public static SwitchCasePipe<string> CaseStartsWith(this SwitchCasePipe<string> pipe, string choice, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.StartsWith(choice)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseEndsWith(this SwitchCasePipe<string> pipe, string choice, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.EndsWith(choice)); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseRegexMatch(this SwitchCasePipe<string> pipe, string match, RegexOptions regexOptions, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(Regex.Match(match, pipe.CompareValue, regexOptions).Success); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseRegexMatch(this SwitchCasePipe<string> pipe, string match, SwitchCasePipe<string>.Action action = null)
        {
            return CaseRegexMatch(pipe, match, RegexOptions.None, action);
        }


        public static SwitchCasePipe<string> CaseIsNull(this SwitchCasePipe<string> pipe, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue == null); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseIsNullOrEmpty(this SwitchCasePipe<string> pipe, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(string.IsNullOrEmpty(pipe.CompareValue)); 
            return ExecuteCaseAction(pipe, action);
        }

        #endregion

        #region Case class

        public static SwitchCasePipe<T> CaseType<T>(this SwitchCasePipe<T> pipe, Type choice, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.GetType() == choice); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseAssignableFrom<T>(this SwitchCasePipe<T> pipe, Type choice, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            #if NOPCL
            pipe.CurrentDecision.CalcDecision(choice.IsAssignableFrom(pipe.CompareValue.GetType())); 
            #else
            pipe.CurrentDecision.CalcDecision(choice.GetTypeInfo().IsAssignableFrom(pipe.CompareValue.GetType().GetTypeInfo())); 
            #endif
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseIsNull<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue == null); 
            return ExecuteCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseIsNotNull<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue != null); 
            return ExecuteCaseAction(pipe, action);
        }

        /// <summary>
        /// Cases the pattern matching. ?  c# 7.0 
        /// </summary>
        /// <returns>The pattern matching.</returns>
        /// <param name="pipe">Pipe.</param>
        /// <param name="choice">Choice.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TO">The 2nd type parameter.</typeparam>
        public static SwitchCasePipe<T> CaseOn<T, TOn>(this SwitchCasePipe<T> pipe, Func<TOn, bool> choice, SwitchCasePipe<T>.Action<TOn> action = null) where T: class where TOn: class
        {
            if (pipe.Executed)
                return pipe;

            TOn On = pipe.CompareValue as TOn;

            if (On == null)
                return pipe;

            if (choice != null)
                pipe.CurrentDecision.CalcDecision(choice(On));
            else
                pipe.CurrentDecision.CalcDecision(true); 

            if (action != null)
            {
                pipe.PopDecisions();
                if (pipe.CurrentDecision.Value)
                {
                    pipe.Executed = true;
                    if (action != null)
                        action(pipe, On);
                }
                pipe.CurrentDecision.First = true;
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseOn<T, TOn>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action<TOn> action) where T: class where TOn: class
        {
            return CaseOn(pipe, null, action);
        }

        #endregion

        #region object

        public static SwitchCasePipe<object> CaseOn<TOn>(this SwitchCasePipe<object> pipe, Func<TOn, bool> choice, SwitchCasePipe<object>.Action<TOn> action = null)
        {   
            if (pipe.Executed)
                return pipe;

            bool ok = true;
            TOn On = default(TOn);
            try
            {
                On = (TOn)Convert.ChangeType(pipe.CompareValue, typeof(TOn));
            }
            catch (Exception ex)
            {
                ok = false;
                Debug.WriteLine(ex);
            }

            if (On == null | !ok)
                return pipe;

            if (choice != null)
                pipe.CurrentDecision.CalcDecision(choice(On));
            else
                pipe.CurrentDecision.CalcDecision(true); 

            if (action != null)
            {
                pipe.PopDecisions();
                if (pipe.CurrentDecision.Value)
                {
                    pipe.Executed = true;
                    if (action != null)
                        action(pipe, On);
                }
                pipe.CurrentDecision.First = true;
            }
           
            return pipe;
        }

        public static SwitchCasePipe<object> CaseOn<TOn>(this SwitchCasePipe<object> pipe, SwitchCasePipe<object>.Action<TOn> action)
        {
            return CaseOn(pipe, null, action);
        }

        #endregion
    }
}

