namespace SICASv20.forms
{
    partial class ActualizacionCategoriasMecanicos
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
            this.CategoriasMecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.CategoriaMecanico_IDLabel = new System.Windows.Forms.Label();
            this.CategoriaMecanico_IDTextBox = new System.Windows.Forms.TextBox();
            this.Familia_IDLabel = new System.Windows.Forms.Label();
            this.Familia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasMecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamiliasBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoriasMecanicosBindingSource
            // 
            this.CategoriasMecanicosBindingSource.DataSource = typeof(SICASv20.Entities.CategoriasMecanicos);
            // 
            // FamiliasBindingSource
            // 
            this.FamiliasBindingSource.DataSource = typeof(SICASv20.Entities.Familias);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(511, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 8;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(511, 70);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 7;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // CategoriaMecanico_IDLabel
            // 
            this.CategoriaMecanico_IDLabel.AutoSize = true;
            this.CategoriaMecanico_IDLabel.Location = new System.Drawing.Point(26, 30);
            this.CategoriaMecanico_IDLabel.Name = "CategoriaMecanico_IDLabel";
            this.CategoriaMecanico_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.CategoriaMecanico_IDLabel.TabIndex = 1;
            this.CategoriaMecanico_IDLabel.Text = "CategoriaMecanico_ID:";
            // 
            // CategoriaMecanico_IDTextBox
            // 
            this.CategoriaMecanico_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CategoriasMecanicosBindingSource, "CategoriaMecanico_ID", true));
            this.CategoriaMecanico_IDTextBox.Location = new System.Drawing.Point(211, 30);
            this.CategoriaMecanico_IDTextBox.Name = "CategoriaMecanico_IDTextBox";
            this.CategoriaMecanico_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.CategoriaMecanico_IDTextBox.TabIndex = 2;
            // 
            // Familia_IDLabel
            // 
            this.Familia_IDLabel.AutoSize = true;
            this.Familia_IDLabel.Location = new System.Drawing.Point(26, 57);
            this.Familia_IDLabel.Name = "Familia_IDLabel";
            this.Familia_IDLabel.Size = new System.Drawing.Size(70, 15);
            this.Familia_IDLabel.TabIndex = 3;
            this.Familia_IDLabel.Text = "Familia_ID:";
            // 
            // Familia_IDComboBox
            // 
            this.Familia_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.CategoriasMecanicosBindingSource, "Familia_ID", true));
            this.Familia_IDComboBox.DataSource = this.FamiliasBindingSource;
            this.Familia_IDComboBox.DisplayMember = "Nombre";
            this.Familia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Familia_IDComboBox.FormattingEnabled = true;
            this.Familia_IDComboBox.Location = new System.Drawing.Point(211, 57);
            this.Familia_IDComboBox.Name = "Familia_IDComboBox";
            this.Familia_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Familia_IDComboBox.TabIndex = 4;
            this.Familia_IDComboBox.ValueMember = "Familia_ID";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(26, 84);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 5;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CategoriasMecanicosBindingSource, "Nombre", true));
            this.NombreTextBox.Location = new System.Drawing.Point(211, 84);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDLabel);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDTextBox);
            this.groupBox1.Controls.Add(this.Familia_IDComboBox);
            this.groupBox1.Controls.Add(this.Familia_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 137);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de categoría de mecánicos";
            // 
            // ActualizacionCategoriasMecanicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionCategoriasMecanicos";
            this.Text = "AltaCategoriasMecanicos";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasMecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamiliasBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label CategoriaMecanico_IDLabel;
        private System.Windows.Forms.TextBox CategoriaMecanico_IDTextBox;
        private System.Windows.Forms.Label Familia_IDLabel;
        private System.Windows.Forms.ComboBox Familia_IDComboBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource CategoriasMecanicosBindingSource;
        private System.Windows.Forms.BindingSource FamiliasBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}