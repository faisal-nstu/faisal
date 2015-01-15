using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(() => BigFatImportantfunction("John Doe")).ContinueWith(t => label1.Text = t.Result,TaskScheduler.FromCurrentSynchronizationContext());
            //label1.Text = BigFatImportantfunction("John");

            CallBigFatImportantfunction();
            label1.Text = "Waiting...";
        }

        private async void CallBigFatImportantfunction()
        {
            var result = await BigFatImportantfunctionAsync("Amy");
            label1.Text = result;
        }

        private Task<string> BigFatImportantfunctionAsync(string name)
        {
            return Task.Factory.StartNew(() => BigFatImportantfunction(name));
        }

        private string BigFatImportantfunction(string name)
        {
            Thread.Sleep(3000);
            return "Hello " + name + "!!!";
        }
    }
}
