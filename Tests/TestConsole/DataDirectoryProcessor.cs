using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConsole
{
    public static class DataDirectoryProcessor
    {
        public static int GetTotalLinesCountStack(string DirectoryPath)
        {
            var dir = new DirectoryInfo(DirectoryPath);
            
            Stack<DirectoryInfo> dirToProc = new Stack<DirectoryInfo>();
            dirToProc.Push(dir);

            var total_lines = 0;
            while(dirToProc.Count > 0)
            {
                var procDir = dirToProc.Pop();

                foreach(var sub_dir in procDir.EnumerateDirectories())
                {
                    dirToProc.Push(sub_dir);
                }

                foreach(var file in procDir.EnumerateFiles("*.cs"))
                {
                    total_lines += GetLinesCount(file);
                }
            }
            return total_lines;
        }
        public static int GetTotalLinesCountQueue(string DirectoryPath)
        {
            var dir = new DirectoryInfo(DirectoryPath);

            Queue<DirectoryInfo> dirToProc = new Queue<DirectoryInfo>();
            dirToProc.Enqueue(dir);

            var total_lines = 0;
            while (dirToProc.Count > 0)
            {
                var procDir = dirToProc.Dequeue();

                foreach (var sub_dir in procDir.EnumerateDirectories())
                {
                    dirToProc.Enqueue(sub_dir);
                }

                foreach (var file in procDir.EnumerateFiles("*.cs"))
                {
                    total_lines += GetLinesCount(file);
                }
            }
            return total_lines;
        }

        private static int GetLinesCount(FileInfo file)
        {
            var lines_count = 0;
            foreach(var line in GetLines(file))
            {
                lines_count++;
            }
            return lines_count;
        }

        private static IEnumerable<string> GetLines(FileInfo file)
        {
            using (var reader = file.OpenText())
            {
                while(!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
