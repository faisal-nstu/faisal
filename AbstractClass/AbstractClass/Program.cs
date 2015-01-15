using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Implementer_first implementerFirst = new Implementer_first();
            Implementer_second implementerSecond = new Implementer_second();
            Console.ReadKey();
        }
    }
}
