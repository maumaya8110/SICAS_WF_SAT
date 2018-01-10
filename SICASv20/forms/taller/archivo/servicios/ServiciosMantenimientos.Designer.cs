namespace SICASv20.forms
{
    partial class ServiciosMantenimientos
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
            this.Vista_ServiciosMantenimientosDataGridView = new System.Windows.Forms.DataGridView();
            this.Vista_ServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectTiposServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectFamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectModelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.Familia_IDLabel = new System.Windows.Forms.Label();
            this.Familia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServicioMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.TipoServicioMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.TipoServicioMantenimiento_IDComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PreciosColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TiposRefaccionesColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ServicioMantenimiento_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamiliaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoAplicadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoManoObraAreaMinutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioMinutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeUtilidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaManoObraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosMantenimientosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosMantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposServiciosMantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_ServiciosMantenimientosDataGridView
            // 
            this.Vista_ServiciosMantenimientosDataGridView.AllowUserToAddRows = false;
            this.Vista_ServiciosMantenimientosDataGridView.AllowUserToDeleteRows = false;
            this.Vista_ServiciosMantenimientosDataGridView.AutoGenerateColumns = false;
            this.Vista_ServiciosMantenimientosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_ServiciosMantenimientosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PreciosColumn,
            this.TiposRefaccionesColumn,
            this.EditColumn,
            this.ServicioMantenimiento_IDColumn,
            this.TipoColumn,
            this.FamiliaColumn,
            this.ModeloColumn,
            this.NombreColumn,
            this.TiempoAplicadoColumn,
            this.CostoManoObraAreaMinutoColumn,
            this.PrecioMinutoColumn,
            this.CostoColumn,
            this.PrecioColumn,
            this.PorcentajeUtilidadColumn,
            this.CuotaManoObraColumn});
            this.Vista_ServiciosMantenimientosDataGridView.DataSource = this.Vista_ServiciosMantenimientosBindingSource;
            this.Vista_ServiciosMantenimientosDataGridView.Location = new System.Drawing.Point(15, 141);
            this.Vista_ServiciosMantenimientosDataGridView.Name = "Vista_ServiciosMantenimientosDataGridView";
            this.Vista_ServiciosMantenimientosDataGridView.ReadOnly = true;
            this.Vista_ServiciosMantenimientosDataGridView.Size = new System.Drawing.Size(954, 471);
            this.Vista_ServiciosMantenimientosDataGridView.TabIndex = 12;
            this.Vista_ServiciosMantenimientosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_ServiciosMantenimientosDataGridView_CellContentClick);
            // 
            // Vista_ServiciosMantenimientosBindingSource
            // 
            this.Vista_ServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosMantenimientos);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(774, 31);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectTiposServiciosMantenimientosBindingSource
            // 
            this.selectTiposServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposServiciosMantenimientos);
            // 
            // selectFamiliasBindingSource
            // 
            this.selectFamiliasBindingSource.DataSource = typeof(SICASv20.Entities.SelectFamilias);
            // 
            // selectModelosBindingSource
            // 
            this.selectModelosBindingSource.DataSource = typeof(SICASv20.Entities.SelectModelos);
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(206, 28);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 2;
            // 
            // Familia_IDLabel
            // 
            this.Familia_IDLabel.AutoSize = true;
            this.Familia_IDLabel.Location = new System.Drawing.Point(427, 31);
            this.Familia_IDLabel.Name = "Familia_IDLabel";
            this.Familia_IDLabel.Size = new System.Drawing.Size(70, 15);
            this.Familia_IDLabel.TabIndex = 5;
            this.Familia_IDLabel.Text = "Familia_ID:";
            // 
            // Familia_IDComboBox
            // 
            this.Familia_IDComboBox.DataSource = this.selectFamiliasBindingSource;
            this.Familia_IDComboBox.DisplayMember = "Nombre";
            this.Familia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Familia_IDComboBox.FormattingEnabled = true;
            this.Familia_IDComboBox.Location = new System.Drawing.Point(524, 31);
            this.Familia_IDComboBox.Name = "Familia_IDComboBox";
            this.Familia_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Familia_IDComboBox.TabIndex = 6;
            this.Familia_IDComboBox.ValueMember = "Familia_ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServicioMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.Familia_IDComboBox);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.TipoServicioMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.TipoServicioMantenimiento_IDComboBox);
            this.groupBox1.Controls.Add(this.Familia_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de búsqueda";
            // 
            // ServicioMantenimiento_IDLabel
            // 
            this.ServicioMantenimiento_IDLabel.AutoSize = true;
            this.ServicioMantenimiento_IDLabel.Location = new System.Drawing.Point(21, 28);
            this.ServicioMantenimiento_IDLabel.Name = "ServicioMantenimiento_IDLabel";
            this.ServicioMantenimiento_IDLabel.Size = new System.Drawing.Size(155, 15);
            this.ServicioMantenimiento_IDLabel.TabIndex = 1;
            this.ServicioMantenimiento_IDLabel.Text = "ServicioMantenimiento_ID:";
            // 
            // TipoServicioMantenimiento_IDLabel
            // 
            this.TipoServicioMantenimiento_IDLabel.AutoSize = true;
            this.TipoServicioMantenimiento_IDLabel.Location = new System.Drawing.Point(21, 55);
            this.TipoServicioMantenimiento_IDLabel.Name = "TipoServicioMantenimiento_IDLabel";
            this.TipoServicioMantenimiento_IDLabel.Size = new System.Drawing.Size(179, 15);
            this.TipoServicioMantenimiento_IDLabel.TabIndex = 3;
            this.TipoServicioMantenimiento_IDLabel.Text = "TipoServicioMantenimiento_ID:";
            // 
            // TipoServicioMantenimiento_IDComboBox
            // 
            this.TipoServicioMantenimiento_IDComboBox.DataSource = this.selectTiposServiciosMantenimientosBindingSource;
            this.TipoServicioMantenimiento_IDComboBox.DisplayMember = "Nombre";
            this.TipoServicioMantenimiento_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoServicioMantenimiento_IDComboBox.FormattingEnabled = true;
            this.TipoServicioMantenimiento_IDComboBox.Location = new System.Drawing.Point(206, 55);
            this.TipoServicioMantenimiento_IDComboBox.Name = "TipoServicioMantenimiento_IDComboBox";
            this.TipoServicioMantenimiento_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoServicioMantenimiento_IDComboBox.TabIndex = 4;
            this.TipoServicioMantenimiento_IDComboBox.ValueMember = "TipoServicioMantenimiento_ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Vista_ServiciosMantenimientosDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 628);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servicios Mantenimientos";
            // 
            // PreciosColumn
            // 
            this.PreciosColumn.HeaderText = "";
            this.PreciosColumn.Name = "PreciosColumn";
            this.PreciosColumn.ReadOnly = true;
            this.PreciosColumn.Text = "Precios";
            this.PreciosColumn.UseColumnTextForLinkValue = true;
            // 
            // TiposRefaccionesColumn
            // 
            this.TiposRefaccionesColumn.HeaderText = "";
            this.TiposRefaccionesColumn.Name = "TiposRefaccionesColumn";
            this.TiposRefaccionesColumn.ReadOnly = true;
            this.TiposRefaccionesColumn.Text = "Refacciones";
            this.TiposRefaccionesColumn.UseColumnTextForLinkValue = true;
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // ServicioMantenimiento_IDColumn
            // 
            this.ServicioMantenimiento_IDColumn.DataPropertyName = "ServicioMantenimiento_ID";
            this.ServicioMantenimiento_IDColumn.HeaderText = "ServicioMantenimiento_ID";
            this.ServicioMantenimiento_IDColumn.Name = "ServicioMantenimiento_IDColumn";
            this.ServicioMantenimiento_IDColumn.ReadOnly = true;
            // 
            // TipoColumn
            // 
            this.TipoColumn.DataPropertyName = "Tipo";
            this.TipoColumn.HeaderText = "Tipo";
            this.TipoColumn.Name = "TipoColumn";
            this.TipoColumn.ReadOnly = true;
            // 
            // FamiliaColumn
            // 
            this.FamiliaColumn.DataPropertyName = "Familia";
            this.FamiliaColumn.HeaderText = "Familia";
            this.FamiliaColumn.Name = "FamiliaColumn";
            this.FamiliaColumn.ReadOnly = true;
            // 
            // ModeloColumn
            // 
            this.ModeloColumn.DataPropertyName = "Modelo";
            this.ModeloColumn.HeaderText = "Modelo";
            this.ModeloColumn.Name = "ModeloColumn";
            this.ModeloColumn.ReadOnly = true;
            this.ModeloColumn.Visible = false;
            // 
            // NombreColumn
            // 
            this.NombreColumn.DataPropertyName = "Nombre";
            this.NombreColumn.HeaderText = "Nombre";
            this.NombreColumn.Name = "NombreColumn";
            this.NombreColumn.ReadOnly = true;
            // 
            // TiempoAplicadoColumn
            // 
            this.TiempoAplicadoColumn.DataPropertyName = "TiempoAplicado";
            this.TiempoAplicadoColumn.HeaderText = "TiempoAplicado";
            this.TiempoAplicadoColumn.Name = "TiempoAplicadoColumn";
            this.TiempoAplicadoColumn.ReadOnly = true;
            // 
            // CostoManoObraAreaMinutoColumn
            // 
            this.CostoManoObraAreaMinutoColumn.DataPropertyName = "CostoManoObraAreaMinuto";
            this.CostoManoObraAreaMinutoColumn.HeaderText = "CostoManoObraAreaMinuto";
            this.CostoManoObraAreaMinutoColumn.Name = "CostoManoObraAreaMinutoColumn";
            this.CostoManoObraAreaMinutoColumn.ReadOnly = true;
            // 
            // PrecioMinutoColumn
            // 
            this.PrecioMinutoColumn.DataPropertyName = "PrecioMinuto";
            this.PrecioMinutoColumn.HeaderText = "PrecioMinuto";
            this.PrecioMinutoColumn.Name = "PrecioMinutoColumn";
            this.PrecioMinutoColumn.ReadOnly = true;
            // 
            // CostoColumn
            // 
            this.CostoColumn.DataPropertyName = "Costo";
            this.CostoColumn.HeaderText = "Costo";
            this.CostoColumn.Name = "CostoColumn";
            this.CostoColumn.ReadOnly = true;
            // 
            // PrecioColumn
            // 
            this.PrecioColumn.DataPropertyName = "Precio";
            this.PrecioColumn.HeaderText = "Precio";
            this.PrecioColumn.Name = "PrecioColumn";
            this.PrecioColumn.ReadOnly = true;
            // 
            // PorcentajeUtilidadColumn
            // 
            this.PorcentajeUtilidadColumn.DataPropertyName = "PorcentajeUtilidad";
            this.PorcentajeUtilidadColumn.HeaderText = "PorcentajeUtilidad";
            this.PorcentajeUtilidadColumn.Name = "PorcentajeUtilidadColumn";
            this.PorcentajeUtilidadColumn.ReadOnly = true;
            // 
            // CuotaManoObraColumn
            // 
            this.CuotaManoObraColumn.DataPropertyName = "CuotaManoObra";
            this.CuotaManoObraColumn.HeaderText = "CuotaManoObra";
            this.CuotaManoObraColumn.Name = "CuotaManoObraColumn";
            this.CuotaManoObraColumn.ReadOnly = true;
            // 
            // ServiciosMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "ServiciosMantenimientos";
            this.Text = "ServiciosMantenimientos";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosMantenimientosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ServiciosMantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposServiciosMantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_ServiciosMantenimientosDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label Familia_IDLabel;
        private System.Windows.Forms.ComboBox Familia_IDComboBox;
        private System.Windows.Forms.BindingSource Vista_ServiciosMantenimientosBindingSource;
        private System.Windows.Forms.BindingSource selectTiposServiciosMantenimientosBindingSource;
        private System.Windows.Forms.BindingSource selectFamiliasBindingSource;
        private System.Windows.Forms.BindingSource selectModelosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ServicioMantenimiento_IDLabel;
        private System.Windows.Forms.Label TipoServicioMantenimiento_IDLabel;
        private System.Windows.Forms.ComboBox TipoServicioMantenimiento_IDComboBox;
        private System.Windows.Forms.DataGridViewLinkColumn PreciosColumn;
        private System.Windows.Forms.DataGridViewLinkColumn TiposRefaccionesColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicioMantenimiento_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamiliaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoAplicadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoManoObraAreaMinutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioMinutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeUtilidadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaManoObraColumn;

    }
}