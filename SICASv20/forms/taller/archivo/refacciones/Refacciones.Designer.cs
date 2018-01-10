namespace SICASv20.forms
{
    partial class Refacciones
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
            this.Vista_RefaccionesDataGridView = new System.Windows.Forms.DataGridView();
            this.Vista_RefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectTiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectModelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectMarcasRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Refaccion_IDLabel = new System.Windows.Forms.Label();
            this.Refaccion_IDTextBox = new System.Windows.Forms.TextBox();
            this.TipoRefaccion_IDLabel = new System.Windows.Forms.Label();
            this.TipoRefaccion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.Modelo_IDLabel = new System.Windows.Forms.Label();
            this.Modelo_IDComboBox = new System.Windows.Forms.ComboBox();
            this.MarcaRefaccion_IDLabel = new System.Windows.Forms.Label();
            this.MarcaRefaccion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Refaccion_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroSerialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_RefaccionesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_RefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectMarcasRefaccionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_RefaccionesDataGridView
            // 
            this.Vista_RefaccionesDataGridView.AllowUserToAddRows = false;
            this.Vista_RefaccionesDataGridView.AllowUserToDeleteRows = false;
            this.Vista_RefaccionesDataGridView.AutoGenerateColumns = false;
            this.Vista_RefaccionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_RefaccionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.Refaccion_IDColumn,
            this.TipoColumn,
            this.ModeloColumn,
            this.MarcaColumn,
            this.NumeroSerialColumn,
            this.DescripcionColumn,
            this.AnioColumn});
            this.Vista_RefaccionesDataGridView.DataSource = this.Vista_RefaccionesBindingSource;
            this.Vista_RefaccionesDataGridView.Location = new System.Drawing.Point(16, 158);
            this.Vista_RefaccionesDataGridView.Name = "Vista_RefaccionesDataGridView";
            this.Vista_RefaccionesDataGridView.ReadOnly = true;
            this.Vista_RefaccionesDataGridView.Size = new System.Drawing.Size(956, 448);
            this.Vista_RefaccionesDataGridView.TabIndex = 12;
            this.Vista_RefaccionesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_RefaccionesDataGridView_CellContentClick);
            // 
            // Vista_RefaccionesBindingSource
            // 
            this.Vista_RefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Refacciones);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(807, 43);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectTiposRefaccionesBindingSource
            // 
            this.selectTiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposRefacciones);
            // 
            // selectModelosBindingSource
            // 
            this.selectModelosBindingSource.DataSource = typeof(SICASv20.Entities.SelectModelos);
            // 
            // selectMarcasRefaccionesBindingSource
            // 
            this.selectMarcasRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectMarcasRefacciones);
            // 
            // Refaccion_IDLabel
            // 
            this.Refaccion_IDLabel.AutoSize = true;
            this.Refaccion_IDLabel.Location = new System.Drawing.Point(16, 27);
            this.Refaccion_IDLabel.Name = "Refaccion_IDLabel";
            this.Refaccion_IDLabel.Size = new System.Drawing.Size(84, 15);
            this.Refaccion_IDLabel.TabIndex = 1;
            this.Refaccion_IDLabel.Text = "Refaccion_ID:";
            // 
            // Refaccion_IDTextBox
            // 
            this.Refaccion_IDTextBox.Location = new System.Drawing.Point(158, 27);
            this.Refaccion_IDTextBox.Name = "Refaccion_IDTextBox";
            this.Refaccion_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.Refaccion_IDTextBox.TabIndex = 2;
            // 
            // TipoRefaccion_IDLabel
            // 
            this.TipoRefaccion_IDLabel.AutoSize = true;
            this.TipoRefaccion_IDLabel.Location = new System.Drawing.Point(16, 54);
            this.TipoRefaccion_IDLabel.Name = "TipoRefaccion_IDLabel";
            this.TipoRefaccion_IDLabel.Size = new System.Drawing.Size(108, 15);
            this.TipoRefaccion_IDLabel.TabIndex = 3;
            this.TipoRefaccion_IDLabel.Text = "TipoRefaccion_ID:";
            // 
            // TipoRefaccion_IDComboBox
            // 
            this.TipoRefaccion_IDComboBox.DataSource = this.selectTiposRefaccionesBindingSource;
            this.TipoRefaccion_IDComboBox.DisplayMember = "Nombre";
            this.TipoRefaccion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoRefaccion_IDComboBox.FormattingEnabled = true;
            this.TipoRefaccion_IDComboBox.Location = new System.Drawing.Point(158, 54);
            this.TipoRefaccion_IDComboBox.Name = "TipoRefaccion_IDComboBox";
            this.TipoRefaccion_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoRefaccion_IDComboBox.TabIndex = 4;
            this.TipoRefaccion_IDComboBox.ValueMember = "TipoRefaccion_ID";
            // 
            // Modelo_IDLabel
            // 
            this.Modelo_IDLabel.AutoSize = true;
            this.Modelo_IDLabel.Location = new System.Drawing.Point(16, 81);
            this.Modelo_IDLabel.Name = "Modelo_IDLabel";
            this.Modelo_IDLabel.Size = new System.Drawing.Size(71, 15);
            this.Modelo_IDLabel.TabIndex = 5;
            this.Modelo_IDLabel.Text = "Modelo_ID:";
            // 
            // Modelo_IDComboBox
            // 
            this.Modelo_IDComboBox.DataSource = this.selectModelosBindingSource;
            this.Modelo_IDComboBox.DisplayMember = "Nombre";
            this.Modelo_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Modelo_IDComboBox.FormattingEnabled = true;
            this.Modelo_IDComboBox.Location = new System.Drawing.Point(158, 81);
            this.Modelo_IDComboBox.Name = "Modelo_IDComboBox";
            this.Modelo_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Modelo_IDComboBox.TabIndex = 6;
            this.Modelo_IDComboBox.ValueMember = "Modelo_ID";
            // 
            // MarcaRefaccion_IDLabel
            // 
            this.MarcaRefaccion_IDLabel.AutoSize = true;
            this.MarcaRefaccion_IDLabel.Location = new System.Drawing.Point(401, 30);
            this.MarcaRefaccion_IDLabel.Name = "MarcaRefaccion_IDLabel";
            this.MarcaRefaccion_IDLabel.Size = new System.Drawing.Size(119, 15);
            this.MarcaRefaccion_IDLabel.TabIndex = 7;
            this.MarcaRefaccion_IDLabel.Text = "MarcaRefaccion_ID:";
            // 
            // MarcaRefaccion_IDComboBox
            // 
            this.MarcaRefaccion_IDComboBox.DataSource = this.selectMarcasRefaccionesBindingSource;
            this.MarcaRefaccion_IDComboBox.DisplayMember = "Nombre";
            this.MarcaRefaccion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarcaRefaccion_IDComboBox.FormattingEnabled = true;
            this.MarcaRefaccion_IDComboBox.Location = new System.Drawing.Point(562, 30);
            this.MarcaRefaccion_IDComboBox.Name = "MarcaRefaccion_IDComboBox";
            this.MarcaRefaccion_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.MarcaRefaccion_IDComboBox.TabIndex = 8;
            this.MarcaRefaccion_IDComboBox.ValueMember = "MarcaRefaccion_ID";
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Location = new System.Drawing.Point(401, 57);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(75, 15);
            this.DescripcionLabel.TabIndex = 9;
            this.DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(562, 57);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(150, 21);
            this.DescripcionTextBox.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.DescripcionTextBox);
            this.groupBox1.Controls.Add(this.Refaccion_IDLabel);
            this.groupBox1.Controls.Add(this.MarcaRefaccion_IDComboBox);
            this.groupBox1.Controls.Add(this.DescripcionLabel);
            this.groupBox1.Controls.Add(this.TipoRefaccion_IDLabel);
            this.groupBox1.Controls.Add(this.Modelo_IDComboBox);
            this.groupBox1.Controls.Add(this.Refaccion_IDTextBox);
            this.groupBox1.Controls.Add(this.MarcaRefaccion_IDLabel);
            this.groupBox1.Controls.Add(this.Modelo_IDLabel);
            this.groupBox1.Controls.Add(this.TipoRefaccion_IDComboBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 116);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Vista_RefaccionesDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 628);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Refacciones";
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // Refaccion_IDColumn
            // 
            this.Refaccion_IDColumn.DataPropertyName = "Refaccion_ID";
            this.Refaccion_IDColumn.HeaderText = "Refaccion_ID";
            this.Refaccion_IDColumn.Name = "Refaccion_IDColumn";
            this.Refaccion_IDColumn.ReadOnly = true;
            // 
            // TipoColumn
            // 
            this.TipoColumn.DataPropertyName = "Tipo";
            this.TipoColumn.HeaderText = "Tipo";
            this.TipoColumn.Name = "TipoColumn";
            this.TipoColumn.ReadOnly = true;
            // 
            // ModeloColumn
            // 
            this.ModeloColumn.DataPropertyName = "Modelo";
            this.ModeloColumn.HeaderText = "Modelo";
            this.ModeloColumn.Name = "ModeloColumn";
            this.ModeloColumn.ReadOnly = true;
            // 
            // MarcaColumn
            // 
            this.MarcaColumn.DataPropertyName = "Marca";
            this.MarcaColumn.HeaderText = "Marca";
            this.MarcaColumn.Name = "MarcaColumn";
            this.MarcaColumn.ReadOnly = true;
            // 
            // NumeroSerialColumn
            // 
            this.NumeroSerialColumn.DataPropertyName = "NumeroSerial";
            this.NumeroSerialColumn.HeaderText = "NumeroSerial";
            this.NumeroSerialColumn.Name = "NumeroSerialColumn";
            this.NumeroSerialColumn.ReadOnly = true;
            // 
            // DescripcionColumn
            // 
            this.DescripcionColumn.DataPropertyName = "Descripcion";
            this.DescripcionColumn.HeaderText = "Descripcion";
            this.DescripcionColumn.Name = "DescripcionColumn";
            this.DescripcionColumn.ReadOnly = true;
            // 
            // AnioColumn
            // 
            this.AnioColumn.DataPropertyName = "Anio";
            this.AnioColumn.HeaderText = "Anio";
            this.AnioColumn.Name = "AnioColumn";
            this.AnioColumn.ReadOnly = true;
            // 
            // Refacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "Refacciones";
            this.Text = "Refacciones";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_RefaccionesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_RefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectMarcasRefaccionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_RefaccionesDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label Refaccion_IDLabel;
        private System.Windows.Forms.TextBox Refaccion_IDTextBox;
        private System.Windows.Forms.Label TipoRefaccion_IDLabel;
        private System.Windows.Forms.ComboBox TipoRefaccion_IDComboBox;
        private System.Windows.Forms.Label Modelo_IDLabel;
        private System.Windows.Forms.ComboBox Modelo_IDComboBox;
        private System.Windows.Forms.Label MarcaRefaccion_IDLabel;
        private System.Windows.Forms.ComboBox MarcaRefaccion_IDComboBox;
        private System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.BindingSource Vista_RefaccionesBindingSource;
        private System.Windows.Forms.BindingSource selectTiposRefaccionesBindingSource;
        private System.Windows.Forms.BindingSource selectModelosBindingSource;
        private System.Windows.Forms.BindingSource selectMarcasRefaccionesBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refaccion_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSerialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioColumn;


    }
}