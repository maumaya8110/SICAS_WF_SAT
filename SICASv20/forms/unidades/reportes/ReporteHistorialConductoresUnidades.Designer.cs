namespace SICASv20.forms
{
    partial class ReporteHistorialUnidadesConductores
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.vista_HistorialConductoresUnidadesDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vista_HistorialConductoresUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ParametrosTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
			this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
			this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.BuscarButton = new System.Windows.Forms.Button();
			this.ExportarButton = new System.Windows.Forms.Button();
			this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.MainTablePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vista_HistorialConductoresUnidadesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_HistorialConductoresUnidadesBindingSource)).BeginInit();
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
			this.groupBox1.Text = "Reporte de Historial de Conductores y Unidades";
			// 
			// MainTablePanel
			// 
			this.MainTablePanel.ColumnCount = 1;
			this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainTablePanel.Controls.Add(this.vista_HistorialConductoresUnidadesDataGridView, 0, 1);
			this.MainTablePanel.Controls.Add(this.groupBox2, 0, 0);
			this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTablePanel.Location = new System.Drawing.Point(3, 20);
			this.MainTablePanel.Margin = new System.Windows.Forms.Padding(10);
			this.MainTablePanel.Name = "MainTablePanel";
			this.MainTablePanel.Padding = new System.Windows.Forms.Padding(10);
			this.MainTablePanel.RowCount = 2;
			this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
			this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.95238F));
			this.MainTablePanel.Size = new System.Drawing.Size(982, 605);
			this.MainTablePanel.TabIndex = 0;
			// 
			// vista_HistorialConductoresUnidadesDataGridView
			// 
			this.vista_HistorialConductoresUnidadesDataGridView.AllowUserToAddRows = false;
			this.vista_HistorialConductoresUnidadesDataGridView.AllowUserToDeleteRows = false;
			this.vista_HistorialConductoresUnidadesDataGridView.AutoGenerateColumns = false;
			this.vista_HistorialConductoresUnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vista_HistorialConductoresUnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
			this.vista_HistorialConductoresUnidadesDataGridView.DataSource = this.vista_HistorialConductoresUnidadesBindingSource;
			this.vista_HistorialConductoresUnidadesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vista_HistorialConductoresUnidadesDataGridView.Location = new System.Drawing.Point(20, 131);
			this.vista_HistorialConductoresUnidadesDataGridView.Margin = new System.Windows.Forms.Padding(10);
			this.vista_HistorialConductoresUnidadesDataGridView.Name = "vista_HistorialConductoresUnidadesDataGridView";
			this.vista_HistorialConductoresUnidadesDataGridView.ReadOnly = true;
			this.vista_HistorialConductoresUnidadesDataGridView.Size = new System.Drawing.Size(942, 454);
			this.vista_HistorialConductoresUnidadesDataGridView.TabIndex = 1;
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
			this.dataGridViewTextBoxColumn3.HeaderText = "Unidad";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Conductor";
			this.dataGridViewTextBoxColumn4.HeaderText = "Conductor";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "FechaInicial";
			dataGridViewCellStyle2.Format = "d";
			dataGridViewCellStyle2.NullValue = null;
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn5.HeaderText = "FechaInicial";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "FechaFinal";
			dataGridViewCellStyle3.Format = "d";
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn6.HeaderText = "FechaFinal";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			// 
			// vista_HistorialConductoresUnidadesBindingSource
			// 
			this.vista_HistorialConductoresUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_HistorialConductoresUnidades);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ParametrosTablePanel);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(13, 13);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(956, 105);
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
			this.ParametrosTablePanel.Controls.Add(this.BuscarButton, 4, 0);
			this.ParametrosTablePanel.Controls.Add(this.ExportarButton, 4, 1);
			this.ParametrosTablePanel.Controls.Add(this.NumeroEconomicoTextBox, 3, 0);
			this.ParametrosTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParametrosTablePanel.Location = new System.Drawing.Point(3, 20);
			this.ParametrosTablePanel.Margin = new System.Windows.Forms.Padding(10);
			this.ParametrosTablePanel.Name = "ParametrosTablePanel";
			this.ParametrosTablePanel.Padding = new System.Windows.Forms.Padding(10);
			this.ParametrosTablePanel.RowCount = 2;
			this.ParametrosTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ParametrosTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ParametrosTablePanel.Size = new System.Drawing.Size(950, 82);
			this.ParametrosTablePanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 16);
			this.label1.Margin = new System.Windows.Forms.Padding(5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Empresa";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 47);
			this.label2.Margin = new System.Windows.Forms.Padding(5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 18);
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
			this.EmpresasComboBox.Location = new System.Drawing.Point(101, 15);
			this.EmpresasComboBox.Margin = new System.Windows.Forms.Padding(5);
			this.EmpresasComboBox.Name = "EmpresasComboBox";
			this.EmpresasComboBox.Size = new System.Drawing.Size(177, 26);
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
			this.EstacionesComboBox.Location = new System.Drawing.Point(101, 46);
			this.EstacionesComboBox.Margin = new System.Windows.Forms.Padding(5);
			this.EstacionesComboBox.Name = "EstacionesComboBox";
			this.EstacionesComboBox.Size = new System.Drawing.Size(177, 26);
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
			this.label3.Location = new System.Drawing.Point(307, 16);
			this.label3.Margin = new System.Windows.Forms.Padding(5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Unidad";
			// 
			// BuscarButton
			// 
			this.BuscarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.BuscarButton.Location = new System.Drawing.Point(535, 15);
			this.BuscarButton.Margin = new System.Windows.Forms.Padding(5);
			this.BuscarButton.Name = "BuscarButton";
			this.BuscarButton.Size = new System.Drawing.Size(98, 21);
			this.BuscarButton.TabIndex = 10;
			this.BuscarButton.Text = "Buscar";
			this.BuscarButton.UseVisualStyleBackColor = true;
			this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
			// 
			// ExportarButton
			// 
			this.ExportarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ExportarButton.Location = new System.Drawing.Point(535, 46);
			this.ExportarButton.Margin = new System.Windows.Forms.Padding(5);
			this.ExportarButton.Name = "ExportarButton";
			this.ExportarButton.Size = new System.Drawing.Size(98, 21);
			this.ExportarButton.TabIndex = 11;
			this.ExportarButton.Text = "Exportar";
			this.ExportarButton.UseVisualStyleBackColor = true;
			this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
			// 
			// NumeroEconomicoTextBox
			// 
			this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(400, 13);
			this.NumeroEconomicoTextBox.MaxLength = 4;
			this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
			this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(100, 24);
			this.NumeroEconomicoTextBox.TabIndex = 12;
			this.NumeroEconomicoTextBox.TextChanged += new System.EventHandler(this.NumeroEconomicoTextBox_TextChanged);
			// 
			// ReporteHistorialUnidadesConductores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "ReporteHistorialUnidadesConductores";
			this.Text = "ReporteKilometrajesPromedio";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.MainTablePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vista_HistorialConductoresUnidadesDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_HistorialConductoresUnidadesBindingSource)).EndInit();
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
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.DataGridView vista_HistorialConductoresUnidadesDataGridView;
        private System.Windows.Forms.BindingSource vista_HistorialConductoresUnidadesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}