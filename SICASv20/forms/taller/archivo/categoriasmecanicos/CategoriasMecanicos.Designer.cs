namespace SICASv20.forms
{
    partial class CategoriasMecanicos
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
            this.Vista_CategoriasMecanicosDataGridView = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.CategoriaMecanico_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamiliaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vista_CategoriasMecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectFamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CategoriaMecanico_IDLabel = new System.Windows.Forms.Label();
            this.CategoriaMecanico_IDTextBox = new System.Windows.Forms.TextBox();
            this.Familia_IDLabel = new System.Windows.Forms.Label();
            this.Familia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_CategoriasMecanicosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_CategoriasMecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_CategoriasMecanicosDataGridView
            // 
            this.Vista_CategoriasMecanicosDataGridView.AllowUserToAddRows = false;
            this.Vista_CategoriasMecanicosDataGridView.AllowUserToDeleteRows = false;
            this.Vista_CategoriasMecanicosDataGridView.AutoGenerateColumns = false;
            this.Vista_CategoriasMecanicosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_CategoriasMecanicosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.CategoriaMecanico_IDColumn,
            this.FamiliaColumn,
            this.NombreColumn});
            this.Vista_CategoriasMecanicosDataGridView.DataSource = this.Vista_CategoriasMecanicosBindingSource;
            this.Vista_CategoriasMecanicosDataGridView.Location = new System.Drawing.Point(17, 131);
            this.Vista_CategoriasMecanicosDataGridView.Name = "Vista_CategoriasMecanicosDataGridView";
            this.Vista_CategoriasMecanicosDataGridView.ReadOnly = true;
            this.Vista_CategoriasMecanicosDataGridView.Size = new System.Drawing.Size(958, 478);
            this.Vista_CategoriasMecanicosDataGridView.TabIndex = 12;
            this.Vista_CategoriasMecanicosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_CategoriasMecanicosDataGridView_CellContentClick);
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // CategoriaMecanico_IDColumn
            // 
            this.CategoriaMecanico_IDColumn.DataPropertyName = "CategoriaMecanico_ID";
            this.CategoriaMecanico_IDColumn.HeaderText = "CategoriaMecanico_ID";
            this.CategoriaMecanico_IDColumn.Name = "CategoriaMecanico_IDColumn";
            this.CategoriaMecanico_IDColumn.ReadOnly = true;
            // 
            // FamiliaColumn
            // 
            this.FamiliaColumn.DataPropertyName = "Familia";
            this.FamiliaColumn.HeaderText = "Familia";
            this.FamiliaColumn.Name = "FamiliaColumn";
            this.FamiliaColumn.ReadOnly = true;
            // 
            // NombreColumn
            // 
            this.NombreColumn.DataPropertyName = "Nombre";
            this.NombreColumn.HeaderText = "Nombre";
            this.NombreColumn.Name = "NombreColumn";
            this.NombreColumn.ReadOnly = true;
            // 
            // Vista_CategoriasMecanicosBindingSource
            // 
            this.Vista_CategoriasMecanicosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_CategoriasMecanicos);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(716, 27);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectFamiliasBindingSource
            // 
            this.selectFamiliasBindingSource.DataSource = typeof(SICASv20.Entities.SelectFamilias);
            // 
            // CategoriaMecanico_IDLabel
            // 
            this.CategoriaMecanico_IDLabel.AutoSize = true;
            this.CategoriaMecanico_IDLabel.Location = new System.Drawing.Point(22, 27);
            this.CategoriaMecanico_IDLabel.Name = "CategoriaMecanico_IDLabel";
            this.CategoriaMecanico_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.CategoriaMecanico_IDLabel.TabIndex = 1;
            this.CategoriaMecanico_IDLabel.Text = "CategoriaMecanico_ID:";
            // 
            // CategoriaMecanico_IDTextBox
            // 
            this.CategoriaMecanico_IDTextBox.Location = new System.Drawing.Point(207, 27);
            this.CategoriaMecanico_IDTextBox.Name = "CategoriaMecanico_IDTextBox";
            this.CategoriaMecanico_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.CategoriaMecanico_IDTextBox.TabIndex = 2;
            // 
            // Familia_IDLabel
            // 
            this.Familia_IDLabel.AutoSize = true;
            this.Familia_IDLabel.Location = new System.Drawing.Point(22, 54);
            this.Familia_IDLabel.Name = "Familia_IDLabel";
            this.Familia_IDLabel.Size = new System.Drawing.Size(70, 15);
            this.Familia_IDLabel.TabIndex = 3;
            this.Familia_IDLabel.Text = "Familia_ID:";
            // 
            // Familia_IDComboBox
            // 
            this.Familia_IDComboBox.DataSource = this.selectFamiliasBindingSource;
            this.Familia_IDComboBox.DisplayMember = "Nombre";
            this.Familia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Familia_IDComboBox.FormattingEnabled = true;
            this.Familia_IDComboBox.Location = new System.Drawing.Point(207, 54);
            this.Familia_IDComboBox.Name = "Familia_IDComboBox";
            this.Familia_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Familia_IDComboBox.TabIndex = 4;
            this.Familia_IDComboBox.ValueMember = "Familia_ID";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(418, 27);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 5;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(497, 27);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Vista_CategoriasMecanicosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorias Mecanicos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CategoriaMecanico_IDLabel);
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Controls.Add(this.NombreTextBox);
            this.groupBox2.Controls.Add(this.CategoriaMecanico_IDTextBox);
            this.groupBox2.Controls.Add(this.NombreLabel);
            this.groupBox2.Controls.Add(this.Familia_IDLabel);
            this.groupBox2.Controls.Add(this.Familia_IDComboBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 92);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros de Búsqueda";
            // 
            // CategoriasMecanicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "CategoriasMecanicos";
            this.Text = "CategoriasMecanicos";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_CategoriasMecanicosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_CategoriasMecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_CategoriasMecanicosDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaMecanico_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamiliaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreColumn;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label CategoriaMecanico_IDLabel;
        private System.Windows.Forms.TextBox CategoriaMecanico_IDTextBox;
        private System.Windows.Forms.Label Familia_IDLabel;
        private System.Windows.Forms.ComboBox Familia_IDComboBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.BindingSource Vista_CategoriasMecanicosBindingSource;
        private System.Windows.Forms.BindingSource selectFamiliasBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}