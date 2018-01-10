﻿namespace SICASv20.forms
{
    partial class MarcasUnidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcasUnidades));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.marcasUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marcasUnidadesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.MarcasUnidadesTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.marcasUnidadesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.marcasUnidadesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.marcasUnidadesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesBindingNavigator)).BeginInit();
            this.marcasUnidadesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // marcasUnidadesBindingSource
            // 
            this.marcasUnidadesBindingSource.DataMember = "MarcasUnidades";
            this.marcasUnidadesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // marcasUnidadesTableAdapter
            // 
            this.marcasUnidadesTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.MarcasUnidadesTableAdapter = this.marcasUnidadesTableAdapter;
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
            // marcasUnidadesBindingNavigator
            // 
            this.marcasUnidadesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.marcasUnidadesBindingNavigator.BindingSource = this.marcasUnidadesBindingSource;
            this.marcasUnidadesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.marcasUnidadesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.marcasUnidadesBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.marcasUnidadesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.marcasUnidadesBindingNavigatorSaveItem});
            this.marcasUnidadesBindingNavigator.Location = new System.Drawing.Point(31, 38);
            this.marcasUnidadesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.marcasUnidadesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.marcasUnidadesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.marcasUnidadesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.marcasUnidadesBindingNavigator.Name = "marcasUnidadesBindingNavigator";
            this.marcasUnidadesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.marcasUnidadesBindingNavigator.Size = new System.Drawing.Size(278, 25);
            this.marcasUnidadesBindingNavigator.TabIndex = 0;
            this.marcasUnidadesBindingNavigator.Text = "bindingNavigator1";
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
            // marcasUnidadesBindingNavigatorSaveItem
            // 
            this.marcasUnidadesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.marcasUnidadesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("marcasUnidadesBindingNavigatorSaveItem.Image")));
            this.marcasUnidadesBindingNavigatorSaveItem.Name = "marcasUnidadesBindingNavigatorSaveItem";
            this.marcasUnidadesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.marcasUnidadesBindingNavigatorSaveItem.Text = "Save Data";
            this.marcasUnidadesBindingNavigatorSaveItem.Click += new System.EventHandler(this.marcasUnidadesBindingNavigatorSaveItem_Click);
            // 
            // marcasUnidadesDataGridView
            // 
            this.marcasUnidadesDataGridView.AutoGenerateColumns = false;
            this.marcasUnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marcasUnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.marcasUnidadesDataGridView.DataSource = this.marcasUnidadesBindingSource;
            this.marcasUnidadesDataGridView.Location = new System.Drawing.Point(31, 84);
            this.marcasUnidadesDataGridView.Name = "marcasUnidadesDataGridView";
            this.marcasUnidadesDataGridView.Size = new System.Drawing.Size(930, 568);
            this.marcasUnidadesDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MarcaUnidad_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "MarcaUnidad_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.marcasUnidadesDataGridView);
            this.groupBox1.Controls.Add(this.marcasUnidadesBindingNavigator);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 675);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marcas de unidades";
            // 
            // MarcasUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.groupBox1);
            this.Name = "MarcasUnidades";
            this.Text = "MarcasUnidades";
            this.Load += new System.EventHandler(this.MarcasUnidades_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesBindingNavigator)).EndInit();
            this.marcasUnidadesBindingNavigator.ResumeLayout(false);
            this.marcasUnidadesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marcasUnidadesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource marcasUnidadesBindingSource;
        private SICASCentralDataSetTableAdapters.MarcasUnidadesTableAdapter marcasUnidadesTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator marcasUnidadesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton marcasUnidadesBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView marcasUnidadesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}