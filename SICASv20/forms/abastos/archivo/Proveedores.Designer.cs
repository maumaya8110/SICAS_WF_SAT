namespace SICASv20.forms.abastos.archivo
{
	partial class Proveedores
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgvProveedores = new System.Windows.Forms.DataGridView();
			this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgvProveedores);
			this.groupBox1.Location = new System.Drawing.Point(1, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(469, 274);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Proveedores";
			// 
			// dgvProveedores
			// 
			this.dgvProveedores.AllowUserToAddRows = false;
			this.dgvProveedores.AllowUserToDeleteRows = false;
			this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cCID,
            this.cNombre});
			this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProveedores.Location = new System.Drawing.Point(3, 20);
			this.dgvProveedores.MultiSelect = false;
			this.dgvProveedores.Name = "dgvProveedores";
			this.dgvProveedores.ReadOnly = true;
			this.dgvProveedores.RowTemplate.Height = 24;
			this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvProveedores.Size = new System.Drawing.Size(463, 251);
			this.dgvProveedores.TabIndex = 0;
			// 
			// cID
			// 
			this.cID.DataPropertyName = "ID";
			this.cID.HeaderText = "ID";
			this.cID.Name = "cID";
			this.cID.ReadOnly = true;
			// 
			// cCID
			// 
			this.cCID.DataPropertyName = "CID";
			this.cCID.HeaderText = "Código";
			this.cCID.Name = "cCID";
			this.cCID.ReadOnly = true;
			// 
			// cNombre
			// 
			this.cNombre.DataPropertyName = "Nombre";
			this.cNombre.HeaderText = "Nombre";
			this.cNombre.Name = "cNombre";
			this.cNombre.ReadOnly = true;
			// 
			// Proveedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 284);
			this.Controls.Add(this.groupBox1);
			this.Name = "Proveedores";
			this.Text = "Proveedores";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgvProveedores;
		private System.Windows.Forms.DataGridViewTextBoxColumn cID;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCID;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
	}
}