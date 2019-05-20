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
            string s = "Jackdaws love my big sphinx of quartz";
            Console.WriteLine("1) " + s.Count(c => c == ' '));
            Console.WriteLine("2) " + s.Replace("big", "small"));
            Console.WriteLine("3) " + s.Split(' ').Length);
            var query = s.Split(' ').Where(word => word.Length <= 4); // select�� true,false������ where�� ���ǿ� �´°� ����
            Console.Write("4) ");
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            var sb = new StringBuilder();
            foreach (var item in s.Split(' '))
            {
                sb.Append(item);
                sb.Append(' ');
            }
            Console.WriteLine("5) " + sb.ToString());

        }
    }
}