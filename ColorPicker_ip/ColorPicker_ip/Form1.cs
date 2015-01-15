using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker_ip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string width = Screen.PrimaryScreen.WorkingArea.Width.ToString();
            string height = Screen.PrimaryScreen.WorkingArea.Height.ToString();
            
            label1.Text = "Your monitor's width : " + width + " and height: " + height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = Screen.PrimaryScreen.WorkingArea.Width;
            int height = Screen.PrimaryScreen.WorkingArea.Height;
            int btnWidth = button1.Size.Width;
            int btnHeight = button1.Height;

            

        }

        
    }
}
