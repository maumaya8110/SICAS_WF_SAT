namespace SICASv20.forms.aeropuerto.nomina
{
	partial class AgregaConductor
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
            this.cmbConductor = new System.Windows.Forms.ComboBox();
            this.lblConductor = new System.Windows.Forms.Label();
            this.cmbTiposNomina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbConductor
            // 
            this.cmbConductor.FormattingEnabled = true;
            this.cmbConductor.Location = new System.Drawing.Point(100, 21);
            this.cmbConductor.Name = "cmbConductor";
            this.cmbConductor.Size = new System.Drawing.Size(413, 24);
            this.cmbConductor.TabIndex = 5;
            this.cmbConductor.SelectedIndexChanged += new System.EventHandler(this.cmbConductor_SelectedIndexChanged);
            // 
            // lblConductor
            // 
            this.lblConductor.AutoSize = true;
            this.lblConductor.Location = new System.Drawing.Point(21, 25);
            this.lblConductor.Name = "lblConductor";
            this.lblConductor.Size = new System.Drawing.Size(73, 17);
            this.lblConductor.TabIndex = 4;
            this.lblConductor.Text = "Conductor";
            // 
            // cmbTiposNomina
            // 
            this.cmbTiposNomina.FormattingEnabled = true;
            this.cmbTiposNomina.Location = new System.Drawing.Point(100, 56);
            this.cmbTiposNomina.Name = "cmbTiposNomina";
            this.cmbTiposNomina.Size = new System.Drawing.Size(280, 24);
            this.cmbTiposNomina.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo Nómina";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(11, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 62);
            this.panel1.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(140, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblConductor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbTiposNomina);
            this.panel2.Controls.Add(this.cmbConductor);
            this.panel2.Location = new System.Drawing.Point(11, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 100);
            this.panel2.TabIndex = 10;
            // 
            // AgregaConductor
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(553, 193);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregaConductor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregaConductor";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.AgregaConductor_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbConductor;
		private System.Windows.Forms.Label lblConductor;
		private System.Windows.Forms.ComboBox cmbTiposNomina;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Panel panel2;
	}
}