namespace SICASv20.forms.callcenter.valesempresariales
{
	partial class AsignaValesEmpresariales
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbUsuarios = new System.Windows.Forms.ComboBox();
			this.txtSerie = new System.Windows.Forms.TextBox();
			this.txtFolioInicial = new System.Windows.Forms.TextBox();
			this.txtFolioFinal = new System.Windows.Forms.TextBox();
			this.cmdAsigna = new System.Windows.Forms.Button();
			this.cmdCerrar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Usuario";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Serie:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(162, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Inicio:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(310, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Fin:";
			// 
			// cmbUsuarios
			// 
			this.cmbUsuarios.DisplayMember = "Nombre";
			this.cmbUsuarios.FormattingEnabled = true;
			this.cmbUsuarios.Location = new System.Drawing.Point(85, 15);
			this.cmbUsuarios.Name = "cmbUsuarios";
			this.cmbUsuarios.Size = new System.Drawing.Size(333, 24);
			this.cmbUsuarios.TabIndex = 4;
			this.cmbUsuarios.ValueMember = "ValeEmpresarialUsuario_ID";
			// 
			// txtSerie
			// 
			this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSerie.Location = new System.Drawing.Point(85, 53);
			this.txtSerie.Name = "txtSerie";
			this.txtSerie.Size = new System.Drawing.Size(71, 22);
			this.txtSerie.TabIndex = 5;
			this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtFolioInicial
			// 
			this.txtFolioInicial.Location = new System.Drawing.Point(212, 55);
			this.txtFolioInicial.Name = "txtFolioInicial";
			this.txtFolioInicial.Size = new System.Drawing.Size(71, 22);
			this.txtFolioInicial.TabIndex = 6;
			// 
			// txtFolioFinal
			// 
			this.txtFolioFinal.Location = new System.Drawing.Point(347, 55);
			this.txtFolioFinal.Name = "txtFolioFinal";
			this.txtFolioFinal.Size = new System.Drawing.Size(71, 22);
			this.txtFolioFinal.TabIndex = 7;
			// 
			// cmdAsigna
			// 
			this.cmdAsigna.Location = new System.Drawing.Point(100, 101);
			this.cmdAsigna.Name = "cmdAsigna";
			this.cmdAsigna.Size = new System.Drawing.Size(106, 42);
			this.cmdAsigna.TabIndex = 8;
			this.cmdAsigna.Text = "Asignar";
			this.cmdAsigna.UseVisualStyleBackColor = true;
			this.cmdAsigna.Click += new System.EventHandler(this.cmdAsigna_Click);
			// 
			// cmdCerrar
			// 
			this.cmdCerrar.Location = new System.Drawing.Point(235, 101);
			this.cmdCerrar.Name = "cmdCerrar";
			this.cmdCerrar.Size = new System.Drawing.Size(106, 42);
			this.cmdCerrar.TabIndex = 9;
			this.cmdCerrar.Text = "Cerrar";
			this.cmdCerrar.UseVisualStyleBackColor = true;
			this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
			// 
			// AsignaValesEmpresariales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 155);
			this.Controls.Add(this.cmdCerrar);
			this.Controls.Add(this.cmdAsigna);
			this.Controls.Add(this.txtFolioFinal);
			this.Controls.Add(this.txtFolioInicial);
			this.Controls.Add(this.txtSerie);
			this.Controls.Add(this.cmbUsuarios);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AsignaValesEmpresariales";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Asignación de Vales Empresariales";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbUsuarios;
		private System.Windows.Forms.TextBox txtSerie;
		private System.Windows.Forms.TextBox txtFolioInicial;
		private System.Windows.Forms.TextBox txtFolioFinal;
		private System.Windows.Forms.Button cmdAsigna;
		private System.Windows.Forms.Button cmdCerrar;
	}
}