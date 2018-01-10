namespace SICASv20.forms
{
    partial class ActualizacionZonas
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
            this.ZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TiposZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComisionesServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.Zona_IDLabel = new System.Windows.Forms.Label();
            this.Zona_IDTextBox = new System.Windows.Forms.TextBox();
            this.TipoZona_IDLabel = new System.Windows.Forms.Label();
            this.TipoZona_IDComboBox = new System.Windows.Forms.ComboBox();
            this.ComisionServicio_IDLabel = new System.Windows.Forms.Label();
            this.ComisionServicio_IDComboBox = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposZonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComisionesServiciosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZonasBindingSource
            // 
            this.ZonasBindingSource.DataSource = typeof(SICASv20.Entities.Zonas);
            // 
            // TiposZonasBindingSource
            // 
            this.TiposZonasBindingSource.DataSource = typeof(SICASv20.Entities.TiposZonas);
            // 
            // ComisionesServiciosBindingSource
            // 
            this.ComisionesServiciosBindingSource.DataSource = typeof(SICASv20.Entities.ComisionesServicios);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(596, 46);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 10;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(596, 94);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // Zona_IDLabel
            // 
            this.Zona_IDLabel.AutoSize = true;
            this.Zona_IDLabel.Location = new System.Drawing.Point(27, 38);
            this.Zona_IDLabel.Name = "Zona_IDLabel";
            this.Zona_IDLabel.Size = new System.Drawing.Size(57, 15);
            this.Zona_IDLabel.TabIndex = 1;
            this.Zona_IDLabel.Text = "Zona_ID:";
            // 
            // Zona_IDTextBox
            // 
            this.Zona_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ZonasBindingSource, "Zona_ID", true));
            this.Zona_IDTextBox.Location = new System.Drawing.Point(212, 38);
            this.Zona_IDTextBox.Name = "Zona_IDTextBox";
            this.Zona_IDTextBox.Size = new System.Drawing.Size(115, 21);
            this.Zona_IDTextBox.TabIndex = 2;
            // 
            // TipoZona_IDLabel
            // 
            this.TipoZona_IDLabel.AutoSize = true;
            this.TipoZona_IDLabel.Location = new System.Drawing.Point(27, 65);
            this.TipoZona_IDLabel.Name = "TipoZona_IDLabel";
            this.TipoZona_IDLabel.Size = new System.Drawing.Size(82, 15);
            this.TipoZona_IDLabel.TabIndex = 3;
            this.TipoZona_IDLabel.Text = "Tipo de Zona:";
            // 
            // TipoZona_IDComboBox
            // 
            this.TipoZona_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ZonasBindingSource, "TipoZona_ID", true));
            this.TipoZona_IDComboBox.DataSource = this.TiposZonasBindingSource;
            this.TipoZona_IDComboBox.DisplayMember = "Nombre";
            this.TipoZona_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoZona_IDComboBox.FormattingEnabled = true;
            this.TipoZona_IDComboBox.Location = new System.Drawing.Point(212, 65);
            this.TipoZona_IDComboBox.Name = "TipoZona_IDComboBox";
            this.TipoZona_IDComboBox.Size = new System.Drawing.Size(279, 23);
            this.TipoZona_IDComboBox.TabIndex = 4;
            this.TipoZona_IDComboBox.ValueMember = "TipoZona_ID";
            // 
            // ComisionServicio_IDLabel
            // 
            this.ComisionServicio_IDLabel.AutoSize = true;
            this.ComisionServicio_IDLabel.Location = new System.Drawing.Point(27, 92);
            this.ComisionServicio_IDLabel.Name = "ComisionServicio_IDLabel";
            this.ComisionServicio_IDLabel.Size = new System.Drawing.Size(123, 15);
            this.ComisionServicio_IDLabel.TabIndex = 5;
            this.ComisionServicio_IDLabel.Text = "Comisión de servicio:";
            // 
            // ComisionServicio_IDComboBox
            // 
            this.ComisionServicio_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ZonasBindingSource, "ComisionServicio_ID", true));
            this.ComisionServicio_IDComboBox.DataSource = this.ComisionesServiciosBindingSource;
            this.ComisionServicio_IDComboBox.DisplayMember = "Nombre";
            this.ComisionServicio_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComisionServicio_IDComboBox.FormattingEnabled = true;
            this.ComisionServicio_IDComboBox.Location = new System.Drawing.Point(212, 92);
            this.ComisionServicio_IDComboBox.Name = "ComisionServicio_IDComboBox";
            this.ComisionServicio_IDComboBox.Size = new System.Drawing.Size(279, 23);
            this.ComisionServicio_IDComboBox.TabIndex = 6;
            this.ComisionServicio_IDComboBox.ValueMember = "ComisionServicio_ID";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(27, 119);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 7;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ZonasBindingSource, "Nombre", true));
            this.NombreTextBox.Location = new System.Drawing.Point(212, 119);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(279, 21);
            this.NombreTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TipoZona_IDComboBox);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.Zona_IDLabel);
            this.groupBox1.Controls.Add(this.ComisionServicio_IDComboBox);
            this.groupBox1.Controls.Add(this.Zona_IDTextBox);
            this.groupBox1.Controls.Add(this.ComisionServicio_IDLabel);
            this.groupBox1.Controls.Add(this.TipoZona_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 177);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de zonas:";
            // 
            // ActualizacionZonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionZonas";
            this.Text = "AltaZonas";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposZonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComisionesServiciosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label Zona_IDLabel;
        private System.Windows.Forms.TextBox Zona_IDTextBox;
        private System.Windows.Forms.Label TipoZona_IDLabel;
        private System.Windows.Forms.ComboBox TipoZona_IDComboBox;
        private System.Windows.Forms.Label ComisionServicio_IDLabel;
        private System.Windows.Forms.ComboBox ComisionServicio_IDComboBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource ZonasBindingSource;
        private System.Windows.Forms.BindingSource TiposZonasBindingSource;
        private System.Windows.Forms.BindingSource ComisionesServiciosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;        

    }
}