namespace SICASv20.forms
{
    partial class SalidaInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SurtirTodasButton = new System.Windows.Forms.Button();
            this.RegistrarMovimientoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefaccionesGridView = new System.Windows.Forms.DataGridView();
            this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenTrabajoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refSurtidasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porSurtirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SurtirTodasButton);
            this.groupBox1.Controls.Add(this.RegistrarMovimientoButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RefaccionesGridView);
            this.groupBox1.Controls.Add(this.OrdenTrabajoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 613);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salida de inventario";
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
            this.label3.Size = new System.Drawing.Size(222, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Por favor, capture una orden de trabajo:";
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
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.refaccionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.CantidadInventario,
            this.cantidadDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.refSurtidasDataGridViewTextBoxColumn,
            this.porSurtirDataGridViewTextBoxColumn,
            this.salidaDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(18, 114);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.Size = new System.Drawing.Size(930, 485);
            this.RefaccionesGridView.TabIndex = 2;
            this.RefaccionesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellEndEdit);
            this.RefaccionesGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.RefaccionesGridView_DataBindingComplete);
            // 
            // vista_OrdenesServiciosRefaccionesAlmacenBindingSource
            // 
            this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource.DataSource = typeof(SICASv20.Entities.Vista_OrdenesServiciosRefaccionesAlmacen);
            // 
            // OrdenTrabajoTextBox
            // 
            this.OrdenTrabajoTextBox.Location = new System.Drawing.Point(127, 52);
            this.OrdenTrabajoTextBox.Name = "OrdenTrabajoTextBox";
            this.OrdenTrabajoTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenTrabajoTextBox.TabIndex = 1;
            this.OrdenTrabajoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenTrabajoTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de trabajo:";
            // 
            // ordenServicioRefaccionIDDataGridViewTextBoxColumn
            // 
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenServicioRefaccion_ID";
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn.HeaderText = "OrdenServicioRefaccion_ID";
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn.Name = "ordenServicioRefaccionIDDataGridViewTextBoxColumn";
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenServicioRefaccionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            this.refaccionIDDataGridViewTextBoxColumn.ReadOnly = true;
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
            dataGridViewCellStyle8.Format = "n2";
            this.costoUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            this.costoUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle9.Format = "n2";
            this.precioUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "PrecioUnitario";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioUnitarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // CantidadInventario
            // 
            this.CantidadInventario.DataPropertyName = "CantidadInventario";
            this.CantidadInventario.HeaderText = "Inventario";
            this.CantidadInventario.Name = "CantidadInventario";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle10.Format = "n2";
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle11.Format = "n2";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Visible = false;
            // 
            // refSurtidasDataGridViewTextBoxColumn
            // 
            this.refSurtidasDataGridViewTextBoxColumn.DataPropertyName = "RefSurtidas";
            dataGridViewCellStyle12.Format = "n2";
            this.refSurtidasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.refSurtidasDataGridViewTextBoxColumn.HeaderText = "RefSurtidas";
            this.refSurtidasDataGridViewTextBoxColumn.Name = "refSurtidasDataGridViewTextBoxColumn";
            this.refSurtidasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porSurtirDataGridViewTextBoxColumn
            // 
            this.porSurtirDataGridViewTextBoxColumn.DataPropertyName = "PorSurtir";
            dataGridViewCellStyle13.Format = "n2";
            this.porSurtirDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.porSurtirDataGridViewTextBoxColumn.HeaderText = "PorSurtir";
            this.porSurtirDataGridViewTextBoxColumn.Name = "porSurtirDataGridViewTextBoxColumn";
            this.porSurtirDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salidaDataGridViewTextBoxColumn
            // 
            this.salidaDataGridViewTextBoxColumn.DataPropertyName = "Salida";
            dataGridViewCellStyle14.Format = "n2";
            this.salidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.salidaDataGridViewTextBoxColumn.HeaderText = "Salida";
            this.salidaDataGridViewTextBoxColumn.Name = "salidaDataGridViewTextBoxColumn";
            // 
            // SalidaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 632);
            this.Controls.Add(this.groupBox1);
            this.Name = "SalidaInventario";
            this.Text = "EntradaInventario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesServiciosRefaccionesAlmacenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RegistrarMovimientoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.TextBox OrdenTrabajoTextBox;
        private System.Windows.Forms.BindingSource vista_OrdenesServiciosRefaccionesAlmacenBindingSource;
        private System.Windows.Forms.Button SurtirTodasButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenServicioRefaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refSurtidasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porSurtirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salidaDataGridViewTextBoxColumn;
    }
}