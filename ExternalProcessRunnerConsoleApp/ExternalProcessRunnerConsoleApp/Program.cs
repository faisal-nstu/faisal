using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Web;

namespace ExternalProcessRunnerConsoleApp
{
    class MyProcess
    {
        public static void Main()
        {
            string command;
            while (true)
            {
                Console.Write(">> ");
                command = Console.ReadLine();
                if (command == "exit")
                {
                 break;   
                }
                Process myProcess = new Process();

                try
                {
                    var res = "http://google.com/search?q=" + HttpUtility.UrlEncode(command);
                    Process.Start(res);
                    //Process.Start("C:\\Windows\\" + command);
                    //myProcess.StartInfo.UseShellExecute = false;
                    //// You can start any process, HelloWorld is a do-nothing example.
                    ////myProcess.StartInfo.FileName = "C:\\Windows\\" + command ;
                    //myProcess.StartInfo.CreateNoWindow = true;
                    //myProcess.Start();
                    // //This code assumes the process you are starting will terminate itself.  
                    // //Given that is is started without a window so you cannot terminate it  
                    // //on the desktop, it must terminate itself or you can do it programmatically 
                    // //from this application using the Kill method.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}