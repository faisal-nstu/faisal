using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pythonRuntime = Python.CreateRuntime();

            //dynamic pythonFile = pythonRuntime.UseFile("Test.py");

            dynamic test = new ExpandoObject();
            test.Name = "Faisal";
            test.Age = 25;
            Console.WriteLine(test.Name);
            Console.WriteLine(test.Age);
            Console.ReadKey();



        }
    }
}
