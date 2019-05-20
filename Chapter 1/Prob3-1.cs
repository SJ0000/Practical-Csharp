using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            Console.WriteLine(numbers.Exists(n => (n / 8 == 0 || n / 9 == 0)));
            numbers.ForEach(n => Console.Write(n / 2.0 + " "));
            Console.WriteLine();
            var query = numbers.Where(n => n >= 50).ToArray();
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            var query2 = numbers.Select(n => n *= 2);
            foreach (var item in query2)
            {
                Console.Write(item + " ");
            }
        }
    }
}