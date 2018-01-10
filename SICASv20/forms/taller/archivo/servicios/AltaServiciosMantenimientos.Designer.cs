namespace SICASv20.forms
{
    partial class AltaServiciosMantenimientos
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
            this.ServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TiposServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ModelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ServicioMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.ServicioMantenimiento_IDTextBox = new System.Windows.Forms.TextBox();
            this.TipoServicioMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.TipoServicioMantenimiento_IDComboBox = new System.Windows.Forms.ComboBox();
            this.Familia_IDLabel = new System.Windows.Forms.Label();
            this.Familia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.Modelo_IDLabel = new System.Windows.Forms.Label();
            this.Modelo_IDComboBox = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.TiempoAplicadoLabel = new System.Windows.Forms.Label();
            this.TiempoAplicadoTextBox = new System.Windows.Forms.TextBox();
            this.CostoManoObraAreaMinutoLabel = new System.Windows.Forms.Label();
            this.CostoManoObraAreaMinutoTextBox = new System.Windows.Forms.TextBox();
            this.PrecioMinutoLabel = new System.Windows.Forms.Label();
            this.PrecioMinutoTextBox = new System.Windows.Forms.TextBox();
            this.CostoLabel = new System.Windows.Forms.Label();
            this.CostoTextBox = new System.Windows.Forms.TextBox();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.PorcentajeUtilidadLabel = new System.Windows.Forms.Label();
            this.PorcentajeUtilidadTextBox = new System.Windows.Forms.TextBox();
            this.CuotaManoObraLabel = new System.Windows.Forms.Label();
            this.CuotaManoObraTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosMantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposServiciosMantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamiliasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServiciosMantenimientosBindingSource
            // 
            this.ServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.ServiciosMantenimientos);
            // 
            // TiposServiciosMantenimientosBindingSource
            // 
            this.TiposServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.TiposServiciosMantenimientos);
            // 
            // FamiliasBindingSource
            // 
            this.FamiliasBindingSource.DataSource = typeof(SICASv20.Entities.Familias);
            // 
            // ModelosBindingSource
            // 
            this.ModelosBindingSource.DataSource = typeof(SICASv20.Entities.Modelos);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(511, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 26;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(511, 70);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 25;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // ServicioMantenimiento_IDLabel
            // 
            this.ServicioMantenimiento_IDLabel.AutoSize = true;
            this.ServicioMantenimiento_IDLabel.Location = new System.Drawing.Point(20, 36);
            this.ServicioMantenimiento_IDLabel.Name = "ServicioMantenimiento_IDLabel";
            this.ServicioMantenimiento_IDLabel.Size = new System.Drawing.Size(155, 15);
            this.ServicioMantenimiento_IDLabel.TabIndex = 1;
            this.ServicioMantenimiento_IDLabel.Text = "ServicioMantenimiento_ID:";
            // 
            // ServicioMantenimiento_IDTextBox
            // 
            this.ServicioMantenimiento_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "ServicioMantenimiento_ID", true));
            this.ServicioMantenimiento_IDTextBox.Location = new System.Drawing.Point(205, 36);
            this.ServicioMantenimiento_IDTextBox.Name = "ServicioMantenimiento_IDTextBox";
            this.ServicioMantenimiento_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.ServicioMantenimiento_IDTextBox.TabIndex = 2;
            // 
            // TipoServicioMantenimiento_IDLabel
            // 
            this.TipoServicioMantenimiento_IDLabel.AutoSize = true;
            this.TipoServicioMantenimiento_IDLabel.Location = new System.Drawing.Point(20, 63);
            this.TipoServicioMantenimiento_IDLabel.Name = "TipoServicioMantenimiento_IDLabel";
            this.TipoServicioMantenimiento_IDLabel.Size = new System.Drawing.Size(179, 15);
            this.TipoServicioMantenimiento_IDLabel.TabIndex = 3;
            this.TipoServicioMantenimiento_IDLabel.Text = "TipoServicioMantenimiento_ID:";
            // 
            // TipoServicioMantenimiento_IDComboBox
            // 
            this.TipoServicioMantenimiento_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ServiciosMantenimientosBindingSource, "TipoServicioMantenimiento_ID", true));
            this.TipoServicioMantenimiento_IDComboBox.DataSource = this.TiposServiciosMantenimientosBindingSource;
            this.TipoServicioMantenimiento_IDComboBox.DisplayMember = "Nombre";
            this.TipoServicioMantenimiento_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoServicioMantenimiento_IDComboBox.FormattingEnabled = true;
            this.TipoServicioMantenimiento_IDComboBox.Location = new System.Drawing.Point(205, 63);
            this.TipoServicioMantenimiento_IDComboBox.Name = "TipoServicioMantenimiento_IDComboBox";
            this.TipoServicioMantenimiento_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoServicioMantenimiento_IDComboBox.TabIndex = 4;
            this.TipoServicioMantenimiento_IDComboBox.ValueMember = "TipoServicioMantenimiento_ID";
            // 
            // Familia_IDLabel
            // 
            this.Familia_IDLabel.AutoSize = true;
            this.Familia_IDLabel.Location = new System.Drawing.Point(20, 90);
            this.Familia_IDLabel.Name = "Familia_IDLabel";
            this.Familia_IDLabel.Size = new System.Drawing.Size(70, 15);
            this.Familia_IDLabel.TabIndex = 5;
            this.Familia_IDLabel.Text = "Familia_ID:";
            // 
            // Familia_IDComboBox
            // 
            this.Familia_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ServiciosMantenimientosBindingSource, "Familia_ID", true));
            this.Familia_IDComboBox.DataSource = this.FamiliasBindingSource;
            this.Familia_IDComboBox.DisplayMember = "Nombre";
            this.Familia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Familia_IDComboBox.FormattingEnabled = true;
            this.Familia_IDComboBox.Location = new System.Drawing.Point(205, 90);
            this.Familia_IDComboBox.Name = "Familia_IDComboBox";
            this.Familia_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Familia_IDComboBox.TabIndex = 6;
            this.Familia_IDComboBox.ValueMember = "Familia_ID";
            // 
            // Modelo_IDLabel
            // 
            this.Modelo_IDLabel.AutoSize = true;
            this.Modelo_IDLabel.Location = new System.Drawing.Point(20, 117);
            this.Modelo_IDLabel.Name = "Modelo_IDLabel";
            this.Modelo_IDLabel.Size = new System.Drawing.Size(71, 15);
            this.Modelo_IDLabel.TabIndex = 7;
            this.Modelo_IDLabel.Text = "Modelo_ID:";
            // 
            // Modelo_IDComboBox
            // 
            this.Modelo_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ServiciosMantenimientosBindingSource, "Modelo_ID", true));
            this.Modelo_IDComboBox.DataSource = this.ModelosBindingSource;
            this.Modelo_IDComboBox.DisplayMember = "Nombre";
            this.Modelo_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Modelo_IDComboBox.FormattingEnabled = true;
            this.Modelo_IDComboBox.Location = new System.Drawing.Point(205, 117);
            this.Modelo_IDComboBox.Name = "Modelo_IDComboBox";
            this.Modelo_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Modelo_IDComboBox.TabIndex = 8;
            this.Modelo_IDComboBox.ValueMember = "Modelo_ID";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(20, 144);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 9;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "Nombre", true));
            this.NombreTextBox.Location = new System.Drawing.Point(205, 144);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 10;
            // 
            // TiempoAplicadoLabel
            // 
            this.TiempoAplicadoLabel.AutoSize = true;
            this.TiempoAplicadoLabel.Location = new System.Drawing.Point(20, 171);
            this.TiempoAplicadoLabel.Name = "TiempoAplicadoLabel";
            this.TiempoAplicadoLabel.Size = new System.Drawing.Size(99, 15);
            this.TiempoAplicadoLabel.TabIndex = 11;
            this.TiempoAplicadoLabel.Text = "TiempoAplicado:";
            // 
            // TiempoAplicadoTextBox
            // 
            this.TiempoAplicadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "TiempoAplicado", true));
            this.TiempoAplicadoTextBox.Location = new System.Drawing.Point(205, 171);
            this.TiempoAplicadoTextBox.Name = "TiempoAplicadoTextBox";
            this.TiempoAplicadoTextBox.Size = new System.Drawing.Size(150, 21);
            this.TiempoAplicadoTextBox.TabIndex = 12;
            // 
            // CostoManoObraAreaMinutoLabel
            // 
            this.CostoManoObraAreaMinutoLabel.AutoSize = true;
            this.CostoManoObraAreaMinutoLabel.Location = new System.Drawing.Point(20, 198);
            this.CostoManoObraAreaMinutoLabel.Name = "CostoManoObraAreaMinutoLabel";
            this.CostoManoObraAreaMinutoLabel.Size = new System.Drawing.Size(163, 15);
            this.CostoManoObraAreaMinutoLabel.TabIndex = 13;
            this.CostoManoObraAreaMinutoLabel.Text = "CostoManoObraAreaMinuto:";
            // 
            // CostoManoObraAreaMinutoTextBox
            // 
            this.CostoManoObraAreaMinutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "CostoManoObraAreaMinuto", true));
            this.CostoManoObraAreaMinutoTextBox.Location = new System.Drawing.Point(205, 198);
            this.CostoManoObraAreaMinutoTextBox.Name = "CostoManoObraAreaMinutoTextBox";
            this.CostoManoObraAreaMinutoTextBox.Size = new System.Drawing.Size(150, 21);
            this.CostoManoObraAreaMinutoTextBox.TabIndex = 14;
            // 
            // PrecioMinutoLabel
            // 
            this.PrecioMinutoLabel.AutoSize = true;
            this.PrecioMinutoLabel.Location = new System.Drawing.Point(20, 225);
            this.PrecioMinutoLabel.Name = "PrecioMinutoLabel";
            this.PrecioMinutoLabel.Size = new System.Drawing.Size(83, 15);
            this.PrecioMinutoLabel.TabIndex = 15;
            this.PrecioMinutoLabel.Text = "PrecioMinuto:";
            // 
            // PrecioMinutoTextBox
            // 
            this.PrecioMinutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "PrecioMinuto", true));
            this.PrecioMinutoTextBox.Location = new System.Drawing.Point(205, 225);
            this.PrecioMinutoTextBox.Name = "PrecioMinutoTextBox";
            this.PrecioMinutoTextBox.Size = new System.Drawing.Size(150, 21);
            this.PrecioMinutoTextBox.TabIndex = 16;
            // 
            // CostoLabel
            // 
            this.CostoLabel.AutoSize = true;
            this.CostoLabel.Location = new System.Drawing.Point(20, 252);
            this.CostoLabel.Name = "CostoLabel";
            this.CostoLabel.Size = new System.Drawing.Size(41, 15);
            this.CostoLabel.TabIndex = 17;
            this.CostoLabel.Text = "Costo:";
            // 
            // CostoTextBox
            // 
            this.CostoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "Costo", true));
            this.CostoTextBox.Location = new System.Drawing.Point(205, 252);
            this.CostoTextBox.Name = "CostoTextBox";
            this.CostoTextBox.Size = new System.Drawing.Size(150, 21);
            this.CostoTextBox.TabIndex = 18;
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.AutoSize = true;
            this.PrecioLabel.Location = new System.Drawing.Point(20, 279);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(45, 15);
            this.PrecioLabel.TabIndex = 19;
            this.PrecioLabel.Text = "Precio:";
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "Precio", true));
            this.PrecioTextBox.Location = new System.Drawing.Point(205, 279);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(150, 21);
            this.PrecioTextBox.TabIndex = 20;
            // 
            // PorcentajeUtilidadLabel
            // 
            this.PorcentajeUtilidadLabel.AutoSize = true;
            this.PorcentajeUtilidadLabel.Location = new System.Drawing.Point(20, 306);
            this.PorcentajeUtilidadLabel.Name = "PorcentajeUtilidadLabel";
            this.PorcentajeUtilidadLabel.Size = new System.Drawing.Size(111, 15);
            this.PorcentajeUtilidadLabel.TabIndex = 21;
            this.PorcentajeUtilidadLabel.Text = "PorcentajeUtilidad:";
            // 
            // PorcentajeUtilidadTextBox
            // 
            this.PorcentajeUtilidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "PorcentajeUtilidad", true));
            this.PorcentajeUtilidadTextBox.Location = new System.Drawing.Point(205, 306);
            this.PorcentajeUtilidadTextBox.Name = "PorcentajeUtilidadTextBox";
            this.PorcentajeUtilidadTextBox.Size = new System.Drawing.Size(150, 21);
            this.PorcentajeUtilidadTextBox.TabIndex = 22;
            // 
            // CuotaManoObraLabel
            // 
            this.CuotaManoObraLabel.AutoSize = true;
            this.CuotaManoObraLabel.Location = new System.Drawing.Point(20, 333);
            this.CuotaManoObraLabel.Name = "CuotaManoObraLabel";
            this.CuotaManoObraLabel.Size = new System.Drawing.Size(101, 15);
            this.CuotaManoObraLabel.TabIndex = 23;
            this.CuotaManoObraLabel.Text = "CuotaManoObra:";
            // 
            // CuotaManoObraTextBox
            // 
            this.CuotaManoObraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServiciosMantenimientosBindingSource, "CuotaManoObra", true));
            this.CuotaManoObraTextBox.Location = new System.Drawing.Point(205, 333);
            this.CuotaManoObraTextBox.Name = "CuotaManoObraTextBox";
            this.CuotaManoObraTextBox.Size = new System.Drawing.Size(150, 21);
            this.CuotaManoObraTextBox.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServicioMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.CuotaManoObraTextBox);
            this.groupBox1.Controls.Add(this.CuotaManoObraLabel);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.PorcentajeUtilidadTextBox);
            this.groupBox1.Controls.Add(this.ServicioMantenimiento_IDTextBox);
            this.groupBox1.Controls.Add(this.PorcentajeUtilidadLabel);
            this.groupBox1.Controls.Add(this.TipoServicioMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.PrecioTextBox);
            this.groupBox1.Controls.Add(this.TipoServicioMantenimiento_IDComboBox);
            this.groupBox1.Controls.Add(this.CostoTextBox);
            this.groupBox1.Controls.Add(this.Familia_IDLabel);
            this.groupBox1.Controls.Add(this.PrecioLabel);
            this.groupBox1.Controls.Add(this.Familia_IDComboBox);
            this.groupBox1.Controls.Add(this.PrecioMinutoTextBox);
            this.groupBox1.Controls.Add(this.Modelo_IDLabel);
            this.groupBox1.Controls.Add(this.PrecioMinutoLabel);
            this.groupBox1.Controls.Add(this.Modelo_IDComboBox);
            this.groupBox1.Controls.Add(this.CostoManoObraAreaMinutoTextBox);
            this.groupBox1.Controls.Add(this.CostoLabel);
            this.groupBox1.Controls.Add(this.CostoManoObraAreaMinutoLabel);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.TiempoAplicadoTextBox);
            this.groupBox1.Controls.Add(this.TiempoAplicadoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 376);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de servicio de mantenimiento";
            // 
            // AltaServiciosMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "AltaServiciosMantenimientos";
            this.Text = "AltaServiciosMantenimientos";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosMantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposServiciosMantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamiliasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label ServicioMantenimiento_IDLabel;
        private System.Windows.Forms.TextBox ServicioMantenimiento_IDTextBox;
        private System.Windows.Forms.Label TipoServicioMantenimiento_IDLabel;
        private System.Windows.Forms.ComboBox TipoServicioMantenimiento_IDComboBox;
        private System.Windows.Forms.Label Familia_IDLabel;
        private System.Windows.Forms.ComboBox Familia_IDComboBox;
        private System.Windows.Forms.Label Modelo_IDLabel;
        private System.Windows.Forms.ComboBox Modelo_IDComboBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label TiempoAplicadoLabel;
        private System.Windows.Forms.TextBox TiempoAplicadoTextBox;
        private System.Windows.Forms.Label CostoManoObraAreaMinutoLabel;
        private System.Windows.Forms.TextBox CostoManoObraAreaMinutoTextBox;
        private System.Windows.Forms.Label PrecioMinutoLabel;
        private System.Windows.Forms.TextBox PrecioMinutoTextBox;
        private System.Windows.Forms.Label CostoLabel;
        private System.Windows.Forms.TextBox CostoTextBox;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label PorcentajeUtilidadLabel;
        private System.Windows.Forms.TextBox PorcentajeUtilidadTextBox;
        private System.Windows.Forms.Label CuotaManoObraLabel;
        private System.Windows.Forms.TextBox CuotaManoObraTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource ServiciosMantenimientosBindingSource;
        private System.Windows.Forms.BindingSource TiposServiciosMantenimientosBindingSource;
        private System.Windows.Forms.BindingSource FamiliasBindingSource;
        private System.Windows.Forms.BindingSource ModelosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}