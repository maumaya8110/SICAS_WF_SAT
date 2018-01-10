namespace SICASv20.forms
{
    partial class CambioContraseña
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
            this.GuardarButton = new System.Windows.Forms.Button();
            this.RepetirNuevoPwdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NuevoPwdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.RepetirNuevoPwdTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NuevoPwdTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.EmailTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NombreUsuarioTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 527);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambio de contraseña:";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(355, 242);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(84, 34);
            this.GuardarButton.TabIndex = 8;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // RepetirNuevoPwdTextBox
            // 
            this.RepetirNuevoPwdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "RepetirNuevaContraseña", true));
            this.RepetirNuevoPwdTextBox.Location = new System.Drawing.Point(35, 200);
            this.RepetirNuevoPwdTextBox.Name = "RepetirNuevoPwdTextBox";
            this.RepetirNuevoPwdTextBox.PasswordChar = '?';
            this.RepetirNuevoPwdTextBox.Size = new System.Drawing.Size(214, 21);
            this.RepetirNuevoPwdTextBox.TabIndex = 7;
            this.RepetirNuevoPwdTextBox.TextChanged += new System.EventHandler(this.RepetirNuevoPwdTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Repetir nueva contraseña";
            // 
            // NuevoPwdTextBox
            // 
            this.NuevoPwdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "NuevaContraseña", true));
            this.NuevoPwdTextBox.Location = new System.Drawing.Point(35, 155);
            this.NuevoPwdTextBox.Name = "NuevoPwdTextBox";
            this.NuevoPwdTextBox.PasswordChar = '?';
            this.NuevoPwdTextBox.Size = new System.Drawing.Size(214, 21);
            this.NuevoPwdTextBox.TabIndex = 5;
            this.NuevoPwdTextBox.TextChanged += new System.EventHandler(this.NuevoPwdTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nueva contraseña";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "Email", true));
            this.EmailTextBox.Location = new System.Drawing.Point(35, 108);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(308, 21);
            this.EmailTextBox.TabIndex = 3;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Correo electrónico";
            // 
            // NombreUsuarioTextBox
            // 
            this.NombreUsuarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "NombreUsuario", true));
            this.NombreUsuarioTextBox.Location = new System.Drawing.Point(35, 61);
            this.NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
            this.NombreUsuarioTextBox.ReadOnly = true;
            this.NombreUsuarioTextBox.Size = new System.Drawing.Size(308, 21);
            this.NombreUsuarioTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataSource = typeof(SICASv20.forms.CambioContraseña.Model);
            // 
            // CambioContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "CambioContraseña";
            this.Text = "CambioContraseña";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.TextBox RepetirNuevoPwdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NuevoPwdTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreUsuarioTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource modelBindingSource;
    }
}