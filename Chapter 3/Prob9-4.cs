using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {

            var src = @"C:\Users\Administrator\Desktop\srcdir";
            var dest = @"C:\Users\Administrator\Desktop\destdir";

            var di = new DirectoryInfo(src);
            var firstFile = di.GetFiles().Take(1).ToArray();

            File.Copy(src + "\\" + firstFile[0].Name, dest + "\\" + renameForCopy(firstFile[0].Name));

        }
        static string renameForCopy(string fileName)
        {
            var splits = fileName.Split('.');
            string name = splits[0];
            string extension = splits[1];
            return name + "_bak." + extension;
        }
    }
}