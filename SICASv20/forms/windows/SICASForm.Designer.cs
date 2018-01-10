namespace SICASv20.forms
{
    partial class SICASForm
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
            this.PanelMain = new System.Windows.Forms.Panel();
            this.MenuesPanel = new System.Windows.Forms.Panel();
            this.ToolBarPanel = new System.Windows.Forms.Panel();
            this.ModuleMenuPanel = new System.Windows.Forms.Panel();
            this.ModulosMenu = new System.Windows.Forms.MenuStrip();
            this.ModuleMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.Transparent;
            this.PanelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelMain.Location = new System.Drawing.Point(0, 72);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1024, 628);
            this.PanelMain.TabIndex = 2;
            // 
            // MenuesPanel
            // 
            this.MenuesPanel.BackColor = System.Drawing.Color.Transparent;
            this.MenuesPanel.Location = new System.Drawing.Point(0, 24);
            this.MenuesPanel.Name = "MenuesPanel";
            this.MenuesPanel.Size = new System.Drawing.Size(1024, 24);
            this.MenuesPanel.TabIndex = 2;
            // 
            // ToolBarPanel
            // 
            this.ToolBarPanel.BackColor = System.Drawing.Color.Transparent;
            this.ToolBarPanel.Location = new System.Drawing.Point(0, 48);
            this.ToolBarPanel.Name = "ToolBarPanel";
            this.ToolBarPanel.Size = new System.Drawing.Size(1024, 24);
            this.ToolBarPanel.TabIndex = 1;
            // 
            // ModuleMenuPanel
            // 
            this.ModuleMenuPanel.Controls.Add(this.ModulosMenu);
            this.ModuleMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModuleMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.ModuleMenuPanel.Name = "ModuleMenuPanel";
            this.ModuleMenuPanel.Size = new System.Drawing.Size(1008, 24);
            this.ModuleMenuPanel.TabIndex = 0;
            // 
            // ModulosMenu
            // 
            this.ModulosMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ModulosMenu.Location = new System.Drawing.Point(0, 0);
            this.ModulosMenu.Name = "ModulosMenu";
            this.ModulosMenu.Size = new System.Drawing.Size(1008, 24);
            this.ModulosMenu.TabIndex = 0;
            this.ModulosMenu.Text = "menuStrip1";
            // 
            // SICASForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::SICASv20.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 712);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.MenuesPanel);
            this.Controls.Add(this.ToolBarPanel);
            this.Controls.Add(this.ModuleMenuPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.MainMenuStrip = this.ModulosMenu;
            this.Name = "SICASForm";
            this.Text = "SICAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SICASForm_FormClosed);
            this.ModuleMenuPanel.ResumeLayout(false);
            this.ModuleMenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ModuleMenuPanel;
        private System.Windows.Forms.Panel MenuesPanel;
        private System.Windows.Forms.Panel ToolBarPanel;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.MenuStrip ModulosMenu;
    }
}