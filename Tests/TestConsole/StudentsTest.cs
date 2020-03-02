using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestConsole.Extensions;

namespace TestConsole
{
    internal static class StudentsTest
    {
        public static void Run()
        {
            const string student_name = "Names.txt";
            var file_with_name = new FileInfo(student_name);

            var rnd = new Random();
            var dekanat = new Dekanat();

            for(var i = 0; i <10; i++)
            {
                dekanat.Add(new StudentsGroup { Name = $"Group {i + 1}" });
            }

            foreach (var line in file_with_name.GetLines())
            {
                if (string.IsNullOrEmpty(line)) continue;
                var components = line.Split(' ');
                if (components.Length < 2) continue;

                var student = new Student
                {
                    LastName = components[0],
                    FirstName = components[1],
                    Ratings = rnd.GetRandomIntValues(20, 3, 6).ToList()
                };
                dekanat.Add(student);
            }

            //IEnumerable<Student> students_enum = dekanat;
            //IQueryable<Student> students_query = students_enum.AsQueryable();

            //var sStudents = Enumerable.Range(1, 100)
            //    .Select(i => new Student
            //    {
            //        FirstName = $"Student {i}"
            //    });
            //foreach(var student in sStudents)
            //{
            //    Console.WriteLine(student);
            //}

            var bStudents = dekanat.Where(s => s.AvgRating > 4);
            foreach(var bs in bStudents)
            {
                Console.WriteLine(bs);
            }
            var bCount = bStudents.Count();
            
            bStudents = dekanat.Where(s => s.AvgRating < 4);
            foreach (var bs in bStudents)
            {
                Console.WriteLine(bs);
            }
            var lCount = bStudents.Count();
            Console.WriteLine("{0} {1}", bCount, lCount);

            //var nameLengths = file_with_name.GetLines()
            //    .Select(str => str.Split(' '))
            //    .Select(strs => new KeyValuePair<string , int>(strs[1], strs[1].Length))
            //    .Where(v => v.Value > 4)
            //    .OrderBy(v => v.Value)
            //    .ToArray();

            IEnumerable<Student> students = dekanat;
            IEnumerable<StudentsGroup> groups = dekanat.Groups;

            var students_groups = students
                .Join(
                    groups, 
                    stud => stud.GroupId, 
                    grp => grp.Id,
                    (stud, grp) => new {Student = stud, Group = grp}
                 )
                .Where(s => s.Student.AvgRating > 4);

            foreach (var stdGrp in students_groups)
            {
                Console.WriteLine("{0} == {1}", stdGrp.Student, stdGrp.Group);
            }

            var students_group_dict = students_groups
                .GroupBy(
                    g => g.Group.Name
                )
                .ToDictionary(
                    g => g.Key, 
                    g => g.Select(v => v.Student.LastName));
        }
    }
}
