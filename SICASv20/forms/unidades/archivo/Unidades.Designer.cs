namespace SICASv20.forms
{
    partial class Unidades
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
            this.vista_UnidadesDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_UnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UnidadesBajaCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Arrendamiento_IDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unidadIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioListaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSerieMotorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarjetaCirculacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometrajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propietarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrendamientoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrendamientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concesionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroConcesionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vista_UnidadesDataGridView
            // 
            this.vista_UnidadesDataGridView.AllowUserToAddRows = false;
            this.vista_UnidadesDataGridView.AllowUserToDeleteRows = false;
            this.vista_UnidadesDataGridView.AutoGenerateColumns = false;
            this.vista_UnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_UnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.unidadIDDataGridViewTextBoxColumn,
            this.empresaDataGridViewTextBoxColumn,
            this.estacionDataGridViewTextBoxColumn,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.anioDataGridViewTextBoxColumn,
            this.precioListaDataGridViewTextBoxColumn,
            this.numeroSerieDataGridViewTextBoxColumn,
            this.numeroSerieMotorDataGridViewTextBoxColumn,
            this.tarjetaCirculacionDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn,
            this.locacionDataGridViewTextBoxColumn,
            this.placasDataGridViewTextBoxColumn,
            this.kilometrajeDataGridViewTextBoxColumn,
            this.propietarioDataGridViewTextBoxColumn,
            this.arrendamientoIDDataGridViewTextBoxColumn,
            this.arrendamientoDataGridViewTextBoxColumn,
            this.concesionIDDataGridViewTextBoxColumn,
            this.numeroConcesionDataGridViewTextBoxColumn,
            this.GPS});
            this.vista_UnidadesDataGridView.DataSource = this.vista_UnidadesBindingSource;
            this.vista_UnidadesDataGridView.Location = new System.Drawing.Point(23, 98);
            this.vista_UnidadesDataGridView.Name = "vista_UnidadesDataGridView";
            this.vista_UnidadesDataGridView.ReadOnly = true;
            this.vista_UnidadesDataGridView.Size = new System.Drawing.Size(959, 512);
            this.vista_UnidadesDataGridView.TabIndex = 2;
            this.vista_UnidadesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_UnidadesDataGridView_CellContentClick);
            this.vista_UnidadesDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.vista_UnidadesDataGridView_DataBindingComplete);
            // 
            // vista_UnidadesBindingSource
            // 
            this.vista_UnidadesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Unidades);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UnidadesBajaCheckBox);
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.EmpresasComboBox);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Arrendamiento_IDTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vista_UnidadesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 627);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de unidades";
            // 
            // UnidadesBajaCheckBox
            // 
            this.UnidadesBajaCheckBox.AutoSize = true;
            this.UnidadesBajaCheckBox.Location = new System.Drawing.Point(677, 30);
            this.UnidadesBajaCheckBox.Name = "UnidadesBajaCheckBox";
            this.UnidadesBajaCheckBox.Size = new System.Drawing.Size(95, 17);
            this.UnidadesBajaCheckBox.TabIndex = 13;
            this.UnidadesBajaCheckBox.Text = "Unidades Baja";
            this.UnidadesBajaCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(822, 51);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(160, 29);
            this.ExportarButton.TabIndex = 12;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(822, 20);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(160, 29);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Estación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Empresa:";
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(313, 55);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(348, 23);
            this.EstacionesComboBox.TabIndex = 8;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.empresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(313, 26);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(348, 23);
            this.EmpresasComboBox.TabIndex = 7;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(139, 26);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(97, 21);
            this.NumeroEconomicoTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unidad:";
            // 
            // Arrendamiento_IDTextBox
            // 
            this.Arrendamiento_IDTextBox.Location = new System.Drawing.Point(139, 55);
            this.Arrendamiento_IDTextBox.Name = "Arrendamiento_IDTextBox";
            this.Arrendamiento_IDTextBox.Size = new System.Drawing.Size(97, 21);
            this.Arrendamiento_IDTextBox.TabIndex = 4;
            this.Arrendamiento_IDTextBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Arrendamiento ID:";
            this.label1.Visible = false;
            // 
            // unidadIDDataGridViewTextBoxColumn
            // 
            this.unidadIDDataGridViewTextBoxColumn.DataPropertyName = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.HeaderText = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.Name = "unidadIDDataGridViewTextBoxColumn";
            this.unidadIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empresaDataGridViewTextBoxColumn
            // 
            this.empresaDataGridViewTextBoxColumn.DataPropertyName = "Empresa";
            this.empresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.empresaDataGridViewTextBoxColumn.Name = "empresaDataGridViewTextBoxColumn";
            this.empresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estacionDataGridViewTextBoxColumn
            // 
            this.estacionDataGridViewTextBoxColumn.DataPropertyName = "Estacion";
            this.estacionDataGridViewTextBoxColumn.HeaderText = "Estacion";
            this.estacionDataGridViewTextBoxColumn.Name = "estacionDataGridViewTextBoxColumn";
            this.estacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anioDataGridViewTextBoxColumn
            // 
            this.anioDataGridViewTextBoxColumn.DataPropertyName = "Anio";
            this.anioDataGridViewTextBoxColumn.HeaderText = "Anio";
            this.anioDataGridViewTextBoxColumn.Name = "anioDataGridViewTextBoxColumn";
            this.anioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioListaDataGridViewTextBoxColumn
            // 
            this.precioListaDataGridViewTextBoxColumn.DataPropertyName = "PrecioLista";
            this.precioListaDataGridViewTextBoxColumn.HeaderText = "PrecioLista";
            this.precioListaDataGridViewTextBoxColumn.Name = "precioListaDataGridViewTextBoxColumn";
            this.precioListaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroSerieDataGridViewTextBoxColumn
            // 
            this.numeroSerieDataGridViewTextBoxColumn.DataPropertyName = "NumeroSerie";
            this.numeroSerieDataGridViewTextBoxColumn.HeaderText = "NumeroSerie";
            this.numeroSerieDataGridViewTextBoxColumn.Name = "numeroSerieDataGridViewTextBoxColumn";
            this.numeroSerieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroSerieMotorDataGridViewTextBoxColumn
            // 
            this.numeroSerieMotorDataGridViewTextBoxColumn.DataPropertyName = "NumeroSerieMotor";
            this.numeroSerieMotorDataGridViewTextBoxColumn.HeaderText = "NumeroSerieMotor";
            this.numeroSerieMotorDataGridViewTextBoxColumn.Name = "numeroSerieMotorDataGridViewTextBoxColumn";
            this.numeroSerieMotorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tarjetaCirculacionDataGridViewTextBoxColumn
            // 
            this.tarjetaCirculacionDataGridViewTextBoxColumn.DataPropertyName = "TarjetaCirculacion";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.HeaderText = "TarjetaCirculacion";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.Name = "tarjetaCirculacionDataGridViewTextBoxColumn";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locacionDataGridViewTextBoxColumn
            // 
            this.locacionDataGridViewTextBoxColumn.DataPropertyName = "Locacion";
            this.locacionDataGridViewTextBoxColumn.HeaderText = "Locacion";
            this.locacionDataGridViewTextBoxColumn.Name = "locacionDataGridViewTextBoxColumn";
            this.locacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placasDataGridViewTextBoxColumn
            // 
            this.placasDataGridViewTextBoxColumn.DataPropertyName = "Placas";
            this.placasDataGridViewTextBoxColumn.HeaderText = "Placas";
            this.placasDataGridViewTextBoxColumn.Name = "placasDataGridViewTextBoxColumn";
            this.placasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kilometrajeDataGridViewTextBoxColumn
            // 
            this.kilometrajeDataGridViewTextBoxColumn.DataPropertyName = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.HeaderText = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.Name = "kilometrajeDataGridViewTextBoxColumn";
            this.kilometrajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // propietarioDataGridViewTextBoxColumn
            // 
            this.propietarioDataGridViewTextBoxColumn.DataPropertyName = "Propietario";
            this.propietarioDataGridViewTextBoxColumn.HeaderText = "Propietario";
            this.propietarioDataGridViewTextBoxColumn.Name = "propietarioDataGridViewTextBoxColumn";
            this.propietarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // arrendamientoIDDataGridViewTextBoxColumn
            // 
            this.arrendamientoIDDataGridViewTextBoxColumn.DataPropertyName = "Arrendamiento_ID";
            this.arrendamientoIDDataGridViewTextBoxColumn.HeaderText = "Arrendamiento_ID";
            this.arrendamientoIDDataGridViewTextBoxColumn.Name = "arrendamientoIDDataGridViewTextBoxColumn";
            this.arrendamientoIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // arrendamientoDataGridViewTextBoxColumn
            // 
            this.arrendamientoDataGridViewTextBoxColumn.DataPropertyName = "Arrendamiento";
            this.arrendamientoDataGridViewTextBoxColumn.HeaderText = "Arrendamiento";
            this.arrendamientoDataGridViewTextBoxColumn.Name = "arrendamientoDataGridViewTextBoxColumn";
            this.arrendamientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // concesionIDDataGridViewTextBoxColumn
            // 
            this.concesionIDDataGridViewTextBoxColumn.DataPropertyName = "Concesion_ID";
            this.concesionIDDataGridViewTextBoxColumn.HeaderText = "Concesion_ID";
            this.concesionIDDataGridViewTextBoxColumn.Name = "concesionIDDataGridViewTextBoxColumn";
            this.concesionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroConcesionDataGridViewTextBoxColumn
            // 
            this.numeroConcesionDataGridViewTextBoxColumn.DataPropertyName = "NumeroConcesion";
            this.numeroConcesionDataGridViewTextBoxColumn.HeaderText = "NumeroConcesion";
            this.numeroConcesionDataGridViewTextBoxColumn.Name = "numeroConcesionDataGridViewTextBoxColumn";
            this.numeroConcesionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GPS
            // 
            this.GPS.DataPropertyName = "GPS";
            this.GPS.HeaderText = "GPS";
            this.GPS.Name = "GPS";
            this.GPS.ReadOnly = true;
            // 
            // Unidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "Unidades";
            this.Text = "Unidades";
            this.Load += new System.EventHandler(this.Unidades_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vista_UnidadesDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource vista_UnidadesBindingSource;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Arrendamiento_IDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.CheckBox UnidadesBajaCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioListaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSerieMotorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarjetaCirculacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometrajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propietarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrendamientoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrendamientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn concesionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroConcesionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPS;

    }
}