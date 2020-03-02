using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>() { 
                { "four", 4 }, 
                { "two", 2 }, 
                { "one", 1 }, 
                { "three", 3 }
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair)
            {
                return pair.Value;
            });

            //a
            //var d = dict.OrderBy(pair => pair.Value);

            //b
            // Не понял задание =(



            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
