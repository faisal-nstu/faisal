using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordDemo
{
    public partial class LogInForm : Form
    {
        private string _userName = "username";
        private string _password = "password";
        public LogInForm()
        {
            InitializeComponent();
            label3.Hide();
            

        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (CheckCredential())
            {
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide(); 
            }
            else
            {
                usernameTextbox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                label3.Show();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            usernameTextbox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }

        private bool CheckCredential()
        {
            if (usernameTextbox.Text == _userName && passwordTextBox.Text == _password)
            {
                return true;
            }
            return false;
        }


    }
}
