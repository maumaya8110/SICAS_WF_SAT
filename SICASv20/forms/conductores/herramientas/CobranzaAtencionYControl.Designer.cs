namespace SICASv20.forms
{
    partial class CobranzaAtencionYControl
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
            this.sICASCentralQuerysIIDataSet = new SICASv20.SICASCentralQuerysIIDataSet();
            this.reporte_CobranzaAtencionYControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_CobranzaAtencionYControlTableAdapter = new SICASv20.SICASCentralQuerysIIDataSetTableAdapters.Reporte_CobranzaAtencionYControlTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralQuerysIIDataSetTableAdapters.TableAdapterManager();
            this.reporte_CobranzaAtencionYControlDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.UnidadTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HistorialColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contratoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otrosCargosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargosEstacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometrajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoATratarCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CronoCascoCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TerminalDatosCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BloquearConductorCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MensajeACajaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conductor_IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysIIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_CobranzaAtencionYControlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_CobranzaAtencionYControlDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sICASCentralQuerysIIDataSet
            // 
            this.sICASCentralQuerysIIDataSet.DataSetName = "SICASCentralQuerysIIDataSet";
            this.sICASCentralQuerysIIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporte_CobranzaAtencionYControlBindingSource
            // 
            this.reporte_CobranzaAtencionYControlBindingSource.DataSource = typeof(SICASv20.Entities.Vista_CobranzaAtencionYControl);
            // 
            // reporte_CobranzaAtencionYControlTableAdapter
            // 
            this.reporte_CobranzaAtencionYControlTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralQuerysIIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reporte_CobranzaAtencionYControlDataGridView
            // 
            this.reporte_CobranzaAtencionYControlDataGridView.AllowUserToAddRows = false;
            this.reporte_CobranzaAtencionYControlDataGridView.AllowUserToDeleteRows = false;
            this.reporte_CobranzaAtencionYControlDataGridView.AutoGenerateColumns = false;
            this.reporte_CobranzaAtencionYControlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reporte_CobranzaAtencionYControlDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HistorialColumn,
            this.Empresa,
            this.Estacion,
            this.contratoIDDataGridViewTextBoxColumn,
            this.unidadDataGridViewTextBoxColumn,
            this.conductorDataGridViewTextBoxColumn,
            this.rentasDataGridViewTextBoxColumn,
            this.otrosCargosDataGridViewTextBoxColumn,
            this.cargosEstacionDataGridViewTextBoxColumn,
            this.sCPDataGridViewTextBoxColumn,
            this.kilometrajeDataGridViewTextBoxColumn,
            this.SaldoATratarCol,
            this.CronoCascoCol,
            this.TerminalDatosCol,
            this.BloquearConductorCol,
            this.MensajeACajaCol,
            this.copiaDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn,
            this.Conductor_IDCol});
            this.reporte_CobranzaAtencionYControlDataGridView.DataSource = this.reporte_CobranzaAtencionYControlBindingSource;
            this.reporte_CobranzaAtencionYControlDataGridView.Location = new System.Drawing.Point(19, 107);
            this.reporte_CobranzaAtencionYControlDataGridView.Name = "reporte_CobranzaAtencionYControlDataGridView";
            this.reporte_CobranzaAtencionYControlDataGridView.ReadOnly = true;
            this.reporte_CobranzaAtencionYControlDataGridView.Size = new System.Drawing.Size(950, 470);
            this.reporte_CobranzaAtencionYControlDataGridView.TabIndex = 2;
            this.reporte_CobranzaAtencionYControlDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reporte_CobranzaAtencionYControlDataGridView_CellClick);            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.UnidadTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EmpresasComboBox);
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.reporte_CobranzaAtencionYControlDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 646);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cobranza, Atención y Control";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(850, 59);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(119, 31);
            this.ExportarButton.TabIndex = 30;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.Location = new System.Drawing.Point(91, 60);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.Size = new System.Drawing.Size(346, 21);
            this.ConductorTextBox.TabIndex = 29;
            // 
            // UnidadTextBox
            // 
            this.UnidadTextBox.Location = new System.Drawing.Point(91, 34);
            this.UnidadTextBox.Name = "UnidadTextBox";
            this.UnidadTextBox.Size = new System.Drawing.Size(135, 21);
            this.UnidadTextBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Conductor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Unidad:";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(850, 25);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(119, 31);
            this.BuscarButton.TabIndex = 25;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Estación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Empresa:";
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.empresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(527, 34);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(300, 23);
            this.EmpresasComboBox.TabIndex = 21;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(527, 63);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(300, 23);
            this.EstacionesComboBox.TabIndex = 22;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // HistorialColumn
            // 
            this.HistorialColumn.HeaderText = "";
            this.HistorialColumn.Name = "HistorialColumn";
            this.HistorialColumn.ReadOnly = true;
            this.HistorialColumn.Text = "Historial";
            this.HistorialColumn.UseColumnTextForLinkValue = true;
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // Estacion
            // 
            this.Estacion.DataPropertyName = "Estacion";
            this.Estacion.HeaderText = "Estacion";
            this.Estacion.Name = "Estacion";
            this.Estacion.ReadOnly = true;
            // 
            // contratoIDDataGridViewTextBoxColumn
            // 
            this.contratoIDDataGridViewTextBoxColumn.DataPropertyName = "Contrato_ID";
            this.contratoIDDataGridViewTextBoxColumn.HeaderText = "Contrato_ID";
            this.contratoIDDataGridViewTextBoxColumn.Name = "contratoIDDataGridViewTextBoxColumn";
            this.contratoIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadDataGridViewTextBoxColumn
            // 
            this.unidadDataGridViewTextBoxColumn.DataPropertyName = "Unidad";
            this.unidadDataGridViewTextBoxColumn.HeaderText = "Unidad";
            this.unidadDataGridViewTextBoxColumn.Name = "unidadDataGridViewTextBoxColumn";
            this.unidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rentasDataGridViewTextBoxColumn
            // 
            this.rentasDataGridViewTextBoxColumn.DataPropertyName = "Rentas";
            this.rentasDataGridViewTextBoxColumn.HeaderText = "Rentas";
            this.rentasDataGridViewTextBoxColumn.Name = "rentasDataGridViewTextBoxColumn";
            this.rentasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // otrosCargosDataGridViewTextBoxColumn
            // 
            this.otrosCargosDataGridViewTextBoxColumn.DataPropertyName = "OtrosCargos";
            this.otrosCargosDataGridViewTextBoxColumn.HeaderText = "OtrosCargos";
            this.otrosCargosDataGridViewTextBoxColumn.Name = "otrosCargosDataGridViewTextBoxColumn";
            this.otrosCargosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cargosEstacionDataGridViewTextBoxColumn
            // 
            this.cargosEstacionDataGridViewTextBoxColumn.DataPropertyName = "CargosEstacion";
            this.cargosEstacionDataGridViewTextBoxColumn.HeaderText = "CargosEstacion";
            this.cargosEstacionDataGridViewTextBoxColumn.Name = "cargosEstacionDataGridViewTextBoxColumn";
            this.cargosEstacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sCPDataGridViewTextBoxColumn
            // 
            this.sCPDataGridViewTextBoxColumn.DataPropertyName = "SCP";
            this.sCPDataGridViewTextBoxColumn.HeaderText = "SCP";
            this.sCPDataGridViewTextBoxColumn.Name = "sCPDataGridViewTextBoxColumn";
            this.sCPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kilometrajeDataGridViewTextBoxColumn
            // 
            this.kilometrajeDataGridViewTextBoxColumn.DataPropertyName = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.HeaderText = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.Name = "kilometrajeDataGridViewTextBoxColumn";
            this.kilometrajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SaldoATratarCol
            // 
            this.SaldoATratarCol.DataPropertyName = "SaldoATratar";
            this.SaldoATratarCol.HeaderText = "SaldoATratar";
            this.SaldoATratarCol.Name = "SaldoATratarCol";
            this.SaldoATratarCol.ReadOnly = true;
            // 
            // CronoCascoCol
            // 
            this.CronoCascoCol.DataPropertyName = "Cronocasco";
            this.CronoCascoCol.HeaderText = "Cronocasco";
            this.CronoCascoCol.Name = "CronoCascoCol";
            this.CronoCascoCol.ReadOnly = true;
            // 
            // TerminalDatosCol
            // 
            this.TerminalDatosCol.DataPropertyName = "TerminalDatos";
            this.TerminalDatosCol.HeaderText = "TerminalDatos";
            this.TerminalDatosCol.Name = "TerminalDatosCol";
            this.TerminalDatosCol.ReadOnly = true;
            // 
            // BloquearConductorCol
            // 
            this.BloquearConductorCol.DataPropertyName = "BloquearConductor";
            this.BloquearConductorCol.HeaderText = "BloquearConductor";
            this.BloquearConductorCol.Name = "BloquearConductorCol";
            this.BloquearConductorCol.ReadOnly = true;
            // 
            // MensajeACajaCol
            // 
            this.MensajeACajaCol.DataPropertyName = "MensajeACaja";
            this.MensajeACajaCol.HeaderText = "MensajeACaja";
            this.MensajeACajaCol.Name = "MensajeACajaCol";
            this.MensajeACajaCol.ReadOnly = true;
            // 
            // copiaDataGridViewTextBoxColumn
            // 
            this.copiaDataGridViewTextBoxColumn.DataPropertyName = "Copia";
            this.copiaDataGridViewTextBoxColumn.HeaderText = "Copia";
            this.copiaDataGridViewTextBoxColumn.Name = "copiaDataGridViewTextBoxColumn";
            this.copiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Conductor_IDCol
            // 
            this.Conductor_IDCol.DataPropertyName = "Conductor_ID";
            this.Conductor_IDCol.HeaderText = "Conductor_ID";
            this.Conductor_IDCol.Name = "Conductor_IDCol";
            this.Conductor_IDCol.ReadOnly = true;
            this.Conductor_IDCol.Visible = false;
            // 
            // CobranzaAtencionYControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Name = "CobranzaAtencionYControl";
            this.Text = "CobranzaAtencionYControl";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysIIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_CobranzaAtencionYControlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_CobranzaAtencionYControlDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralQuerysIIDataSet sICASCentralQuerysIIDataSet;
        private System.Windows.Forms.BindingSource reporte_CobranzaAtencionYControlBindingSource;
        private SICASCentralQuerysIIDataSetTableAdapters.Reporte_CobranzaAtencionYControlTableAdapter reporte_CobranzaAtencionYControlTableAdapter;
        private SICASCentralQuerysIIDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView reporte_CobranzaAtencionYControlDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.TextBox UnidadTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.DataGridViewLinkColumn HistorialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otrosCargosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargosEstacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometrajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoATratarCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CronoCascoCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TerminalDatosCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BloquearConductorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MensajeACajaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn copiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conductor_IDCol;
    }
}