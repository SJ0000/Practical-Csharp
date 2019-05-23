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
            // 1

            var employee = new Employee()
            {
                Id = 2011,
                Name = "KIM",
                HireDate = DateTime.Now,
            };
            using (var writer = XmlWriter.Create("Employee.xml"))
            {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }

            using (var reader = XmlReader.Create("Employee.xml"))
            {
                var serializer = new XmlSerializer(typeof(Employee));
                var xmlToObj = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(xmlToObj);
            }

            // 2

            var employees = new Employee[]{
                new Employee(){ Id = 2011, Name = "KIM", HireDate = DateTime.Now},
                new Employee(){ Id = 2001, Name = "KANG", HireDate = DateTime.Now.AddDays(40)},
                new Employee(){ Id = 2041, Name = "LEE", HireDate = DateTime.Now.AddDays(362)},
            };

            using (var writer = XmlWriter.Create("Employees.xml"))
            {
                var serializer = new DataContractSerializer(employees.GetType());
                serializer.WriteObject(writer, employees);
            }
            
            // 3
            using (var reader = XmlReader.Create("Employees.xml"))
            {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var deserialized = serializer.ReadObject(reader) as Employee[];
                foreach (var item in deserialized)
                {
                    Console.WriteLine(item);
                }
            }

            // 4
            using (var stream = new FileStream("Employees.json", FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractJsonSerializer(employees.GetType());
                serializer.WriteObject(stream, employees);
            }
            var lines = File.ReadAllLines("Employees.json");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
    [DataContract(Name = "employee")]
    public class Employee
    {
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "HireDate")]
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}",Id,Name,HireDate.ToShortDateString());
        }
    }

}