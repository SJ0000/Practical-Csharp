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




        }
    }

    class YearMonth
    {
        int Year { get; private set; } // 읽기전용
        int Month { get; private set; }

        bool Is21Century
        {
            get
            {
                return (2001<=Year && Year <= 2100);
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
            return new YearMonth(Year += (afterMonth / 12), afterMonth % 12);
        }
        public override string ToString()
        {
            return Year+"년 "+Month+"월";
        }
    }
}