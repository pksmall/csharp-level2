namespace TestConsole.Loggers
{
    public abstract class Logger
    {
        public abstract void Log(string message);

        public void LogInfo(string message)
        {
            Log($"[info]: {message}");
        }

        public void LogWarring(string message)
        {
            Log($"[warring]: {message}");
        }

        public void LogError(string message)
        {
            Log($"[error]: {message}");
        }
    }
}
