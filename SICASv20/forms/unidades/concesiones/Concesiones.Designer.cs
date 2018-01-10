namespace SICASv20.forms
{
    partial class Concesiones
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Concesiones));
			this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
			this.concesionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.concesionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ConcesionesTableAdapter();
			this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
			this.concesionesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.concesionesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.concesionesDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.tiposConcesionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
			this.tiposConcesionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.TiposConcesionesTableAdapter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BuscarButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.PlacaLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PlacaTextBox = new System.Windows.Forms.TextBox();
			this.NumeroConcesionTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.concesionesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.concesionesBindingNavigator)).BeginInit();
			this.concesionesBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.concesionesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sICASCentralDataSet
			// 
			this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
			this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// concesionesBindingSource
			// 
			this.concesionesBindingSource.DataMember = "Concesiones";
			this.concesionesBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// concesionesTableAdapter
			// 
			this.concesionesTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.ArrendamientosTableAdapter = null;
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.CajasTableAdapter = null;
			this.tableAdapterManager.ClasesPublicidadTableAdapter = null;
			this.tableAdapterManager.ComisionesServiciosTableAdapter = null;
			this.tableAdapterManager.ConceptosTableAdapter = null;
			this.tableAdapterManager.ConcesionesTableAdapter = this.concesionesTableAdapter;
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
			this.tableAdapterManager.TiposComisionesTableAdapter = null;
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
			// concesionesBindingNavigator
			// 
			this.concesionesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.concesionesBindingNavigator.BindingSource = this.concesionesBindingSource;
			this.concesionesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.concesionesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.concesionesBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
			this.concesionesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.concesionesBindingNavigatorSaveItem});
			this.concesionesBindingNavigator.Location = new System.Drawing.Point(23, 30);
			this.concesionesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.concesionesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.concesionesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.concesionesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.concesionesBindingNavigator.Name = "concesionesBindingNavigator";
			this.concesionesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.concesionesBindingNavigator.Size = new System.Drawing.Size(288, 25);
			this.concesionesBindingNavigator.TabIndex = 0;
			this.concesionesBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Add new";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 22);
			this.bindingNavigatorCountItem.Text = "of {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Delete";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Move previous";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Position";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Current position";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Move last";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// concesionesBindingNavigatorSaveItem
			// 
			this.concesionesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.concesionesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("concesionesBindingNavigatorSaveItem.Image")));
			this.concesionesBindingNavigatorSaveItem.Name = "concesionesBindingNavigatorSaveItem";
			this.concesionesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.concesionesBindingNavigatorSaveItem.Text = "Save Data";
			this.concesionesBindingNavigatorSaveItem.Click += new System.EventHandler(this.concesionesBindingNavigatorSaveItem_Click);
			// 
			// concesionesDataGridView
			// 
			this.concesionesDataGridView.AutoGenerateColumns = false;
			this.concesionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.concesionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
			this.concesionesDataGridView.DataSource = this.concesionesBindingSource;
			this.concesionesDataGridView.Location = new System.Drawing.Point(23, 149);
			this.concesionesDataGridView.Name = "concesionesDataGridView";
			this.concesionesDataGridView.Size = new System.Drawing.Size(933, 503);
			this.concesionesDataGridView.TabIndex = 1;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Concesion_ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "Concesion_ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Empresa_ID";
			this.dataGridViewTextBoxColumn2.DataSource = this.empresasBindingSource;
			this.dataGridViewTextBoxColumn2.DisplayMember = "Nombre";
			this.dataGridViewTextBoxColumn2.HeaderText = "Empresa_ID";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn2.ValueMember = "Empresa_ID";
			// 
			// empresasBindingSource
			// 
			this.empresasBindingSource.DataMember = "Empresas";
			this.empresasBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "TipoConcesion_ID";
			this.dataGridViewTextBoxColumn3.DataSource = this.tiposConcesionesBindingSource;
			this.dataGridViewTextBoxColumn3.DisplayMember = "Nombre";
			this.dataGridViewTextBoxColumn3.HeaderText = "TipoConcesion_ID";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn3.ValueMember = "TipoConcesion_ID";
			// 
			// tiposConcesionesBindingSource
			// 
			this.tiposConcesionesBindingSource.DataMember = "TiposConcesiones";
			this.tiposConcesionesBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Placa";
			this.dataGridViewTextBoxColumn5.HeaderText = "Placa";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "NumeroConcesion";
			this.dataGridViewTextBoxColumn6.HeaderText = "NumeroConcesion";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// empresasTableAdapter
			// 
			this.empresasTableAdapter.ClearBeforeFill = true;
			// 
			// tiposConcesionesTableAdapter
			// 
			this.tiposConcesionesTableAdapter.ClearBeforeFill = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BuscarButton);
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Controls.Add(this.concesionesDataGridView);
			this.groupBox1.Controls.Add(this.concesionesBindingNavigator);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(987, 675);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Concesiones de unidades";
			// 
			// BuscarButton
			// 
			this.BuscarButton.Location = new System.Drawing.Point(366, 82);
			this.BuscarButton.Name = "BuscarButton";
			this.BuscarButton.Size = new System.Drawing.Size(108, 41);
			this.BuscarButton.TabIndex = 3;
			this.BuscarButton.Text = "Buscar";
			this.BuscarButton.UseVisualStyleBackColor = true;
			this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.2963F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.7037F));
			this.tableLayoutPanel1.Controls.Add(this.PlacaLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.PlacaTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.NumeroConcesionTextBox, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 71);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 57);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// PlacaLabel
			// 
			this.PlacaLabel.AutoSize = true;
			this.PlacaLabel.Location = new System.Drawing.Point(3, 0);
			this.PlacaLabel.Name = "PlacaLabel";
			this.PlacaLabel.Size = new System.Drawing.Size(49, 18);
			this.PlacaLabel.TabIndex = 0;
			this.PlacaLabel.Text = "Placa:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Numero de concesión:";
			// 
			// PlacaTextBox
			// 
			this.PlacaTextBox.Location = new System.Drawing.Point(153, 3);
			this.PlacaTextBox.Name = "PlacaTextBox";
			this.PlacaTextBox.Size = new System.Drawing.Size(144, 24);
			this.PlacaTextBox.TabIndex = 2;
			// 
			// NumeroConcesionTextBox
			// 
			this.NumeroConcesionTextBox.Location = new System.Drawing.Point(153, 31);
			this.NumeroConcesionTextBox.Name = "NumeroConcesionTextBox";
			this.NumeroConcesionTextBox.Size = new System.Drawing.Size(144, 24);
			this.NumeroConcesionTextBox.TabIndex = 3;
			// 
			// Concesiones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 700);
			this.Controls.Add(this.groupBox1);
			this.Name = "Concesiones";
			this.Text = "Concesiones";
			this.Load += new System.EventHandler(this.Concesiones_Load);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.concesionesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.concesionesBindingNavigator)).EndInit();
			this.concesionesBindingNavigator.ResumeLayout(false);
			this.concesionesBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.concesionesDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource concesionesBindingSource;
        private SICASCentralDataSetTableAdapters.ConcesionesTableAdapter concesionesTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator concesionesBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton concesionesBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView concesionesDataGridView;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.BindingSource tiposConcesionesBindingSource;
        private SICASCentralDataSetTableAdapters.TiposConcesionesTableAdapter tiposConcesionesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label PlacaLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PlacaTextBox;
        private System.Windows.Forms.TextBox NumeroConcesionTextBox;
    }
}