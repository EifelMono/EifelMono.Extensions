using System;
using System.Text.RegularExpressions;

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

        #region Execute

        #endregion

        #region If is then else

        public static IfLogikPipe<T> If<T>(this T value)  where T : IComparable
        {
            IfLogikPipe<T> pipe = new IfLogikPipe<T>();
            pipe.CompareValue = value;
            return pipe;
        }

        public static IfLogikPipe<T> Is<T>(this IfLogikPipe<T> pipe, T choice)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Equals(choice));
            return pipe;
        }

        public static IfThenPipe<T> Then<T>(this IfLogikPipe<T> pipe, Flow.Pipe<T>.Action action)
        {
            if (pipe.Executed)
                return pipe;
            
            pipe.PopDecisions();
            if (pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
            ;
        }

        public static IfElsePipe<T> Else<T>(this IfThenPipe<T> pipe, Flow.Pipe<T>.Action action)
        {
            if (pipe.Executed)
                return pipe;

            pipe.PopDecisions();
            if (!pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Is bool

        public static IfLogikPipe<T> IsTrue<T>(this IfLogikPipe<T> pipe, bool choice)
        {
            pipe.CurrentDecision.CalcDecision(choice);
            return pipe;
        }

        public static IfLogikPipe<T> IsFalse<T>(this IfLogikPipe<T> pipe, bool choice)
        {
            pipe.CurrentDecision.CalcDecision(!choice);
            return pipe;
        }

        #endregion

        #region Is in out

        public static IfLogikPipe<T> IsIn<T>(this IfLogikPipe<T> pipe, params T[] choices)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.In(choices));
            return pipe;
        }

        public static IfLogikPipe<T> IsOut<T>(this IfLogikPipe<T> pipe, params T[] choices)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.Out(choices));
            return pipe;
        }

        #endregion

        #region Is in out range

        public static IfLogikPipe<T> IsInRange<T>(this IfLogikPipe<T> pipe, T minChoice, T maxChoise)  where T : IComparable
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRange(minChoice, maxChoise));
            return pipe;
        }

        public static IfLogikPipe<T> IsOutRange<T>(this IfLogikPipe<T> pipe, T minChoice, T maxChoise)  where T : IComparable
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.OutRange(minChoice, maxChoise));
            return pipe;
        }

        #endregion

        #region Is operator

        public static IfLogikPipe<T> And<T>(this IfLogikPipe<T> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.And;
            return pipe;
        }

        public static IfLogikPipe<T> Or<T>(this IfLogikPipe<T> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.Or;
            return pipe;
        }

        public static IfLogikPipe<T> Not<T>(this IfLogikPipe<T> pipe)
        {
            pipe.CurrentDecision.InvertDecision();
            return pipe;
        }

        public static IfLogikPipe<T> AndPush<T>(this IfLogikPipe<T> pipe)
        {
            pipe.PushDecision(Flow.Operator.And);
            return pipe;
        }

        public static IfLogikPipe<T> OrPush<T>(this IfLogikPipe<T> pipe)
        {
            pipe.PushDecision(Flow.Operator.Or);
            return pipe;
        }

        public static IfLogikPipe<T> Pop<T>(this IfLogikPipe<T> pipe)
        {
            pipe.PopDecision();
            return pipe;
        }

        #endregion

        #region Is comparable

        public static IfLogikPipe<T> CaseEql<T>(this IfLogikPipe<T> pipe, T choice) where T : IComparable
        {
            return IsTrue(pipe, pipe.CompareValue.CompareTo(choice) == 0);
        }

        public static IfLogikPipe<T> CaseGtr<T>(this IfLogikPipe<T> pipe, T choice) where T : IComparable
        {
            return IsTrue(pipe, pipe.CompareValue.CompareTo(choice) > 0);
        }

        public static IfLogikPipe<T> CaseGeq<T>(this IfLogikPipe<T> pipe, T choice) where T : IComparable
        {
            return IsTrue(pipe, pipe.CompareValue.CompareTo(choice) >= 0);
        }

        public static IfLogikPipe<T> CaseLss<T>(this IfLogikPipe<T> pipe, T choice) where T : IComparable
        {
            return IsTrue(pipe, pipe.CompareValue.CompareTo(choice) < 0);
        }

        public static IfLogikPipe<T> CaseLeq<T>(this IfLogikPipe<T> pipe, T choice) where T : IComparable
        {
            return IsTrue(pipe, pipe.CompareValue.CompareTo(choice) <= 0);
        }

        #endregion

        #region Is string

        public static IfLogikPipe<string> IsStartsWith(this IfLogikPipe<string> pipe, string choice)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.StartsWith(choice));
            return pipe;
        }

        public static IfLogikPipe<string> IsEndsWith(this IfLogikPipe<string> pipe, string choice)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.EndsWith(choice));
            return pipe;
        }

        public static IfLogikPipe<string> IsRegexMatch(this IfLogikPipe<string> pipe, string match, RegexOptions regexOptions= RegexOptions.None)
        {
            pipe.CurrentDecision.CalcDecision(Regex.Match(match, pipe.CompareValue, regexOptions).Success); 
            return pipe;
        }

        public static IfLogikPipe<string> IsNull(this IfLogikPipe<string> pipe)
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue== null);
            return pipe;
        }

        public static IfLogikPipe<string> IsNullOrEmpty(this IfLogikPipe<string> pipe)
        {
            pipe.CurrentDecision.CalcDecision(string.IsNullOrEmpty(pipe.CompareValue));
            return pipe;
        }


        #endregion

        #region Is class

        public static IfLogikPipe<T> IsType<T>(this IfLogikPipe<T> pipe, Type choice) where T: class
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.GetType() == choice);
            return pipe;
        }

//        public static SwitchCasePipe<T> IsAssignableFrom<T>(this SwitchCasePipe<T> pipe, Type choice, Flow.Pipe<T>.Action action) where T: class
//        {
//            bool flag = false;
//            #if NOPCL
//            flag= choice.IsAssignableFrom(pipe.CompareValue.GetType());
//            #else
//            flag = choice.GetTypeInfo().IsAssignableFrom(pipe.CompareValue.GetType().GetTypeInfo());
//            #endif
//            pipe.CurrentDecision.CalcDecision(flag);
//            return pipe;
//        }

        public static IfLogikPipe<T> IsNull<T>(this IfLogikPipe<T> pipe) where T: class
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue== null);
            return pipe;
        }

        public static IfLogikPipe<T> IsNotNull<T>(this IfLogikPipe<T> pipe) where T: class
        {
            pipe.CurrentDecision.CalcDecision(pipe.CompareValue!= null);
            return pipe;
        }

        /// <summary>
        /// Determines if is pattern matching the specified pipe choice. c# 7.0
        /// </summary>
        /// <returns><c>true</c> if is pattern matching the specified pipe choice; otherwise, <c>false</c>.</returns>
        /// <param name="pipe">Pipe.</param>
        /// <param name="choice">Choice.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="TO">The 2nd type parameter.</typeparam>
        public static IfLogikPipe<T> IsOn<T, TOn>(this IfLogikPipe<T> pipe, Func<TOn, bool> choice = null) where TOn: class
        {
            TOn On = pipe.CompareValue as TOn;

            if (On == null)
                return pipe;

            if (choice!= null)
                pipe.CurrentDecision.CalcDecision(choice(On));
            else
                pipe.CurrentDecision.CalcDecision(true);
            return pipe;
        }

        #endregion
    }
}

