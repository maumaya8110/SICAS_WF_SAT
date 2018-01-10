namespace SICASv20.forms
{
    partial class TiposRefacciones
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vista_TiposRefaccionesDataGridView = new System.Windows.Forms.DataGridView();
            this.ActualizarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_TiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FamiliasComboBox = new System.Windows.Forms.ComboBox();
            this.selectFamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TiposRefaccionesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 547);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Refacciones";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.74074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.25926F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 419F));
            this.tableLayoutPanel1.Controls.Add(this.vista_TiposRefaccionesDataGridView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FamiliasComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NombreTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BuscarButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // vista_TiposRefaccionesDataGridView
            // 
            this.vista_TiposRefaccionesDataGridView.AllowUserToAddRows = false;
            this.vista_TiposRefaccionesDataGridView.AllowUserToDeleteRows = false;
            this.vista_TiposRefaccionesDataGridView.AutoGenerateColumns = false;
            this.vista_TiposRefaccionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_TiposRefaccionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActualizarColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tableLayoutPanel1.SetColumnSpan(this.vista_TiposRefaccionesDataGridView, 3);
            this.vista_TiposRefaccionesDataGridView.DataSource = this.vista_TiposRefaccionesBindingSource;
            this.vista_TiposRefaccionesDataGridView.Location = new System.Drawing.Point(3, 80);
            this.vista_TiposRefaccionesDataGridView.Name = "vista_TiposRefaccionesDataGridView";
            this.vista_TiposRefaccionesDataGridView.ReadOnly = true;
            this.vista_TiposRefaccionesDataGridView.Size = new System.Drawing.Size(945, 405);
            this.vista_TiposRefaccionesDataGridView.TabIndex = 5;
            this.vista_TiposRefaccionesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_TiposRefaccionesDataGridView_CellContentClick);
            // 
            // ActualizarColumn
            // 
            this.ActualizarColumn.HeaderText = "";
            this.ActualizarColumn.Name = "ActualizarColumn";
            this.ActualizarColumn.ReadOnly = true;
            this.ActualizarColumn.Text = "Actualizar";
            this.ActualizarColumn.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TipoRefaccion_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "TipoRefaccion_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Familia";
            this.dataGridViewTextBoxColumn2.HeaderText = "Familia";
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
            // vista_TiposRefaccionesBindingSource
            // 
            this.vista_TiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_TiposRefacciones);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Familia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // FamiliasComboBox
            // 
            this.FamiliasComboBox.DataSource = this.selectFamiliasBindingSource;
            this.FamiliasComboBox.DisplayMember = "Nombre";
            this.FamiliasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamiliasComboBox.FormattingEnabled = true;
            this.FamiliasComboBox.Location = new System.Drawing.Point(113, 3);
            this.FamiliasComboBox.Name = "FamiliasComboBox";
            this.FamiliasComboBox.Size = new System.Drawing.Size(311, 23);
            this.FamiliasComboBox.TabIndex = 2;
            this.FamiliasComboBox.ValueMember = "Familia_ID";
            this.FamiliasComboBox.SelectionChangeCommitted += new System.EventHandler(this.FamiliasComboBox_SelectionChangeCommitted);
            // 
            // selectFamiliasBindingSource
            // 
            this.selectFamiliasBindingSource.DataSource = typeof(SICASv20.Entities.SelectFamilias);
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(113, 32);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(311, 21);
            this.NombreTextBox.TabIndex = 3;
            this.NombreTextBox.TextChanged += new System.EventHandler(this.NombreTextBox_TextChanged);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(534, 3);
            this.BuscarButton.Name = "BuscarButton";
            this.tableLayoutPanel1.SetRowSpan(this.BuscarButton, 2);
            this.BuscarButton.Size = new System.Drawing.Size(125, 51);
            this.BuscarButton.TabIndex = 4;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // TiposRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1041, 577);
            this.Controls.Add(this.groupBox1);
            this.Name = "TiposRefacciones";
            this.Text = "TiposRefacciones";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TiposRefaccionesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_TiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView vista_TiposRefaccionesDataGridView;
        private System.Windows.Forms.BindingSource vista_TiposRefaccionesBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FamiliasComboBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridViewLinkColumn ActualizarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource selectFamiliasBindingSource;
    }
}