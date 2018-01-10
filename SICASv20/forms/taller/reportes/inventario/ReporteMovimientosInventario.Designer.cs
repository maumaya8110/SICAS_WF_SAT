namespace SICASv20.forms
{
    partial class ReporteMovimientosInventario
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
            this.ReporteMovimientosInventarioDataGridView = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenTrabajoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ajusteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notaAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadPrevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadPostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_MovimientosInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TipoMovimientoInventarioComboBox = new System.Windows.Forms.ComboBox();
            this.selectTiposMovimientosInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DescripcionRefaccionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OrdenCompra_IDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OrdenTrabajo_IDTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AjusteInventario_IDTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteMovimientosInventarioDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_MovimientosInventarioBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposMovimientosInventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReporteMovimientosInventarioDataGridView);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Movimientos de Inventario";
            // 
            // ReporteMovimientosInventarioDataGridView
            // 
            this.ReporteMovimientosInventarioDataGridView.AllowUserToAddRows = false;
            this.ReporteMovimientosInventarioDataGridView.AllowUserToDeleteRows = false;
            this.ReporteMovimientosInventarioDataGridView.AutoGenerateColumns = false;
            this.ReporteMovimientosInventarioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReporteMovimientosInventarioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.ordenCompraDataGridViewTextBoxColumn,
            this.ordenTrabajoDataGridViewTextBoxColumn,
            this.ajusteDataGridViewTextBoxColumn,
            this.notaAlmacenDataGridViewTextBoxColumn,
            this.refaccionDataGridViewTextBoxColumn,
            this.cantidadPrevDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.cantidadPostDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.usuarioIDDataGridViewTextBoxColumn});
            this.ReporteMovimientosInventarioDataGridView.DataSource = this.vista_MovimientosInventarioBindingSource;
            this.ReporteMovimientosInventarioDataGridView.Location = new System.Drawing.Point(17, 211);
            this.ReporteMovimientosInventarioDataGridView.Name = "ReporteMovimientosInventarioDataGridView";
            this.ReporteMovimientosInventarioDataGridView.ReadOnly = true;
            this.ReporteMovimientosInventarioDataGridView.Size = new System.Drawing.Size(951, 399);
            this.ReporteMovimientosInventarioDataGridView.TabIndex = 1;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenCompraDataGridViewTextBoxColumn
            // 
            this.ordenCompraDataGridViewTextBoxColumn.DataPropertyName = "OrdenCompra";
            this.ordenCompraDataGridViewTextBoxColumn.HeaderText = "OrdenCompra";
            this.ordenCompraDataGridViewTextBoxColumn.Name = "ordenCompraDataGridViewTextBoxColumn";
            this.ordenCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenTrabajoDataGridViewTextBoxColumn
            // 
            this.ordenTrabajoDataGridViewTextBoxColumn.DataPropertyName = "OrdenTrabajo";
            this.ordenTrabajoDataGridViewTextBoxColumn.HeaderText = "OrdenTrabajo";
            this.ordenTrabajoDataGridViewTextBoxColumn.Name = "ordenTrabajoDataGridViewTextBoxColumn";
            this.ordenTrabajoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ajusteDataGridViewTextBoxColumn
            // 
            this.ajusteDataGridViewTextBoxColumn.DataPropertyName = "Ajuste";
            this.ajusteDataGridViewTextBoxColumn.HeaderText = "Ajuste";
            this.ajusteDataGridViewTextBoxColumn.Name = "ajusteDataGridViewTextBoxColumn";
            this.ajusteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notaAlmacenDataGridViewTextBoxColumn
            // 
            this.notaAlmacenDataGridViewTextBoxColumn.DataPropertyName = "NotaAlmacen";
            this.notaAlmacenDataGridViewTextBoxColumn.HeaderText = "NotaAlmacen";
            this.notaAlmacenDataGridViewTextBoxColumn.Name = "notaAlmacenDataGridViewTextBoxColumn";
            this.notaAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refaccionDataGridViewTextBoxColumn
            // 
            this.refaccionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.HeaderText = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.Name = "refaccionDataGridViewTextBoxColumn";
            this.refaccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPrevDataGridViewTextBoxColumn
            // 
            this.cantidadPrevDataGridViewTextBoxColumn.DataPropertyName = "CantidadPrev";
            this.cantidadPrevDataGridViewTextBoxColumn.HeaderText = "CantidadPrev";
            this.cantidadPrevDataGridViewTextBoxColumn.Name = "cantidadPrevDataGridViewTextBoxColumn";
            this.cantidadPrevDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadPostDataGridViewTextBoxColumn
            // 
            this.cantidadPostDataGridViewTextBoxColumn.DataPropertyName = "CantidadPost";
            this.cantidadPostDataGridViewTextBoxColumn.HeaderText = "CantidadPost";
            this.cantidadPostDataGridViewTextBoxColumn.Name = "cantidadPostDataGridViewTextBoxColumn";
            this.cantidadPostDataGridViewTextBoxColumn.ReadOnly = true;
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
            // vista_MovimientosInventarioBindingSource
            // 
            this.vista_MovimientosInventarioBindingSource.DataSource = typeof(SICASv20.Entities.Vista_MovimientosInventario);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportarButton);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.BuscarButton);
            this.groupBox2.Location = new System.Drawing.Point(17, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(951, 174);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(789, 91);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(117, 39);
            this.ExportarButton.TabIndex = 15;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TipoMovimientoInventarioComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DescripcionRefaccionTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FechaInicialDateTimePicker, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FechaFinalDateTimePicker, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.OrdenCompra_IDTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.OrdenTrabajo_IDTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.AjusteInventario_IDTextBox, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(29, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 127);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Movimiento:";
            // 
            // TipoMovimientoInventarioComboBox
            // 
            this.TipoMovimientoInventarioComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TipoMovimientoInventarioComboBox.DataSource = this.selectTiposMovimientosInventarioBindingSource;
            this.TipoMovimientoInventarioComboBox.DisplayMember = "Nombre";
            this.TipoMovimientoInventarioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoMovimientoInventarioComboBox.FormattingEnabled = true;
            this.TipoMovimientoInventarioComboBox.Location = new System.Drawing.Point(116, 5);
            this.TipoMovimientoInventarioComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.TipoMovimientoInventarioComboBox.Name = "TipoMovimientoInventarioComboBox";
            this.TipoMovimientoInventarioComboBox.Size = new System.Drawing.Size(202, 23);
            this.TipoMovimientoInventarioComboBox.TabIndex = 1;
            this.TipoMovimientoInventarioComboBox.ValueMember = "TipoMovimientoInventario_ID";
            this.TipoMovimientoInventarioComboBox.SelectionChangeCommitted += new System.EventHandler(this.TipoMovimientoInventarioComboBox_SelectionChangeCommitted);
            // 
            // selectTiposMovimientosInventarioBindingSource
            // 
            this.selectTiposMovimientosInventarioBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposMovimientosInventario);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Refacción:";
            // 
            // DescripcionRefaccionTextBox
            // 
            this.DescripcionRefaccionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DescripcionRefaccionTextBox.Location = new System.Drawing.Point(116, 38);
            this.DescripcionRefaccionTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.DescripcionRefaccionTextBox.Name = "DescripcionRefaccionTextBox";
            this.DescripcionRefaccionTextBox.Size = new System.Drawing.Size(311, 21);
            this.DescripcionRefaccionTextBox.TabIndex = 3;
            this.DescripcionRefaccionTextBox.TextChanged += new System.EventHandler(this.DescripcionRefaccionTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Inicial:";
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaInicialDateTimePicker.Checked = false;
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(116, 69);
            this.FechaInicialDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(138, 21);
            this.FechaInicialDateTimePicker.TabIndex = 5;
            this.FechaInicialDateTimePicker.ValueChanged += new System.EventHandler(this.FechaInicialDateTimePicker_ValueChanged);
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FechaFinalDateTimePicker.Checked = false;
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(116, 100);
            this.FechaFinalDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(138, 21);
            this.FechaFinalDateTimePicker.TabIndex = 6;
            this.FechaFinalDateTimePicker.ValueChanged += new System.EventHandler(this.FechaFinalDateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Final:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Orden de Compra:";
            // 
            // OrdenCompra_IDTextBox
            // 
            this.OrdenCompra_IDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OrdenCompra_IDTextBox.Location = new System.Drawing.Point(555, 6);
            this.OrdenCompra_IDTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.OrdenCompra_IDTextBox.Name = "OrdenCompra_IDTextBox";
            this.OrdenCompra_IDTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenCompra_IDTextBox.TabIndex = 9;
            this.OrdenCompra_IDTextBox.TextChanged += new System.EventHandler(this.OrdenCompra_IDTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Orden de Trabajo:";
            // 
            // OrdenTrabajo_IDTextBox
            // 
            this.OrdenTrabajo_IDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OrdenTrabajo_IDTextBox.Location = new System.Drawing.Point(555, 38);
            this.OrdenTrabajo_IDTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.OrdenTrabajo_IDTextBox.Name = "OrdenTrabajo_IDTextBox";
            this.OrdenTrabajo_IDTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenTrabajo_IDTextBox.TabIndex = 11;
            this.OrdenTrabajo_IDTextBox.TextChanged += new System.EventHandler(this.OrdenTrabajo_IDTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(437, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Folio de Ajuste:";
            // 
            // AjusteInventario_IDTextBox
            // 
            this.AjusteInventario_IDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AjusteInventario_IDTextBox.Location = new System.Drawing.Point(555, 69);
            this.AjusteInventario_IDTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.AjusteInventario_IDTextBox.Name = "AjusteInventario_IDTextBox";
            this.AjusteInventario_IDTextBox.Size = new System.Drawing.Size(100, 21);
            this.AjusteInventario_IDTextBox.TabIndex = 13;
            this.AjusteInventario_IDTextBox.TextChanged += new System.EventHandler(this.AjusteInventario_IDTextBox_TextChanged);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(789, 48);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(117, 39);
            this.BuscarButton.TabIndex = 14;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // ReporteMovimientosInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteMovimientosInventario";
            this.Text = "ReporteMovimientosInventario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteMovimientosInventarioDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_MovimientosInventarioBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposMovimientosInventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ReporteMovimientosInventarioDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoMovimientoInventarioComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescripcionRefaccionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OrdenCompra_IDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OrdenTrabajo_IDTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AjusteInventario_IDTextBox;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenTrabajoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ajusteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notaAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadPrevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadPostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vista_MovimientosInventarioBindingSource;
        private System.Windows.Forms.BindingSource selectTiposMovimientosInventarioBindingSource;
    }
}