using System;
using System.Diagnostics;
using TestConsole.Loggers;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Logger logger = new ListLogger();
            //Logger logger = new FileLogger("program.log");
            //Logger logger = new VisualStudioOutputLogger();
            Logger logger = new TraceLogger();
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

            logger.LogInfo("Start program");

            for (var i = 0; i < 10; i++)
            {
                logger.LogInfo($"Do some wokr {i + 1}");
            }
            logger.LogWarring("The work has been stoped.");

            Trace.Flush();
/*            var log_message = ((ListLogger)logger).message;

            foreach (var message in log_message)
            {
                Console.WriteLine($"{message}");
            }
*/
            Console.ReadKey();
        }
    }
}
