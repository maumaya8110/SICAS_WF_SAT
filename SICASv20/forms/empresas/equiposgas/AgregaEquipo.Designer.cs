namespace SICASv20.forms.empresas.equiposgas
{
	partial class AgregaEquipo
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtSerieTanque = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDiasAPagar = new System.Windows.Forms.TextBox();
			this.txtMontoDiario = new System.Windows.Forms.TextBox();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.txtCosto = new System.Windows.Forms.TextBox();
			this.txtSerieKit = new System.Windows.Forms.TextBox();
			this.cmbEstacion = new System.Windows.Forms.ComboBox();
			this.cmbEmpresa = new System.Windows.Forms.ComboBox();
			this.chkEstatus = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbEquiposGas = new System.Windows.Forms.ComboBox();
			this.cmbProveedores = new System.Windows.Forms.ComboBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtSerieTanque);
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.txtDiasAPagar);
			this.splitContainer1.Panel1.Controls.Add(this.txtMontoDiario);
			this.splitContainer1.Panel1.Controls.Add(this.txtPrecio);
			this.splitContainer1.Panel1.Controls.Add(this.txtCosto);
			this.splitContainer1.Panel1.Controls.Add(this.txtSerieKit);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEstacion);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEmpresa);
			this.splitContainer1.Panel1.Controls.Add(this.chkEstatus);
			this.splitContainer1.Panel1.Controls.Add(this.label10);
			this.splitContainer1.Panel1.Controls.Add(this.label9);
			this.splitContainer1.Panel1.Controls.Add(this.label8);
			this.splitContainer1.Panel1.Controls.Add(this.label7);
			this.splitContainer1.Panel1.Controls.Add(this.label6);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEquiposGas);
			this.splitContainer1.Panel1.Controls.Add(this.cmbProveedores);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnGuardar);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
			this.splitContainer1.Size = new System.Drawing.Size(660, 260);
			this.splitContainer1.SplitterDistance = 157;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.TabStop = false;
			// 
			// txtSerieTanque
			// 
			this.txtSerieTanque.Location = new System.Drawing.Point(123, 131);
			this.txtSerieTanque.Name = "txtSerieTanque";
			this.txtSerieTanque.Size = new System.Drawing.Size(200, 22);
			this.txtSerieTanque.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "# Serie Tanque:";
			// 
			// txtDiasAPagar
			// 
			this.txtDiasAPagar.Location = new System.Drawing.Point(531, 73);
			this.txtDiasAPagar.Name = "txtDiasAPagar";
			this.txtDiasAPagar.Size = new System.Drawing.Size(100, 22);
			this.txtDiasAPagar.TabIndex = 13;
			this.txtDiasAPagar.TextChanged += new System.EventHandler(this.txtDiasAPagar_TextChanged);
			// 
			// txtMontoDiario
			// 
			this.txtMontoDiario.BackColor = System.Drawing.Color.White;
			this.txtMontoDiario.Enabled = false;
			this.txtMontoDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMontoDiario.Location = new System.Drawing.Point(531, 103);
			this.txtMontoDiario.Name = "txtMontoDiario";
			this.txtMontoDiario.ReadOnly = true;
			this.txtMontoDiario.Size = new System.Drawing.Size(100, 22);
			this.txtMontoDiario.TabIndex = 18;
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(303, 73);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(100, 22);
			this.txtPrecio.TabIndex = 11;
			this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
			// 
			// txtCosto
			// 
			this.txtCosto.Location = new System.Drawing.Point(123, 73);
			this.txtCosto.Name = "txtCosto";
			this.txtCosto.Size = new System.Drawing.Size(100, 22);
			this.txtCosto.TabIndex = 9;
			// 
			// txtSerieKit
			// 
			this.txtSerieKit.Location = new System.Drawing.Point(123, 103);
			this.txtSerieKit.Name = "txtSerieKit";
			this.txtSerieKit.Size = new System.Drawing.Size(200, 22);
			this.txtSerieKit.TabIndex = 15;
			// 
			// cmbEstacion
			// 
			this.cmbEstacion.FormattingEnabled = true;
			this.cmbEstacion.Location = new System.Drawing.Point(437, 40);
			this.cmbEstacion.Name = "cmbEstacion";
			this.cmbEstacion.Size = new System.Drawing.Size(215, 24);
			this.cmbEstacion.TabIndex = 7;
			// 
			// cmbEmpresa
			// 
			this.cmbEmpresa.FormattingEnabled = true;
			this.cmbEmpresa.Location = new System.Drawing.Point(123, 40);
			this.cmbEmpresa.Name = "cmbEmpresa";
			this.cmbEmpresa.Size = new System.Drawing.Size(200, 24);
			this.cmbEmpresa.TabIndex = 5;
			// 
			// chkEstatus
			// 
			this.chkEstatus.AutoSize = true;
			this.chkEstatus.Checked = true;
			this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEstatus.Location = new System.Drawing.Point(329, 104);
			this.chkEstatus.Name = "chkEstatus";
			this.chkEstatus.Size = new System.Drawing.Size(68, 21);
			this.chkEstatus.TabIndex = 16;
			this.chkEstatus.Text = "Activo";
			this.chkEstatus.UseVisualStyleBackColor = true;
			this.chkEstatus.Visible = false;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(45, 106);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(77, 17);
			this.label10.TabIndex = 14;
			this.label10.Text = "# Serie Kit:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(368, 44);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = "Estacion:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(245, 76);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "Precio:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(431, 76);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 17);
			this.label7.TabIndex = 12;
			this.label7.Text = "Días a Pagar:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(54, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 4;
			this.label6.Text = "Empresa:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(431, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 17);
			this.label4.TabIndex = 17;
			this.label4.Text = "Monto Diario:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(74, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Costo:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Euipo de Gas:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(356, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Proveedor:";
			// 
			// cmbEquiposGas
			// 
			this.cmbEquiposGas.FormattingEnabled = true;
			this.cmbEquiposGas.Location = new System.Drawing.Point(123, 7);
			this.cmbEquiposGas.Name = "cmbEquiposGas";
			this.cmbEquiposGas.Size = new System.Drawing.Size(200, 24);
			this.cmbEquiposGas.TabIndex = 1;
			// 
			// cmbProveedores
			// 
			this.cmbProveedores.FormattingEnabled = true;
			this.cmbProveedores.Location = new System.Drawing.Point(434, 7);
			this.cmbProveedores.Name = "cmbProveedores";
			this.cmbProveedores.Size = new System.Drawing.Size(218, 24);
			this.cmbProveedores.TabIndex = 3;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(181, 20);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(116, 52);
			this.btnGuardar.TabIndex = 0;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(357, 19);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(116, 53);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cerrar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// AgregaEquipo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 260);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AgregaEquipo";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agrega Equipo";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.AgregaEquipo_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ComboBox cmbProveedores;
		private System.Windows.Forms.ComboBox cmbEquiposGas;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkEstatus;
		private System.Windows.Forms.TextBox txtSerieKit;
		private System.Windows.Forms.ComboBox cmbEstacion;
		private System.Windows.Forms.ComboBox cmbEmpresa;
		private System.Windows.Forms.TextBox txtDiasAPagar;
		private System.Windows.Forms.TextBox txtMontoDiario;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.TextBox txtCosto;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtSerieTanque;
		private System.Windows.Forms.Label label5;
	}
}