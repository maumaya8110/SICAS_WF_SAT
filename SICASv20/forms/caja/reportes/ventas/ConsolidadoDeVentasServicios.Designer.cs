namespace SICASv20.forms
{
    partial class ConsolidadoDeVentasServicios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Vista_DatosDeSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_DatosDeSesionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(897, 508);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consolidado de Ventas de Servicios";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Vista_DatosSesion_DataSet";
            reportDataSource1.Value = this.Vista_DatosDeSesionBindingSource;
            reportDataSource2.Name = "Vista_VentasServicios_DataSet";
            reportDataSource2.Value = this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource;
            reportDataSource3.Name = "Vista_ServiciosConductor_DataSet";
            reportDataSource3.Value = this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource;
            reportDataSource4.Name = "Vista_FlujoMonetario_DataSet";
            reportDataSource4.Value = this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.caja.Reporte_CorteConsolidadoDeVentasServicios.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(21, 32);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(852, 454);
            this.reportViewer1.TabIndex = 0;
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
            // ConsolidadoDeVentasServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 531);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsolidadoDeVentasServicios";
            this.Text = "Consolidado de Ventas de Servicios";
            this.Load += new System.EventHandler(this.ConsolidadoDeVentasServicios_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_DatosDeSesionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Vista_DatosDeSesionBindingSource;
        private System.Windows.Forms.BindingSource Vista_VentasServiciosDeSesion_ConsolidadoBindingSource;
        private System.Windows.Forms.BindingSource Vista_ServiciosConductorDeSesion_ConsolidadoBindingSource;
        private System.Windows.Forms.BindingSource Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource;
    }
}