namespace SICASv20.forms
{
    partial class ResumenUC
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

        #region Component Designer generated code

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
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrdenTrabajoReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesTrabajosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosRefaccionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(461, 513);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 22;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Image = global::SICASv20.Properties.Resources.save;
            this.AceptarButton.Location = new System.Drawing.Point(554, 513);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(126, 31);
            this.AceptarButton.TabIndex = 21;
            this.AceptarButton.Text = "Registrar orden";
            this.AceptarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AceptarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OrdenTrabajoReportViewer);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 503);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vista previa";
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
            this.OrdenTrabajoReportViewer.Location = new System.Drawing.Point(11, 25);
            this.OrdenTrabajoReportViewer.Name = "OrdenTrabajoReportViewer";
            this.OrdenTrabajoReportViewer.ShowExportButton = false;
            this.OrdenTrabajoReportViewer.ShowPrintButton = false;
            this.OrdenTrabajoReportViewer.Size = new System.Drawing.Size(654, 465);
            this.OrdenTrabajoReportViewer.TabIndex = 0;
            // 
            // ResumenUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.AceptarButton);
            this.Name = "ResumenUC";
            this.Size = new System.Drawing.Size(694, 557);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesTrabajosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesServiciosRefaccionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer OrdenTrabajoReportViewer;
        private System.Windows.Forms.BindingSource OrdenesTrabajosBindingSource;
        private System.Windows.Forms.BindingSource OrdenesServiciosBindingSource;
        private System.Windows.Forms.BindingSource OrdenesServiciosRefaccionesBindingSource;
    }
}
