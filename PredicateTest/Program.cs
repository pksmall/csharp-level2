using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateTest
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

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair)
            //{
            //    return pair.Value;
            //});

            //a
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine();

            //b
            int myMethod(KeyValuePair<string, int> pair)
            {
                return pair.Value;
            }
            Func<KeyValuePair<string, int>, int> predicate = myMethod;
            d = dict.OrderBy(predicate);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
