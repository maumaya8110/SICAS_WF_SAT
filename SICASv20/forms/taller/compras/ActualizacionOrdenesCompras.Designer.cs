namespace SICASv20.forms
{
    partial class ActualizacionOrdenesCompras
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
            System.Windows.Forms.Label estatusOrdenCompra_IDLabel;
            System.Windows.Forms.Label facturaLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label iVALabel;
            System.Windows.Forms.Label ordenCompra_IDLabel;
            System.Windows.Forms.Label proveedor_IDLabel;
            System.Windows.Forms.Label subtotalLabel;
            System.Windows.Forms.Label totalLabel;
            System.Windows.Forms.Label usuario_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ordenesComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estatusOrdenCompra_IDComboBox = new System.Windows.Forms.ComboBox();
            this.facturaTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.iVATextBox = new System.Windows.Forms.TextBox();
            this.ordenCompra_IDTextBox = new System.Windows.Forms.TextBox();
            this.proveedor_IDTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.estatusOrdenesComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            estatusOrdenCompra_IDLabel = new System.Windows.Forms.Label();
            facturaLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            iVALabel = new System.Windows.Forms.Label();
            ordenCompra_IDLabel = new System.Windows.Forms.Label();
            proveedor_IDLabel = new System.Windows.Forms.Label();
            subtotalLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            usuario_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesComprasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusOrdenesComprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(estatusOrdenCompra_IDLabel);
            this.groupBox1.Controls.Add(this.estatusOrdenCompra_IDComboBox);
            this.groupBox1.Controls.Add(facturaLabel);
            this.groupBox1.Controls.Add(this.facturaTextBox);
            this.groupBox1.Controls.Add(fechaLabel);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Controls.Add(iVALabel);
            this.groupBox1.Controls.Add(this.iVATextBox);
            this.groupBox1.Controls.Add(ordenCompra_IDLabel);
            this.groupBox1.Controls.Add(this.ordenCompra_IDTextBox);
            this.groupBox1.Controls.Add(proveedor_IDLabel);
            this.groupBox1.Controls.Add(this.proveedor_IDTextBox);
            this.groupBox1.Controls.Add(subtotalLabel);
            this.groupBox1.Controls.Add(this.subtotalTextBox);
            this.groupBox1.Controls.Add(totalLabel);
            this.groupBox1.Controls.Add(this.totalTextBox);
            this.groupBox1.Controls.Add(usuario_IDLabel);
            this.groupBox1.Controls.Add(this.usuario_IDTextBox);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de orden de compra";
            // 
            // ordenesComprasBindingSource
            // 
            this.ordenesComprasBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesCompras);
            // 
            // estatusOrdenCompra_IDLabel
            // 
            estatusOrdenCompra_IDLabel.AutoSize = true;
            estatusOrdenCompra_IDLabel.Location = new System.Drawing.Point(32, 34);
            estatusOrdenCompra_IDLabel.Name = "estatusOrdenCompra_IDLabel";
            estatusOrdenCompra_IDLabel.Size = new System.Drawing.Size(149, 15);
            estatusOrdenCompra_IDLabel.TabIndex = 0;
            estatusOrdenCompra_IDLabel.Text = "Estatus Orden Compra ID:";
            // 
            // estatusOrdenCompra_IDComboBox
            // 
            this.estatusOrdenCompra_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ordenesComprasBindingSource, "EstatusOrdenCompra_ID", true));
            this.estatusOrdenCompra_IDComboBox.DataSource = this.estatusOrdenesComprasBindingSource;
            this.estatusOrdenCompra_IDComboBox.DisplayMember = "Nombre";
            this.estatusOrdenCompra_IDComboBox.Enabled = false;
            this.estatusOrdenCompra_IDComboBox.FormattingEnabled = true;
            this.estatusOrdenCompra_IDComboBox.Location = new System.Drawing.Point(187, 31);
            this.estatusOrdenCompra_IDComboBox.Name = "estatusOrdenCompra_IDComboBox";
            this.estatusOrdenCompra_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.estatusOrdenCompra_IDComboBox.TabIndex = 1;
            this.estatusOrdenCompra_IDComboBox.ValueMember = "EstatusOrdenCompra_ID";
            // 
            // facturaLabel
            // 
            facturaLabel.AutoSize = true;
            facturaLabel.Location = new System.Drawing.Point(32, 63);
            facturaLabel.Name = "facturaLabel";
            facturaLabel.Size = new System.Drawing.Size(51, 15);
            facturaLabel.TabIndex = 2;
            facturaLabel.Text = "Factura:";
            // 
            // facturaTextBox
            // 
            this.facturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "Factura", true));
            this.facturaTextBox.Location = new System.Drawing.Point(187, 60);
            this.facturaTextBox.Name = "facturaTextBox";
            this.facturaTextBox.Size = new System.Drawing.Size(117, 21);
            this.facturaTextBox.TabIndex = 3;
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(32, 91);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(44, 15);
            fechaLabel.TabIndex = 4;
            fechaLabel.Text = "Fecha:";
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ordenesComprasBindingSource, "Fecha", true));
            this.fechaDateTimePicker.Enabled = false;
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(187, 87);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(108, 21);
            this.fechaDateTimePicker.TabIndex = 5;
            // 
            // iVALabel
            // 
            iVALabel.AutoSize = true;
            iVALabel.Location = new System.Drawing.Point(32, 117);
            iVALabel.Name = "iVALabel";
            iVALabel.Size = new System.Drawing.Size(27, 15);
            iVALabel.TabIndex = 6;
            iVALabel.Text = "IVA:";
            // 
            // iVATextBox
            // 
            this.iVATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "IVA", true));
            this.iVATextBox.Location = new System.Drawing.Point(187, 114);
            this.iVATextBox.Name = "iVATextBox";
            this.iVATextBox.ReadOnly = true;
            this.iVATextBox.Size = new System.Drawing.Size(117, 21);
            this.iVATextBox.TabIndex = 7;
            // 
            // ordenCompra_IDLabel
            // 
            ordenCompra_IDLabel.AutoSize = true;
            ordenCompra_IDLabel.Location = new System.Drawing.Point(32, 144);
            ordenCompra_IDLabel.Name = "ordenCompra_IDLabel";
            ordenCompra_IDLabel.Size = new System.Drawing.Size(106, 15);
            ordenCompra_IDLabel.TabIndex = 8;
            ordenCompra_IDLabel.Text = "Orden Compra ID:";
            // 
            // ordenCompra_IDTextBox
            // 
            this.ordenCompra_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "OrdenCompra_ID", true));
            this.ordenCompra_IDTextBox.Location = new System.Drawing.Point(187, 141);
            this.ordenCompra_IDTextBox.Name = "ordenCompra_IDTextBox";
            this.ordenCompra_IDTextBox.ReadOnly = true;
            this.ordenCompra_IDTextBox.Size = new System.Drawing.Size(97, 21);
            this.ordenCompra_IDTextBox.TabIndex = 9;
            // 
            // proveedor_IDLabel
            // 
            proveedor_IDLabel.AutoSize = true;
            proveedor_IDLabel.Location = new System.Drawing.Point(32, 171);
            proveedor_IDLabel.Name = "proveedor_IDLabel";
            proveedor_IDLabel.Size = new System.Drawing.Size(81, 15);
            proveedor_IDLabel.TabIndex = 10;
            proveedor_IDLabel.Text = "Proveedor ID:";
            // 
            // proveedor_IDTextBox
            // 
            this.proveedor_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "Proveedor_ID", true));
            this.proveedor_IDTextBox.Location = new System.Drawing.Point(187, 168);
            this.proveedor_IDTextBox.Name = "proveedor_IDTextBox";
            this.proveedor_IDTextBox.ReadOnly = true;
            this.proveedor_IDTextBox.Size = new System.Drawing.Size(97, 21);
            this.proveedor_IDTextBox.TabIndex = 11;
            // 
            // subtotalLabel
            // 
            subtotalLabel.AutoSize = true;
            subtotalLabel.Location = new System.Drawing.Point(32, 198);
            subtotalLabel.Name = "subtotalLabel";
            subtotalLabel.Size = new System.Drawing.Size(55, 15);
            subtotalLabel.TabIndex = 12;
            subtotalLabel.Text = "Subtotal:";
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "Subtotal", true));
            this.subtotalTextBox.Location = new System.Drawing.Point(187, 195);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.ReadOnly = true;
            this.subtotalTextBox.Size = new System.Drawing.Size(117, 21);
            this.subtotalTextBox.TabIndex = 13;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new System.Drawing.Point(32, 225);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(37, 15);
            totalLabel.TabIndex = 14;
            totalLabel.Text = "Total:";
            // 
            // totalTextBox
            // 
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "Total", true));
            this.totalTextBox.Location = new System.Drawing.Point(187, 222);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(117, 21);
            this.totalTextBox.TabIndex = 15;
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(32, 252);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 16;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ordenesComprasBindingSource, "Usuario_ID", true));
            this.usuario_IDTextBox.Location = new System.Drawing.Point(187, 249);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.ReadOnly = true;
            this.usuario_IDTextBox.Size = new System.Drawing.Size(117, 21);
            this.usuario_IDTextBox.TabIndex = 17;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(303, 289);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(84, 33);
            this.GuardarButton.TabIndex = 18;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // estatusOrdenesComprasBindingSource
            // 
            this.estatusOrdenesComprasBindingSource.DataSource = typeof(SICASv20.Entities.EstatusOrdenesCompras);
            // 
            // ActualizacionOrdenesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActualizacionOrdenesCompras";
            this.Text = "ActualizacionOrdenesCompras";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesComprasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusOrdenesComprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ComboBox estatusOrdenCompra_IDComboBox;
        private System.Windows.Forms.BindingSource ordenesComprasBindingSource;
        private System.Windows.Forms.TextBox facturaTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox iVATextBox;
        private System.Windows.Forms.TextBox ordenCompra_IDTextBox;
        private System.Windows.Forms.TextBox proveedor_IDTextBox;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.BindingSource estatusOrdenesComprasBindingSource;
    }
}