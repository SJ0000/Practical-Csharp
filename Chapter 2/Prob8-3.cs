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
            // ó��
            for (int i = 0; i < 1000000; i++)
            {

            }
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            Console.WriteLine("ó�� �ð��� {0}�и��ʿ����ϴ�.",duration.TotalMilliseconds);
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