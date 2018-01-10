namespace SICASv20.forms
{
    partial class Opciones
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
            this.OpcionesGridView = new System.Windows.Forms.DataGridView();
            this.vistaOpcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.vista_OpcionesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Vista_OpcionesTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ModuloComboBox = new System.Windows.Forms.ComboBox();
            this.getModulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MenuComboBox = new System.Windows.Forms.ComboBox();
            this.getMenuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OpcionIDTextBox = new System.Windows.Forms.TextBox();
            this.get_ModulosTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter();
            this.get_MenuesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Actualizar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Opcion_IDCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esHerramientaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpcionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaOpcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getModulosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OpcionesGridView);
            this.groupBox1.Location = new System.Drawing.Point(21, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 580);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de Menues";
            // 
            // OpcionesGridView
            // 
            this.OpcionesGridView.AllowUserToAddRows = false;
            this.OpcionesGridView.AllowUserToDeleteRows = false;
            this.OpcionesGridView.AutoGenerateColumns = false;
            this.OpcionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OpcionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Actualizar,
            this.Eliminar,
            this.Opcion_IDCell,
            this.moduloDataGridViewTextBoxColumn,
            this.menuDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.textoDataGridViewTextBoxColumn,
            this.imagenDataGridViewTextBoxColumn,
            this.esHerramientaDataGridViewCheckBoxColumn});
            this.OpcionesGridView.DataSource = this.vistaOpcionesBindingSource;
            this.OpcionesGridView.Location = new System.Drawing.Point(26, 39);
            this.OpcionesGridView.Name = "OpcionesGridView";
            this.OpcionesGridView.ReadOnly = true;
            this.OpcionesGridView.Size = new System.Drawing.Size(934, 538);
            this.OpcionesGridView.TabIndex = 0;
            this.OpcionesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OpcionesGridView_CellContentClick);
            // 
            // vistaOpcionesBindingSource
            // 
            this.vistaOpcionesBindingSource.DataMember = "Vista_Opciones";
            this.vistaOpcionesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vista_OpcionesTableAdapter
            // 
            this.vista_OpcionesTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.305065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.19906F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.067138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.43699F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.242639F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.26148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.ConsultarButton, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ModuloComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.MenuComboBox, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.OpcionIDTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 29);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ConsultarButton.Location = new System.Drawing.Point(771, 3);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 23);
            this.ConsultarButton.TabIndex = 0;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opcion ID:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modulo:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Menu:";
            // 
            // ModuloComboBox
            // 
            this.ModuloComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ModuloComboBox.DataSource = this.getModulosBindingSource;
            this.ModuloComboBox.DisplayMember = "Nombre";
            this.ModuloComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModuloComboBox.FormattingEnabled = true;
            this.ModuloComboBox.Location = new System.Drawing.Point(305, 4);
            this.ModuloComboBox.Name = "ModuloComboBox";
            this.ModuloComboBox.Size = new System.Drawing.Size(160, 23);
            this.ModuloComboBox.TabIndex = 4;
            this.ModuloComboBox.ValueMember = "Modulo_ID";
            this.ModuloComboBox.SelectionChangeCommitted += new System.EventHandler(this.ModuloComboBox_SelectionChangeCommitted);
            // 
            // getModulosBindingSource
            // 
            this.getModulosBindingSource.DataMember = "Get_Modulos";
            this.getModulosBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // MenuComboBox
            // 
            this.MenuComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MenuComboBox.DataSource = this.getMenuesBindingSource;
            this.MenuComboBox.DisplayMember = "Nombre";
            this.MenuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MenuComboBox.FormattingEnabled = true;
            this.MenuComboBox.Location = new System.Drawing.Point(540, 4);
            this.MenuComboBox.Name = "MenuComboBox";
            this.MenuComboBox.Size = new System.Drawing.Size(163, 23);
            this.MenuComboBox.TabIndex = 5;
            this.MenuComboBox.ValueMember = "Menu_ID";
            // 
            // getMenuesBindingSource
            // 
            this.getMenuesBindingSource.DataMember = "Get_Menues";
            this.getMenuesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // OpcionIDTextBox
            // 
            this.OpcionIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OpcionIDTextBox.Location = new System.Drawing.Point(82, 4);
            this.OpcionIDTextBox.Name = "OpcionIDTextBox";
            this.OpcionIDTextBox.Size = new System.Drawing.Size(131, 21);
            this.OpcionIDTextBox.TabIndex = 6;
            // 
            // get_ModulosTableAdapter
            // 
            this.get_ModulosTableAdapter.ClearBeforeFill = true;
            // 
            // get_MenuesTableAdapter
            // 
            this.get_MenuesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(21, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(982, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros de búsqueda";
            // 
            // Actualizar
            // 
            this.Actualizar.HeaderText = "";
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.ReadOnly = true;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseColumnTextForLinkValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForLinkValue = true;
            // 
            // Opcion_IDCell
            // 
            this.Opcion_IDCell.DataPropertyName = "Opcion_ID";
            this.Opcion_IDCell.HeaderText = "Opcion_ID";
            this.Opcion_IDCell.Name = "Opcion_IDCell";
            this.Opcion_IDCell.ReadOnly = true;
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.moduloDataGridViewTextBoxColumn.DataPropertyName = "Modulo";
            this.moduloDataGridViewTextBoxColumn.HeaderText = "Modulo";
            this.moduloDataGridViewTextBoxColumn.Name = "moduloDataGridViewTextBoxColumn";
            this.moduloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuDataGridViewTextBoxColumn
            // 
            this.menuDataGridViewTextBoxColumn.DataPropertyName = "Menu";
            this.menuDataGridViewTextBoxColumn.HeaderText = "Menu";
            this.menuDataGridViewTextBoxColumn.Name = "menuDataGridViewTextBoxColumn";
            this.menuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textoDataGridViewTextBoxColumn
            // 
            this.textoDataGridViewTextBoxColumn.DataPropertyName = "Texto";
            this.textoDataGridViewTextBoxColumn.HeaderText = "Texto";
            this.textoDataGridViewTextBoxColumn.Name = "textoDataGridViewTextBoxColumn";
            this.textoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imagenDataGridViewTextBoxColumn
            // 
            this.imagenDataGridViewTextBoxColumn.DataPropertyName = "Imagen";
            this.imagenDataGridViewTextBoxColumn.HeaderText = "Imagen";
            this.imagenDataGridViewTextBoxColumn.Name = "imagenDataGridViewTextBoxColumn";
            this.imagenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // esHerramientaDataGridViewCheckBoxColumn
            // 
            this.esHerramientaDataGridViewCheckBoxColumn.DataPropertyName = "EsHerramienta";
            this.esHerramientaDataGridViewCheckBoxColumn.HeaderText = "EsHerramienta";
            this.esHerramientaDataGridViewCheckBoxColumn.Name = "esHerramientaDataGridViewCheckBoxColumn";
            this.esHerramientaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // Opciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Opciones";
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.Opciones_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OpcionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaOpcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getModulosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView OpcionesGridView;
        private System.Windows.Forms.BindingSource vistaOpcionesBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralQuerysDataSetTableAdapters.Vista_OpcionesTableAdapter vista_OpcionesTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ModuloComboBox;
        private System.Windows.Forms.ComboBox MenuComboBox;
        private System.Windows.Forms.TextBox OpcionIDTextBox;
        private System.Windows.Forms.BindingSource getModulosBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter get_ModulosTableAdapter;
        private System.Windows.Forms.BindingSource getMenuesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter get_MenuesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewLinkColumn Actualizar;
        private System.Windows.Forms.DataGridViewLinkColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opcion_IDCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esHerramientaDataGridViewCheckBoxColumn;

    }
}