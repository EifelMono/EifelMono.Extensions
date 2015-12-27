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

        public class SelectPipe<T>: Flow.Pipe<T>
        {
        }

        public class SelectDefaultPipe<T>: SelectPipe<T>
        {
        }

        public class SelectCasePipe<T>: SelectDefaultPipe<T>
        {
            public void Continue()
            {
                Executed = false;
            }

            public delegate void Action<T1>(SelectCasePipe<T> a,T1 o);
        }

        #endregion

        #region Execute

        public static SelectCasePipe<object> Execute(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action action)
        {
            if (action != null)
                action(pipe);
            return pipe;
        }

        private static SelectCasePipe<object> ExecuteSelectCaseAction(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action action)
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

        #region Select

        public static SelectCasePipe<object> Select(this object value)
        {
            SelectCasePipe<object> pipe = new SelectCasePipe<object>();
            pipe.CompareValue = value;


            #if NOPCL
            pipe.CompareValueType  = pipe.CompareValue.GetType();
            #else
            pipe.CompareValueType = pipe.CompareValue.GetType().GetTypeInfo();
            #endif

            return pipe;
        }

        #endregion

        #region Default

        public static SelectCasePipe<object> Default(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action action)
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

        #region CaseOn

        public static SelectCasePipe<object> CaseOn<TOn>(this SelectCasePipe<object> pipe, Func<TOn, bool> choice, SelectCasePipe<object>.Action<TOn> action = null)
        {   
            if (pipe.Executed)
                return pipe;

            #if NOPCL
            var onType = typeof(TOn);
            #else
            var onType = typeof(TOn).GetTypeInfo();     
            #endif

            Action<TOn> executeDependCaseAction = (onObject) =>
            {
                pipe.CurrentDecision.CalcDecision(choice  == null ? true : choice(onObject));
                if (action != null)
                {
                    pipe.PopDecisions();
                    if (pipe.CurrentDecision.Value)
                    {
                        pipe.Executed = true;
                        if (action != null)
                            action(pipe, onObject);
                    }
                    pipe.CurrentDecision.First = true;
                } 
            };

            try
            {
                if (pipe.CompareValueType.IsClass && onType.IsClass)
                if (onType.IsAssignableFrom(pipe.CompareValueType))
                    executeDependCaseAction((TOn)pipe.CompareValue);
                
                if (pipe.CompareValueType.IsPrimitive && pipe.CompareValueType.FullName == onType.FullName)
                    executeDependCaseAction((TOn)Convert.ChangeType(pipe.CompareValue, typeof(TOn)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return pipe;
        }

        public static SelectCasePipe<object> CaseOn<TOn>(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action<TOn> action)
        {
            return CaseOn(pipe, null, action);
        }

        #endregion

        #region CaseOnEqual

        public static SelectCasePipe<object> CaseOnEqual<TOn>(this SelectCasePipe<object> pipe, Func<TOn, bool> choice, SelectCasePipe<object>.Action<TOn> action = null)
        {   
            if (pipe.Executed)
                return pipe;

            #if NOPCL
            var onType = typeof(TOn);
            #else
            var onType = typeof(TOn).GetTypeInfo();     
            #endif

            Action<TOn> executeDependCaseAction = (onObject) =>
                {
                    pipe.CurrentDecision.CalcDecision(choice  == null ? true : choice(onObject));
                    if (action != null)
                    {
                        pipe.PopDecisions();
                        if (pipe.CurrentDecision.Value)
                        {
                            pipe.Executed = true;
                            if (action != null)
                                action(pipe, onObject);
                        }
                        pipe.CurrentDecision.First = true;
                    } 
                };

            try
            {
                if (pipe.CompareValueType.FullName == onType.FullName)
                    executeDependCaseAction((TOn)Convert.ChangeType(pipe.CompareValue, typeof(TOn)));
            }
            catch (Exception ex)
            {
                ex.LogException();
            }

            return pipe;
        }

        public static SelectCasePipe<object> CaseOnEqual<TOn>(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action<TOn> action)
        {
            return CaseOnEqual(pipe, null, action);
        }

        #endregion

        #region Case Bool

        public static SelectCasePipe<object> CaseTrue(this SelectCasePipe<object> pipe, bool choice, SelectCasePipe<object>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(choice); 
            return ExecuteSelectCaseAction(pipe, action);
        }

        public static SelectCasePipe<object> CaseFalse(this SelectCasePipe<object> pipe, bool choice, SelectCasePipe<object>.Action action = null)
        {
            return CaseTrue(pipe, !choice, action);
        }

        #endregion

        #region Case Operator

        public static SelectCasePipe<object> And(this SelectCasePipe<object>pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.And;
            return pipe;
        }

        public static SelectCasePipe<object> Or(this SelectCasePipe<object> pipe)
        {
            pipe.CurrentDecision.Operator = Flow.Operator.Or;
            return pipe;
        }

        public static SelectCasePipe<object> AndPush(this SelectCasePipe<object> pipe)
        {
            pipe.PushDecision(Flow.Operator.And);
            return pipe;
        }

        public static SelectCasePipe<object> OrPush(this SelectCasePipe<object> pipe)
        {
            pipe.PushDecision(Flow.Operator.Or);
            return pipe;
        }

        public static SelectCasePipe<object> Pop(this SelectCasePipe<object> pipe)
        {
            pipe.PopDecision();
            return pipe;
        }

        #endregion

        #region Case class

        public static SelectCasePipe<object> CaseIsNull(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue == null); 
            return ExecuteSelectCaseAction(pipe, action);
        }

        public static SelectCasePipe<object>CaseIsNotNull(this SelectCasePipe<object> pipe, SelectCasePipe<object>.Action action = null)
        {
            if (pipe.Executed)
                return pipe;

            pipe.CurrentDecision.CalcDecision(pipe.CompareValue != null); 
            return ExecuteSelectCaseAction(pipe, action);
        }

        #endregion
    }
}

