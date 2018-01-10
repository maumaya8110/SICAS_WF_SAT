namespace SICASv20.forms.aeropuerto.nomina
{
	partial class CapturaConvenio
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
			this.gbCapturaConvenio = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dteFechaCaptura = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbEmpresa = new System.Windows.Forms.ComboBox();
			this.cmbTipoConvenio = new System.Windows.Forms.ComboBox();
			this.cmbEstacion = new System.Windows.Forms.ComboBox();
			this.cmbConductor = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtMontoMinimoParaDescuento = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.dteFechaPrimerDcto = new System.Windows.Forms.DateTimePicker();
			this.label14 = new System.Windows.Forms.Label();
			this.txtMontoParcialidad = new System.Windows.Forms.NumericUpDown();
			this.txtMontoTotal = new System.Windows.Forms.NumericUpDown();
			this.txtDctosPend = new System.Windows.Forms.Label();
			this.txtDctosApl = new System.Windows.Forms.Label();
			this.txtDctos = new System.Windows.Forms.Label();
			this.txtFechaUltimoDescuento = new System.Windows.Forms.Label();
			this.txtSaldoActual = new System.Windows.Forms.Label();
			this.chkConvenioFirmado = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.ttMensajes = new System.Windows.Forms.ToolTip(this.components);
			this.gbCapturaConvenio.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoMinimoParaDescuento)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoParcialidad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoTotal)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCapturaConvenio
			// 
			this.gbCapturaConvenio.BackColor = System.Drawing.Color.Transparent;
			this.gbCapturaConvenio.Controls.Add(this.panel1);
			this.gbCapturaConvenio.Controls.Add(this.groupBox2);
			this.gbCapturaConvenio.Controls.Add(this.groupBox1);
			this.gbCapturaConvenio.Location = new System.Drawing.Point(12, 12);
			this.gbCapturaConvenio.Name = "gbCapturaConvenio";
			this.gbCapturaConvenio.Size = new System.Drawing.Size(802, 400);
			this.gbCapturaConvenio.TabIndex = 0;
			this.gbCapturaConvenio.TabStop = false;
			this.gbCapturaConvenio.Text = "Captura Convenio";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.dteFechaCaptura);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cmbEmpresa);
			this.panel1.Controls.Add(this.cmbTipoConvenio);
			this.panel1.Controls.Add(this.cmbEstacion);
			this.panel1.Controls.Add(this.cmbConductor);
			this.panel1.Location = new System.Drawing.Point(6, 23);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(790, 83);
			this.panel1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Empresa";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(306, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Conductor";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Estacion";
			// 
			// dteFechaCaptura
			// 
			this.dteFechaCaptura.Enabled = false;
			this.dteFechaCaptura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaCaptura.Location = new System.Drawing.Point(636, 45);
			this.dteFechaCaptura.Name = "dteFechaCaptura";
			this.dteFechaCaptura.Size = new System.Drawing.Size(140, 24);
			this.dteFechaCaptura.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(280, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Tipo Convenio";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(583, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Fecha";
			// 
			// cmbEmpresa
			// 
			this.cmbEmpresa.DisplayMember = "Nombre";
			this.cmbEmpresa.FormattingEnabled = true;
			this.cmbEmpresa.Location = new System.Drawing.Point(86, 12);
			this.cmbEmpresa.Name = "cmbEmpresa";
			this.cmbEmpresa.Size = new System.Drawing.Size(180, 26);
			this.cmbEmpresa.TabIndex = 1;
			this.cmbEmpresa.ValueMember = "Empresa_ID";
			this.cmbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cmbEmpresa_SelectionChangeCommitted);
			// 
			// cmbTipoConvenio
			// 
			this.cmbTipoConvenio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTipoConvenio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTipoConvenio.DisplayMember = "Nombre";
			this.cmbTipoConvenio.FormattingEnabled = true;
			this.cmbTipoConvenio.Location = new System.Drawing.Point(390, 44);
			this.cmbTipoConvenio.Name = "cmbTipoConvenio";
			this.cmbTipoConvenio.Size = new System.Drawing.Size(186, 26);
			this.cmbTipoConvenio.TabIndex = 7;
			this.cmbTipoConvenio.ValueMember = "Id";
			// 
			// cmbEstacion
			// 
			this.cmbEstacion.DisplayMember = "Nombre";
			this.cmbEstacion.FormattingEnabled = true;
			this.cmbEstacion.Location = new System.Drawing.Point(86, 44);
			this.cmbEstacion.Name = "cmbEstacion";
			this.cmbEstacion.Size = new System.Drawing.Size(180, 26);
			this.cmbEstacion.TabIndex = 3;
			this.cmbEstacion.ValueMember = "Estacion_ID";
			// 
			// cmbConductor
			// 
			this.cmbConductor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbConductor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbConductor.DisplayMember = "Nombre";
			this.cmbConductor.FormattingEnabled = true;
			this.cmbConductor.Location = new System.Drawing.Point(390, 12);
			this.cmbConductor.Name = "cmbConductor";
			this.cmbConductor.Size = new System.Drawing.Size(386, 26);
			this.cmbConductor.TabIndex = 5;
			this.cmbConductor.ValueMember = "Id";
			this.cmbConductor.SelectionChangeCommitted += new System.EventHandler(this.cmbConductor_SelectionChangeCommitted);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtObservaciones);
			this.groupBox2.Location = new System.Drawing.Point(6, 267);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(790, 123);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Observaciones";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtObservaciones.Location = new System.Drawing.Point(3, 20);
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(784, 100);
			this.txtObservaciones.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtMontoMinimoParaDescuento);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.dteFechaPrimerDcto);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtMontoParcialidad);
			this.groupBox1.Controls.Add(this.txtMontoTotal);
			this.groupBox1.Controls.Add(this.txtDctosPend);
			this.groupBox1.Controls.Add(this.txtDctosApl);
			this.groupBox1.Controls.Add(this.txtDctos);
			this.groupBox1.Controls.Add(this.txtFechaUltimoDescuento);
			this.groupBox1.Controls.Add(this.txtSaldoActual);
			this.groupBox1.Controls.Add(this.chkConvenioFirmado);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(6, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(790, 149);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Detalle Convenio";
			// 
			// txtMontoMinimoParaDescuento
			// 
			this.txtMontoMinimoParaDescuento.Location = new System.Drawing.Point(343, 118);
			this.txtMontoMinimoParaDescuento.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.txtMontoMinimoParaDescuento.Name = "txtMontoMinimoParaDescuento";
			this.txtMontoMinimoParaDescuento.Size = new System.Drawing.Size(135, 24);
			this.txtMontoMinimoParaDescuento.TabIndex = 17;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(65, 121);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(272, 18);
			this.label13.TabIndex = 16;
			this.label13.Text = "Sueldo Mínimo para aplicar descuentos:";
			// 
			// dteFechaPrimerDcto
			// 
			this.dteFechaPrimerDcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaPrimerDcto.Location = new System.Drawing.Point(636, 30);
			this.dteFechaPrimerDcto.Name = "dteFechaPrimerDcto";
			this.dteFechaPrimerDcto.Size = new System.Drawing.Size(140, 24);
			this.dteFechaPrimerDcto.TabIndex = 13;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(591, 33);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(38, 18);
			this.label14.TabIndex = 12;
			this.label14.Text = "FPD";
			this.ttMensajes.SetToolTip(this.label14, "Fecha Primer Descuento");
			// 
			// txtMontoParcialidad
			// 
			this.txtMontoParcialidad.Location = new System.Drawing.Point(167, 60);
			this.txtMontoParcialidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.txtMontoParcialidad.Name = "txtMontoParcialidad";
			this.txtMontoParcialidad.Size = new System.Drawing.Size(135, 24);
			this.txtMontoParcialidad.TabIndex = 3;
			this.txtMontoParcialidad.ValueChanged += new System.EventHandler(this.txtMontoParcialidad_ValueChanged);
			// 
			// txtMontoTotal
			// 
			this.txtMontoTotal.Location = new System.Drawing.Point(167, 30);
			this.txtMontoTotal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.txtMontoTotal.Name = "txtMontoTotal";
			this.txtMontoTotal.Size = new System.Drawing.Size(135, 24);
			this.txtMontoTotal.TabIndex = 1;
			// 
			// txtDctosPend
			// 
			this.txtDctosPend.BackColor = System.Drawing.Color.Navy;
			this.txtDctosPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDctosPend.ForeColor = System.Drawing.Color.White;
			this.txtDctosPend.Location = new System.Drawing.Point(489, 89);
			this.txtDctosPend.Name = "txtDctosPend";
			this.txtDctosPend.Size = new System.Drawing.Size(87, 26);
			this.txtDctosPend.TabIndex = 11;
			this.txtDctosPend.Text = "Saldo Actual:";
			this.txtDctosPend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDctosApl
			// 
			this.txtDctosApl.BackColor = System.Drawing.Color.Navy;
			this.txtDctosApl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDctosApl.ForeColor = System.Drawing.Color.White;
			this.txtDctosApl.Location = new System.Drawing.Point(489, 59);
			this.txtDctosApl.Name = "txtDctosApl";
			this.txtDctosApl.Size = new System.Drawing.Size(87, 26);
			this.txtDctosApl.TabIndex = 9;
			this.txtDctosApl.Text = "Saldo Actual:";
			this.txtDctosApl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDctos
			// 
			this.txtDctos.BackColor = System.Drawing.Color.Navy;
			this.txtDctos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDctos.ForeColor = System.Drawing.Color.White;
			this.txtDctos.Location = new System.Drawing.Point(489, 29);
			this.txtDctos.Name = "txtDctos";
			this.txtDctos.Size = new System.Drawing.Size(87, 26);
			this.txtDctos.TabIndex = 7;
			this.txtDctos.Text = "Saldo Actual:";
			this.txtDctos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtFechaUltimoDescuento
			// 
			this.txtFechaUltimoDescuento.BackColor = System.Drawing.Color.Navy;
			this.txtFechaUltimoDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFechaUltimoDescuento.ForeColor = System.Drawing.Color.White;
			this.txtFechaUltimoDescuento.Location = new System.Drawing.Point(636, 59);
			this.txtFechaUltimoDescuento.Name = "txtFechaUltimoDescuento";
			this.txtFechaUltimoDescuento.Size = new System.Drawing.Size(140, 26);
			this.txtFechaUltimoDescuento.TabIndex = 15;
			this.txtFechaUltimoDescuento.Text = "Saldo Actual:";
			this.txtFechaUltimoDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ttMensajes.SetToolTip(this.txtFechaUltimoDescuento, "Fecha Ultimo Descuento");
			// 
			// txtSaldoActual
			// 
			this.txtSaldoActual.BackColor = System.Drawing.Color.Navy;
			this.txtSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSaldoActual.ForeColor = System.Drawing.Color.White;
			this.txtSaldoActual.Location = new System.Drawing.Point(163, 89);
			this.txtSaldoActual.Name = "txtSaldoActual";
			this.txtSaldoActual.Size = new System.Drawing.Size(139, 26);
			this.txtSaldoActual.TabIndex = 5;
			this.txtSaldoActual.Text = "Saldo Actual:";
			this.txtSaldoActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkConvenioFirmado
			// 
			this.chkConvenioFirmado.AutoSize = true;
			this.chkConvenioFirmado.Location = new System.Drawing.Point(595, 91);
			this.chkConvenioFirmado.Name = "chkConvenioFirmado";
			this.chkConvenioFirmado.Size = new System.Drawing.Size(192, 22);
			this.chkConvenioFirmado.TabIndex = 0;
			this.chkConvenioFirmado.Text = "Tiene Convenio Firmado";
			this.chkConvenioFirmado.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(591, 63);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(39, 18);
			this.label12.TabIndex = 14;
			this.label12.Text = "FUD";
			this.ttMensajes.SetToolTip(this.label12, "Fecha Ultimo Descuento");
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(313, 93);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(165, 18);
			this.label11.TabIndex = 10;
			this.label11.Text = "Descuentos Pendientes";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(318, 63);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(160, 18);
			this.label10.TabIndex = 8;
			this.label10.Text = "Descuentos Aplicados:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(378, 33);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 18);
			this.label9.TabIndex = 6;
			this.label9.Text = "# Descuentos";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(65, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 18);
			this.label8.TabIndex = 4;
			this.label8.Text = "Saldo Actual:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 63);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(154, 18);
			this.label7.TabIndex = 2;
			this.label7.Text = "Monto del Descuento:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(148, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "Monto Total A Pagar:";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.btnGuardar);
			this.panel2.Location = new System.Drawing.Point(12, 418);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(802, 80);
			this.panel2.TabIndex = 1;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(625, 12);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(168, 56);
			this.btnGuardar.TabIndex = 0;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// CapturaConvenio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 508);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.gbCapturaConvenio);
			this.Name = "CapturaConvenio";
			this.Text = "CapturaConvenio";
			this.Shown += new System.EventHandler(this.CapturaConvenio_Shown);
			this.Controls.SetChildIndex(this.gbCapturaConvenio, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.gbCapturaConvenio.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoMinimoParaDescuento)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoParcialidad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMontoTotal)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCapturaConvenio;
		private System.Windows.Forms.ComboBox cmbTipoConvenio;
		private System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.ComboBox cmbEstacion;
		private System.Windows.Forms.ComboBox cmbEmpresa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dteFechaCaptura;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox chkConvenioFirmado;
		private System.Windows.Forms.Label txtSaldoActual;
		private System.Windows.Forms.Label txtDctosPend;
		private System.Windows.Forms.Label txtDctosApl;
		private System.Windows.Forms.Label txtDctos;
		private System.Windows.Forms.Label txtFechaUltimoDescuento;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.NumericUpDown txtMontoParcialidad;
		private System.Windows.Forms.NumericUpDown txtMontoTotal;
		private System.Windows.Forms.DateTimePicker dteFechaPrimerDcto;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ToolTip ttMensajes;
		private System.Windows.Forms.NumericUpDown txtMontoMinimoParaDescuento;
		private System.Windows.Forms.Label label13;
	}
}