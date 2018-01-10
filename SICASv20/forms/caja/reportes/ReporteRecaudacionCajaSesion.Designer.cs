namespace SICASv20.forms
{
    partial class ReporteRecaudacionCajaSesion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReporteRecaudacionReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.reporteCuentaCajaEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_CuentaCajaEmpresasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_CuentaCajaEmpresasTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteCuentaCajaEmpresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReporteRecaudacionReportViewer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 644);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de recaudación";
            // 
            // ReporteRecaudacionReportViewer
            // 
            reportDataSource1.Name = "ReporteRecaudacionCada_DataSet";
            reportDataSource1.Value = this.reporteCuentaCajaEmpresasBindingSource;
            this.ReporteRecaudacionReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.ReporteRecaudacionReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_RecaudacionCaja.rdlc";
            this.ReporteRecaudacionReportViewer.Location = new System.Drawing.Point(18, 30);
            this.ReporteRecaudacionReportViewer.Name = "ReporteRecaudacionReportViewer";
            this.ReporteRecaudacionReportViewer.Size = new System.Drawing.Size(950, 588);
            this.ReporteRecaudacionReportViewer.TabIndex = 0;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteCuentaCajaEmpresasBindingSource
            // 
            this.reporteCuentaCajaEmpresasBindingSource.DataMember = "Reporte_CuentaCajaEmpresas";
            this.reporteCuentaCajaEmpresasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // reporte_CuentaCajaEmpresasTableAdapter
            // 
            this.reporte_CuentaCajaEmpresasTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteRecaudacionCajaSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteRecaudacionCajaSesion";
            this.Text = "ReporteRecaudacionCajaSesion";            
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteCuentaCajaEmpresasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer ReporteRecaudacionReportViewer;
        private System.Windows.Forms.BindingSource reporteCuentaCajaEmpresasBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_CuentaCajaEmpresasTableAdapter reporte_CuentaCajaEmpresasTableAdapter;
    }
}