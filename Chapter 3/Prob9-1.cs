using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace Study
{   
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Administrator\githubRepos\Practical C# Example\Practical-Csharp\Chapter 2\Prob6-2.cs";

            // 1
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    int countClass = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line.Contains("class")) countClass++;
                    }
                    Console.WriteLine(countClass);
                }
            }

            // 2
            var lines = File.ReadAllLines(filePath);
            Console.WriteLine(lines.Count(s => s.Contains("class")));

            // 3
            var lines2 = File.ReadLines(filePath);
            Console.WriteLine(lines2.Count(s => s.Contains("class")));
        }
    }
    
}