namespace SICASv20.forms
{
    partial class Mecanicos
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
            this.Vista_MecanicosDataGridView = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Mecanico_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombresColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidosColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RfcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSSColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DomicilioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoElectronicoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalarioDiarioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioEntradaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioSalidaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarrasColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vista_MecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectCategoriasMecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Mecanico_IDLabel = new System.Windows.Forms.Label();
            this.Mecanico_IDTextBox = new System.Windows.Forms.TextBox();
            this.CategoriaMecanico_IDLabel = new System.Windows.Forms.Label();
            this.CategoriaMecanico_IDComboBox = new System.Windows.Forms.ComboBox();
            this.NombresLabel = new System.Windows.Forms.Label();
            this.NombresTextBox = new System.Windows.Forms.TextBox();
            this.ApellidosLabel = new System.Windows.Forms.Label();
            this.ApellidosTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_MecanicosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_MecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectCategoriasMecanicosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_MecanicosDataGridView
            // 
            this.Vista_MecanicosDataGridView.AllowUserToAddRows = false;
            this.Vista_MecanicosDataGridView.AllowUserToDeleteRows = false;
            this.Vista_MecanicosDataGridView.AutoGenerateColumns = false;
            this.Vista_MecanicosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_MecanicosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.Mecanico_IDColumn,
            this.CategoriaColumn,
            this.NombresColumn,
            this.ApellidosColumn,
            this.RfcColumn,
            this.CurpColumn,
            this.NSSColumn,
            this.DomicilioColumn,
            this.CiudadColumn,
            this.EntidadColumn,
            this.CodigoPostalColumn,
            this.TelefonoColumn,
            this.CorreoElectronicoColumn,
            this.SalarioDiarioColumn,
            this.HorarioEntradaColumn,
            this.HorarioSalidaColumn,
            this.EstatusColumn,
            this.Usuario_IDColumn,
            this.FechaColumn,
            this.CodigoBarrasColumn});
            this.Vista_MecanicosDataGridView.DataSource = this.Vista_MecanicosBindingSource;
            this.Vista_MecanicosDataGridView.Location = new System.Drawing.Point(22, 144);
            this.Vista_MecanicosDataGridView.Name = "Vista_MecanicosDataGridView";
            this.Vista_MecanicosDataGridView.ReadOnly = true;
            this.Vista_MecanicosDataGridView.Size = new System.Drawing.Size(945, 460);
            this.Vista_MecanicosDataGridView.TabIndex = 12;
            this.Vista_MecanicosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_MecanicosDataGridView_CellContentClick);
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // Mecanico_IDColumn
            // 
            this.Mecanico_IDColumn.DataPropertyName = "Mecanico_ID";
            this.Mecanico_IDColumn.HeaderText = "Mecanico_ID";
            this.Mecanico_IDColumn.Name = "Mecanico_IDColumn";
            this.Mecanico_IDColumn.ReadOnly = true;
            // 
            // CategoriaColumn
            // 
            this.CategoriaColumn.DataPropertyName = "Categoria";
            this.CategoriaColumn.HeaderText = "Categoria";
            this.CategoriaColumn.Name = "CategoriaColumn";
            this.CategoriaColumn.ReadOnly = true;
            // 
            // NombresColumn
            // 
            this.NombresColumn.DataPropertyName = "Nombres";
            this.NombresColumn.HeaderText = "Nombres";
            this.NombresColumn.Name = "NombresColumn";
            this.NombresColumn.ReadOnly = true;
            // 
            // ApellidosColumn
            // 
            this.ApellidosColumn.DataPropertyName = "Apellidos";
            this.ApellidosColumn.HeaderText = "Apellidos";
            this.ApellidosColumn.Name = "ApellidosColumn";
            this.ApellidosColumn.ReadOnly = true;
            // 
            // RfcColumn
            // 
            this.RfcColumn.DataPropertyName = "Rfc";
            this.RfcColumn.HeaderText = "Rfc";
            this.RfcColumn.Name = "RfcColumn";
            this.RfcColumn.ReadOnly = true;
            // 
            // CurpColumn
            // 
            this.CurpColumn.DataPropertyName = "Curp";
            this.CurpColumn.HeaderText = "Curp";
            this.CurpColumn.Name = "CurpColumn";
            this.CurpColumn.ReadOnly = true;
            // 
            // NSSColumn
            // 
            this.NSSColumn.DataPropertyName = "NSS";
            this.NSSColumn.HeaderText = "NSS";
            this.NSSColumn.Name = "NSSColumn";
            this.NSSColumn.ReadOnly = true;
            // 
            // DomicilioColumn
            // 
            this.DomicilioColumn.DataPropertyName = "Domicilio";
            this.DomicilioColumn.HeaderText = "Domicilio";
            this.DomicilioColumn.Name = "DomicilioColumn";
            this.DomicilioColumn.ReadOnly = true;
            // 
            // CiudadColumn
            // 
            this.CiudadColumn.DataPropertyName = "Ciudad";
            this.CiudadColumn.HeaderText = "Ciudad";
            this.CiudadColumn.Name = "CiudadColumn";
            this.CiudadColumn.ReadOnly = true;
            // 
            // EntidadColumn
            // 
            this.EntidadColumn.DataPropertyName = "Entidad";
            this.EntidadColumn.HeaderText = "Entidad";
            this.EntidadColumn.Name = "EntidadColumn";
            this.EntidadColumn.ReadOnly = true;
            // 
            // CodigoPostalColumn
            // 
            this.CodigoPostalColumn.DataPropertyName = "CodigoPostal";
            this.CodigoPostalColumn.HeaderText = "CodigoPostal";
            this.CodigoPostalColumn.Name = "CodigoPostalColumn";
            this.CodigoPostalColumn.ReadOnly = true;
            // 
            // TelefonoColumn
            // 
            this.TelefonoColumn.DataPropertyName = "Telefono";
            this.TelefonoColumn.HeaderText = "Telefono";
            this.TelefonoColumn.Name = "TelefonoColumn";
            this.TelefonoColumn.ReadOnly = true;
            // 
            // CorreoElectronicoColumn
            // 
            this.CorreoElectronicoColumn.DataPropertyName = "CorreoElectronico";
            this.CorreoElectronicoColumn.HeaderText = "CorreoElectronico";
            this.CorreoElectronicoColumn.Name = "CorreoElectronicoColumn";
            this.CorreoElectronicoColumn.ReadOnly = true;
            // 
            // SalarioDiarioColumn
            // 
            this.SalarioDiarioColumn.DataPropertyName = "SalarioDiario";
            this.SalarioDiarioColumn.HeaderText = "SalarioDiario";
            this.SalarioDiarioColumn.Name = "SalarioDiarioColumn";
            this.SalarioDiarioColumn.ReadOnly = true;
            // 
            // HorarioEntradaColumn
            // 
            this.HorarioEntradaColumn.DataPropertyName = "HorarioEntrada";
            this.HorarioEntradaColumn.HeaderText = "HorarioEntrada";
            this.HorarioEntradaColumn.Name = "HorarioEntradaColumn";
            this.HorarioEntradaColumn.ReadOnly = true;
            // 
            // HorarioSalidaColumn
            // 
            this.HorarioSalidaColumn.DataPropertyName = "HorarioSalida";
            this.HorarioSalidaColumn.HeaderText = "HorarioSalida";
            this.HorarioSalidaColumn.Name = "HorarioSalidaColumn";
            this.HorarioSalidaColumn.ReadOnly = true;
            // 
            // EstatusColumn
            // 
            this.EstatusColumn.DataPropertyName = "Estatus";
            this.EstatusColumn.HeaderText = "Estatus";
            this.EstatusColumn.Name = "EstatusColumn";
            this.EstatusColumn.ReadOnly = true;
            // 
            // Usuario_IDColumn
            // 
            this.Usuario_IDColumn.DataPropertyName = "Usuario_ID";
            this.Usuario_IDColumn.HeaderText = "Usuario_ID";
            this.Usuario_IDColumn.Name = "Usuario_IDColumn";
            this.Usuario_IDColumn.ReadOnly = true;
            // 
            // FechaColumn
            // 
            this.FechaColumn.DataPropertyName = "Fecha";
            this.FechaColumn.HeaderText = "Fecha";
            this.FechaColumn.Name = "FechaColumn";
            this.FechaColumn.ReadOnly = true;
            // 
            // CodigoBarrasColumn
            // 
            this.CodigoBarrasColumn.DataPropertyName = "CodigoBarras";
            this.CodigoBarrasColumn.HeaderText = "CodigoBarras";
            this.CodigoBarrasColumn.Name = "CodigoBarrasColumn";
            this.CodigoBarrasColumn.ReadOnly = true;
            // 
            // Vista_MecanicosBindingSource
            // 
            this.Vista_MecanicosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Mecanicos);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(796, 31);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectCategoriasMecanicosBindingSource
            // 
            this.selectCategoriasMecanicosBindingSource.DataSource = typeof(SICASv20.Entities.SelectCategoriasMecanicos);
            // 
            // Mecanico_IDLabel
            // 
            this.Mecanico_IDLabel.AutoSize = true;
            this.Mecanico_IDLabel.Location = new System.Drawing.Point(22, 31);
            this.Mecanico_IDLabel.Name = "Mecanico_IDLabel";
            this.Mecanico_IDLabel.Size = new System.Drawing.Size(83, 15);
            this.Mecanico_IDLabel.TabIndex = 1;
            this.Mecanico_IDLabel.Text = "Mecanico_ID:";
            // 
            // Mecanico_IDTextBox
            // 
            this.Mecanico_IDTextBox.Location = new System.Drawing.Point(207, 31);
            this.Mecanico_IDTextBox.Name = "Mecanico_IDTextBox";
            this.Mecanico_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.Mecanico_IDTextBox.TabIndex = 2;
            // 
            // CategoriaMecanico_IDLabel
            // 
            this.CategoriaMecanico_IDLabel.AutoSize = true;
            this.CategoriaMecanico_IDLabel.Location = new System.Drawing.Point(22, 58);
            this.CategoriaMecanico_IDLabel.Name = "CategoriaMecanico_IDLabel";
            this.CategoriaMecanico_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.CategoriaMecanico_IDLabel.TabIndex = 3;
            this.CategoriaMecanico_IDLabel.Text = "CategoriaMecanico_ID:";
            // 
            // CategoriaMecanico_IDComboBox
            // 
            this.CategoriaMecanico_IDComboBox.DataSource = this.selectCategoriasMecanicosBindingSource;
            this.CategoriaMecanico_IDComboBox.DisplayMember = "Nombre";
            this.CategoriaMecanico_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriaMecanico_IDComboBox.FormattingEnabled = true;
            this.CategoriaMecanico_IDComboBox.Location = new System.Drawing.Point(207, 58);
            this.CategoriaMecanico_IDComboBox.Name = "CategoriaMecanico_IDComboBox";
            this.CategoriaMecanico_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.CategoriaMecanico_IDComboBox.TabIndex = 4;
            this.CategoriaMecanico_IDComboBox.ValueMember = "CategoriaMecanico_ID";
            // 
            // NombresLabel
            // 
            this.NombresLabel.AutoSize = true;
            this.NombresLabel.Location = new System.Drawing.Point(425, 31);
            this.NombresLabel.Name = "NombresLabel";
            this.NombresLabel.Size = new System.Drawing.Size(61, 15);
            this.NombresLabel.TabIndex = 5;
            this.NombresLabel.Text = "Nombres:";
            // 
            // NombresTextBox
            // 
            this.NombresTextBox.Location = new System.Drawing.Point(610, 31);
            this.NombresTextBox.Name = "NombresTextBox";
            this.NombresTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombresTextBox.TabIndex = 6;
            // 
            // ApellidosLabel
            // 
            this.ApellidosLabel.AutoSize = true;
            this.ApellidosLabel.Location = new System.Drawing.Point(425, 58);
            this.ApellidosLabel.Name = "ApellidosLabel";
            this.ApellidosLabel.Size = new System.Drawing.Size(60, 15);
            this.ApellidosLabel.TabIndex = 7;
            this.ApellidosLabel.Text = "Apellidos:";
            // 
            // ApellidosTextBox
            // 
            this.ApellidosTextBox.Location = new System.Drawing.Point(610, 58);
            this.ApellidosTextBox.Name = "ApellidosTextBox";
            this.ApellidosTextBox.Size = new System.Drawing.Size(150, 21);
            this.ApellidosTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Mecanico_IDLabel);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.NombresLabel);
            this.groupBox1.Controls.Add(this.NombresTextBox);
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDComboBox);
            this.groupBox1.Controls.Add(this.ApellidosLabel);
            this.groupBox1.Controls.Add(this.Mecanico_IDTextBox);
            this.groupBox1.Controls.Add(this.ApellidosTextBox);
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(22, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de Búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Vista_MecanicosDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(987, 627);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mecánicos";
            // 
            // Mecanicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "Mecanicos";
            this.Text = "Mecanicos";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_MecanicosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_MecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectCategoriasMecanicosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_MecanicosDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mecanico_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombresColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RfcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurpColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSSColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DomicilioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoElectronicoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalarioDiarioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioEntradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioSalidaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarrasColumn;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label Mecanico_IDLabel;
        private System.Windows.Forms.TextBox Mecanico_IDTextBox;
        private System.Windows.Forms.Label CategoriaMecanico_IDLabel;
        private System.Windows.Forms.ComboBox CategoriaMecanico_IDComboBox;
        private System.Windows.Forms.Label NombresLabel;
        private System.Windows.Forms.TextBox NombresTextBox;
        private System.Windows.Forms.Label ApellidosLabel;
        private System.Windows.Forms.TextBox ApellidosTextBox;
        private System.Windows.Forms.BindingSource Vista_MecanicosBindingSource;
        private System.Windows.Forms.BindingSource selectCategoriasMecanicosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}