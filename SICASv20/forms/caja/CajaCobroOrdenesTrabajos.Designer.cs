namespace SICASv20.forms
{
    partial class CajaCobroOrdenesTrabajos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CambioTextBox = new System.Windows.Forms.TextBox();
            this.PagaConTextBox = new System.Windows.Forms.TextBox();
            this.TotalAPagarTextBox = new System.Windows.Forms.TextBox();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            this.CodigoBarrasTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrdenTrabajoIDTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 285);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cobro de ordenes de trabajo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.45356F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.54643F));
            this.tableLayoutPanel1.Controls.Add(this.CambioTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.PagaConTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TotalAPagarTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ClienteTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodigoBarrasTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.OrdenTrabajoIDTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CambioTextBox
            // 
            this.CambioTextBox.BackColor = System.Drawing.Color.White;
            this.CambioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CambioTextBox.Location = new System.Drawing.Point(143, 178);
            this.CambioTextBox.Name = "CambioTextBox";
            this.CambioTextBox.ReadOnly = true;
            this.CambioTextBox.Size = new System.Drawing.Size(100, 24);
            this.CambioTextBox.TabIndex = 11;
            this.CambioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PagaConTextBox
            // 
            this.PagaConTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PagaConTextBox.Location = new System.Drawing.Point(143, 143);
            this.PagaConTextBox.Name = "PagaConTextBox";
            this.PagaConTextBox.Size = new System.Drawing.Size(100, 24);
            this.PagaConTextBox.TabIndex = 10;
            this.PagaConTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PagaConTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PagaConTextBox_KeyUp);
            // 
            // TotalAPagarTextBox
            // 
            this.TotalAPagarTextBox.BackColor = System.Drawing.Color.White;
            this.TotalAPagarTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAPagarTextBox.Location = new System.Drawing.Point(143, 108);
            this.TotalAPagarTextBox.Name = "TotalAPagarTextBox";
            this.TotalAPagarTextBox.ReadOnly = true;
            this.TotalAPagarTextBox.Size = new System.Drawing.Size(100, 24);
            this.TotalAPagarTextBox.TabIndex = 9;
            this.TotalAPagarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.BackColor = System.Drawing.Color.White;
            this.ClienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteTextBox.Location = new System.Drawing.Point(143, 73);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.ReadOnly = true;
            this.ClienteTextBox.Size = new System.Drawing.Size(317, 24);
            this.ClienteTextBox.TabIndex = 8;
            // 
            // CodigoBarrasTextBox
            // 
            this.CodigoBarrasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodigoBarrasTextBox.Location = new System.Drawing.Point(143, 38);
            this.CodigoBarrasTextBox.Name = "CodigoBarrasTextBox";
            this.CodigoBarrasTextBox.Size = new System.Drawing.Size(175, 24);
            this.CodigoBarrasTextBox.TabIndex = 7;
            this.CodigoBarrasTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodigoBarrasTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden trabajo ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código de barras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total a pagar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Paga con:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cambio:";
            // 
            // OrdenTrabajoIDTextBox
            // 
            this.OrdenTrabajoIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdenTrabajoIDTextBox.Location = new System.Drawing.Point(143, 3);
            this.OrdenTrabajoIDTextBox.Name = "OrdenTrabajoIDTextBox";
            this.OrdenTrabajoIDTextBox.Size = new System.Drawing.Size(121, 24);
            this.OrdenTrabajoIDTextBox.TabIndex = 6;
            this.OrdenTrabajoIDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenTrabajoIDTextBox_KeyUp);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(411, 315);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(117, 31);
            this.AceptarButton.TabIndex = 2;
            this.AceptarButton.Text = "Registrar cobro";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CajaCobroOrdenesTrabajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AceptarButton);
            this.Name = "CajaCobroOrdenesTrabajos";
            this.Text = "CajaCobroOrdenesTrabajos";
            this.Controls.SetChildIndex(this.AceptarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox CambioTextBox;
        private System.Windows.Forms.TextBox PagaConTextBox;
        private System.Windows.Forms.TextBox TotalAPagarTextBox;
        private System.Windows.Forms.TextBox ClienteTextBox;
        private System.Windows.Forms.TextBox CodigoBarrasTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OrdenTrabajoIDTextBox;
        private System.Windows.Forms.Button AceptarButton;
    }
}