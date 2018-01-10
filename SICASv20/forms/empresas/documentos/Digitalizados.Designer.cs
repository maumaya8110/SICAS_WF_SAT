namespace SICASv20.forms.empresas.documentos
{
	partial class Digitalizados
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
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Concesiones");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Digitalizados));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvItems = new System.Windows.Forms.TreeView();
			this.ilImagenes = new System.Windows.Forms.ImageList(this.components);
			this.gbBuscar = new System.Windows.Forms.GroupBox();
			this.cmdBuscar = new System.Windows.Forms.Button();
			this.txtTextoABuscar = new System.Windows.Forms.TextBox();
			this.pnlImagen = new System.Windows.Forms.Panel();
			this.pbArchivo = new System.Windows.Forms.PictureBox();
			this.pdfFile = new AxAcroPDFLib.AxAcroPDF();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.gbBuscar.SuspendLayout();
			this.pnlImagen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbArchivo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pdfFile)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvItems);
			this.splitContainer1.Panel1.Controls.Add(this.gbBuscar);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlImagen);
			this.splitContainer1.Panel2.Controls.Add(this.pdfFile);
			this.splitContainer1.Size = new System.Drawing.Size(1280, 621);
			this.splitContainer1.SplitterDistance = 338;
			this.splitContainer1.SplitterWidth = 10;
			this.splitContainer1.TabIndex = 1;
			// 
			// tvItems
			// 
			this.tvItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.tvItems.ImageIndex = 0;
			this.tvItems.ImageList = this.ilImagenes;
			this.tvItems.Location = new System.Drawing.Point(0, 95);
			this.tvItems.Margin = new System.Windows.Forms.Padding(10);
			this.tvItems.Name = "tvItems";
			treeNode2.Name = "Node0";
			treeNode2.Text = "Concesiones";
			this.tvItems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
			this.tvItems.SelectedImageIndex = 0;
			this.tvItems.Size = new System.Drawing.Size(338, 522);
			this.tvItems.TabIndex = 0;
			this.tvItems.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvItems_NodeMouseClick);
			// 
			// ilImagenes
			// 
			this.ilImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImagenes.ImageStream")));
			this.ilImagenes.TransparentColor = System.Drawing.Color.Transparent;
			this.ilImagenes.Images.SetKeyName(0, "orgchart.png");
			this.ilImagenes.Images.SetKeyName(1, "openapp.png");
			this.ilImagenes.Images.SetKeyName(2, "attachfile.png");
			// 
			// gbBuscar
			// 
			this.gbBuscar.BackColor = System.Drawing.Color.Transparent;
			this.gbBuscar.Controls.Add(this.cmdBuscar);
			this.gbBuscar.Controls.Add(this.txtTextoABuscar);
			this.gbBuscar.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbBuscar.Location = new System.Drawing.Point(0, 0);
			this.gbBuscar.Name = "gbBuscar";
			this.gbBuscar.Size = new System.Drawing.Size(338, 95);
			this.gbBuscar.TabIndex = 1;
			this.gbBuscar.TabStop = false;
			this.gbBuscar.Text = "Buscar";
			// 
			// cmdBuscar
			// 
			this.cmdBuscar.Location = new System.Drawing.Point(7, 55);
			this.cmdBuscar.Name = "cmdBuscar";
			this.cmdBuscar.Size = new System.Drawing.Size(316, 34);
			this.cmdBuscar.TabIndex = 1;
			this.cmdBuscar.Text = "Buscar";
			this.cmdBuscar.UseVisualStyleBackColor = true;
			this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
			// 
			// txtTextoABuscar
			// 
			this.txtTextoABuscar.Location = new System.Drawing.Point(7, 24);
			this.txtTextoABuscar.Name = "txtTextoABuscar";
			this.txtTextoABuscar.Size = new System.Drawing.Size(316, 24);
			this.txtTextoABuscar.TabIndex = 0;
			this.txtTextoABuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTextoABuscar_KeyPress);
			// 
			// pnlImagen
			// 
			this.pnlImagen.AutoScroll = true;
			this.pnlImagen.AutoSize = true;
			this.pnlImagen.Controls.Add(this.pbArchivo);
			this.pnlImagen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlImagen.Location = new System.Drawing.Point(0, 0);
			this.pnlImagen.Name = "pnlImagen";
			this.pnlImagen.Size = new System.Drawing.Size(932, 621);
			this.pnlImagen.TabIndex = 2;
			this.pnlImagen.Visible = false;
			// 
			// pbArchivo
			// 
			this.pbArchivo.Location = new System.Drawing.Point(0, 0);
			this.pbArchivo.Name = "pbArchivo";
			this.pbArchivo.Size = new System.Drawing.Size(932, 621);
			this.pbArchivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbArchivo.TabIndex = 1;
			this.pbArchivo.TabStop = false;
			// 
			// pdfFile
			// 
			this.pdfFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pdfFile.Enabled = true;
			this.pdfFile.Location = new System.Drawing.Point(0, 0);
			this.pdfFile.Margin = new System.Windows.Forms.Padding(10);
			this.pdfFile.Name = "pdfFile";
			this.pdfFile.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfFile.OcxState")));
			this.pdfFile.Padding = new System.Windows.Forms.Padding(20);
			this.pdfFile.Size = new System.Drawing.Size(932, 621);
			this.pdfFile.TabIndex = 0;
			this.pdfFile.Visible = false;
			// 
			// Digitalizados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 652);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Digitalizados";
			this.Text = "Digitalizadas";
			this.Shown += new System.EventHandler(this.Digitalizados_Shown);
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.gbBuscar.ResumeLayout(false);
			this.gbBuscar.PerformLayout();
			this.pnlImagen.ResumeLayout(false);
			this.pnlImagen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbArchivo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pdfFile)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView tvItems;
		private System.Windows.Forms.ImageList ilImagenes;
		private System.Windows.Forms.GroupBox gbBuscar;
		private System.Windows.Forms.Button cmdBuscar;
		private System.Windows.Forms.TextBox txtTextoABuscar;
		private AxAcroPDFLib.AxAcroPDF pdfFile;
		private System.Windows.Forms.PictureBox pbArchivo;
		private System.Windows.Forms.Panel pnlImagen;
	}
}