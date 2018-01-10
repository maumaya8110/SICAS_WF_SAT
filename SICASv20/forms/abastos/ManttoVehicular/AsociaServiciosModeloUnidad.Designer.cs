namespace SICASv20.forms.abastos.ManttoVehicular
{
	partial class AsociaServiciosModeloUnidad
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
			this.listPlantillasAsociadas = new System.Windows.Forms.ListBox();
			this.bsItemsPlantilla = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.listServiciosDisponibles = new System.Windows.Forms.ListBox();
			this.bsServicios = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbModelosUnidades = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.bsItemsPlantilla)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsServicios)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listPlantillasAsociadas
			// 
			this.listPlantillasAsociadas.DataSource = this.bsItemsPlantilla;
			this.listPlantillasAsociadas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listPlantillasAsociadas.FormattingEnabled = true;
			this.listPlantillasAsociadas.ItemHeight = 18;
			this.listPlantillasAsociadas.Location = new System.Drawing.Point(0, 0);
			this.listPlantillasAsociadas.Name = "listPlantillasAsociadas";
			this.listPlantillasAsociadas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listPlantillasAsociadas.Size = new System.Drawing.Size(369, 543);
			this.listPlantillasAsociadas.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.listPlantillasAsociadas);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listServiciosDisponibles);
			this.splitContainer1.Size = new System.Drawing.Size(756, 543);
			this.splitContainer1.SplitterDistance = 369;
			this.splitContainer1.SplitterWidth = 10;
			this.splitContainer1.TabIndex = 2;
			// 
			// listServiciosDisponibles
			// 
			this.listServiciosDisponibles.DataSource = this.bsServicios;
			this.listServiciosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listServiciosDisponibles.FormattingEnabled = true;
			this.listServiciosDisponibles.ItemHeight = 18;
			this.listServiciosDisponibles.Location = new System.Drawing.Point(0, 0);
			this.listServiciosDisponibles.Name = "listServiciosDisponibles";
			this.listServiciosDisponibles.Size = new System.Drawing.Size(377, 543);
			this.listServiciosDisponibles.TabIndex = 2;
			this.listServiciosDisponibles.DoubleClick += new System.EventHandler(this.listServiciosDisponibles_DoubleClick);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(3, 20);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
			this.splitContainer2.Size = new System.Drawing.Size(756, 605);
			this.splitContainer2.SplitterDistance = 52;
			this.splitContainer2.SplitterWidth = 10;
			this.splitContainer2.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnGuardar);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cmbModelosUnidades);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(756, 52);
			this.panel1.TabIndex = 0;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(622, 3);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(118, 46);
			this.btnGuardar.TabIndex = 2;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(229, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Seleccione un Modelo de Unidad:";
			// 
			// cmbModelosUnidades
			// 
			this.cmbModelosUnidades.DisplayMember = "Descripcion";
			this.cmbModelosUnidades.FormattingEnabled = true;
			this.cmbModelosUnidades.Location = new System.Drawing.Point(253, 13);
			this.cmbModelosUnidades.Name = "cmbModelosUnidades";
			this.cmbModelosUnidades.Size = new System.Drawing.Size(305, 26);
			this.cmbModelosUnidades.TabIndex = 0;
			this.cmbModelosUnidades.ValueMember = "ID";
			this.cmbModelosUnidades.SelectionChangeCommitted += new System.EventHandler(this.cmbModelosUnidades_SelectionChangeCommitted);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.splitContainer2);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(762, 628);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Relación de Servicios - Modelo Unidad";
			// 
			// AsociaServiciosModeloUnidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "AsociaServiciosModeloUnidad";
			this.Text = "AsociaServiciosModeloUnidad";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.bsItemsPlantilla)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bsServicios)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listPlantillasAsociadas;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox listServiciosDisponibles;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbModelosUnidades;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.BindingSource bsItemsPlantilla;
		private System.Windows.Forms.BindingSource bsServicios;
	}
}