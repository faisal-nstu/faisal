using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new SingleParameter<int> {Success = true, Data = 55};
            var result2 = new SingleParameter<string> {Success = false, Data = "Faisal"};
            var doublePar = new DoubleParameter<int, string> {Success = true, Data = 420, Data2 = "Amin"};


            //Console.WriteLine(result.Success + " " + result.Data);
            //Console.WriteLine(result2.Success + " " + result2.Data);
            //Console.WriteLine(doublePar.Success + " " + doublePar.Data + " " + doublePar.Data2);


            var helper = new ResultPrinter();
            helper.Printer(result);


            Console.ReadKey();
        }

        public class SingleParameter<T>
        {
            public bool Success { get; set; }
            public T Data { get; set; }
        }



        public class DoubleParameter<T,U>
        {
            public bool Success { get; set; }
            public T Data { get; set; }
            public U Data2 { get; set; }
        }
        

        public class ResultPrinter
        {
            public void Printer<T>(SingleParameter<T> result)
            {
                Console.WriteLine(result.Success + " " + result.Data);
            }
        }
    }
}
