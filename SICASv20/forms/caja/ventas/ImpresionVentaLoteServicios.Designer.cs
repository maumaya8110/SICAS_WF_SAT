namespace SICASv20.forms
{
    partial class ImpresionVentaLoteServicios
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
            this.TiposServiciosComboBox = new System.Windows.Forms.ComboBox();
            this.tiposServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.CantidadTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreZonaTextBox = new System.Windows.Forms.TextBox();
            this.ZonasListBox = new System.Windows.Forms.ListBox();
            this.buscarZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Zona_IDTextBox = new System.Windows.Forms.TextBox();
            this.LabelZona = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarZonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TiposServiciosComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CantidadTextBox);
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(this.PrecioTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NombreZonaTextBox);
            this.groupBox1.Controls.Add(this.ZonasListBox);
            this.groupBox1.Controls.Add(this.Zona_IDTextBox);
            this.groupBox1.Controls.Add(this.LabelZona);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 552);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresión de Servicios Por Lotes";
            // 
            // TiposServiciosComboBox
            // 
            this.TiposServiciosComboBox.DataSource = this.tiposServiciosBindingSource;
            this.TiposServiciosComboBox.DisplayMember = "Nombre";
            this.TiposServiciosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiposServiciosComboBox.FormattingEnabled = true;
            this.TiposServiciosComboBox.Location = new System.Drawing.Point(119, 36);
            this.TiposServiciosComboBox.Name = "TiposServiciosComboBox";
            this.TiposServiciosComboBox.Size = new System.Drawing.Size(204, 23);
            this.TiposServiciosComboBox.TabIndex = 1;
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
            this.label7.Location = new System.Drawing.Point(23, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tipo de servicio:";
            // 
            // CantidadTextBox
            // 
            this.CantidadTextBox.BackColor = System.Drawing.Color.White;
            this.CantidadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CantidadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantidadTextBox.Location = new System.Drawing.Point(126, 273);
            this.CantidadTextBox.Name = "CantidadTextBox";
            this.CantidadTextBox.Size = new System.Drawing.Size(87, 20);
            this.CantidadTextBox.TabIndex = 6;
            this.CantidadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(318, 314);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(133, 44);
            this.AceptarButton.TabIndex = 7;
            this.AceptarButton.Text = "Generar Boletos";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.BackColor = System.Drawing.Color.White;
            this.PrecioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrecioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioTextBox.Location = new System.Drawing.Point(126, 249);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.ReadOnly = true;
            this.PrecioTextBox.Size = new System.Drawing.Size(87, 20);
            this.PrecioTextBox.TabIndex = 5;
            this.PrecioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Zona:";
            // 
            // NombreZonaTextBox
            // 
            this.NombreZonaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreZonaTextBox.Location = new System.Drawing.Point(119, 88);
            this.NombreZonaTextBox.Name = "NombreZonaTextBox";
            this.NombreZonaTextBox.Size = new System.Drawing.Size(343, 21);
            this.NombreZonaTextBox.TabIndex = 3;
            this.NombreZonaTextBox.TextChanged += new System.EventHandler(this.NombreZonaTextBox_TextChanged);
            // 
            // ZonasListBox
            // 
            this.ZonasListBox.DataSource = this.buscarZonasBindingSource;
            this.ZonasListBox.DisplayMember = "Nombre";
            this.ZonasListBox.FormattingEnabled = true;
            this.ZonasListBox.ItemHeight = 15;
            this.ZonasListBox.Location = new System.Drawing.Point(26, 111);
            this.ZonasListBox.Name = "ZonasListBox";
            this.ZonasListBox.Size = new System.Drawing.Size(425, 124);
            this.ZonasListBox.TabIndex = 4;
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
            this.Zona_IDTextBox.Location = new System.Drawing.Point(119, 65);
            this.Zona_IDTextBox.Name = "Zona_IDTextBox";
            this.Zona_IDTextBox.Size = new System.Drawing.Size(204, 21);
            this.Zona_IDTextBox.TabIndex = 2;
            this.Zona_IDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Zona_IDTextBox_KeyUp);
            // 
            // LabelZona
            // 
            this.LabelZona.AutoSize = true;
            this.LabelZona.Location = new System.Drawing.Point(23, 66);
            this.LabelZona.Name = "LabelZona";
            this.LabelZona.Size = new System.Drawing.Size(37, 15);
            this.LabelZona.TabIndex = 10;
            this.LabelZona.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad:";
            // 
            // monedasBindingSource
            // 
            this.monedasBindingSource.DataSource = typeof(SICASv20.Entities.Monedas);
            // 
            // VentaLoteServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 565);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentaLoteServicios";
            this.Text = "VentaServicios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarZonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource monedasBindingSource;
        private System.Windows.Forms.ListBox ZonasListBox;
        private System.Windows.Forms.TextBox Zona_IDTextBox;
        private System.Windows.Forms.BindingSource buscarZonasBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreZonaTextBox;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource tiposServiciosBindingSource;
        private System.Windows.Forms.Label LabelZona;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.TextBox CantidadTextBox;
        private System.Windows.Forms.ComboBox TiposServiciosComboBox;
        private System.Windows.Forms.Label label7;
    }
}