using System;
using System.Diagnostics;
using EifelMono.Extensions;
using System.Runtime.CompilerServices;

namespace EifelMono.Extensions
{
    public class LogProxyDebug: ILogProxy
    {
        public LogProxyDebug()
        {
        }

        #region ILogProxy implementation

        public bool CallerInfosVisible { get; set; }= true;

        public bool CatchExceptionVisible { get; set; }= true;

        public void Exception(Exception ex, string format, object[] args)
        {
            string prefix = "";
            if (!string.IsNullOrEmpty(format))
                prefix = string.Format(format, args) + " ";
            WriteLine(Log.Type.Exception, prefix + ex.ToString());
        }

        public void Text(Log.Type logType, string text, string filePath, int lineNumber, string memberName)
        {
            string callerInfos = CallerInfos(filePath, lineNumber, memberName);
            if (logType == Log.Type.WriteLine)
                callerInfos = "";
            WriteLine(logType, callerInfos + text);
        }

        protected virtual void WriteLine(Log.Type logType, string format, params object[] args)
        {
            string prefix = logType.ToString() + ":";
            if (logType == Log.Type.WriteLine)
                prefix = "";
            if (args.Length == 0)
                Debug.WriteLine(prefix + format);
            else
                Debug.WriteLine(prefix + string.Format(format, args));
        }

        protected string CallerInfos(string filePath, int lineNumber, string memberName)
        {
            string result = "";
            if (CallerInfosVisible)
            {
                result += filePath.IsNullOrEmpty() ? "" : filePath + ":";
                result += lineNumber == -1 ? "" : lineNumber.ToString() + ":";
                result += memberName.IsNullOrEmpty() ? "" : memberName + ":";
            }
            return result;
        }

        #endregion
    }
}

