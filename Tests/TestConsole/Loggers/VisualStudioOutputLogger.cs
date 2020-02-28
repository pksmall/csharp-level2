namespace TestConsole.Loggers
{
    public class VisualStudioOutputLogger : DebugLogger
    {
        public override void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine($">>>> {message}");
        }

        public override void Log(string message, string category)
        {
            System.Diagnostics.Debug.WriteLine($">>>> {message} {category}");
        }
    }

}
