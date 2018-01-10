namespace SICASv20.forms.aeropuerto.nomina
{
	partial class CapturaIncidenciasConductores
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
			this.gbCaptura = new System.Windows.Forms.GroupBox();
			this.cmbPeriodoHasta = new System.Windows.Forms.ComboBox();
			this.cmbPeriodoDesde = new System.Windows.Forms.ComboBox();
			this.cmbConductor = new System.Windows.Forms.ComboBox();
			this.cmbEstatus = new System.Windows.Forms.ComboBox();
			this.cmbTiposIncidencias = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.dgvIncidencias = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.Conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Usuario_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaCaptura = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EstatusIncidencia_Conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PeriodoAplicacionIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AnulaMontoVariable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gbCaptura.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCaptura
			// 
			this.gbCaptura.BackColor = System.Drawing.Color.Transparent;
			this.gbCaptura.Controls.Add(this.cmbPeriodoHasta);
			this.gbCaptura.Controls.Add(this.cmbPeriodoDesde);
			this.gbCaptura.Controls.Add(this.cmbConductor);
			this.gbCaptura.Controls.Add(this.cmbEstatus);
			this.gbCaptura.Controls.Add(this.cmbTiposIncidencias);
			this.gbCaptura.Controls.Add(this.label5);
			this.gbCaptura.Controls.Add(this.label4);
			this.gbCaptura.Controls.Add(this.label3);
			this.gbCaptura.Controls.Add(this.label2);
			this.gbCaptura.Controls.Add(this.label1);
			this.gbCaptura.Controls.Add(this.btnAgregar);
			this.gbCaptura.Controls.Add(this.btnConsultar);
			this.gbCaptura.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbCaptura.Location = new System.Drawing.Point(0, 0);
			this.gbCaptura.Name = "gbCaptura";
			this.gbCaptura.Size = new System.Drawing.Size(784, 151);
			this.gbCaptura.TabIndex = 1;
			this.gbCaptura.TabStop = false;
			this.gbCaptura.Text = "Incidencias por Conductor";
			// 
			// cmbPeriodoHasta
			// 
			this.cmbPeriodoHasta.FormattingEnabled = true;
			this.cmbPeriodoHasta.Location = new System.Drawing.Point(302, 42);
			this.cmbPeriodoHasta.Name = "cmbPeriodoHasta";
			this.cmbPeriodoHasta.Size = new System.Drawing.Size(131, 26);
			this.cmbPeriodoHasta.TabIndex = 13;
			// 
			// cmbPeriodoDesde
			// 
			this.cmbPeriodoDesde.FormattingEnabled = true;
			this.cmbPeriodoDesde.Location = new System.Drawing.Point(100, 42);
			this.cmbPeriodoDesde.Name = "cmbPeriodoDesde";
			this.cmbPeriodoDesde.Size = new System.Drawing.Size(121, 26);
			this.cmbPeriodoDesde.TabIndex = 12;
			// 
			// cmbConductor
			// 
			this.cmbConductor.FormattingEnabled = true;
			this.cmbConductor.Location = new System.Drawing.Point(100, 108);
			this.cmbConductor.Name = "cmbConductor";
			this.cmbConductor.Size = new System.Drawing.Size(333, 26);
			this.cmbConductor.TabIndex = 11;
			this.cmbConductor.SelectedIndexChanged += new System.EventHandler(this.cmbConductor_SelectedIndexChanged);
			// 
			// cmbEstatus
			// 
			this.cmbEstatus.FormattingEnabled = true;
			this.cmbEstatus.Location = new System.Drawing.Point(302, 74);
			this.cmbEstatus.Name = "cmbEstatus";
			this.cmbEstatus.Size = new System.Drawing.Size(131, 26);
			this.cmbEstatus.TabIndex = 10;
			// 
			// cmbTiposIncidencias
			// 
			this.cmbTiposIncidencias.FormattingEnabled = true;
			this.cmbTiposIncidencias.Location = new System.Drawing.Point(100, 74);
			this.cmbTiposIncidencias.Name = "cmbTiposIncidencias";
			this.cmbTiposIncidencias.Size = new System.Drawing.Size(121, 26);
			this.cmbTiposIncidencias.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 111);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 18);
			this.label5.TabIndex = 6;
			this.label5.Text = "Conductor";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(238, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 18);
			this.label4.TabIndex = 5;
			this.label4.Text = "Estatus";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(57, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tipo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(249, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Hasta";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Desde";
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(619, 84);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(137, 50);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(467, 84);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(137, 50);
			this.btnConsultar.TabIndex = 0;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// dgvIncidencias
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvIncidencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conductor,
            this.TipoIncidencia,
            this.Observaciones,
            this.Usuario_ID,
            this.FechaCaptura,
            this.EstatusIncidencia_Conductor,
            this.PeriodoAplicacionIncidencia,
            this.Monto,
            this.AnulaMontoVariable});
			this.dgvIncidencias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvIncidencias.Location = new System.Drawing.Point(0, 0);
			this.dgvIncidencias.MultiSelect = false;
			this.dgvIncidencias.Name = "dgvIncidencias";
			this.dgvIncidencias.ReadOnly = true;
			this.dgvIncidencias.RowTemplate.Height = 24;
			this.dgvIncidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvIncidencias.Size = new System.Drawing.Size(784, 209);
			this.dgvIncidencias.TabIndex = 2;
			this.dgvIncidencias.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIncidencias_CellMouseDoubleClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(8, 8);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gbCaptura);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvIncidencias);
			this.splitContainer1.Size = new System.Drawing.Size(784, 364);
			this.splitContainer1.SplitterDistance = 151;
			this.splitContainer1.TabIndex = 3;
			// 
			// Conductor
			// 
			this.Conductor.DataPropertyName = "Conductor";
			this.Conductor.Frozen = true;
			this.Conductor.HeaderText = "Conductor";
			this.Conductor.Name = "Conductor";
			this.Conductor.ReadOnly = true;
			// 
			// TipoIncidencia
			// 
			this.TipoIncidencia.DataPropertyName = "TipoIncidencia";
			this.TipoIncidencia.HeaderText = "Tipo";
			this.TipoIncidencia.Name = "TipoIncidencia";
			this.TipoIncidencia.ReadOnly = true;
			// 
			// Observaciones
			// 
			this.Observaciones.DataPropertyName = "Observaciones";
			this.Observaciones.HeaderText = "Observaciones";
			this.Observaciones.Name = "Observaciones";
			this.Observaciones.ReadOnly = true;
			// 
			// Usuario_ID
			// 
			this.Usuario_ID.DataPropertyName = "Usuario_ID";
			this.Usuario_ID.HeaderText = "Usuario";
			this.Usuario_ID.Name = "Usuario_ID";
			this.Usuario_ID.ReadOnly = true;
			// 
			// FechaCaptura
			// 
			this.FechaCaptura.DataPropertyName = "FechaCaptura";
			dataGridViewCellStyle2.Format = "g";
			dataGridViewCellStyle2.NullValue = null;
			this.FechaCaptura.DefaultCellStyle = dataGridViewCellStyle2;
			this.FechaCaptura.HeaderText = "Fecha de Captura";
			this.FechaCaptura.Name = "FechaCaptura";
			this.FechaCaptura.ReadOnly = true;
			// 
			// EstatusIncidencia_Conductor
			// 
			this.EstatusIncidencia_Conductor.DataPropertyName = "EstatusIncidencia_Conductor";
			this.EstatusIncidencia_Conductor.HeaderText = "Estatus";
			this.EstatusIncidencia_Conductor.Name = "EstatusIncidencia_Conductor";
			this.EstatusIncidencia_Conductor.ReadOnly = true;
			// 
			// PeriodoAplicacionIncidencia
			// 
			this.PeriodoAplicacionIncidencia.DataPropertyName = "PeriodoAplicacionIncidencia";
			dataGridViewCellStyle3.Format = "d";
			dataGridViewCellStyle3.NullValue = null;
			this.PeriodoAplicacionIncidencia.DefaultCellStyle = dataGridViewCellStyle3;
			this.PeriodoAplicacionIncidencia.HeaderText = "Periodo Incidencia";
			this.PeriodoAplicacionIncidencia.Name = "PeriodoAplicacionIncidencia";
			this.PeriodoAplicacionIncidencia.ReadOnly = true;
			// 
			// Monto
			// 
			this.Monto.DataPropertyName = "Monto";
			dataGridViewCellStyle4.Format = "C2";
			this.Monto.DefaultCellStyle = dataGridViewCellStyle4;
			this.Monto.HeaderText = "Monto";
			this.Monto.Name = "Monto";
			this.Monto.ReadOnly = true;
			// 
			// AnulaMontoVariable
			// 
			this.AnulaMontoVariable.DataPropertyName = "AnulaMontoVariable";
			this.AnulaMontoVariable.FalseValue = "0";
			this.AnulaMontoVariable.HeaderText = "Anula S V";
			this.AnulaMontoVariable.Name = "AnulaMontoVariable";
			this.AnulaMontoVariable.ReadOnly = true;
			this.AnulaMontoVariable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.AnulaMontoVariable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.AnulaMontoVariable.TrueValue = "1";
			// 
			// CapturaIncidenciasConductores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 383);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CapturaIncidenciasConductores";
			this.Text = "CapturaIncidenciasConductores";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.gbCaptura.ResumeLayout(false);
			this.gbCaptura.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCaptura;
		private System.Windows.Forms.DataGridView dgvIncidencias;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.ComboBox cmbEstatus;
		private System.Windows.Forms.ComboBox cmbTiposIncidencias;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbPeriodoHasta;
		private System.Windows.Forms.ComboBox cmbPeriodoDesde;
		private System.Windows.Forms.DataGridViewTextBoxColumn Conductor;
		private System.Windows.Forms.DataGridViewTextBoxColumn TipoIncidencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
		private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn FechaCaptura;
		private System.Windows.Forms.DataGridViewTextBoxColumn EstatusIncidencia_Conductor;
		private System.Windows.Forms.DataGridViewTextBoxColumn PeriodoAplicacionIncidencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
		private System.Windows.Forms.DataGridViewCheckBoxColumn AnulaMontoVariable;
	}
}