namespace SICASv20.forms.caja.reportes.usercontrols.arqueodecaja
{
    partial class DeclaracionAptoUC
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

		#region Component Designer generated code

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvBilletes = new System.Windows.Forms.DataGridView();
            this.cBilletesDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBilletesCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBilletesMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBilletes = new System.Windows.Forms.GroupBox();
            this.pnlBilletes = new System.Windows.Forms.Panel();
            this.lblTotBilletes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMonedas = new System.Windows.Forms.GroupBox();
            this.pnlMonedas = new System.Windows.Forms.Panel();
            this.lblMonedas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMonedas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.lblNumEmpresarial = new System.Windows.Forms.Label();
            this.lblNumPrepago = new System.Windows.Forms.Label();
            this.lblNumVouchers = new System.Windows.Forms.Label();
            this.lblTotalVouchers = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.lblTotSesion = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotGeneral = new System.Windows.Forms.Label();
            this.lblTotVE = new System.Windows.Forms.Label();
            this.lblTotVp = new System.Windows.Forms.Label();
            this.lblTotEfectivo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ttMensajes = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilletes)).BeginInit();
            this.gbBilletes.SuspendLayout();
            this.pnlBilletes.SuspendLayout();
            this.gbMonedas.SuspendLayout();
            this.pnlMonedas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedas)).BeginInit();
            this.pnlTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Navy;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(414, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Declaración General";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvBilletes
            // 
            this.dgvBilletes.AllowUserToAddRows = false;
            this.dgvBilletes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBilletes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBilletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBilletes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cBilletesDesc,
            this.cBilletesCantidad,
            this.cBilletesMonto});
            this.dgvBilletes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBilletes.Location = new System.Drawing.Point(3, 20);
            this.dgvBilletes.Name = "dgvBilletes";
            this.dgvBilletes.RowHeadersVisible = false;
            this.dgvBilletes.RowTemplate.Height = 24;
            this.dgvBilletes.Size = new System.Drawing.Size(408, 206);
            this.dgvBilletes.TabIndex = 1;
            this.dgvBilletes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBilletes_DataError);
            // 
            // cBilletesDesc
            // 
            this.cBilletesDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cBilletesDesc.DataPropertyName = "Descripcion_Denominacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cBilletesDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.cBilletesDesc.HeaderText = "Denominacion";
            this.cBilletesDesc.Name = "cBilletesDesc";
            this.cBilletesDesc.ReadOnly = true;
            this.cBilletesDesc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cBilletesDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cBilletesCantidad
            // 
            this.cBilletesCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cBilletesCantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.cBilletesCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cBilletesCantidad.HeaderText = "Cantidad";
            this.cBilletesCantidad.Name = "cBilletesCantidad";
            this.cBilletesCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cBilletesCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cBilletesMonto
            // 
            this.cBilletesMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cBilletesMonto.DataPropertyName = "Monto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.cBilletesMonto.DefaultCellStyle = dataGridViewCellStyle4;
            this.cBilletesMonto.HeaderText = "Monto";
            this.cBilletesMonto.Name = "cBilletesMonto";
            this.cBilletesMonto.ReadOnly = true;
            this.cBilletesMonto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cBilletesMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbBilletes
            // 
            this.gbBilletes.Controls.Add(this.pnlBilletes);
            this.gbBilletes.Controls.Add(this.dgvBilletes);
            this.gbBilletes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBilletes.Location = new System.Drawing.Point(0, 24);
            this.gbBilletes.Name = "gbBilletes";
            this.gbBilletes.Size = new System.Drawing.Size(414, 257);
            this.gbBilletes.TabIndex = 2;
            this.gbBilletes.TabStop = false;
            this.gbBilletes.Text = "Billetes";
            // 
            // pnlBilletes
            // 
            this.pnlBilletes.Controls.Add(this.lblTotBilletes);
            this.pnlBilletes.Controls.Add(this.label1);
            this.pnlBilletes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBilletes.Location = new System.Drawing.Point(3, 227);
            this.pnlBilletes.Name = "pnlBilletes";
            this.pnlBilletes.Size = new System.Drawing.Size(408, 27);
            this.pnlBilletes.TabIndex = 2;
            // 
            // lblTotBilletes
            // 
            this.lblTotBilletes.BackColor = System.Drawing.Color.White;
            this.lblTotBilletes.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotBilletes.Location = new System.Drawing.Point(270, 3);
            this.lblTotBilletes.Name = "lblTotBilletes";
            this.lblTotBilletes.Size = new System.Drawing.Size(135, 20);
            this.lblTotBilletes.TabIndex = 1;
            this.lblTotBilletes.Text = "$0.00";
            this.lblTotBilletes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Billetes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbMonedas
            // 
            this.gbMonedas.Controls.Add(this.pnlMonedas);
            this.gbMonedas.Controls.Add(this.dgvMonedas);
            this.gbMonedas.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMonedas.Location = new System.Drawing.Point(0, 281);
            this.gbMonedas.Name = "gbMonedas";
            this.gbMonedas.Size = new System.Drawing.Size(414, 257);
            this.gbMonedas.TabIndex = 3;
            this.gbMonedas.TabStop = false;
            this.gbMonedas.Text = "Monedas";
            // 
            // pnlMonedas
            // 
            this.pnlMonedas.Controls.Add(this.lblMonedas);
            this.pnlMonedas.Controls.Add(this.label3);
            this.pnlMonedas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMonedas.Location = new System.Drawing.Point(3, 227);
            this.pnlMonedas.Name = "pnlMonedas";
            this.pnlMonedas.Size = new System.Drawing.Size(408, 27);
            this.pnlMonedas.TabIndex = 2;
            // 
            // lblMonedas
            // 
            this.lblMonedas.BackColor = System.Drawing.Color.White;
            this.lblMonedas.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonedas.Location = new System.Drawing.Point(270, 3);
            this.lblMonedas.Name = "lblMonedas";
            this.lblMonedas.Size = new System.Drawing.Size(135, 20);
            this.lblMonedas.TabIndex = 1;
            this.lblMonedas.Text = "$0.00";
            this.lblMonedas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Monedas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvMonedas
            // 
            this.dgvMonedas.AllowUserToAddRows = false;
            this.dgvMonedas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonedas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonedas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvMonedas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMonedas.Location = new System.Drawing.Point(3, 20);
            this.dgvMonedas.Name = "dgvMonedas";
            this.dgvMonedas.RowHeadersVisible = false;
            this.dgvMonedas.RowTemplate.Height = 24;
            this.dgvMonedas.Size = new System.Drawing.Size(408, 206);
            this.dgvMonedas.TabIndex = 1;
            this.dgvMonedas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBilletes_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion_Denominacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Denominacion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Cantidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Monto";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlTotales
            // 
            this.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotales.Controls.Add(this.lblNumEmpresarial);
            this.pnlTotales.Controls.Add(this.lblNumPrepago);
            this.pnlTotales.Controls.Add(this.lblNumVouchers);
            this.pnlTotales.Controls.Add(this.lblTotalVouchers);
            this.pnlTotales.Controls.Add(this.label9);
            this.pnlTotales.Controls.Add(this.txtObservaciones);
            this.pnlTotales.Controls.Add(this.btnSiguiente);
            this.pnlTotales.Controls.Add(this.lblDiferencia);
            this.pnlTotales.Controls.Add(this.lblTotSesion);
            this.pnlTotales.Controls.Add(this.label8);
            this.pnlTotales.Controls.Add(this.label7);
            this.pnlTotales.Controls.Add(this.lblTotGeneral);
            this.pnlTotales.Controls.Add(this.lblTotVE);
            this.pnlTotales.Controls.Add(this.lblTotVp);
            this.pnlTotales.Controls.Add(this.lblTotEfectivo);
            this.pnlTotales.Controls.Add(this.label6);
            this.pnlTotales.Controls.Add(this.label5);
            this.pnlTotales.Controls.Add(this.label4);
            this.pnlTotales.Controls.Add(this.label2);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotales.Location = new System.Drawing.Point(0, 538);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(414, 249);
            this.pnlTotales.TabIndex = 4;
            // 
            // lblNumEmpresarial
            // 
            this.lblNumEmpresarial.BackColor = System.Drawing.Color.White;
            this.lblNumEmpresarial.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumEmpresarial.Location = new System.Drawing.Point(189, 83);
            this.lblNumEmpresarial.Name = "lblNumEmpresarial";
            this.lblNumEmpresarial.Size = new System.Drawing.Size(78, 20);
            this.lblNumEmpresarial.TabIndex = 19;
            this.lblNumEmpresarial.Text = "0";
            this.lblNumEmpresarial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumPrepago
            // 
            this.lblNumPrepago.BackColor = System.Drawing.Color.White;
            this.lblNumPrepago.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPrepago.Location = new System.Drawing.Point(189, 57);
            this.lblNumPrepago.Name = "lblNumPrepago";
            this.lblNumPrepago.Size = new System.Drawing.Size(78, 20);
            this.lblNumPrepago.TabIndex = 18;
            this.lblNumPrepago.Text = "0";
            this.lblNumPrepago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumVouchers
            // 
            this.lblNumVouchers.BackColor = System.Drawing.Color.White;
            this.lblNumVouchers.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumVouchers.Location = new System.Drawing.Point(189, 29);
            this.lblNumVouchers.Name = "lblNumVouchers";
            this.lblNumVouchers.Size = new System.Drawing.Size(78, 20);
            this.lblNumVouchers.TabIndex = 17;
            this.lblNumVouchers.Text = "0";
            this.lblNumVouchers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalVouchers
            // 
            this.lblTotalVouchers.BackColor = System.Drawing.Color.White;
            this.lblTotalVouchers.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVouchers.Location = new System.Drawing.Point(273, 29);
            this.lblTotalVouchers.Name = "lblTotalVouchers";
            this.lblTotalVouchers.Size = new System.Drawing.Size(135, 20);
            this.lblTotalVouchers.TabIndex = 16;
            this.lblTotalVouchers.Text = "$0.00";
            this.lblTotalVouchers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "Total Vouchers";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.Location = new System.Drawing.Point(4, 182);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(256, 65);
            this.txtObservaciones.TabIndex = 14;
            this.ttMensajes.SetToolTip(this.txtObservaciones, "Aquí puede indicar alguna \r\nobservación con respecto a \r\nla declaración de efecti" +
        "vo \r\nque está realizando.");
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(266, 182);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(141, 69);
            this.btnSiguiente.TabIndex = 13;
            this.btnSiguiente.Text = "Continuar";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.BackColor = System.Drawing.Color.White;
            this.lblDiferencia.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Location = new System.Drawing.Point(273, 159);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(135, 20);
            this.lblDiferencia.TabIndex = 12;
            this.lblDiferencia.Text = "$0.00";
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensajes.SetToolTip(this.lblDiferencia, "Es la diferencia correspondiente a\r\ningresos registrados en el sistema - \r\ningres" +
        "os declarados");
            // 
            // lblTotSesion
            // 
            this.lblTotSesion.BackColor = System.Drawing.Color.White;
            this.lblTotSesion.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotSesion.Location = new System.Drawing.Point(273, 133);
            this.lblTotSesion.Name = "lblTotSesion";
            this.lblTotSesion.Size = new System.Drawing.Size(135, 20);
            this.lblTotSesion.TabIndex = 11;
            this.lblTotSesion.Text = "$0.00";
            this.lblTotSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensajes.SetToolTip(this.lblTotSesion, "Total de Ingresos registrados \r\nen sistema para la sesión actual");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Diferencia";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total en Sesión";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotGeneral
            // 
            this.lblTotGeneral.BackColor = System.Drawing.Color.White;
            this.lblTotGeneral.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotGeneral.Location = new System.Drawing.Point(273, 107);
            this.lblTotGeneral.Name = "lblTotGeneral";
            this.lblTotGeneral.Size = new System.Drawing.Size(135, 20);
            this.lblTotGeneral.TabIndex = 8;
            this.lblTotGeneral.Text = "$0.00";
            this.lblTotGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensajes.SetToolTip(this.lblTotGeneral, "Es la suma de\r\nEfectivo declarado + \r\nVales Prepagados  + \r\nVales Empresariales");
            // 
            // lblTotVE
            // 
            this.lblTotVE.BackColor = System.Drawing.Color.White;
            this.lblTotVE.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotVE.Location = new System.Drawing.Point(273, 81);
            this.lblTotVE.Name = "lblTotVE";
            this.lblTotVE.Size = new System.Drawing.Size(135, 20);
            this.lblTotVE.TabIndex = 7;
            this.lblTotVE.Text = "$0.00";
            this.lblTotVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotVp
            // 
            this.lblTotVp.BackColor = System.Drawing.Color.White;
            this.lblTotVp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotVp.Location = new System.Drawing.Point(273, 55);
            this.lblTotVp.Name = "lblTotVp";
            this.lblTotVp.Size = new System.Drawing.Size(135, 20);
            this.lblTotVp.TabIndex = 6;
            this.lblTotVp.Text = "$0.00";
            this.lblTotVp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotEfectivo
            // 
            this.lblTotEfectivo.BackColor = System.Drawing.Color.White;
            this.lblTotEfectivo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotEfectivo.Location = new System.Drawing.Point(273, 3);
            this.lblTotEfectivo.Name = "lblTotEfectivo";
            this.lblTotEfectivo.Size = new System.Drawing.Size(135, 20);
            this.lblTotEfectivo.TabIndex = 5;
            this.lblTotEfectivo.Text = "$0.00";
            this.lblTotEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Ingresos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total Vales Empresariales";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Vales Prepagados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Efectivo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ttMensajes
            // 
            this.ttMensajes.AutomaticDelay = 300;
            this.ttMensajes.IsBalloon = true;
            // 
            // DeclaracionAptoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.gbMonedas);
            this.Controls.Add(this.gbBilletes);
            this.Controls.Add(this.lblTitle);
            this.Name = "DeclaracionAptoUC";
            this.Size = new System.Drawing.Size(414, 790);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilletes)).EndInit();
            this.gbBilletes.ResumeLayout(false);
            this.pnlBilletes.ResumeLayout(false);
            this.pnlBilletes.PerformLayout();
            this.gbMonedas.ResumeLayout(false);
            this.pnlMonedas.ResumeLayout(false);
            this.pnlMonedas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonedas)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.DataGridView dgvBilletes;
		private System.Windows.Forms.GroupBox gbBilletes;
		private System.Windows.Forms.Panel pnlBilletes;
		private System.Windows.Forms.Label lblTotBilletes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gbMonedas;
		private System.Windows.Forms.Panel pnlMonedas;
		private System.Windows.Forms.Label lblMonedas;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dgvMonedas;
		private System.Windows.Forms.Panel pnlTotales;
		private System.Windows.Forms.Label lblTotGeneral;
		private System.Windows.Forms.Label lblTotVE;
		private System.Windows.Forms.Label lblTotVp;
		private System.Windows.Forms.Label lblTotEfectivo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewTextBoxColumn cBilletesDesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn cBilletesCantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn cBilletesMonto;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblDiferencia;
		private System.Windows.Forms.Label lblTotSesion;
		public System.Windows.Forms.Button btnSiguiente;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.ToolTip ttMensajes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNumEmpresarial;
        private System.Windows.Forms.Label lblNumPrepago;
        private System.Windows.Forms.Label lblNumVouchers;
        private System.Windows.Forms.Label lblTotalVouchers;
	}
}
