namespace SICASv20.forms.callcenter.valesempresariales
{
	partial class ValesEmpresariales
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
			this.cmbEstatus = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.txtSerie = new System.Windows.Forms.TextBox();
			this.cmbUsuarios = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdExportar = new System.Windows.Forms.Button();
			this.cmrConsultar = new System.Windows.Forms.Button();
			this.cmdAsignar = new System.Windows.Forms.Button();
			this.dgvValesEmpresariales = new System.Windows.Forms.DataGridView();
			this.cSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFechaAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cUsuarioAsignado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cEstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFechaCanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvValesEmpresariales)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Location = new System.Drawing.Point(2, -1);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cmbEstatus);
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.txtFolio);
			this.splitContainer1.Panel1.Controls.Add(this.txtSerie);
			this.splitContainer1.Panel1.Controls.Add(this.cmbUsuarios);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.cmdExportar);
			this.splitContainer1.Panel1.Controls.Add(this.cmrConsultar);
			this.splitContainer1.Panel1.Controls.Add(this.cmdAsignar);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvValesEmpresariales);
			this.splitContainer1.Size = new System.Drawing.Size(1022, 650);
			this.splitContainer1.SplitterDistance = 134;
			this.splitContainer1.TabIndex = 1;
			// 
			// cmbEstatus
			// 
			this.cmbEstatus.DisplayMember = "Nombre";
			this.cmbEstatus.FormattingEnabled = true;
			this.cmbEstatus.Location = new System.Drawing.Point(94, 89);
			this.cmbEstatus.Name = "cmbEstatus";
			this.cmbEstatus.Size = new System.Drawing.Size(207, 26);
			this.cmbEstatus.TabIndex = 17;
			this.cmbEstatus.ValueMember = "EstatusValePrepagado_ID";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(30, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 18);
			this.label5.TabIndex = 16;
			this.label5.Text = "Estatus";
			// 
			// txtFolio
			// 
			this.txtFolio.Location = new System.Drawing.Point(230, 60);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(71, 24);
			this.txtFolio.TabIndex = 14;
			// 
			// txtSerie
			// 
			this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSerie.Location = new System.Drawing.Point(94, 58);
			this.txtSerie.Name = "txtSerie";
			this.txtSerie.Size = new System.Drawing.Size(71, 24);
			this.txtSerie.TabIndex = 13;
			this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cmbUsuarios
			// 
			this.cmbUsuarios.DisplayMember = "Nombre";
			this.cmbUsuarios.FormattingEnabled = true;
			this.cmbUsuarios.Location = new System.Drawing.Point(94, 24);
			this.cmbUsuarios.Name = "cmbUsuarios";
			this.cmbUsuarios.Size = new System.Drawing.Size(333, 26);
			this.cmbUsuarios.TabIndex = 12;
			this.cmbUsuarios.ValueMember = "ValeEmpresarialUsuario_ID";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(180, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 18);
			this.label3.TabIndex = 10;
			this.label3.Text = "Folio:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(42, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 18);
			this.label2.TabIndex = 9;
			this.label2.Text = "Serie";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 18);
			this.label1.TabIndex = 8;
			this.label1.Text = "Usuario";
			// 
			// cmdExportar
			// 
			this.cmdExportar.Location = new System.Drawing.Point(884, 48);
			this.cmdExportar.Name = "cmdExportar";
			this.cmdExportar.Size = new System.Drawing.Size(126, 45);
			this.cmdExportar.TabIndex = 2;
			this.cmdExportar.Text = "Exportar";
			this.cmdExportar.UseVisualStyleBackColor = true;
			// 
			// cmrConsultar
			// 
			this.cmrConsultar.Location = new System.Drawing.Point(582, 48);
			this.cmrConsultar.Name = "cmrConsultar";
			this.cmrConsultar.Size = new System.Drawing.Size(126, 45);
			this.cmrConsultar.TabIndex = 1;
			this.cmrConsultar.Text = "Consultar";
			this.cmrConsultar.UseVisualStyleBackColor = true;
			this.cmrConsultar.Click += new System.EventHandler(this.cmrConsultar_Click);
			// 
			// cmdAsignar
			// 
			this.cmdAsignar.Location = new System.Drawing.Point(732, 48);
			this.cmdAsignar.Name = "cmdAsignar";
			this.cmdAsignar.Size = new System.Drawing.Size(126, 45);
			this.cmdAsignar.TabIndex = 0;
			this.cmdAsignar.Text = "Asignación";
			this.cmdAsignar.UseVisualStyleBackColor = true;
			this.cmdAsignar.Click += new System.EventHandler(this.cmdAsignar_Click);
			// 
			// dgvValesEmpresariales
			// 
			this.dgvValesEmpresariales.AllowUserToAddRows = false;
			this.dgvValesEmpresariales.AllowUserToDeleteRows = false;
			this.dgvValesEmpresariales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvValesEmpresariales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSerie,
            this.cFolio,
            this.cFechaAsignacion,
            this.cUsuarioAsignado,
            this.cEstatus,
            this.cFechaCanje,
            this.cCaja,
            this.cMonto});
			this.dgvValesEmpresariales.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvValesEmpresariales.Location = new System.Drawing.Point(0, 0);
			this.dgvValesEmpresariales.Name = "dgvValesEmpresariales";
			this.dgvValesEmpresariales.ReadOnly = true;
			this.dgvValesEmpresariales.RowTemplate.Height = 24;
			this.dgvValesEmpresariales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvValesEmpresariales.Size = new System.Drawing.Size(1022, 512);
			this.dgvValesEmpresariales.TabIndex = 0;
			// 
			// cSerie
			// 
			this.cSerie.DataPropertyName = "Serie";
			this.cSerie.HeaderText = "Serie";
			this.cSerie.Name = "cSerie";
			this.cSerie.ReadOnly = true;
			// 
			// cFolio
			// 
			this.cFolio.DataPropertyName = "Folio";
			this.cFolio.HeaderText = "Folio";
			this.cFolio.Name = "cFolio";
			this.cFolio.ReadOnly = true;
			// 
			// cFechaAsignacion
			// 
			this.cFechaAsignacion.DataPropertyName = "FechaAsignacion";
			dataGridViewCellStyle1.Format = "g";
			dataGridViewCellStyle1.NullValue = null;
			this.cFechaAsignacion.DefaultCellStyle = dataGridViewCellStyle1;
			this.cFechaAsignacion.HeaderText = "Fecha Asignado";
			this.cFechaAsignacion.Name = "cFechaAsignacion";
			this.cFechaAsignacion.ReadOnly = true;
			// 
			// cUsuarioAsignado
			// 
			this.cUsuarioAsignado.DataPropertyName = "UsuarioAsignado";
			this.cUsuarioAsignado.HeaderText = "UsuarioAsignado";
			this.cUsuarioAsignado.Name = "cUsuarioAsignado";
			this.cUsuarioAsignado.ReadOnly = true;
			// 
			// cEstatus
			// 
			this.cEstatus.DataPropertyName = "Estatus";
			this.cEstatus.HeaderText = "Estatus";
			this.cEstatus.Name = "cEstatus";
			this.cEstatus.ReadOnly = true;
			// 
			// cFechaCanje
			// 
			this.cFechaCanje.DataPropertyName = "FechaCanje";
			dataGridViewCellStyle2.Format = "g";
			dataGridViewCellStyle2.NullValue = null;
			this.cFechaCanje.DefaultCellStyle = dataGridViewCellStyle2;
			this.cFechaCanje.HeaderText = "FechaCanje";
			this.cFechaCanje.Name = "cFechaCanje";
			this.cFechaCanje.ReadOnly = true;
			// 
			// cCaja
			// 
			this.cCaja.DataPropertyName = "Caja";
			this.cCaja.HeaderText = "Caja";
			this.cCaja.Name = "cCaja";
			this.cCaja.ReadOnly = true;
			// 
			// cMonto
			// 
			this.cMonto.DataPropertyName = "Monto";
			dataGridViewCellStyle3.Format = "C2";
			dataGridViewCellStyle3.NullValue = null;
			this.cMonto.DefaultCellStyle = dataGridViewCellStyle3;
			this.cMonto.HeaderText = "Monto";
			this.cMonto.Name = "cMonto";
			this.cMonto.ReadOnly = true;
			// 
			// ValesEmpresariales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ValesEmpresariales";
			this.Text = "ValesEmpresariales";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvValesEmpresariales)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button cmdAsignar;
		private System.Windows.Forms.DataGridView dgvValesEmpresariales;
		private System.Windows.Forms.Button cmdExportar;
		private System.Windows.Forms.Button cmrConsultar;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.TextBox txtSerie;
		private System.Windows.Forms.ComboBox cmbUsuarios;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbEstatus;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn cSerie;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFolio;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFechaAsignacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioAsignado;
		private System.Windows.Forms.DataGridViewTextBoxColumn cEstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFechaCanje;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCaja;
		private System.Windows.Forms.DataGridViewTextBoxColumn cMonto;
	}
}