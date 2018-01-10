namespace SICASv20.forms
{
    partial class PermisosDeGrupoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.GruposComboBox = new System.Windows.Forms.ComboBox();
            this.gruposUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AceptarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un grupo:";
            // 
            // GruposComboBox
            // 
            this.GruposComboBox.DataSource = this.gruposUsuariosBindingSource;
            this.GruposComboBox.DisplayMember = "Nombre";
            this.GruposComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GruposComboBox.FormattingEnabled = true;
            this.GruposComboBox.Location = new System.Drawing.Point(59, 68);
            this.GruposComboBox.Name = "GruposComboBox";
            this.GruposComboBox.Size = new System.Drawing.Size(349, 21);
            this.GruposComboBox.TabIndex = 1;
            this.GruposComboBox.ValueMember = "Descripcion";
            // 
            // gruposUsuariosBindingSource
            // 
            this.gruposUsuariosBindingSource.DataSource = typeof(SICASv20.Entities.GruposUsuarios);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(292, 123);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(116, 33);
            this.AceptarButton.TabIndex = 2;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // PermisosDeGrupoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 183);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.GruposComboBox);
            this.Controls.Add(this.label1);
            this.Name = "PermisosDeGrupoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Grupo";
            this.Load += new System.EventHandler(this.PermisosDeGrupoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GruposComboBox;
        private System.Windows.Forms.BindingSource gruposUsuariosBindingSource;
        private System.Windows.Forms.Button AceptarButton;
    }
}