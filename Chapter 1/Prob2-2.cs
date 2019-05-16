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
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(InchToMeter(i));
            }
        }

        static double InchToMeter(int inch)
        {
            return (double)inch * 0.0254;
        }
    }
}