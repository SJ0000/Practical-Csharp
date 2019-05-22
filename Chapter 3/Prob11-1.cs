using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Study
{   
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\Sample.xml";
            var xdoc = XDocument.Load(filePath);
            var xelements = xdoc.Root.Elements();

            // 1

            foreach (var xSports in xelements)
            {
                var xName = xSports.Element("name");
                var xChName = xName.Attribute("chinese");
                var xTeamMembers = xSports.Element("teammembers");
                Console.WriteLine("{0} {1} {2}", xName.Value, xChName.Value, xTeamMembers.Value);
            }
            
            // 2
            var xFirstPlayeds = xdoc.Root.Descendants("firstplayed").ToArray();
            foreach (var item in xFirstPlayeds)
            {
                Console.WriteLine(item.Value);
            }

            // 3
            var maxTeamMember = xelements.Max(xSports => int.Parse(xSports.Element("teammembers").Value));
            Console.WriteLine(maxTeamMember);

            // 4
            var newElement = new XElement("ballsport",
                new XElement("name", "√‡±∏", new XAttribute("chinese", "ıÌœπ")),
                new XElement("teammembers", 11),
                new XElement("firstplayed", 1863));

            xdoc.Root.Add(newElement);

            foreach (var xSports in xelements)
            {
                var xName = xSports.Element("name");
                var xChName = xName.Attribute("chinese");
                var xTeamMembers = xSports.Element("teammembers");
                var xFirstPlayed = xSports.Element("firstplayed");
                Console.WriteLine("{0} {1} {2} {3}", xName.Value, xChName.Value, xTeamMembers.Value, xFirstPlayed.Value);
            }
        }
    }    
}