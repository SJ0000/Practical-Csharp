using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Study
{   

    class Program
    {
        static void Main(string[] args)
        {
            Abbreviations ab = new Abbreviations();

            Console.WriteLine(ab.Count);
            ab.Remove("PKO");
            Console.WriteLine(ab.Count);

            var query = ab.FindLen(3);
            foreach(var item in query){
                Console.WriteLine(item.Key + "=" + item.Value);
            }
        }
    }

    class Abbreviations
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public int Count
        {
            get
            {
                return _dict.Count();
            }
        }

        public Abbreviations()
        {
            var lines = File.ReadAllLines(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Study\Study\Abbreviations.txt",Encoding.Default);
            _dict = lines.Select(line => line.Split('=')).ToDictionary(x => x[0], x => x[1]);
        }

        public void Add(string abbr, string ko)
        {
            _dict[abbr] = ko;
        }

        //indexer
        public string this[string abbr]
        {
            get
            {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }

        public string ToAbbreviation(string ko)
        {
            return _dict.FirstOrDefault(x => x.Value == ko).Key;
        }

        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring)
        {
            foreach (var item in _dict)
            {
                if (item.Value.Contains(substring)) yield return item;
            }
        }

        public bool Remove(string abbr)
        {
            if (_dict.ContainsKey(abbr))
            {
                _dict.Remove(abbr);
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<KeyValuePair<string, string>> FindLen(int len)
        {
            foreach (var item in _dict)
            {
                if (item.Key.Length == len) yield return item;
            }
        }
    }
}