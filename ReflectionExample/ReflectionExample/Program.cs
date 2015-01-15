using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: " + type.Name);
                var porperties = type.GetProperties();
                var methods = type.GetMethods();
                foreach (var propertyInfo in porperties)
                {
                    Console.WriteLine("\tProperty Name: " + propertyInfo.Name + "\n\t>Type: " + propertyInfo.PropertyType);
                }
                foreach (var methodInfo in methods)
                {
                    Console.WriteLine("\t\tMethod Name: " + methodInfo.Name);
                }
            }


            var sample = new Sample { Name = "John", Age = 25 };
            var sampleType = typeof(Sample);

            var myMethod = sampleType.GetMethod("MyMethod");
            myMethod.Invoke(sample, null);







            var attributeTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyClassAttribute>().Count() > 0);
            foreach (var attributeType in attributeTypes)
            {
                Console.WriteLine(attributeType.Name);
                var methods =
                    attributeType.GetMethods().Where(m => m.GetCustomAttributes<MyMethodAttribute>().Count() > 0);
                foreach (var methodInfo in methods)
                {
                    Console.WriteLine(">" + methodInfo.Name);
                }
            }







            Console.ReadKey();
        }

        
        [MyClass]
        public class  Sample
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public int Age;

            [MyMethod]
            public void MyMethod()
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
        }


        [MyClass]
        public class Tample
        {
            public string T_Name { get; set; }
            public string T_Email { get; set; }
            public string T_Address { get; set; }
            public int T_Age;

            [MyMethod]
            public void T_MyMethod()
            {
                
            }
        }


        [AttributeUsage(AttributeTargets.Class)]
        public class MyClassAttribute: Attribute
        {
             
        }


        [AttributeUsage(AttributeTargets.Method)]
        public class MyMethodAttribute:Attribute
        {
             
        }
    }
}
