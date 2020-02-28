using System;
using System.Diagnostics;

namespace TestConsole.Loggers
{
    public class TraceLogger : DebugLogger, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Log(string message)
        {
            System.Diagnostics.Trace.WriteLine($">>>> {message}");
        }

        public override void Log(string message, string category)
        {
            Trace.Flush();
        }

    }

}
