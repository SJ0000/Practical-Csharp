using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
    Person , Object 클래스에 Student는 대입이 가능하지만
    각자 클래스가 가지고 있는 속성에만 접근이 가능하다.
 *  ex) Person은 Student의 Name,Birthday,GetAge()만 접근할 수 있음
 */

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.Birthday = new DateTime(1993, 2, 23);
            st.Name = "SJ";
            st.Grade = 4;
            st.ClassNumber = 6;
            st.PrintStInfo();

            Person p = st;
            Object obj = st;
            Console.WriteLine(p.Name + p.Birthday + p.GetAge());
        }      

    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }

    public class Student : Person
    {
        public int Grade { get; set; }
        public int ClassNumber { get; set; }

        public void PrintStInfo()
        {
            Console.WriteLine(Name + " " + Birthday + " " + GetAge() + " " + Grade + " " + ClassNumber);
        }
    }


}
