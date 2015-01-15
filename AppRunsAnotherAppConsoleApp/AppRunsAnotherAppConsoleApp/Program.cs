using System;
using System.Diagnostics;

namespace AppRunsAnotherAppConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Process firstProc = new Process();
                firstProc.StartInfo.FileName = @"C:\Program Files\Sublime Text 3\sublime_text.exe";
                firstProc.StartInfo.Arguments = "e:/test.txt";
                firstProc.EnableRaisingEvents = true;
                


                firstProc.Start();
                firstProc.WaitForExit();
                
                

                

                //You may want to perform different actions depending on the exit code.
                Console.WriteLine("First process exited: " + firstProc.ExitCode);
                //Console.ReadKey();

                Process secondProc = new Process();
                secondProc.StartInfo.FileName = "explorer.exe";
                secondProc.StartInfo.Arguments = @"E:\Fresher Training 1st phase.pdf";
                //secondProc.StartInfo.Arguments = "e:/test.txt";
                secondProc.EnableRaisingEvents = true;
                secondProc.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred!!!: " + ex.Message);
                return;
            }
        }
    }
}
