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
            var names = new List<string>{
                "Seoul","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };
            var line = Console.ReadLine();
            Console.WriteLine(names.FindIndex(s => s == line));
            Console.WriteLine(names.Count(s => s.IndexOf('o') >= 0));
            var query = names.Where(s => s.IndexOf('o') >= 0).ToArray();
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            var query2 = names.Where(s => s.IndexOf('B') == 0).Select(s => s.Length);
            foreach (var item in query2)
            {
                Console.Write(item + " ");
            }
        }
    }
}