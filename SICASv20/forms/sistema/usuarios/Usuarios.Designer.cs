namespace SICASv20.forms
{
    partial class Usuarios
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
            this.vista_UsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_UsuariosTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Vista_UsuariosTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            this.vista_UsuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.Actualizar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Usuario_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.EstacionComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.EmpresaComboBox = new System.Windows.Forms.ComboBox();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ApellidosTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vista_UsuariosBindingSource
            // 
            this.vista_UsuariosBindingSource.DataMember = "Vista_Usuarios";
            this.vista_UsuariosBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // vista_UsuariosTableAdapter
            // 
            this.vista_UsuariosTableAdapter.ClearBeforeFill = true;
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
            // vista_UsuariosDataGridView
            // 
            this.vista_UsuariosDataGridView.AllowUserToAddRows = false;
            this.vista_UsuariosDataGridView.AllowUserToDeleteRows = false;
            this.vista_UsuariosDataGridView.AutoGenerateColumns = false;
            this.vista_UsuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_UsuariosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Actualizar,
            this.Usuario_ID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.vista_UsuariosDataGridView.DataSource = this.vista_UsuariosBindingSource;
            this.vista_UsuariosDataGridView.Location = new System.Drawing.Point(19, 113);
            this.vista_UsuariosDataGridView.Name = "vista_UsuariosDataGridView";
            this.vista_UsuariosDataGridView.ReadOnly = true;
            this.vista_UsuariosDataGridView.Size = new System.Drawing.Size(851, 470);
            this.vista_UsuariosDataGridView.TabIndex = 2;
            this.vista_UsuariosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_UsuariosDataGridView_CellContentClick);
            // 
            // Actualizar
            // 
            this.Actualizar.DataPropertyName = "Usuario_ID";
            this.Actualizar.HeaderText = "";
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.ReadOnly = true;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseColumnTextForLinkValue = true;
            // 
            // Usuario_ID
            // 
            this.Usuario_ID.DataPropertyName = "Usuario_ID";
            this.Usuario_ID.HeaderText = "Usuario_ID";
            this.Usuario_ID.Name = "Usuario_ID";
            this.Usuario_ID.ReadOnly = true;
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
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Apellidos";
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellidos";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn4.HeaderText = "Email";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Activo";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Activo";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Empresa";
            this.dataGridViewTextBoxColumn5.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Estacion";
            this.dataGridViewTextBoxColumn6.HeaderText = "Estacion";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.vista_UsuariosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(901, 626);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración de Usuarios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportarButton);
            this.groupBox2.Controls.Add(this.ConsultarButton);
            this.groupBox2.Controls.Add(this.EstacionComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.EmpresaComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ApellidosTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NombreTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(19, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(851, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paramétros de consulta";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(749, 44);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(75, 27);
            this.ExportarButton.TabIndex = 9;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(749, 16);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 27);
            this.ConsultarButton.TabIndex = 8;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // EstacionComboBox
            // 
            this.EstacionComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionComboBox.DisplayMember = "Nombre";
            this.EstacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionComboBox.FormattingEnabled = true;
            this.EstacionComboBox.Location = new System.Drawing.Point(600, 36);
            this.EstacionComboBox.Name = "EstacionComboBox";
            this.EstacionComboBox.Size = new System.Drawing.Size(121, 23);
            this.EstacionComboBox.TabIndex = 7;
            this.EstacionComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estación:";
            // 
            // EmpresaComboBox
            // 
            this.EmpresaComboBox.DataSource = this.empresasBindingSource;
            this.EmpresaComboBox.DisplayMember = "Nombre";
            this.EmpresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresaComboBox.FormattingEnabled = true;
            this.EmpresaComboBox.Location = new System.Drawing.Point(406, 35);
            this.EmpresaComboBox.Name = "EmpresaComboBox";
            this.EmpresaComboBox.Size = new System.Drawing.Size(121, 23);
            this.EmpresaComboBox.TabIndex = 5;
            this.EmpresaComboBox.ValueMember = "Empresa_ID";
            this.EmpresaComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresaComboBox_SelectionChangeCommitted);
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Empresa:";
            // 
            // ApellidosTextBox
            // 
            this.ApellidosTextBox.Location = new System.Drawing.Point(238, 36);
            this.ApellidosTextBox.Name = "ApellidosTextBox";
            this.ApellidosTextBox.Size = new System.Drawing.Size(100, 21);
            this.ApellidosTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(69, 37);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(100, 21);
            this.NombreTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // ExportarSaveFileDialog
            // 
            this.ExportarSaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportarSaveFileDialog_FileOk);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource vista_UsuariosBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Vista_UsuariosTableAdapter vista_UsuariosTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView vista_UsuariosDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.ComboBox EstacionComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EmpresaComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ApellidosTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn Actualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.SaveFileDialog ExportarSaveFileDialog;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
    }
}