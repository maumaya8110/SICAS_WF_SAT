namespace SICASv20.forms
{
    partial class IngresosEgresosCajasPorFechas
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.SaldosCuentaCajasPorFechasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.IngresosEgresosCajasReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ConsultarButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.CajasComboBox = new System.Windows.Forms.ComboBox();
			this.selectCajasActivasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.SaldosCuentaCajasPorFechasBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectCajasActivasBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// SaldosCuentaCajasPorFechasBindingSource
			// 
			this.SaldosCuentaCajasPorFechasBindingSource.DataSource = typeof(SICASv20.Entities.SaldosCuentaCajasPorFechas);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.IngresosEgresosCajasReportViewer);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(988, 637);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Reporte de ingresos y egresos de caja";
			// 
			// IngresosEgresosCajasReportViewer
			// 
			reportDataSource1.Name = "SaldosCajasPorFechas_DataSet";
			reportDataSource1.Value = this.SaldosCuentaCajasPorFechasBindingSource;
			this.IngresosEgresosCajasReportViewer.LocalReport.DataSources.Add(reportDataSource1);
			this.IngresosEgresosCajasReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.empresas.Reporte_IngresosEgresosCajas.rdlc";
			this.IngresosEgresosCajasReportViewer.Location = new System.Drawing.Point(14, 142);
			this.IngresosEgresosCajasReportViewer.Name = "IngresosEgresosCajasReportViewer";
			this.IngresosEgresosCajasReportViewer.Size = new System.Drawing.Size(954, 468);
			this.IngresosEgresosCajasReportViewer.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ConsultarButton);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.CajasComboBox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
			this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(14, 21);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(575, 100);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Parámetros de búsqueda";
			// 
			// ConsultarButton
			// 
			this.ConsultarButton.Location = new System.Drawing.Point(446, 56);
			this.ConsultarButton.Name = "ConsultarButton";
			this.ConsultarButton.Size = new System.Drawing.Size(90, 23);
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
			// CajasComboBox
			// 
			this.CajasComboBox.DataSource = this.selectCajasActivasBindingSource;
			this.CajasComboBox.DisplayMember = "Descripcion";
			this.CajasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CajasComboBox.FormattingEnabled = true;
			this.CajasComboBox.Location = new System.Drawing.Point(103, 56);
			this.CajasComboBox.Name = "CajasComboBox";
			this.CajasComboBox.Size = new System.Drawing.Size(299, 26);
			this.CajasComboBox.TabIndex = 4;
			this.CajasComboBox.ValueMember = "Caja_ID";
			// 
			// selectCajasActivasBindingSource
			// 
			this.selectCajasActivasBindingSource.DataSource = typeof(SICASv20.Entities.SelectCajasActivas);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Caja:";
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
			// IngresosEgresosCajasPorFechas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "IngresosEgresosCajasPorFechas";
			this.Text = "IngresosEgresosCajasPorFechas";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.SaldosCuentaCajasPorFechasBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectCajasActivasBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer IngresosEgresosCajasReportViewer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource SaldosCuentaCajasPorFechasBindingSource;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CajasComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource selectCajasActivasBindingSource;
    }
}