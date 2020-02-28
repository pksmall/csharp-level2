using System;

namespace TestEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var employees = new Employee[100];
            for (var i = 0; i < employees.Length; i++)
            {
                if (i % 2 == 0)
                {
                    employees[i] = new FixedEmployee(
                        $"Student {i + 1}".ToString(), 
                        random.Next(22, 65).ToString(),
                        random.Next(1000, 5000)
                    );
                } else
                {
                    employees[i] = new TimeEmployee(
                        $"Student {i + 1}",
                        random.Next(22, 65).ToString(),
                        random.Next(25, 100)
                    );

                }
            }

            foreach(Employee item in employees)
            {
                Console.WriteLine("{0, -11} {0, -3} {1:f2}", item.GetName(), item.GetAge(),  item.CalulateSallay());
            }

            Console.ReadKey();
        }
    }
}
