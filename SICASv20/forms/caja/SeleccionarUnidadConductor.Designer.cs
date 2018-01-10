namespace SICASv20.forms
{
    partial class SeleccionarUnidadConductor
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
            this.label1 = new System.Windows.Forms.Label();
            this.UnidadesBindPanel = new SICASv20.BindPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECCIONE UNA UNIDAD";
            // 
            // UnidadesBindPanel
            // 
            this.UnidadesBindPanel.B_Click = null;
            this.UnidadesBindPanel.ButtonFontSize = 0F;
            this.UnidadesBindPanel.ButtonHeight = 0;
            this.UnidadesBindPanel.ButtonWidth = 0;
            this.UnidadesBindPanel.ColumnCount = 1;
            this.UnidadesBindPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UnidadesBindPanel.DataMember = null;
            this.UnidadesBindPanel.DataSource = null;
            this.UnidadesBindPanel.DisplayMember = null;
            this.UnidadesBindPanel.ImageMember = null;
            this.UnidadesBindPanel.ItemsCount = 0;
            this.UnidadesBindPanel.LayoutType = SICASv20.BindPanel.BindPanelLayoutType.Vertical;
            this.UnidadesBindPanel.Location = new System.Drawing.Point(12, 44);
            this.UnidadesBindPanel.Name = "UnidadesBindPanel";
            this.UnidadesBindPanel.RowCount = 1;
            this.UnidadesBindPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UnidadesBindPanel.Size = new System.Drawing.Size(609, 224);
            this.UnidadesBindPanel.Sqr = 0;
            this.UnidadesBindPanel.TabIndex = 0;
            this.UnidadesBindPanel.ValueMember = null;
            // 
            // SeleccionarUnidadConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 280);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnidadesBindPanel);
            this.Name = "SeleccionarUnidadConductor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar unidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BindPanel UnidadesBindPanel;
        private System.Windows.Forms.Label label1;

    }
}