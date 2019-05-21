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
            var texts = new[]{
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
                "Alphabet ABCD",
            };
            //time이 포함된 문자열, time의 시작위치 모두 출력, 대소문자 구분X
            var regex = new Regex(@"(T|t)(I|i)(M|m)(E|e)");
            Match match;
            foreach (var text in texts)
            {   
                match = Regex.Match(text,@"(T|t)(I|i)(M|m)(E|e)");
                if (match.Success)
                {   
                    Console.WriteLine("{0} , index : {1}", text, match.Index);
                }
            }
        }
    }    
}