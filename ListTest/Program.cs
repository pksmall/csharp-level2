using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //a
            Console.WriteLine($"Коллекция целых чисел");
            List<int> integerList = new List<int>() { 
                2, 1, 2, 3, 4, 54, -12, 3, 4, 2, 1, 4, 7, 35, -16, 13, 4, 
            };
            Dictionary<int, int> uniqInteger = new Dictionary<int, int>();

            foreach (int i in integerList)
            {
                if (uniqInteger.ContainsKey(i))
                {
                    uniqInteger[i]++;
                }
                else
                {
                    uniqInteger[i] = 1;
                }
            }

            foreach (KeyValuePair<int, int> p in uniqInteger)
            {
                Console.WriteLine($"Элемент {p.Key} встречается {p.Value} раз");
            }
            Console.WriteLine();

            //b
            Console.WriteLine($"Коллекция строк");
            List<string> stringList = new List<string>() { 
                "adf", "dgs", "asd", " adf", "0afs9", "gfd23", "adf", "asdf" 
            };

            var uniqGeneric = stringList.UniqCount();

            foreach (var p in uniqGeneric)
            {
                Console.WriteLine($"Элемент {p.Key} встречается {p.Value} раз");
            }
            Console.WriteLine();

            // с
            Console.WriteLine($"Коллекция строк с использованием Linq");

            var uniqLinq = stringList.GroupBy(p => p).Select(g => new { g.Key, Count = g.Count() });
            foreach (var p in uniqLinq)
            {
                Console.WriteLine($"Элемент {p.Key} встречается {p.Count} раз");
            }

            Console.ReadKey();
        }
    }
}
