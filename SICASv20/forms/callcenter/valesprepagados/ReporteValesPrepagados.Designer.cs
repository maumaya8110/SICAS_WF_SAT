namespace SICASv20.forms
{
    partial class ReporteValesPrepagados
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.vistaReporteValesPrepagadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.IngresosEgresosCajasReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.EstatusComboBox = new System.Windows.Forms.ComboBox();
			this.estatusValesPrepagadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.ConsultarButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.ClienteComboBox = new System.Windows.Forms.ComboBox();
			this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.EmpresaComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.selectEmpresasCASCOBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.vistaReporteValesPrepagadosBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.estatusValesPrepagadosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasCASCOBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// vistaReporteValesPrepagadosBindingSource
			// 
			this.vistaReporteValesPrepagadosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ReporteValesPrepagados);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.IngresosEgresosCajasReportViewer);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(18, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(988, 669);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Reporte de vales prepagados";
			// 
			// IngresosEgresosCajasReportViewer
			// 
			reportDataSource2.Name = "dsReporteVales_ReporteValesPrepagados";
			reportDataSource2.Value = this.vistaReporteValesPrepagadosBindingSource;
			this.IngresosEgresosCajasReportViewer.LocalReport.DataSources.Add(reportDataSource2);
			this.IngresosEgresosCajasReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.callcenter.ReporteValesPrepagados.rdlc";
			this.IngresosEgresosCajasReportViewer.Location = new System.Drawing.Point(14, 213);
			this.IngresosEgresosCajasReportViewer.Name = "IngresosEgresosCajasReportViewer";
			this.IngresosEgresosCajasReportViewer.Size = new System.Drawing.Size(954, 441);
			this.IngresosEgresosCajasReportViewer.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.EmpresaComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.EstatusComboBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.ConsultarButton);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.ClienteComboBox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
			this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(14, 21);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(575, 157);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Parámetros de búsqueda";
			// 
			// EstatusComboBox
			// 
			this.EstatusComboBox.DataSource = this.estatusValesPrepagadosBindingSource;
			this.EstatusComboBox.DisplayMember = "Nombre";
			this.EstatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EstatusComboBox.FormattingEnabled = true;
			this.EstatusComboBox.Location = new System.Drawing.Point(103, 118);
			this.EstatusComboBox.Name = "EstatusComboBox";
			this.EstatusComboBox.Size = new System.Drawing.Size(299, 26);
			this.EstatusComboBox.TabIndex = 8;
			this.EstatusComboBox.ValueMember = "EstatusValePrepagado_ID";
			// 
			// estatusValesPrepagadosBindingSource
			// 
			this.estatusValesPrepagadosBindingSource.DataSource = typeof(SICASv20.Entities.EstatusValesPrepagados);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 18);
			this.label4.TabIndex = 7;
			this.label4.Text = "Estatus:";
			// 
			// ConsultarButton
			// 
			this.ConsultarButton.Location = new System.Drawing.Point(454, 97);
			this.ConsultarButton.Name = "ConsultarButton";
			this.ConsultarButton.Size = new System.Drawing.Size(90, 44);
			this.ConsultarButton.TabIndex = 6;
			this.ConsultarButton.Text = "Consultar";
			this.ConsultarButton.UseVisualStyleBackColor = true;
			this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(218, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "a";
			// 
			// ClienteComboBox
			// 
			this.ClienteComboBox.DataSource = this.selectEmpresasBindingSource;
			this.ClienteComboBox.DisplayMember = "Nombre";
			this.ClienteComboBox.FormattingEnabled = true;
			this.ClienteComboBox.Location = new System.Drawing.Point(103, 89);
			this.ClienteComboBox.Name = "ClienteComboBox";
			this.ClienteComboBox.Size = new System.Drawing.Size(299, 26);
			this.ClienteComboBox.TabIndex = 4;
			this.ClienteComboBox.ValueMember = "Empresa_ID";
			// 
			// selectEmpresasBindingSource
			// 
			this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cliente:";
			// 
			// FechaFinalDateTimePicker
			// 
			this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(240, 27);
			this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
			this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(108, 24);
			this.FechaFinalDateTimePicker.TabIndex = 2;
			// 
			// FechaInicialDateTimePicker
			// 
			this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(103, 27);
			this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
			this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(108, 24);
			this.FechaInicialDateTimePicker.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fechas:";
			// 
			// EmpresaComboBox
			// 
			this.EmpresaComboBox.DataSource = this.selectEmpresasCASCOBindingSource;
			this.EmpresaComboBox.DisplayMember = "Nombre";
			this.EmpresaComboBox.FormattingEnabled = true;
			this.EmpresaComboBox.Location = new System.Drawing.Point(103, 57);
			this.EmpresaComboBox.Name = "EmpresaComboBox";
			this.EmpresaComboBox.Size = new System.Drawing.Size(299, 26);
			this.EmpresaComboBox.TabIndex = 10;
			this.EmpresaComboBox.ValueMember = "Empresa_ID";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 57);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 18);
			this.label5.TabIndex = 9;
			this.label5.Text = "Empresa:";
			// 
			// selectEmpresasCASCOBindingSource
			// 
			this.selectEmpresasCASCOBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
			// 
			// ReporteValesPrepagados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 689);
			this.Controls.Add(this.groupBox1);
			this.Name = "ReporteValesPrepagados";
			this.Text = "ReporteValesPrepagados";
			this.Load += new System.EventHandler(this.ReporteValesPrepagados_Load);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.vistaReporteValesPrepagadosBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.estatusValesPrepagadosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasCASCOBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer IngresosEgresosCajasReportViewer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClienteComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EstatusComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource estatusValesPrepagadosBindingSource;
        private System.Windows.Forms.BindingSource vistaReporteValesPrepagadosBindingSource;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
	   private System.Windows.Forms.ComboBox EmpresaComboBox;
	   private System.Windows.Forms.Label label5;
	   private System.Windows.Forms.BindingSource selectEmpresasCASCOBindingSource;
    }
}