using System;
using System.Collections.Generic;

namespace TestConsole.Loggers
{
    public class ListLogger : Logger
    {
        private readonly List<string> _messages = new List<string>();
        public string[] message => _messages.ToArray();

        public override void Log(string message)
        {
            _messages.Add($"({DateTime.Now}{message}");
        }
    }

}
