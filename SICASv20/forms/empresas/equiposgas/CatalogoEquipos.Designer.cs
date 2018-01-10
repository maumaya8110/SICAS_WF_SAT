namespace SICASv20.forms.empresas.equiposgas
{
	partial class CatalogoEquipos
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumeroSerie = new System.Windows.Forms.TextBox();
			this.txtCapacidad = new System.Windows.Forms.TextBox();
			this.cmbEstaciones = new System.Windows.Forms.ComboBox();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.cmbProveedores = new System.Windows.Forms.ComboBox();
			this.cmbEquiposGas = new System.Windows.Forms.ComboBox();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnExportar = new System.Windows.Forms.Button();
			this.dgvCatEquipos = new System.Windows.Forms.DataGridView();
			this.CEquipoGas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CMontoDiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CDiasAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CNumeroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cNumeroSerieTanque = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CFechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CAsignado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCatEquipos)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvCatEquipos);
			this.splitContainer1.Size = new System.Drawing.Size(1000, 628);
			this.splitContainer1.SplitterDistance = 109;
			this.splitContainer1.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label6);
			this.splitContainer2.Panel1.Controls.Add(this.label5);
			this.splitContainer2.Panel1.Controls.Add(this.label4);
			this.splitContainer2.Panel1.Controls.Add(this.label3);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Panel1.Controls.Add(this.txtNumeroSerie);
			this.splitContainer2.Panel1.Controls.Add(this.txtCapacidad);
			this.splitContainer2.Panel1.Controls.Add(this.cmbEstaciones);
			this.splitContainer2.Panel1.Controls.Add(this.cmbEmpresas);
			this.splitContainer2.Panel1.Controls.Add(this.cmbProveedores);
			this.splitContainer2.Panel1.Controls.Add(this.cmbEquiposGas);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.btnConsultar);
			this.splitContainer2.Panel2.Controls.Add(this.btnAgregar);
			this.splitContainer2.Panel2.Controls.Add(this.btnExportar);
			this.splitContainer2.Size = new System.Drawing.Size(1000, 109);
			this.splitContainer2.SplitterDistance = 620;
			this.splitContainer2.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(243, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Capacidad";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "# de Serie";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 47);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 18);
			this.label4.TabIndex = 4;
			this.label4.Text = "Proveedor";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Equipo de Gas:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(397, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Estación";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(392, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Empresa";
			// 
			// txtNumeroSerie
			// 
			this.txtNumeroSerie.Location = new System.Drawing.Point(89, 77);
			this.txtNumeroSerie.Name = "txtNumeroSerie";
			this.txtNumeroSerie.Size = new System.Drawing.Size(148, 24);
			this.txtNumeroSerie.TabIndex = 9;
			// 
			// txtCapacidad
			// 
			this.txtCapacidad.Location = new System.Drawing.Point(327, 77);
			this.txtCapacidad.Name = "txtCapacidad";
			this.txtCapacidad.Size = new System.Drawing.Size(59, 24);
			this.txtCapacidad.TabIndex = 11;
			// 
			// cmbEstaciones
			// 
			this.cmbEstaciones.FormattingEnabled = true;
			this.cmbEstaciones.Location = new System.Drawing.Point(455, 43);
			this.cmbEstaciones.Name = "cmbEstaciones";
			this.cmbEstaciones.Size = new System.Drawing.Size(149, 26);
			this.cmbEstaciones.TabIndex = 7;
			// 
			// cmbEmpresas
			// 
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(455, 9);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(149, 26);
			this.cmbEmpresas.TabIndex = 3;
			// 
			// cmbProveedores
			// 
			this.cmbProveedores.FormattingEnabled = true;
			this.cmbProveedores.Location = new System.Drawing.Point(89, 43);
			this.cmbProveedores.Name = "cmbProveedores";
			this.cmbProveedores.Size = new System.Drawing.Size(297, 26);
			this.cmbProveedores.TabIndex = 5;
			// 
			// cmbEquiposGas
			// 
			this.cmbEquiposGas.FormattingEnabled = true;
			this.cmbEquiposGas.Location = new System.Drawing.Point(116, 9);
			this.cmbEquiposGas.Name = "cmbEquiposGas";
			this.cmbEquiposGas.Size = new System.Drawing.Size(270, 26);
			this.cmbEquiposGas.TabIndex = 1;
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(6, 29);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(116, 52);
			this.btnConsultar.TabIndex = 0;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(126, 28);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(116, 53);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnExportar
			// 
			this.btnExportar.Location = new System.Drawing.Point(246, 28);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(116, 53);
			this.btnExportar.TabIndex = 2;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// dgvCatEquipos
			// 
			this.dgvCatEquipos.AllowUserToAddRows = false;
			this.dgvCatEquipos.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvCatEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCatEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCatEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CEquipoGas,
            this.CProveedor,
            this.CCosto,
            this.CPrecio,
            this.CMontoDiario,
            this.CDiasAPagar,
            this.CNumeroSerie,
            this.cNumeroSerieTanque,
            this.CFechaAlta,
            this.CAsignado});
			this.dgvCatEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCatEquipos.Location = new System.Drawing.Point(0, 0);
			this.dgvCatEquipos.MultiSelect = false;
			this.dgvCatEquipos.Name = "dgvCatEquipos";
			this.dgvCatEquipos.ReadOnly = true;
			this.dgvCatEquipos.RowTemplate.Height = 24;
			this.dgvCatEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCatEquipos.Size = new System.Drawing.Size(1000, 515);
			this.dgvCatEquipos.TabIndex = 0;
			this.dgvCatEquipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatEquipos_CellDoubleClick);
			// 
			// CEquipoGas
			// 
			this.CEquipoGas.DataPropertyName = "Equipo_Gas";
			this.CEquipoGas.HeaderText = "Equipo de Gas";
			this.CEquipoGas.Name = "CEquipoGas";
			this.CEquipoGas.ReadOnly = true;
			this.CEquipoGas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// CProveedor
			// 
			this.CProveedor.DataPropertyName = "proveedor";
			this.CProveedor.HeaderText = "Proveedor";
			this.CProveedor.Name = "CProveedor";
			this.CProveedor.ReadOnly = true;
			// 
			// CCosto
			// 
			this.CCosto.DataPropertyName = "Costo";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			this.CCosto.DefaultCellStyle = dataGridViewCellStyle2;
			this.CCosto.HeaderText = "Costo";
			this.CCosto.Name = "CCosto";
			this.CCosto.ReadOnly = true;
			// 
			// CPrecio
			// 
			this.CPrecio.DataPropertyName = "Precio";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			this.CPrecio.DefaultCellStyle = dataGridViewCellStyle3;
			this.CPrecio.HeaderText = "Precio";
			this.CPrecio.Name = "CPrecio";
			this.CPrecio.ReadOnly = true;
			// 
			// CMontoDiario
			// 
			this.CMontoDiario.DataPropertyName = "MontoDiario";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "C2";
			this.CMontoDiario.DefaultCellStyle = dataGridViewCellStyle4;
			this.CMontoDiario.HeaderText = "Monto Diario";
			this.CMontoDiario.Name = "CMontoDiario";
			this.CMontoDiario.ReadOnly = true;
			// 
			// CDiasAPagar
			// 
			this.CDiasAPagar.DataPropertyName = "CantidadDiasApagar";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.CDiasAPagar.DefaultCellStyle = dataGridViewCellStyle5;
			this.CDiasAPagar.HeaderText = "Dias a Pagar";
			this.CDiasAPagar.Name = "CDiasAPagar";
			this.CDiasAPagar.ReadOnly = true;
			// 
			// CNumeroSerie
			// 
			this.CNumeroSerie.DataPropertyName = "NumeroSerieKit";
			this.CNumeroSerie.HeaderText = "Número de Serie Kit";
			this.CNumeroSerie.Name = "CNumeroSerie";
			this.CNumeroSerie.ReadOnly = true;
			// 
			// cNumeroSerieTanque
			// 
			this.cNumeroSerieTanque.DataPropertyName = "NumeroSerieTanque";
			this.cNumeroSerieTanque.HeaderText = "Numero de Serie Tanque";
			this.cNumeroSerieTanque.Name = "cNumeroSerieTanque";
			this.cNumeroSerieTanque.ReadOnly = true;
			// 
			// CFechaAlta
			// 
			this.CFechaAlta.DataPropertyName = "FechaAlta";
			this.CFechaAlta.HeaderText = "Fecha de Alta";
			this.CFechaAlta.Name = "CFechaAlta";
			this.CFechaAlta.ReadOnly = true;
			// 
			// CAsignado
			// 
			this.CAsignado.DataPropertyName = "Asignado";
			this.CAsignado.HeaderText = "Asignado";
			this.CAsignado.Name = "CAsignado";
			this.CAsignado.ReadOnly = true;
			this.CAsignado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.CAsignado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// CatalogoEquipos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.splitContainer1);
			this.Name = "CatalogoEquipos";
			this.Text = "CatalogoEquipos";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCatEquipos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvCatEquipos;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.ComboBox cmbProveedores;
		private System.Windows.Forms.ComboBox cmbEquiposGas;
		private System.Windows.Forms.ComboBox cmbEstaciones;
		private System.Windows.Forms.ComboBox cmbEmpresas;
		private System.Windows.Forms.TextBox txtNumeroSerie;
		private System.Windows.Forms.TextBox txtCapacidad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn CEquipoGas;
		private System.Windows.Forms.DataGridViewTextBoxColumn CProveedor;
		private System.Windows.Forms.DataGridViewTextBoxColumn CCosto;
		private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
		private System.Windows.Forms.DataGridViewTextBoxColumn CMontoDiario;
		private System.Windows.Forms.DataGridViewTextBoxColumn CDiasAPagar;
		private System.Windows.Forms.DataGridViewTextBoxColumn CNumeroSerie;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNumeroSerieTanque;
		private System.Windows.Forms.DataGridViewTextBoxColumn CFechaAlta;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CAsignado;
	}
}