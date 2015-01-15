using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleCollection<string> stringCollection = new SampleCollection<string>();

            stringCollection[0] = "Data - 1";
            stringCollection[1] = "Data - 2";
            stringCollection[2] = "Data - 3";

            for (int i = 0; stringCollection[i]!=null; i++)
            {
                Console.WriteLine(stringCollection[i]);
                
            }



            Console.ReadKey();
        }
    }



    public class SampleCollection<T>
    {
        private T[] arr = new T[100];

        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }
}
