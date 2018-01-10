namespace SICASv20.forms
{
    partial class EntradaInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FacturaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SurtirTodasButton = new System.Windows.Forms.Button();
            this.RegistrarMovimientoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefaccionesGridView = new System.Windows.Forms.DataGridView();
            this.compraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenCompraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionesSurtidasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porSurtirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ComprasAlmacenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenCompraTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasAlmacenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FacturaTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SurtirTodasButton);
            this.groupBox1.Controls.Add(this.RegistrarMovimientoButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RefaccionesGridView);
            this.groupBox1.Controls.Add(this.OrdenCompraTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 617);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada a almacen";
            // 
            // FacturaTextBox
            // 
            this.FacturaTextBox.Location = new System.Drawing.Point(413, 55);
            this.FacturaTextBox.Name = "FacturaTextBox";
            this.FacturaTextBox.Size = new System.Drawing.Size(126, 21);
            this.FacturaTextBox.TabIndex = 36;
            this.FacturaTextBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Factura:";
            this.label4.Visible = false;
            // 
            // SurtirTodasButton
            // 
            this.SurtirTodasButton.Location = new System.Drawing.Point(652, 74);
            this.SurtirTodasButton.Name = "SurtirTodasButton";
            this.SurtirTodasButton.Size = new System.Drawing.Size(145, 28);
            this.SurtirTodasButton.TabIndex = 7;
            this.SurtirTodasButton.Text = "Surtir Todas";
            this.SurtirTodasButton.UseVisualStyleBackColor = true;
            this.SurtirTodasButton.Click += new System.EventHandler(this.SurtirTodasButton_Click);
            // 
            // RegistrarMovimientoButton
            // 
            this.RegistrarMovimientoButton.Location = new System.Drawing.Point(803, 74);
            this.RegistrarMovimientoButton.Name = "RegistrarMovimientoButton";
            this.RegistrarMovimientoButton.Size = new System.Drawing.Size(145, 28);
            this.RegistrarMovimientoButton.TabIndex = 5;
            this.RegistrarMovimientoButton.Text = "Registrar movimiento";
            this.RegistrarMovimientoButton.UseVisualStyleBackColor = true;
            this.RegistrarMovimientoButton.Click += new System.EventHandler(this.RegistrarMovimientoButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(488, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Por favor, capture una orden de compra: e ingrese el número de factura correspond" +
    "iente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Por favor, capture las refacciones a ingresar";
            // 
            // RefaccionesGridView
            // 
            this.RefaccionesGridView.AllowUserToAddRows = false;
            this.RefaccionesGridView.AllowUserToDeleteRows = false;
            this.RefaccionesGridView.AutoGenerateColumns = false;
            this.RefaccionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compraIDDataGridViewTextBoxColumn,
            this.ordenCompraIDDataGridViewTextBoxColumn,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.refaccionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.refaccionesSurtidasDataGridViewTextBoxColumn,
            this.porSurtirDataGridViewTextBoxColumn,
            this.entradaDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.vista_ComprasAlmacenBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(18, 114);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.Size = new System.Drawing.Size(930, 491);
            this.RefaccionesGridView.TabIndex = 2;
            this.RefaccionesGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.RefaccionesGridView_CellBeginEdit);
            this.RefaccionesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellEndEdit);
            // 
            // compraIDDataGridViewTextBoxColumn
            // 
            this.compraIDDataGridViewTextBoxColumn.DataPropertyName = "Compra_ID";
            this.compraIDDataGridViewTextBoxColumn.HeaderText = "Compra_ID";
            this.compraIDDataGridViewTextBoxColumn.Name = "compraIDDataGridViewTextBoxColumn";
            this.compraIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // ordenCompraIDDataGridViewTextBoxColumn
            // 
            this.ordenCompraIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.HeaderText = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.Name = "ordenCompraIDDataGridViewTextBoxColumn";
            this.ordenCompraIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            this.refaccionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // refaccionDataGridViewTextBoxColumn
            // 
            this.refaccionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.HeaderText = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.Name = "refaccionDataGridViewTextBoxColumn";
            this.refaccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            dataGridViewCellStyle1.Format = "n2";
            this.costoUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Format = "n2";
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refaccionesSurtidasDataGridViewTextBoxColumn
            // 
            this.refaccionesSurtidasDataGridViewTextBoxColumn.DataPropertyName = "RefaccionesSurtidas";
            dataGridViewCellStyle3.Format = "n2";
            this.refaccionesSurtidasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.refaccionesSurtidasDataGridViewTextBoxColumn.HeaderText = "RefaccionesSurtidas";
            this.refaccionesSurtidasDataGridViewTextBoxColumn.Name = "refaccionesSurtidasDataGridViewTextBoxColumn";
            this.refaccionesSurtidasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porSurtirDataGridViewTextBoxColumn
            // 
            this.porSurtirDataGridViewTextBoxColumn.DataPropertyName = "PorSurtir";
            dataGridViewCellStyle4.Format = "n2";
            this.porSurtirDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.porSurtirDataGridViewTextBoxColumn.HeaderText = "PorSurtir";
            this.porSurtirDataGridViewTextBoxColumn.Name = "porSurtirDataGridViewTextBoxColumn";
            this.porSurtirDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // entradaDataGridViewTextBoxColumn
            // 
            this.entradaDataGridViewTextBoxColumn.DataPropertyName = "Entrada";
            dataGridViewCellStyle5.Format = "n2";
            this.entradaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.entradaDataGridViewTextBoxColumn.HeaderText = "Entrada";
            this.entradaDataGridViewTextBoxColumn.Name = "entradaDataGridViewTextBoxColumn";
            // 
            // vista_ComprasAlmacenBindingSource
            // 
            this.vista_ComprasAlmacenBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ComprasAlmacen);
            // 
            // OrdenCompraTextBox
            // 
            this.OrdenCompraTextBox.Location = new System.Drawing.Point(127, 52);
            this.OrdenCompraTextBox.Name = "OrdenCompraTextBox";
            this.OrdenCompraTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenCompraTextBox.TabIndex = 1;
            this.OrdenCompraTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenCompraTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de compra:";
            // 
            // EntradaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 637);
            this.Controls.Add(this.groupBox1);
            this.Name = "EntradaInventario";
            this.Text = "EntradaInventario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasAlmacenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RegistrarMovimientoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.TextBox OrdenCompraTextBox;
        private System.Windows.Forms.BindingSource vista_ComprasAlmacenBindingSource;
        private System.Windows.Forms.Button SurtirTodasButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionesSurtidasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porSurtirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FacturaTextBox;
    }
}