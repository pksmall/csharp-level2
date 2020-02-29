using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Extensions
{
    static class RandomExtension
    {
        public static IEnumerable<int> GetRandomIntValues(this Random rnd, int count, int min, int max)
        {
            for(var i = 0; i < count; i++)
            {
                yield return rnd.Next(min, max);
            }
        }
        public static T NextValue<T>(this Random rnd, params T[] Variants)
        {
            return Variants[rnd.Next(0, Variants.Length)];
        }
    }
}
