namespace SICASv20.forms
{
    partial class AltaCuentaUnidades
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
            System.Windows.Forms.Label cuenta_IDLabel;
            System.Windows.Forms.Label concepto_IDLabel;
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AbonoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.CargoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.cuenta_IDComboBox = new System.Windows.Forms.ComboBox();
            this.vista_Empresas_CuentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.concepto_IDComboBox = new System.Windows.Forms.ComboBox();
            this.vista_ConceptosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vista_SaldosUnidadesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_SaldosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            cuenta_IDLabel = new System.Windows.Forms.Label();
            concepto_IDLabel = new System.Windows.Forms.Label();
            empresa_IDLabel = new System.Windows.Forms.Label();
            estacion_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbonoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Empresas_CuentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConceptosBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosUnidadesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cuenta_IDLabel
            // 
            cuenta_IDLabel.AutoSize = true;
            cuenta_IDLabel.Location = new System.Drawing.Point(12, 153);
            cuenta_IDLabel.Name = "cuenta_IDLabel";
            cuenta_IDLabel.Size = new System.Drawing.Size(64, 15);
            cuenta_IDLabel.TabIndex = 47;
            cuenta_IDLabel.Text = "Cuenta ID:";
            // 
            // concepto_IDLabel
            // 
            concepto_IDLabel.AutoSize = true;
            concepto_IDLabel.Location = new System.Drawing.Point(12, 182);
            concepto_IDLabel.Name = "concepto_IDLabel";
            concepto_IDLabel.Size = new System.Drawing.Size(77, 15);
            concepto_IDLabel.TabIndex = 49;
            concepto_IDLabel.Text = "Concepto ID:";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(12, 39);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 41;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(12, 68);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 43;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AbonoNumericUpDown);
            this.groupBox1.Controls.Add(this.empresa_IDComboBox);
            this.groupBox1.Controls.Add(this.CargoNumericUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComentariosTextBox);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.estacion_IDComboBox);
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(cuenta_IDLabel);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Controls.Add(this.cuenta_IDComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(concepto_IDLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.concepto_IDComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 617);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Movimiento";
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.BackColor = System.Drawing.Color.White;
            this.ConductorTextBox.Location = new System.Drawing.Point(106, 119);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.ReadOnly = true;
            this.ConductorTextBox.Size = new System.Drawing.Size(225, 21);
            this.ConductorTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Conductor:";
            // 
            // AbonoNumericUpDown
            // 
            this.AbonoNumericUpDown.DecimalPlaces = 2;
            this.AbonoNumericUpDown.InterceptArrowKeys = false;
            this.AbonoNumericUpDown.Location = new System.Drawing.Point(106, 235);
            this.AbonoNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.AbonoNumericUpDown.Name = "AbonoNumericUpDown";
            this.AbonoNumericUpDown.Size = new System.Drawing.Size(86, 21);
            this.AbonoNumericUpDown.TabIndex = 55;
            this.AbonoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AbonoNumericUpDown.ValueChanged += new System.EventHandler(this.AbonoNumericUpDown_ValueChanged);
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataSource = this.selectEmpresasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(106, 36);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.empresa_IDComboBox.TabIndex = 42;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            this.empresa_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.empresa_IDComboBox_SelectionChangeCommitted);
            // 
            // CargoNumericUpDown
            // 
            this.CargoNumericUpDown.DecimalPlaces = 2;
            this.CargoNumericUpDown.InterceptArrowKeys = false;
            this.CargoNumericUpDown.Location = new System.Drawing.Point(106, 208);
            this.CargoNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.CargoNumericUpDown.Name = "CargoNumericUpDown";
            this.CargoNumericUpDown.Size = new System.Drawing.Size(86, 21);
            this.CargoNumericUpDown.TabIndex = 54;
            this.CargoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CargoNumericUpDown.ValueChanged += new System.EventHandler(this.CargoNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Unidad:";
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComentariosTextBox.Location = new System.Drawing.Point(106, 262);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(225, 69);
            this.ComentariosTextBox.TabIndex = 53;
            this.ComentariosTextBox.TextChanged += new System.EventHandler(this.ComentariosTextBox_TextChanged);
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(106, 92);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(101, 21);
            this.NumeroEconomicoTextBox.TabIndex = 40;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 52;
            this.label5.Text = "Comentarios:";
            // 
            // estacion_IDComboBox
            // 
            this.estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(106, 65);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.estacion_IDComboBox.TabIndex = 44;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            this.estacion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.estacion_IDComboBox_SelectionChangeCommitted);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(293, 337);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 30);
            this.AceptarButton.TabIndex = 51;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // cuenta_IDComboBox
            // 
            this.cuenta_IDComboBox.DataSource = this.vista_Empresas_CuentasBindingSource;
            this.cuenta_IDComboBox.DisplayMember = "Cuenta";
            this.cuenta_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cuenta_IDComboBox.FormattingEnabled = true;
            this.cuenta_IDComboBox.Location = new System.Drawing.Point(106, 150);
            this.cuenta_IDComboBox.Name = "cuenta_IDComboBox";
            this.cuenta_IDComboBox.Size = new System.Drawing.Size(225, 23);
            this.cuenta_IDComboBox.TabIndex = 48;
            this.cuenta_IDComboBox.ValueMember = "Cuenta_ID";
            this.cuenta_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.cuenta_IDComboBox_SelectionChangeCommitted);
            // 
            // vista_Empresas_CuentasBindingSource
            // 
            this.vista_Empresas_CuentasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Empresas_Cuentas);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Cargo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 46;
            this.label3.Text = "Abono:";
            // 
            // concepto_IDComboBox
            // 
            this.concepto_IDComboBox.DataSource = this.vista_ConceptosBindingSource;
            this.concepto_IDComboBox.DisplayMember = "Concepto";
            this.concepto_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.concepto_IDComboBox.FormattingEnabled = true;
            this.concepto_IDComboBox.Location = new System.Drawing.Point(106, 179);
            this.concepto_IDComboBox.Name = "concepto_IDComboBox";
            this.concepto_IDComboBox.Size = new System.Drawing.Size(225, 23);
            this.concepto_IDComboBox.TabIndex = 50;
            this.concepto_IDComboBox.ValueMember = "Concepto_ID";
            this.concepto_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.concepto_IDComboBox_SelectionChangeCommitted);
            // 
            // vista_ConceptosBindingSource
            // 
            this.vista_ConceptosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Conceptos);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vista_SaldosUnidadesDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(416, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 617);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldos de la Unidad";
            // 
            // vista_SaldosUnidadesDataGridView
            // 
            this.vista_SaldosUnidadesDataGridView.AllowUserToAddRows = false;
            this.vista_SaldosUnidadesDataGridView.AllowUserToDeleteRows = false;
            this.vista_SaldosUnidadesDataGridView.AutoGenerateColumns = false;
            this.vista_SaldosUnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_SaldosUnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.vista_SaldosUnidadesDataGridView.DataSource = this.vista_SaldosUnidadesBindingSource;
            this.vista_SaldosUnidadesDataGridView.Location = new System.Drawing.Point(15, 28);
            this.vista_SaldosUnidadesDataGridView.Name = "vista_SaldosUnidadesDataGridView";
            this.vista_SaldosUnidadesDataGridView.ReadOnly = true;
            this.vista_SaldosUnidadesDataGridView.Size = new System.Drawing.Size(529, 558);
            this.vista_SaldosUnidadesDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Empresa";
            this.dataGridViewTextBoxColumn4.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Cuenta";
            this.dataGridViewTextBoxColumn6.HeaderText = "Cuenta";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Saldo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "c";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Saldo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // vista_SaldosUnidadesBindingSource
            // 
            this.vista_SaldosUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_SaldosUnidades);
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // AltaCuentaUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AltaCuentaUnidades";
            this.Text = "AltaCuentaUnidades";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbonoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Empresas_CuentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConceptosBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosUnidadesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_SaldosUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown AbonoNumericUpDown;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.NumericUpDown CargoNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.ComboBox cuenta_IDComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox concepto_IDComboBox;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView vista_SaldosUnidadesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource vista_SaldosUnidadesBindingSource;
        private System.Windows.Forms.BindingSource vista_Empresas_CuentasBindingSource;
        private System.Windows.Forms.BindingSource vista_ConceptosBindingSource;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
    }
}