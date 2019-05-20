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
            string s = "Novelist=�踸��;BestWork=�����;Born=1687";
            var splits = s.Split(';');
            var dict = new Dictionary<string, string>(){
                {"Novelist","�۰�"},
                {"BestWork","��ǥ��"},
                {"Born","���ǳ⵵"},
            };

            foreach (var item in splits)
            {
                var splitItem = item.Split('=');
                Console.WriteLine(dict[splitItem[0]] + " : " + splitItem[1]);
            }       
                
        }
    }
}