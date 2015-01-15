using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renamer
{
    public partial class Renamer : Form
    {
        public List<string> SelectedFileNames;
        //private string _oldFileName;
        private string _newFileName;
        private int _successMessageTimer;
        public Renamer()
        {
            InitializeComponent();
            openFileDialogcontrol.Multiselect = true;
            successLabel.Text = "Name Changed Successfully";
            successLabel.Hide();
            renameButton.Enabled = false;
            renameRadioButton.CheckedChanged += RenameRadioButtonOnCheckedChanged;
            appendRadioButton.CheckedChanged += AppendRadioButtonOnCheckedChanged;
            prependRadioButton.CheckedChanged += PrependRadioButtonOnCheckedChanged;
            changeExtensionRadioButton.CheckedChanged += ChangeExtensionRadioButtonOnCheckedChanged;
            newNameTextBox.GotFocus += NewNameTextBoxOnGotFocus;
            renameRadioButton.Checked = true;
        }


        private void NewNameTextBoxOnGotFocus(object sender, EventArgs eventArgs)
        {
            newNameTextBox.Text = "";
            newNameTextBox.ForeColor = DefaultForeColor;
        }

        private void ChangeExtensionRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (changeExtensionRadioButton.Checked)
            {
                newNameTextBox.Text = "Enter New File Extension";
                newNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void PrependRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (prependRadioButton.Checked)
            {
                newNameTextBox.Text = "Enter Text to Prepend";
                newNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void AppendRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (appendRadioButton.Checked)
            {
                newNameTextBox.Text = "Enter Text to Append";
                newNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void RenameRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (renameRadioButton.Checked)
            {
                newNameTextBox.Text = "Enter New Name";
                newNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogcontrol.ShowDialog();
            SelectedFileNames = new List<string>();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialogcontrol.FileNames)
                {
                    SelectedFileNames.Add(fileName);
                    renameButton.Enabled = true;
                }
            }
            
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (renameRadioButton.Checked)
            {
                Rename();
            }
            else if (prependRadioButton.Checked)
            {
                Prepend();
            }
            else if (appendRadioButton.Checked)
            {
                Append();
            }
            else if (changeExtensionRadioButton.Checked)
            {
                ChangeExtension();
            }

            SelectedFileNames = null;
            newNameTextBox.Text = "";
            SuccessMessage();
        }

        private void Rename()
        {
            int increment = 0;
            string replacer = newNameTextBox.Text;
            string replaceable;
            string filePath;
            if (SelectedFileNames.Count == 1)
            {
                replaceable = System.IO.Path.GetFileNameWithoutExtension(openFileDialogcontrol.SafeFileName);
                filePath = System.IO.Path.GetFullPath(openFileDialogcontrol.FileName);
                _newFileName = filePath.Replace(replaceable, (replacer));
                System.IO.File.Move(filePath, _newFileName);
            }
            else
            {
                foreach (var selectedFileName in SelectedFileNames)
                {
                    replaceable = System.IO.Path.GetFileNameWithoutExtension(selectedFileName);
                    _newFileName = selectedFileName.Replace(replaceable, (replacer + " - " + (++increment)));
                    System.IO.File.Move(selectedFileName, _newFileName);
                }
            }
        }

        private void Prepend()
        {
            string replacer = newNameTextBox.Text;
            string replaceable;
            string filePath;
            if (SelectedFileNames.Count == 1)
            {
                replaceable = System.IO.Path.GetFileNameWithoutExtension(openFileDialogcontrol.SafeFileName);
                filePath = System.IO.Path.GetFullPath(openFileDialogcontrol.FileName);
                _newFileName = filePath.Replace(replaceable, (replacer + replaceable));
                System.IO.File.Move(filePath, _newFileName);
            }
            else
            {
                foreach (var selectedFileName in SelectedFileNames)
                {
                    replaceable = System.IO.Path.GetFileNameWithoutExtension(selectedFileName);
                    _newFileName = selectedFileName.Replace(replaceable, (replacer + replaceable));
                    System.IO.File.Move(selectedFileName, _newFileName);
                }
            }
        }

        private void Append()
        {
            string replacer = newNameTextBox.Text;
            string replaceable;
            string filePath;
            if (SelectedFileNames.Count == 1)
            {
                replaceable = System.IO.Path.GetFileNameWithoutExtension(openFileDialogcontrol.SafeFileName);
                filePath = System.IO.Path.GetFullPath(openFileDialogcontrol.FileName);
                _newFileName = filePath.Replace(replaceable, (replaceable + replacer)); 
                System.IO.File.Move(filePath, _newFileName);
            }
            else
            {
                foreach (var selectedFileName in SelectedFileNames)
                {
                    replaceable = System.IO.Path.GetFileNameWithoutExtension(selectedFileName);
                    _newFileName = selectedFileName.Replace(replaceable, (replaceable + replacer));
                    System.IO.File.Move(selectedFileName, _newFileName);
                }
            }
        }

        private void ChangeExtension()
        {
            string newExtension = newNameTextBox.Text;
            foreach (var selectedFileName in SelectedFileNames)
            {
                System.IO.File.Move(selectedFileName, System.IO.Path.ChangeExtension(selectedFileName, ("." + newExtension)));
            }
        }

        private void SuccessMessage()
        {
            renameButton.Enabled = false;
            successLabel.Show(); _successMessageTimer = 2;
            Timer msgTimer = new Timer();
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(this.timer_tick); 
        }

        private void timer_tick(object sender, EventArgs e)
        {
            _successMessageTimer--;

            if (_successMessageTimer == 0)
            {
                successLabel.Hide();
            }
        }
    }
}
