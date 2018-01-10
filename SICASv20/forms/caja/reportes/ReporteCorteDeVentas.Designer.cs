namespace SICASv20.forms
{
    partial class ReporteCorteDeVentas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Vista_DatosDeSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReporteCorteDeVentasReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CerrarSesionButton = new System.Windows.Forms.Button();
            this.Vista_ComisionesVentaSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_DatosDeSesionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ComisionesVentaSesionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Vista_DatosDeSesionBindingSource
            // 
            this.Vista_DatosDeSesionBindingSource.DataSource = typeof(SICASv20.Entities.Vista_DatosDeSesion);
            // 
            // Vista_VentasServiciosDeSesion_ConsolidadoBindingSource
            // 
            this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource.DataSource = typeof(SICASv20.Entities.Vista_VentasServiciosDeSesion_Consolidado);
            // 
            // Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource
            // 
            this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosConductorDeSesion_Consolidado);
            // 
            // Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource
            // 
            this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource.DataSource = typeof(SICASv20.Entities.Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado);
            // 
            // ReporteCorteDeVentasReportViewer
            // 
            reportDataSource1.Name = "Vista_DatosSesion_DataSet";
            reportDataSource1.Value = this.Vista_DatosDeSesionBindingSource;
            reportDataSource2.Name = "Vista_VentasServicios_DataSet";
            reportDataSource2.Value = this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource;
            reportDataSource3.Name = "Vista_ServiciosConductor_DataSet";
            reportDataSource3.Value = this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource;
            reportDataSource4.Name = "Vista_FlujoMonetario_DataSet";
            reportDataSource4.Value = this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource;
            reportDataSource5.Name = "Comisiones_DataSet";
            reportDataSource5.Value = this.Vista_ComisionesVentaSesionBindingSource;
            this.ReporteCorteDeVentasReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.ReporteCorteDeVentasReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.ReporteCorteDeVentasReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.ReporteCorteDeVentasReportViewer.LocalReport.DataSources.Add(reportDataSource4);
            this.ReporteCorteDeVentasReportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.ReporteCorteDeVentasReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.caja.Reporte_CorteCajaVentasServicios.rdlc";
            this.ReporteCorteDeVentasReportViewer.Location = new System.Drawing.Point(25, 30);
            this.ReporteCorteDeVentasReportViewer.Name = "ReporteCorteDeVentasReportViewer";
            this.ReporteCorteDeVentasReportViewer.ShowToolBar = false;
            this.ReporteCorteDeVentasReportViewer.Size = new System.Drawing.Size(483, 578);
            this.ReporteCorteDeVentasReportViewer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CerrarSesionButton);
            this.groupBox1.Controls.Add(this.ReporteCorteDeVentasReportViewer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Corte de Ventas";
            // 
            // CerrarSesionButton
            // 
            this.CerrarSesionButton.Location = new System.Drawing.Point(548, 42);
            this.CerrarSesionButton.Name = "CerrarSesionButton";
            this.CerrarSesionButton.Size = new System.Drawing.Size(143, 36);
            this.CerrarSesionButton.TabIndex = 2;
            this.CerrarSesionButton.Text = "Cerrar Sesión";
            this.CerrarSesionButton.UseVisualStyleBackColor = true;
            this.CerrarSesionButton.Click += new System.EventHandler(this.CerrarSesionButton_Click);
            // 
            // Vista_ComisionesVentaSesionBindingSource
            // 
            this.Vista_ComisionesVentaSesionBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ComisionesVentaSesion);
            // 
            // ReporteCorteDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteCorteDeVentas";
            this.Text = "ReporteDeCorteDeVentas";
            this.Load += new System.EventHandler(this.ReporteCorteDeVentas_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_DatosDeSesionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ComisionesVentaSesionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReporteCorteDeVentasReportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource Vista_DatosDeSesionBindingSource;
        private System.Windows.Forms.BindingSource Vista_VentasServiciosDeSesion_ConsolidadoBindingSource;
        private System.Windows.Forms.BindingSource Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource;
        private System.Windows.Forms.BindingSource Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource;
        private System.Windows.Forms.Button CerrarSesionButton;
        private System.Windows.Forms.BindingSource Vista_ComisionesVentaSesionBindingSource;
    }
}