namespace SICASv20.forms.empresas.equiposgas
{
	partial class ProveedoresEquipoGas
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
			this.txtProveedor = new System.Windows.Forms.TextBox();
			this.chkEstatus = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvProveedores = new System.Windows.Forms.DataGridView();
			this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
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
			this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
			this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
			this.splitContainer1.Panel1.Controls.Add(this.txtProveedor);
			this.splitContainer1.Panel1.Controls.Add(this.chkEstatus);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvProveedores);
			this.splitContainer1.Size = new System.Drawing.Size(694, 471);
			this.splitContainer1.SplitterDistance = 85;
			this.splitContainer1.TabIndex = 1;
			// 
			// btnExportar
			// 
			this.btnExportar.Location = new System.Drawing.Point(564, 18);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(114, 53);
			this.btnExportar.TabIndex = 4;
			this.btnExportar.Tag = "0";
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(444, 18);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(114, 53);
			this.btnGuardar.TabIndex = 3;
			this.btnGuardar.Text = "Agregar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txtProveedor
			// 
			this.txtProveedor.Location = new System.Drawing.Point(101, 18);
			this.txtProveedor.Name = "txtProveedor";
			this.txtProveedor.Size = new System.Drawing.Size(337, 24);
			this.txtProveedor.TabIndex = 1;
			// 
			// chkEstatus
			// 
			this.chkEstatus.AutoSize = true;
			this.chkEstatus.Checked = true;
			this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEstatus.Location = new System.Drawing.Point(17, 51);
			this.chkEstatus.Name = "chkEstatus";
			this.chkEstatus.Size = new System.Drawing.Size(70, 22);
			this.chkEstatus.TabIndex = 2;
			this.chkEstatus.Text = "Activo";
			this.chkEstatus.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Proveedor:";
			// 
			// dgvProveedores
			// 
			this.dgvProveedores.AllowUserToAddRows = false;
			this.dgvProveedores.AllowUserToDeleteRows = false;
			this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proveedor});
			this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProveedores.Location = new System.Drawing.Point(0, 0);
			this.dgvProveedores.Name = "dgvProveedores";
			this.dgvProveedores.ReadOnly = true;
			this.dgvProveedores.RowTemplate.Height = 24;
			this.dgvProveedores.Size = new System.Drawing.Size(694, 382);
			this.dgvProveedores.TabIndex = 0;
			this.dgvProveedores.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentDoubleClick);
			// 
			// Proveedor
			// 
			this.Proveedor.DataPropertyName = "Nombre";
			this.Proveedor.HeaderText = "Proveedor";
			this.Proveedor.Name = "Proveedor";
			this.Proveedor.ReadOnly = true;
			// 
			// ProveedoresEquipoGas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 492);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ProveedoresEquipoGas";
			this.Text = "Proveedores";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvProveedores;
		private System.Windows.Forms.TextBox txtProveedor;
		private System.Windows.Forms.CheckBox chkEstatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
	}
}