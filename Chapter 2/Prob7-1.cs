using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Study
{
    // Dictionary<K,V> 는 정렬 안되어 있음.
    // SortedDictionary<K,V> 는 KEY를 기준으로 오름차순 정렬되어 나타남.

    class Program
    {
        static void Main(string[] args)
        {
            string str = "Cozy lummox gives smart squid who asks for job pen123";
            var upperStr = str.ToUpper().Replace(" ", "");

            // 1

            var checker = new Dictionary<char, int>();

            foreach (var ch in upperStr)
            {
                if ('A' <= ch && ch <= 'Z')
                {
                    if (!checker.ContainsKey(ch))
                    {
                        checker.Add(ch, 1);
                    }
                    else
                    {
                        checker[ch] = checker[ch] + 1;
                    }
                }
            }
            foreach (var item in checker.OrderBy(kv => kv.Key))
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            // 2
            var checker2 = new SortedDictionary<char, int>();
            foreach (var ch in upperStr)
            {
                if ('A' <= ch && ch <= 'Z')
                {
                    if (!checker2.ContainsKey(ch))
                    {
                        checker2.Add(ch, 1);
                    }
                    else
                    {
                        checker2[ch] = checker2[ch] + 1;
                    }
                }
            }
            foreach (var item in checker2)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

        }

    }
}