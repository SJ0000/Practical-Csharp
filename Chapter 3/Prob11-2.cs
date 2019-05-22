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

            string ch = "chinese";
            string kr = "korean";

            //하나만 바뀜.
            /*
            foreach (var oldElem in xelements)
            {
                var newElement = new XElement("word",
                    new XAttribute(ch, oldElem.Element(ch).Value),
                    new XAttribute(kr, oldElem.Element(kr).Value)
                    );
                oldElem.ReplaceWith(newElement);
            }
            */

            //정답.
            var newElements = xelements.Select(old => new XElement("word",
                    new XAttribute(ch, old.Element(ch).Value),
                    new XAttribute(kr, old.Element(kr).Value)
                    )
                 );

            var newRoot = new XElement("seoulku", newElements);
            newRoot.Save(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\Sample_new.xml");


     //       xdoc.Save(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\Sample_new.xml");     
        }
    }    
}