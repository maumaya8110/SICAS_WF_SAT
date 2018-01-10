namespace SICASv20.forms
{
    partial class ReporteCorteCajaCobro
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CorteButton = new System.Windows.Forms.Button();
            this.CortePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CortePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CortePictureBox);
            this.groupBox1.Controls.Add(this.CorteButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 607);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corte de Caja";
            // 
            // CorteButton
            // 
            this.CorteButton.Location = new System.Drawing.Point(549, 33);
            this.CorteButton.Name = "CorteButton";
            this.CorteButton.Size = new System.Drawing.Size(166, 33);
            this.CorteButton.TabIndex = 3;
            this.CorteButton.Text = "Realizar el corte de caja";
            this.CorteButton.UseVisualStyleBackColor = true;
            this.CorteButton.Click += new System.EventHandler(this.CorteButton_Click);
            // 
            // CortePictureBox
            // 
            this.CortePictureBox.Location = new System.Drawing.Point(19, 33);
            this.CortePictureBox.Name = "CortePictureBox";
            this.CortePictureBox.Size = new System.Drawing.Size(503, 551);
            this.CortePictureBox.TabIndex = 4;
            this.CortePictureBox.TabStop = false;
            // 
            // ReporteCorteCajaCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteCorteCajaCobro";
            this.Text = "ReporteCorteCajaCobro";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CortePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CorteButton;
        private System.Windows.Forms.PictureBox CortePictureBox;

    }
}