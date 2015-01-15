using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
// ************************************************************************************
// ****************  Normal Dictionary ************************************************
// ************************************************************************************

            //Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
            //stateDictionary.Add("Bangladesh", "dhaka");
            //stateDictionary.Add("Egypt", "kairo");

            //Console.WriteLine(stateDictionary["Bangladesh"]);
            //Console.WriteLine(stateDictionary["Egypt"]);

// ************************************************************************************
// ****************  Object Dictionary ************************************************
// ************************************************************************************

            Dictionary<int, Dicto> dictoDictionary = new Dictionary<int, Dicto>();
            Dicto aDicto = new Dicto("A Dicto", 1, "Small");
            Dicto bDicto = new Dicto("B Dicto", 2, "Medium");
            Dicto cDicto = new Dicto("C Dicto", 3, "Big");
            dictoDictionary.Add(1,aDicto);
            dictoDictionary.Add(2,bDicto);
            dictoDictionary.Add(3,cDicto);

            Console.WriteLine("Object No- {0} and its Name: {1} and Size: {2}",dictoDictionary[1].Id, dictoDictionary[1].Name, dictoDictionary[1].Flag);
            Console.WriteLine("Object No- {0} and its Name: {1} and Size: {2}", dictoDictionary[2].Id, dictoDictionary[2].Name, dictoDictionary[2].Flag);
            Console.WriteLine("Object No- {0} and its Name: {1} and Size: {2}", dictoDictionary[3].Id, dictoDictionary[3].Name, dictoDictionary[3].Flag);

            Console.ReadKey();

        }
    }


    public class Dicto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Flag { get; set; }

        public Dicto(string name, int id, string flag)
        {
            Name = name;
            Id = id;
            Flag = flag;
        }
    }



}
