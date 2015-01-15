using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateDesktopApp
{
    public partial class DThin : Form
    {
        private int labelNo;
        ButtonStroke buttonStroke = new ButtonStroke();
        public int Labelno
        {
            get { return labelNo; }
            set { labelNo = value; }
        }

        public DThin()
        {
            InitializeComponent();
            Labelno = 1;
            
            
        }

        private void DThin_Load(object sender, EventArgs e)
        {
            
            label1.Text = Labelno.ToString("D2");
        }

        public void Plus()
        {
            Labelno++;
            label1.Text = Labelno.ToString("D2");
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            Plus();
        }

        public void Minus()
        {
            Labelno--;
            label1.Text = Labelno.ToString("D2");
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            Minus();
        }
    }
}
