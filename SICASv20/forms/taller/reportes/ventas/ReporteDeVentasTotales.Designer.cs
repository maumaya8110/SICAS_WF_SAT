namespace SICASv20.forms
{
    partial class ReporteDeVentasTotales
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Vista_ReporteVentasTallerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VentasTotalesReporteViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaTerminacionInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaTerminacionFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ReporteVentasTallerBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_ReporteVentasTallerBindingSource
            // 
            this.Vista_ReporteVentasTallerBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ReporteVentasTaller);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VentasTotalesReporteViewer);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Ventas Totales";
            // 
            // VentasTotalesReporteViewer
            // 
            reportDataSource4.Name = "ReporteVentasTaller_DataSet";
            reportDataSource4.Value = this.Vista_ReporteVentasTallerBindingSource;
            this.VentasTotalesReporteViewer.LocalReport.DataSources.Add(reportDataSource4);
            this.VentasTotalesReporteViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.taller.Reporte_VentasTaller.rdlc";
            this.VentasTotalesReporteViewer.Location = new System.Drawing.Point(19, 138);
            this.VentasTotalesReporteViewer.Name = "VentasTotalesReporteViewer";
            this.VentasTotalesReporteViewer.Size = new System.Drawing.Size(948, 473);
            this.VentasTotalesReporteViewer.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FechaTerminacionInicialDateTimePicker);
            this.groupBox2.Controls.Add(this.ConsultarButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.FechaTerminacionFinalDateTimePicker);
            this.groupBox2.Location = new System.Drawing.Point(19, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros de busqueda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fecha Terminación Final:";
            // 
            // FechaTerminacionInicialDateTimePicker
            // 
            this.FechaTerminacionInicialDateTimePicker.Checked = false;
            this.FechaTerminacionInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionInicialDateTimePicker.Location = new System.Drawing.Point(197, 33);
            this.FechaTerminacionInicialDateTimePicker.Name = "FechaTerminacionInicialDateTimePicker";
            this.FechaTerminacionInicialDateTimePicker.Size = new System.Drawing.Size(129, 21);
            this.FechaTerminacionInicialDateTimePicker.TabIndex = 34;
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(349, 33);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 42);
            this.ConsultarButton.TabIndex = 38;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Fecha Terminación Inicial:";
            // 
            // FechaTerminacionFinalDateTimePicker
            // 
            this.FechaTerminacionFinalDateTimePicker.Checked = false;
            this.FechaTerminacionFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionFinalDateTimePicker.Location = new System.Drawing.Point(197, 60);
            this.FechaTerminacionFinalDateTimePicker.Name = "FechaTerminacionFinalDateTimePicker";
            this.FechaTerminacionFinalDateTimePicker.Size = new System.Drawing.Size(129, 21);
            this.FechaTerminacionFinalDateTimePicker.TabIndex = 35;
            // 
            // ReporteDeVentasTotales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteDeVentasTotales";
            this.Text = "ReporteDeVentasTotales";
            this.Load += new System.EventHandler(this.ReporteDeVentasTotales_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ReporteVentasTallerBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer VentasTotalesReporteViewer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaTerminacionInicialDateTimePicker;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FechaTerminacionFinalDateTimePicker;
        private System.Windows.Forms.BindingSource Vista_ReporteVentasTallerBindingSource;
    }
}