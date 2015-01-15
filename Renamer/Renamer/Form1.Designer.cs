namespace Renamer
{
    partial class Renamer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFileButton = new System.Windows.Forms.Button();
            this.openFileDialogcontrol = new System.Windows.Forms.OpenFileDialog();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.successLabel = new System.Windows.Forms.Label();
            this.appendRadioButton = new System.Windows.Forms.RadioButton();
            this.prependRadioButton = new System.Windows.Forms.RadioButton();
            this.renameRadioButton = new System.Windows.Forms.RadioButton();
            this.changeExtensionRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(68, 63);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(288, 23);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Select File";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // openFileDialogcontrol
            // 
            this.openFileDialogcontrol.FileName = "openFileDialog1";
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(68, 177);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(288, 20);
            this.newNameTextBox.TabIndex = 4;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(68, 216);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(288, 23);
            this.renameButton.TabIndex = 5;
            this.renameButton.Text = "Do It";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(68, 258);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(89, 13);
            this.successLabel.TabIndex = 3;
            this.successLabel.Text = "Succes Message";
            // 
            // appendRadioButton
            // 
            this.appendRadioButton.AutoSize = true;
            this.appendRadioButton.Location = new System.Drawing.Point(294, 105);
            this.appendRadioButton.Name = "appendRadioButton";
            this.appendRadioButton.Size = new System.Drawing.Size(62, 17);
            this.appendRadioButton.TabIndex = 1;
            this.appendRadioButton.Text = "Append";
            this.appendRadioButton.UseVisualStyleBackColor = true;
            // 
            // prependRadioButton
            // 
            this.prependRadioButton.AutoSize = true;
            this.prependRadioButton.Location = new System.Drawing.Point(181, 105);
            this.prependRadioButton.Name = "prependRadioButton";
            this.prependRadioButton.Size = new System.Drawing.Size(65, 17);
            this.prependRadioButton.TabIndex = 2;
            this.prependRadioButton.Text = "Prepend";
            this.prependRadioButton.UseVisualStyleBackColor = true;
            // 
            // renameRadioButton
            // 
            this.renameRadioButton.AutoSize = true;
            this.renameRadioButton.Location = new System.Drawing.Point(68, 105);
            this.renameRadioButton.Name = "renameRadioButton";
            this.renameRadioButton.Size = new System.Drawing.Size(65, 17);
            this.renameRadioButton.TabIndex = 3;
            this.renameRadioButton.Text = "Rename";
            this.renameRadioButton.UseVisualStyleBackColor = true;
            // 
            // changeExtensionRadioButton
            // 
            this.changeExtensionRadioButton.AutoSize = true;
            this.changeExtensionRadioButton.Location = new System.Drawing.Point(68, 141);
            this.changeExtensionRadioButton.Name = "changeExtensionRadioButton";
            this.changeExtensionRadioButton.Size = new System.Drawing.Size(111, 17);
            this.changeExtensionRadioButton.TabIndex = 1;
            this.changeExtensionRadioButton.Text = "Change Extension";
            this.changeExtensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // Renamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 301);
            this.Controls.Add(this.renameRadioButton);
            this.Controls.Add(this.prependRadioButton);
            this.Controls.Add(this.changeExtensionRadioButton);
            this.Controls.Add(this.appendRadioButton);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.selectFileButton);
            this.Name = "Renamer";
            this.Text = "Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogcontrol;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.RadioButton appendRadioButton;
        private System.Windows.Forms.RadioButton prependRadioButton;
        private System.Windows.Forms.RadioButton renameRadioButton;
        private System.Windows.Forms.RadioButton changeExtensionRadioButton;
    }
}

