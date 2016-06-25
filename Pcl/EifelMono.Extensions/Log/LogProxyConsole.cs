using System;

namespace EifelMono.Extensions
{
#if NOPCL
    public class LogProxyConsole: LogProxyDebug
    {
        public LogProxyConsole()
        {
        }

        protected override void WriteLine(Log.Type logType, string format, params object[] args)
        {
            string prefix = logType.ToString() + ":";
            if (logType == Log.Type.WriteLine)
                prefix = "";
            if (args.Length == 0)
                Console.WriteLine(prefix + format);
            else
                Console.WriteLine(prefix + string.Format(format, args));
        }
    }
#endif
}

