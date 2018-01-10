namespace SICASv20.forms.abastos.ManttoVehicular
{
	partial class Plantillas
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lblAnio = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbModelosUnidad = new System.Windows.Forms.ComboBox();
			this.dgvDetalles = new System.Windows.Forms.DataGridView();
			this.bsDetalles = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsDetalles)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lblAnio);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.cmbModelosUnidad);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvDetalles);
			this.splitContainer1.Size = new System.Drawing.Size(1024, 652);
			this.splitContainer1.SplitterDistance = 62;
			this.splitContainer1.TabIndex = 1;
			// 
			// lblAnio
			// 
			this.lblAnio.BackColor = System.Drawing.Color.White;
			this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnio.Location = new System.Drawing.Point(405, 17);
			this.lblAnio.Name = "lblAnio";
			this.lblAnio.Size = new System.Drawing.Size(95, 26);
			this.lblAnio.TabIndex = 4;
			this.lblAnio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(362, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 18);
			this.label3.TabIndex = 3;
			this.label3.Text = "Año:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Modelo Unidad";
			// 
			// cmbModelosUnidad
			// 
			this.cmbModelosUnidad.DisplayMember = "Descripcion";
			this.cmbModelosUnidad.FormattingEnabled = true;
			this.cmbModelosUnidad.Location = new System.Drawing.Point(132, 17);
			this.cmbModelosUnidad.Name = "cmbModelosUnidad";
			this.cmbModelosUnidad.Size = new System.Drawing.Size(169, 26);
			this.cmbModelosUnidad.TabIndex = 0;
			this.cmbModelosUnidad.ValueMember = "ModeloUnidad_ID";
			this.cmbModelosUnidad.SelectedIndexChanged += new System.EventHandler(this.cmbModelosUnidad_SelectedIndexChanged);
			// 
			// dgvDetalles
			// 
			this.dgvDetalles.AllowUserToAddRows = false;
			this.dgvDetalles.AllowUserToDeleteRows = false;
			this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDetalles.Location = new System.Drawing.Point(0, 0);
			this.dgvDetalles.Name = "dgvDetalles";
			this.dgvDetalles.ReadOnly = true;
			this.dgvDetalles.RowTemplate.Height = 24;
			this.dgvDetalles.Size = new System.Drawing.Size(1024, 586);
			this.dgvDetalles.TabIndex = 0;
			// 
			// Plantillas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Plantillas";
			this.Text = "Plantillas";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsDetalles)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvDetalles;
		private System.Windows.Forms.BindingSource bsDetalles;
		private System.Windows.Forms.Label lblAnio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbModelosUnidad;
	}
}