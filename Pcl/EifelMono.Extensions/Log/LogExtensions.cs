using System;
using System.Runtime.CompilerServices;

namespace EifelMono.Extensions
{
    public static class LogExtensions
    {
        public static void LogException(this Exception ex, string format = "", params object[] args)
        {
            Log.Exception(ex, format, args);
        }

        public static void LogError(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Error, text, filePath, lineNumber, memberName);
        }

        public static void LogMessage(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Message, text, filePath, lineNumber, memberName);
        }

        public static void LogHint(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Hint, text, filePath, lineNumber, memberName);
        }

        public static void LogWarning(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Warning, text, filePath, lineNumber, memberName);
        }

        public static void LogFlow(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Flow, text, filePath, lineNumber, memberName);
        }

        public static void LogCommunication(this string text, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1, [CallerMemberName] string memberName = "")
        {
            Log.Text(Log.Type.Communication, text, filePath, lineNumber, memberName);
        }

        public static void Try(this Action action, Action<Exception> catchAction = null, Action finallyAction = null)
        {
            Log.Try(action, catchAction, finallyAction);
        }

        [Obsolete("Use Try it's the same")]
        public static void TryCatchFinally(this Action action, Action<Exception> catchAction = null, Action finallyAction = null)
        {
            Log.TryCatchFinally(action, catchAction, finallyAction);
        }
    }
}

