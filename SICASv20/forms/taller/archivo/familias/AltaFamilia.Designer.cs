namespace SICASv20.forms
{
    partial class AltaFamilia
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
            this.familiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.familia_IDTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            familia_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // familia_IDLabel
            // 
            familia_IDLabel.AutoSize = true;
            familia_IDLabel.Location = new System.Drawing.Point(12, 37);
            familia_IDLabel.Name = "familia_IDLabel";
            familia_IDLabel.Size = new System.Drawing.Size(66, 15);
            familia_IDLabel.TabIndex = 2;
            familia_IDLabel.Text = "Familia ID:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(12, 64);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Nombre:";
            // 
            // familiasBindingSource
            // 
            this.familiasBindingSource.DataSource = typeof(SICASv20.Entities.Familias);
            // 
            // familia_IDTextBox
            // 
            this.familia_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.familiasBindingSource, "Familia_ID", true));
            this.familia_IDTextBox.Location = new System.Drawing.Point(84, 34);
            this.familia_IDTextBox.Name = "familia_IDTextBox";
            this.familia_IDTextBox.Size = new System.Drawing.Size(100, 21);
            this.familia_IDTextBox.TabIndex = 3;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.familiasBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(84, 61);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(100, 21);
            this.nombreTextBox.TabIndex = 5;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(269, 20);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(95, 32);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.familia_IDTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(familia_IDLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 112);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de familia";
            // 
            // AltaFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "AltaFamilia";
            this.Text = "AltaFamilia";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.familiasBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource familiasBindingSource;
        private System.Windows.Forms.TextBox familia_IDTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}