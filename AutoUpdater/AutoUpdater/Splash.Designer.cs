namespace AutoUpdater
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            this.AppImagePictureBox = new System.Windows.Forms.PictureBox();
            this.LegendLabel = new System.Windows.Forms.Label();
            this.AutoUpProgressBar = new System.Windows.Forms.ProgressBar();
            this.AutoUpTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AppImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AppImagePictureBox
            // 
            this.AppImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.AppImagePictureBox.Name = "AppImagePictureBox";
            this.AppImagePictureBox.Size = new System.Drawing.Size(537, 192);
            this.AppImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppImagePictureBox.TabIndex = 0;
            this.AppImagePictureBox.TabStop = false;
            // 
            // LegendLabel
            // 
            this.LegendLabel.AutoSize = true;
            this.LegendLabel.Location = new System.Drawing.Point(196, 227);
            this.LegendLabel.Name = "LegendLabel";
            this.LegendLabel.Size = new System.Drawing.Size(160, 13);
            this.LegendLabel.TabIndex = 5;
            this.LegendLabel.Text = "Actualizando, por favor espere...";
            // 
            // AutoUpProgressBar
            // 
            this.AutoUpProgressBar.Location = new System.Drawing.Point(140, 255);
            this.AutoUpProgressBar.Name = "AutoUpProgressBar";
            this.AutoUpProgressBar.Size = new System.Drawing.Size(286, 23);
            this.AutoUpProgressBar.TabIndex = 6;
            // 
            // AutoUpTimer
            // 
            this.AutoUpTimer.Enabled = true;
            this.AutoUpTimer.Tick += new System.EventHandler(this.AutoUpTimer_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(561, 308);
            this.Controls.Add(this.AutoUpProgressBar);
            this.Controls.Add(this.LegendLabel);
            this.Controls.Add(this.AppImagePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoUp";
            ((System.ComponentModel.ISupportInitialize)(this.AppImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LegendLabel;
        public System.Windows.Forms.PictureBox AppImagePictureBox;
        private System.Windows.Forms.Timer AutoUpTimer;
        public System.Windows.Forms.ProgressBar AutoUpProgressBar;
    }
}