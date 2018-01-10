namespace SICASv20.forms.empresas.equiposgas
{
	partial class EquiposGas
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
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txtCapacidad = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.chkEstatus = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvEquipos = new System.Windows.Forms.DataGridView();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
			this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
			this.splitContainer1.Panel1.Controls.Add(this.txtCapacidad);
			this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
			this.splitContainer1.Panel1.Controls.Add(this.chkEstatus);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvEquipos);
			this.splitContainer1.Size = new System.Drawing.Size(711, 487);
			this.splitContainer1.SplitterDistance = 71;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 1;
			// 
			// btnExportar
			// 
			this.btnExportar.Location = new System.Drawing.Point(588, 7);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(114, 53);
			this.btnExportar.TabIndex = 6;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(451, 7);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(114, 53);
			this.btnGuardar.TabIndex = 5;
			this.btnGuardar.Text = "Agregar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txtCapacidad
			// 
			this.txtCapacidad.Location = new System.Drawing.Point(98, 39);
			this.txtCapacidad.Name = "txtCapacidad";
			this.txtCapacidad.Size = new System.Drawing.Size(127, 24);
			this.txtCapacidad.TabIndex = 3;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(98, 10);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(337, 24);
			this.txtDescripcion.TabIndex = 1;
			// 
			// chkEstatus
			// 
			this.chkEstatus.AutoSize = true;
			this.chkEstatus.Checked = true;
			this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEstatus.Location = new System.Drawing.Point(360, 40);
			this.chkEstatus.Name = "chkEstatus";
			this.chkEstatus.Size = new System.Drawing.Size(70, 22);
			this.chkEstatus.TabIndex = 4;
			this.chkEstatus.Text = "Activo";
			this.chkEstatus.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Capacidad:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Descripción:";
			// 
			// dgvEquipos
			// 
			this.dgvEquipos.AllowUserToAddRows = false;
			this.dgvEquipos.AllowUserToDeleteRows = false;
			this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Capacidad,
            this.Activo});
			this.dgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvEquipos.Location = new System.Drawing.Point(0, 0);
			this.dgvEquipos.Name = "dgvEquipos";
			this.dgvEquipos.ReadOnly = true;
			this.dgvEquipos.RowTemplate.Height = 24;
			this.dgvEquipos.Size = new System.Drawing.Size(711, 411);
			this.dgvEquipos.TabIndex = 0;
			this.dgvEquipos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentDoubleClick);
			// 
			// Descripcion
			// 
			this.Descripcion.DataPropertyName = "Descripcion";
			this.Descripcion.Frozen = true;
			this.Descripcion.HeaderText = "Descripción";
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			// 
			// Capacidad
			// 
			this.Capacidad.DataPropertyName = "Capacidad";
			this.Capacidad.HeaderText = "Capacidad";
			this.Capacidad.Name = "Capacidad";
			this.Capacidad.ReadOnly = true;
			// 
			// Activo
			// 
			this.Activo.DataPropertyName = "EstatusEquipoGas_ID";
			this.Activo.HeaderText = "Activo";
			this.Activo.Name = "Activo";
			this.Activo.ReadOnly = true;
			this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Activo.TrueValue = "1";
			// 
			// EquiposGas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 518);
			this.Controls.Add(this.splitContainer1);
			this.Name = "EquiposGas";
			this.Text = "EquiposGas";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvEquipos;
		private System.Windows.Forms.TextBox txtCapacidad;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.CheckBox chkEstatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
	}
}