using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestConsole.Loggers;

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
                    Ratings = GetRandomRatings(rnd, 20, 50)
                });
            }

            const string students_data_file = "student.csv";
            dekanat.SaveToFile(students_data_file);

            var dekanat2 = new Dekanat();
            dekanat2.LoadFromFile(students_data_file);


            Console.ReadKey();
        }
    }

}
