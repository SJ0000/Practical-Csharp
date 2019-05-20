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
            YearMonth[] yms = new YearMonth[]{
                new YearMonth(201,3),
                new YearMonth(201,11),
                new YearMonth(201,2),
                new YearMonth(1993,7),
                new YearMonth(1927,12),
            };

            foreach (var item in yms)
            {
                Console.WriteLine(item.ToString());
            }

            var first = YearMonth.GetFirst21Century(yms);

            if (first != null)
            {
                Console.WriteLine("First 21 Century is " + first.ToString());
            }
            else
            {
                Console.WriteLine("NO 21 Century YEARMONTH");
            }

            var query = yms.Select(ym => ym.AddOneMonth()).ToArray();

            Console.WriteLine("After 1 Month");

            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class YearMonth
    {
        public int Year { get; private set; } // 읽기전용
        public int Month { get; private set; }

        bool Is21Century
        {
            get
            {
                return (2001 <= Year && Year <= 2100);
            }
        }

        public YearMonth(int year, int month)
        {
            this.Year = year;
            this.Month = month;
        }
        public YearMonth AddOneMonth()
        {
            int afterMonth = Month + 1;
            return new YearMonth(Year += (afterMonth / 13), (afterMonth % 13) == 0 ? 1 : afterMonth % 13);
        }
        public override string ToString()
        {
            return Year + "년 " + Month + "월";
        }

        public static YearMonth GetFirst21Century(YearMonth[] yms)
        {
            foreach (var item in yms)
            {
                if (item.Is21Century) return item;
            }
            return null;
        }

    }
}