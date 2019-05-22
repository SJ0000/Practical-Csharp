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
            var text = "abcba abd bfe as1sa 12321 7x9x7 45x2b6";
            var regex = new Regex(@"\b(\w)(\w)\w\2\1\b");
            var matches = regex.Matches(text);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }
        }
    }    
}