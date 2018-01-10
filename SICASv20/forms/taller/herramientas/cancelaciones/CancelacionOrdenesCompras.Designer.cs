namespace SICASv20.forms
{
    partial class CancelacionOrdenesCompras
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
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label facturaLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label iVALabel;
            System.Windows.Forms.Label ordenCompra_IDLabel;
            System.Windows.Forms.Label proveedorLabel;
            System.Windows.Forms.Label subtotalLabel;
            System.Windows.Forms.Label totalLabel;
            System.Windows.Forms.Label usuario_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OrdenCompraTextBox = new System.Windows.Forms.TextBox();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.estadoTextBox = new System.Windows.Forms.TextBox();
            this.vista_OrdenesComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.iVATextBox = new System.Windows.Forms.TextBox();
            this.ordenCompra_IDTextBox = new System.Windows.Forms.TextBox();
            this.proveedorTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            estadoLabel = new System.Windows.Forms.Label();
            facturaLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            iVALabel = new System.Windows.Forms.Label();
            ordenCompra_IDLabel = new System.Windows.Forms.Label();
            proveedorLabel = new System.Windows.Forms.Label();
            subtotalLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            usuario_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesComprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new System.Drawing.Point(32, 30);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(48, 15);
            estadoLabel.TabIndex = 0;
            estadoLabel.Text = "Estado:";
            // 
            // facturaLabel
            // 
            facturaLabel.AutoSize = true;
            facturaLabel.Location = new System.Drawing.Point(32, 57);
            facturaLabel.Name = "facturaLabel";
            facturaLabel.Size = new System.Drawing.Size(51, 15);
            facturaLabel.TabIndex = 2;
            facturaLabel.Text = "Factura:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(32, 85);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(44, 15);
            fechaLabel.TabIndex = 4;
            fechaLabel.Text = "Fecha:";
            // 
            // iVALabel
            // 
            iVALabel.AutoSize = true;
            iVALabel.Location = new System.Drawing.Point(32, 111);
            iVALabel.Name = "iVALabel";
            iVALabel.Size = new System.Drawing.Size(27, 15);
            iVALabel.TabIndex = 6;
            iVALabel.Text = "IVA:";
            // 
            // ordenCompra_IDLabel
            // 
            ordenCompra_IDLabel.AutoSize = true;
            ordenCompra_IDLabel.Location = new System.Drawing.Point(32, 138);
            ordenCompra_IDLabel.Name = "ordenCompra_IDLabel";
            ordenCompra_IDLabel.Size = new System.Drawing.Size(106, 15);
            ordenCompra_IDLabel.TabIndex = 8;
            ordenCompra_IDLabel.Text = "Orden Compra ID:";
            // 
            // proveedorLabel
            // 
            proveedorLabel.AutoSize = true;
            proveedorLabel.Location = new System.Drawing.Point(32, 165);
            proveedorLabel.Name = "proveedorLabel";
            proveedorLabel.Size = new System.Drawing.Size(66, 15);
            proveedorLabel.TabIndex = 10;
            proveedorLabel.Text = "Proveedor:";
            // 
            // subtotalLabel
            // 
            subtotalLabel.AutoSize = true;
            subtotalLabel.Location = new System.Drawing.Point(32, 192);
            subtotalLabel.Name = "subtotalLabel";
            subtotalLabel.Size = new System.Drawing.Size(55, 15);
            subtotalLabel.TabIndex = 12;
            subtotalLabel.Text = "Subtotal:";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new System.Drawing.Point(32, 219);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(37, 15);
            totalLabel.TabIndex = 14;
            totalLabel.Text = "Total:";
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(32, 246);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 16;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelación de Ordenes de Compras";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OrdenCompraTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComentariosTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AceptarButton, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 130);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden de compra a cancelar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo de la cancelación";
            // 
            // OrdenCompraTextBox
            // 
            this.OrdenCompraTextBox.Location = new System.Drawing.Point(175, 3);
            this.OrdenCompraTextBox.Name = "OrdenCompraTextBox";
            this.OrdenCompraTextBox.Size = new System.Drawing.Size(100, 21);
            this.OrdenCompraTextBox.TabIndex = 2;
            this.OrdenCompraTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrdenCompraTextBox_KeyUp);
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.Location = new System.Drawing.Point(175, 30);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(255, 63);
            this.ComentariosTextBox.TabIndex = 3;
            this.ComentariosTextBox.TextChanged += new System.EventHandler(this.ComentariosTextBox_TextChanged);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(175, 99);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 4;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(estadoLabel);
            this.groupBox2.Controls.Add(this.estadoTextBox);
            this.groupBox2.Controls.Add(facturaLabel);
            this.groupBox2.Controls.Add(this.facturaTextBox);
            this.groupBox2.Controls.Add(fechaLabel);
            this.groupBox2.Controls.Add(this.fechaDateTimePicker);
            this.groupBox2.Controls.Add(iVALabel);
            this.groupBox2.Controls.Add(this.iVATextBox);
            this.groupBox2.Controls.Add(ordenCompra_IDLabel);
            this.groupBox2.Controls.Add(this.ordenCompra_IDTextBox);
            this.groupBox2.Controls.Add(proveedorLabel);
            this.groupBox2.Controls.Add(this.proveedorTextBox);
            this.groupBox2.Controls.Add(subtotalLabel);
            this.groupBox2.Controls.Add(this.subtotalTextBox);
            this.groupBox2.Controls.Add(totalLabel);
            this.groupBox2.Controls.Add(this.totalTextBox);
            this.groupBox2.Controls.Add(usuario_IDLabel);
            this.groupBox2.Controls.Add(this.usuario_IDTextBox);
            this.groupBox2.Location = new System.Drawing.Point(499, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 285);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la orden";
            // 
            // estadoTextBox
            // 
            this.estadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Estado", true));
            this.estadoTextBox.Location = new System.Drawing.Point(144, 27);
            this.estadoTextBox.Name = "estadoTextBox";
            this.estadoTextBox.Size = new System.Drawing.Size(200, 21);
            this.estadoTextBox.TabIndex = 1;
            // 
            // vista_OrdenesComprasBindingSource
            // 
            this.vista_OrdenesComprasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_OrdenesCompras);
            // 
            // facturaTextBox
            // 
            this.facturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Factura", true));
            this.facturaTextBox.Location = new System.Drawing.Point(144, 54);
            this.facturaTextBox.Name = "facturaTextBox";
            this.facturaTextBox.Size = new System.Drawing.Size(200, 21);
            this.facturaTextBox.TabIndex = 3;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vista_OrdenesComprasBindingSource, "Fecha", true));
            this.fechaDateTimePicker.Location = new System.Drawing.Point(144, 81);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.fechaDateTimePicker.TabIndex = 5;
            // 
            // iVATextBox
            // 
            this.iVATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "IVA", true));
            this.iVATextBox.Location = new System.Drawing.Point(144, 108);
            this.iVATextBox.Name = "iVATextBox";
            this.iVATextBox.Size = new System.Drawing.Size(200, 21);
            this.iVATextBox.TabIndex = 7;
            // 
            // ordenCompra_IDTextBox
            // 
            this.ordenCompra_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "OrdenCompra_ID", true));
            this.ordenCompra_IDTextBox.Location = new System.Drawing.Point(144, 135);
            this.ordenCompra_IDTextBox.Name = "ordenCompra_IDTextBox";
            this.ordenCompra_IDTextBox.Size = new System.Drawing.Size(200, 21);
            this.ordenCompra_IDTextBox.TabIndex = 9;
            // 
            // proveedorTextBox
            // 
            this.proveedorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Proveedor", true));
            this.proveedorTextBox.Location = new System.Drawing.Point(144, 162);
            this.proveedorTextBox.Name = "proveedorTextBox";
            this.proveedorTextBox.Size = new System.Drawing.Size(200, 21);
            this.proveedorTextBox.TabIndex = 11;
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Subtotal", true));
            this.subtotalTextBox.Location = new System.Drawing.Point(144, 189);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.Size = new System.Drawing.Size(200, 21);
            this.subtotalTextBox.TabIndex = 13;
            // 
            // totalTextBox
            // 
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Total", true));
            this.totalTextBox.Location = new System.Drawing.Point(144, 216);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(200, 21);
            this.totalTextBox.TabIndex = 15;
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_OrdenesComprasBindingSource, "Usuario_ID", true));
            this.usuario_IDTextBox.Location = new System.Drawing.Point(144, 243);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.Size = new System.Drawing.Size(200, 21);
            this.usuario_IDTextBox.TabIndex = 17;
            // 
            // CancelacionOrdenesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelacionOrdenesCompras";
            this.Text = "CancelacionOrdenesCompras";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_OrdenesComprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox estadoTextBox;
        private System.Windows.Forms.BindingSource vista_OrdenesComprasBindingSource;
        private System.Windows.Forms.TextBox facturaTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox iVATextBox;
        private System.Windows.Forms.TextBox ordenCompra_IDTextBox;
        private System.Windows.Forms.TextBox proveedorTextBox;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OrdenCompraTextBox;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.Button AceptarButton;
    }
}