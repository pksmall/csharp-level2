namespace TestConsole.Loggers
{
    public class FileLogger : Logger
    {
        private int _index;

        public string filePath { get; }

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public override void Log(string message)
        {
            System.IO.File.AppendAllText(filePath, $"{++_index}:{message}\r\n");
        }
    }

}
