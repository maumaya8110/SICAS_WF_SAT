namespace SICASv20.forms
{
    partial class LicenciasVencidas
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
            this.get_LicenciasVencidasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_LicenciasVencidasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_LicenciasVencidasTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            this.get_LicenciasVencidasDataGridView = new System.Windows.Forms.DataGridView();
            this.Estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Actualizar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Conductor_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_LicenciasVencidasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_LicenciasVencidasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // get_LicenciasVencidasBindingSource
            // 
            this.get_LicenciasVencidasBindingSource.DataMember = "Get_LicenciasVencidas";
            this.get_LicenciasVencidasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_LicenciasVencidasTableAdapter
            // 
            this.get_LicenciasVencidasTableAdapter.ClearBeforeFill = true;
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
            // get_LicenciasVencidasDataGridView
            // 
            this.get_LicenciasVencidasDataGridView.AllowUserToAddRows = false;
            this.get_LicenciasVencidasDataGridView.AllowUserToDeleteRows = false;
            this.get_LicenciasVencidasDataGridView.AutoGenerateColumns = false;
            this.get_LicenciasVencidasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.get_LicenciasVencidasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Actualizar,
            this.Conductor_ID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.get_LicenciasVencidasDataGridView.DataSource = this.get_LicenciasVencidasBindingSource;
            this.get_LicenciasVencidasDataGridView.Location = new System.Drawing.Point(17, 55);
            this.get_LicenciasVencidasDataGridView.Name = "get_LicenciasVencidasDataGridView";
            this.get_LicenciasVencidasDataGridView.ReadOnly = true;
            this.get_LicenciasVencidasDataGridView.Size = new System.Drawing.Size(944, 578);
            this.get_LicenciasVencidasDataGridView.TabIndex = 2;
            this.get_LicenciasVencidasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.get_LicenciasVencidasDataGridView_CellContentClick);
            this.get_LicenciasVencidasDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.get_LicenciasVencidasDataGridView_DataBindingComplete);
            // 
            // Estacion_IDComboBox
            // 
            this.Estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.Estacion_IDComboBox.DisplayMember = "Nombre";
            this.Estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estacion_IDComboBox.FormattingEnabled = true;
            this.Estacion_IDComboBox.Location = new System.Drawing.Point(80, 25);
            this.Estacion_IDComboBox.Name = "Estacion_IDComboBox";
            this.Estacion_IDComboBox.Size = new System.Drawing.Size(121, 23);
            this.Estacion_IDComboBox.TabIndex = 3;
            this.Estacion_IDComboBox.ValueMember = "Estacion_ID";
            this.Estacion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.Estacion_IDComboBox_SelectionChangeCommitted);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estación:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.get_LicenciasVencidasDataGridView);
            this.groupBox1.Controls.Add(this.Estacion_IDComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 655);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Licencias vencidas";
            // 
            // Actualizar
            // 
            this.Actualizar.Frozen = true;
            this.Actualizar.HeaderText = "";
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.ReadOnly = true;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseColumnTextForLinkValue = true;
            // 
            // Conductor_ID
            // 
            this.Conductor_ID.DataPropertyName = "Conductor_ID";
            this.Conductor_ID.Frozen = true;
            this.Conductor_ID.HeaderText = "Conductor_ID";
            this.Conductor_ID.Name = "Conductor_ID";
            this.Conductor_ID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Apellidos";
            this.dataGridViewTextBoxColumn2.HeaderText = "Apellidos";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoLicencia";
            this.dataGridViewTextBoxColumn4.HeaderText = "TipoLicencia";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FolioLicencia";
            this.dataGridViewTextBoxColumn5.HeaderText = "FolioLicencia";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "VenceLicencia";
            this.dataGridViewTextBoxColumn6.HeaderText = "VenceLicencia";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // LicenciasVencidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "LicenciasVencidas";
            this.Text = "LicenciasVencidas";            
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_LicenciasVencidasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.get_LicenciasVencidasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource get_LicenciasVencidasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_LicenciasVencidasTableAdapter get_LicenciasVencidasTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView get_LicenciasVencidasDataGridView;
        private System.Windows.Forms.ComboBox Estacion_IDComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Actualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}