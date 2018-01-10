namespace SICASv20.forms
{
    partial class ReporteServiciosPagadosPorModelo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelRentasButton = new System.Windows.Forms.Button();
            this.vista_RentasPagadasPorModeloDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_RentasPagadasPorModeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExportarButton = new System.Windows.Forms.Button();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.vista_ServiciosPagadosPorModeloDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ServiciosPagadosPorModeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RentasPagadasPorModeloDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RentasPagadasPorModeloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosPagadosPorModeloDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosPagadosPorModeloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExcelRentasButton);
            this.groupBox1.Controls.Add(this.vista_RentasPagadasPorModeloDataGridView);
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vista_ServiciosPagadosPorModeloDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Servicios Pagados Por Modelo";
            // 
            // ExcelRentasButton
            // 
            this.ExcelRentasButton.Location = new System.Drawing.Point(830, 71);
            this.ExcelRentasButton.Name = "ExcelRentasButton";
            this.ExcelRentasButton.Size = new System.Drawing.Size(142, 31);
            this.ExcelRentasButton.TabIndex = 8;
            this.ExcelRentasButton.Text = "Exportar a MS Excel";
            this.ExcelRentasButton.UseVisualStyleBackColor = true;
            this.ExcelRentasButton.Click += new System.EventHandler(this.ExcelRentasButton_Click);
            // 
            // vista_RentasPagadasPorModeloDataGridView
            // 
            this.vista_RentasPagadasPorModeloDataGridView.AllowUserToAddRows = false;
            this.vista_RentasPagadasPorModeloDataGridView.AllowUserToDeleteRows = false;
            this.vista_RentasPagadasPorModeloDataGridView.AutoGenerateColumns = false;
            this.vista_RentasPagadasPorModeloDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_RentasPagadasPorModeloDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.vista_RentasPagadasPorModeloDataGridView.DataSource = this.vista_RentasPagadasPorModeloBindingSource;
            this.vista_RentasPagadasPorModeloDataGridView.Location = new System.Drawing.Point(517, 108);
            this.vista_RentasPagadasPorModeloDataGridView.Name = "vista_RentasPagadasPorModeloDataGridView";
            this.vista_RentasPagadasPorModeloDataGridView.ReadOnly = true;
            this.vista_RentasPagadasPorModeloDataGridView.Size = new System.Drawing.Size(455, 487);
            this.vista_RentasPagadasPorModeloDataGridView.TabIndex = 7;
            // 
            // vista_RentasPagadasPorModeloBindingSource
            // 
            this.vista_RentasPagadasPorModeloBindingSource.DataSource = typeof(SICASv20.Entities.Vista_RentasPagadasPorModelo);
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(360, 71);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(142, 31);
            this.ExportarButton.TabIndex = 6;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(116, 62);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(126, 21);
            this.FechaFinalDateTimePicker.TabIndex = 5;
            this.FechaFinalDateTimePicker.ValueChanged += new System.EventHandler(this.FechaFinalDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha final:";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(360, 31);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(142, 31);
            this.AceptarButton.TabIndex = 3;
            this.AceptarButton.Text = "Consultar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(116, 31);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(126, 21);
            this.FechaInicialDateTimePicker.TabIndex = 2;
            this.FechaInicialDateTimePicker.ValueChanged += new System.EventHandler(this.FechaInicialDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha inicial:";
            // 
            // vista_ServiciosPagadosPorModeloDataGridView
            // 
            this.vista_ServiciosPagadosPorModeloDataGridView.AllowUserToAddRows = false;
            this.vista_ServiciosPagadosPorModeloDataGridView.AllowUserToDeleteRows = false;
            this.vista_ServiciosPagadosPorModeloDataGridView.AutoGenerateColumns = false;
            this.vista_ServiciosPagadosPorModeloDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ServiciosPagadosPorModeloDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.vista_ServiciosPagadosPorModeloDataGridView.DataSource = this.vista_ServiciosPagadosPorModeloBindingSource;
            this.vista_ServiciosPagadosPorModeloDataGridView.Location = new System.Drawing.Point(16, 108);
            this.vista_ServiciosPagadosPorModeloDataGridView.Name = "vista_ServiciosPagadosPorModeloDataGridView";
            this.vista_ServiciosPagadosPorModeloDataGridView.ReadOnly = true;
            this.vista_ServiciosPagadosPorModeloDataGridView.Size = new System.Drawing.Size(486, 487);
            this.vista_ServiciosPagadosPorModeloDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Modelo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Modelo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Servicios";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Servicios";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Total";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalDC";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "TotalDC";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // vista_ServiciosPagadosPorModeloBindingSource
            // 
            this.vista_ServiciosPagadosPorModeloBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosPagadosPorModelo);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Rentas";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "Rentas";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // ReporteServiciosPagadosPorModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteServiciosPagadosPorModelo";
            this.Text = "ReporteServiciosPagadosPorModelo";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RentasPagadasPorModeloDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RentasPagadasPorModeloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosPagadosPorModeloDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosPagadosPorModeloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_ServiciosPagadosPorModeloDataGridView;
        private System.Windows.Forms.BindingSource vista_ServiciosPagadosPorModeloBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExcelRentasButton;
        private System.Windows.Forms.DataGridView vista_RentasPagadasPorModeloDataGridView;
        private System.Windows.Forms.BindingSource vista_RentasPagadasPorModeloBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}