namespace SICASv20.forms
{
    partial class NuevaOrdenTrabajo
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
            this.InnerPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IVATextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SubTotalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RefaccionestextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ManoDeObraTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InnerPanel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 604);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva orden de trabajo";
            // 
            // InnerPanel
            // 
            this.InnerPanel.Location = new System.Drawing.Point(18, 30);
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Size = new System.Drawing.Size(694, 557);
            this.InnerPanel.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CancelarButton);
            this.groupBox2.Controls.Add(this.TotalTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.IVATextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SubTotalTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RefaccionestextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ManoDeObraTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(718, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 567);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totales";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::SICASv20.Properties.Resources.cancel;
            this.CancelarButton.Location = new System.Drawing.Point(6, 198);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(105, 32);
            this.CancelarButton.TabIndex = 11;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.BackColor = System.Drawing.Color.White;
            this.TotalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.TotalTextBox.Location = new System.Drawing.Point(140, 144);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(106, 24);
            this.TotalTextBox.TabIndex = 9;
            this.TotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(16, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total:";
            // 
            // IVATextBox
            // 
            this.IVATextBox.BackColor = System.Drawing.Color.White;
            this.IVATextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IVATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVATextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.IVATextBox.Location = new System.Drawing.Point(140, 117);
            this.IVATextBox.Name = "IVATextBox";
            this.IVATextBox.ReadOnly = true;
            this.IVATextBox.Size = new System.Drawing.Size(106, 24);
            this.IVATextBox.TabIndex = 7;
            this.IVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(16, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "IVA:";
            // 
            // SubTotalTextBox
            // 
            this.SubTotalTextBox.BackColor = System.Drawing.Color.White;
            this.SubTotalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTotalTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.SubTotalTextBox.Location = new System.Drawing.Point(140, 90);
            this.SubTotalTextBox.Name = "SubTotalTextBox";
            this.SubTotalTextBox.ReadOnly = true;
            this.SubTotalTextBox.Size = new System.Drawing.Size(106, 24);
            this.SubTotalTextBox.TabIndex = 5;
            this.SubTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "SubTotal:";
            // 
            // RefaccionestextBox
            // 
            this.RefaccionestextBox.BackColor = System.Drawing.Color.White;
            this.RefaccionestextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RefaccionestextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefaccionestextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.RefaccionestextBox.Location = new System.Drawing.Point(140, 63);
            this.RefaccionestextBox.Name = "RefaccionestextBox";
            this.RefaccionestextBox.ReadOnly = true;
            this.RefaccionestextBox.Size = new System.Drawing.Size(106, 24);
            this.RefaccionestextBox.TabIndex = 3;
            this.RefaccionestextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Refacciones:";
            // 
            // ManoDeObraTextBox
            // 
            this.ManoDeObraTextBox.BackColor = System.Drawing.Color.White;
            this.ManoDeObraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ManoDeObraTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManoDeObraTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.ManoDeObraTextBox.Location = new System.Drawing.Point(140, 36);
            this.ManoDeObraTextBox.Name = "ManoDeObraTextBox";
            this.ManoDeObraTextBox.ReadOnly = true;
            this.ManoDeObraTextBox.Size = new System.Drawing.Size(106, 24);
            this.ManoDeObraTextBox.TabIndex = 1;
            this.ManoDeObraTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mano de obra:";
            // 
            // NuevaOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 628);
            this.Controls.Add(this.groupBox1);
            this.Name = "NuevaOrdenTrabajo";
            this.Text = "NuevaOrdenTrabajo";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel InnerPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IVATextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SubTotalTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RefaccionestextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ManoDeObraTextBox;
        private System.Windows.Forms.Label label1;

    }
}