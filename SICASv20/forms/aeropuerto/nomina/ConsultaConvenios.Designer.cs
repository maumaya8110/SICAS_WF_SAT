namespace SICASv20.forms.aeropuerto.nomina
{
	partial class ConsultaConvenios
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.cmdExportar = new System.Windows.Forms.Button();
			this.cmdConsultar = new System.Windows.Forms.Button();
			this.cmbTipoConvenio = new System.Windows.Forms.ComboBox();
			this.cmbConductor = new System.Windows.Forms.ComboBox();
			this.chkConSaldo = new System.Windows.Forms.CheckBox();
			this.cmbEstacion = new System.Windows.Forms.ComboBox();
			this.cmbEmpresa = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvConvenios = new System.Windows.Forms.DataGridView();
			this.cEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cConductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cTipoConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cMontoParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cSaldoActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCantidadDescuentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDescuentosAplicados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDescuentosPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cUltimaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cTieneDocumentos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.groupBox1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvConvenios)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1152, 628);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Consulta Convenios";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 20);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cmdExportar);
			this.splitContainer1.Panel1.Controls.Add(this.cmdConsultar);
			this.splitContainer1.Panel1.Controls.Add(this.cmbTipoConvenio);
			this.splitContainer1.Panel1.Controls.Add(this.cmbConductor);
			this.splitContainer1.Panel1.Controls.Add(this.chkConSaldo);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEstacion);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEmpresa);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvConvenios);
			this.splitContainer1.Size = new System.Drawing.Size(1146, 605);
			this.splitContainer1.SplitterDistance = 83;
			this.splitContainer1.TabIndex = 0;
			// 
			// cmdExportar
			// 
			this.cmdExportar.Location = new System.Drawing.Point(992, 15);
			this.cmdExportar.Name = "cmdExportar";
			this.cmdExportar.Size = new System.Drawing.Size(142, 59);
			this.cmdExportar.TabIndex = 11;
			this.cmdExportar.Text = "Exportar";
			this.cmdExportar.UseVisualStyleBackColor = true;
			this.cmdExportar.Click += new System.EventHandler(this.cmdExportar_Click);
			// 
			// cmdConsultar
			// 
			this.cmdConsultar.Location = new System.Drawing.Point(828, 15);
			this.cmdConsultar.Name = "cmdConsultar";
			this.cmdConsultar.Size = new System.Drawing.Size(142, 59);
			this.cmdConsultar.TabIndex = 10;
			this.cmdConsultar.Text = "Consultar";
			this.cmdConsultar.UseVisualStyleBackColor = true;
			this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
			// 
			// cmbTipoConvenio
			// 
			this.cmbTipoConvenio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTipoConvenio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTipoConvenio.DisplayMember = "Nombre";
			this.cmbTipoConvenio.FormattingEnabled = true;
			this.cmbTipoConvenio.Location = new System.Drawing.Point(410, 44);
			this.cmbTipoConvenio.Name = "cmbTipoConvenio";
			this.cmbTipoConvenio.Size = new System.Drawing.Size(280, 26);
			this.cmbTipoConvenio.TabIndex = 9;
			this.cmbTipoConvenio.ValueMember = "Id";
			// 
			// cmbConductor
			// 
			this.cmbConductor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbConductor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbConductor.DisplayMember = "Nombre";
			this.cmbConductor.FormattingEnabled = true;
			this.cmbConductor.Location = new System.Drawing.Point(410, 12);
			this.cmbConductor.Name = "cmbConductor";
			this.cmbConductor.Size = new System.Drawing.Size(386, 26);
			this.cmbConductor.TabIndex = 8;
			this.cmbConductor.ValueMember = "Id";
			// 
			// chkConSaldo
			// 
			this.chkConSaldo.AutoSize = true;
			this.chkConSaldo.Checked = true;
			this.chkConSaldo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkConSaldo.Location = new System.Drawing.Point(696, 46);
			this.chkConSaldo.Name = "chkConSaldo";
			this.chkConSaldo.Size = new System.Drawing.Size(100, 22);
			this.chkConSaldo.TabIndex = 7;
			this.chkConSaldo.Text = "Con Saldo";
			this.chkConSaldo.UseVisualStyleBackColor = true;
			// 
			// cmbEstacion
			// 
			this.cmbEstacion.DisplayMember = "Nombre";
			this.cmbEstacion.FormattingEnabled = true;
			this.cmbEstacion.Location = new System.Drawing.Point(106, 44);
			this.cmbEstacion.Name = "cmbEstacion";
			this.cmbEstacion.Size = new System.Drawing.Size(180, 26);
			this.cmbEstacion.TabIndex = 6;
			this.cmbEstacion.ValueMember = "Estacion_ID";
			// 
			// cmbEmpresa
			// 
			this.cmbEmpresa.DisplayMember = "Nombre";
			this.cmbEmpresa.FormattingEnabled = true;
			this.cmbEmpresa.Location = new System.Drawing.Point(106, 12);
			this.cmbEmpresa.Name = "cmbEmpresa";
			this.cmbEmpresa.Size = new System.Drawing.Size(180, 26);
			this.cmbEmpresa.TabIndex = 5;
			this.cmbEmpresa.ValueMember = "Empresa_ID";
			this.cmbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cmbEmpresa_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(300, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "Tipo Convenio";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Estacion";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Empresa";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(326, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Conductor";
			// 
			// dgvConvenios
			// 
			this.dgvConvenios.AllowUserToAddRows = false;
			this.dgvConvenios.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvConvenios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConvenios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvConvenios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConvenios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEmpresa,
            this.cEstacion,
            this.cConductor,
            this.cTipoConvenio,
            this.cFecha,
            this.cMontoTotal,
            this.cMontoParcial,
            this.cSaldoActual,
            this.cCantidadDescuentos,
            this.cDescuentosAplicados,
            this.cDescuentosPendientes,
            this.cUltimaFecha,
            this.cTieneDocumentos});
			this.dgvConvenios.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvConvenios.Location = new System.Drawing.Point(0, 0);
			this.dgvConvenios.Name = "dgvConvenios";
			this.dgvConvenios.ReadOnly = true;
			this.dgvConvenios.RowTemplate.Height = 24;
			this.dgvConvenios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConvenios.Size = new System.Drawing.Size(1146, 518);
			this.dgvConvenios.TabIndex = 0;
			// 
			// cEmpresa
			// 
			this.cEmpresa.DataPropertyName = "Empresa";
			this.cEmpresa.HeaderText = "Empresa";
			this.cEmpresa.Name = "cEmpresa";
			this.cEmpresa.ReadOnly = true;
			// 
			// cEstacion
			// 
			this.cEstacion.DataPropertyName = "Estacion";
			this.cEstacion.HeaderText = "Estación";
			this.cEstacion.Name = "cEstacion";
			this.cEstacion.ReadOnly = true;
			// 
			// cConductor
			// 
			this.cConductor.DataPropertyName = "Conductor";
			this.cConductor.HeaderText = "Conductor";
			this.cConductor.Name = "cConductor";
			this.cConductor.ReadOnly = true;
			// 
			// cTipoConvenio
			// 
			this.cTipoConvenio.DataPropertyName = "TipoConvenio";
			this.cTipoConvenio.HeaderText = "Tipo Convenio";
			this.cTipoConvenio.Name = "cTipoConvenio";
			this.cTipoConvenio.ReadOnly = true;
			// 
			// cFecha
			// 
			this.cFecha.DataPropertyName = "FechaElaboracion";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Format = "d";
			this.cFecha.DefaultCellStyle = dataGridViewCellStyle3;
			this.cFecha.HeaderText = "Fecha";
			this.cFecha.Name = "cFecha";
			this.cFecha.ReadOnly = true;
			// 
			// cMontoTotal
			// 
			this.cMontoTotal.DataPropertyName = "MontoTotalAPagar";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "C2";
			dataGridViewCellStyle4.NullValue = null;
			this.cMontoTotal.DefaultCellStyle = dataGridViewCellStyle4;
			this.cMontoTotal.HeaderText = "Monto a Pagar";
			this.cMontoTotal.Name = "cMontoTotal";
			this.cMontoTotal.ReadOnly = true;
			// 
			// cMontoParcial
			// 
			this.cMontoParcial.DataPropertyName = "MontoParcialidad";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "C2";
			this.cMontoParcial.DefaultCellStyle = dataGridViewCellStyle5;
			this.cMontoParcial.HeaderText = "Parcialidad";
			this.cMontoParcial.Name = "cMontoParcial";
			this.cMontoParcial.ReadOnly = true;
			// 
			// cSaldoActual
			// 
			this.cSaldoActual.DataPropertyName = "SaldoActual";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "C2";
			this.cSaldoActual.DefaultCellStyle = dataGridViewCellStyle6;
			this.cSaldoActual.HeaderText = "Saldo";
			this.cSaldoActual.Name = "cSaldoActual";
			this.cSaldoActual.ReadOnly = true;
			// 
			// cCantidadDescuentos
			// 
			this.cCantidadDescuentos.DataPropertyName = "CantidadDescuentos";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Format = "N0";
			dataGridViewCellStyle7.NullValue = null;
			this.cCantidadDescuentos.DefaultCellStyle = dataGridViewCellStyle7;
			this.cCantidadDescuentos.HeaderText = "# Descuentos";
			this.cCantidadDescuentos.Name = "cCantidadDescuentos";
			this.cCantidadDescuentos.ReadOnly = true;
			// 
			// cDescuentosAplicados
			// 
			this.cDescuentosAplicados.DataPropertyName = "CantidadDescuentosAplicados";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Format = "N0";
			this.cDescuentosAplicados.DefaultCellStyle = dataGridViewCellStyle8;
			this.cDescuentosAplicados.HeaderText = "# Desc. Aplicados";
			this.cDescuentosAplicados.Name = "cDescuentosAplicados";
			this.cDescuentosAplicados.ReadOnly = true;
			// 
			// cDescuentosPendientes
			// 
			this.cDescuentosPendientes.DataPropertyName = "CantidadDescuentosPendientes";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Format = "N0";
			this.cDescuentosPendientes.DefaultCellStyle = dataGridViewCellStyle9;
			this.cDescuentosPendientes.HeaderText = "# Desc. Pendientes";
			this.cDescuentosPendientes.Name = "cDescuentosPendientes";
			this.cDescuentosPendientes.ReadOnly = true;
			// 
			// cUltimaFecha
			// 
			this.cUltimaFecha.DataPropertyName = "UltimaFechaDescuento";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.Format = "d";
			dataGridViewCellStyle10.NullValue = null;
			this.cUltimaFecha.DefaultCellStyle = dataGridViewCellStyle10;
			this.cUltimaFecha.HeaderText = "Ultima Movimiento";
			this.cUltimaFecha.Name = "cUltimaFecha";
			this.cUltimaFecha.ReadOnly = true;
			// 
			// cTieneDocumentos
			// 
			this.cTieneDocumentos.DataPropertyName = "TieneDocumentoFirmado";
			this.cTieneDocumentos.FalseValue = "0";
			this.cTieneDocumentos.HeaderText = "Convenio Firmado?";
			this.cTieneDocumentos.Name = "cTieneDocumentos";
			this.cTieneDocumentos.ReadOnly = true;
			this.cTieneDocumentos.TrueValue = "1";
			// 
			// ConsultaConvenios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1176, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "ConsultaConvenios";
			this.Text = "ConsultaConvenios";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvConvenios)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvConvenios;
		private System.Windows.Forms.ComboBox cmbTipoConvenio;
		private System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.CheckBox chkConSaldo;
		private System.Windows.Forms.ComboBox cmbEstacion;
		private System.Windows.Forms.ComboBox cmbEmpresa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdExportar;
		private System.Windows.Forms.Button cmdConsultar;
		private System.Windows.Forms.DataGridViewTextBoxColumn cEmpresa;
		private System.Windows.Forms.DataGridViewTextBoxColumn cEstacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn cConductor;
		private System.Windows.Forms.DataGridViewTextBoxColumn cTipoConvenio;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cMontoTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn cMontoParcial;
		private System.Windows.Forms.DataGridViewTextBoxColumn cSaldoActual;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCantidadDescuentos;
		private System.Windows.Forms.DataGridViewTextBoxColumn cDescuentosAplicados;
		private System.Windows.Forms.DataGridViewTextBoxColumn cDescuentosPendientes;
		private System.Windows.Forms.DataGridViewTextBoxColumn cUltimaFecha;
		private System.Windows.Forms.DataGridViewCheckBoxColumn cTieneDocumentos;
	}
}