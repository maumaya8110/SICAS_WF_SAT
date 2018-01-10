namespace SICASv20.forms
{
    partial class ReportePublicitarioConsolidado
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
            this.reporteRegistroPublicitarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.Reporte_RegistroPublicitarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.PublicitarioConsolidadoReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_RegistroPublicitarioTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_RegistroPublicitarioTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reporteRegistroPublicitarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_RegistroPublicitarioBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteRegistroPublicitarioBindingSource
            // 
            this.reporteRegistroPublicitarioBindingSource.DataMember = "Reporte_RegistroPublicitario";
            this.reporteRegistroPublicitarioBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte_RegistroPublicitarioBindingSource
            // 
            this.Reporte_RegistroPublicitarioBindingSource.DataMember = "Reporte_RegistroPublicitario";
            this.Reporte_RegistroPublicitarioBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Estacion_IDComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ConsultarButton);
            this.groupBox1.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(587, 25);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(113, 33);
            this.ConsultarButton.TabIndex = 4;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(105, 55);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(131, 21);
            this.FechaFinalDateTimePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha final:";
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(105, 28);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(131, 21);
            this.FechaInicialDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial:";
            // 
            // PublicitarioConsolidadoReportViewer
            // 
            reportDataSource2.Name = "Publicitario_Consolidado_DataSet";
            reportDataSource2.Value = this.reporteRegistroPublicitarioBindingSource;
            this.PublicitarioConsolidadoReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.PublicitarioConsolidadoReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_Publicitario_Consolidado.rdlc";
            this.PublicitarioConsolidadoReportViewer.Location = new System.Drawing.Point(18, 126);
            this.PublicitarioConsolidadoReportViewer.Name = "PublicitarioConsolidadoReportViewer";
            this.PublicitarioConsolidadoReportViewer.Size = new System.Drawing.Size(951, 506);
            this.PublicitarioConsolidadoReportViewer.TabIndex = 2;
            // 
            // reporte_RegistroPublicitarioTableAdapter
            // 
            this.reporte_RegistroPublicitarioTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.PublicitarioConsolidadoReportViewer);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(987, 655);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte publicitario consolidado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estación:";
            // 
            // Estacion_IDComboBox
            // 
            this.Estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.Estacion_IDComboBox.DisplayMember = "Nombre";
            this.Estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estacion_IDComboBox.FormattingEnabled = true;
            this.Estacion_IDComboBox.Location = new System.Drawing.Point(333, 26);
            this.Estacion_IDComboBox.Name = "Estacion_IDComboBox";
            this.Estacion_IDComboBox.Size = new System.Drawing.Size(221, 23);
            this.Estacion_IDComboBox.TabIndex = 6;
            this.Estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // ReportePublicitarioConsolidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox2);
            this.Name = "ReportePublicitarioConsolidado";
            this.Text = "ReportePublicitarioConsolidado";            
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.reporteRegistroPublicitarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_RegistroPublicitarioBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer PublicitarioConsolidadoReportViewer;
        private System.Windows.Forms.BindingSource reporteRegistroPublicitarioBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_RegistroPublicitarioTableAdapter reporte_RegistroPublicitarioTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_RegistroPublicitarioBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox Estacion_IDComboBox;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.Label label3;
    }
}