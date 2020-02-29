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

            Console.ReadKey();
        }
    }

}
