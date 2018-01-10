namespace SICASv20.forms
{
    partial class DevolucionOrdenCompra
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
            this.SurtirTodasButton = new System.Windows.Forms.Button();
            this.RegistrarMovimientoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefaccionesGridView = new System.Windows.Forms.DataGridView();
            this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenCompraTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ordenCompraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDevolverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SurtirTodasButton);
            this.groupBox1.Controls.Add(this.RegistrarMovimientoButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RefaccionesGridView);
            this.groupBox1.Controls.Add(this.OrdenCompraTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 613);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devolución de orden de compra";
            // 
            // SurtirTodasButton
            // 
            this.SurtirTodasButton.Location = new System.Drawing.Point(652, 74);
            this.SurtirTodasButton.Name = "SurtirTodasButton";
            this.SurtirTodasButton.Size = new System.Drawing.Size(145, 28);
            this.SurtirTodasButton.TabIndex = 6;
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
            this.label3.Size = new System.Drawing.Size(332, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Por favor, capture una orden de compra para su devolucion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Por favor, capture las refacciones a retirar del almacen";
            // 
            // RefaccionesGridView
            // 
            this.RefaccionesGridView.AllowUserToAddRows = false;
            this.RefaccionesGridView.AllowUserToDeleteRows = false;
            this.RefaccionesGridView.AutoGenerateColumns = false;
            this.RefaccionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordenCompraIDDataGridViewTextBoxColumn,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.porDevolverDataGridViewTextBoxColumn,
            this.salidaDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(18, 114);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.Size = new System.Drawing.Size(930, 485);
            this.RefaccionesGridView.TabIndex = 2;
            this.RefaccionesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellEndEdit);
            // 
            // vista_RefaccionesDevolucionesOrdenesComprasBindingSource
            // 
            this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_RefaccionesDevolucionesOrdenesCompras);
            // 
            // OrdenCompraTextBox
            // 
            this.OrdenCompraTextBox.Location = new System.Drawing.Point(127, 52);
            this.OrdenCompraTextBox.Name = "OrdenCompraTextBox";
            this.OrdenCompraTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenCompraTextBox.TabIndex = 1;
            this.OrdenCompraTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenTrabajoTextBox_KeyUp);
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
            // ordenCompraIDDataGridViewTextBoxColumn
            // 
            this.ordenCompraIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.HeaderText = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.Name = "ordenCompraIDDataGridViewTextBoxColumn";
            this.ordenCompraIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            this.refaccionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            this.costoUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porDevolverDataGridViewTextBoxColumn
            // 
            this.porDevolverDataGridViewTextBoxColumn.DataPropertyName = "PorDevolver";
            this.porDevolverDataGridViewTextBoxColumn.HeaderText = "PorDevolver";
            this.porDevolverDataGridViewTextBoxColumn.Name = "porDevolverDataGridViewTextBoxColumn";
            this.porDevolverDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salidaDataGridViewTextBoxColumn
            // 
            this.salidaDataGridViewTextBoxColumn.DataPropertyName = "Salida";
            this.salidaDataGridViewTextBoxColumn.HeaderText = "Salida";
            this.salidaDataGridViewTextBoxColumn.Name = "salidaDataGridViewTextBoxColumn";
            // 
            // DevolucionOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "DevolucionOrdenCompra";
            this.Text = "DevolucionOrdenCompra";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesDevolucionesOrdenesComprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SurtirTodasButton;
        private System.Windows.Forms.Button RegistrarMovimientoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.TextBox OrdenCompraTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource vista_RefaccionesDevolucionesOrdenesComprasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porDevolverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salidaDataGridViewTextBoxColumn;

    }
}