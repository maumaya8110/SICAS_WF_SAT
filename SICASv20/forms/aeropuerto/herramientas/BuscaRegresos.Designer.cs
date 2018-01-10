namespace SICASv20.forms.aeropuerto.herramientas
{
	partial class BuscaRegresos
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.dteFecha = new System.Windows.Forms.DateTimePicker();
			this.cmbZona = new System.Windows.Forms.ComboBox();
			this.chkPrecio = new System.Windows.Forms.CheckBox();
			this.chkZona = new System.Windows.Forms.CheckBox();
			this.chkFolio = new System.Windows.Forms.CheckBox();
			this.chkFecha = new System.Windows.Forms.CheckBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.bsRegresosVendidos = new System.Windows.Forms.BindingSource(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsRegresosVendidos)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.splitContainer1);
			this.groupBox1.Location = new System.Drawing.Point(13, 20);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(993, 613);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Búsqueda de Regresos Vendidos";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(5, 22);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnImprimir);
			this.splitContainer1.Panel1.Controls.Add(this.txtFolio);
			this.splitContainer1.Panel1.Controls.Add(this.txtPrecio);
			this.splitContainer1.Panel1.Controls.Add(this.dteFecha);
			this.splitContainer1.Panel1.Controls.Add(this.cmbZona);
			this.splitContainer1.Panel1.Controls.Add(this.chkPrecio);
			this.splitContainer1.Panel1.Controls.Add(this.chkZona);
			this.splitContainer1.Panel1.Controls.Add(this.chkFolio);
			this.splitContainer1.Panel1.Controls.Add(this.chkFecha);
			this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
			this.splitContainer1.Size = new System.Drawing.Size(983, 586);
			this.splitContainer1.SplitterDistance = 95;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			// 
			// btnImprimir
			// 
			this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnImprimir.Location = new System.Drawing.Point(852, 14);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(102, 60);
			this.btnImprimir.TabIndex = 9;
			this.btnImprimir.Text = "Imprimir";
			this.toolTip1.SetToolTip(this.btnImprimir, "Realiza la impresión del boleto de regreso, siempre y cuando el estatus del bolet" +
        "o sea igual a \"Vendido\"");
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// txtFolio
			// 
			this.txtFolio.Location = new System.Drawing.Point(197, 12);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(200, 24);
			this.txtFolio.TabIndex = 1;
			this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolio_KeyPress);
			// 
			// txtPrecio
			// 
			this.txtPrecio.Enabled = false;
			this.txtPrecio.Location = new System.Drawing.Point(499, 50);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(118, 24);
			this.txtPrecio.TabIndex = 7;
			this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolio_KeyPress);
			// 
			// dteFecha
			// 
			this.dteFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFecha.Location = new System.Drawing.Point(197, 53);
			this.dteFecha.Name = "dteFecha";
			this.dteFecha.Size = new System.Drawing.Size(200, 24);
			this.dteFecha.TabIndex = 3;
			// 
			// cmbZona
			// 
			this.cmbZona.Enabled = false;
			this.cmbZona.FormattingEnabled = true;
			this.cmbZona.Location = new System.Drawing.Point(499, 12);
			this.cmbZona.Name = "cmbZona";
			this.cmbZona.Size = new System.Drawing.Size(118, 26);
			this.cmbZona.TabIndex = 5;
			// 
			// chkPrecio
			// 
			this.chkPrecio.AutoSize = true;
			this.chkPrecio.Location = new System.Drawing.Point(413, 53);
			this.chkPrecio.Name = "chkPrecio";
			this.chkPrecio.Size = new System.Drawing.Size(73, 22);
			this.chkPrecio.TabIndex = 6;
			this.chkPrecio.Text = "Precio";
			this.toolTip1.SetToolTip(this.chkPrecio, "Precio del boleto de Regreso");
			this.chkPrecio.UseVisualStyleBackColor = true;
			this.chkPrecio.Click += new System.EventHandler(this.checkBox4_Click);
			// 
			// chkZona
			// 
			this.chkZona.AutoSize = true;
			this.chkZona.Location = new System.Drawing.Point(413, 14);
			this.chkZona.Name = "chkZona";
			this.chkZona.Size = new System.Drawing.Size(64, 22);
			this.chkZona.TabIndex = 4;
			this.chkZona.Text = "Zona";
			this.toolTip1.SetToolTip(this.chkZona, "Zona destino del boleto de Regreso");
			this.chkZona.UseVisualStyleBackColor = true;
			this.chkZona.Click += new System.EventHandler(this.chkZona_Click);
			// 
			// chkFolio
			// 
			this.chkFolio.Checked = true;
			this.chkFolio.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFolio.Location = new System.Drawing.Point(27, 14);
			this.chkFolio.Name = "chkFolio";
			this.chkFolio.Size = new System.Drawing.Size(164, 22);
			this.chkFolio.TabIndex = 0;
			this.chkFolio.Text = "El Boleto Contenga:";
			this.toolTip1.SetToolTip(this.chkFolio, "Se debe introducir el número de boleto completo o una parte del mismo");
			this.chkFolio.UseVisualStyleBackColor = true;
			this.chkFolio.Click += new System.EventHandler(this.chkFolio_Click);
			// 
			// chkFecha
			// 
			this.chkFecha.Checked = true;
			this.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFecha.Enabled = false;
			this.chkFecha.Location = new System.Drawing.Point(27, 53);
			this.chkFecha.Name = "chkFecha";
			this.chkFecha.Size = new System.Drawing.Size(164, 22);
			this.chkFecha.TabIndex = 2;
			this.chkFecha.Text = "Fecha";
			this.toolTip1.SetToolTip(this.chkFecha, "Fecha en que se realizó la compra del boleto de Regreso");
			this.chkFecha.UseVisualStyleBackColor = true;
			this.chkFecha.Click += new System.EventHandler(this.chkFecha_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnBuscar.Location = new System.Drawing.Point(735, 14);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(102, 60);
			this.btnBuscar.TabIndex = 8;
			this.btnBuscar.Text = "Buscar";
			this.toolTip1.SetToolTip(this.btnBuscar, "Busca la información en el sistema que corresponda con los parámetros indicados.");
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// BuscaRegresos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "BuscaRegresos";
			this.Text = "BuscaRegresos";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsRegresosVendidos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.CheckBox chkFolio;
		private System.Windows.Forms.CheckBox chkFecha;
		private System.Windows.Forms.CheckBox chkPrecio;
		private System.Windows.Forms.CheckBox chkZona;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.DateTimePicker dteFecha;
		private System.Windows.Forms.ComboBox cmbZona;
		private System.Windows.Forms.Button btnImprimir;
		private System.Windows.Forms.BindingSource bsRegresosVendidos;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}