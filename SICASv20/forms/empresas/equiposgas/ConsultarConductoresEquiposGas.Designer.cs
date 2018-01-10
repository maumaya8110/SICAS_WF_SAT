namespace SICASv20.forms.empresas.equiposgas
{
	partial class ConsultarConductoresEquiposGas
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.chkFechas = new System.Windows.Forms.CheckBox();
			this.dteFin = new System.Windows.Forms.DateTimePicker();
			this.dteInicio = new System.Windows.Forms.DateTimePicker();
			this.cmbEquiposGas = new System.Windows.Forms.ComboBox();
			this.cmbConductores = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.dgvConductoresEquipoGas = new System.Windows.Forms.DataGridView();
			this.cNumeroEconomico = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EquipoGas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MontoDiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CobroActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.TotalDiasCargados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MontoCargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MontoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Estatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gbConsultaEquiposGas = new System.Windows.Forms.GroupBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvConductoresEquipoGas)).BeginInit();
			this.gbConsultaEquiposGas.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 20);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvConductoresEquipoGas);
			this.splitContainer1.Size = new System.Drawing.Size(1315, 556);
			this.splitContainer1.SplitterDistance = 76;
			this.splitContainer1.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.chkFechas);
			this.splitContainer2.Panel1.Controls.Add(this.dteFin);
			this.splitContainer2.Panel1.Controls.Add(this.dteInicio);
			this.splitContainer2.Panel1.Controls.Add(this.cmbEquiposGas);
			this.splitContainer2.Panel1.Controls.Add(this.cmbConductores);
			this.splitContainer2.Panel1.Controls.Add(this.label4);
			this.splitContainer2.Panel1.Controls.Add(this.label3);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.btnExportar);
			this.splitContainer2.Panel2.Controls.Add(this.btnAgregar);
			this.splitContainer2.Panel2.Controls.Add(this.btnConsultar);
			this.splitContainer2.Size = new System.Drawing.Size(1315, 76);
			this.splitContainer2.SplitterDistance = 858;
			this.splitContainer2.TabIndex = 0;
			// 
			// chkFechas
			// 
			this.chkFechas.AutoSize = true;
			this.chkFechas.Location = new System.Drawing.Point(9, 53);
			this.chkFechas.Name = "chkFechas";
			this.chkFechas.Size = new System.Drawing.Size(175, 22);
			this.chkFechas.TabIndex = 8;
			this.chkFechas.Text = "Por Rango de Fechas";
			this.chkFechas.UseVisualStyleBackColor = true;
			this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
			// 
			// dteFin
			// 
			this.dteFin.Enabled = false;
			this.dteFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFin.Location = new System.Drawing.Point(527, 52);
			this.dteFin.Name = "dteFin";
			this.dteFin.Size = new System.Drawing.Size(126, 24);
			this.dteFin.TabIndex = 7;
			// 
			// dteInicio
			// 
			this.dteInicio.Enabled = false;
			this.dteInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteInicio.Location = new System.Drawing.Point(300, 52);
			this.dteInicio.Name = "dteInicio";
			this.dteInicio.Size = new System.Drawing.Size(121, 24);
			this.dteInicio.TabIndex = 6;
			// 
			// cmbEquiposGas
			// 
			this.cmbEquiposGas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbEquiposGas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbEquiposGas.DisplayMember = "NumeroSerieKit";
			this.cmbEquiposGas.FormattingEnabled = true;
			this.cmbEquiposGas.Location = new System.Drawing.Point(527, 18);
			this.cmbEquiposGas.Name = "cmbEquiposGas";
			this.cmbEquiposGas.Size = new System.Drawing.Size(321, 26);
			this.cmbEquiposGas.TabIndex = 5;
			this.cmbEquiposGas.ValueMember = "Id";
			// 
			// cmbConductores
			// 
			this.cmbConductores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbConductores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbConductores.DisplayMember = "Nombre";
			this.cmbConductores.FormattingEnabled = true;
			this.cmbConductores.Location = new System.Drawing.Point(106, 18);
			this.cmbConductores.Name = "cmbConductores";
			this.cmbConductores.Size = new System.Drawing.Size(317, 26);
			this.cmbConductores.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(444, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "Fecha Fin:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(203, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Fecha Inicio:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(427, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Equipos de Gas";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Conductores";
			// 
			// btnExportar
			// 
			this.btnExportar.Location = new System.Drawing.Point(286, 18);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(116, 52);
			this.btnExportar.TabIndex = 2;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(153, 18);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(116, 52);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Asignación";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(20, 18);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(116, 52);
			this.btnConsultar.TabIndex = 0;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// dgvConductoresEquipoGas
			// 
			this.dgvConductoresEquipoGas.AllowUserToAddRows = false;
			this.dgvConductoresEquipoGas.AllowUserToDeleteRows = false;
			this.dgvConductoresEquipoGas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConductoresEquipoGas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
			this.dgvConductoresEquipoGas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConductoresEquipoGas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNumeroEconomico,
            this.Conductor,
            this.EquipoGas,
            this.FechaInicio,
            this.FechaFin,
            this.MontoDiario,
            this.CobroActivo,
            this.TotalDiasCargados,
            this.MontoCargado,
            this.MontoPagado,
            this.Saldo,
            this.Estatus});
			this.dgvConductoresEquipoGas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvConductoresEquipoGas.Location = new System.Drawing.Point(0, 0);
			this.dgvConductoresEquipoGas.MultiSelect = false;
			this.dgvConductoresEquipoGas.Name = "dgvConductoresEquipoGas";
			this.dgvConductoresEquipoGas.ReadOnly = true;
			this.dgvConductoresEquipoGas.RowTemplate.Height = 24;
			this.dgvConductoresEquipoGas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConductoresEquipoGas.Size = new System.Drawing.Size(1315, 476);
			this.dgvConductoresEquipoGas.TabIndex = 0;
			this.dgvConductoresEquipoGas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConductoresEquipoGas_CellMouseDoubleClick);
			// 
			// cNumeroEconomico
			// 
			this.cNumeroEconomico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.cNumeroEconomico.DataPropertyName = "Unidad";
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.cNumeroEconomico.DefaultCellStyle = dataGridViewCellStyle20;
			this.cNumeroEconomico.Frozen = true;
			this.cNumeroEconomico.HeaderText = "# Economico";
			this.cNumeroEconomico.Name = "cNumeroEconomico";
			this.cNumeroEconomico.ReadOnly = true;
			this.cNumeroEconomico.Width = 112;
			// 
			// Conductor
			// 
			this.Conductor.DataPropertyName = "Conductor";
			this.Conductor.Frozen = true;
			this.Conductor.HeaderText = "Conductor";
			this.Conductor.Name = "Conductor";
			this.Conductor.ReadOnly = true;
			this.Conductor.Width = 103;
			// 
			// EquipoGas
			// 
			this.EquipoGas.DataPropertyName = "Equipo_Gas";
			this.EquipoGas.HeaderText = "Equipo de Gas";
			this.EquipoGas.Name = "EquipoGas";
			this.EquipoGas.ReadOnly = true;
			this.EquipoGas.Width = 95;
			// 
			// FechaInicio
			// 
			this.FechaInicio.DataPropertyName = "FechaInicio";
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle21.Format = "d";
			dataGridViewCellStyle21.NullValue = null;
			this.FechaInicio.DefaultCellStyle = dataGridViewCellStyle21;
			this.FechaInicio.HeaderText = "Fecha Inicio";
			this.FechaInicio.Name = "FechaInicio";
			this.FechaInicio.ReadOnly = true;
			this.FechaInicio.Width = 103;
			// 
			// FechaFin
			// 
			this.FechaFin.DataPropertyName = "FechaFin";
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.Format = "d";
			dataGridViewCellStyle22.NullValue = null;
			this.FechaFin.DefaultCellStyle = dataGridViewCellStyle22;
			this.FechaFin.HeaderText = "Fecha Fin";
			this.FechaFin.Name = "FechaFin";
			this.FechaFin.ReadOnly = true;
			this.FechaFin.Width = 90;
			// 
			// MontoDiario
			// 
			this.MontoDiario.DataPropertyName = "MontoDiario";
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle23.Format = "C2";
			dataGridViewCellStyle23.NullValue = null;
			this.MontoDiario.DefaultCellStyle = dataGridViewCellStyle23;
			this.MontoDiario.HeaderText = "Monto Diario";
			this.MontoDiario.Name = "MontoDiario";
			this.MontoDiario.ReadOnly = true;
			this.MontoDiario.Width = 109;
			// 
			// CobroActivo
			// 
			this.CobroActivo.DataPropertyName = "CobroActivo";
			this.CobroActivo.HeaderText = "Cobro Activo";
			this.CobroActivo.Name = "CobroActivo";
			this.CobroActivo.ReadOnly = true;
			this.CobroActivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.CobroActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.CobroActivo.Width = 109;
			// 
			// TotalDiasCargados
			// 
			this.TotalDiasCargados.DataPropertyName = "TotalDiasCargados";
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle24.Format = "N0";
			dataGridViewCellStyle24.NullValue = null;
			this.TotalDiasCargados.DefaultCellStyle = dataGridViewCellStyle24;
			this.TotalDiasCargados.HeaderText = "Dias Cargados";
			this.TotalDiasCargados.Name = "TotalDiasCargados";
			this.TotalDiasCargados.ReadOnly = true;
			this.TotalDiasCargados.Width = 121;
			// 
			// MontoCargado
			// 
			this.MontoCargado.DataPropertyName = "MontoCargosEquipoGas";
			dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle25.Format = "C2";
			dataGridViewCellStyle25.NullValue = null;
			this.MontoCargado.DefaultCellStyle = dataGridViewCellStyle25;
			this.MontoCargado.HeaderText = "Monto Cargado";
			this.MontoCargado.Name = "MontoCargado";
			this.MontoCargado.ReadOnly = true;
			this.MontoCargado.Width = 125;
			// 
			// MontoPagado
			// 
			this.MontoPagado.DataPropertyName = "MontoPagado";
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle26.Format = "C2";
			dataGridViewCellStyle26.NullValue = null;
			this.MontoPagado.DefaultCellStyle = dataGridViewCellStyle26;
			this.MontoPagado.HeaderText = "Monto Pagado";
			this.MontoPagado.Name = "MontoPagado";
			this.MontoPagado.ReadOnly = true;
			this.MontoPagado.Width = 120;
			// 
			// Saldo
			// 
			this.Saldo.DataPropertyName = "Saldo";
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle27.Format = "C2";
			dataGridViewCellStyle27.NullValue = null;
			this.Saldo.DefaultCellStyle = dataGridViewCellStyle27;
			this.Saldo.HeaderText = "Saldo";
			this.Saldo.Name = "Saldo";
			this.Saldo.ReadOnly = true;
			this.Saldo.Width = 71;
			// 
			// Estatus
			// 
			this.Estatus.DataPropertyName = "Estatus";
			this.Estatus.HeaderText = "Asignado";
			this.Estatus.Name = "Estatus";
			this.Estatus.ReadOnly = true;
			this.Estatus.TrueValue = "1";
			this.Estatus.Width = 75;
			// 
			// gbConsultaEquiposGas
			// 
			this.gbConsultaEquiposGas.BackColor = System.Drawing.Color.Transparent;
			this.gbConsultaEquiposGas.Controls.Add(this.splitContainer1);
			this.gbConsultaEquiposGas.Location = new System.Drawing.Point(12, 12);
			this.gbConsultaEquiposGas.Name = "gbConsultaEquiposGas";
			this.gbConsultaEquiposGas.Size = new System.Drawing.Size(1321, 579);
			this.gbConsultaEquiposGas.TabIndex = 2;
			this.gbConsultaEquiposGas.TabStop = false;
			this.gbConsultaEquiposGas.Text = "Equipos de Gas";
			// 
			// ConsultarConductoresEquiposGas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1353, 614);
			this.Controls.Add(this.gbConsultaEquiposGas);
			this.Name = "ConsultarConductoresEquiposGas";
			this.Text = "AsignarEquipoGasConductor";
			this.Controls.SetChildIndex(this.gbConsultaEquiposGas, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvConductoresEquipoGas)).EndInit();
			this.gbConsultaEquiposGas.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvConductoresEquipoGas;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gbConsultaEquiposGas;
		private System.Windows.Forms.DateTimePicker dteFin;
		private System.Windows.Forms.DateTimePicker dteInicio;
		private System.Windows.Forms.ComboBox cmbEquiposGas;
		private System.Windows.Forms.ComboBox cmbConductores;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.CheckBox chkFechas;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNumeroEconomico;
		private System.Windows.Forms.DataGridViewTextBoxColumn Conductor;
		private System.Windows.Forms.DataGridViewTextBoxColumn EquipoGas;
		private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
		private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
		private System.Windows.Forms.DataGridViewTextBoxColumn MontoDiario;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CobroActivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiasCargados;
		private System.Windows.Forms.DataGridViewTextBoxColumn MontoCargado;
		private System.Windows.Forms.DataGridViewTextBoxColumn MontoPagado;
		private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Estatus;
	}
}