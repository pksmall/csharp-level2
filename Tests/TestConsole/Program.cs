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
        static void Main(string[] args)
        {
            /*var sArrayList = new ArrayList();

            sArrayList.Add(42);
            sArrayList.Add(new object());
            sArrayList.Add(3.141592);
            sArrayList.Add("hELLOWorld");

            for(var i = 0; i <sArrayList.Count; i++)
            {
                var value = sArrayList[i];
                if (value is int)
                {
                    Console.WriteLine("Int: {0}", (int)value);
                } else if (value is string)
                {
                    Console.WriteLine("Str: {0}", (string)value);
                } else if (value is double)
                {
                    Console.WriteLine("Dbl: {0}", (double)value);
                }
            }*/

            List<Student> students = new List<Student>();
            students.Capacity = 90;

            for (var i = 0; i < 45; i++)
            {
                students.Add(new Student());
            }

            var student_to_add = new Student[20];
            for (var i = 0; i < student_to_add.Length; i++)
            {
                student_to_add[i] = new Student();
            }
            students.AddRange(student_to_add);

            students.Capacity = students.Count;

            var nsList = new List<Student>(student_to_add);
            students.RemoveAt(5);
            var numList = new List<int>(1000);
            for (var i = 0; i < numList.Capacity; i++)
            {
                numList.Add(i + 72);
            }
            var vIdex = numList.BinarySearch(712);

            var strList = new List<string>(1000);
            for (var i = 0; i < numList.Capacity; i++)
            {
                strList.Add($"Message {i + 21}");
            }
            strList.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2, s1));

            var sIdex = strList.BinarySearch("Message 712");

            //var sArray = strList.ToArray():
            var sArray = new string[strList.Count];
            strList.CopyTo(sArray, 0);

            //strList.ForEach(PrintString);

            //const string dDirName = "../../";
            //var tLines = DataDirectoryProcessor.GetTotalLinesCountStack(dDirName);
            //var tLines = DataDirectoryProcessor.GetTotalLinesCountQueue(dDirName);
            //Console.WriteLine("Total number: {0}", tLines);

            var tString = new string[] { "Hello world!", "123", "1231QWEWE-" };

            Dictionary<string, int> strIntDict = new Dictionary<string, int>();
            strIntDict.Add("ASD", 1024);
            for(var i = 0; i < tString.Length; i++)
            {
                strIntDict.Add(tString[i], tString[i].Length);
            }
            foreach(KeyValuePair<string, int> value in strIntDict)
            {
                Console.WriteLine("{0} -- {1}", value.Key, value.Value);
            }

            strIntDict.Remove("123");

            int str_123_len3;
            if (strIntDict.TryGetValue("123", out str_123_len3))
            {
                Console.WriteLine(str_123_len3);
            }
            strIntDict["123"] = 123;
            if (strIntDict.TryGetValue("123", out str_123_len3))
            {
                Console.WriteLine(str_123_len3);
            }

            StudentsTest.Run();

            Console.ReadKey();
        }

        private static void PrintString(string str) => Console.WriteLine("Str = " + str);
    }
}
