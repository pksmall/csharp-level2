namespace TestConsole.Loggers
{
    interface ILogger
    {
        void Log(string message);
        void LogInfo(string message);
        void LogWarring(string message);
        void LogError(string message);
    }
}
