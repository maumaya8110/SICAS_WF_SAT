﻿namespace SICASv20.forms
{
    partial class ActualizacionTiposRefacciones
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
            System.Windows.Forms.Label familia_IDLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label label1;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TipoRefaccion_IDTextBox = new System.Windows.Forms.TextBox();
            this.tiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.FamiliaCombobox = new System.Windows.Forms.ComboBox();
            this.familiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            familia_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // familia_IDLabel
            // 
            familia_IDLabel.AutoSize = true;
            familia_IDLabel.Location = new System.Drawing.Point(22, 54);
            familia_IDLabel.Name = "familia_IDLabel";
            familia_IDLabel.Size = new System.Drawing.Size(51, 15);
            familia_IDLabel.TabIndex = 0;
            familia_IDLabel.Text = "Familia:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(22, 81);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(22, 15);
            label1.TabIndex = 6;
            label1.Text = "ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TipoRefaccion_IDTextBox);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.FamiliaCombobox);
            this.groupBox1.Controls.Add(familia_IDLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 499);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta de tipos de refacciones";
            // 
            // TipoRefaccion_IDTextBox
            // 
            this.TipoRefaccion_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tiposRefaccionesBindingSource, "TipoRefaccion_ID", true));
            this.TipoRefaccion_IDTextBox.Location = new System.Drawing.Point(135, 25);
            this.TipoRefaccion_IDTextBox.Name = "TipoRefaccion_IDTextBox";
            this.TipoRefaccion_IDTextBox.ReadOnly = true;
            this.TipoRefaccion_IDTextBox.Size = new System.Drawing.Size(100, 21);
            this.TipoRefaccion_IDTextBox.TabIndex = 7;
            // 
            // tiposRefaccionesBindingSource
            // 
            this.tiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposRefacciones);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(329, 121);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(126, 38);
            this.GuardarButton.TabIndex = 5;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // FamiliaCombobox
            // 
            this.FamiliaCombobox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tiposRefaccionesBindingSource, "Familia_ID", true));
            this.FamiliaCombobox.DataSource = this.familiasBindingSource;
            this.FamiliaCombobox.DisplayMember = "Nombre";
            this.FamiliaCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamiliaCombobox.FormattingEnabled = true;
            this.FamiliaCombobox.Location = new System.Drawing.Point(135, 51);
            this.FamiliaCombobox.Name = "FamiliaCombobox";
            this.FamiliaCombobox.Size = new System.Drawing.Size(320, 23);
            this.FamiliaCombobox.TabIndex = 4;
            this.FamiliaCombobox.ValueMember = "Familia_ID";
            // 
            // familiasBindingSource
            // 
            this.familiasBindingSource.DataSource = typeof(SICASv20.Entities.Familias);
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tiposRefaccionesBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(135, 78);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(320, 21);
            this.nombreTextBox.TabIndex = 3;
            // 
            // ActualizacionTiposRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActualizacionTiposRefacciones";
            this.Text = "ActualizacionTiposRefacciones";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ComboBox FamiliaCombobox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox TipoRefaccion_IDTextBox;
        private System.Windows.Forms.BindingSource familiasBindingSource;
        private System.Windows.Forms.BindingSource tiposRefaccionesBindingSource;
    }
}