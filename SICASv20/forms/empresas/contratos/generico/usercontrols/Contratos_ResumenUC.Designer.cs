namespace SICASv20.forms
{
    partial class Contratos_ResumenUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resumenGridView = new System.Windows.Forms.DataGridView();
            this.FinalizarButton = new System.Windows.Forms.Button();
            this.AtrasButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resumenGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.resumenGridView);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 507);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistente de Contrato: Resumen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor, revise la información. Si desea proceder, haga clic en \"Efectuar contr" +
                "ato\"";
            // 
            // resumenGridView
            // 
            this.resumenGridView.AllowUserToAddRows = false;
            this.resumenGridView.AllowUserToDeleteRows = false;
            this.resumenGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resumenGridView.ColumnHeadersVisible = false;
            this.resumenGridView.Location = new System.Drawing.Point(16, 80);
            this.resumenGridView.Name = "resumenGridView";
            this.resumenGridView.ReadOnly = true;
            this.resumenGridView.Size = new System.Drawing.Size(880, 383);
            this.resumenGridView.TabIndex = 0;
            // 
            // FinalizarButton
            // 
            this.FinalizarButton.Location = new System.Drawing.Point(802, 517);
            this.FinalizarButton.Name = "FinalizarButton";
            this.FinalizarButton.Size = new System.Drawing.Size(134, 31);
            this.FinalizarButton.TabIndex = 24;
            this.FinalizarButton.Text = "Efectuar contrato";
            this.FinalizarButton.UseVisualStyleBackColor = true;
            this.FinalizarButton.Click += new System.EventHandler(this.FinalizarButton_Click);
            // 
            // AtrasButton
            // 
            this.AtrasButton.Location = new System.Drawing.Point(707, 517);
            this.AtrasButton.Name = "AtrasButton";
            this.AtrasButton.Size = new System.Drawing.Size(89, 31);
            this.AtrasButton.TabIndex = 25;
            this.AtrasButton.Text = "Atras";
            this.AtrasButton.UseVisualStyleBackColor = true;
            this.AtrasButton.Click += new System.EventHandler(this.AtrasButton_Click);
            // 
            // Contratos_ResumenUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AtrasButton);
            this.Controls.Add(this.FinalizarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Contratos_ResumenUC";
            this.Size = new System.Drawing.Size(939, 566);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resumenGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FinalizarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView resumenGridView;
        private System.Windows.Forms.Button AtrasButton;
    }
}
