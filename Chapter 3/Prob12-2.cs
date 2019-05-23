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
            Novelist novelist;
            using (var reader = XmlReader.Create("novelist.xml"))
            {
                var xRoot = new XmlRootAttribute();
                xRoot.ElementName = "novelist";
                xRoot.IsNullable = true;
                var serializer = new XmlSerializer(typeof(Novelist), xRoot);
                novelist = serializer.Deserialize(reader) as Novelist;
                Console.WriteLine(novelist);
            }
            // 2

            using (var stream = new FileStream("novelist.json", FileMode.Create, FileAccess.Write))
            {
                var setting = new DataContractJsonSerializerSettings();
                setting.DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ");
                var serializer = new DataContractJsonSerializer(novelist.GetType(), setting);
                serializer.WriteObject(stream, novelist);
            }
        }
    }

    [DataContract(Name = "novelist")]
    public class Novelist
    {
        [XmlElement("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement("birth")]
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }

        [XmlArray("masterpieces")]
        [XmlArrayItem("title", typeof(string))]
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var m in Masterpieces)
            {
                sb.Append(m + " ");
            }
            return string.Format("Name : {0}\nBirth : {1}\nMasterPieces : {2}", Name, Birth.ToShortDateString(), sb);
        }
    }
}