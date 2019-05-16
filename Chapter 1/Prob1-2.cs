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
            MyClass mycl = new MyClass();
            mycl.X = 20; mycl.Y = 20;
            MyStruct myst = new MyStruct();
            myst.X = 5; myst.Y = 5;

            PrintObjects(mycl, myst);

        }

        static void PrintObjects(MyClass myc, MyStruct mys)
        {
            myc.X *= 2; myc.Y *= 2; mys.X *= 2; mys.Y *= 2;
            Console.WriteLine(myc.X + " " + myc.Y + " " + mys.X + " " + mys.Y);
            return;
        }

    }

    class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    struct MyStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}