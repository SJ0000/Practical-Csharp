using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Study
{
    class Program
    {   
        static void Main(string[] args)
        {
            var category = Library.Categories;
            var books = Library.Books;

            // 2
            var maxPrice = books.Max(b => b.Price);
            var query2 = books.Where(b => b.Price == maxPrice);
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

            // 3
            var query3 = books.GroupBy(b => b.PublishedYear);
            foreach (var item in query3)
            {
                Console.WriteLine(string.Format("{0}�� => {1}��", item.Key,item.Count()));
            }

            // 4
            var query4 = books.OrderByDescending(b => b.PublishedYear).ThenByDescending(b => b.Price);
            foreach (var b in query4)
            {
                Console.WriteLine(b);
            }

            // 5
            var query5 = books.Where(b => b.PublishedYear == 2016).Join(category, b => b.CategoryId, c => c.Id,
                (b, c) => c.Name).Distinct();
            foreach (var name in query5)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();

            // 6
            var query6 = books.GroupBy(b => b.CategoryId);
            foreach (var grouped in query6)
            {
                var categoryName = grouped.Join(category, b => b.CategoryId, c => c.Id,
                     (b, c) => c.Name).First();
                Console.WriteLine("#" + categoryName);
                foreach (var b in grouped)
                {
                    Console.WriteLine(" " + b.Title);
                }
            }

            // 7
            var query7 = books.GroupBy(b => b.PublishedYear);
            foreach (var grouped in query6)
            {
                var year = grouped.First().PublishedYear;
                Console.WriteLine("#" + year + "��");
                foreach (var b in grouped)
                {
                    Console.WriteLine(" " + b.Title);
                }
            }

            // 8
            // category�� �������� books�� �׷�ȭ
            // books.GroupJoin(....) �̸� books�� �������� category�� ����ִ� ��ü���� �׷�ȭ.
            var query8 = category.GroupJoin(books, c => c.Id, b => b.CategoryId,
                (c, b) => new { Name = c.Name, Count = b.Count() }); // (c,b) ���� c�� key�� ��ü, b�� �׷�

            foreach (var item in query8)
            {
                if (item.Count >= 4) Console.Write(item.Name+" ");
            }
            Console.WriteLine();
        }
    }   

    // 1
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Id:{0}, �о� �̸�:{1}", Id, Name);
        }
    }

    public class Book
    {

        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }

        public override string ToString()
        {
            return string.Format("���࿬��:{0}, �о�:{1}, ����:{2}, ����:{3}", PublishedYear, CategoryId, Price, Title);
        }
    }

    public static class Library
    {
        public static IEnumerable<Category> Categories { get; private set; }

        public static IEnumerable<Book> Books { get; private set; }

        static Library()
        {
            Categories = new List<Category> {
                new Category { Id = 1, Name = "Development"  },
                new Category { Id = 2, Name = "Server"  },
                new Category { Id = 3, Name = "Web Design"  },
                new Category { Id = 4, Name = "Windows"  },
                new Category { Id = 5, Name = "Application"  },
            };

            Books = new List<Book> {
                new Book { Title = "Writing C# Solid Code", CategoryId = 1, Price = 25000, PublishedYear = 2016 },
                new Book { Title = "C# ������ħ", CategoryId = 1, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "Visual C# �ٽ� �Թ�", CategoryId = 1, Price = 27800, PublishedYear = 2016 },
                new Book { Title = "�������� ���� C# Book", CategoryId = 1, Price = 24000, PublishedYear = 2016 },
                new Book { Title = "TypeScript �ʱ� ����", CategoryId = 1, Price = 25000, PublishedYear = 2015 },
                new Book { Title = "PowerShell ���� ������", CategoryId = 2, Price = 42000, PublishedYear = 2013 },
                new Book { Title = "SQL Server ���� �Թ�", CategoryId = 2, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "IIS �� ���� ��� ���̵�", CategoryId = 2, Price = 31800, PublishedYear = 2015 },
                new Book { Title = "����ũ�μ���Ʈ Azure ���� ����", CategoryId = 2, Price = 48000, PublishedYear = 2016 },
                new Book { Title = "�� ������ ���� HTML5 & CSS", CategoryId = 3, Price = 28000, PublishedYear = 2013 },
                new Book { Title = "HTML5 �� ����", CategoryId = 3, Price = 38000, PublishedYear = 2015 },
                new Book { Title = "CSS ������ ����", CategoryId = 3, Price = 35500, PublishedYear = 2015 },
                new Book { Title = "Windows10���� ��̰� ���ϱ�", CategoryId = 4, Price = 22800, PublishedYear = 2016 },
                new Book { Title = "Windows10�� ����� �Ǵ� ��", CategoryId = 4, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Windows10�� ����� �Ǵ� ��2", CategoryId = 4, Price = 20800, PublishedYear = 2016 },
                new Book { Title = "Windows10 ���� �ٷ��� �Թ���", CategoryId = 4, Price = 23000, PublishedYear = 2015 },
                new Book { Title = "�ʹ� ���� Windows10 �Թ�", CategoryId = 5, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Word Excel ���� ���÷���Ʈ ������", CategoryId = 5, Price = 26000, PublishedYear = 2016 },
                new Book { Title = "��̰� ���� Excel �ʱ���", CategoryId = 5, Price = 28000, PublishedYear = 2015 },
            };
        }
    }
}