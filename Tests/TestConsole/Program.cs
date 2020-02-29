using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using TestConsole.Loggers;
using TestConsole.Extensions;

namespace TestConsole
{
    static class Program
    {
        private static List<int> GetRandomRatings(Random rnd, int countMin, int countMax)
        {
            var count = rnd.Next(countMin, countMax + 1);
            var result = new List<int>(count);

            for (var i = 0; i < count; i++)
            {
                result.Add(rnd.Next(1, 13));
            }

            return result;
        }

        static void Main(string[] args)
        {
            var dekanat = new Dekanat();

            var rnd = new Random();
            for (var i = 0; i < 100; i++)
            {
                dekanat.Add(new Student
                {
                    Name = $"Student {i + 1}",
                    Ratings = rnd.GetRandomIntValues(20, 1, 13).ToList()   //GetRandomRatings(rnd, 20, 50)
                }) ;
            }

            const string students_data_file = "student.csv";
            dekanat.SaveToFile(students_data_file);

            var dekanat2 = new Dekanat();
            dekanat2.LoadFromFile(students_data_file);

            foreach (var std in dekanat2)
            {
                Console.WriteLine(std);
            }

            var avg_rating = dekanat2.Average(s => s.AvgRating);
            var sum_avg_rating = dekanat2.Sum(s => s.AvgRating);
            Console.WriteLine($"{avg_rating:0.##} {sum_avg_rating:0.##}");

            var rnd_student_name = rnd.NextValue("Ivanov", "Petrov", "Sidorov");
            var random_rating = rnd.NextValue(2, 3, 4, 5);

            /*  
                StudentProcessor processor = new StudentProcessor(GetIndexedStudentName);
                StudentProcessor processor = GetIndexedStudentName;

                var index = 0;
                foreach(var s in dekanat2)
                {
                    Console.WriteLine(processor(s, index++));
                }

                Console.ReadKey();

                processor = GetAvgStudentRating;
                index = 0;
                foreach (var s in dekanat2)
                {
                    Console.WriteLine(processor(s, index++));
                }
            */

            /*      
                ProcessStudents(dekanat2, GetIndexedStudentName);
                Console.ReadKey();
                ProcessStudents(dekanat2, GetAvgStudentRating);
            */
            //ProcessStudentsStandard(dekanat2, PrintStudent);

            var metrics = GetStudentsMetrics(dekanat2, std => std.Name.Length + (int)(std.AvgRating * 10));
            Console.ReadKey();
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("Student: {0}", student.Name);
        }

        public static void ProcessStudentsStandard(IEnumerable<Student> students, Action<Student> action)
        {
            foreach (var s in students)
            {
                action(s);
            }
        }

        public static int[] GetStudentsMetrics(IEnumerable<Student> student, Func<Student, int> GetMetrics)
        {
            var result = new List<int>();
            foreach(var cstd in student)
            {
                result.Add(GetMetrics(cstd));
            }
            return result.ToArray();
        }

        public static void ProcessStudents(IEnumerable<Student> students, StudentProcessor processor)
        {
            var index = 0;
            foreach (var s in students)
            {
                Console.WriteLine(processor(s, index++));
            }
        }
        private static string GetIndexedStudentName(Student student, int index)
        {
            return $"{student.Name}[{index}]";
        }

        public static string GetAvgStudentRating(Student student, int index)
        {
            return $"[{index}]:{student.Name} - {student.AvgRating}";
        }
    }

    internal delegate string StudentProcessor(Student student, int index);
}
