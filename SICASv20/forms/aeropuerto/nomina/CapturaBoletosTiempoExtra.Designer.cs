namespace SICASv20.forms.aeropuerto.nomina
{
	partial class CapturaBoletosTiempoExtra
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
			this.label2 = new System.Windows.Forms.Label();
			this.pnlParameters = new System.Windows.Forms.Panel();
			this.btnActKm = new System.Windows.Forms.Button();
			this.dteFechaPago = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lblServicio = new System.Windows.Forms.Label();
			this.txtServicio = new System.Windows.Forms.TextBox();
			this.lblConductor = new System.Windows.Forms.Label();
			this.cmbConductor = new System.Windows.Forms.ComboBox();
			this.dgvDetalleBoletos = new System.Windows.Forms.DataGridView();
			this.Numero_Economico = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Fecha_Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Fecha_Captura = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlFooter = new System.Windows.Forms.Panel();
			this.lblTotaServicios = new System.Windows.Forms.Label();
			this.lblTotalMonto = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCountServicios = new System.Windows.Forms.Label();
			this.pnlParameters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalleBoletos)).BeginInit();
			this.pnlFooter.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Salmon;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(616, 32);
			this.label2.TabIndex = 5;
			this.label2.Text = "Captura Boletos TIEMPO EXTRA por Conductor";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlParameters
			// 
			this.pnlParameters.BackColor = System.Drawing.Color.Salmon;
			this.pnlParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlParameters.Controls.Add(this.btnActKm);
			this.pnlParameters.Controls.Add(this.dteFechaPago);
			this.pnlParameters.Controls.Add(this.label1);
			this.pnlParameters.Controls.Add(this.btnAdd);
			this.pnlParameters.Controls.Add(this.lblServicio);
			this.pnlParameters.Controls.Add(this.txtServicio);
			this.pnlParameters.Controls.Add(this.lblConductor);
			this.pnlParameters.Controls.Add(this.cmbConductor);
			this.pnlParameters.Location = new System.Drawing.Point(12, 45);
			this.pnlParameters.Name = "pnlParameters";
			this.pnlParameters.Size = new System.Drawing.Size(616, 130);
			this.pnlParameters.TabIndex = 3;
			// 
			// btnActKm
			// 
			this.btnActKm.Location = new System.Drawing.Point(481, 79);
			this.btnActKm.Name = "btnActKm";
			this.btnActKm.Size = new System.Drawing.Size(127, 34);
			this.btnActKm.TabIndex = 8;
			this.btnActKm.Text = "Act. Km";
			this.btnActKm.UseVisualStyleBackColor = true;
			this.btnActKm.Click += new System.EventHandler(this.btnActKm_Click);
			// 
			// dteFechaPago
			// 
			this.dteFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaPago.Location = new System.Drawing.Point(116, 10);
			this.dteFechaPago.Name = "dteFechaPago";
			this.dteFechaPago.Size = new System.Drawing.Size(119, 24);
			this.dteFechaPago.TabIndex = 1;
			this.dteFechaPago.ValueChanged += new System.EventHandler(this.dteFechaPago_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fecha Pago";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(348, 80);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(127, 34);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "Agregar";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lblServicio
			// 
			this.lblServicio.AutoSize = true;
			this.lblServicio.BackColor = System.Drawing.Color.Transparent;
			this.lblServicio.Location = new System.Drawing.Point(13, 88);
			this.lblServicio.Name = "lblServicio";
			this.lblServicio.Size = new System.Drawing.Size(97, 18);
			this.lblServicio.TabIndex = 4;
			this.lblServicio.Text = "# de Servicio:";
			// 
			// txtServicio
			// 
			this.txtServicio.Location = new System.Drawing.Point(116, 85);
			this.txtServicio.Name = "txtServicio";
			this.txtServicio.Size = new System.Drawing.Size(226, 24);
			this.txtServicio.TabIndex = 5;
			this.txtServicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServicio_KeyPress);
			// 
			// lblConductor
			// 
			this.lblConductor.AutoSize = true;
			this.lblConductor.BackColor = System.Drawing.Color.Transparent;
			this.lblConductor.Location = new System.Drawing.Point(32, 51);
			this.lblConductor.Name = "lblConductor";
			this.lblConductor.Size = new System.Drawing.Size(78, 18);
			this.lblConductor.TabIndex = 2;
			this.lblConductor.Text = "Conductor";
			// 
			// cmbConductor
			// 
			this.cmbConductor.FormattingEnabled = true;
			this.cmbConductor.Location = new System.Drawing.Point(116, 47);
			this.cmbConductor.Name = "cmbConductor";
			this.cmbConductor.Size = new System.Drawing.Size(492, 26);
			this.cmbConductor.TabIndex = 3;
			this.cmbConductor.SelectedIndexChanged += new System.EventHandler(this.cmbConductor_SelectedIndexChanged);
			// 
			// dgvDetalleBoletos
			// 
			this.dgvDetalleBoletos.AllowUserToAddRows = false;
			this.dgvDetalleBoletos.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvDetalleBoletos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDetalleBoletos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvDetalleBoletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDetalleBoletos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero_Economico,
            this.Servicio,
            this.cmonto,
            this.Fecha_Servicio,
            this.Fecha_Captura});
			this.dgvDetalleBoletos.Location = new System.Drawing.Point(12, 180);
			this.dgvDetalleBoletos.MultiSelect = false;
			this.dgvDetalleBoletos.Name = "dgvDetalleBoletos";
			this.dgvDetalleBoletos.ReadOnly = true;
			this.dgvDetalleBoletos.RowTemplate.Height = 24;
			this.dgvDetalleBoletos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDetalleBoletos.Size = new System.Drawing.Size(616, 384);
			this.dgvDetalleBoletos.TabIndex = 4;
			// 
			// Numero_Economico
			// 
			this.Numero_Economico.DataPropertyName = "Numero_Economico";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Numero_Economico.DefaultCellStyle = dataGridViewCellStyle2;
			this.Numero_Economico.Frozen = true;
			this.Numero_Economico.HeaderText = "Unidad";
			this.Numero_Economico.Name = "Numero_Economico";
			this.Numero_Economico.ReadOnly = true;
			// 
			// Servicio
			// 
			this.Servicio.DataPropertyName = "Servicio";
			this.Servicio.Frozen = true;
			this.Servicio.HeaderText = "Servicio";
			this.Servicio.Name = "Servicio";
			this.Servicio.ReadOnly = true;
			// 
			// cmonto
			// 
			this.cmonto.DataPropertyName = "Monto";
			dataGridViewCellStyle3.Format = "C2";
			this.cmonto.DefaultCellStyle = dataGridViewCellStyle3;
			this.cmonto.Frozen = true;
			this.cmonto.HeaderText = "Monto";
			this.cmonto.Name = "cmonto";
			this.cmonto.ReadOnly = true;
			// 
			// Fecha_Servicio
			// 
			this.Fecha_Servicio.DataPropertyName = "Fecha_Servicio";
			this.Fecha_Servicio.HeaderText = "Fecha Servicio";
			this.Fecha_Servicio.Name = "Fecha_Servicio";
			this.Fecha_Servicio.ReadOnly = true;
			// 
			// Fecha_Captura
			// 
			this.Fecha_Captura.DataPropertyName = "Fecha_Captura";
			this.Fecha_Captura.HeaderText = "Fecha Captura";
			this.Fecha_Captura.Name = "Fecha_Captura";
			this.Fecha_Captura.ReadOnly = true;
			// 
			// pnlFooter
			// 
			this.pnlFooter.BackColor = System.Drawing.Color.Salmon;
			this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFooter.Controls.Add(this.lblTotaServicios);
			this.pnlFooter.Controls.Add(this.lblTotalMonto);
			this.pnlFooter.Controls.Add(this.label3);
			this.pnlFooter.Controls.Add(this.lblCountServicios);
			this.pnlFooter.Location = new System.Drawing.Point(12, 569);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new System.Drawing.Size(616, 44);
			this.pnlFooter.TabIndex = 6;
			// 
			// lblTotaServicios
			// 
			this.lblTotaServicios.BackColor = System.Drawing.Color.Transparent;
			this.lblTotaServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotaServicios.ForeColor = System.Drawing.Color.Black;
			this.lblTotaServicios.Location = new System.Drawing.Point(191, 3);
			this.lblTotaServicios.Name = "lblTotaServicios";
			this.lblTotaServicios.Size = new System.Drawing.Size(74, 36);
			this.lblTotaServicios.TabIndex = 3;
			this.lblTotaServicios.Text = "label4";
			this.lblTotaServicios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTotalMonto
			// 
			this.lblTotalMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalMonto.Location = new System.Drawing.Point(409, 3);
			this.lblTotalMonto.Name = "lblTotalMonto";
			this.lblTotalMonto.Size = new System.Drawing.Size(146, 36);
			this.lblTotalMonto.TabIndex = 2;
			this.lblTotalMonto.Text = "label4";
			this.lblTotalMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(324, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 18);
			this.label3.TabIndex = 1;
			this.label3.Text = "Total Caja:";
			// 
			// lblCountServicios
			// 
			this.lblCountServicios.AutoSize = true;
			this.lblCountServicios.Location = new System.Drawing.Point(52, 12);
			this.lblCountServicios.Name = "lblCountServicios";
			this.lblCountServicios.Size = new System.Drawing.Size(122, 18);
			this.lblCountServicios.TabIndex = 0;
			this.lblCountServicios.Text = "Total # Servicios:";
			// 
			// CapturaBoletosTiempoExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 625);
			this.Controls.Add(this.pnlFooter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnlParameters);
			this.Controls.Add(this.dgvDetalleBoletos);
			this.Name = "CapturaBoletosTiempoExtra";
			this.Text = "CapturaBoletosTiempoExtra";
			this.Controls.SetChildIndex(this.dgvDetalleBoletos, 0);
			this.Controls.SetChildIndex(this.pnlParameters, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.pnlFooter, 0);
			this.pnlParameters.ResumeLayout(false);
			this.pnlParameters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalleBoletos)).EndInit();
			this.pnlFooter.ResumeLayout(false);
			this.pnlFooter.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlParameters;
		private System.Windows.Forms.DateTimePicker dteFechaPago;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lblServicio;
		private System.Windows.Forms.TextBox txtServicio;
		private System.Windows.Forms.Label lblConductor;
		private System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.DataGridView dgvDetalleBoletos;
		private System.Windows.Forms.Panel pnlFooter;
		private System.Windows.Forms.Label lblTotaServicios;
		private System.Windows.Forms.Label lblTotalMonto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCountServicios;
		private System.Windows.Forms.DataGridViewTextBoxColumn Numero_Economico;
		private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
		private System.Windows.Forms.DataGridViewTextBoxColumn cmonto;
		private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Servicio;
		private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Captura;
		private System.Windows.Forms.Button btnActKm;
	}
}