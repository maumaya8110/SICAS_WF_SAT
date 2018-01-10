namespace SICASv20.forms
{
    partial class baseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseForm));
            this.AyudaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AyudaButton
            // 
            resources.ApplyResources(this.AyudaButton, "AyudaButton");
            this.AyudaButton.Name = "AyudaButton";
            this.AyudaButton.UseVisualStyleBackColor = true;
            this.AyudaButton.Click += new System.EventHandler(this.AyudaButton_Click);
            // 
            // baseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this, "$this");
            this.Color1 = System.Drawing.Color.LightSteelBlue;
            this.Color2 = System.Drawing.Color.GhostWhite;
            this.ControlBox = false;
            this.Controls.Add(this.AyudaButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "baseForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.baseForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AyudaButton;
    }
}