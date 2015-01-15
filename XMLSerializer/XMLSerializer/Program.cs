using System;

namespace XMLSerializer
{
    public class Program
    {

        static void Main(string[] args)
        {
            WriteXML();
            ReadXML();
            Console.ReadKey();
        }


        public class Book
        {
            public String title;
            public string isbn;
            public int price;

        }


        public static void WriteXML()
        {
            Book overview = new Book();
            overview.title = "Serialization Overview";
            overview.isbn = "ASD-4342";
            overview.price = 500;

            Book overview2 = new Book();
            overview2.title = "DeSerialization Overview";
            overview2.isbn = "BSD-4342";
            overview2.price = 400;


            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));

            System.IO.StreamWriter file = new System.IO.StreamWriter(
                @"d:\SerializationOverview.xml");
            writer.Serialize(file, overview);
            
            file.Close();
        }

        public static void ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"d:\SerializationOverview.xml");
            Book overview = new Book();
            overview = (Book)reader.Deserialize(file);

            Console.WriteLine("\t" + overview.title);
            Console.WriteLine("\t" + overview.isbn);
            Console.WriteLine("\t" + overview.price);

        }




    }
}
