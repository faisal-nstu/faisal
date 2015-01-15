using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Procurios.Public;

namespace JSON_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            JSON jsonObj  = new JSON();
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    ISBN = "A1",
                    Price = 200,
                    Title = "Book 1"
                },
                new Book()
                {
                    Title = "Book 2",
                    Price = 300,
                    ISBN = "A2"
                },
                new Book()
                {
                    Title = "Book 3",
                    Price = 400,
                    ISBN = "A3"

                }

            };


            var v= JSON.JsonEncode(books);
            var c = JSON.JsonDecode(v);
            Console.WriteLine(c);

            Console.ReadKey();

        }



        public class Book
        {
            public string Title { get; set; }
            public string ISBN { get; set; }
            public int Price { get; set; }
        }
    }
}
