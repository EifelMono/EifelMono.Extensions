using System;

namespace EifelMono.Extensions
{
    public static partial class FlowExtenions
    {
        #region SafeInvoke

        public delegate void CatchAction(Exception exception);

        public delegate void FinallyAction();

        #region Action

        /// <summary>
        /// Safes invoke Action
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        public static void SafeInvoke(this Action value, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action action = value;
                if (action != null)
                    action();
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        /// <summary>
        /// Safes invoke Action<T1>
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        public static void SafeInvoke<T1>(this Action<T1> value, T1 value1, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action<T1> action = value;
                if (action != null)
                    action(value1);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        /// <summary>
        /// Safes invoke Action<T1, T2>
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        public static void SafeInvoke<T1, T2>(this Action<T1, T2> value, T1 value1, T2 value2, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action<T1, T2> action = value;
                if (action != null)
                    action(value1, value2);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        /// <summary>
        /// Safes invoke Action<T1, T2, T3>
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> value, T1 value1, T2 value2, T3 value3, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action<T1, T2, T3> action = value;
                if (action != null)
                    action(value1, value2, value3);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        /// <summary>
        /// Safes invoke Action<T1, T2, T3, T4>
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="value4">Value4.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        /// <typeparam name="T4">The 4th type parameter.</typeparam>
        public static void SafeInvoke<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> value, T1 value1, T2 value2, T3 value3, T4 value4, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action<T1, T2, T3, T4> action = value;
                if (action != null)
                    action(value1, value2, value3, value4);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        /// <summary>
        /// Safes invoke Action<T1, T2, T3, T4, T5>
        /// try catch finally around the action
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="value4">Value4.</param>
        /// <param name="value5">Value5.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        /// <typeparam name="T4">The 4th type parameter.</typeparam>
        /// <typeparam name="T5">The 5th type parameter.</typeparam>
        public static void SafeInvoke<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> value, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Action<T1, T2, T3, T4, T5> action = value;
                if (action != null)
                    action(value1, value2, value3, value4, value5);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
        }

        #endregion

        #region Func

        /// <summary>
        /// Safes invoke Func<TResult>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="TResult">The 1st type parameter.</typeparam>
        public static TResult SafeInvoke<TResult>(this Func<TResult> value, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<TResult> action = value;
                if (action != null)
                    return action();
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        /// <summary>
        /// Safes invoke Func<TResult, T1>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="TResult">The 2nd type parameter.</typeparam>
        public static TResult SafeInvoke<T1, TResult>(this Func<T1, TResult> value, T1 value1, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<T1, TResult> action = value;
                if (action != null)
                    return action(value1);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        /// <summary>
        /// Safes invoke Func<TResult, T1, T2>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="TResult">The 3rd type parameter.</typeparam>
        public static TResult SafeInvoke<T1, T2, TResult>(this Func<T1, T2, TResult> value, T1 value1, T2 value2, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<T1, T2, TResult> action = value;
                if (action != null)
                    return action(value1, value2);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        /// <summary>
        /// Safes invoke Func<T1, T2, T3, TResult>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        /// <typeparam name="TResult">The 4th type parameter.</typeparam>
        public static TResult SafeInvoke<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> value, T1 value1, T2 value2, T3 value3, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<T1, T2, T3, TResult> action = value;
                if (action != null)
                    return action(value1, value2, value3);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        /// <summary>
        /// Safes invoke Func<TResult, T1, T2, T3, T4>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="value4">Value4.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        /// <typeparam name="T4">The 4th type parameter.</typeparam>
        /// <typeparam name="TResult">The 5th type parameter.</typeparam>
        public static TResult SafeInvoke<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3,  T4, TResult> value, T1 value1, T2 value2, T3 value3, T4 value4, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<T1, T2, T3, T4, TResult> action = value;
                if (action != null)
                    return action(value1, value2, value3, value4);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        /// <summary>
        /// Safes invoke Func<TResult, T1, T2, T3, T4, T5>
        /// try catch finally around the action
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="value">Value.</param>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="value3">Value3.</param>
        /// <param name="value4">Value4.</param>
        /// <param name="value5">Value5.</param>
        /// <param name="catchAction">Catch action.</param>
        /// <param name="finallyAction">Finally action.</param>
        /// <typeparam name="T1">The 1st type parameter.</typeparam>
        /// <typeparam name="T2">The 2nd type parameter.</typeparam>
        /// <typeparam name="T3">The 3rd type parameter.</typeparam>
        /// <typeparam name="T4">The 4th type parameter.</typeparam>
        /// <typeparam name="T5">The 5th type parameter.</typeparam>
        /// <typeparam name="TResult">The 6th type parameter.</typeparam>
        public static TResult SafeInvoke<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3,  T4, T5, TResult> value, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, CatchAction catchAction = null, FinallyAction finallyAction = null)
        {
            try
            {
                Func<T1, T2, T3, T4, T5, TResult> action = value;
                if (action != null)
                    return action(value1, value2, value3, value4, value5);
            }
            catch (Exception ex)
            {
                if (catchAction != null)
                    catchAction(ex);
            }
            finally
            {
                if (finallyAction != null)
                    finallyAction();
            }
            return default(TResult);
        }

        #endregion

        #endregion
    }
}