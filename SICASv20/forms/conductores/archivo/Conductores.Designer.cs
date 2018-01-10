namespace SICASv20.forms
{
    partial class Conductores
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
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.vista_ConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_ConductoresTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Vista_ConductoresTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            this.vista_ConductoresDataGridView = new System.Windows.Forms.DataGridView();
            this.ConductoresContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verEstadoDeCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeSaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarInformaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialDeCobranzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EstacionComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getSelectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Conductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.get_SelectEstacionesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectEstacionesTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ExportarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.OptionsColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.estacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conductor_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domicilioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoAvalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresDataGridView)).BeginInit();
            this.ConductoresContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vistaConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vista_ConductoresBindingSource
            // 
            this.vista_ConductoresBindingSource.DataMember = "Vista_Conductores";
            this.vista_ConductoresBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // vista_ConductoresTableAdapter
            // 
            this.vista_ConductoresTableAdapter.ClearBeforeFill = true;
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
            // vista_ConductoresDataGridView
            // 
            this.vista_ConductoresDataGridView.AllowUserToAddRows = false;
            this.vista_ConductoresDataGridView.AllowUserToDeleteRows = false;
            this.vista_ConductoresDataGridView.AutoGenerateColumns = false;
            this.vista_ConductoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ConductoresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.OptionsColumn,
            this.estacionDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.Conductor_ID,
            this.rfcDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.domicilioDataGridViewTextBoxColumn,
            this.ciudadDataGridViewTextBoxColumn,
            this.entidadDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.telefono2DataGridViewTextBoxColumn,
            this.movilDataGridViewTextBoxColumn,
            this.telefonoAvalDataGridViewTextBoxColumn});
            this.vista_ConductoresDataGridView.DataSource = this.vistaConductoresBindingSource;
            this.vista_ConductoresDataGridView.Location = new System.Drawing.Point(13, 94);
            this.vista_ConductoresDataGridView.Name = "vista_ConductoresDataGridView";
            this.vista_ConductoresDataGridView.ReadOnly = true;
            this.vista_ConductoresDataGridView.Size = new System.Drawing.Size(970, 482);
            this.vista_ConductoresDataGridView.TabIndex = 2;
            this.vista_ConductoresDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_ConductoresDataGridView_CellContentClick);
            this.vista_ConductoresDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.vista_ConductoresDataGridView_CellMouseUp);
            // 
            // ConductoresContextMenu
            // 
            this.ConductoresContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEstadoDeCuentaToolStripMenuItem,
            this.reporteDeSaldosToolStripMenuItem,
            this.actualizarInformaciónToolStripMenuItem,
            this.verHistorialDeCobranzaToolStripMenuItem});
            this.ConductoresContextMenu.Name = "ConductoresContextMenu";
            this.ConductoresContextMenu.Size = new System.Drawing.Size(204, 114);
            // 
            // verEstadoDeCuentaToolStripMenuItem
            // 
            this.verEstadoDeCuentaToolStripMenuItem.Name = "verEstadoDeCuentaToolStripMenuItem";
            this.verEstadoDeCuentaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.verEstadoDeCuentaToolStripMenuItem.Text = "Ver Estado de Cuenta";
            this.verEstadoDeCuentaToolStripMenuItem.Click += new System.EventHandler(this.verEstadoDeCuentaToolStripMenuItem_Click);
            // 
            // reporteDeSaldosToolStripMenuItem
            // 
            this.reporteDeSaldosToolStripMenuItem.Name = "reporteDeSaldosToolStripMenuItem";
            this.reporteDeSaldosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.reporteDeSaldosToolStripMenuItem.Text = "Reporte de Saldos";
            this.reporteDeSaldosToolStripMenuItem.Click += new System.EventHandler(this.reporteDeSaldosToolStripMenuItem_Click);
            // 
            // actualizarInformaciónToolStripMenuItem
            // 
            this.actualizarInformaciónToolStripMenuItem.Name = "actualizarInformaciónToolStripMenuItem";
            this.actualizarInformaciónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.actualizarInformaciónToolStripMenuItem.Text = "Actualizar información";
            this.actualizarInformaciónToolStripMenuItem.Click += new System.EventHandler(this.actualizarInformaciónToolStripMenuItem_Click);
            // 
            // verHistorialDeCobranzaToolStripMenuItem
            // 
            this.verHistorialDeCobranzaToolStripMenuItem.Name = "verHistorialDeCobranzaToolStripMenuItem";
            this.verHistorialDeCobranzaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.verHistorialDeCobranzaToolStripMenuItem.Text = "Ver historial de cobranza";
            this.verHistorialDeCobranzaToolStripMenuItem.Click += new System.EventHandler(this.verHistorialDeCobranzaToolStripMenuItem_Click);
            // 
            // vistaConductoresBindingSource
            // 
            this.vistaConductoresBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Conductores);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Conductor ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Estación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre:";
            // 
            // EstacionComboBox
            // 
            this.EstacionComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionComboBox.DisplayMember = "Nombre";
            this.EstacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionComboBox.FormattingEnabled = true;
            this.EstacionComboBox.Location = new System.Drawing.Point(531, 20);
            this.EstacionComboBox.Name = "EstacionComboBox";
            this.EstacionComboBox.Size = new System.Drawing.Size(121, 23);
            this.EstacionComboBox.TabIndex = 6;
            this.EstacionComboBox.ValueMember = "Estacion_ID";
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // getSelectEstacionesBindingSource
            // 
            this.getSelectEstacionesBindingSource.DataMember = "Get_SelectEstaciones";
            this.getSelectEstacionesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // Conductor_IDTextBox
            // 
            this.Conductor_IDTextBox.Location = new System.Drawing.Point(97, 20);
            this.Conductor_IDTextBox.Name = "Conductor_IDTextBox";
            this.Conductor_IDTextBox.Size = new System.Drawing.Size(81, 21);
            this.Conductor_IDTextBox.TabIndex = 7;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(246, 20);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(216, 21);
            this.NombreTextBox.TabIndex = 8;
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(745, 14);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 34);
            this.ConsultarButton.TabIndex = 9;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // get_SelectEstacionesTableAdapter
            // 
            this.get_SelectEstacionesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.vista_ConductoresDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 603);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de conductores";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportarButton);
            this.groupBox2.Controls.Add(this.Conductor_IDTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ConsultarButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NombreTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.EstacionComboBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 58);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros de búsqueda";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(826, 14);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(132, 34);
            this.ExportarButton.TabIndex = 34;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Width = 20;
            // 
            // OptionsColumn
            // 
            this.OptionsColumn.ContextMenuStrip = this.ConductoresContextMenu;
            this.OptionsColumn.HeaderText = "";
            this.OptionsColumn.Image = global::SICASv20.Properties.Resources.properties;
            this.OptionsColumn.Name = "OptionsColumn";
            this.OptionsColumn.ReadOnly = true;
            this.OptionsColumn.Width = 20;
            // 
            // estacionDataGridViewTextBoxColumn
            // 
            this.estacionDataGridViewTextBoxColumn.DataPropertyName = "Estacion";
            this.estacionDataGridViewTextBoxColumn.HeaderText = "Estacion";
            this.estacionDataGridViewTextBoxColumn.Name = "estacionDataGridViewTextBoxColumn";
            this.estacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Conductor_ID
            // 
            this.Conductor_ID.DataPropertyName = "Conductor_ID";
            this.Conductor_ID.HeaderText = "Conductor_ID";
            this.Conductor_ID.Name = "Conductor_ID";
            this.Conductor_ID.ReadOnly = true;
            // 
            // rfcDataGridViewTextBoxColumn
            // 
            this.rfcDataGridViewTextBoxColumn.DataPropertyName = "Rfc";
            this.rfcDataGridViewTextBoxColumn.HeaderText = "Rfc";
            this.rfcDataGridViewTextBoxColumn.Name = "rfcDataGridViewTextBoxColumn";
            this.rfcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // domicilioDataGridViewTextBoxColumn
            // 
            this.domicilioDataGridViewTextBoxColumn.DataPropertyName = "Domicilio";
            this.domicilioDataGridViewTextBoxColumn.HeaderText = "Domicilio";
            this.domicilioDataGridViewTextBoxColumn.Name = "domicilioDataGridViewTextBoxColumn";
            this.domicilioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ciudadDataGridViewTextBoxColumn
            // 
            this.ciudadDataGridViewTextBoxColumn.DataPropertyName = "Ciudad";
            this.ciudadDataGridViewTextBoxColumn.HeaderText = "Municipio";
            this.ciudadDataGridViewTextBoxColumn.Name = "ciudadDataGridViewTextBoxColumn";
            this.ciudadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // entidadDataGridViewTextBoxColumn
            // 
            this.entidadDataGridViewTextBoxColumn.DataPropertyName = "Entidad";
            this.entidadDataGridViewTextBoxColumn.HeaderText = "Entidad";
            this.entidadDataGridViewTextBoxColumn.Name = "entidadDataGridViewTextBoxColumn";
            this.entidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefono2DataGridViewTextBoxColumn
            // 
            this.telefono2DataGridViewTextBoxColumn.DataPropertyName = "Telefono2";
            this.telefono2DataGridViewTextBoxColumn.HeaderText = "Telefono2";
            this.telefono2DataGridViewTextBoxColumn.Name = "telefono2DataGridViewTextBoxColumn";
            this.telefono2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // movilDataGridViewTextBoxColumn
            // 
            this.movilDataGridViewTextBoxColumn.DataPropertyName = "Movil";
            this.movilDataGridViewTextBoxColumn.HeaderText = "Movil";
            this.movilDataGridViewTextBoxColumn.Name = "movilDataGridViewTextBoxColumn";
            this.movilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoAvalDataGridViewTextBoxColumn
            // 
            this.telefonoAvalDataGridViewTextBoxColumn.DataPropertyName = "Telefono_Aval";
            this.telefonoAvalDataGridViewTextBoxColumn.HeaderText = "Telefono_Aval";
            this.telefonoAvalDataGridViewTextBoxColumn.Name = "telefonoAvalDataGridViewTextBoxColumn";
            this.telefonoAvalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Conductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "Conductores";
            this.Text = "Conductores";
            this.Load += new System.EventHandler(this.Conductores_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresDataGridView)).EndInit();
            this.ConductoresContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vistaConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource vista_ConductoresBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Vista_ConductoresTableAdapter vista_ConductoresTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView vista_ConductoresDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EstacionComboBox;
        private System.Windows.Forms.TextBox Conductor_IDTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.BindingSource getSelectEstacionesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectEstacionesTableAdapter get_SelectEstacionesTableAdapter;
        private System.Windows.Forms.ContextMenuStrip ConductoresContextMenu;
        private System.Windows.Forms.ToolStripMenuItem verEstadoDeCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeSaldosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarInformaciónToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.SaveFileDialog ExportarSaveFileDialog;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.ToolStripMenuItem verHistorialDeCobranzaToolStripMenuItem;
        private System.Windows.Forms.BindingSource vistaConductoresBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewImageColumn OptionsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domicilioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoAvalDataGridViewTextBoxColumn;

    }
}