using System.Collections.Generic;

namespace ListTest
{
    public static class ExtensionsList
    {
        public static Dictionary<T, int> UniqCount<T>(this ICollection<T> self)
        {
            Dictionary<T, int> uniqDictionary = new Dictionary<T, int>();

            foreach (T i in self)
            {
                bool contains = false;
                contains  = uniqDictionary.ContainsKey(i);

                if (contains)
                {
                    uniqDictionary[i]++;
                }
                else
                {
                    uniqDictionary[i] = 1;
                }
            }
            return uniqDictionary;
        }
    }
}
