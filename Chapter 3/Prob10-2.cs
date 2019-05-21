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
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\dest.txt";
            var lines = File.ReadAllLines(filePath);

            //세 문자 이상, 숫자만
            var regex = new Regex(@"^(\d{3,})$");
            foreach (var line in lines)
            {
                if (regex.IsMatch(line)) Console.WriteLine(line);
            }
        }
    }
}