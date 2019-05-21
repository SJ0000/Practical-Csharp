using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace Study
{   
    class Program
    {
        static void Main(string[] args)
        {
            var tw = new TimeWatch();

            tw.Start();
            // 처리
            for (int i = 0; i < 1000000; i++)
            {

            }
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            Console.WriteLine("처리 시간은 {0}밀리초였습니다.",duration.TotalMilliseconds);
        }
    }
    class TimeWatch
    {

        DateTime diff;
        public void Start()
        {
            diff = DateTime.Now;
        }

        public TimeSpan Stop()
        {
            return DateTime.Now - diff;
        }
    }
}