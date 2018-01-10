namespace SICASv20.forms
{
    partial class ReporteOrdenTrabajo
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OrdenesTrabajosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenesServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenesServiciosRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenTrabajoReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ImprimirButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesTrabajosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosRefaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdenesTrabajosBindingSource
            // 
            this.OrdenesTrabajosBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesTrabajos);
            // 
            // OrdenesServiciosBindingSource
            // 
            this.OrdenesServiciosBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesServicios);
            // 
            // OrdenesServiciosRefaccionesBindingSource
            // 
            this.OrdenesServiciosRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesServiciosRefacciones);
            // 
            // OrdenTrabajoReportViewer
            // 
            reportDataSource1.Name = "OrdenTrabajo_DataSet";
            reportDataSource1.Value = this.OrdenesTrabajosBindingSource;
            reportDataSource2.Name = "OrdenesServicios_DataSet";
            reportDataSource2.Value = this.OrdenesServiciosBindingSource;
            reportDataSource3.Name = "OrdenesServiciosRefacciones_DataSet";
            reportDataSource3.Value = this.OrdenesServiciosRefaccionesBindingSource;
            this.OrdenTrabajoReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.OrdenTrabajoReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.OrdenTrabajoReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.OrdenTrabajoReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.taller.Reporte_OrdenTrabajo.rdlc";
            this.OrdenTrabajoReportViewer.Location = new System.Drawing.Point(0, 25);
            this.OrdenTrabajoReportViewer.Name = "OrdenTrabajoReportViewer";
            this.OrdenTrabajoReportViewer.ShowToolBar = false;
            this.OrdenTrabajoReportViewer.Size = new System.Drawing.Size(1006, 687);
            this.OrdenTrabajoReportViewer.TabIndex = 0;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Location = new System.Drawing.Point(3, 0);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(75, 23);
            this.ImprimirButton.TabIndex = 1;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.UseVisualStyleBackColor = true;
            // 
            // ReporteOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 712);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.OrdenTrabajoReportViewer);
            this.Name = "ReporteOrdenTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Orden de Trabajo";
            this.Load += new System.EventHandler(this.ReporteOrdenTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesTrabajosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosRefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer OrdenTrabajoReportViewer;
        private System.Windows.Forms.BindingSource OrdenesTrabajosBindingSource;
        private System.Windows.Forms.BindingSource OrdenesServiciosBindingSource;
        private System.Windows.Forms.BindingSource OrdenesServiciosRefaccionesBindingSource;
        private System.Windows.Forms.Button ImprimirButton;
    }
}