namespace SICASv20.forms.aeropuerto.nomina
{
	partial class AgregaIncidenciaConductor
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.gbAnula = new System.Windows.Forms.GroupBox();
			this.txtObservacionGral = new System.Windows.Forms.TextBox();
			this.cmbPeriodos = new System.Windows.Forms.ComboBox();
			this.gbPago = new System.Windows.Forms.GroupBox();
			this.txtMontoPE = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtObservacionesPE = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gbDescuento = new System.Windows.Forms.GroupBox();
			this.txtMontoDesc = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbTiposIncidencias = new System.Windows.Forms.ComboBox();
			this.cmbConductores = new System.Windows.Forms.ComboBox();
			this.lblFecha = new System.Windows.Forms.Label();
			this.lblTipoIncidencia = new System.Windows.Forms.Label();
			this.lblConductor = new System.Windows.Forms.Label();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.gbAnula.SuspendLayout();
			this.gbPago.SuspendLayout();
			this.gbDescuento.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.gbAnula);
			this.panel1.Controls.Add(this.cmbPeriodos);
			this.panel1.Controls.Add(this.gbPago);
			this.panel1.Controls.Add(this.gbDescuento);
			this.panel1.Controls.Add(this.cmbTiposIncidencias);
			this.panel1.Controls.Add(this.cmbConductores);
			this.panel1.Controls.Add(this.lblFecha);
			this.panel1.Controls.Add(this.lblTipoIncidencia);
			this.panel1.Controls.Add(this.lblConductor);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(603, 248);
			this.panel1.TabIndex = 0;
			// 
			// gbAnula
			// 
			this.gbAnula.Controls.Add(this.txtObservacionGral);
			this.gbAnula.Location = new System.Drawing.Point(75, 74);
			this.gbAnula.Name = "gbAnula";
			this.gbAnula.Size = new System.Drawing.Size(584, 152);
			this.gbAnula.TabIndex = 11;
			this.gbAnula.TabStop = false;
			this.gbAnula.Text = "Observaciones";
			// 
			// txtObservacionGral
			// 
			this.txtObservacionGral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtObservacionGral.Location = new System.Drawing.Point(3, 18);
			this.txtObservacionGral.Multiline = true;
			this.txtObservacionGral.Name = "txtObservacionGral";
			this.txtObservacionGral.Size = new System.Drawing.Size(578, 131);
			this.txtObservacionGral.TabIndex = 1;
			// 
			// cmbPeriodos
			// 
			this.cmbPeriodos.FormattingEnabled = true;
			this.cmbPeriodos.Location = new System.Drawing.Point(461, 44);
			this.cmbPeriodos.Name = "cmbPeriodos";
			this.cmbPeriodos.Size = new System.Drawing.Size(131, 24);
			this.cmbPeriodos.TabIndex = 10;
			// 
			// gbPago
			// 
			this.gbPago.Controls.Add(this.txtMontoPE);
			this.gbPago.Controls.Add(this.label3);
			this.gbPago.Controls.Add(this.txtObservacionesPE);
			this.gbPago.Controls.Add(this.label4);
			this.gbPago.Location = new System.Drawing.Point(37, 91);
			this.gbPago.Name = "gbPago";
			this.gbPago.Size = new System.Drawing.Size(584, 152);
			this.gbPago.TabIndex = 9;
			this.gbPago.TabStop = false;
			this.gbPago.Text = "Pago Extraordinario";
			// 
			// txtMontoPE
			// 
			this.txtMontoPE.Location = new System.Drawing.Point(121, 21);
			this.txtMontoPE.Name = "txtMontoPE";
			this.txtMontoPE.Size = new System.Drawing.Size(88, 22);
			this.txtMontoPE.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(63, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Monto:";
			// 
			// txtObservacionesPE
			// 
			this.txtObservacionesPE.Location = new System.Drawing.Point(121, 49);
			this.txtObservacionesPE.Multiline = true;
			this.txtObservacionesPE.Name = "txtObservacionesPE";
			this.txtObservacionesPE.Size = new System.Drawing.Size(457, 97);
			this.txtObservacionesPE.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 17);
			this.label4.TabIndex = 0;
			this.label4.Text = "Observaciones:";
			// 
			// gbDescuento
			// 
			this.gbDescuento.Controls.Add(this.txtMontoDesc);
			this.gbDescuento.Controls.Add(this.label5);
			this.gbDescuento.Controls.Add(this.txtObservaciones);
			this.gbDescuento.Controls.Add(this.label6);
			this.gbDescuento.Location = new System.Drawing.Point(7, 115);
			this.gbDescuento.Name = "gbDescuento";
			this.gbDescuento.Size = new System.Drawing.Size(584, 152);
			this.gbDescuento.TabIndex = 8;
			this.gbDescuento.TabStop = false;
			this.gbDescuento.Text = "Descuento";
			// 
			// txtMontoDesc
			// 
			this.txtMontoDesc.Location = new System.Drawing.Point(121, 21);
			this.txtMontoDesc.Name = "txtMontoDesc";
			this.txtMontoDesc.Size = new System.Drawing.Size(88, 22);
			this.txtMontoDesc.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(65, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "Monto:";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Location = new System.Drawing.Point(121, 49);
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(457, 97);
			this.txtObservaciones.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "Observaciones:";
			// 
			// cmbTiposIncidencias
			// 
			this.cmbTiposIncidencias.FormattingEnabled = true;
			this.cmbTiposIncidencias.Location = new System.Drawing.Point(113, 44);
			this.cmbTiposIncidencias.Name = "cmbTiposIncidencias";
			this.cmbTiposIncidencias.Size = new System.Drawing.Size(208, 24);
			this.cmbTiposIncidencias.TabIndex = 4;
			this.cmbTiposIncidencias.SelectedIndexChanged += new System.EventHandler(this.cmbTiposIncidencias_SelectedIndexChanged);
			// 
			// cmbConductores
			// 
			this.cmbConductores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbConductores.FormattingEnabled = true;
			this.cmbConductores.Location = new System.Drawing.Point(113, 7);
			this.cmbConductores.Name = "cmbConductores";
			this.cmbConductores.Size = new System.Drawing.Size(479, 24);
			this.cmbConductores.TabIndex = 3;
			// 
			// lblFecha
			// 
			this.lblFecha.AutoSize = true;
			this.lblFecha.Location = new System.Drawing.Point(398, 48);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(57, 17);
			this.lblFecha.TabIndex = 2;
			this.lblFecha.Text = "Periodo";
			// 
			// lblTipoIncidencia
			// 
			this.lblTipoIncidencia.AutoSize = true;
			this.lblTipoIncidencia.Location = new System.Drawing.Point(4, 48);
			this.lblTipoIncidencia.Name = "lblTipoIncidencia";
			this.lblTipoIncidencia.Size = new System.Drawing.Size(103, 17);
			this.lblTipoIncidencia.TabIndex = 1;
			this.lblTipoIncidencia.Text = "Tipo Incidencia";
			// 
			// lblConductor
			// 
			this.lblConductor.AutoSize = true;
			this.lblConductor.Location = new System.Drawing.Point(34, 11);
			this.lblConductor.Name = "lblConductor";
			this.lblConductor.Size = new System.Drawing.Size(73, 17);
			this.lblConductor.TabIndex = 0;
			this.lblConductor.Text = "Conductor";
			// 
			// btnCerrar
			// 
			this.btnCerrar.Location = new System.Drawing.Point(428, 260);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(119, 43);
			this.btnCerrar.TabIndex = 1;
			this.btnCerrar.Text = "&Regresar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(255, 260);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(126, 43);
			this.btnGuardar.TabIndex = 2;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnCancelar.Location = new System.Drawing.Point(82, 260);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(126, 43);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "&Cancela Incidencia";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Visible = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// AgregaIncidenciaConductor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCerrar;
			this.ClientSize = new System.Drawing.Size(613, 311);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AgregaIncidenciaConductor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agrega Incidencia de Conductor";
			this.Shown += new System.EventHandler(this.AgregaIncidenciaConductor_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gbAnula.ResumeLayout(false);
			this.gbAnula.PerformLayout();
			this.gbPago.ResumeLayout(false);
			this.gbPago.PerformLayout();
			this.gbDescuento.ResumeLayout(false);
			this.gbDescuento.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.ComboBox cmbTiposIncidencias;
		private System.Windows.Forms.ComboBox cmbConductores;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Label lblTipoIncidencia;
		private System.Windows.Forms.Label lblConductor;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.GroupBox gbPago;
		private System.Windows.Forms.TextBox txtMontoPE;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtObservacionesPE;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gbDescuento;
		private System.Windows.Forms.TextBox txtMontoDesc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbPeriodos;
		private System.Windows.Forms.GroupBox gbAnula;
		private System.Windows.Forms.TextBox txtObservacionGral;
	}
}