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

        public class SwitchPipe<T>: Flow.Pipe<T>
        {
        }

        public class SwitchDefaultPipe<T>: SwitchPipe<T>
        {
        }

        public class SwitchCasePipe<T>: SwitchDefaultPipe<T>
        {
            public void Continue()
            {
                Executed = false;
            }

            public new delegate void Action(SwitchCasePipe<T> a);
        }

        #endregion

        #region Execute

        public static SwitchCasePipe<T> Execute<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action)
        {
            if (action != null)
                action(pipe);
            return pipe;
        }

        private static SwitchCasePipe<T> ExecuteSwitchCaseAction<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action)
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

        #region Switch

        public static SwitchCasePipe<T> Switch<T>(this T value)
        {
            SwitchCasePipe<T> pipe = new SwitchCasePipe<T>();
            pipe.CompareValue = value;

            return pipe;
        }

        public static SwitchCasePipe<object> Switch<T>(this object value)
        {
            SwitchCasePipe<object> pipe = new SwitchCasePipe<object>();
            pipe.CompareValue = value;

            return pipe;
        }

        #endregion

        #region Default

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

        #region Case

        public static SwitchCasePipe<T> Case<T>(this SwitchCasePipe<T> pipe, T choice, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Equals(choice)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }


        #endregion

        #region Case Bool

        public static SwitchCasePipe<T> CaseTrue<T>(this SwitchCasePipe<T> pipe, bool choice, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(choice); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseFalse<T>(this SwitchCasePipe<T> pipe, bool choice, SwitchCasePipe<T>.Action action = null)
        {
            return CaseTrue(pipe, !choice, action);
        }

        #endregion

        #region CaseIn

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T[] choices, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.In(choices)); 
            return ExecuteSwitchCaseAction(pipe, action);
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

        #endregion

        #region CaseOut

        public static SwitchCasePipe<T> CaseOut<T>(this SwitchCasePipe<T> pipe, T[] choices, SwitchCasePipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Out(choices)); 
            return ExecuteSwitchCaseAction(pipe, action);
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

        #region Case In/Out Range

        public static SwitchCasePipe<T> CaseInRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, SwitchCasePipe<T>.Action action = null) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRange(minChoice, maxChoice)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseOutRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, SwitchCasePipe<T>.Action action) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.OutRange(minChoice, maxChoice)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        #endregion

        #region Case Operator

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

        #region Case Comparable

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
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseEndsWith(this SwitchCasePipe<string> pipe, string choice, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.EndsWith(choice)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseRegexMatch(this SwitchCasePipe<string> pipe, string match, RegexOptions regexOptions, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(Regex.Match(match, pipe.CompareValue, regexOptions).Success); 
            return ExecuteSwitchCaseAction(pipe, action);
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
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<string> CaseIsNullOrEmpty(this SwitchCasePipe<string> pipe, SwitchCasePipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(string.IsNullOrEmpty(pipe.CompareValue)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        #endregion

        #region Case Numerical

        public static SwitchCasePipe<int> CaseInRangeOffset(this SwitchCasePipe<int> pipe, int basevalue, int offset, SwitchCasePipe<int>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRangeOffset(basevalue, offset)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<float> CaseInRangeOffset(this SwitchCasePipe<float> pipe, float basevalue, float offset, SwitchCasePipe<float>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRangeOffset(basevalue, offset)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<double> CaseInRangeOffset(this SwitchCasePipe<double> pipe, double basevalue, double offset, SwitchCasePipe<double>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRangeOffset(basevalue, offset)); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        #endregion

        #region Case class

        public static SwitchCasePipe<T> CaseType<T>(this SwitchCasePipe<T> pipe, Type choice, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.GetType() == choice); 
            return ExecuteSwitchCaseAction(pipe, action);
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
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseIsNull<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue == null); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        public static SwitchCasePipe<T> CaseIsNotNull<T>(this SwitchCasePipe<T> pipe, SwitchCasePipe<T>.Action action = null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue != null); 
            return ExecuteSwitchCaseAction(pipe, action);
        }

        #endregion
    }
}

