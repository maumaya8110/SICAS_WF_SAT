namespace SICASv20.forms
{
    partial class Ayuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.AyudaBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // AyudaBrowser
            // 
            this.AyudaBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AyudaBrowser.Location = new System.Drawing.Point(0, 0);
            this.AyudaBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.AyudaBrowser.Name = "AyudaBrowser";
            this.AyudaBrowser.Size = new System.Drawing.Size(816, 505);
            this.AyudaBrowser.TabIndex = 0;
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 505);
            this.Controls.Add(this.AyudaBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ayuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser AyudaBrowser;
    }
}