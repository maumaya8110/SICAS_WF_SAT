namespace SICASv20.forms
{
    partial class AltaOrdenCompra
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FacturaTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoProveedorTextBox = new System.Windows.Forms.TextBox();
            this.NombreProveedorTextBox = new System.Windows.Forms.TextBox();
            this.CantidadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BuscarProveedorButton = new System.Windows.Forms.Button();
            this.AgregarAOrdenButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalRefaccionTextBox = new System.Windows.Forms.TextBox();
            this.CodigoRefaccionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreRefaccionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BuscarRefaccionButton = new System.Windows.Forms.Button();
            this.CostoUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.CostoUnitario = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RegistrarOrdenButton = new System.Windows.Forms.Button();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IVATextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SubTotalTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CantidadRefaccionesTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RefaccionesGridView = new System.Windows.Forms.DataGridView();
            this.Cancelar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva orden de compra";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FacturaTextBox);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.CodigoProveedorTextBox);
            this.groupBox4.Controls.Add(this.NombreProveedorTextBox);
            this.groupBox4.Controls.Add(this.CantidadNumericUpDown);
            this.groupBox4.Controls.Add(this.BuscarProveedorButton);
            this.groupBox4.Controls.Add(this.AgregarAOrdenButton);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.TotalRefaccionTextBox);
            this.groupBox4.Controls.Add(this.CodigoRefaccionTextBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.NombreRefaccionTextBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.BuscarRefaccionButton);
            this.groupBox4.Controls.Add(this.CostoUnitarioTextBox);
            this.groupBox4.Controls.Add(this.CostoUnitario);
            this.groupBox4.Location = new System.Drawing.Point(17, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(678, 206);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Agregar refacciones";
            // 
            // FacturaTextBox
            // 
            this.FacturaTextBox.Enabled = false;
            this.FacturaTextBox.Location = new System.Drawing.Point(112, 159);
            this.FacturaTextBox.Name = "FacturaTextBox";
            this.FacturaTextBox.Size = new System.Drawing.Size(126, 21);
            this.FacturaTextBox.TabIndex = 35;
            this.FacturaTextBox.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Factura:";
            this.label9.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Provedor:";
            // 
            // CodigoProveedorTextBox
            // 
            this.CodigoProveedorTextBox.Location = new System.Drawing.Point(77, 25);
            this.CodigoProveedorTextBox.Name = "CodigoProveedorTextBox";
            this.CodigoProveedorTextBox.Size = new System.Drawing.Size(71, 21);
            this.CodigoProveedorTextBox.TabIndex = 19;
            this.CodigoProveedorTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodigoProveedorTextBox_KeyUp);
            // 
            // NombreProveedorTextBox
            // 
            this.NombreProveedorTextBox.Location = new System.Drawing.Point(154, 25);
            this.NombreProveedorTextBox.Name = "NombreProveedorTextBox";
            this.NombreProveedorTextBox.Size = new System.Drawing.Size(449, 21);
            this.NombreProveedorTextBox.TabIndex = 20;
            // 
            // CantidadNumericUpDown
            // 
            this.CantidadNumericUpDown.Location = new System.Drawing.Point(114, 106);
            this.CantidadNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.CantidadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CantidadNumericUpDown.Name = "CantidadNumericUpDown";
            this.CantidadNumericUpDown.Size = new System.Drawing.Size(102, 21);
            this.CantidadNumericUpDown.TabIndex = 33;
            this.CantidadNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CantidadNumericUpDown.ValueChanged += new System.EventHandler(this.CantidadNumericUpDown_ValueChanged);
            // 
            // BuscarProveedorButton
            // 
            this.BuscarProveedorButton.Location = new System.Drawing.Point(627, 23);
            this.BuscarProveedorButton.Name = "BuscarProveedorButton";
            this.BuscarProveedorButton.Size = new System.Drawing.Size(32, 23);
            this.BuscarProveedorButton.TabIndex = 21;
            this.BuscarProveedorButton.Text = "...";
            this.BuscarProveedorButton.UseVisualStyleBackColor = true;
            this.BuscarProveedorButton.Click += new System.EventHandler(this.BuscarProveedorButton_Click);
            // 
            // AgregarAOrdenButton
            // 
            this.AgregarAOrdenButton.Location = new System.Drawing.Point(545, 171);
            this.AgregarAOrdenButton.Name = "AgregarAOrdenButton";
            this.AgregarAOrdenButton.Size = new System.Drawing.Size(121, 23);
            this.AgregarAOrdenButton.TabIndex = 32;
            this.AgregarAOrdenButton.Text = "Agregar a orden";
            this.AgregarAOrdenButton.UseVisualStyleBackColor = true;
            this.AgregarAOrdenButton.Click += new System.EventHandler(this.AgregarAOrdenButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Refacción:";
            // 
            // TotalRefaccionTextBox
            // 
            this.TotalRefaccionTextBox.Location = new System.Drawing.Point(112, 133);
            this.TotalRefaccionTextBox.Name = "TotalRefaccionTextBox";
            this.TotalRefaccionTextBox.Size = new System.Drawing.Size(126, 21);
            this.TotalRefaccionTextBox.TabIndex = 31;
            // 
            // CodigoRefaccionTextBox
            // 
            this.CodigoRefaccionTextBox.Location = new System.Drawing.Point(77, 52);
            this.CodigoRefaccionTextBox.Name = "CodigoRefaccionTextBox";
            this.CodigoRefaccionTextBox.Size = new System.Drawing.Size(71, 21);
            this.CodigoRefaccionTextBox.TabIndex = 23;
            this.CodigoRefaccionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodigoRefaccionTextBox_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Total refacción:";
            // 
            // NombreRefaccionTextBox
            // 
            this.NombreRefaccionTextBox.Location = new System.Drawing.Point(154, 52);
            this.NombreRefaccionTextBox.Name = "NombreRefaccionTextBox";
            this.NombreRefaccionTextBox.Size = new System.Drawing.Size(449, 21);
            this.NombreRefaccionTextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cantidad:";
            // 
            // BuscarRefaccionButton
            // 
            this.BuscarRefaccionButton.Location = new System.Drawing.Point(627, 50);
            this.BuscarRefaccionButton.Name = "BuscarRefaccionButton";
            this.BuscarRefaccionButton.Size = new System.Drawing.Size(32, 23);
            this.BuscarRefaccionButton.TabIndex = 25;
            this.BuscarRefaccionButton.Text = "...";
            this.BuscarRefaccionButton.UseVisualStyleBackColor = true;
            this.BuscarRefaccionButton.Click += new System.EventHandler(this.BuscarRefaccionButton_Click);
            // 
            // CostoUnitarioTextBox
            // 
            this.CostoUnitarioTextBox.Location = new System.Drawing.Point(112, 79);
            this.CostoUnitarioTextBox.Name = "CostoUnitarioTextBox";
            this.CostoUnitarioTextBox.Size = new System.Drawing.Size(126, 21);
            this.CostoUnitarioTextBox.TabIndex = 27;
            this.CostoUnitarioTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CostoUnitarioTextBox_KeyUp);
            // 
            // CostoUnitario
            // 
            this.CostoUnitario.AutoSize = true;
            this.CostoUnitario.Location = new System.Drawing.Point(8, 82);
            this.CostoUnitario.Name = "CostoUnitario";
            this.CostoUnitario.Size = new System.Drawing.Size(87, 15);
            this.CostoUnitario.TabIndex = 26;
            this.CostoUnitario.Text = "Costo Unitario:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RegistrarOrdenButton);
            this.groupBox3.Controls.Add(this.TotalTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.IVATextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.SubTotalTextBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.CantidadRefaccionesTextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(721, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 575);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totales:";
            // 
            // RegistrarOrdenButton
            // 
            this.RegistrarOrdenButton.Location = new System.Drawing.Point(120, 164);
            this.RegistrarOrdenButton.Name = "RegistrarOrdenButton";
            this.RegistrarOrdenButton.Size = new System.Drawing.Size(121, 23);
            this.RegistrarOrdenButton.TabIndex = 36;
            this.RegistrarOrdenButton.Text = "Registrar orden";
            this.RegistrarOrdenButton.UseVisualStyleBackColor = true;
            this.RegistrarOrdenButton.Click += new System.EventHandler(this.RegistrarOrdenButton_Click);
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.BackColor = System.Drawing.Color.White;
            this.TotalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.TotalTextBox.Location = new System.Drawing.Point(130, 113);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(111, 24);
            this.TotalTextBox.TabIndex = 27;
            this.TotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(17, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total:";
            // 
            // IVATextBox
            // 
            this.IVATextBox.BackColor = System.Drawing.Color.White;
            this.IVATextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IVATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVATextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.IVATextBox.Location = new System.Drawing.Point(130, 83);
            this.IVATextBox.Name = "IVATextBox";
            this.IVATextBox.ReadOnly = true;
            this.IVATextBox.Size = new System.Drawing.Size(111, 24);
            this.IVATextBox.TabIndex = 25;
            this.IVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(17, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "IVA:";
            // 
            // SubTotalTextBox
            // 
            this.SubTotalTextBox.BackColor = System.Drawing.Color.White;
            this.SubTotalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTotalTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.SubTotalTextBox.Location = new System.Drawing.Point(130, 56);
            this.SubTotalTextBox.Name = "SubTotalTextBox";
            this.SubTotalTextBox.ReadOnly = true;
            this.SubTotalTextBox.Size = new System.Drawing.Size(111, 24);
            this.SubTotalTextBox.TabIndex = 23;
            this.SubTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(17, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Subtotal:";
            // 
            // CantidadRefaccionesTextBox
            // 
            this.CantidadRefaccionesTextBox.BackColor = System.Drawing.Color.White;
            this.CantidadRefaccionesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CantidadRefaccionesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantidadRefaccionesTextBox.ForeColor = System.Drawing.Color.MediumBlue;
            this.CantidadRefaccionesTextBox.Location = new System.Drawing.Point(130, 27);
            this.CantidadRefaccionesTextBox.Name = "CantidadRefaccionesTextBox";
            this.CantidadRefaccionesTextBox.ReadOnly = true;
            this.CantidadRefaccionesTextBox.Size = new System.Drawing.Size(111, 24);
            this.CantidadRefaccionesTextBox.TabIndex = 21;
            this.CantidadRefaccionesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Refacciones:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RefaccionesGridView);
            this.groupBox2.Location = new System.Drawing.Point(17, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 358);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Refacciones";
            // 
            // RefaccionesGridView
            // 
            this.RefaccionesGridView.AllowUserToAddRows = false;
            this.RefaccionesGridView.AllowUserToDeleteRows = false;
            this.RefaccionesGridView.AutoGenerateColumns = false;
            this.RefaccionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cancelar,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.refaccionDescripcionDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.comprasBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(19, 30);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.ReadOnly = true;
            this.RefaccionesGridView.Size = new System.Drawing.Size(640, 302);
            this.RefaccionesGridView.TabIndex = 0;
            this.RefaccionesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellContentClick);
            // 
            // Cancelar
            // 
            this.Cancelar.HeaderText = "";
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.ReadOnly = true;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseColumnTextForLinkValue = true;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            this.refaccionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            this.costoUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refaccionDescripcionDataGridViewTextBoxColumn
            // 
            this.refaccionDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_Descripcion";
            this.refaccionDescripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.refaccionDescripcionDataGridViewTextBoxColumn.Name = "refaccionDescripcionDataGridViewTextBoxColumn";
            this.refaccionDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comprasBindingSource
            // 
            this.comprasBindingSource.DataSource = typeof(SICASv20.Entities.Compras);
            // 
            // AltaOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaOrdenCompra";
            this.Text = "AltaOrdenCompra";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodigoProveedorTextBox;
        private System.Windows.Forms.TextBox NombreProveedorTextBox;
        private System.Windows.Forms.NumericUpDown CantidadNumericUpDown;
        private System.Windows.Forms.Button BuscarProveedorButton;
        private System.Windows.Forms.Button AgregarAOrdenButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TotalRefaccionTextBox;
        private System.Windows.Forms.TextBox CodigoRefaccionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreRefaccionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BuscarRefaccionButton;
        private System.Windows.Forms.TextBox CostoUnitarioTextBox;
        private System.Windows.Forms.Label CostoUnitario;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button RegistrarOrdenButton;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IVATextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SubTotalTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CantidadRefaccionesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.BindingSource comprasBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox FacturaTextBox;
        private System.Windows.Forms.Label label9;
    }
}