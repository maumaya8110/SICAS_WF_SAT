namespace SICASv20.forms
{
    partial class OrdenesCompras
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OrdenCompra_IDTextBox = new System.Windows.Forms.TextBox();
            this.Proveedor_IDTextBox = new System.Windows.Forms.TextBox();
            this.BuscarProveedoresButton = new System.Windows.Forms.Button();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NombreProveedorTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OrdenesComprasGridView = new System.Windows.Forms.DataGridView();
            this.ActualizarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.VerColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CancelarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ordenCompraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_OrdenesComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesComprasGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesComprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.OrdenesComprasGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenes de compra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OrdenCompra_IDTextBox);
            this.groupBox2.Controls.Add(this.Proveedor_IDTextBox);
            this.groupBox2.Controls.Add(this.BuscarProveedoresButton);
            this.groupBox2.Controls.Add(this.FechaFinalDateTimePicker);
            this.groupBox2.Controls.Add(this.FechaInicialDateTimePicker);
            this.groupBox2.Controls.Add(this.NombreProveedorTextBox);
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(22, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros de búsqueda";
            // 
            // OrdenCompra_IDTextBox
            // 
            this.OrdenCompra_IDTextBox.Location = new System.Drawing.Point(159, 23);
            this.OrdenCompra_IDTextBox.Name = "OrdenCompra_IDTextBox";
            this.OrdenCompra_IDTextBox.Size = new System.Drawing.Size(96, 21);
            this.OrdenCompra_IDTextBox.TabIndex = 12;
            this.OrdenCompra_IDTextBox.TextChanged += new System.EventHandler(this.OrdenCompra_IDTextBox_TextChanged);
            // 
            // Proveedor_IDTextBox
            // 
            this.Proveedor_IDTextBox.Location = new System.Drawing.Point(159, 50);
            this.Proveedor_IDTextBox.Name = "Proveedor_IDTextBox";
            this.Proveedor_IDTextBox.Size = new System.Drawing.Size(95, 21);
            this.Proveedor_IDTextBox.TabIndex = 11;
            this.Proveedor_IDTextBox.TextChanged += new System.EventHandler(this.Proveedor_IDTextBox_TextChanged);
            // 
            // BuscarProveedoresButton
            // 
            this.BuscarProveedoresButton.Location = new System.Drawing.Point(570, 48);
            this.BuscarProveedoresButton.Name = "BuscarProveedoresButton";
            this.BuscarProveedoresButton.Size = new System.Drawing.Size(36, 23);
            this.BuscarProveedoresButton.TabIndex = 10;
            this.BuscarProveedoresButton.Text = "...";
            this.BuscarProveedoresButton.UseVisualStyleBackColor = true;
            this.BuscarProveedoresButton.Click += new System.EventHandler(this.BuscarProveedoresButton_Click);
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Checked = false;
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(719, 49);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(114, 21);
            this.FechaFinalDateTimePicker.TabIndex = 9;
            this.FechaFinalDateTimePicker.ValueChanged += new System.EventHandler(this.FechaFinalDateTimePicker_ValueChanged);            
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Checked = false;
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(719, 20);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(114, 21);
            this.FechaInicialDateTimePicker.TabIndex = 8;
            this.FechaInicialDateTimePicker.ValueChanged += new System.EventHandler(this.FechaInicialDateTimePicker_ValueChanged);            
            // 
            // NombreProveedorTextBox
            // 
            this.NombreProveedorTextBox.Location = new System.Drawing.Point(260, 50);
            this.NombreProveedorTextBox.Name = "NombreProveedorTextBox";
            this.NombreProveedorTextBox.Size = new System.Drawing.Size(304, 21);
            this.NombreProveedorTextBox.TabIndex = 6;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(854, 24);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 38);
            this.BuscarButton.TabIndex = 4;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proveedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de compra ID:";
            // 
            // OrdenesComprasGridView
            // 
            this.OrdenesComprasGridView.AllowUserToAddRows = false;
            this.OrdenesComprasGridView.AllowUserToDeleteRows = false;
            this.OrdenesComprasGridView.AutoGenerateColumns = false;
            this.OrdenesComprasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdenesComprasGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActualizarColumn,
            this.VerColumn,
            this.CancelarColumn,
            this.ordenCompraIDDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.proveedorDataGridViewTextBoxColumn,
            this.facturaDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.iVADataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.usuarioIDDataGridViewTextBoxColumn});
            this.OrdenesComprasGridView.DataSource = this.vista_OrdenesComprasBindingSource;
            this.OrdenesComprasGridView.Location = new System.Drawing.Point(22, 120);
            this.OrdenesComprasGridView.Name = "OrdenesComprasGridView";
            this.OrdenesComprasGridView.ReadOnly = true;
            this.OrdenesComprasGridView.Size = new System.Drawing.Size(948, 486);
            this.OrdenesComprasGridView.TabIndex = 0;
            this.OrdenesComprasGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrdenesComprasGridView_CellContentClick);
            // 
            // ActualizarColumn
            // 
            this.ActualizarColumn.HeaderText = "";
            this.ActualizarColumn.Name = "ActualizarColumn";
            this.ActualizarColumn.ReadOnly = true;
            this.ActualizarColumn.Text = "Actualizar";
            this.ActualizarColumn.UseColumnTextForLinkValue = true;
            // 
            // VerColumn
            // 
            this.VerColumn.HeaderText = "";
            this.VerColumn.Name = "VerColumn";
            this.VerColumn.ReadOnly = true;
            this.VerColumn.Text = "Ver Compras";
            this.VerColumn.UseColumnTextForLinkValue = true;
            // 
            // CancelarColumn
            // 
            this.CancelarColumn.HeaderText = "";
            this.CancelarColumn.Name = "CancelarColumn";
            this.CancelarColumn.ReadOnly = true;
            this.CancelarColumn.Text = "Cancelar";
            this.CancelarColumn.UseColumnTextForLinkValue = true;
            // 
            // ordenCompraIDDataGridViewTextBoxColumn
            // 
            this.ordenCompraIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.HeaderText = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.Name = "ordenCompraIDDataGridViewTextBoxColumn";
            this.ordenCompraIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            this.proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facturaDataGridViewTextBoxColumn
            // 
            this.facturaDataGridViewTextBoxColumn.DataPropertyName = "Factura";
            this.facturaDataGridViewTextBoxColumn.HeaderText = "Factura";
            this.facturaDataGridViewTextBoxColumn.Name = "facturaDataGridViewTextBoxColumn";
            this.facturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iVADataGridViewTextBoxColumn
            // 
            this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
            this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
            this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
            this.iVADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioIDDataGridViewTextBoxColumn
            // 
            this.usuarioIDDataGridViewTextBoxColumn.DataPropertyName = "Usuario_ID";
            this.usuarioIDDataGridViewTextBoxColumn.HeaderText = "Usuario_ID";
            this.usuarioIDDataGridViewTextBoxColumn.Name = "usuarioIDDataGridViewTextBoxColumn";
            this.usuarioIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vista_OrdenesComprasBindingSource
            // 
            this.vista_OrdenesComprasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_OrdenesCompras);
            // 
            // OrdenesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdenesCompras";
            this.Text = "OrdenesCompras";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesComprasGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesComprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.TextBox NombreProveedorTextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView OrdenesComprasGridView;
        private System.Windows.Forms.Button BuscarProveedoresButton;
        private System.Windows.Forms.TextBox OrdenCompra_IDTextBox;
        private System.Windows.Forms.TextBox Proveedor_IDTextBox;
        private System.Windows.Forms.BindingSource vista_OrdenesComprasBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn ActualizarColumn;
        private System.Windows.Forms.DataGridViewLinkColumn VerColumn;
        private System.Windows.Forms.DataGridViewLinkColumn CancelarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
    }
}