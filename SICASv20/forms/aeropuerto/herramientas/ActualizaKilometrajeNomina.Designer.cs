namespace SICASv20.forms.aeropuerto.herramientas
{
	partial class ActualizaKilometrajeNomina
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
			this.btnActualiza = new System.Windows.Forms.Button();
			this.btnCancela = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ConductorTextBox = new System.Windows.Forms.TextBox();
			this.UnidadTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.KilometrajeActualTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.KilometrajeAnteriorTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtLitros = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnActualiza
			// 
			this.btnActualiza.Location = new System.Drawing.Point(132, 129);
			this.btnActualiza.Name = "btnActualiza";
			this.btnActualiza.Size = new System.Drawing.Size(101, 40);
			this.btnActualiza.TabIndex = 1;
			this.btnActualiza.Text = "Actualizar";
			this.btnActualiza.UseVisualStyleBackColor = true;
			this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
			// 
			// btnCancela
			// 
			this.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancela.Location = new System.Drawing.Point(334, 129);
			this.btnCancela.Name = "btnCancela";
			this.btnCancela.Size = new System.Drawing.Size(101, 40);
			this.btnCancela.TabIndex = 2;
			this.btnCancela.Text = "Cancelar";
			this.btnCancela.UseVisualStyleBackColor = true;
			this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtLitros);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.ConductorTextBox);
			this.panel1.Controls.Add(this.UnidadTextBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.KilometrajeActualTextBox);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.KilometrajeAnteriorTextBox);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Location = new System.Drawing.Point(12, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(547, 115);
			this.panel1.TabIndex = 0;
			// 
			// ConductorTextBox
			// 
			this.ConductorTextBox.BackColor = System.Drawing.Color.White;
			this.ConductorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConductorTextBox.Location = new System.Drawing.Point(199, 16);
			this.ConductorTextBox.Name = "ConductorTextBox";
			this.ConductorTextBox.ReadOnly = true;
			this.ConductorTextBox.Size = new System.Drawing.Size(336, 22);
			this.ConductorTextBox.TabIndex = 3;
			this.ConductorTextBox.TabStop = false;
			// 
			// UnidadTextBox
			// 
			this.UnidadTextBox.BackColor = System.Drawing.Color.White;
			this.UnidadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UnidadTextBox.Location = new System.Drawing.Point(71, 16);
			this.UnidadTextBox.Name = "UnidadTextBox";
			this.UnidadTextBox.ReadOnly = true;
			this.UnidadTextBox.Size = new System.Drawing.Size(100, 22);
			this.UnidadTextBox.TabIndex = 1;
			this.UnidadTextBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Unidad";
			// 
			// KilometrajeActualTextBox
			// 
			this.KilometrajeActualTextBox.BackColor = System.Drawing.Color.White;
			this.KilometrajeActualTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.KilometrajeActualTextBox.Location = new System.Drawing.Point(402, 47);
			this.KilometrajeActualTextBox.Name = "KilometrajeActualTextBox";
			this.KilometrajeActualTextBox.Size = new System.Drawing.Size(133, 22);
			this.KilometrajeActualTextBox.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(270, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 17);
			this.label8.TabIndex = 6;
			this.label8.Text = "Kilometraje actual";
			// 
			// KilometrajeAnteriorTextBox
			// 
			this.KilometrajeAnteriorTextBox.BackColor = System.Drawing.Color.White;
			this.KilometrajeAnteriorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.KilometrajeAnteriorTextBox.Location = new System.Drawing.Point(151, 47);
			this.KilometrajeAnteriorTextBox.Name = "KilometrajeAnteriorTextBox";
			this.KilometrajeAnteriorTextBox.ReadOnly = true;
			this.KilometrajeAnteriorTextBox.Size = new System.Drawing.Size(99, 22);
			this.KilometrajeAnteriorTextBox.TabIndex = 5;
			this.KilometrajeAnteriorTextBox.TabStop = false;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(131, 17);
			this.label9.TabIndex = 4;
			this.label9.Text = "Kilometraje anterior";
			// 
			// txtLitros
			// 
			this.txtLitros.BackColor = System.Drawing.Color.White;
			this.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLitros.Location = new System.Drawing.Point(151, 78);
			this.txtLitros.Name = "txtLitros";
			this.txtLitros.Size = new System.Drawing.Size(99, 22);
			this.txtLitros.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Consumo en Litros";
			// 
			// ActualizaKilometrajeNomina
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancela;
			this.ClientSize = new System.Drawing.Size(567, 177);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancela);
			this.Controls.Add(this.btnActualiza);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActualizaKilometrajeNomina";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Actualizar Kilometraje";
			this.Shown += new System.EventHandler(this.ActualizaKilometrajeNomina_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnActualiza;
		private System.Windows.Forms.Button btnCancela;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox KilometrajeActualTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox KilometrajeAnteriorTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox UnidadTextBox;
		public System.Windows.Forms.TextBox ConductorTextBox;
		private System.Windows.Forms.TextBox txtLitros;
		private System.Windows.Forms.Label label2;
	}
}