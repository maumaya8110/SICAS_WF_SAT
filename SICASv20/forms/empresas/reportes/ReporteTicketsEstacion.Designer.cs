﻿namespace SICASv20.forms
{
    partial class ReporteTicketsEstacion
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vista_TicketsDeSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TicketsDeSesionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 656);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Tickets de Estación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConsultarButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.EstacionesComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(15, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros de búsqueda";
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(408, 55);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(90, 24);
            this.ConsultarButton.TabIndex = 6;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "a";
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(103, 56);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(299, 23);
            this.EstacionesComboBox.TabIndex = 4;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estación";
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(240, 27);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(108, 21);
            this.FechaFinalDateTimePicker.TabIndex = 2;
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(103, 27);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(108, 21);
            this.FechaInicialDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fechas:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ReporteTickets_DataSet";
            reportDataSource1.Value = this.vista_TicketsDeSesionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.Reporte_Tickets.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 126);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(947, 505);
            this.reportViewer1.TabIndex = 0;
            // 
            // vista_TicketsDeSesionBindingSource
            // 
            this.vista_TicketsDeSesionBindingSource.DataSource = typeof(SICASv20.Entities.Vista_TicketsDeSesion);
            // 
            // ReporteTicketsEstacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteTicketsEstacion";
            this.Text = "ReporteTicketsEstacion";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TicketsDeSesionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vista_TicketsDeSesionBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
    }
}