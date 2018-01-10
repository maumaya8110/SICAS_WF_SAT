namespace SICASv20.forms
{
    partial class ReporteHistorialCobranzaConductor
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
            this.HistorialConductorReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Vista_HistorialCobranzaConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_HistorialCobranzaConductoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HistorialConductorReportViewer
            // 
            reportDataSource1.Name = "Vista_HistorialCobranzaConductores_DataSet";
            reportDataSource1.Value = this.Vista_HistorialCobranzaConductoresBindingSource;
            this.HistorialConductorReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.HistorialConductorReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.conductores.Reporte_HistorialCobranza.rdlc";
            this.HistorialConductorReportViewer.Location = new System.Drawing.Point(24, 35);
            this.HistorialConductorReportViewer.Name = "HistorialConductorReportViewer";
            this.HistorialConductorReportViewer.Size = new System.Drawing.Size(953, 570);
            this.HistorialConductorReportViewer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HistorialConductorReportViewer);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 627);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte Historial Conductor";
            // 
            // Vista_HistorialCobranzaConductoresBindingSource
            // 
            this.Vista_HistorialCobranzaConductoresBindingSource.DataSource = typeof(SICASv20.Entities.Vista_HistorialCobranzaConductores);
            // 
            // ReporteHistorialCobranzaConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteHistorialCobranzaConductor";
            this.Text = "ReporteHistorialCobranzaConductor";            
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_HistorialCobranzaConductoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer HistorialConductorReportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource Vista_HistorialCobranzaConductoresBindingSource;
    }
}