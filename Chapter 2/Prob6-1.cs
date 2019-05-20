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
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            // 1
            Console.WriteLine(numbers.Max());

            // 2
            for (int i = numbers.Length - 1; i >= numbers.Length - 2; i--)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            
            //3
            var query = numbers.Select(n => n.ToString());
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //4
            var query2 = numbers.OrderBy(n => n).Take(3);
            foreach (var item in query2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //5
            var query3 = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(query3);                            
        }
    }
}