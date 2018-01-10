namespace SICASv20.forms
{
    partial class ReporteIndicadoresUnidades
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.reporteIndicadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_IndicadoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Reporte_IndicadoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIndicadoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReporteIndicadores_DataSet";
            reportDataSource1.Value = this.reporteIndicadoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_IndicadoresMetropolitano.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1024, 680);
            this.reportViewer1.TabIndex = 0;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteIndicadoresBindingSource
            // 
            this.reporteIndicadoresBindingSource.DataMember = "Reporte_Indicadores";
            this.reporteIndicadoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // reporte_IndicadoresTableAdapter
            // 
            this.reporte_IndicadoresTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteIndicadoresUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteIndicadoresUnidades";
            this.Text = "ReporteIndicadoresUnidades";
            this.Load += new System.EventHandler(this.ReporteIndicadoresUnidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIndicadoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteIndicadoresBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralQuerysDataSetTableAdapters.Reporte_IndicadoresTableAdapter reporte_IndicadoresTableAdapter;
    }
}