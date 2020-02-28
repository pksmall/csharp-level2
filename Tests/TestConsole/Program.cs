using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestConsole.Loggers;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*            TraceLogger trace_logger = null;

                        try
                        {
                            trace_logger = new TraceLogger();
                            trace_logger.Log("123");
                        }
                        finally
                        {
                            trace_logger.Dispose();
                        }
            */
            using (var trace_logger = new TraceLogger())
                trace_logger.Log("123");

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

            /*            var log_message = ((ListLogger)logger).message;

                        foreach (var message in log_message)
                        {
                            Console.WriteLine($"{message}");
                        }
            */
            var crit_logger = new ListLogger();
            var student_logger = new Student { Name = "Ivanov" };
            var student_clone = (Student)student_logger.Clone();
           
            DoSomeCriticalWork(crit_logger);

            ((ILogger)student_logger).LogError("Error!");
            //student_logger.LogError("Some error");

            var random = new Random();
            var stundents = new Student[100];
            for (var i = 0; i < stundents.Length; i++)
            {
                stundents[i] = new Student { Name = $"Student {i + 1}", Height = random.Next(150, 211) };
            }
            Array.Sort(stundents);

            Trace.Flush();


            Console.ReadKey();
        }

        public static void DoSomeCriticalWork(ILogger log)
        {
            for (var i = 0; i < 10; i++)
            {
                log.LogInfo($"Do some very important wokr {i + 1}");
            }
        }
    }

    public class Student : ILogger, IComparable, ICloneable
    {
        private List<string> _message = new List<string>();
        public double Height { get; set; } = 175;
        public string Name { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();

        public void Log(string message)
        {
            Ratings.Add(message.Length);
            _message.Add(message);
        }

/*        public void LogError(string message)
        {
            Log("Error: " + message);
        }
*/
        void ILogger.LogError(string message)
        {
            Log("Error: " + message);
        }


        public void LogInfo(string message)
        {
            Log("Info: " + message);
        }

        public void LogWarring(string message)
        {
            Log("Warring: " + message);
        }

        public int CompareTo(object obj)
        {
            if(obj is Student)
            {
                var other_Student = (Student)obj;
                //return StringComparer.OrdinalIgnoreCase.Compare(Name, other_Student.Name);
                if (Height > other_Student.Height)
                {
                    return +1
                } else if (Height.Equals(other_Student.Height))
                {
                    return 0;
                } else
                {
                    return 1;
                }
            } else
            {
                if(obj is null)
                {
                    throw new ArgumentNullException(nameof(obj), "Try compare student to null ");
                }
                throw new ArgumentException(nameof(obj), "Try compare student to " + obj.GetType().Name);
            }
        }
        public override string ToString() => $"{Name} = {Height}";

        public object Clone()
        {
            /*var new_student = new Student
            {
                Name = Name,
                Height = Height,
                Ratings = new List<int>(Ratings)
            };*/

            var new_student = (Student)MemberwiseClone();
            new_student._message = new List<string>(_message);
            new_student.Ratings = new List<int>(Ratings);

            return new_student;
        }
    }
}
