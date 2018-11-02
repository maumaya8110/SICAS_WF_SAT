namespace SICASv20.forms
{
    partial class ConductoresIdGNV
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
            this.dgvConductores = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lbltop = new System.Windows.Forms.Label();
            this.lblconductorid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConductores
            // 
            this.dgvConductores.AllowUserToAddRows = false;
            this.dgvConductores.AllowUserToDeleteRows = false;
            this.dgvConductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConductores.Location = new System.Drawing.Point(12, 21);
            this.dgvConductores.Name = "dgvConductores";
            this.dgvConductores.ReadOnly = true;
            this.dgvConductores.RowTemplate.Height = 24;
            this.dgvConductores.Size = new System.Drawing.Size(1078, 313);
            this.dgvConductores.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(959, 340);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(131, 36);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lbltop
            // 
            this.lbltop.AutoSize = true;
            this.lbltop.Location = new System.Drawing.Point(30, 361);
            this.lbltop.Name = "lbltop";
            this.lbltop.Size = new System.Drawing.Size(0, 17);
            this.lbltop.TabIndex = 2;
            this.lbltop.Visible = false;
            // 
            // lblconductorid
            // 
            this.lblconductorid.AutoSize = true;
            this.lblconductorid.Location = new System.Drawing.Point(422, 361);
            this.lblconductorid.Name = "lblconductorid";
            this.lblconductorid.Size = new System.Drawing.Size(0, 17);
            this.lblconductorid.TabIndex = 3;
            this.lblconductorid.Visible = false;
            // 
            // ConductoresIdGNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 388);
            this.Controls.Add(this.lblconductorid);
            this.Controls.Add(this.lbltop);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvConductores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConductoresIdGNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConductoresIdGNV";
            this.Load += new System.EventHandler(this.ConductoresIdGNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConductores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConductores;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lbltop;
        private System.Windows.Forms.Label lblconductorid;
    }
}