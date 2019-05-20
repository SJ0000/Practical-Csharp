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
            int result;
            if (int.TryParse(str1,out result))
            {
                Console.WriteLine(result.ToString("#,0"));
            }
            else
            {
                Console.WriteLine(str1 + " is not number");
            }
            
        }
    }
}