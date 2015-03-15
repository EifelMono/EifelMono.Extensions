using System;
using System.Collections.Generic;
using System.Reflection;

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

        public static SwitchCasePipe<T> Switch<T>(this T value)
        {
            SwitchCasePipe<T> pipe = new SwitchCasePipe<T>();
            pipe.CompareValue = value;

            return pipe;
        }

        #endregion

        #region Case Default

        public static SwitchCasePipe<T> Case<T>(this SwitchCasePipe<T> pipe, T choice, Flow.Pipe<T>.Action action)
        {
            if (pipe.Executed)
                return pipe;

            if (pipe.CompareValue.Equals(choice))
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchDefaultPipe<T> Default<T>(this SwitchCasePipe<T> pipe, Flow.Pipe<T>.Action action)
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

        #region Execute

        public static SwitchCasePipe<T> Execute<T>(this SwitchCasePipe<T> pipe, Flow.Pipe<T>.Action action)
        {
            if (action != null)
                action(pipe);
            return pipe;
        }

        #endregion

        #region Case Bool

        public static SwitchCasePipe<T> CaseTrue<T>(this SwitchCasePipe<T> pipe, bool choice, Flow.Pipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(choice, action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseFalse<T>(this SwitchCasePipe<T> pipe, bool choice, Flow.Pipe<T>.Action action = null)
        {
            return CaseTrue(pipe, !choice, action);
        }

        #endregion

        #region Case In

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T[] choices, Flow.Pipe<T>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.In(choices), action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, Flow.Pipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, Flow.Pipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, Flow.Pipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4 }, action);
        }

        public static SwitchCasePipe<T> CaseIn<T>(this SwitchCasePipe<T> pipe, T choice1, T choice2, T choice3, T choice4, T choice5, Flow.Pipe<T>.Action action = null)
        {
            return CaseIn(pipe, new T[] { choice1, choice2, choice3, choice4, choice5 }, action);
        }

        #endregion

        #region Case In/Out Range

        public static SwitchCasePipe<T> CaseInRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, Flow.Pipe<T>.Action action = null) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.InRange(minChoice, maxChoice), action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseOutRange<T>(this SwitchCasePipe<T> pipe, T minChoice, T maxChoice, Flow.Pipe<T>.Action action) where T : IComparable
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.OutRange(minChoice, maxChoice), action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Operator
        public static SwitchCasePipe<T> And<T>(this SwitchCasePipe<T> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.And;
            return pipe;
        }

        #endregion

        #region Case Compareable

        public static SwitchCasePipe<T> CaseGtr<T>(this SwitchCasePipe<T> pipe, T choice, Flow.Pipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) > 0, action);
        }

        public static SwitchCasePipe<T> CaseGeq<T>(this SwitchCasePipe<T> pipe, T choice, Flow.Pipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) >= 0, action);
        }

        public static SwitchCasePipe<T> CaseLss<T>(this SwitchCasePipe<T> pipe, T choice, Flow.Pipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) < 0, action);
        }

        public static SwitchCasePipe<T> CaseLeq<T>(this SwitchCasePipe<T> pipe, T choice, Flow.Pipe<T>.Action action = null) where T : IComparable
        {
            return CaseTrue(pipe, pipe.CompareValue.CompareTo(choice) <= 0, action);
        }

        #endregion

        #region Case string

        public static SwitchCasePipe<string> CaseStartsWith(this SwitchCasePipe<string> pipe, string choice, Flow.Pipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.StartsWith(choice), action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<string> CaseEndsWith(this SwitchCasePipe<string> pipe, string choice, Flow.Pipe<string>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.EndsWith(choice), action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion

        #region Case class

        public static SwitchCasePipe<T> CaseType<T>(this SwitchCasePipe<T> pipe, Type choice, Flow.Pipe<T>.Action action= null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue.GetType() == choice, action!= null); 
            if (action != null && pipe.CurrentDecision.Value)
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        public static SwitchCasePipe<T> CaseIs<T>(this SwitchCasePipe<T> pipe, Type choice, Flow.Pipe<T>.Action action= null) where T: class
        {
            if (pipe.Executed)
                return pipe;

            #if NOPCL
            pipe.CurrentDecision.CalcDecision(choice.IsAssignableFrom(pipe.CompareValue.GetType())); 
            #else
            pipe.CurrentDecision.CalcDecision(choice.GetTypeInfo().IsAssignableFrom(pipe.CompareValue.GetType().GetTypeInfo()), action!= null); 
            #endif
            if (action != null && pipe.CurrentDecision.Value)   
            {
                pipe.Executed = true;
                if (action != null)
                    action(pipe);
            }
            return pipe;
        }

        #endregion
    }
}

