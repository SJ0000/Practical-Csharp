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
            var strs = new string[]{
                "070-7212-1234","010-xxxx-yyyy","090-123-1237","080-1234-777","080-1234-12x",
            };

            foreach (var str in strs)
            {
                Console.WriteLine("{0} is {1}", str, isPhoneNumber(str));
            }
        }

        static bool isPhoneNumber(string str)
        {
            var regex = new Regex(@"^(0[7-9]0-\d{4}-\d{4})$");
            return regex.IsMatch(str);            
        }
    }    
}