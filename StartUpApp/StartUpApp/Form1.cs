using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;


namespace StartUpApp
{
    public partial class Form1 : Form
    {
        RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            //rk.DeleteValue("iPaL-App");

            // startup folder shortcut approach
            RemoveShortcut();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //rk.SetValue("iPaL-App", Application.ExecutablePath.ToString());

            // startup folder shortcut approach
            CreateShortcut();
            
        }

        private void CreateShortcut()
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\sc.lnk");
                try
                {
                    lnk.TargetPath = Application.ExecutablePath;
                    lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private void RemoveShortcut()
        {
            string startUpPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (System.IO.File.Exists(Path.Combine(startUpPath, "sc.lnk")))
            {
                System.IO.File.Delete(Path.Combine(startUpPath, "sc.lnk"));
            }
        }
    }
}
