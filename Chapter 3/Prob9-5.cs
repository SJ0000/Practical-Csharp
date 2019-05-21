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
            var dir = @"C:\Users\Administrator\Desktop\sj";
            printFiles(dir);
        }
        static void printFiles(string dir)
        {
            var di = new DirectoryInfo(dir);
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            foreach (var item in fileSystems)
            {
                FileInfo fi;
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //Directory
                    printFiles(item.FullName);
                }
                else
                {
                    // File
                    fi = new FileInfo(item.FullName);
                    if (fi.Length >= 1024 * 1024) Console.WriteLine(fi.Name);
                }
            }
        }
    }
}