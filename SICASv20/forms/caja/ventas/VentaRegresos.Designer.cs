namespace SICASv20.forms
{
    partial class VentaRegresos
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
            this.txtPayBack = new System.Windows.Forms.MaskedTextBox();
            this.lblPayBack = new System.Windows.Forms.Label();
            this.ReservacionIDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.TiposServiciosComboBox = new System.Windows.Forms.ComboBox();
            this.tiposServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreZonaTextBox = new System.Windows.Forms.TextBox();
            this.ZonasListBox = new System.Windows.Forms.ListBox();
            this.buscarZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Zona_IDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MonedasComboBox = new System.Windows.Forms.ComboBox();
            this.monedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbPagoTarjeta = new System.Windows.Forms.GroupBox();
            this.lblCtaBanco = new System.Windows.Forms.Label();
            this.txtCtaBanco = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarZonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
            this.gbPagoTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbPagoTarjeta);
            this.groupBox1.Controls.Add(this.txtPayBack);
            this.groupBox1.Controls.Add(this.lblPayBack);
            this.groupBox1.Controls.Add(this.ReservacionIDTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(this.TiposServiciosComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.PrecioTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NombreZonaTextBox);
            this.groupBox1.Controls.Add(this.ZonasListBox);
            this.groupBox1.Controls.Add(this.Zona_IDTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MonedasComboBox);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 552);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venta de Regresos";
            // 
            // txtPayBack
            // 
            this.txtPayBack.Location = new System.Drawing.Point(110, 368);
            this.txtPayBack.Mask = "0-000000-000000";
            this.txtPayBack.Name = "txtPayBack";
            this.txtPayBack.Size = new System.Drawing.Size(132, 24);
            this.txtPayBack.TabIndex = 20;
            this.txtPayBack.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPayBack.TextChanged += new System.EventHandler(this.txtPayBack_TextChanged);
            // 
            // lblPayBack
            // 
            this.lblPayBack.AutoSize = true;
            this.lblPayBack.Location = new System.Drawing.Point(14, 371);
            this.lblPayBack.Name = "lblPayBack";
            this.lblPayBack.Size = new System.Drawing.Size(102, 18);
            this.lblPayBack.TabIndex = 19;
            this.lblPayBack.Text = "Ref. PayBack:";
            // 
            // ReservacionIDTextBox
            // 
            this.ReservacionIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReservacionIDTextBox.Location = new System.Drawing.Point(110, 341);
            this.ReservacionIDTextBox.Name = "ReservacionIDTextBox";
            this.ReservacionIDTextBox.Size = new System.Drawing.Size(132, 24);
            this.ReservacionIDTextBox.TabIndex = 18;
            this.ReservacionIDTextBox.TextChanged += new System.EventHandler(this.ReservacionIDTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Reservación:";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(310, 403);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(133, 44);
            this.AceptarButton.TabIndex = 21;
            this.AceptarButton.Text = "Efectuar Venta";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // TiposServiciosComboBox
            // 
            this.TiposServiciosComboBox.DataSource = this.tiposServiciosBindingSource;
            this.TiposServiciosComboBox.DisplayMember = "Nombre";
            this.TiposServiciosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiposServiciosComboBox.FormattingEnabled = true;
            this.TiposServiciosComboBox.Location = new System.Drawing.Point(110, 76);
            this.TiposServiciosComboBox.Name = "TiposServiciosComboBox";
            this.TiposServiciosComboBox.Size = new System.Drawing.Size(204, 26);
            this.TiposServiciosComboBox.TabIndex = 5;
            this.TiposServiciosComboBox.ValueMember = "TipoServicio_ID";
            this.TiposServiciosComboBox.SelectedValueChanged += new System.EventHandler(this.TiposServiciosComboBox_SelectedValueChanged);
            // 
            // tiposServiciosBindingSource
            // 
            this.tiposServiciosBindingSource.DataSource = typeof(SICASv20.Entities.TiposServicios);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tipo de servicio:";
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.BackColor = System.Drawing.Color.White;
            this.PrecioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrecioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioTextBox.Location = new System.Drawing.Point(110, 285);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.ReadOnly = true;
            this.PrecioTextBox.Size = new System.Drawing.Size(87, 23);
            this.PrecioTextBox.TabIndex = 12;
            this.PrecioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zona:";
            // 
            // NombreZonaTextBox
            // 
            this.NombreZonaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreZonaTextBox.Location = new System.Drawing.Point(110, 124);
            this.NombreZonaTextBox.Name = "NombreZonaTextBox";
            this.NombreZonaTextBox.Size = new System.Drawing.Size(343, 24);
            this.NombreZonaTextBox.TabIndex = 9;
            this.NombreZonaTextBox.TextChanged += new System.EventHandler(this.NombreZonaTextBox_TextChanged);
            // 
            // ZonasListBox
            // 
            this.ZonasListBox.DataSource = this.buscarZonasBindingSource;
            this.ZonasListBox.DisplayMember = "Nombre";
            this.ZonasListBox.FormattingEnabled = true;
            this.ZonasListBox.ItemHeight = 18;
            this.ZonasListBox.Location = new System.Drawing.Point(17, 149);
            this.ZonasListBox.Name = "ZonasListBox";
            this.ZonasListBox.Size = new System.Drawing.Size(436, 112);
            this.ZonasListBox.TabIndex = 10;
            this.ZonasListBox.ValueMember = "Zona_ID";
            this.ZonasListBox.Click += new System.EventHandler(this.ZonasListBox_Click);
            // 
            // buscarZonasBindingSource
            // 
            this.buscarZonasBindingSource.DataSource = typeof(SICASv20.Entities.BuscarZonas);
            // 
            // Zona_IDTextBox
            // 
            this.Zona_IDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Zona_IDTextBox.Location = new System.Drawing.Point(110, 101);
            this.Zona_IDTextBox.Name = "Zona_IDTextBox";
            this.Zona_IDTextBox.Size = new System.Drawing.Size(204, 24);
            this.Zona_IDTextBox.TabIndex = 7;
            this.Zona_IDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Zona_IDTextBox_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Forma de pago:";
            // 
            // MonedasComboBox
            // 
            this.MonedasComboBox.DataSource = this.monedasBindingSource;
            this.MonedasComboBox.DisplayMember = "Nombre";
            this.MonedasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonedasComboBox.FormattingEnabled = true;
            this.MonedasComboBox.Location = new System.Drawing.Point(110, 309);
            this.MonedasComboBox.Name = "MonedasComboBox";
            this.MonedasComboBox.Size = new System.Drawing.Size(162, 26);
            this.MonedasComboBox.TabIndex = 14;
            this.MonedasComboBox.ValueMember = "Moneda_ID";
            this.MonedasComboBox.SelectedValueChanged += new System.EventHandler(this.MonedasComboBox_SelectedValueChanged);
            // 
            // monedasBindingSource
            // 
            this.monedasBindingSource.DataSource = typeof(SICASv20.Entities.Monedas);
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.BackColor = System.Drawing.Color.White;
            this.ConductorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConductorTextBox.Location = new System.Drawing.Point(110, 52);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.ReadOnly = true;
            this.ConductorTextBox.Size = new System.Drawing.Size(241, 24);
            this.ConductorTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conductor:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(110, 29);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(87, 24);
            this.NumeroEconomicoTextBox.TabIndex = 1;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidad:";
            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(138, 56);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(151, 24);
            this.txtVoucher.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "# Voucher:";
            // 
            // gbPagoTarjeta
            // 
            this.gbPagoTarjeta.Controls.Add(this.txtVoucher);
            this.gbPagoTarjeta.Controls.Add(this.label9);
            this.gbPagoTarjeta.Controls.Add(this.lblCtaBanco);
            this.gbPagoTarjeta.Controls.Add(this.txtCtaBanco);
            this.gbPagoTarjeta.Location = new System.Drawing.Point(278, 294);
            this.gbPagoTarjeta.Name = "gbPagoTarjeta";
            this.gbPagoTarjeta.Size = new System.Drawing.Size(306, 103);
            this.gbPagoTarjeta.TabIndex = 25;
            this.gbPagoTarjeta.TabStop = false;
            this.gbPagoTarjeta.Visible = false;
            // 
            // lblCtaBanco
            // 
            this.lblCtaBanco.AutoSize = true;
            this.lblCtaBanco.Location = new System.Drawing.Point(28, 26);
            this.lblCtaBanco.Name = "lblCtaBanco";
            this.lblCtaBanco.Size = new System.Drawing.Size(209, 18);
            this.lblCtaBanco.TabIndex = 15;
            this.lblCtaBanco.Text = "Ultimos 4 Digitos de la Tarjeta:";
            // 
            // txtCtaBanco
            // 
            this.txtCtaBanco.BackColor = System.Drawing.Color.White;
            this.txtCtaBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtaBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaBanco.Location = new System.Drawing.Point(243, 25);
            this.txtCtaBanco.MaxLength = 4;
            this.txtCtaBanco.Name = "txtCtaBanco";
            this.txtCtaBanco.Size = new System.Drawing.Size(46, 23);
            this.txtCtaBanco.TabIndex = 16;
            this.txtCtaBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VentaRegresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 565);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentaRegresos";
            this.Text = "VentaServicios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarZonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).EndInit();
            this.gbPagoTarjeta.ResumeLayout(false);
            this.gbPagoTarjeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox MonedasComboBox;
        private System.Windows.Forms.BindingSource monedasBindingSource;
        private System.Windows.Forms.ListBox ZonasListBox;
        private System.Windows.Forms.TextBox Zona_IDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource buscarZonasBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreZonaTextBox;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TiposServiciosComboBox;
        private System.Windows.Forms.BindingSource tiposServiciosBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AceptarButton;
	   private System.Windows.Forms.MaskedTextBox txtPayBack;
	   private System.Windows.Forms.Label lblPayBack;
	   private System.Windows.Forms.TextBox ReservacionIDTextBox;
       private System.Windows.Forms.Label label8;
       private System.Windows.Forms.GroupBox gbPagoTarjeta;
       private System.Windows.Forms.TextBox txtVoucher;
       private System.Windows.Forms.Label label9;
       private System.Windows.Forms.Label lblCtaBanco;
       private System.Windows.Forms.TextBox txtCtaBanco;
    }
}