namespace TestConsole.Loggers
{
    public abstract class DebugLogger : Logger
    {
        public abstract void Log(string message, string category);
    }

}
