using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

namespace Study
{

    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;

            Console.WriteLine(NextDate(now, DayOfWeek.Sunday));
            Console.WriteLine(NextDate(now, DayOfWeek.Monday));
            Console.WriteLine(NextDate(now, DayOfWeek.Tuesday));
            Console.WriteLine(NextDate(now, DayOfWeek.Wednesday));
            Console.WriteLine(NextDate(now, DayOfWeek.Thursday));
            Console.WriteLine(NextDate(now, DayOfWeek.Friday));
            Console.WriteLine(NextDate(now, DayOfWeek.Saturday));


        }


        public static DateTime NextDate(DateTime date, DayOfWeek dayOfWeek)
        {
            //다음 특정 요일.
            int now = (int)date.DayOfWeek;
            int next = (int)dayOfWeek;
            var days = next - now;
            if (days <= 0)
            {
                days += 7;
            }
            //다음주의 특정요일
            if (now < next) days += 7;

            return date.AddDays(days);
        }

    }
}