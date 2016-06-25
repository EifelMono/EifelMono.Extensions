using System;
using System.Runtime.CompilerServices;


namespace EifelMono.Extensions
{
    public static class Log
    {
        #region IProxy

        public enum Type
        {
            Exception,
            Error,
            Message,
            Hint,
            Warning,
            Flow,
            Communication,
            WriteLine,
        }

        public static ILogProxy Proxy = new LogProxyDebug();

        public static void Exception(Exception ex, string format = "", params object[] args)
        {
            Proxy?.Exception(ex, format, args);
        }

        public static void Text(Log.Type type, string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Proxy?.Text(type, text, filePath, lineNumber, memberName);
        }

        #endregion

        #region Type

        public static void Error(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Error, text, filePath, lineNumber, memberName);
        }

        public static void Message(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Message, text, filePath, lineNumber, memberName);
        }

        public static void Hint(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Hint, text, filePath, lineNumber, memberName);
        }

        public static void Warning(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Warning, text, filePath, lineNumber, memberName);
        }

        public static void Flow(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Flow, text, filePath, lineNumber, memberName);
        }

        public static void Communication(string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Text(Type.Communication, text, filePath, lineNumber, memberName);
        }

        public static void WriteLine(string format, object[] args)
        {
            if (format != null)
                Text(Type.WriteLine, string.Format(format, args));
        }

        #endregion

        #region Try....

        /// <summary>
        /// Only for Log Exception with CatchExceptionVisible
        /// </summary>
        /// <param name="ex">Ex.</param>
        public static void CatchException(Exception ex)
        {
            if (Proxy != null && Proxy.CatchExceptionVisible)
                ex.LogException();
        }

        public static void Try(Action action, Action<Exception> catchAction = null, Action finallyAction = null)
        {
            action.SafeInvoke(catchAction, finallyAction);
        }

        [Obsolete ("Use Try it's the same")]
        public static void TryCatchFinally(Action action, Action<Exception> catchAction = null, Action finallyAction = null)
        {
            Try(action, catchAction, finallyAction);
        }

        #endregion
    }
}

