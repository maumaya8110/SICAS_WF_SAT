﻿namespace SICASv20.forms
{
    partial class ComprasConsolidado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.vista_ComprasConsolidadasDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ComprasConsolidadasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExportarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasConsolidadasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasConsolidadasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.vista_ComprasConsolidadasDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de compras consolidado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportarButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Location = new System.Drawing.Point(18, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(952, 74);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(333, 20);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(75, 42);
            this.ExportarButton.TabIndex = 23;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
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
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // vista_ComprasConsolidadasDataGridView
            // 
            this.vista_ComprasConsolidadasDataGridView.AllowUserToAddRows = false;
            this.vista_ComprasConsolidadasDataGridView.AllowUserToDeleteRows = false;
            this.vista_ComprasConsolidadasDataGridView.AutoGenerateColumns = false;
            this.vista_ComprasConsolidadasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ComprasConsolidadasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.vista_ComprasConsolidadasDataGridView.DataSource = this.vista_ComprasConsolidadasBindingSource;
            this.vista_ComprasConsolidadasDataGridView.Location = new System.Drawing.Point(18, 106);
            this.vista_ComprasConsolidadasDataGridView.Name = "vista_ComprasConsolidadasDataGridView";
            this.vista_ComprasConsolidadasDataGridView.ReadOnly = true;
            this.vista_ComprasConsolidadasDataGridView.Size = new System.Drawing.Size(952, 510);
            this.vista_ComprasConsolidadasDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Proveedor";
            this.dataGridViewTextBoxColumn2.HeaderText = "Proveedor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Subtotal";
            this.dataGridViewTextBoxColumn4.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IVA";
            this.dataGridViewTextBoxColumn5.HeaderText = "IVA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Total";
            this.dataGridViewTextBoxColumn6.HeaderText = "Total";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // vista_ComprasConsolidadasBindingSource
            // 
            this.vista_ComprasConsolidadasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ComprasConsolidadas);
            // 
            // ComprasConsolidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComprasConsolidado";
            this.Text = "ComprasConsolidado";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasConsolidadasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasConsolidadasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_ComprasConsolidadasDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource vista_ComprasConsolidadasBindingSource;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.SaveFileDialog ExportarSaveFileDialog;
    }
}