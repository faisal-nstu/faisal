using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Writer
{
    public class XMLWriter
    {
        public class Book
        {
            public string title;
            public string ISBN;
        }


        public static void WriteXML(string bookName, string isbn)
        {
            Book overview = new Book();
            overview.title = bookName;
            overview.ISBN = isbn;
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\SerializationOverview.xml");
            writer.Serialize(file, overview);
            file.Close();
        }

        public static void ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"D:\SerializationOverview.xml");
            Book overview = new Book();
            overview = (Book)reader.Deserialize(file);

            Console.WriteLine(overview.title);
            Console.ReadKey();
        }
    }
}
