using System;

namespace EifelMono.Extensions
{
    public interface ILogProxy
    {
        bool CallerInfosVisible { get; set; }

        bool CatchExceptionVisible { get;set;}

        void Exception(Exception ex, string format, object[] args);

        void Text(Log.Type logType, string text, string filePath, int lineNumber, string memberName);
    }
}

