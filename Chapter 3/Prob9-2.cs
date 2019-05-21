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
            var in_filePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\Abbreviations.txt";
            var out_filePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\NewText.txt";

            if (File.Exists(in_filePath))
            {
                using (var inStream = new FileStream(in_filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                using (var outStream = new FileStream(out_filePath, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    using (var reader = new StreamReader(inStream))
                    using (var writer = new StreamWriter(outStream))
                    {
                        writer.WriteLine("วเน๘ศฃ");
                        string copy = reader.ReadToEnd();
                        writer.Write(copy);
                    }
                }
            }
        }
    }
}