namespace SICASv20.forms
{
    partial class VerificacionBoletos
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
            System.Windows.Forms.Label zonaLabel;
            System.Windows.Forms.Label tipoServicioLabel;
            System.Windows.Forms.Label claseServicioLabel;
            System.Windows.Forms.Label estatusLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label fechaServicioLabel;
            System.Windows.Forms.Label precioLabel;
            System.Windows.Forms.Label unidadLabel;
            System.Windows.Forms.Label conductorLabel;
            System.Windows.Forms.Label pagoConductorLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalServiciosTextBox = new System.Windows.Forms.TextBox();
            this.ServiciosPendientesGridView = new System.Windows.Forms.DataGridView();
            this.servicioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoConductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviciosPendientesConductorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.NombreConductorTextBox = new System.Windows.Forms.TextBox();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaPagoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ServicioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKilometraje = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.estatusTextBox = new System.Windows.Forms.TextBox();
            this.vista_ServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fechaServicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.claseServicioTextBox = new System.Windows.Forms.TextBox();
            this.conductorTextBox = new System.Windows.Forms.TextBox();
            this.tipoServicioTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.precioTextBox = new System.Windows.Forms.TextBox();
            this.unidadTextBox = new System.Windows.Forms.TextBox();
            this.zonaTextBox = new System.Windows.Forms.TextBox();
            this.pagoConductorTextBox = new System.Windows.Forms.TextBox();
            this.ActualizarButton = new System.Windows.Forms.Button();
            zonaLabel = new System.Windows.Forms.Label();
            tipoServicioLabel = new System.Windows.Forms.Label();
            claseServicioLabel = new System.Windows.Forms.Label();
            estatusLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            fechaServicioLabel = new System.Windows.Forms.Label();
            precioLabel = new System.Windows.Forms.Label();
            unidadLabel = new System.Windows.Forms.Label();
            conductorLabel = new System.Windows.Forms.Label();
            pagoConductorLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // zonaLabel
            // 
            zonaLabel.AutoSize = true;
            zonaLabel.Location = new System.Drawing.Point(3, 81);
            zonaLabel.Name = "zonaLabel";
            zonaLabel.Size = new System.Drawing.Size(46, 18);
            zonaLabel.TabIndex = 0;
            zonaLabel.Text = "Zona:";
            // 
            // tipoServicioLabel
            // 
            tipoServicioLabel.AutoSize = true;
            tipoServicioLabel.Location = new System.Drawing.Point(3, 162);
            tipoServicioLabel.Name = "tipoServicioLabel";
            tipoServicioLabel.Size = new System.Drawing.Size(98, 18);
            tipoServicioLabel.TabIndex = 2;
            tipoServicioLabel.Text = "Tipo Servicio:";
            // 
            // claseServicioLabel
            // 
            claseServicioLabel.AutoSize = true;
            claseServicioLabel.Location = new System.Drawing.Point(3, 189);
            claseServicioLabel.Name = "claseServicioLabel";
            claseServicioLabel.Size = new System.Drawing.Size(107, 18);
            claseServicioLabel.TabIndex = 4;
            claseServicioLabel.Text = "Clase Servicio:";
            // 
            // estatusLabel
            // 
            estatusLabel.AutoSize = true;
            estatusLabel.Location = new System.Drawing.Point(3, 216);
            estatusLabel.Name = "estatusLabel";
            estatusLabel.Size = new System.Drawing.Size(62, 18);
            estatusLabel.TabIndex = 6;
            estatusLabel.Text = "Estatus:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(3, 108);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(53, 18);
            fechaLabel.TabIndex = 8;
            fechaLabel.Text = "Fecha:";
            // 
            // fechaServicioLabel
            // 
            fechaServicioLabel.AutoSize = true;
            fechaServicioLabel.Location = new System.Drawing.Point(3, 135);
            fechaServicioLabel.Name = "fechaServicioLabel";
            fechaServicioLabel.Size = new System.Drawing.Size(110, 18);
            fechaServicioLabel.TabIndex = 10;
            fechaServicioLabel.Text = "Fecha Servicio:";
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new System.Drawing.Point(3, 0);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new System.Drawing.Size(55, 18);
            precioLabel.TabIndex = 12;
            precioLabel.Text = "Precio:";
            // 
            // unidadLabel
            // 
            unidadLabel.AutoSize = true;
            unidadLabel.Location = new System.Drawing.Point(3, 27);
            unidadLabel.Name = "unidadLabel";
            unidadLabel.Size = new System.Drawing.Size(58, 18);
            unidadLabel.TabIndex = 14;
            unidadLabel.Text = "Unidad:";
            // 
            // conductorLabel
            // 
            conductorLabel.AutoSize = true;
            conductorLabel.Location = new System.Drawing.Point(3, 54);
            conductorLabel.Name = "conductorLabel";
            conductorLabel.Size = new System.Drawing.Size(82, 18);
            conductorLabel.TabIndex = 16;
            conductorLabel.Text = "Conductor:";
            // 
            // pagoConductorLabel
            // 
            pagoConductorLabel.AutoSize = true;
            pagoConductorLabel.Location = new System.Drawing.Point(3, 243);
            pagoConductorLabel.Name = "pagoConductorLabel";
            pagoConductorLabel.Size = new System.Drawing.Size(82, 27);
            pagoConductorLabel.TabIndex = 18;
            pagoConductorLabel.Text = "Pago Conductor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TotalServiciosTextBox);
            this.groupBox1.Controls.Add(this.ServiciosPendientesGridView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NombreConductorTextBox);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FechaPagoDateTimePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ServicioTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verificación de boletos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(293, 599);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Total servicios:";
            // 
            // TotalServiciosTextBox
            // 
            this.TotalServiciosTextBox.BackColor = System.Drawing.Color.White;
            this.TotalServiciosTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalServiciosTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalServiciosTextBox.Location = new System.Drawing.Point(422, 597);
            this.TotalServiciosTextBox.Name = "TotalServiciosTextBox";
            this.TotalServiciosTextBox.ReadOnly = true;
            this.TotalServiciosTextBox.Size = new System.Drawing.Size(116, 27);
            this.TotalServiciosTextBox.TabIndex = 24;
            this.TotalServiciosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ServiciosPendientesGridView
            // 
            this.ServiciosPendientesGridView.AllowUserToAddRows = false;
            this.ServiciosPendientesGridView.AllowUserToDeleteRows = false;
            this.ServiciosPendientesGridView.AutoGenerateColumns = false;
            this.ServiciosPendientesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosPendientesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servicioIDDataGridViewTextBoxColumn,
            this.empresaIDDataGridViewTextBoxColumn,
            this.cuentaIDDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.pagoConductorDataGridViewTextBoxColumn,
            this.destinoDataGridViewTextBoxColumn});
            this.ServiciosPendientesGridView.DataSource = this.serviciosPendientesConductorBindingSource;
            this.ServiciosPendientesGridView.Location = new System.Drawing.Point(22, 134);
            this.ServiciosPendientesGridView.Name = "ServiciosPendientesGridView";
            this.ServiciosPendientesGridView.ReadOnly = true;
            this.ServiciosPendientesGridView.Size = new System.Drawing.Size(516, 457);
            this.ServiciosPendientesGridView.TabIndex = 23;
            this.ServiciosPendientesGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.ServiciosPendientesGridView_CellValueNeeded);
            // 
            // servicioIDDataGridViewTextBoxColumn
            // 
            this.servicioIDDataGridViewTextBoxColumn.DataPropertyName = "Servicio_ID";
            this.servicioIDDataGridViewTextBoxColumn.HeaderText = "Servicio_ID";
            this.servicioIDDataGridViewTextBoxColumn.Name = "servicioIDDataGridViewTextBoxColumn";
            this.servicioIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empresaIDDataGridViewTextBoxColumn
            // 
            this.empresaIDDataGridViewTextBoxColumn.DataPropertyName = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.HeaderText = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.Name = "empresaIDDataGridViewTextBoxColumn";
            this.empresaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.empresaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cuentaIDDataGridViewTextBoxColumn
            // 
            this.cuentaIDDataGridViewTextBoxColumn.DataPropertyName = "Cuenta_ID";
            this.cuentaIDDataGridViewTextBoxColumn.HeaderText = "Cuenta_ID";
            this.cuentaIDDataGridViewTextBoxColumn.Name = "cuentaIDDataGridViewTextBoxColumn";
            this.cuentaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "c";
            this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pagoConductorDataGridViewTextBoxColumn
            // 
            this.pagoConductorDataGridViewTextBoxColumn.DataPropertyName = "PagoConductor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "c";
            this.pagoConductorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pagoConductorDataGridViewTextBoxColumn.HeaderText = "PagoConductor";
            this.pagoConductorDataGridViewTextBoxColumn.Name = "pagoConductorDataGridViewTextBoxColumn";
            this.pagoConductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destinoDataGridViewTextBoxColumn
            // 
            this.destinoDataGridViewTextBoxColumn.DataPropertyName = "Destino";
            this.destinoDataGridViewTextBoxColumn.HeaderText = "Destino";
            this.destinoDataGridViewTextBoxColumn.Name = "destinoDataGridViewTextBoxColumn";
            this.destinoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviciosPendientesConductorBindingSource
            // 
            this.serviciosPendientesConductorBindingSource.DataSource = typeof(SICASv20.Entities.ServiciosPendientesConductor);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(19, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Conductor:";
            // 
            // NombreConductorTextBox
            // 
            this.NombreConductorTextBox.BackColor = System.Drawing.Color.White;
            this.NombreConductorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreConductorTextBox.Location = new System.Drawing.Point(130, 88);
            this.NombreConductorTextBox.Name = "NombreConductorTextBox";
            this.NombreConductorTextBox.ReadOnly = true;
            this.NombreConductorTextBox.Size = new System.Drawing.Size(357, 24);
            this.NombreConductorTextBox.TabIndex = 21;
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.BackColor = System.Drawing.Color.White;
            this.NumeroEconomicoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(130, 59);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(116, 24);
            this.NumeroEconomicoTextBox.TabIndex = 20;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UnidadTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Unidad:";
            // 
            // FechaPagoDateTimePicker
            // 
            this.FechaPagoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaPagoDateTimePicker.Location = new System.Drawing.Point(130, 30);
            this.FechaPagoDateTimePicker.Name = "FechaPagoDateTimePicker";
            this.FechaPagoDateTimePicker.Size = new System.Drawing.Size(116, 24);
            this.FechaPagoDateTimePicker.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Fecha a pagar:";
            // 
            // ServicioTextBox
            // 
            this.ServicioTextBox.Location = new System.Drawing.Point(614, 24);
            this.ServicioTextBox.MaxLength = 21;
            this.ServicioTextBox.Name = "ServicioTextBox";
            this.ServicioTextBox.Size = new System.Drawing.Size(354, 24);
            this.ServicioTextBox.TabIndex = 2;
            this.ServicioTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ServicioTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servicio:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKilometraje);
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(558, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 527);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del servicio";
            // 
            // btnKilometraje
            // 
            this.btnKilometraje.Location = new System.Drawing.Point(103, 458);
            this.btnKilometraje.Name = "btnKilometraje";
            this.btnKilometraje.Size = new System.Drawing.Size(216, 38);
            this.btnKilometraje.TabIndex = 19;
            this.btnKilometraje.Text = "Actualizar Kilometraje";
            this.btnKilometraje.UseVisualStyleBackColor = true;
            this.btnKilometraje.Visible = false;
            this.btnKilometraje.Click += new System.EventHandler(this.btnKilometraje_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.60411F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.39589F));
            this.tableLayoutPanel2.Controls.Add(precioLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.estatusTextBox, 1, 8);
            this.tableLayoutPanel2.Controls.Add(estatusLabel, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.fechaServicioDateTimePicker, 1, 5);
            this.tableLayoutPanel2.Controls.Add(fechaServicioLabel, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.claseServicioTextBox, 1, 7);
            this.tableLayoutPanel2.Controls.Add(claseServicioLabel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.conductorTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(conductorLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tipoServicioTextBox, 1, 6);
            this.tableLayoutPanel2.Controls.Add(tipoServicioLabel, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.fechaDateTimePicker, 1, 4);
            this.tableLayoutPanel2.Controls.Add(fechaLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.precioTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(unidadLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.unidadTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(zonaLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.zonaTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(pagoConductorLabel, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.pagoConductorTextBox, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.ActualizarButton, 1, 10);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(358, 304);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // estatusTextBox
            // 
            this.estatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "Estatus", true));
            this.estatusTextBox.Location = new System.Drawing.Point(126, 219);
            this.estatusTextBox.Name = "estatusTextBox";
            this.estatusTextBox.ReadOnly = true;
            this.estatusTextBox.Size = new System.Drawing.Size(217, 24);
            this.estatusTextBox.TabIndex = 7;
            // 
            // vista_ServiciosBindingSource
            // 
            this.vista_ServiciosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Servicios);
            // 
            // fechaServicioDateTimePicker
            // 
            this.fechaServicioDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vista_ServiciosBindingSource, "FechaServicio", true));
            this.fechaServicioDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaServicioDateTimePicker.Location = new System.Drawing.Point(126, 138);
            this.fechaServicioDateTimePicker.Name = "fechaServicioDateTimePicker";
            this.fechaServicioDateTimePicker.Size = new System.Drawing.Size(136, 24);
            this.fechaServicioDateTimePicker.TabIndex = 11;
            // 
            // claseServicioTextBox
            // 
            this.claseServicioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "ClaseServicio", true));
            this.claseServicioTextBox.Location = new System.Drawing.Point(126, 192);
            this.claseServicioTextBox.Name = "claseServicioTextBox";
            this.claseServicioTextBox.ReadOnly = true;
            this.claseServicioTextBox.Size = new System.Drawing.Size(217, 24);
            this.claseServicioTextBox.TabIndex = 5;
            // 
            // conductorTextBox
            // 
            this.conductorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "Conductor", true));
            this.conductorTextBox.Location = new System.Drawing.Point(126, 57);
            this.conductorTextBox.Name = "conductorTextBox";
            this.conductorTextBox.ReadOnly = true;
            this.conductorTextBox.Size = new System.Drawing.Size(217, 24);
            this.conductorTextBox.TabIndex = 17;
            // 
            // tipoServicioTextBox
            // 
            this.tipoServicioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "TipoServicio", true));
            this.tipoServicioTextBox.Location = new System.Drawing.Point(126, 165);
            this.tipoServicioTextBox.Name = "tipoServicioTextBox";
            this.tipoServicioTextBox.ReadOnly = true;
            this.tipoServicioTextBox.Size = new System.Drawing.Size(217, 24);
            this.tipoServicioTextBox.TabIndex = 3;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vista_ServiciosBindingSource, "Fecha", true));
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(126, 111);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(136, 24);
            this.fechaDateTimePicker.TabIndex = 9;
            // 
            // precioTextBox
            // 
            this.precioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "Precio", true));
            this.precioTextBox.Location = new System.Drawing.Point(126, 3);
            this.precioTextBox.Name = "precioTextBox";
            this.precioTextBox.ReadOnly = true;
            this.precioTextBox.Size = new System.Drawing.Size(100, 24);
            this.precioTextBox.TabIndex = 13;
            // 
            // unidadTextBox
            // 
            this.unidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "Unidad", true));
            this.unidadTextBox.Location = new System.Drawing.Point(126, 30);
            this.unidadTextBox.Name = "unidadTextBox";
            this.unidadTextBox.ReadOnly = true;
            this.unidadTextBox.Size = new System.Drawing.Size(217, 24);
            this.unidadTextBox.TabIndex = 15;
            // 
            // zonaTextBox
            // 
            this.zonaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "Zona", true));
            this.zonaTextBox.Location = new System.Drawing.Point(126, 84);
            this.zonaTextBox.Name = "zonaTextBox";
            this.zonaTextBox.ReadOnly = true;
            this.zonaTextBox.Size = new System.Drawing.Size(217, 24);
            this.zonaTextBox.TabIndex = 1;
            // 
            // pagoConductorTextBox
            // 
            this.pagoConductorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ServiciosBindingSource, "PagoConductor", true));
            this.pagoConductorTextBox.Location = new System.Drawing.Point(126, 246);
            this.pagoConductorTextBox.Name = "pagoConductorTextBox";
            this.pagoConductorTextBox.ReadOnly = true;
            this.pagoConductorTextBox.Size = new System.Drawing.Size(100, 24);
            this.pagoConductorTextBox.TabIndex = 19;
            // 
            // ActualizarButton
            // 
            this.ActualizarButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActualizarButton.Location = new System.Drawing.Point(126, 273);
            this.ActualizarButton.Name = "ActualizarButton";
            this.ActualizarButton.Size = new System.Drawing.Size(229, 28);
            this.ActualizarButton.TabIndex = 20;
            this.ActualizarButton.Text = "Pagar boleto hoy";
            this.ActualizarButton.UseVisualStyleBackColor = true;
            this.ActualizarButton.Click += new System.EventHandler(this.ActualizarButton_Click);
            // 
            // VerificacionBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "VerificacionBoletos";
            this.Text = "RastreoCambioBoletos";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ServicioTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox estatusTextBox;
        private System.Windows.Forms.BindingSource vista_ServiciosBindingSource;
        private System.Windows.Forms.DateTimePicker fechaServicioDateTimePicker;
        private System.Windows.Forms.TextBox claseServicioTextBox;
        private System.Windows.Forms.TextBox conductorTextBox;
        private System.Windows.Forms.TextBox tipoServicioTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox precioTextBox;
        private System.Windows.Forms.TextBox unidadTextBox;
        private System.Windows.Forms.TextBox zonaTextBox;
	   private System.Windows.Forms.DataGridView ServiciosPendientesGridView;
        private System.Windows.Forms.BindingSource serviciosPendientesConductorBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NombreConductorTextBox;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaPagoDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalServiciosTextBox;
        private System.Windows.Forms.TextBox pagoConductorTextBox;
        private System.Windows.Forms.Button ActualizarButton;
	   private System.Windows.Forms.Button btnKilometraje;
	   private System.Windows.Forms.DataGridViewTextBoxColumn servicioIDDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn empresaIDDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn cuentaIDDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn pagoConductorDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn destinoDataGridViewTextBoxColumn;
    }
}