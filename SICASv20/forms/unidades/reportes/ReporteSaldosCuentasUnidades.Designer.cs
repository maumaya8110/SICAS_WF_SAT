namespace SICASv20.forms
{
    partial class ReporteSaldosCuentasUnidades
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
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vista_SaldosTotalesUnidadesDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_SaldosTotalesUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            estacion_IDLabel = new System.Windows.Forms.Label();
            empresa_IDLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosTotalesUnidadesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosTotalesUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(14, 106);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 51;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(14, 77);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 49;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 26);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(391, 30);
            label3.TabIndex = 55;
            label3.Text = "Para consultar por empresa y estación, haga clic en \"Consultar Todos\".\r\nPara cons" +
    "ultar por unidad, teclee la unidad y haga \"Enter\".";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(443, 26);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(396, 30);
            label4.TabIndex = 56;
            label4.Text = "Para exportar, primero consulte la información, y cuando se muestre en\r\nla tabla," +
    " haga clic en \"Exportar a MS Excel\".";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(this.vista_SaldosTotalesUnidadesDataGridView);
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.ConsultarButton);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.empresa_IDComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.estacion_IDComboBox);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 607);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Saldos Totales de Unidades";
            // 
            // vista_SaldosTotalesUnidadesDataGridView
            // 
            this.vista_SaldosTotalesUnidadesDataGridView.AllowUserToAddRows = false;
            this.vista_SaldosTotalesUnidadesDataGridView.AllowUserToDeleteRows = false;
            this.vista_SaldosTotalesUnidadesDataGridView.AutoGenerateColumns = false;
            this.vista_SaldosTotalesUnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_SaldosTotalesUnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.Ingreso,
            this.Gasto,
            this.dataGridViewTextBoxColumn5});
            this.vista_SaldosTotalesUnidadesDataGridView.DataSource = this.vista_SaldosTotalesUnidadesBindingSource;
            this.vista_SaldosTotalesUnidadesDataGridView.Location = new System.Drawing.Point(19, 132);
            this.vista_SaldosTotalesUnidadesDataGridView.Name = "vista_SaldosTotalesUnidadesDataGridView";
            this.vista_SaldosTotalesUnidadesDataGridView.ReadOnly = true;
            this.vista_SaldosTotalesUnidadesDataGridView.Size = new System.Drawing.Size(941, 457);
            this.vista_SaldosTotalesUnidadesDataGridView.TabIndex = 54;
            // 
            // vista_SaldosTotalesUnidadesBindingSource
            // 
            this.vista_SaldosTotalesUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_SaldosTotalesUnidades);
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(793, 75);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(117, 46);
            this.ExportarButton.TabIndex = 54;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(660, 75);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(117, 46);
            this.ConsultarButton.TabIndex = 53;
            this.ConsultarButton.Text = "Consultar Todos";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.BackColor = System.Drawing.Color.White;
            this.ConductorTextBox.Location = new System.Drawing.Point(410, 103);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.ReadOnly = true;
            this.ConductorTextBox.Size = new System.Drawing.Size(225, 21);
            this.ConductorTextBox.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 45;
            this.label2.Text = "Conductor:";
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataSource = this.selectEmpresasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(108, 74);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.empresa_IDComboBox.TabIndex = 50;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            this.empresa_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.empresa_IDComboBox_SelectionChangeCommitted);
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Unidad:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(410, 76);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(101, 21);
            this.NumeroEconomicoTextBox.TabIndex = 48;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // estacion_IDComboBox
            // 
            this.estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(108, 103);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.estacion_IDComboBox.TabIndex = 52;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            this.estacion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.estacion_IDComboBox_SelectionChangeCommitted);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Unidad_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Unidad_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
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
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Unidad";
            this.dataGridViewTextBoxColumn4.HeaderText = "Unidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Ingreso
            // 
            this.Ingreso.DataPropertyName = "Ingreso";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "c";
            this.Ingreso.DefaultCellStyle = dataGridViewCellStyle1;
            this.Ingreso.HeaderText = "Ingreso";
            this.Ingreso.Name = "Ingreso";
            this.Ingreso.ReadOnly = true;
            // 
            // Gasto
            // 
            this.Gasto.DataPropertyName = "Gasto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "c";
            this.Gasto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Gasto.HeaderText = "Gasto";
            this.Gasto.Name = "Gasto";
            this.Gasto.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "c";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "Saldo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // ReporteSaldosCuentasUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteSaldosCuentasUnidades";
            this.Text = "ReporteSaldosCuentasConductores";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosTotalesUnidadesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosTotalesUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.DataGridView vista_SaldosTotalesUnidadesDataGridView;
        private System.Windows.Forms.BindingSource vista_SaldosTotalesUnidadesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

    }
}