namespace SICASv20.forms
{
    partial class DevolucionOrdenTrabajo
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
            this.ordenTrabajoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porDevolverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdenTrabajoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devolución de Orden de Trabajo";
            // 
            // SurtirTodasButton
            // 
            this.SurtirTodasButton.Location = new System.Drawing.Point(665, 74);
            this.SurtirTodasButton.Name = "SurtirTodasButton";
            this.SurtirTodasButton.Size = new System.Drawing.Size(145, 28);
            this.SurtirTodasButton.TabIndex = 13;
            this.SurtirTodasButton.Text = "Devolver Todas";
            this.SurtirTodasButton.UseVisualStyleBackColor = true;
            this.SurtirTodasButton.Click += new System.EventHandler(this.SurtirTodasButton_Click);
            // 
            // RegistrarMovimientoButton
            // 
            this.RegistrarMovimientoButton.Location = new System.Drawing.Point(816, 74);
            this.RegistrarMovimientoButton.Name = "RegistrarMovimientoButton";
            this.RegistrarMovimientoButton.Size = new System.Drawing.Size(145, 28);
            this.RegistrarMovimientoButton.TabIndex = 12;
            this.RegistrarMovimientoButton.Text = "Registrar movimiento";
            this.RegistrarMovimientoButton.UseVisualStyleBackColor = true;
            this.RegistrarMovimientoButton.Visible = false;
            this.RegistrarMovimientoButton.Click += new System.EventHandler(this.RegistrarMovimientoButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Por favor, capture una orden de trabajo a devolver:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Por favor, capture las refacciones a retirar del almacen";
            // 
            // RefaccionesGridView
            // 
            this.RefaccionesGridView.AllowUserToAddRows = false;
            this.RefaccionesGridView.AllowUserToDeleteRows = false;
            this.RefaccionesGridView.AutoGenerateColumns = false;
            this.RefaccionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordenTrabajoIDDataGridViewTextBoxColumn,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.porDevolverDataGridViewTextBoxColumn,
            this.entradaDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(31, 114);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.Size = new System.Drawing.Size(930, 485);
            this.RefaccionesGridView.TabIndex = 9;
            this.RefaccionesGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellEndEdit);
            // 
            // ordenTrabajoIDDataGridViewTextBoxColumn
            // 
            this.ordenTrabajoIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenTrabajo_ID";
            this.ordenTrabajoIDDataGridViewTextBoxColumn.HeaderText = "OrdenTrabajo_ID";
            this.ordenTrabajoIDDataGridViewTextBoxColumn.Name = "ordenTrabajoIDDataGridViewTextBoxColumn";
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            // 
            // porDevolverDataGridViewTextBoxColumn
            // 
            this.porDevolverDataGridViewTextBoxColumn.DataPropertyName = "PorDevolver";
            this.porDevolverDataGridViewTextBoxColumn.HeaderText = "PorDevolver";
            this.porDevolverDataGridViewTextBoxColumn.Name = "porDevolverDataGridViewTextBoxColumn";
            // 
            // entradaDataGridViewTextBoxColumn
            // 
            this.entradaDataGridViewTextBoxColumn.DataPropertyName = "Entrada";
            this.entradaDataGridViewTextBoxColumn.HeaderText = "Entrada";
            this.entradaDataGridViewTextBoxColumn.Name = "entradaDataGridViewTextBoxColumn";
            // 
            // vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource
            // 
            this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource.DataSource = typeof(SICASv20.Entities.Vista_RefaccionesDevolucionesOrdenesTrabajo);
            // 
            // OrdenTrabajoTextBox
            // 
            this.OrdenTrabajoTextBox.Location = new System.Drawing.Point(140, 52);
            this.OrdenTrabajoTextBox.Name = "OrdenTrabajoTextBox";
            this.OrdenTrabajoTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenTrabajoTextBox.TabIndex = 8;
            this.OrdenTrabajoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenTrabajoTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Orden de trabajo:";
            // 
            // DevolucionOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "DevolucionOrdenTrabajo";
            this.Text = "DevolucionOrdenTrabajo";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SurtirTodasButton;
        private System.Windows.Forms.Button RegistrarMovimientoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.TextBox OrdenTrabajoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenTrabajoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porDevolverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vista_RefaccionesDevolucionesOrdenesTrabajoBindingSource;
    }
}