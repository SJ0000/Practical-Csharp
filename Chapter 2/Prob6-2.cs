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
            var books = new List<Book>{
               new Book{Title = "C# 프로그래밍의 상식", Price = 38000, Pages = 378},
               new Book{Title = "람다식과 LINQ의 비밀", Price = 25000, Pages = 312},
               new Book{Title = "원더풀 C# 라이프", Price = 29000, Pages = 385},
               new Book{Title = "독학 병렬처리 프로그래밍", Price = 48000, Pages = 464},
               new Book{Title = "구문으로 배우는 C# 입문", Price = 53000, Pages = 604},
               new Book{Title = "나도 할 수 있는 ASP.NET MVC", Price = 32000, Pages = 453},
               new Book{Title = "재미 있는 C# 프로그래밍 교실", Price = 25400, Pages = 348},
           };
           
           // 1
            var query1 = books.Where(b => b.Title == "원더풀 C# 라이프");
            foreach (var item in query1)
            {
                Console.WriteLine(item.Price + " " + item.Pages);
            }

            // 2
            var query2 = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(query2);

            // 3
            var query3 = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine(query3);

            // 4
            var query4 = books.FirstOrDefault(b => b.Price >= 40000);
            Console.WriteLine(query4.Title);

            // 5
            var query5 = books.Where(b => b.Price < 40000).Max(b => b.Pages);
            Console.WriteLine(query5);

            // 6
            var query6 = books.Where(b => b.Pages >= 400).OrderByDescending(b=> b.Price);
            foreach (var item in query6)
            {
                Console.Write(item.Title + " " + item.Price + " / ");
            }
            Console.WriteLine();


            // 7
            var query7 = books.Where(b => b.Title.Contains("C#")).Where(b => b.Pages <= 500);
            foreach (var item in query7)
            {
                Console.Write(item.Title + " / ");
            }
            Console.WriteLine();

        }
    }

    class Book
    {
        public string Title{ get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}