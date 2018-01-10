namespace SICASv20.forms
{
    partial class Contratos_DatosConductorUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.TiposContratosComboBox = new System.Windows.Forms.ComboBox();
            this.tiposContratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ConductoresDataGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.conductorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domicilioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NombreConductorTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Conductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.selectEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConductoresDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.TiposContratosComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ConductoresDataGridView);
            this.groupBox1.Controls.Add(this.NombreConductorTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Conductor_IDTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EmpresasComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1200, 628);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistente de Contratos: Conductor";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(825, 175);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(102, 28);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // TiposContratosComboBox
            // 
            this.TiposContratosComboBox.DataSource = this.tiposContratosBindingSource;
            this.TiposContratosComboBox.DisplayMember = "Nombre";
            this.TiposContratosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiposContratosComboBox.FormattingEnabled = true;
            this.TiposContratosComboBox.Location = new System.Drawing.Point(289, 38);
            this.TiposContratosComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.TiposContratosComboBox.Name = "TiposContratosComboBox";
            this.TiposContratosComboBox.Size = new System.Drawing.Size(315, 26);
            this.TiposContratosComboBox.TabIndex = 10;
            this.TiposContratosComboBox.ValueMember = "TipoContrato_ID";
            // 
            // tiposContratosBindingSource
            // 
            this.tiposContratosBindingSource.DataSource = typeof(SICASv20.Entities.TiposContratos);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seleccione un tipo de contrato:";
            // 
            // ConductoresDataGridView
            // 
            this.ConductoresDataGridView.AllowUserToAddRows = false;
            this.ConductoresDataGridView.AllowUserToDeleteRows = false;
            this.ConductoresDataGridView.AutoGenerateColumns = false;
            this.ConductoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConductoresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.conductorIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidosDataGridViewTextBoxColumn,
            this.domicilioDataGridViewTextBoxColumn,
            this.ciudadDataGridViewTextBoxColumn,
            this.entidadDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.telefono2DataGridViewTextBoxColumn,
            this.movilDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.rFCDataGridViewTextBoxColumn,
            this.estacionIDDataGridViewTextBoxColumn});
            this.ConductoresDataGridView.DataSource = this.conductoresBindingSource;
            this.ConductoresDataGridView.Location = new System.Drawing.Point(26, 222);
            this.ConductoresDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ConductoresDataGridView.Name = "ConductoresDataGridView";
            this.ConductoresDataGridView.ReadOnly = true;
            this.ConductoresDataGridView.Size = new System.Drawing.Size(1151, 384);
            this.ConductoresDataGridView.TabIndex = 8;
            this.ConductoresDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConductoresDataGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // conductorIDDataGridViewTextBoxColumn
            // 
            this.conductorIDDataGridViewTextBoxColumn.DataPropertyName = "Conductor_ID";
            this.conductorIDDataGridViewTextBoxColumn.HeaderText = "Conductor_ID";
            this.conductorIDDataGridViewTextBoxColumn.Name = "conductorIDDataGridViewTextBoxColumn";
            this.conductorIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidosDataGridViewTextBoxColumn
            // 
            this.apellidosDataGridViewTextBoxColumn.DataPropertyName = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.HeaderText = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.Name = "apellidosDataGridViewTextBoxColumn";
            this.apellidosDataGridViewTextBoxColumn.ReadOnly = true;
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
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rFCDataGridViewTextBoxColumn
            // 
            this.rFCDataGridViewTextBoxColumn.DataPropertyName = "RFC";
            this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
            this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
            this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estacionIDDataGridViewTextBoxColumn
            // 
            this.estacionIDDataGridViewTextBoxColumn.DataPropertyName = "Estacion_ID";
            this.estacionIDDataGridViewTextBoxColumn.HeaderText = "Estacion_ID";
            this.estacionIDDataGridViewTextBoxColumn.Name = "estacionIDDataGridViewTextBoxColumn";
            this.estacionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conductoresBindingSource
            // 
            this.conductoresBindingSource.DataSource = typeof(SICASv20.Entities.Conductores);
            // 
            // NombreConductorTextBox
            // 
            this.NombreConductorTextBox.Location = new System.Drawing.Point(289, 176);
            this.NombreConductorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NombreConductorTextBox.Name = "NombreConductorTextBox";
            this.NombreConductorTextBox.Size = new System.Drawing.Size(489, 24);
            this.NombreConductorTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Capture el nombre de un conductor:";
            // 
            // Conductor_IDTextBox
            // 
            this.Conductor_IDTextBox.Location = new System.Drawing.Point(289, 144);
            this.Conductor_IDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Conductor_IDTextBox.Name = "Conductor_IDTextBox";
            this.Conductor_IDTextBox.Size = new System.Drawing.Size(127, 24);
            this.Conductor_IDTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Capture el folio de un conductor:";
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(289, 108);
            this.EstacionesComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(315, 26);
            this.EstacionesComboBox.TabIndex = 3;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            this.EstacionesComboBox.SelectedIndexChanged += new System.EventHandler(this.EstacionesComboBox_SelectedIndexChanged);
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione una estación:";
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.selectEmpresasInternasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(289, 73);
            this.EmpresasComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(315, 26);
            this.EmpresasComboBox.TabIndex = 1;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            // 
            // selectEmpresasInternasBindingSource
            // 
            this.selectEmpresasInternasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una empresa:";
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Location = new System.Drawing.Point(1092, 638);
            this.SiguienteButton.Margin = new System.Windows.Forms.Padding(4);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(112, 37);
            this.SiguienteButton.TabIndex = 20;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // Contratos_DatosConductorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Contratos_DatosConductorUC";
            this.Size = new System.Drawing.Size(1207, 679);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConductoresDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TiposContratosComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView ConductoresDataGridView;
        private System.Windows.Forms.TextBox NombreConductorTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Conductor_IDTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
	   private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.BindingSource selectEmpresasInternasBindingSource;
        private System.Windows.Forms.BindingSource tiposContratosBindingSource;
        private System.Windows.Forms.BindingSource conductoresBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domicilioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacionIDDataGridViewTextBoxColumn;
        internal System.Windows.Forms.ComboBox EmpresasComboBox;
    }
}
