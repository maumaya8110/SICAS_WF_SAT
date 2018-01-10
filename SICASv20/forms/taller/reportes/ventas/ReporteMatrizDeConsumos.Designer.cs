namespace SICASv20.forms
{
    partial class ReporteMatrizDeConsumos
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
            this.Vista_ConsumosConsolidadosTallerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MatrizConsumosReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ConsumosConsolidadosTallerBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_ConsumosConsolidadosTallerBindingSource
            // 
            this.Vista_ConsumosConsolidadosTallerBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ConsumosConsolidadosTaller);
            // 
            // MatrizConsumosReportViewer
            // 
            reportDataSource1.Name = "Vista_ConsumosConsolidadosTaller_DataSer";
            reportDataSource1.Value = this.Vista_ConsumosConsolidadosTallerBindingSource;
            this.MatrizConsumosReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.MatrizConsumosReportViewer.LocalReport.ReportEmbeddedResource = "SICASv20.reports.taller.Reporte_MatrizDeConsumos.rdlc";
            this.MatrizConsumosReportViewer.Location = new System.Drawing.Point(23, 111);
            this.MatrizConsumosReportViewer.Name = "MatrizConsumosReportViewer";
            this.MatrizConsumosReportViewer.Size = new System.Drawing.Size(937, 500);
            this.MatrizConsumosReportViewer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.MatrizConsumosReportViewer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matriz de Consumos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Location = new System.Drawing.Point(23, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(952, 74);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha Inicial:";
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Checked = false;
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(107, 47);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(114, 21);
            this.FechaFinalDateTimePicker.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fecha final:";
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Checked = false;
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(107, 18);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(114, 21);
            this.FechaInicialDateTimePicker.TabIndex = 13;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(242, 22);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 38);
            this.BuscarButton.TabIndex = 12;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            // 
            // ReporteMatrizDeConsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteMatrizDeConsumos";
            this.Text = "ReporteDeConsumosConsolidados";
            this.Load += new System.EventHandler(this.ReporteDeConsumosConsolidados_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ConsumosConsolidadosTallerBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer MatrizConsumosReportViewer;
        private System.Windows.Forms.BindingSource Vista_ConsumosConsolidadosTallerBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Button BuscarButton;
    }
}