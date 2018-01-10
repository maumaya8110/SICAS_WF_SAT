namespace SICASv20.forms
{
    partial class BusquedaConductor
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
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.Conductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.EstacionComboBox = new System.Windows.Forms.ComboBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vista_ConductoresDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conductor_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
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
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(675, 19);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 23);
            this.ConsultarButton.TabIndex = 17;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // Conductor_IDTextBox
            // 
            this.Conductor_IDTextBox.Location = new System.Drawing.Point(96, 21);
            this.Conductor_IDTextBox.Name = "Conductor_IDTextBox";
            this.Conductor_IDTextBox.Size = new System.Drawing.Size(81, 20);
            this.Conductor_IDTextBox.TabIndex = 15;
            // 
            // EstacionComboBox
            // 
            this.EstacionComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionComboBox.DisplayMember = "Nombre";
            this.EstacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionComboBox.FormattingEnabled = true;
            this.EstacionComboBox.Location = new System.Drawing.Point(530, 21);
            this.EstacionComboBox.Name = "EstacionComboBox";
            this.EstacionComboBox.Size = new System.Drawing.Size(121, 21);
            this.EstacionComboBox.TabIndex = 14;
            this.EstacionComboBox.ValueMember = "Estacion_ID";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(245, 21);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(216, 20);
            this.NombreTextBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Estación:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Conductor ID:";
            // 
            // vista_ConductoresDataGridView
            // 
            this.vista_ConductoresDataGridView.AllowUserToAddRows = false;
            this.vista_ConductoresDataGridView.AllowUserToDeleteRows = false;
            this.vista_ConductoresDataGridView.AutoGenerateColumns = false;
            this.vista_ConductoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ConductoresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Conductor_IDColumn,
            this.dataGridViewTextBoxColumn3,
            this.NombreColumn,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.vista_ConductoresDataGridView.DataSource = this.vista_ConductoresBindingSource;
            this.vista_ConductoresDataGridView.Location = new System.Drawing.Point(12, 59);
            this.vista_ConductoresDataGridView.Name = "vista_ConductoresDataGridView";
            this.vista_ConductoresDataGridView.ReadOnly = true;
            this.vista_ConductoresDataGridView.Size = new System.Drawing.Size(836, 350);
            this.vista_ConductoresDataGridView.TabIndex = 10;
            this.vista_ConductoresDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_ConductoresDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Estacion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Estacion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Conductor_IDColumn
            // 
            this.Conductor_IDColumn.DataPropertyName = "Conductor_ID";
            this.Conductor_IDColumn.HeaderText = "Conductor_ID";
            this.Conductor_IDColumn.Name = "Conductor_IDColumn";
            this.Conductor_IDColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Rfc";
            this.dataGridViewTextBoxColumn3.HeaderText = "Rfc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // NombreColumn
            // 
            this.NombreColumn.DataPropertyName = "Nombre";
            this.NombreColumn.HeaderText = "Nombre";
            this.NombreColumn.Name = "NombreColumn";
            this.NombreColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Domicilio";
            this.dataGridViewTextBoxColumn5.HeaderText = "Domicilio";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ciudad";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ciudad";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Entidad";
            this.dataGridViewTextBoxColumn7.HeaderText = "Entidad";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Telefono";
            this.dataGridViewTextBoxColumn8.HeaderText = "Telefono";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Telefono2";
            this.dataGridViewTextBoxColumn9.HeaderText = "Telefono2";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Movil";
            this.dataGridViewTextBoxColumn10.HeaderText = "Movil";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Telefono_Aval";
            this.dataGridViewTextBoxColumn11.HeaderText = "Telefono_Aval";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // BusquedaConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 441);
            this.Controls.Add(this.ConsultarButton);
            this.Controls.Add(this.Conductor_IDTextBox);
            this.Controls.Add(this.EstacionComboBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vista_ConductoresDataGridView);
            this.Name = "BusquedaConductor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Conductor";
            this.Load += new System.EventHandler(this.BusquedaConductor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ConductoresDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource vista_ConductoresBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Vista_ConductoresTableAdapter vista_ConductoresTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.TextBox Conductor_IDTextBox;
        private System.Windows.Forms.ComboBox EstacionComboBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView vista_ConductoresDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
    }
}