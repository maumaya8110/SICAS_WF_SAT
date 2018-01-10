namespace SICASv20.forms
{
    partial class CargoCuentaConductores
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
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label cuenta_IDLabel;
            System.Windows.Forms.Label concepto_IDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CargoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BuscarConductorButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.cuenta_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getCuentasDeEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.concepto_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getConceptosDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.get_DatosConductorDeUnidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.get_SaldosConductorDataGridView = new System.Windows.Forms.DataGridView();
            this.empresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.get_SaldosConductorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_SaldosConductorTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SaldosConductorTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            this.get_EmpresasInternasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter();
            this.estacionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstacionesTableAdapter();
            this.get_CuentasDeEmpresaTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_CuentasDeEmpresaTableAdapter();
            this.get_ConceptosDeCuentaTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ConceptosDeCuentaTableAdapter();
            this.get_DatosConductorDeUnidadTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_DatosConductorDeUnidadTableAdapter();
            empresa_IDLabel = new System.Windows.Forms.Label();
            estacion_IDLabel = new System.Windows.Forms.Label();
            cuenta_IDLabel = new System.Windows.Forms.Label();
            concepto_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCuentasDeEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConceptosDeCuentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_DatosConductorDeUnidadBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.get_SaldosConductorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_SaldosConductorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(8, 31);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 8;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(8, 60);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 10;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // cuenta_IDLabel
            // 
            cuenta_IDLabel.AutoSize = true;
            cuenta_IDLabel.Location = new System.Drawing.Point(8, 145);
            cuenta_IDLabel.Name = "cuenta_IDLabel";
            cuenta_IDLabel.Size = new System.Drawing.Size(64, 15);
            cuenta_IDLabel.TabIndex = 29;
            cuenta_IDLabel.Text = "Cuenta ID:";
            // 
            // concepto_IDLabel
            // 
            concepto_IDLabel.AutoSize = true;
            concepto_IDLabel.Location = new System.Drawing.Point(8, 174);
            concepto_IDLabel.Name = "concepto_IDLabel";
            concepto_IDLabel.Size = new System.Drawing.Size(77, 15);
            concepto_IDLabel.TabIndex = 31;
            concepto_IDLabel.Text = "Concepto ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CargoNumericUpDown);
            this.groupBox1.Controls.Add(this.ComentariosTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BuscarConductorButton);
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(cuenta_IDLabel);
            this.groupBox1.Controls.Add(this.cuenta_IDComboBox);
            this.groupBox1.Controls.Add(concepto_IDLabel);
            this.groupBox1.Controls.Add(this.concepto_IDComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Controls.Add(this.empresa_IDComboBox);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(this.estacion_IDComboBox);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cargo";
            // 
            // CargoNumericUpDown
            // 
            this.CargoNumericUpDown.DecimalPlaces = 2;
            this.CargoNumericUpDown.InterceptArrowKeys = false;
            this.CargoNumericUpDown.Location = new System.Drawing.Point(102, 200);
            this.CargoNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.CargoNumericUpDown.Name = "CargoNumericUpDown";
            this.CargoNumericUpDown.Size = new System.Drawing.Size(86, 21);
            this.CargoNumericUpDown.TabIndex = 37;
            this.CargoNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComentariosTextBox.Location = new System.Drawing.Point(102, 228);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(225, 69);
            this.ComentariosTextBox.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "Comentarios:";
            // 
            // BuscarConductorButton
            // 
            this.BuscarConductorButton.Location = new System.Drawing.Point(331, 111);
            this.BuscarConductorButton.Name = "BuscarConductorButton";
            this.BuscarConductorButton.Size = new System.Drawing.Size(33, 23);
            this.BuscarConductorButton.TabIndex = 34;
            this.BuscarConductorButton.Text = "...";
            this.BuscarConductorButton.UseVisualStyleBackColor = true;
            this.BuscarConductorButton.Click += new System.EventHandler(this.BuscarConductorButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(289, 303);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 30);
            this.AceptarButton.TabIndex = 33;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // cuenta_IDComboBox
            // 
            this.cuenta_IDComboBox.DataSource = this.getCuentasDeEmpresaBindingSource;
            this.cuenta_IDComboBox.DisplayMember = "Nombre";
            this.cuenta_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cuenta_IDComboBox.FormattingEnabled = true;
            this.cuenta_IDComboBox.Location = new System.Drawing.Point(102, 142);
            this.cuenta_IDComboBox.Name = "cuenta_IDComboBox";
            this.cuenta_IDComboBox.Size = new System.Drawing.Size(225, 23);
            this.cuenta_IDComboBox.TabIndex = 30;
            this.cuenta_IDComboBox.ValueMember = "Cuenta_ID";
            this.cuenta_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.cuenta_IDComboBox_SelectionChangeCommitted);
            // 
            // getCuentasDeEmpresaBindingSource
            // 
            this.getCuentasDeEmpresaBindingSource.DataMember = "Get_CuentasDeEmpresa";
            this.getCuentasDeEmpresaBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // concepto_IDComboBox
            // 
            this.concepto_IDComboBox.DataSource = this.getConceptosDeCuentaBindingSource;
            this.concepto_IDComboBox.DisplayMember = "Nombre";
            this.concepto_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.concepto_IDComboBox.FormattingEnabled = true;
            this.concepto_IDComboBox.Location = new System.Drawing.Point(102, 171);
            this.concepto_IDComboBox.Name = "concepto_IDComboBox";
            this.concepto_IDComboBox.Size = new System.Drawing.Size(225, 23);
            this.concepto_IDComboBox.TabIndex = 32;
            this.concepto_IDComboBox.ValueMember = "Concepto_ID";
            // 
            // getConceptosDeCuentaBindingSource
            // 
            this.getConceptosDeCuentaBindingSource.DataMember = "Get_ConceptosDeCuenta";
            this.getConceptosDeCuentaBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cargo:";
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataSource = this.getEmpresasInternasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(102, 28);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.empresa_IDComboBox.TabIndex = 9;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            this.empresa_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.empresa_IDComboBox_SelectionChangeCommitted);
            // 
            // getEmpresasInternasBindingSource
            // 
            this.getEmpresasInternasBindingSource.DataMember = "Get_EmpresasInternas";
            this.getEmpresasInternasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // estacion_IDComboBox
            // 
            this.estacion_IDComboBox.DataSource = this.estacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(102, 57);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(182, 23);
            this.estacion_IDComboBox.TabIndex = 11;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataMember = "Estaciones";
            this.estacionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.BackColor = System.Drawing.Color.White;
            this.ConductorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.get_DatosConductorDeUnidadBindingSource, "Conductor", true));
            this.ConductorTextBox.Location = new System.Drawing.Point(102, 111);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.ReadOnly = true;
            this.ConductorTextBox.Size = new System.Drawing.Size(225, 21);
            this.ConductorTextBox.TabIndex = 7;
            // 
            // get_DatosConductorDeUnidadBindingSource
            // 
            this.get_DatosConductorDeUnidadBindingSource.DataMember = "Get_DatosConductorDeUnidad";
            this.get_DatosConductorDeUnidadBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Conductor:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(102, 84);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(101, 21);
            this.NumeroEconomicoTextBox.TabIndex = 5;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unidad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.get_SaldosConductorDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(392, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 484);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldos del conductor";
            // 
            // get_SaldosConductorDataGridView
            // 
            this.get_SaldosConductorDataGridView.AllowUserToAddRows = false;
            this.get_SaldosConductorDataGridView.AllowUserToDeleteRows = false;
            this.get_SaldosConductorDataGridView.AutoGenerateColumns = false;
            this.get_SaldosConductorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.get_SaldosConductorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empresaDataGridViewTextBoxColumn,
            this.cuentaDataGridViewTextBoxColumn,
            this.SaldoColumn});
            this.get_SaldosConductorDataGridView.DataSource = this.get_SaldosConductorBindingSource;
            this.get_SaldosConductorDataGridView.Location = new System.Drawing.Point(17, 29);
            this.get_SaldosConductorDataGridView.Name = "get_SaldosConductorDataGridView";
            this.get_SaldosConductorDataGridView.ReadOnly = true;
            this.get_SaldosConductorDataGridView.Size = new System.Drawing.Size(570, 434);
            this.get_SaldosConductorDataGridView.TabIndex = 0;
            // 
            // empresaDataGridViewTextBoxColumn
            // 
            this.empresaDataGridViewTextBoxColumn.DataPropertyName = "Empresa";
            this.empresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.empresaDataGridViewTextBoxColumn.Name = "empresaDataGridViewTextBoxColumn";
            this.empresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cuentaDataGridViewTextBoxColumn
            // 
            this.cuentaDataGridViewTextBoxColumn.DataPropertyName = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.Name = "cuentaDataGridViewTextBoxColumn";
            this.cuentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SaldoColumn
            // 
            this.SaldoColumn.DataPropertyName = "Saldo";
            dataGridViewCellStyle1.Format = "N2";
            this.SaldoColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SaldoColumn.HeaderText = "Saldo";
            this.SaldoColumn.Name = "SaldoColumn";
            this.SaldoColumn.ReadOnly = true;
            // 
            // get_SaldosConductorBindingSource
            // 
            this.get_SaldosConductorBindingSource.DataMember = "Get_SaldosConductor";
            this.get_SaldosConductorBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_SaldosConductorTableAdapter
            // 
            this.get_SaldosConductorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Get_ArrendamientosDisponiblesTableAdapter = null;
            this.tableAdapterManager.Get_EmpresasPropietariasTableAdapter = null;
            this.tableAdapterManager.Get_MenuesTableAdapter = null;
            this.tableAdapterManager.Get_ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.Get_ModulosTableAdapter = null;
            this.tableAdapterManager.Get_OpcionesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // get_EmpresasInternasTableAdapter
            // 
            this.get_EmpresasInternasTableAdapter.ClearBeforeFill = true;
            // 
            // estacionesTableAdapter
            // 
            this.estacionesTableAdapter.ClearBeforeFill = true;
            // 
            // get_CuentasDeEmpresaTableAdapter
            // 
            this.get_CuentasDeEmpresaTableAdapter.ClearBeforeFill = true;
            // 
            // get_ConceptosDeCuentaTableAdapter
            // 
            this.get_ConceptosDeCuentaTableAdapter.ClearBeforeFill = true;
            // 
            // get_DatosConductorDeUnidadTableAdapter
            // 
            this.get_DatosConductorDeUnidadTableAdapter.ClearBeforeFill = true;
            // 
            // CargoCuentaConductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CargoCuentaConductores";
            this.Text = "AltaCuentaConductores";            
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCuentasDeEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConceptosDeCuentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_DatosConductorDeUnidadBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.get_SaldosConductorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_SaldosConductorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource get_SaldosConductorBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SaldosConductorTableAdapter get_SaldosConductorTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView get_SaldosConductorDataGridView;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.Button BuscarConductorButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.ComboBox cuenta_IDComboBox;
        private System.Windows.Forms.ComboBox concepto_IDComboBox;
        private System.Windows.Forms.BindingSource getEmpresasInternasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter get_EmpresasInternasTableAdapter;
        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private SICASCentralDataSetTableAdapters.EstacionesTableAdapter estacionesTableAdapter;
        private System.Windows.Forms.BindingSource getCuentasDeEmpresaBindingSource;
        private System.Windows.Forms.BindingSource getConceptosDeCuentaBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_CuentasDeEmpresaTableAdapter get_CuentasDeEmpresaTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.Get_ConceptosDeCuentaTableAdapter get_ConceptosDeCuentaTableAdapter;
        private System.Windows.Forms.BindingSource get_DatosConductorDeUnidadBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_DatosConductorDeUnidadTableAdapter get_DatosConductorDeUnidadTableAdapter;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoColumn;
        private System.Windows.Forms.NumericUpDown CargoNumericUpDown;

    }
}