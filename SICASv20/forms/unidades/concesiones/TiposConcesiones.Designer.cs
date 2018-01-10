namespace SICASv20.forms
{
    partial class TiposConcesiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiposConcesiones));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.tiposConcesionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tiposConcesionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.TiposConcesionesTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.tiposConcesionesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.tiposConcesionesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tiposConcesionesDataGridView = new System.Windows.Forms.DataGridView();
            this.tipoConcesionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingNavigator)).BeginInit();
            this.tiposConcesionesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tiposConcesionesBindingSource
            // 
            this.tiposConcesionesBindingSource.DataMember = "TiposConcesiones";
            this.tiposConcesionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // tiposConcesionesTableAdapter
            // 
            this.tiposConcesionesTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.TiposComisionesTableAdapter = null;
            this.tableAdapterManager.TiposConcesionesTableAdapter = this.tiposConcesionesTableAdapter;
            this.tableAdapterManager.TiposContratosTableAdapter = null;
            this.tableAdapterManager.TiposCuentasTableAdapter = null;
            this.tableAdapterManager.TiposEmpresasTableAdapter = null;
            this.tableAdapterManager.TiposLicenciasTableAdapter = null;
            this.tableAdapterManager.UnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = null;
            this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
            // 
            // tiposConcesionesBindingNavigator
            // 
            this.tiposConcesionesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tiposConcesionesBindingNavigator.BindingSource = this.tiposConcesionesBindingSource;
            this.tiposConcesionesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tiposConcesionesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tiposConcesionesBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tiposConcesionesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tiposConcesionesBindingNavigatorSaveItem});
            this.tiposConcesionesBindingNavigator.Location = new System.Drawing.Point(25, 33);
            this.tiposConcesionesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tiposConcesionesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tiposConcesionesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tiposConcesionesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tiposConcesionesBindingNavigator.Name = "tiposConcesionesBindingNavigator";
            this.tiposConcesionesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tiposConcesionesBindingNavigator.Size = new System.Drawing.Size(278, 25);
            this.tiposConcesionesBindingNavigator.TabIndex = 0;
            this.tiposConcesionesBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
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
            // tiposConcesionesBindingNavigatorSaveItem
            // 
            this.tiposConcesionesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tiposConcesionesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tiposConcesionesBindingNavigatorSaveItem.Image")));
            this.tiposConcesionesBindingNavigatorSaveItem.Name = "tiposConcesionesBindingNavigatorSaveItem";
            this.tiposConcesionesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tiposConcesionesBindingNavigatorSaveItem.Text = "Save Data";
            this.tiposConcesionesBindingNavigatorSaveItem.Click += new System.EventHandler(this.tiposConcesionesBindingNavigatorSaveItem_Click);
            // 
            // tiposConcesionesDataGridView
            // 
            this.tiposConcesionesDataGridView.AutoGenerateColumns = false;
            this.tiposConcesionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tiposConcesionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoConcesionIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.tiposConcesionesDataGridView.DataSource = this.tiposConcesionesBindingSource;
            this.tiposConcesionesDataGridView.Location = new System.Drawing.Point(25, 78);
            this.tiposConcesionesDataGridView.Name = "tiposConcesionesDataGridView";
            this.tiposConcesionesDataGridView.Size = new System.Drawing.Size(909, 568);
            this.tiposConcesionesDataGridView.TabIndex = 1;
            // 
            // tipoConcesionIDDataGridViewTextBoxColumn
            // 
            this.tipoConcesionIDDataGridViewTextBoxColumn.DataPropertyName = "TipoConcesion_ID";
            this.tipoConcesionIDDataGridViewTextBoxColumn.HeaderText = "TipoConcesion_ID";
            this.tipoConcesionIDDataGridViewTextBoxColumn.Name = "tipoConcesionIDDataGridViewTextBoxColumn";
            this.tipoConcesionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tiposConcesionesDataGridView);
            this.groupBox1.Controls.Add(this.tiposConcesionesBindingNavigator);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 675);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de concesiones";
            // 
            // TiposConcesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.groupBox1);
            this.Name = "TiposConcesiones";
            this.Text = "TiposConcesiones";
            this.Load += new System.EventHandler(this.TiposConcesiones_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesBindingNavigator)).EndInit();
            this.tiposConcesionesBindingNavigator.ResumeLayout(false);
            this.tiposConcesionesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposConcesionesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource tiposConcesionesBindingSource;
        private SICASCentralDataSetTableAdapters.TiposConcesionesTableAdapter tiposConcesionesTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tiposConcesionesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tiposConcesionesBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView tiposConcesionesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoConcesionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}