namespace SICASv20.forms.caja.reportes
{
	partial class ArqueoDeCajaMetropolitano
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.InnerPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.InnerPanel);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(-7, -1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(710, 714);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Corte de Caja Diario";
			// 
			// InnerPanel
			// 
			this.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InnerPanel.Location = new System.Drawing.Point(43, 20);
			this.InnerPanel.Name = "InnerPanel";
			this.InnerPanel.Size = new System.Drawing.Size(664, 691);
			this.InnerPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(3, 20);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(40, 691);
			this.panel1.TabIndex = 1;
			// 
			// ArqueoDeCajaMetropolitano
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 725);
			this.Controls.Add(this.groupBox1);
			this.Name = "ArqueoDeCajaMetropolitano";
			this.Text = "ArqueoDeCajaMetropolitano";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel InnerPanel;
		private System.Windows.Forms.Panel panel1;
	}
}