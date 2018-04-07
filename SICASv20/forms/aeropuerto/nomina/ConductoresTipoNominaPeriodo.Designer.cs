namespace SICASv20.forms.aeropuerto.nomina
{
	partial class ConductoresTipoNominaPeriodo
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dgvConductoresTipoNomina = new System.Windows.Forms.DataGridView();
            this.Conductor_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoNominaVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductoresTipoNomina)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(18, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.cmbAño);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPeriodo);
            this.splitContainer1.Panel1.Controls.Add(this.lblAño);
            this.splitContainer1.Panel1.Controls.Add(this.lblPeriodo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvConductoresTipoNomina);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.splitContainer1.Size = new System.Drawing.Size(546, 548);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.Location = new System.Drawing.Point(284, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 47);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Silver;
            this.btnGuardar.Location = new System.Drawing.Point(411, 14);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(121, 47);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(76, 6);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(99, 26);
            this.cmbAño.TabIndex = 3;
            this.cmbAño.SelectedIndexChanged += new System.EventHandler(this.cmbAño_SelectedValueChanged);
            this.cmbAño.Enter += new System.EventHandler(this.cmbAño_Enter);
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(76, 38);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(192, 26);
            this.cmbPeriodo.TabIndex = 2;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedValueChanged);
            this.cmbPeriodo.Enter += new System.EventHandler(this.cmbPeriodo_Enter);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(32, 10);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(38, 18);
            this.lblAño.TabIndex = 1;
            this.lblAño.Text = "Año:";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(6, 42);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(64, 18);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // dgvConductoresTipoNomina
            // 
            this.dgvConductoresTipoNomina.AllowUserToAddRows = false;
            this.dgvConductoresTipoNomina.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvConductoresTipoNomina.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConductoresTipoNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConductoresTipoNomina.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conductor_ID,
            this.conductor,
            this.TipoNominaVigente,
            this.Eliminar});
            this.dgvConductoresTipoNomina.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvConductoresTipoNomina.Location = new System.Drawing.Point(0, 0);
            this.dgvConductoresTipoNomina.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgvConductoresTipoNomina.MultiSelect = false;
            this.dgvConductoresTipoNomina.Name = "dgvConductoresTipoNomina";
            this.dgvConductoresTipoNomina.RowTemplate.Height = 24;
            this.dgvConductoresTipoNomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConductoresTipoNomina.Size = new System.Drawing.Size(546, 472);
            this.dgvConductoresTipoNomina.TabIndex = 0;
            this.dgvConductoresTipoNomina.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConductoresTipoNomina_CellContentClick);
            this.dgvConductoresTipoNomina.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConductoresTipoNomina_CellDoubleClick);
            // 
            // Conductor_ID
            // 
            this.Conductor_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Conductor_ID.DataPropertyName = "Conductor_ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Conductor_ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.Conductor_ID.Frozen = true;
            this.Conductor_ID.HeaderText = "# Conductor";
            this.Conductor_ID.Name = "Conductor_ID";
            this.Conductor_ID.ReadOnly = true;
            this.Conductor_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Conductor_ID.Width = 115;
            // 
            // conductor
            // 
            this.conductor.DataPropertyName = "Conductor";
            this.conductor.Frozen = true;
            this.conductor.HeaderText = "Conductor";
            this.conductor.Name = "conductor";
            this.conductor.ReadOnly = true;
            // 
            // TipoNominaVigente
            // 
            this.TipoNominaVigente.DataPropertyName = "TipoNominaActual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.TipoNominaVigente.DefaultCellStyle = dataGridViewCellStyle3;
            this.TipoNominaVigente.HeaderText = "Tipo Nomina";
            this.TipoNominaVigente.Name = "TipoNominaVigente";
            this.TipoNominaVigente.ReadOnly = true;
            this.TipoNominaVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoNominaVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TipoNominaVigente.ToolTipText = "Tipo de Nómina del Conductor";
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "Eliminar";
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ConductoresTipoNominaPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 557);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConductoresTipoNominaPeriodo";
            this.Text = "ConductoresTipoNominaPeriodo";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductoresTipoNomina)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label lblPeriodo;
		private System.Windows.Forms.ComboBox cmbAño;
		private System.Windows.Forms.ComboBox cmbPeriodo;
		private System.Windows.Forms.Label lblAño;
		private System.Windows.Forms.DataGridView dgvConductoresTipoNomina;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn conductor;
		private System.Windows.Forms.DataGridViewTextBoxColumn TipoNominaVigente;
		private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
	}
}