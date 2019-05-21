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
            var culture = new CultureInfo("ko-KR");
            culture.DateTimeFormat.Calendar = new KoreanCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(now);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            var dayName = culture.DateTimeFormat.GetDayName(now.DayOfWeek);

            Console.WriteLine("{0}/{1}/{2} {3}:{4}",now.Year,now.Month,now.Day,now.Hour,now.Minute);
            Console.WriteLine("{0}년{1}월{2}일 {3}시{4}분{5}초", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            Console.WriteLine(now.ToString("ggyyyy년m월d일",culture)+"("+dayName+")");
 
        }
    }
}