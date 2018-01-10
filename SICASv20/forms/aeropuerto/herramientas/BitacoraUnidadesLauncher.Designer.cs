namespace SICASv20.forms
{
    partial class BitacoraUnidadesLauncher
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
            this.AbrirBitacoraButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AbrirBitacoraButton
            // 
            this.AbrirBitacoraButton.Location = new System.Drawing.Point(53, 27);
            this.AbrirBitacoraButton.Name = "AbrirBitacoraButton";
            this.AbrirBitacoraButton.Size = new System.Drawing.Size(202, 39);
            this.AbrirBitacoraButton.TabIndex = 1;
            this.AbrirBitacoraButton.Text = "Abrir Bitácora de Unidades";
            this.AbrirBitacoraButton.UseVisualStyleBackColor = true;
            this.AbrirBitacoraButton.Click += new System.EventHandler(this.AbrirBitacoraButton_Click);
            // 
            // BitacoraUnidadesLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.AbrirBitacoraButton);
            this.Name = "BitacoraUnidadesLauncher";
            this.Text = "SICASTestLauncher";
            this.Controls.SetChildIndex(this.AbrirBitacoraButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AbrirBitacoraButton;
    }
}