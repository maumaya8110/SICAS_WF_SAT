namespace SICASv20.forms
{
    partial class TiposMantenimientosUC : baseUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.bindPanel1 = new SICASv20.BindPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un tipo de mantenimiento";
            // 
            // bindPanel1
            // 
            this.bindPanel1.B_Click = null;
            this.bindPanel1.ButtonHeight = 0;
            this.bindPanel1.ButtonWidth = 0;
            this.bindPanel1.ColumnCount = 2;
            this.bindPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bindPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bindPanel1.DataSource = null;
            this.bindPanel1.DisplayMember = null;
            this.bindPanel1.ItemsCount = 0;
            this.bindPanel1.LayoutType = SICASv20.BindPanel.BindPanelLayoutType.Horizontal;
            this.bindPanel1.Location = new System.Drawing.Point(22, 42);
            this.bindPanel1.Name = "bindPanel1";
            this.bindPanel1.RowCount = 2;
            this.bindPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bindPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bindPanel1.Size = new System.Drawing.Size(654, 489);
            this.bindPanel1.Sqr = 0;
            this.bindPanel1.TabIndex = 1;
            this.bindPanel1.ValueMember = null;
            // 
            // TiposMantenimientosUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bindPanel1);
            this.Controls.Add(this.label1);
            this.Name = "TiposMantenimientosUC";
            this.Size = new System.Drawing.Size(694, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BindPanel bindPanel1;
    }
}
