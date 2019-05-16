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
            NewSpace.Product pulbbang = new NewSpace.Product(98, "PULBBANG", 210);
            Console.WriteLine(pulbbang.getPriceIncludingTax());   
        }
    }
}

namespace NewSpace
{

    public class Product
    {

        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(int code, string name, int price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        public int getTax()
        {
            return (int)(Price * 0.08);
        }

        public int getPriceIncludingTax()
        {
            return Price + getTax();
        }
    }

}
