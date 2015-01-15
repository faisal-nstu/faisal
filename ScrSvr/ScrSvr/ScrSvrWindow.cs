using System;
using System.Windows.Forms;

namespace ScrSvr
{
    class ScrSvrWindow: ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        //Configuration configWindow = new Configuration();
        public ScrSvrWindow()
        {
            
            MenuItem exitMenuItem = new MenuItem("Exit", Exit);

            notifyIcon.Icon = Properties.Resources.skull_bw;
            notifyIcon.Click += SwitchScrSvrOn;
            notifyIcon.ContextMenu = new ContextMenu(new[] {  exitMenuItem });
            //notifyIcon.ContextMenu.
            notifyIcon.Visible = true;
        }

        private void SwitchScrSvrOn(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            //MessageBox.Show("done!!!");
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
