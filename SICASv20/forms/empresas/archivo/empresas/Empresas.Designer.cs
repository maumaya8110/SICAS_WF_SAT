namespace SICASv20.forms
{
    partial class Empresas
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
			this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
			this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
			this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
			this.mercadosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.MercadosTableAdapter();
			this.tiposEmpresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.TiposEmpresasTableAdapter();
			this.tiposEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.mercadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.BuscarButton = new System.Windows.Forms.Button();
			this.empresasDataGridView = new System.Windows.Forms.DataGridView();
			this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TiposEmpresasComboBox = new System.Windows.Forms.ComboBox();
			this.NombreEmpresaTexBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposEmpresasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mercadosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sICASCentralDataSet
			// 
			this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
			this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// empresasBindingSource
			// 
			this.empresasBindingSource.DataMember = "Empresas";
			this.empresasBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// empresasTableAdapter
			// 
			this.empresasTableAdapter.ClearBeforeFill = true;
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
			this.tableAdapterManager.EmpresasTableAdapter = this.empresasTableAdapter;
			this.tableAdapterManager.EstacionesTableAdapter = null;
			this.tableAdapterManager.EstatusConductoresTableAdapter = null;
			this.tableAdapterManager.EstatusContratosTableAdapter = null;
			this.tableAdapterManager.EstatusFinancierosTableAdapter = null;
			this.tableAdapterManager.EstatusUnidadesTableAdapter = null;
			this.tableAdapterManager.LocacionesUnidadesTableAdapter = null;
			this.tableAdapterManager.MarcasUnidadesTableAdapter = null;
			this.tableAdapterManager.MediosPublicitariosTableAdapter = null;
			this.tableAdapterManager.MenuesTableAdapter = null;
			this.tableAdapterManager.MercadosTableAdapter = this.mercadosTableAdapter;
			this.tableAdapterManager.ModelosUnidadesTableAdapter = null;
			this.tableAdapterManager.ModulosTableAdapter = null;
			this.tableAdapterManager.MonedasTableAdapter = null;
			this.tableAdapterManager.OpcionesTableAdapter = null;
			this.tableAdapterManager.Servicios_ComisionesTableAdapter = null;
			this.tableAdapterManager.ServiciosTableAdapter = null;
			this.tableAdapterManager.SesionesTableAdapter = null;
			this.tableAdapterManager.StatusFinancierosTableAdapter = null;
			this.tableAdapterManager.TicketsTableAdapter = null;
			this.tableAdapterManager.TiposComisionesTableAdapter = null;
			this.tableAdapterManager.TiposConcesionesTableAdapter = null;
			this.tableAdapterManager.TiposContratosTableAdapter = null;
			this.tableAdapterManager.TiposCuentasTableAdapter = null;
			this.tableAdapterManager.TiposEmpresasTableAdapter = this.tiposEmpresasTableAdapter;
			this.tableAdapterManager.TiposLicenciasTableAdapter = null;
			this.tableAdapterManager.UnidadesTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			this.tableAdapterManager.UsuariosTableAdapter = null;
			this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
			// 
			// mercadosTableAdapter
			// 
			this.mercadosTableAdapter.ClearBeforeFill = true;
			// 
			// tiposEmpresasTableAdapter
			// 
			this.tiposEmpresasTableAdapter.ClearBeforeFill = true;
			// 
			// tiposEmpresasBindingSource
			// 
			this.tiposEmpresasBindingSource.DataMember = "TiposEmpresas";
			this.tiposEmpresasBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// mercadosBindingSource
			// 
			this.mercadosBindingSource.DataMember = "Mercados";
			this.mercadosBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// BuscarButton
			// 
			this.BuscarButton.Location = new System.Drawing.Point(442, 3);
			this.BuscarButton.Name = "BuscarButton";
			this.tableLayoutPanel1.SetRowSpan(this.BuscarButton, 2);
			this.BuscarButton.Size = new System.Drawing.Size(110, 33);
			this.BuscarButton.TabIndex = 4;
			this.BuscarButton.Text = "Buscar";
			this.BuscarButton.UseVisualStyleBackColor = true;
			this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
			// 
			// empresasDataGridView
			// 
			this.empresasDataGridView.AllowUserToAddRows = false;
			this.empresasDataGridView.AllowUserToDeleteRows = false;
			this.empresasDataGridView.AutoGenerateColumns = false;
			this.empresasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.empresasDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.empresasDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.empresasDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.empresasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.empresasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewCheckBoxColumn1});
			this.empresasDataGridView.DataSource = this.empresasBindingSource;
			this.empresasDataGridView.GridColor = System.Drawing.Color.Gainsboro;
			this.empresasDataGridView.Location = new System.Drawing.Point(18, 107);
			this.empresasDataGridView.Name = "empresasDataGridView";
			this.empresasDataGridView.ReadOnly = true;
			this.empresasDataGridView.RowHeadersVisible = false;
			this.empresasDataGridView.Size = new System.Drawing.Size(950, 493);
			this.empresasDataGridView.TabIndex = 1;
			this.empresasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.empresasDataGridView_CellContentClick);
			// 
			// EditColumn
			// 
			this.EditColumn.HeaderText = "";
			this.EditColumn.Name = "EditColumn";
			this.EditColumn.ReadOnly = true;
			this.EditColumn.Text = "Actualizar";
			this.EditColumn.UseColumnTextForLinkValue = true;
			this.EditColumn.Width = 5;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Empresa_ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "Empresa_ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 115;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "TipoEmpresa_ID";
			this.dataGridViewTextBoxColumn2.DataSource = this.tiposEmpresasBindingSource;
			this.dataGridViewTextBoxColumn2.DisplayMember = "Nombre";
			this.dataGridViewTextBoxColumn2.HeaderText = "TipoEmpresa_ID";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn2.ValueMember = "TipoEmpresa_ID";
			this.dataGridViewTextBoxColumn2.Width = 144;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Mercado_ID";
			this.dataGridViewTextBoxColumn3.DataSource = this.mercadosBindingSource;
			this.dataGridViewTextBoxColumn3.DisplayMember = "Nombre";
			this.dataGridViewTextBoxColumn3.HeaderText = "Mercado_ID";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn3.ValueMember = "Mercado_ID";
			this.dataGridViewTextBoxColumn3.Width = 114;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "RFC";
			this.dataGridViewTextBoxColumn4.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 64;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "RazonSocial";
			this.dataGridViewTextBoxColumn5.HeaderText = "RazonSocial";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 118;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn6.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 87;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Domicilio";
			this.dataGridViewTextBoxColumn7.HeaderText = "Domicilio";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 95;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "CodigoPostal";
			this.dataGridViewTextBoxColumn8.HeaderText = "CodigoPostal";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Width = 123;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Ciudad";
			this.dataGridViewTextBoxColumn9.HeaderText = "Ciudad";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Width = 79;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Estado";
			this.dataGridViewTextBoxColumn10.HeaderText = "Estado";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Width = 80;
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Telefono1";
			this.dataGridViewTextBoxColumn11.HeaderText = "Telefono1";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.Width = 99;
			// 
			// dataGridViewTextBoxColumn12
			// 
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Telefono2";
			this.dataGridViewTextBoxColumn12.HeaderText = "Telefono2";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.Width = 99;
			// 
			// dataGridViewTextBoxColumn13
			// 
			this.dataGridViewTextBoxColumn13.DataPropertyName = "Movil";
			this.dataGridViewTextBoxColumn13.HeaderText = "Movil";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.Width = 68;
			// 
			// dataGridViewTextBoxColumn14
			// 
			this.dataGridViewTextBoxColumn14.DataPropertyName = "Email";
			this.dataGridViewTextBoxColumn14.HeaderText = "Email";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn14.Width = 70;
			// 
			// dataGridViewTextBoxColumn15
			// 
			this.dataGridViewTextBoxColumn15.DataPropertyName = "RepresentanteLegal";
			this.dataGridViewTextBoxColumn15.HeaderText = "RepresentanteLegal";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.Width = 164;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Activo";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Activo";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn1.Width = 54;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Controls.Add(this.empresasDataGridView);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(993, 618);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Empresas";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.BuscarButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.TiposEmpresasComboBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.NombreEmpresaTexBox, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 36);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 55);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 18);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tipo de empresa:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Nombre o razón social:";
			// 
			// TiposEmpresasComboBox
			// 
			this.TiposEmpresasComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.TiposEmpresasComboBox.DataSource = this.tiposEmpresasBindingSource;
			this.TiposEmpresasComboBox.DisplayMember = "Nombre";
			this.TiposEmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TiposEmpresasComboBox.FormattingEnabled = true;
			this.TiposEmpresasComboBox.Location = new System.Drawing.Point(173, 3);
			this.TiposEmpresasComboBox.Name = "TiposEmpresasComboBox";
			this.TiposEmpresasComboBox.Size = new System.Drawing.Size(263, 26);
			this.TiposEmpresasComboBox.TabIndex = 7;
			this.TiposEmpresasComboBox.ValueMember = "TipoEmpresa_ID";
			// 
			// NombreEmpresaTexBox
			// 
			this.NombreEmpresaTexBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.NombreEmpresaTexBox.Location = new System.Drawing.Point(173, 35);
			this.NombreEmpresaTexBox.Name = "NombreEmpresaTexBox";
			this.NombreEmpresaTexBox.Size = new System.Drawing.Size(223, 24);
			this.NombreEmpresaTexBox.TabIndex = 8;
			// 
			// Empresas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "Empresas";
			this.Text = "Empresas";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Empresas_FormClosing);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposEmpresasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mercadosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private SICASCentralDataSetTableAdapters.TiposEmpresasTableAdapter tiposEmpresasTableAdapter;
        private System.Windows.Forms.BindingSource tiposEmpresasBindingSource;
        private SICASCentralDataSetTableAdapters.MercadosTableAdapter mercadosTableAdapter;
        private System.Windows.Forms.BindingSource mercadosBindingSource;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TiposEmpresasComboBox;
        private System.Windows.Forms.TextBox NombreEmpresaTexBox;
        private System.Windows.Forms.DataGridView empresasDataGridView;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}