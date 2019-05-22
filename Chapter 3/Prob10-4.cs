using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Study
{   
    class Program
    {
        // prob 10-4
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\src.txt";
            var lines = File.ReadAllLines(filePath);

            var regex = new Regex(@"(V|v)ersion=""v4\.0""");
            using (var sw = new StreamWriter(filePath,false,Encoding.Default))
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(Regex.Replace(line, @"(V|v)ersion=""v4\.0""",@"version=""v5.0"""));
                }
            }
        }
    }    
}