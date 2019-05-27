namespace SP2_Tool
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menu_Main = new System.Windows.Forms.MenuStrip();
            this.main_File = new System.Windows.Forms.ToolStripMenuItem();
            this.file_ExportSP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.file_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd_OpenFiles = new System.Windows.Forms.OpenFileDialog();
            this.file_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd_OpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.web_Explorer = new System.Windows.Forms.WebBrowser();
            this.main_SDK = new System.Windows.Forms.ToolStripMenuItem();
            this.sdk_CreateSP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.main_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.main_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.main_GitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_Main
            // 
            this.menu_Main.BackColor = System.Drawing.SystemColors.Control;
            this.menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_File,
            this.main_SDK,
            this.main_Help});
            this.menu_Main.Location = new System.Drawing.Point(0, 0);
            this.menu_Main.Name = "menu_Main";
            this.menu_Main.Size = new System.Drawing.Size(642, 24);
            this.menu_Main.TabIndex = 0;
            this.menu_Main.Text = "menuStrip1";
            // 
            // main_File
            // 
            this.main_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ExportSP2,
            this.file_OpenFolder,
            this.toolStripSeparator1,
            this.file_Exit});
            this.main_File.Name = "main_File";
            this.main_File.Size = new System.Drawing.Size(37, 20);
            this.main_File.Text = "File";
            // 
            // file_ExportSP2
            // 
            this.file_ExportSP2.Image = ((System.Drawing.Image)(resources.GetObject("file_ExportSP2.Image")));
            this.file_ExportSP2.Name = "file_ExportSP2";
            this.file_ExportSP2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.file_ExportSP2.Size = new System.Drawing.Size(205, 22);
            this.file_ExportSP2.Text = "Open SP2";
            this.file_ExportSP2.Click += new System.EventHandler(this.File_OpenSP2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // file_Exit
            // 
            this.file_Exit.Image = ((System.Drawing.Image)(resources.GetObject("file_Exit.Image")));
            this.file_Exit.Name = "file_Exit";
            this.file_Exit.Size = new System.Drawing.Size(205, 22);
            this.file_Exit.Text = "Exit";
            this.file_Exit.Click += new System.EventHandler(this.File_Exit_Click);
            // 
            // file_OpenFolder
            // 
            this.file_OpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("file_OpenFolder.Image")));
            this.file_OpenFolder.Name = "file_OpenFolder";
            this.file_OpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.file_OpenFolder.Size = new System.Drawing.Size(205, 22);
            this.file_OpenFolder.Text = "Open Folder";
            this.file_OpenFolder.Visible = false;
            this.file_OpenFolder.Click += new System.EventHandler(this.File_OpenFolder_Click);
            // 
            // web_Explorer
            // 
            this.web_Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_Explorer.Location = new System.Drawing.Point(0, 24);
            this.web_Explorer.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_Explorer.Name = "web_Explorer";
            this.web_Explorer.Size = new System.Drawing.Size(642, 387);
            this.web_Explorer.TabIndex = 1;
            // 
            // main_SDK
            // 
            this.main_SDK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdk_CreateSP2});
            this.main_SDK.Name = "main_SDK";
            this.main_SDK.Size = new System.Drawing.Size(40, 20);
            this.main_SDK.Text = "SDK";
            // 
            // sdk_CreateSP2
            // 
            this.sdk_CreateSP2.Enabled = false;
            this.sdk_CreateSP2.Image = ((System.Drawing.Image)(resources.GetObject("sdk_CreateSP2.Image")));
            this.sdk_CreateSP2.Name = "sdk_CreateSP2";
            this.sdk_CreateSP2.Size = new System.Drawing.Size(180, 22);
            this.sdk_CreateSP2.Text = "Create SP2";
            this.sdk_CreateSP2.Click += new System.EventHandler(this.CreateSP2ToolStripMenuItem_Click);
            // 
            // main_Help
            // 
            this.main_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_GitHub,
            this.toolStripSeparator2,
            this.main_About});
            this.main_Help.Name = "main_Help";
            this.main_Help.Size = new System.Drawing.Size(44, 20);
            this.main_Help.Text = "Help";
            // 
            // main_About
            // 
            this.main_About.Image = ((System.Drawing.Image)(resources.GetObject("main_About.Image")));
            this.main_About.Name = "main_About";
            this.main_About.Size = new System.Drawing.Size(180, 22);
            this.main_About.Text = "About";
            this.main_About.Click += new System.EventHandler(this.Main_About_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // main_GitHub
            // 
            this.main_GitHub.Image = ((System.Drawing.Image)(resources.GetObject("main_GitHub.Image")));
            this.main_GitHub.Name = "main_GitHub";
            this.main_GitHub.Size = new System.Drawing.Size(180, 22);
            this.main_GitHub.Text = "GitHub...";
            this.main_GitHub.Click += new System.EventHandler(this.Main_GitHub_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 411);
            this.Controls.Add(this.web_Explorer);
            this.Controls.Add(this.menu_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_Main;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP2 Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu_Main.ResumeLayout(false);
            this.menu_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_Main;
        private System.Windows.Forms.ToolStripMenuItem main_File;
        private System.Windows.Forms.ToolStripMenuItem file_ExportSP2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem file_Exit;
        private System.Windows.Forms.OpenFileDialog ofd_OpenFiles;
        private System.Windows.Forms.ToolStripMenuItem file_OpenFolder;
        private System.Windows.Forms.FolderBrowserDialog fbd_OpenFolder;
        private System.Windows.Forms.WebBrowser web_Explorer;
        private System.Windows.Forms.ToolStripMenuItem main_SDK;
        private System.Windows.Forms.ToolStripMenuItem sdk_CreateSP2;
        private System.Windows.Forms.ToolStripMenuItem main_Help;
        private System.Windows.Forms.ToolStripMenuItem main_About;
        private System.Windows.Forms.ToolStripMenuItem main_GitHub;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

