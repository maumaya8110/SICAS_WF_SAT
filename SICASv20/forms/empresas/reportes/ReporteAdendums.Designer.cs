namespace SICASv20.forms
{
    partial class ReporteAdendums
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPickFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxCond = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxContrato = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxConcepto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxUnidad = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpickFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adendumIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contratoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indefinidoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MontoAjustadoAlDiaDeHoy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdendumReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdendumReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 461);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta de Adendums";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRegresar);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtPickFin);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btnFiltrar);
            this.splitContainer1.Panel1.Controls.Add(this.dtpickFechaIni);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(752, 441);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(511, 3);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(142, 24);
            this.btnRegresar.TabIndex = 21;
            this.btnRegresar.Text = "&Admon. de Adendums";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 20;
            this.button1.Text = "&Borrar filtros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "hasta:";
            // 
            // dtPickFin
            // 
            this.dtPickFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickFin.Location = new System.Drawing.Point(254, 4);
            this.dtPickFin.Name = "dtPickFin";
            this.dtPickFin.Size = new System.Drawing.Size(91, 21);
            this.dtPickFin.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboxCond);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboxContrato);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboxConcepto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboxUnidad);
            this.groupBox2.Location = new System.Drawing.Point(3, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 70);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros dinamicos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cond:";
            // 
            // cboxCond
            // 
            this.cboxCond.FormattingEnabled = true;
            this.cboxCond.Location = new System.Drawing.Point(460, 19);
            this.cboxCond.Name = "cboxCond";
            this.cboxCond.Size = new System.Drawing.Size(181, 23);
            this.cboxCond.TabIndex = 17;
            this.cboxCond.SelectedIndexChanged += new System.EventHandler(this.cboxUnidad_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Contrato:";
            // 
            // cboxContrato
            // 
            this.cboxContrato.FormattingEnabled = true;
            this.cboxContrato.Location = new System.Drawing.Point(343, 20);
            this.cboxContrato.Name = "cboxContrato";
            this.cboxContrato.Size = new System.Drawing.Size(66, 23);
            this.cboxContrato.TabIndex = 15;
            this.cboxContrato.SelectedIndexChanged += new System.EventHandler(this.cboxUnidad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Concepto:";
            // 
            // cboxConcepto
            // 
            this.cboxConcepto.FormattingEnabled = true;
            this.cboxConcepto.Location = new System.Drawing.Point(176, 20);
            this.cboxConcepto.Name = "cboxConcepto";
            this.cboxConcepto.Size = new System.Drawing.Size(105, 23);
            this.cboxConcepto.TabIndex = 13;
            this.cboxConcepto.SelectedIndexChanged += new System.EventHandler(this.cboxUnidad_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Unidad:";
            // 
            // cboxUnidad
            // 
            this.cboxUnidad.FormattingEnabled = true;
            this.cboxUnidad.Location = new System.Drawing.Point(54, 19);
            this.cboxUnidad.Name = "cboxUnidad";
            this.cboxUnidad.Size = new System.Drawing.Size(57, 23);
            this.cboxUnidad.TabIndex = 11;
            this.cboxUnidad.SelectedIndexChanged += new System.EventHandler(this.cboxUnidad_SelectedIndexChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(350, 3);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(46, 24);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "&Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtpickFechaIni
            // 
            this.dtpickFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpickFechaIni.Location = new System.Drawing.Point(120, 4);
            this.dtpickFechaIni.Name = "dtpickFechaIni";
            this.dtpickFechaIni.Size = new System.Drawing.Size(91, 21);
            this.dtpickFechaIni.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Adendums desde:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conductorDataGridViewTextBoxColumn,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.adendumIDDataGridViewTextBoxColumn,
            this.contratoIDDataGridViewTextBoxColumn,
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.fechaFinDataGridViewTextBoxColumn,
            this.indefinidoDataGridViewCheckBoxColumn,
            this.MontoAjustadoAlDiaDeHoy,
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.AdendumReportBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.Size = new System.Drawing.Size(752, 339);
            this.dataGridView1.TabIndex = 1;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            this.conductorDataGridViewTextBoxColumn.Width = 70;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "No. Economico";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroEconomicoDataGridViewTextBoxColumn.Width = 75;
            // 
            // adendumIDDataGridViewTextBoxColumn
            // 
            this.adendumIDDataGridViewTextBoxColumn.DataPropertyName = "Adendum_ID";
            this.adendumIDDataGridViewTextBoxColumn.HeaderText = "Adendum";
            this.adendumIDDataGridViewTextBoxColumn.Name = "adendumIDDataGridViewTextBoxColumn";
            this.adendumIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.adendumIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // contratoIDDataGridViewTextBoxColumn
            // 
            this.contratoIDDataGridViewTextBoxColumn.DataPropertyName = "Contrato_ID";
            this.contratoIDDataGridViewTextBoxColumn.HeaderText = "Contrato";
            this.contratoIDDataGridViewTextBoxColumn.Name = "contratoIDDataGridViewTextBoxColumn";
            this.contratoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.contratoIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // clasificacionAdendumsDescripcionDataGridViewTextBoxColumn
            // 
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.DataPropertyName = "ClasificacionAdendums_Descripcion";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.HeaderText = "Concepto";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.Name = "clasificacionAdendumsDescripcionDataGridViewTextBoxColumn";
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.clasificacionAdendumsDescripcionDataGridViewTextBoxColumn.Width = 65;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "FechaInicio";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaInicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "Inicio";
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            this.fechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaInicioDataGridViewTextBoxColumn.Width = 60;
            // 
            // fechaFinDataGridViewTextBoxColumn
            // 
            this.fechaFinDataGridViewTextBoxColumn.DataPropertyName = "FechaFin";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaFinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaFinDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.fechaFinDataGridViewTextBoxColumn.Name = "fechaFinDataGridViewTextBoxColumn";
            this.fechaFinDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaFinDataGridViewTextBoxColumn.Width = 60;
            // 
            // indefinidoDataGridViewCheckBoxColumn
            // 
            this.indefinidoDataGridViewCheckBoxColumn.DataPropertyName = "Indefinido";
            this.indefinidoDataGridViewCheckBoxColumn.HeaderText = "Indefinido";
            this.indefinidoDataGridViewCheckBoxColumn.Name = "indefinidoDataGridViewCheckBoxColumn";
            this.indefinidoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.indefinidoDataGridViewCheckBoxColumn.Width = 70;
            // 
            // MontoAjustadoAlDiaDeHoy
            // 
            this.MontoAjustadoAlDiaDeHoy.DataPropertyName = "MontoAjustadoAlDiaDeHoy";
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            this.MontoAjustadoAlDiaDeHoy.DefaultCellStyle = dataGridViewCellStyle3;
            this.MontoAjustadoAlDiaDeHoy.HeaderText = "Monto Ajustado";
            this.MontoAjustadoAlDiaDeHoy.Name = "MontoAjustadoAlDiaDeHoy";
            this.MontoAjustadoAlDiaDeHoy.ReadOnly = true;
            this.MontoAjustadoAlDiaDeHoy.Width = 65;
            // 
            // diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn
            // 
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn.DataPropertyName = "DiasAjustadosAlDiaDeHoy";
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn.HeaderText = "Dias Ajustados";
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn.Name = "diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn";
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn.ReadOnly = true;
            this.diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn.Width = 65;
            // 
            // AdendumReportBindingSource
            // 
            this.AdendumReportBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ReporteAdendums);
            // 
            // ReporteAdendums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 461);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteAdendums";
            this.Text = "ReporteAdendums";
            this.Load += new System.EventHandler(this.ReporteAdendums_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdendumReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource AdendumReportBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpickFechaIni;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxCond;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxContrato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxUnidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPickFin;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adendumIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionAdendumsDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn indefinidoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAjustadoAlDiaDeHoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasAjustadosAlDiaDeHoyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegresar;
    }
}