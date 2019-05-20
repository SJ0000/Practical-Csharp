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
               new Book{Title = "C# ���α׷����� ���", Price = 38000, Pages = 378},
               new Book{Title = "���ٽİ� LINQ�� ���", Price = 25000, Pages = 312},
               new Book{Title = "����Ǯ C# ������", Price = 29000, Pages = 385},
               new Book{Title = "���� ����ó�� ���α׷���", Price = 48000, Pages = 464},
               new Book{Title = "�������� ���� C# �Թ�", Price = 53000, Pages = 604},
               new Book{Title = "���� �� �� �ִ� ASP.NET MVC", Price = 32000, Pages = 453},
               new Book{Title = "��� �ִ� C# ���α׷��� ����", Price = 25400, Pages = 348},
           };
           
           // 1
            var query1 = books.Where(b => b.Title == "����Ǯ C# ������");
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