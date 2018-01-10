namespace SICASv20.forms
{
    partial class VentaComisionada
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
			this.txtCtaBanco = new System.Windows.Forms.TextBox();
			this.lblCtaBanco = new System.Windows.Forms.Label();
			this.ZonasComboBox = new System.Windows.Forms.ComboBox();
			this.zonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.Zona = new System.Windows.Forms.Label();
			this.CantidadTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.AceptarButton = new System.Windows.Forms.Button();
			this.TiposServiciosComboBox = new System.Windows.Forms.ComboBox();
			this.tiposServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.PrecioTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MonedasComboBox = new System.Windows.Forms.ComboBox();
			this.monedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ConductorTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.zonasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtCtaBanco);
			this.groupBox1.Controls.Add(this.lblCtaBanco);
			this.groupBox1.Controls.Add(this.ZonasComboBox);
			this.groupBox1.Controls.Add(this.Zona);
			this.groupBox1.Controls.Add(this.CantidadTextBox);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.AceptarButton);
			this.groupBox1.Controls.Add(this.TiposServiciosComboBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.PrecioTextBox);
			this.groupBox1.Controls.Add(this.label6);
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
			this.groupBox1.Text = "Venta de Servicios Comisionados";
			// 
			// txtCtaBanco
			// 
			this.txtCtaBanco.BackColor = System.Drawing.Color.White;
			this.txtCtaBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCtaBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCtaBanco.Location = new System.Drawing.Point(515, 195);
			this.txtCtaBanco.MaxLength = 4;
			this.txtCtaBanco.Name = "txtCtaBanco";
			this.txtCtaBanco.Size = new System.Drawing.Size(46, 23);
			this.txtCtaBanco.TabIndex = 15;
			this.txtCtaBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCtaBanco.Visible = false;
			// 
			// lblCtaBanco
			// 
			this.lblCtaBanco.AutoSize = true;
			this.lblCtaBanco.Location = new System.Drawing.Point(300, 196);
			this.lblCtaBanco.Name = "lblCtaBanco";
			this.lblCtaBanco.Size = new System.Drawing.Size(209, 18);
			this.lblCtaBanco.TabIndex = 14;
			this.lblCtaBanco.Text = "Ultimos 4 Digitos de la Tarjeta:";
			this.lblCtaBanco.Visible = false;
			// 
			// ZonasComboBox
			// 
			this.ZonasComboBox.DataSource = this.zonasBindingSource;
			this.ZonasComboBox.DisplayMember = "Nombre";
			this.ZonasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ZonasComboBox.FormattingEnabled = true;
			this.ZonasComboBox.Location = new System.Drawing.Point(121, 112);
			this.ZonasComboBox.Name = "ZonasComboBox";
			this.ZonasComboBox.Size = new System.Drawing.Size(241, 26);
			this.ZonasComboBox.TabIndex = 7;
			this.ZonasComboBox.ValueMember = "Zona_ID";
			this.ZonasComboBox.SelectionChangeCommitted += new System.EventHandler(this.ZonasComboBox_SelectionChangeCommitted);
			// 
			// zonasBindingSource
			// 
			this.zonasBindingSource.DataSource = typeof(SICASv20.Entities.Zonas);
			// 
			// Zona
			// 
			this.Zona.AutoSize = true;
			this.Zona.Location = new System.Drawing.Point(14, 114);
			this.Zona.Name = "Zona";
			this.Zona.Size = new System.Drawing.Size(46, 18);
			this.Zona.TabIndex = 6;
			this.Zona.Text = "Zona:";
			// 
			// CantidadTextBox
			// 
			this.CantidadTextBox.BackColor = System.Drawing.Color.White;
			this.CantidadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CantidadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CantidadTextBox.Location = new System.Drawing.Point(121, 141);
			this.CantidadTextBox.Name = "CantidadTextBox";
			this.CantidadTextBox.Size = new System.Drawing.Size(87, 23);
			this.CantidadTextBox.TabIndex = 9;
			this.CantidadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 143);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 18);
			this.label8.TabIndex = 8;
			this.label8.Text = "Cantidad:";
			// 
			// AceptarButton
			// 
			this.AceptarButton.Location = new System.Drawing.Point(320, 234);
			this.AceptarButton.Name = "AceptarButton";
			this.AceptarButton.Size = new System.Drawing.Size(133, 44);
			this.AceptarButton.TabIndex = 16;
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
			this.TiposServiciosComboBox.Location = new System.Drawing.Point(121, 83);
			this.TiposServiciosComboBox.Name = "TiposServiciosComboBox";
			this.TiposServiciosComboBox.Size = new System.Drawing.Size(241, 26);
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
			this.label7.Location = new System.Drawing.Point(14, 85);
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
			this.PrecioTextBox.Location = new System.Drawing.Point(121, 167);
			this.PrecioTextBox.Name = "PrecioTextBox";
			this.PrecioTextBox.ReadOnly = true;
			this.PrecioTextBox.Size = new System.Drawing.Size(87, 23);
			this.PrecioTextBox.TabIndex = 11;
			this.PrecioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 169);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Precio:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 195);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 18);
			this.label3.TabIndex = 12;
			this.label3.Text = "Forma de pago:";
			// 
			// MonedasComboBox
			// 
			this.MonedasComboBox.DataSource = this.monedasBindingSource;
			this.MonedasComboBox.DisplayMember = "Nombre";
			this.MonedasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonedasComboBox.FormattingEnabled = true;
			this.MonedasComboBox.Location = new System.Drawing.Point(121, 193);
			this.MonedasComboBox.Name = "MonedasComboBox";
			this.MonedasComboBox.Size = new System.Drawing.Size(162, 26);
			this.MonedasComboBox.TabIndex = 13;
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
			this.ConductorTextBox.Location = new System.Drawing.Point(121, 56);
			this.ConductorTextBox.Name = "ConductorTextBox";
			this.ConductorTextBox.ReadOnly = true;
			this.ConductorTextBox.Size = new System.Drawing.Size(241, 24);
			this.ConductorTextBox.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Conductor:";
			// 
			// NumeroEconomicoTextBox
			// 
			this.NumeroEconomicoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(121, 29);
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
			// VentaComisionada
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 565);
			this.Controls.Add(this.groupBox1);
			this.Name = "VentaComisionada";
			this.Text = "VentaServicios";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.zonasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TiposServiciosComboBox;
        private System.Windows.Forms.BindingSource tiposServiciosBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.ComboBox ZonasComboBox;
        private System.Windows.Forms.Label Zona;
        private System.Windows.Forms.TextBox CantidadTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource zonasBindingSource;
	   private System.Windows.Forms.TextBox txtCtaBanco;
	   private System.Windows.Forms.Label lblCtaBanco;
    }
}