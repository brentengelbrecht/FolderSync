
namespace FolderSyncTestApp
{
    partial class MainForm
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
            this.ButtonExit = new System.Windows.Forms.Button();
            this.TextBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.TextBoxTargetFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonBrowseSource = new System.Windows.Forms.Button();
            this.ButtonBrowseTarget = new System.Windows.Forms.Button();
            this.TextBoxLogs = new System.Windows.Forms.TextBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(605, 372);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(131, 46);
            this.ButtonExit.TabIndex = 6;
            this.ButtonExit.Text = "E&xit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // TextBoxSourceFolder
            // 
            this.TextBoxSourceFolder.Location = new System.Drawing.Point(156, 40);
            this.TextBoxSourceFolder.Name = "TextBoxSourceFolder";
            this.TextBoxSourceFolder.Size = new System.Drawing.Size(472, 22);
            this.TextBoxSourceFolder.TabIndex = 0;
            // 
            // TextBoxTargetFolder
            // 
            this.TextBoxTargetFolder.Location = new System.Drawing.Point(156, 86);
            this.TextBoxTargetFolder.Name = "TextBoxTargetFolder";
            this.TextBoxTargetFolder.Size = new System.Drawing.Size(472, 22);
            this.TextBoxTargetFolder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Folder";
            // 
            // ButtonBrowseSource
            // 
            this.ButtonBrowseSource.Location = new System.Drawing.Point(645, 36);
            this.ButtonBrowseSource.Name = "ButtonBrowseSource";
            this.ButtonBrowseSource.Size = new System.Drawing.Size(91, 30);
            this.ButtonBrowseSource.TabIndex = 1;
            this.ButtonBrowseSource.Text = "Browse";
            this.ButtonBrowseSource.UseVisualStyleBackColor = true;
            this.ButtonBrowseSource.Click += new System.EventHandler(this.ButtonBrowseSource_Click);
            // 
            // ButtonBrowseTarget
            // 
            this.ButtonBrowseTarget.Location = new System.Drawing.Point(645, 82);
            this.ButtonBrowseTarget.Name = "ButtonBrowseTarget";
            this.ButtonBrowseTarget.Size = new System.Drawing.Size(91, 30);
            this.ButtonBrowseTarget.TabIndex = 3;
            this.ButtonBrowseTarget.Text = "Browse";
            this.ButtonBrowseTarget.UseVisualStyleBackColor = true;
            this.ButtonBrowseTarget.Click += new System.EventHandler(this.ButtonBrowseTarget_Click);
            // 
            // TextBoxLogs
            // 
            this.TextBoxLogs.Location = new System.Drawing.Point(49, 140);
            this.TextBoxLogs.Multiline = true;
            this.TextBoxLogs.Name = "TextBoxLogs";
            this.TextBoxLogs.ReadOnly = true;
            this.TextBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxLogs.Size = new System.Drawing.Size(687, 205);
            this.TextBoxLogs.TabIndex = 6;
            this.TextBoxLogs.TabStop = false;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(49, 372);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(131, 46);
            this.ButtonStart.TabIndex = 4;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(214, 372);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(131, 46);
            this.ButtonStop.TabIndex = 5;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderBrowser.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.TextBoxLogs);
            this.Controls.Add(this.ButtonBrowseTarget);
            this.Controls.Add(this.ButtonBrowseSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxTargetFolder);
            this.Controls.Add(this.TextBoxSourceFolder);
            this.Controls.Add(this.ButtonExit);
            this.Name = "MainForm";
            this.Text = "FolderSyncTestApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.TextBox TextBoxSourceFolder;
        private System.Windows.Forms.TextBox TextBoxTargetFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonBrowseSource;
        private System.Windows.Forms.Button ButtonBrowseTarget;
        private System.Windows.Forms.TextBox TextBoxLogs;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}

