using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConsole.Extensions
{
    public static class FileInfoExtension
    {
        public static IEnumerable<string> GetLines(this FileInfo file)
        {
            using(var reader = file.OpenText())
            {
                while(!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
