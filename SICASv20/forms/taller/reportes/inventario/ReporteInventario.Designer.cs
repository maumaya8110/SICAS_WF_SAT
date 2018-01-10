namespace SICASv20.forms
{
    partial class ReporteInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InventarioCeroCheckBox = new System.Windows.Forms.CheckBox();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.FamiliaComboBox = new System.Windows.Forms.ComboBox();
            this.familiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refaccionesDataGridView = new System.Windows.Forms.DataGridView();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioExterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.refaccionesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 614);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Inventario";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InventarioCeroCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescripcionTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ExportarButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.BuscarButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.FamiliaComboBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 91);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Familia:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descripción:";
            // 
            // InventarioCeroCheckBox
            // 
            this.InventarioCeroCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InventarioCeroCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.InventarioCeroCheckBox, 3);
            this.InventarioCeroCheckBox.Location = new System.Drawing.Point(3, 3);
            this.InventarioCeroCheckBox.Name = "InventarioCeroCheckBox";
            this.InventarioCeroCheckBox.Size = new System.Drawing.Size(274, 19);
            this.InventarioCeroCheckBox.TabIndex = 1;
            this.InventarioCeroCheckBox.Text = "Incluir refacciones sin inventario (inventario 0)";
            this.InventarioCeroCheckBox.UseVisualStyleBackColor = true;
            this.InventarioCeroCheckBox.CheckedChanged += new System.EventHandler(this.InventarioCeroCheckBox_CheckedChanged);
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DescripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DescripcionTextBox.Location = new System.Drawing.Point(84, 28);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(276, 21);
            this.DescripcionTextBox.TabIndex = 4;
            this.DescripcionTextBox.TextChanged += new System.EventHandler(this.DescripcionTextBox_TextChanged);
            // 
            // ExportarButton
            // 
            this.ExportarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ExportarButton.Location = new System.Drawing.Point(490, 55);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(165, 33);
            this.ExportarButton.TabIndex = 6;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BuscarButton.Location = new System.Drawing.Point(366, 55);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(118, 33);
            this.BuscarButton.TabIndex = 3;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // FamiliaComboBox
            // 
            this.FamiliaComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FamiliaComboBox.DataSource = this.familiasBindingSource;
            this.FamiliaComboBox.DisplayMember = "Nombre";
            this.FamiliaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamiliaComboBox.FormattingEnabled = true;
            this.FamiliaComboBox.Location = new System.Drawing.Point(84, 60);
            this.FamiliaComboBox.Name = "FamiliaComboBox";
            this.FamiliaComboBox.Size = new System.Drawing.Size(276, 23);
            this.FamiliaComboBox.TabIndex = 8;
            this.FamiliaComboBox.ValueMember = "Familia_ID";
            this.FamiliaComboBox.SelectionChangeCommitted += new System.EventHandler(this.FamiliaComboBox_SelectionChangeCommitted);
            // 
            // familiasBindingSource
            // 
            this.familiasBindingSource.DataSource = typeof(SICASv20.Entities.Familias);
            // 
            // refaccionesDataGridView
            // 
            this.refaccionesDataGridView.AllowUserToAddRows = false;
            this.refaccionesDataGridView.AllowUserToDeleteRows = false;
            this.refaccionesDataGridView.AutoGenerateColumns = false;
            this.refaccionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.refaccionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Familia,
            this.dataGridViewTextBoxColumn11,
            this.CantidadInventario,
            this.CostoUnitario,
            this.PrecioInterno,
            this.PrecioExterno});
            this.refaccionesDataGridView.DataSource = this.refaccionesBindingSource;
            this.refaccionesDataGridView.Location = new System.Drawing.Point(6, 139);
            this.refaccionesDataGridView.Name = "refaccionesDataGridView";
            this.refaccionesDataGridView.ReadOnly = true;
            this.refaccionesDataGridView.Size = new System.Drawing.Size(975, 469);
            this.refaccionesDataGridView.TabIndex = 0;
            // 
            // Familia
            // 
            this.Familia.DataPropertyName = "Familia";
            this.Familia.HeaderText = "Familia";
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn11.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // CantidadInventario
            // 
            this.CantidadInventario.DataPropertyName = "CantidadInventario";
            this.CantidadInventario.HeaderText = "CantidadInventario";
            this.CantidadInventario.Name = "CantidadInventario";
            this.CantidadInventario.ReadOnly = true;
            // 
            // CostoUnitario
            // 
            this.CostoUnitario.DataPropertyName = "CostoUnitario";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.CostoUnitario.DefaultCellStyle = dataGridViewCellStyle1;
            this.CostoUnitario.HeaderText = "CostoUnitario";
            this.CostoUnitario.Name = "CostoUnitario";
            this.CostoUnitario.ReadOnly = true;
            // 
            // PrecioInterno
            // 
            this.PrecioInterno.DataPropertyName = "PrecioInterno";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.PrecioInterno.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioInterno.HeaderText = "PrecioInterno";
            this.PrecioInterno.Name = "PrecioInterno";
            this.PrecioInterno.ReadOnly = true;
            // 
            // PrecioExterno
            // 
            this.PrecioExterno.DataPropertyName = "PrecioExterno";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.PrecioExterno.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioExterno.HeaderText = "PrecioExterno";
            this.PrecioExterno.Name = "PrecioExterno";
            this.PrecioExterno.ReadOnly = true;
            // 
            // refaccionesBindingSource
            // 
            this.refaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Refacciones);
            // 
            // ReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteInventario";
            this.Text = "ReporteInventario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView refaccionesDataGridView;
        private System.Windows.Forms.BindingSource refaccionesBindingSource;
        private System.Windows.Forms.CheckBox InventarioCeroCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FamiliaComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioExterno;
        private System.Windows.Forms.BindingSource familiasBindingSource;
    }
}