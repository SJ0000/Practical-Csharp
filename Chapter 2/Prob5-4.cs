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
            string s = "Novelist=김만중;BestWork=구운몽;Born=1687";
            var splits = s.Split(';');
            var dict = new Dictionary<string, string>(){
                {"Novelist","작가"},
                {"BestWork","대표작"},
                {"Born","출판년도"},
            };

            foreach (var item in splits)
            {
                var splitItem = item.Split('=');
                Console.WriteLine(dict[splitItem[0]] + " : " + splitItem[1]);
            }       
                
        }
    }
}