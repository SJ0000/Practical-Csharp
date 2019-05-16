using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
    Person , Object Ŭ������ Student�� ������ ����������
    ���� Ŭ������ ������ �ִ� �Ӽ����� ������ �����ϴ�.
 *  ex) Person�� Student�� Name,Birthday,GetAge()�� ������ �� ����
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
