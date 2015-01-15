using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressMessageTestApp
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        public Form1()
        {
            InitializeComponent();
            
            label1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = this.button1.Name + "  task in Progress";
            label1.Show();
            WorksToBeDone();
        }

        public void WorksToBeDone()
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();
            
        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {

            //************************* ***********
            //
            // PUT YOUR 'CODES TO BE EXECUTED' HERE 
            //
            //***************************************

            // just for waiting (don't use it in your code)
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Hide();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = this.button2.Name + "  task in Progress";
            label1.Show();
            WorksToBeDone();
        }


    }
}
