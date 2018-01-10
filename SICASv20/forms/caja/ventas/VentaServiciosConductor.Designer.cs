namespace SICASv20.forms
{
    partial class VentaServiciosConductor
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
			this.label4 = new System.Windows.Forms.Label();
			this.TiposServiciosConductoresComboBox = new System.Windows.Forms.ComboBox();
			this.tiposServiciosConductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.AceptarButton = new System.Windows.Forms.Button();
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
			((System.ComponentModel.ISupportInitialize)(this.tiposServiciosConductoresBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtCtaBanco);
			this.groupBox1.Controls.Add(this.lblCtaBanco);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.TiposServiciosConductoresComboBox);
			this.groupBox1.Controls.Add(this.AceptarButton);
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
			this.groupBox1.Text = "Boletos Especiales";
			// 
			// txtCtaBanco
			// 
			this.txtCtaBanco.BackColor = System.Drawing.Color.White;
			this.txtCtaBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCtaBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCtaBanco.Location = new System.Drawing.Point(505, 135);
			this.txtCtaBanco.MaxLength = 4;
			this.txtCtaBanco.Name = "txtCtaBanco";
			this.txtCtaBanco.Size = new System.Drawing.Size(46, 23);
			this.txtCtaBanco.TabIndex = 11;
			this.txtCtaBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCtaBanco.Visible = false;
			// 
			// lblCtaBanco
			// 
			this.lblCtaBanco.AutoSize = true;
			this.lblCtaBanco.Location = new System.Drawing.Point(290, 136);
			this.lblCtaBanco.Name = "lblCtaBanco";
			this.lblCtaBanco.Size = new System.Drawing.Size(209, 18);
			this.lblCtaBanco.TabIndex = 10;
			this.lblCtaBanco.Text = "Ultimos 4 Digitos de la Tarjeta:";
			this.lblCtaBanco.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 18);
			this.label4.TabIndex = 4;
			this.label4.Text = "Tipo:";
			// 
			// TiposServiciosConductoresComboBox
			// 
			this.TiposServiciosConductoresComboBox.DataSource = this.tiposServiciosConductoresBindingSource;
			this.TiposServiciosConductoresComboBox.DisplayMember = "Nombre";
			this.TiposServiciosConductoresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TiposServiciosConductoresComboBox.FormattingEnabled = true;
			this.TiposServiciosConductoresComboBox.Location = new System.Drawing.Point(110, 81);
			this.TiposServiciosConductoresComboBox.Name = "TiposServiciosConductoresComboBox";
			this.TiposServiciosConductoresComboBox.Size = new System.Drawing.Size(241, 26);
			this.TiposServiciosConductoresComboBox.TabIndex = 5;
			this.TiposServiciosConductoresComboBox.ValueMember = "ComisionServicio_ID";
			this.TiposServiciosConductoresComboBox.SelectionChangeCommitted += new System.EventHandler(this.TiposServiciosConductoresComboBox_SelectionChangeCommitted);
			// 
			// tiposServiciosConductoresBindingSource
			// 
			this.tiposServiciosConductoresBindingSource.DataSource = typeof(SICASv20.Entities.TiposServiciosConductores);
			// 
			// AceptarButton
			// 
			this.AceptarButton.Location = new System.Drawing.Point(293, 205);
			this.AceptarButton.Name = "AceptarButton";
			this.AceptarButton.Size = new System.Drawing.Size(133, 44);
			this.AceptarButton.TabIndex = 12;
			this.AceptarButton.Text = "Efectuar Venta";
			this.AceptarButton.UseVisualStyleBackColor = true;
			this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
			// 
			// PrecioTextBox
			// 
			this.PrecioTextBox.BackColor = System.Drawing.Color.White;
			this.PrecioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PrecioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrecioTextBox.Location = new System.Drawing.Point(110, 109);
			this.PrecioTextBox.Name = "PrecioTextBox";
			this.PrecioTextBox.Size = new System.Drawing.Size(87, 23);
			this.PrecioTextBox.TabIndex = 7;
			this.PrecioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PrecioTextBox.TextChanged += new System.EventHandler(this.PrecioTextBox_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 111);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 18);
			this.label6.TabIndex = 6;
			this.label6.Text = "Monto:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 135);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "Forma de pago:";
			// 
			// MonedasComboBox
			// 
			this.MonedasComboBox.DataSource = this.monedasBindingSource;
			this.MonedasComboBox.DisplayMember = "Nombre";
			this.MonedasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonedasComboBox.FormattingEnabled = true;
			this.MonedasComboBox.Location = new System.Drawing.Point(110, 133);
			this.MonedasComboBox.Name = "MonedasComboBox";
			this.MonedasComboBox.Size = new System.Drawing.Size(162, 26);
			this.MonedasComboBox.TabIndex = 9;
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
			this.ConductorTextBox.Location = new System.Drawing.Point(110, 54);
			this.ConductorTextBox.Name = "ConductorTextBox";
			this.ConductorTextBox.ReadOnly = true;
			this.ConductorTextBox.Size = new System.Drawing.Size(241, 24);
			this.ConductorTextBox.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 55);
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
			// VentaServiciosConductor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 565);
			this.Controls.Add(this.groupBox1);
			this.Name = "VentaServiciosConductor";
			this.Text = "VentaServicios";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tiposServiciosConductoresBindingSource)).EndInit();
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
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TiposServiciosConductoresComboBox;
        private System.Windows.Forms.BindingSource tiposServiciosConductoresBindingSource;
	   private System.Windows.Forms.TextBox txtCtaBanco;
	   private System.Windows.Forms.Label lblCtaBanco;
    }
}