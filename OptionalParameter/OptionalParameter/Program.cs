using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintData("Faisal",age:25);
            Console.ReadKey();
        }


        private static void PrintData(string firstName = "Abul",  string secondName = "Karim",int age = 16)
        {
            Console.WriteLine("{0} {1} is {2} years old...",firstName,secondName,age);
        }
    }
}
