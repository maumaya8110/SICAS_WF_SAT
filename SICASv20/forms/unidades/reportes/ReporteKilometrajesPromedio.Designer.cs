namespace SICASv20.forms
{
    partial class ReporteKilometrajesPromedio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.vista_KilometrajesPromedioDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_KilometrajesPromedioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ParametrosTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaInicialDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaFinalDatePicker = new System.Windows.Forms.DateTimePicker();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.MainTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_KilometrajesPromedioDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_KilometrajesPromedioBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.ParametrosTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MainTablePanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Kilometrajes Promedio";
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 1;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.Controls.Add(this.vista_KilometrajesPromedioDataGridView, 0, 1);
            this.MainTablePanel.Controls.Add(this.groupBox2, 0, 0);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(3, 17);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(10);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainTablePanel.RowCount = 2;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.95238F));
            this.MainTablePanel.Size = new System.Drawing.Size(982, 608);
            this.MainTablePanel.TabIndex = 0;
            // 
            // vista_KilometrajesPromedioDataGridView
            // 
            this.vista_KilometrajesPromedioDataGridView.AllowUserToAddRows = false;
            this.vista_KilometrajesPromedioDataGridView.AllowUserToDeleteRows = false;
            this.vista_KilometrajesPromedioDataGridView.AutoGenerateColumns = false;
            this.vista_KilometrajesPromedioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_KilometrajesPromedioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.vista_KilometrajesPromedioDataGridView.DataSource = this.vista_KilometrajesPromedioBindingSource;
            this.vista_KilometrajesPromedioDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vista_KilometrajesPromedioDataGridView.Location = new System.Drawing.Point(20, 132);
            this.vista_KilometrajesPromedioDataGridView.Margin = new System.Windows.Forms.Padding(10);
            this.vista_KilometrajesPromedioDataGridView.Name = "vista_KilometrajesPromedioDataGridView";
            this.vista_KilometrajesPromedioDataGridView.ReadOnly = true;
            this.vista_KilometrajesPromedioDataGridView.Size = new System.Drawing.Size(942, 456);
            this.vista_KilometrajesPromedioDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Empresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Estacion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Estacion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NumeroEconomico";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "NumeroEconomico";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "KmInicial";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "KmInicial";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "KmFinal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "KmFinal";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PromedioDiario";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "PromedioDiario";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // vista_KilometrajesPromedioBindingSource
            // 
            this.vista_KilometrajesPromedioBindingSource.DataSource = typeof(SICASv20.Entities.Vista_KilometrajesPromedio);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ParametrosTablePanel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 106);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros de busqueda";
            // 
            // ParametrosTablePanel
            // 
            this.ParametrosTablePanel.ColumnCount = 5;
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.354838F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.25806F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.32258F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.4086F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.97849F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ParametrosTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ParametrosTablePanel.Controls.Add(this.label1, 0, 0);
            this.ParametrosTablePanel.Controls.Add(this.label2, 0, 1);
            this.ParametrosTablePanel.Controls.Add(this.EmpresasComboBox, 1, 0);
            this.ParametrosTablePanel.Controls.Add(this.EstacionesComboBox, 1, 1);
            this.ParametrosTablePanel.Controls.Add(this.label3, 2, 0);
            this.ParametrosTablePanel.Controls.Add(this.label4, 2, 1);
            this.ParametrosTablePanel.Controls.Add(this.FechaInicialDatePicker, 3, 0);
            this.ParametrosTablePanel.Controls.Add(this.FechaFinalDatePicker, 3, 1);
            this.ParametrosTablePanel.Controls.Add(this.BuscarButton, 4, 0);
            this.ParametrosTablePanel.Controls.Add(this.ExportarButton, 4, 1);
            this.ParametrosTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametrosTablePanel.Location = new System.Drawing.Point(3, 17);
            this.ParametrosTablePanel.Margin = new System.Windows.Forms.Padding(10);
            this.ParametrosTablePanel.Name = "ParametrosTablePanel";
            this.ParametrosTablePanel.Padding = new System.Windows.Forms.Padding(10);
            this.ParametrosTablePanel.RowCount = 2;
            this.ParametrosTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametrosTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametrosTablePanel.Size = new System.Drawing.Size(950, 86);
            this.ParametrosTablePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estación";
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmpresasComboBox.DataSource = this.selectEmpresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(101, 16);
            this.EmpresasComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(177, 23);
            this.EmpresasComboBox.TabIndex = 2;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            this.EmpresasComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresasComboBox_SelectionChangeCommitted);
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EstacionesComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(101, 48);
            this.EstacionesComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(177, 23);
            this.EstacionesComboBox.TabIndex = 3;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            this.EstacionesComboBox.SelectionChangeCommitted += new System.EventHandler(this.EstacionesComboBox_SelectionChangeCommitted);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Inicial";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Final";
            // 
            // FechaInicialDatePicker
            // 
            this.FechaInicialDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaInicialDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDatePicker.Location = new System.Drawing.Point(402, 16);
            this.FechaInicialDatePicker.Margin = new System.Windows.Forms.Padding(5);
            this.FechaInicialDatePicker.Name = "FechaInicialDatePicker";
            this.FechaInicialDatePicker.Size = new System.Drawing.Size(109, 21);
            this.FechaInicialDatePicker.TabIndex = 6;
            this.FechaInicialDatePicker.ValueChanged += new System.EventHandler(this.FechaInicialDatePicker_ValueChanged);
            // 
            // FechaFinalDatePicker
            // 
            this.FechaFinalDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaFinalDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDatePicker.Location = new System.Drawing.Point(402, 49);
            this.FechaFinalDatePicker.Margin = new System.Windows.Forms.Padding(5);
            this.FechaFinalDatePicker.Name = "FechaFinalDatePicker";
            this.FechaFinalDatePicker.Size = new System.Drawing.Size(109, 21);
            this.FechaFinalDatePicker.TabIndex = 7;
            this.FechaFinalDatePicker.ValueChanged += new System.EventHandler(this.FechaFinalDatePicker_ValueChanged);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BuscarButton.Location = new System.Drawing.Point(535, 15);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(5);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(98, 22);
            this.BuscarButton.TabIndex = 10;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // ExportarButton
            // 
            this.ExportarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ExportarButton.Location = new System.Drawing.Point(535, 48);
            this.ExportarButton.Margin = new System.Windows.Forms.Padding(5);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(98, 23);
            this.ExportarButton.TabIndex = 11;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // ReporteKilometrajesPromedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteKilometrajesPromedio";
            this.Text = "ReporteKilometrajesPromedio";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.MainTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vista_KilometrajesPromedioDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_KilometrajesPromedioBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ParametrosTablePanel.ResumeLayout(false);
            this.ParametrosTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel ParametrosTablePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FechaInicialDatePicker;
        private System.Windows.Forms.DateTimePicker FechaFinalDatePicker;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.DataGridView vista_KilometrajesPromedioDataGridView;
        private System.Windows.Forms.BindingSource vista_KilometrajesPromedioBindingSource;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}