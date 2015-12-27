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
            Format(Log.Type.Exception, prefix + ex.ToString());
        }

        public void Text(Log.Type type, string text, string filePath, int lineNumber, string memberName)
        {
            Format(type, CallerInfos(filePath, lineNumber, memberName) + text);
        }

        private void Format(Log.Type type, string format, params object[] args)
        {
            if (args.Length == 0)
                Debug.WriteLine(type.ToString() + ":" + format);
            else
                Debug.WriteLine(type.ToString() + ":" + string.Format(format, args));
        
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

