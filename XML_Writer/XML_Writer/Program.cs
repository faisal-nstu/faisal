using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            //XMLWriter.WriteXML("Book-A", "001");
            //XMLWriter.WriteXML("Book-B", "002");
            //XMLWriter.ReadXML();



            //*********** XML Document class ***************
            
            XmlDocument xmlDoc1 = new XmlDocument();
            XmlNode rootNode = xmlDoc1.CreateElement("users");
            xmlDoc1.AppendChild(rootNode);

            XmlNode userNode1 = xmlDoc1.CreateElement("user");
            XmlAttribute attribute = xmlDoc1.CreateAttribute("age");
            attribute.Value = "42";
            userNode1.Attributes.Append(attribute);
            
            userNode1.InnerText = "John Doe";
            rootNode.AppendChild(userNode1);

            userNode1 = xmlDoc1.CreateElement("user");
            attribute = xmlDoc1.CreateAttribute("age");
            attribute.Value = "39";
            userNode1.Attributes.Append(attribute);
            userNode1.InnerText = "Beau Garett";
            rootNode.AppendChild(userNode1);

            xmlDoc1.Save(@"D:\test-doc.xml");

            // ************* READING ***************************
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\test-doc.xml");
            XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            foreach (XmlNode userNode in userNodes)
            {
                int age = int.Parse(userNode.Attributes["age"].Value);
                //userNode.Attributes["age"].Value = (age + 1).ToString();
                string name = userNode.InnerText;
                Console.WriteLine("Name: {0}\nAge: {1}", name, age);
            }
            //xmlDoc.Save(@"D:\test-doc.xml");  
            Console.ReadKey();
        }
    }
}
