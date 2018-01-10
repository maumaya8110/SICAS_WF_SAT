namespace SICASv20.forms
{
    partial class AltaTiposMantenimientos
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
            this.TiposMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.TipoMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.TipoMantenimiento_IDTextBox = new System.Windows.Forms.TextBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActivoLabel = new System.Windows.Forms.Label();
            this.ActivoCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TiposMantenimientosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TiposMantenimientosBindingSource
            // 
            this.TiposMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.TiposMantenimientos);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(511, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(511, 70);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // TipoMantenimiento_IDLabel
            // 
            this.TipoMantenimiento_IDLabel.AutoSize = true;
            this.TipoMantenimiento_IDLabel.Location = new System.Drawing.Point(21, 33);
            this.TipoMantenimiento_IDLabel.Name = "TipoMantenimiento_IDLabel";
            this.TipoMantenimiento_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.TipoMantenimiento_IDLabel.TabIndex = 1;
            this.TipoMantenimiento_IDLabel.Text = "TipoMantenimiento_ID:";
            // 
            // TipoMantenimiento_IDTextBox
            // 
            this.TipoMantenimiento_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TiposMantenimientosBindingSource, "TipoMantenimiento_ID", true));
            this.TipoMantenimiento_IDTextBox.Location = new System.Drawing.Point(206, 33);
            this.TipoMantenimiento_IDTextBox.Name = "TipoMantenimiento_IDTextBox";
            this.TipoMantenimiento_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.TipoMantenimiento_IDTextBox.TabIndex = 2;
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(21, 60);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 3;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TiposMantenimientosBindingSource, "Nombre", true));
            this.NombreTextBox.Location = new System.Drawing.Point(206, 60);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ActivoLabel);
            this.groupBox1.Controls.Add(this.ActivoCheckBox);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 131);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de tipos de mantenimientos";
            // 
            // ActivoLabel
            // 
            this.ActivoLabel.AutoSize = true;
            this.ActivoLabel.Location = new System.Drawing.Point(21, 91);
            this.ActivoLabel.Name = "ActivoLabel";
            this.ActivoLabel.Size = new System.Drawing.Size(41, 15);
            this.ActivoLabel.TabIndex = 6;
            this.ActivoLabel.Text = "Activo:";
            // 
            // ActivoCheckBox
            // 
            this.ActivoCheckBox.AutoSize = true;
            this.ActivoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.TiposMantenimientosBindingSource, "Activo", true));
            this.ActivoCheckBox.Location = new System.Drawing.Point(206, 92);
            this.ActivoCheckBox.Name = "ActivoCheckBox";
            this.ActivoCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ActivoCheckBox.TabIndex = 5;
            this.ActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // AltaTiposMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "AltaTiposMantenimientos";
            this.Text = "AltaTiposMantenimientos";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TiposMantenimientosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label TipoMantenimiento_IDLabel;
        private System.Windows.Forms.TextBox TipoMantenimiento_IDTextBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource TiposMantenimientosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ActivoLabel;
        private System.Windows.Forms.CheckBox ActivoCheckBox;


    }
}