namespace SICASv20.forms
{
    partial class ActualizacionTarifas
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
            this.TarifasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TiposServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.Zona_IDLabel = new System.Windows.Forms.Label();
            this.Zona_IDComboBox = new System.Windows.Forms.ComboBox();
            this.TipoServicio_IDLabel = new System.Windows.Forms.Label();
            this.TipoServicio_IDComboBox = new System.Windows.Forms.ComboBox();
            this.TarifaLabel = new System.Windows.Forms.Label();
            this.TarifaTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TarifasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposServiciosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TarifasBindingSource
            // 
            this.TarifasBindingSource.DataSource = typeof(SICASv20.Entities.Tarifas);
            // 
            // ZonasBindingSource
            // 
            this.ZonasBindingSource.DataSource = typeof(SICASv20.Entities.Zonas);
            // 
            // TiposServiciosBindingSource
            // 
            this.TiposServiciosBindingSource.DataSource = typeof(SICASv20.Entities.TiposServicios);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(474, 25);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 8;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(474, 73);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 7;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // Zona_IDLabel
            // 
            this.Zona_IDLabel.AutoSize = true;
            this.Zona_IDLabel.Location = new System.Drawing.Point(19, 45);
            this.Zona_IDLabel.Name = "Zona_IDLabel";
            this.Zona_IDLabel.Size = new System.Drawing.Size(57, 15);
            this.Zona_IDLabel.TabIndex = 1;
            this.Zona_IDLabel.Text = "Zona_ID:";
            // 
            // Zona_IDComboBox
            // 
            this.Zona_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.TarifasBindingSource, "Zona_ID", true));
            this.Zona_IDComboBox.DataSource = this.ZonasBindingSource;
            this.Zona_IDComboBox.DisplayMember = "Nombre";
            this.Zona_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Zona_IDComboBox.FormattingEnabled = true;
            this.Zona_IDComboBox.Location = new System.Drawing.Point(139, 39);
            this.Zona_IDComboBox.Name = "Zona_IDComboBox";
            this.Zona_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Zona_IDComboBox.TabIndex = 2;
            this.Zona_IDComboBox.ValueMember = "Zona_ID";
            // 
            // TipoServicio_IDLabel
            // 
            this.TipoServicio_IDLabel.AutoSize = true;
            this.TipoServicio_IDLabel.Location = new System.Drawing.Point(19, 74);
            this.TipoServicio_IDLabel.Name = "TipoServicio_IDLabel";
            this.TipoServicio_IDLabel.Size = new System.Drawing.Size(96, 15);
            this.TipoServicio_IDLabel.TabIndex = 3;
            this.TipoServicio_IDLabel.Text = "TipoServicio_ID:";
            // 
            // TipoServicio_IDComboBox
            // 
            this.TipoServicio_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.TarifasBindingSource, "TipoServicio_ID", true));
            this.TipoServicio_IDComboBox.DataSource = this.TiposServiciosBindingSource;
            this.TipoServicio_IDComboBox.DisplayMember = "Nombre";
            this.TipoServicio_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoServicio_IDComboBox.FormattingEnabled = true;
            this.TipoServicio_IDComboBox.Location = new System.Drawing.Point(139, 68);
            this.TipoServicio_IDComboBox.Name = "TipoServicio_IDComboBox";
            this.TipoServicio_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoServicio_IDComboBox.TabIndex = 4;
            this.TipoServicio_IDComboBox.ValueMember = "TipoServicio_ID";
            // 
            // TarifaLabel
            // 
            this.TarifaLabel.AutoSize = true;
            this.TarifaLabel.Location = new System.Drawing.Point(19, 103);
            this.TarifaLabel.Name = "TarifaLabel";
            this.TarifaLabel.Size = new System.Drawing.Size(41, 15);
            this.TarifaLabel.TabIndex = 5;
            this.TarifaLabel.Text = "Tarifa:";
            // 
            // TarifaTextBox
            // 
            this.TarifaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TarifasBindingSource, "Tarifa", true));
            this.TarifaTextBox.Location = new System.Drawing.Point(139, 97);
            this.TarifaTextBox.Name = "TarifaTextBox";
            this.TarifaTextBox.Size = new System.Drawing.Size(150, 21);
            this.TarifaTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TarifaTextBox);
            this.groupBox1.Controls.Add(this.TipoServicio_IDComboBox);
            this.groupBox1.Controls.Add(this.Zona_IDComboBox);
            this.groupBox1.Controls.Add(this.TarifaLabel);
            this.groupBox1.Controls.Add(this.Zona_IDLabel);
            this.groupBox1.Controls.Add(this.TipoServicio_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 162);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de tarifas";
            // 
            // ActualizacionTarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionTarifas";
            this.Text = "AltaTarifas";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TarifasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TiposServiciosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label Zona_IDLabel;
        private System.Windows.Forms.ComboBox Zona_IDComboBox;
        private System.Windows.Forms.Label TipoServicio_IDLabel;
        private System.Windows.Forms.ComboBox TipoServicio_IDComboBox;
        private System.Windows.Forms.Label TarifaLabel;
        private System.Windows.Forms.TextBox TarifaTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource TarifasBindingSource;
        private System.Windows.Forms.BindingSource ZonasBindingSource;
        private System.Windows.Forms.BindingSource TiposServiciosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}