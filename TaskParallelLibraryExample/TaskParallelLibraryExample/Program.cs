using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace TaskParallelLibraryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start tasks....");
            Timer aTimer = new Timer();
            Console.ReadKey();
            Console.Write("\b");

            var t1 = new Task(() => DoThings(1, 3000));
            var t2 = new Task(() => DoThings(2, 1500));
            var t3 = new Task(() => DoThings(3, 4000));
            var t4 = Task.Factory.StartNew(() => DoThings(4, 3500)).ContinueWith((prevTask) => DoOtherThings(4,3800));


            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadKey();
        }

        private static void DoThings(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} started",id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} completed", id);
        }

        private static void DoOtherThings(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} complement started", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} complement completed", id);


            
        }

    }
}
