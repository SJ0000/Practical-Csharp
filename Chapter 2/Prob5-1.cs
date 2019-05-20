using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            if (String.Compare(str1, str2, true) == 0)
            {
                Console.WriteLine("T");
            }
            else
            {
                Console.WriteLine("F");
            }            
        }
    }
}