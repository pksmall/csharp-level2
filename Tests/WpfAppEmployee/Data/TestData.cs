using System;
using System.Collections.Generic;
using System.Linq;
using WpfAppEmployee.Models;

namespace WpfAppEmployee.Data
{
    class TestData
    {
        static Random random = new Random();

        public static List<Department> Departments { get; } = Enumerable.Range(1, 5)
            .Select(i => new Department
            {
                DepId = i,
                DepName = $"Department {i}"
            }).ToList();

        public static List<Employee> Employees { get; } = Enumerable.Range(1, 10)
            .Select(i => new Employee
            {
                Id = i,
                Name = $"Name {i}",
                SurName = $"Surname {i}",
                Patronymic = $"Patronymic {i}",
                DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 / 6 * (i + 18))),
                Department = Departments[random.Next(Departments.Count)].DepId
            }).ToList();
    }
}
