namespace SICASv20.forms.abastos.archivo
{
	partial class Servicios
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.cmbProveedores = new System.Windows.Forms.ComboBox();
			this.bsProveedores = new System.Windows.Forms.BindingSource(this.components);
			this.lblProveedores = new System.Windows.Forms.Label();
			this.dgvServicios = new System.Windows.Forms.DataGridView();
			this.bsServicios = new System.Windows.Forms.BindingSource(this.components);
			this.cCODIGOPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cNOMBREPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cPRECIOCOMPRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cKILOMETRAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsProveedores)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsServicios)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(803, 514);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Servicios por Proveedor";
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
			this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
			this.splitContainer1.Panel1.Controls.Add(this.btnConsultar);
			this.splitContainer1.Panel1.Controls.Add(this.cmbProveedores);
			this.splitContainer1.Panel1.Controls.Add(this.lblProveedores);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvServicios);
			this.splitContainer1.Size = new System.Drawing.Size(797, 491);
			this.splitContainer1.SplitterDistance = 79;
			this.splitContainer1.TabIndex = 0;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(116, 44);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(199, 24);
			this.txtCodigo.TabIndex = 5;
			this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Código: ";
			// 
			// btnExportar
			// 
			this.btnExportar.Location = new System.Drawing.Point(669, 10);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(121, 55);
			this.btnExportar.TabIndex = 3;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.UseVisualStyleBackColor = true;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(542, 10);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(121, 55);
			this.btnConsultar.TabIndex = 2;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// cmbProveedores
			// 
			this.cmbProveedores.DataSource = this.bsProveedores;
			this.cmbProveedores.DisplayMember = "CID";
			this.cmbProveedores.FormattingEnabled = true;
			this.cmbProveedores.Location = new System.Drawing.Point(116, 12);
			this.cmbProveedores.Name = "cmbProveedores";
			this.cmbProveedores.Size = new System.Drawing.Size(199, 26);
			this.cmbProveedores.TabIndex = 1;
			this.cmbProveedores.SelectionChangeCommitted += new System.EventHandler(this.cmbProveedores_SelectionChangeCommitted);
			// 
			// lblProveedores
			// 
			this.lblProveedores.AutoSize = true;
			this.lblProveedores.Location = new System.Drawing.Point(9, 15);
			this.lblProveedores.Name = "lblProveedores";
			this.lblProveedores.Size = new System.Drawing.Size(101, 18);
			this.lblProveedores.TabIndex = 0;
			this.lblProveedores.Text = "Proveedores: ";
			// 
			// dgvServicios
			// 
			this.dgvServicios.AllowUserToAddRows = false;
			this.dgvServicios.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvServicios.AutoGenerateColumns = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCODIGOPRODUCTO,
            this.cNOMBREPRODUCTO,
            this.cPRECIOCOMPRA,
            this.cKILOMETRAJE});
			this.dgvServicios.DataSource = this.bsServicios;
			this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvServicios.Location = new System.Drawing.Point(0, 0);
			this.dgvServicios.Name = "dgvServicios";
			this.dgvServicios.RowTemplate.Height = 24;
			this.dgvServicios.Size = new System.Drawing.Size(797, 408);
			this.dgvServicios.TabIndex = 0;
			this.dgvServicios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEndEdit);
			this.dgvServicios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvServicios_DataError);
			// 
			// cCODIGOPRODUCTO
			// 
			this.cCODIGOPRODUCTO.DataPropertyName = "CODIGOPRODUCTO";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.cCODIGOPRODUCTO.DefaultCellStyle = dataGridViewCellStyle3;
			this.cCODIGOPRODUCTO.HeaderText = "Código";
			this.cCODIGOPRODUCTO.Name = "cCODIGOPRODUCTO";
			this.cCODIGOPRODUCTO.ReadOnly = true;
			// 
			// cNOMBREPRODUCTO
			// 
			this.cNOMBREPRODUCTO.DataPropertyName = "NOMBREPRODUCTO";
			this.cNOMBREPRODUCTO.HeaderText = "Nombre";
			this.cNOMBREPRODUCTO.Name = "cNOMBREPRODUCTO";
			this.cNOMBREPRODUCTO.ReadOnly = true;
			// 
			// cPRECIOCOMPRA
			// 
			this.cPRECIOCOMPRA.DataPropertyName = "PRECIOCOMPRA";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "C2";
			dataGridViewCellStyle4.NullValue = null;
			this.cPRECIOCOMPRA.DefaultCellStyle = dataGridViewCellStyle4;
			this.cPRECIOCOMPRA.HeaderText = "Precio";
			this.cPRECIOCOMPRA.Name = "cPRECIOCOMPRA";
			this.cPRECIOCOMPRA.ReadOnly = true;
			// 
			// cKILOMETRAJE
			// 
			this.cKILOMETRAJE.DataPropertyName = "KILOMETRAJE";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.cKILOMETRAJE.DefaultCellStyle = dataGridViewCellStyle5;
			this.cKILOMETRAJE.HeaderText = "Km";
			this.cKILOMETRAJE.Name = "cKILOMETRAJE";
			// 
			// Servicios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 526);
			this.Controls.Add(this.groupBox1);
			this.Name = "Servicios";
			this.Text = "Servicios";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsProveedores)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsServicios)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvServicios;
		private System.Windows.Forms.Button btnExportar;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.ComboBox cmbProveedores;
		private System.Windows.Forms.Label lblProveedores;
		private System.Windows.Forms.BindingSource bsProveedores;
		private System.Windows.Forms.BindingSource bsServicios;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCODIGOPRODUCTO;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNOMBREPRODUCTO;
		private System.Windows.Forms.DataGridViewTextBoxColumn cPRECIOCOMPRA;
		private System.Windows.Forms.DataGridViewTextBoxColumn cKILOMETRAJE;
	}
}