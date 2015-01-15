using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            QuitTracker bob = new QuitTracker{Name = "Bob"};

            KeystrokeHandler keystrokeHandler = new KeystrokeHandler();
            keystrokeHandler.OnKey = GotKey;
            keystrokeHandler.OnQuitting = bob.QuitHandler;
            keystrokeHandler.OnQuitting += OnQuit;
            keystrokeHandler.OnQuitting += bob.MyQuit;


            keystrokeHandler.Run();

            Console.ReadKey();
        }

        static void GotKey(char key)
        {
            Console.WriteLine("You pressed {0}",key);
        }


        static void OnQuit()
        {
            Console.WriteLine("Quiting...");
        }
    }

    public class QuitTracker
    {
        public string Name { get; set; }

        public void QuitHandler()
        {
            Console.WriteLine("My name is {0} and i just got a  quit notification...",Name);
        }


        public void MyQuit()
        {
            Console.WriteLine("I am quiting");
        }
    }
}
