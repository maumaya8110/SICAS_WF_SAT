namespace SICASv20.forms.empresas.equiposgas
{
	partial class AgregaConductorEquipoGas
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gbEquipo = new System.Windows.Forms.GroupBox();
			this.lblProveedor = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lblCantDias = new System.Windows.Forms.Label();
			this.lblMontoDiario = new System.Windows.Forms.Label();
			this.lblPrecio = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dteFechaFin = new System.Windows.Forms.DateTimePicker();
			this.dteFechaInicio = new System.Windows.Forms.DateTimePicker();
			this.cmbEquipo = new System.Windows.Forms.ComboBox();
			this.cmbConductor = new System.Windows.Forms.ComboBox();
			this.chkCobroActivo = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBaja = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.gbEquipo.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gbEquipo);
			this.splitContainer1.Panel1.Controls.Add(this.dteFechaFin);
			this.splitContainer1.Panel1.Controls.Add(this.dteFechaInicio);
			this.splitContainer1.Panel1.Controls.Add(this.cmbEquipo);
			this.splitContainer1.Panel1.Controls.Add(this.cmbConductor);
			this.splitContainer1.Panel1.Controls.Add(this.chkCobroActivo);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnBaja);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
			this.splitContainer1.Panel2.Controls.Add(this.btnAgregar);
			this.splitContainer1.Size = new System.Drawing.Size(800, 227);
			this.splitContainer1.SplitterDistance = 144;
			this.splitContainer1.TabIndex = 0;
			// 
			// gbEquipo
			// 
			this.gbEquipo.Controls.Add(this.lblProveedor);
			this.gbEquipo.Controls.Add(this.label12);
			this.gbEquipo.Controls.Add(this.lblCantDias);
			this.gbEquipo.Controls.Add(this.lblMontoDiario);
			this.gbEquipo.Controls.Add(this.lblPrecio);
			this.gbEquipo.Controls.Add(this.label8);
			this.gbEquipo.Controls.Add(this.label7);
			this.gbEquipo.Controls.Add(this.label6);
			this.gbEquipo.Location = new System.Drawing.Point(467, 10);
			this.gbEquipo.Name = "gbEquipo";
			this.gbEquipo.Size = new System.Drawing.Size(327, 131);
			this.gbEquipo.TabIndex = 11;
			this.gbEquipo.TabStop = false;
			this.gbEquipo.Text = "Detalles del Equipo";
			// 
			// lblProveedor
			// 
			this.lblProveedor.BackColor = System.Drawing.Color.Navy;
			this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProveedor.ForeColor = System.Drawing.Color.White;
			this.lblProveedor.Location = new System.Drawing.Point(19, 93);
			this.lblProveedor.Name = "lblProveedor";
			this.lblProveedor.Size = new System.Drawing.Size(305, 33);
			this.lblProveedor.TabIndex = 7;
			this.lblProveedor.Text = "Proveedor";
			this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(19, 76);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(78, 17);
			this.label12.TabIndex = 6;
			this.label12.Text = "Proveedor:";
			// 
			// lblCantDias
			// 
			this.lblCantDias.BackColor = System.Drawing.Color.Navy;
			this.lblCantDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCantDias.ForeColor = System.Drawing.Color.White;
			this.lblCantDias.Location = new System.Drawing.Point(242, 25);
			this.lblCantDias.Name = "lblCantDias";
			this.lblCantDias.Size = new System.Drawing.Size(82, 20);
			this.lblCantDias.TabIndex = 5;
			this.lblCantDias.Text = "DiasPago";
			this.lblCantDias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMontoDiario
			// 
			this.lblMontoDiario.BackColor = System.Drawing.Color.Navy;
			this.lblMontoDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMontoDiario.ForeColor = System.Drawing.Color.White;
			this.lblMontoDiario.Location = new System.Drawing.Point(111, 25);
			this.lblMontoDiario.Name = "lblMontoDiario";
			this.lblMontoDiario.Size = new System.Drawing.Size(82, 20);
			this.lblMontoDiario.TabIndex = 4;
			this.lblMontoDiario.Text = "Monto";
			this.lblMontoDiario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPrecio
			// 
			this.lblPrecio.BackColor = System.Drawing.Color.Navy;
			this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrecio.ForeColor = System.Drawing.Color.White;
			this.lblPrecio.Location = new System.Drawing.Point(77, 51);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(247, 20);
			this.lblPrecio.TabIndex = 3;
			this.lblPrecio.Text = "Precio:";
			this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(205, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "CDC:";
			this.toolTip1.SetToolTip(this.label8, "Cantidad de Días a Cobrar");
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 17);
			this.label7.TabIndex = 1;
			this.label7.Text = "Monto Diario:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 53);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "Precio:";
			// 
			// dteFechaFin
			// 
			this.dteFechaFin.Enabled = false;
			this.dteFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaFin.Location = new System.Drawing.Point(346, 78);
			this.dteFechaFin.Name = "dteFechaFin";
			this.dteFechaFin.Size = new System.Drawing.Size(113, 22);
			this.dteFechaFin.TabIndex = 9;
			this.dteFechaFin.Visible = false;
			// 
			// dteFechaInicio
			// 
			this.dteFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaInicio.Location = new System.Drawing.Point(106, 78);
			this.dteFechaInicio.Name = "dteFechaInicio";
			this.dteFechaInicio.Size = new System.Drawing.Size(113, 22);
			this.dteFechaInicio.TabIndex = 8;
			this.dteFechaInicio.ValueChanged += new System.EventHandler(this.dteFechaInicio_ValueChanged);
			// 
			// cmbEquipo
			// 
			this.cmbEquipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbEquipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbEquipo.DisplayMember = "NumeroSerie";
			this.cmbEquipo.FormattingEnabled = true;
			this.cmbEquipo.Location = new System.Drawing.Point(107, 43);
			this.cmbEquipo.Name = "cmbEquipo";
			this.cmbEquipo.Size = new System.Drawing.Size(352, 24);
			this.cmbEquipo.TabIndex = 7;
			this.cmbEquipo.ValueMember = "Id";
			this.cmbEquipo.SelectionChangeCommitted += new System.EventHandler(this.cmdEquipo_SelectionChangeCommitted);
			// 
			// cmbConductor
			// 
			this.cmbConductor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbConductor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbConductor.DisplayMember = "Nombre";
			this.cmbConductor.FormattingEnabled = true;
			this.cmbConductor.Location = new System.Drawing.Point(106, 10);
			this.cmbConductor.Name = "cmbConductor";
			this.cmbConductor.Size = new System.Drawing.Size(353, 24);
			this.cmbConductor.TabIndex = 6;
			this.cmbConductor.ValueMember = "Id";
			// 
			// chkCobroActivo
			// 
			this.chkCobroActivo.AutoSize = true;
			this.chkCobroActivo.Checked = true;
			this.chkCobroActivo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCobroActivo.Location = new System.Drawing.Point(106, 110);
			this.chkCobroActivo.Name = "chkCobroActivo";
			this.chkCobroActivo.Size = new System.Drawing.Size(110, 21);
			this.chkCobroActivo.TabIndex = 5;
			this.chkCobroActivo.Text = "Cobro Activo";
			this.chkCobroActivo.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(251, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Fecha Fin";
			this.label4.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Fecha Inicio";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(48, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Equipo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Conductor";
			// 
			// btnBaja
			// 
			this.btnBaja.Enabled = false;
			this.btnBaja.Location = new System.Drawing.Point(165, 8);
			this.btnBaja.Name = "btnBaja";
			this.btnBaja.Size = new System.Drawing.Size(132, 50);
			this.btnBaja.TabIndex = 2;
			this.btnBaja.Text = "Cancelar";
			this.btnBaja.UseVisualStyleBackColor = true;
			this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(503, 8);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(132, 50);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cerrar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(334, 8);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(132, 50);
			this.btnAgregar.TabIndex = 0;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// AgregaConductorEquipoGas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 227);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AgregaConductorEquipoGas";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agrega - Conductor Equipo Gas";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.AgregaConductorEquipoGas_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.gbEquipo.ResumeLayout(false);
			this.gbEquipo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dteFechaFin;
		private System.Windows.Forms.DateTimePicker dteFechaInicio;
		private System.Windows.Forms.CheckBox chkCobroActivo;
		private System.Windows.Forms.GroupBox gbEquipo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblCantDias;
		private System.Windows.Forms.Label lblMontoDiario;
		private System.Windows.Forms.Label lblPrecio;
		private System.Windows.Forms.Label lblProveedor;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.ComboBox cmbEquipo;
		public System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnBaja;
	}
}