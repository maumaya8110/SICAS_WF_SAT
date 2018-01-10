namespace SICASv20.forms
{
    partial class ComisionesServicios
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
            System.Windows.Forms.Label comisionista_IDLabel;
            System.Windows.Forms.Label comisionServicio_IDLabel;
            System.Windows.Forms.Label montoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label tipoComision_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.comisionista_IDComboBox = new System.Windows.Forms.ComboBox();
            this.vista_ComisionistasServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoComision_IDComboBox = new System.Windows.Forms.ComboBox();
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.comisionServicio_IDTextBox = new System.Windows.Forms.TextBox();
            this.montoTextBox = new System.Windows.Forms.TextBox();
            this.vista_ComisionesServiciosDataGridView = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ComisionServicio_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ComisionesServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.tiposComisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            comisionista_IDLabel = new System.Windows.Forms.Label();
            comisionServicio_IDLabel = new System.Windows.Forms.Label();
            montoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            tipoComision_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionistasServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionesServiciosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionesServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposComisionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comisionista_IDLabel
            // 
            comisionista_IDLabel.AutoSize = true;
            comisionista_IDLabel.Location = new System.Drawing.Point(303, 50);
            comisionista_IDLabel.Name = "comisionista_IDLabel";
            comisionista_IDLabel.Size = new System.Drawing.Size(96, 15);
            comisionista_IDLabel.TabIndex = 3;
            comisionista_IDLabel.Text = "Comisionista ID:";
            // 
            // comisionServicio_IDLabel
            // 
            comisionServicio_IDLabel.AutoSize = true;
            comisionServicio_IDLabel.Location = new System.Drawing.Point(25, 26);
            comisionServicio_IDLabel.Name = "comisionServicio_IDLabel";
            comisionServicio_IDLabel.Size = new System.Drawing.Size(123, 15);
            comisionServicio_IDLabel.TabIndex = 5;
            comisionServicio_IDLabel.Text = "Comision Servicio ID:";
            // 
            // montoLabel
            // 
            montoLabel.AutoSize = true;
            montoLabel.Location = new System.Drawing.Point(303, 23);
            montoLabel.Name = "montoLabel";
            montoLabel.Size = new System.Drawing.Size(45, 15);
            montoLabel.TabIndex = 7;
            montoLabel.Text = "Monto:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(25, 53);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 9;
            nombreLabel.Text = "Nombre:";
            // 
            // tipoComision_IDLabel
            // 
            tipoComision_IDLabel.AutoSize = true;
            tipoComision_IDLabel.Location = new System.Drawing.Point(25, 80);
            tipoComision_IDLabel.Name = "tipoComision_IDLabel";
            tipoComision_IDLabel.Size = new System.Drawing.Size(104, 15);
            tipoComision_IDLabel.TabIndex = 13;
            tipoComision_IDLabel.Text = "Tipo Comision ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.vista_ComisionesServiciosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comisiones de Servicio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Controls.Add(this.comisionista_IDComboBox);
            this.groupBox2.Controls.Add(comisionista_IDLabel);
            this.groupBox2.Controls.Add(this.tipoComision_IDComboBox);
            this.groupBox2.Controls.Add(tipoComision_IDLabel);
            this.groupBox2.Controls.Add(comisionServicio_IDLabel);
            this.groupBox2.Controls.Add(this.nombreTextBox);
            this.groupBox2.Controls.Add(this.comisionServicio_IDTextBox);
            this.groupBox2.Controls.Add(nombreLabel);
            this.groupBox2.Controls.Add(montoLabel);
            this.groupBox2.Controls.Add(this.montoTextBox);
            this.groupBox2.Location = new System.Drawing.Point(20, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(941, 111);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(839, 20);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 15;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // comisionista_IDComboBox
            // 
            this.comisionista_IDComboBox.DataSource = this.vista_ComisionistasServiciosBindingSource;
            this.comisionista_IDComboBox.DisplayMember = "Nombre";
            this.comisionista_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comisionista_IDComboBox.FormattingEnabled = true;
            this.comisionista_IDComboBox.Location = new System.Drawing.Point(432, 47);
            this.comisionista_IDComboBox.Name = "comisionista_IDComboBox";
            this.comisionista_IDComboBox.Size = new System.Drawing.Size(329, 23);
            this.comisionista_IDComboBox.TabIndex = 4;
            this.comisionista_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // vista_ComisionistasServiciosBindingSource
            // 
            this.vista_ComisionistasServiciosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ComisionistasServicios);
            // 
            // tipoComision_IDComboBox
            // 
            this.tipoComision_IDComboBox.DataSource = this.tiposComisionesBindingSource;
            this.tipoComision_IDComboBox.DisplayMember = "Nombre";
            this.tipoComision_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComision_IDComboBox.FormattingEnabled = true;
            this.tipoComision_IDComboBox.Location = new System.Drawing.Point(154, 77);
            this.tipoComision_IDComboBox.Name = "tipoComision_IDComboBox";
            this.tipoComision_IDComboBox.Size = new System.Drawing.Size(121, 23);
            this.tipoComision_IDComboBox.TabIndex = 14;
            this.tipoComision_IDComboBox.ValueMember = "TipoComision_ID";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(154, 50);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(121, 21);
            this.nombreTextBox.TabIndex = 10;
            // 
            // comisionServicio_IDTextBox
            // 
            this.comisionServicio_IDTextBox.Location = new System.Drawing.Point(154, 23);
            this.comisionServicio_IDTextBox.Name = "comisionServicio_IDTextBox";
            this.comisionServicio_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.comisionServicio_IDTextBox.TabIndex = 6;
            // 
            // montoTextBox
            // 
            this.montoTextBox.Location = new System.Drawing.Point(432, 20);
            this.montoTextBox.Name = "montoTextBox";
            this.montoTextBox.Size = new System.Drawing.Size(121, 21);
            this.montoTextBox.TabIndex = 8;
            // 
            // vista_ComisionesServiciosDataGridView
            // 
            this.vista_ComisionesServiciosDataGridView.AllowUserToAddRows = false;
            this.vista_ComisionesServiciosDataGridView.AllowUserToDeleteRows = false;
            this.vista_ComisionesServiciosDataGridView.AutoGenerateColumns = false;
            this.vista_ComisionesServiciosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ComisionesServiciosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.ComisionServicio_IDColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.vista_ComisionesServiciosDataGridView.DataSource = this.vista_ComisionesServiciosBindingSource;
            this.vista_ComisionesServiciosDataGridView.Location = new System.Drawing.Point(20, 156);
            this.vista_ComisionesServiciosDataGridView.Name = "vista_ComisionesServiciosDataGridView";
            this.vista_ComisionesServiciosDataGridView.ReadOnly = true;
            this.vista_ComisionesServiciosDataGridView.Size = new System.Drawing.Size(941, 448);
            this.vista_ComisionesServiciosDataGridView.TabIndex = 0;
            this.vista_ComisionesServiciosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_ComisionesServiciosDataGridView_CellContentClick);
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // ComisionServicio_IDColumn
            // 
            this.ComisionServicio_IDColumn.DataPropertyName = "ComisionServicio_ID";
            this.ComisionServicio_IDColumn.HeaderText = "ComisionServicio_ID";
            this.ComisionServicio_IDColumn.Name = "ComisionServicio_IDColumn";
            this.ComisionServicio_IDColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Comisionista_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Comisionista_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Comisionista";
            this.dataGridViewTextBoxColumn4.HeaderText = "Comisionista";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TipoComision_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "TipoComision_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TipoComision";
            this.dataGridViewTextBoxColumn6.HeaderText = "TipoComision";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Monto";
            this.dataGridViewTextBoxColumn7.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // vista_ComisionesServiciosBindingSource
            // 
            this.vista_ComisionesServiciosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ComisionesServicios);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArrendamientosTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CajasTableAdapter = null;
            this.tableAdapterManager.ClasesPublicidadTableAdapter = null;
            this.tableAdapterManager.ComisionesServiciosTableAdapter = null;
            this.tableAdapterManager.ConceptosTableAdapter = null;
            this.tableAdapterManager.ConcesionesTableAdapter = null;
            this.tableAdapterManager.ConductoresTableAdapter = null;
            this.tableAdapterManager.ContratosTableAdapter = null;
            this.tableAdapterManager.CuentaCajasTableAdapter = null;
            this.tableAdapterManager.CuentaConductoresTableAdapter = null;
            this.tableAdapterManager.CuentaEmpresasTableAdapter = null;
            this.tableAdapterManager.CuentaFlujoCajasTableAdapter = null;
            this.tableAdapterManager.CuentasTableAdapter = null;
            this.tableAdapterManager.CuentaUnidadesTableAdapter = null;
            this.tableAdapterManager.DiasDeCobrosTableAdapter = null;
            this.tableAdapterManager.Empresas_CuentasTableAdapter = null;
            this.tableAdapterManager.EmpresasTableAdapter = null;
            this.tableAdapterManager.EstacionesTableAdapter = null;
            this.tableAdapterManager.EstatusConductoresTableAdapter = null;
            this.tableAdapterManager.EstatusContratosTableAdapter = null;
            this.tableAdapterManager.EstatusFinancierosTableAdapter = null;
            this.tableAdapterManager.EstatusUnidadesTableAdapter = null;
            this.tableAdapterManager.LocacionesUnidadesTableAdapter = null;
            this.tableAdapterManager.MarcasUnidadesTableAdapter = null;
            this.tableAdapterManager.MediosPublicitariosTableAdapter = null;
            this.tableAdapterManager.MenuesTableAdapter = null;
            this.tableAdapterManager.MercadosTableAdapter = null;
            this.tableAdapterManager.ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.ModulosTableAdapter = null;
            this.tableAdapterManager.MonedasTableAdapter = null;
            this.tableAdapterManager.OpcionesTableAdapter = null;
            this.tableAdapterManager.Servicios_ComisionesTableAdapter = null;
            this.tableAdapterManager.ServiciosTableAdapter = null;
            this.tableAdapterManager.SesionesTableAdapter = null;
            this.tableAdapterManager.StatusFinancierosTableAdapter = null;
            this.tableAdapterManager.TicketsTableAdapter = null;
            this.tableAdapterManager.TiposConcesionesTableAdapter = null;
            this.tableAdapterManager.TiposContratosTableAdapter = null;
            this.tableAdapterManager.TiposCuentasTableAdapter = null;
            this.tableAdapterManager.TiposEmpresasTableAdapter = null;
            this.tableAdapterManager.TiposLicenciasTableAdapter = null;
            this.tableAdapterManager.UnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = null;
            this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
            // 
            // tiposComisionesBindingSource
            // 
            this.tiposComisionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposComisiones);
            // 
            // ComisionesServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComisionesServicios";
            this.Text = "ComisionesServicios";            
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionistasServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionesServiciosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComisionesServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposComisionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_ComisionesServiciosDataGridView;
        private System.Windows.Forms.BindingSource vista_ComisionesServiciosBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.ComboBox comisionista_IDComboBox;
        private System.Windows.Forms.ComboBox tipoComision_IDComboBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox comisionServicio_IDTextBox;
        private System.Windows.Forms.TextBox montoTextBox;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComisionServicio_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private SICASCentralDataSet sICASCentralDataSet;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource vista_ComisionistasServiciosBindingSource;
        private System.Windows.Forms.BindingSource tiposComisionesBindingSource;

    }
}