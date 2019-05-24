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
                Console.WriteLine(string.Format("{0}년 => {1}권", item.Key,item.Count()));
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
                Console.WriteLine("#" + year + "년");
                foreach (var b in grouped)
                {
                    Console.WriteLine(" " + b.Title);
                }
            }

            // 8
            // category를 기준으로 books를 그룹화
            // books.GroupJoin(....) 이면 books를 기준으로 category에 들어있는 객체들을 그룹화.
            var query8 = category.GroupJoin(books, c => c.Id, b => b.CategoryId,
                (c, b) => new { Name = c.Name, Count = b.Count() }); // (c,b) 에서 c는 key로 객체, b는 그룹

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
            return string.Format("Id:{0}, 분야 이름:{1}", Id, Name);
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
            return string.Format("발행연도:{0}, 분야:{1}, 가격:{2}, 제목:{3}", PublishedYear, CategoryId, Price, Title);
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
                new Book { Title = "C# 개발지침", CategoryId = 1, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "Visual C# 다시 입문", CategoryId = 1, Price = 27800, PublishedYear = 2016 },
                new Book { Title = "구문으로 배우는 C# Book", CategoryId = 1, Price = 24000, PublishedYear = 2016 },
                new Book { Title = "TypeScript 초급 강좌", CategoryId = 1, Price = 25000, PublishedYear = 2015 },
                new Book { Title = "PowerShell 실전 레시피", CategoryId = 2, Price = 42000, PublishedYear = 2013 },
                new Book { Title = "SQL Server 완전 입문", CategoryId = 2, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "IIS 웹 서버 운용 가이드", CategoryId = 2, Price = 31800, PublishedYear = 2015 },
                new Book { Title = "마이크로소프트 Azure 서버 구축", CategoryId = 2, Price = 48000, PublishedYear = 2016 },
                new Book { Title = "웹 디자인 강좌 HTML5 & CSS", CategoryId = 3, Price = 28000, PublishedYear = 2013 },
                new Book { Title = "HTML5 웹 대백과", CategoryId = 3, Price = 38000, PublishedYear = 2015 },
                new Book { Title = "CSS 디자인 사전", CategoryId = 3, Price = 35500, PublishedYear = 2015 },
                new Book { Title = "Windows10으로 즐겁게 일하기", CategoryId = 4, Price = 22800, PublishedYear = 2016 },
                new Book { Title = "Windows10의 고수가 되는 법", CategoryId = 4, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Windows10의 고수가 되는 법2", CategoryId = 4, Price = 20800, PublishedYear = 2016 },
                new Book { Title = "Windows10 쉽게 다루자 입문편", CategoryId = 4, Price = 23000, PublishedYear = 2015 },
                new Book { Title = "너무 쉬운 Windows10 입문", CategoryId = 5, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Word Excel 실전 템플레이트 모음집", CategoryId = 5, Price = 26000, PublishedYear = 2016 },
                new Book { Title = "즐겁게 배우는 Excel 초급편", CategoryId = 5, Price = 28000, PublishedYear = 2015 },
            };
        }
    }
}