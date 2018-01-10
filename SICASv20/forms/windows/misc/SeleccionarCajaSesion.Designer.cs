namespace SICASv20.forms
{
    partial class SeleccionarCajaSesion
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CajasComboBox = new System.Windows.Forms.ComboBox();
            this.cajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AceptarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de caja";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.CajasComboBox);
            this.flowLayoutPanel1.Controls.Add(this.AceptarButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(286, 104);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija una caja, por favor:";
            // 
            // CajasComboBox
            // 
            this.CajasComboBox.DataSource = this.cajasBindingSource;
            this.CajasComboBox.DisplayMember = "Nombre";
            this.CajasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CajasComboBox.FormattingEnabled = true;
            this.CajasComboBox.Location = new System.Drawing.Point(6, 31);
            this.CajasComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.CajasComboBox.Name = "CajasComboBox";
            this.CajasComboBox.Size = new System.Drawing.Size(248, 21);
            this.CajasComboBox.TabIndex = 1;
            this.CajasComboBox.ValueMember = "Activa";
            // 
            // cajasBindingSource
            // 
            this.cajasBindingSource.DataSource = typeof(SICASv20.Entities.Cajas);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AceptarButton.Location = new System.Drawing.Point(179, 64);
            this.AceptarButton.Margin = new System.Windows.Forms.Padding(6);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 2;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // SeleccionarCajaSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 177);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionarCajaSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione la caja en la que desea iniciar sesión:";
            this.Load += new System.EventHandler(this.SeleccionarCajaSesion_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CajasComboBox;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.BindingSource cajasBindingSource;
    }
}