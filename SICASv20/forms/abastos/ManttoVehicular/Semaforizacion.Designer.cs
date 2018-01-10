namespace SICASv20.forms.abastos.ManttoVehicular
{
	partial class Semaforizacion
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtDescripcion = new System.Windows.Forms.Label();
			this.txtUnidad = new System.Windows.Forms.MaskedTextBox();
			this.txtKilometraje = new System.Windows.Forms.Label();
			this.cmdGeneraOrden = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvServicios = new System.Windows.Forms.DataGridView();
			this.bsPlantilla = new System.Windows.Forms.BindingSource(this.components);
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPlantilla)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
			this.splitContainer1.Panel1.Controls.Add(this.txtUnidad);
			this.splitContainer1.Panel1.Controls.Add(this.txtKilometraje);
			this.splitContainer1.Panel1.Controls.Add(this.cmdGeneraOrden);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvServicios);
			this.splitContainer1.Size = new System.Drawing.Size(1024, 652);
			this.splitContainer1.SplitterDistance = 88;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 1;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.BackColor = System.Drawing.Color.White;
			this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescripcion.Location = new System.Drawing.Point(273, 19);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(385, 24);
			this.txtDescripcion.TabIndex = 3;
			this.txtDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtUnidad
			// 
			this.txtUnidad.Location = new System.Drawing.Point(91, 19);
			this.txtUnidad.Mask = "9999";
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.Size = new System.Drawing.Size(54, 24);
			this.txtUnidad.TabIndex = 1;
			this.txtUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtUnidad.ValidatingType = typeof(int);
			this.txtUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnidad_KeyPress);
			// 
			// txtKilometraje
			// 
			this.txtKilometraje.BackColor = System.Drawing.Color.White;
			this.txtKilometraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtKilometraje.Location = new System.Drawing.Point(718, 37);
			this.txtKilometraje.Name = "txtKilometraje";
			this.txtKilometraje.Size = new System.Drawing.Size(112, 37);
			this.txtKilometraje.TabIndex = 5;
			this.txtKilometraje.Text = "500,000";
			this.txtKilometraje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdGeneraOrden
			// 
			this.cmdGeneraOrden.Location = new System.Drawing.Point(871, 19);
			this.cmdGeneraOrden.Name = "cmdGeneraOrden";
			this.cmdGeneraOrden.Size = new System.Drawing.Size(129, 55);
			this.cmdGeneraOrden.TabIndex = 6;
			this.cmdGeneraOrden.Text = "Generar Orden de Servicio";
			this.cmdGeneraOrden.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(178, 18);
			this.label4.TabIndex = 7;
			this.label4.Text = "Kilometraje (Miles de Km)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(719, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Kilometraje Act:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(176, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descripción:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Unidad:";
			// 
			// dgvServicios
			// 
			this.dgvServicios.AllowUserToAddRows = false;
			this.dgvServicios.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvServicios.AutoGenerateColumns = false;
			this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvServicios.DataSource = this.bsPlantilla;
			this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvServicios.Location = new System.Drawing.Point(0, 0);
			this.dgvServicios.Name = "dgvServicios";
			this.dgvServicios.ReadOnly = true;
			this.dgvServicios.RowTemplate.Height = 24;
			this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvServicios.Size = new System.Drawing.Size(1024, 558);
			this.dgvServicios.TabIndex = 0;
			// 
			// Semaforizacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Semaforizacion";
			this.Text = "Semaforizacion";
			this.Controls.SetChildIndex(this.splitContainer1, 0);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsPlantilla)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvServicios;
		private System.Windows.Forms.Button cmdGeneraOrden;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MaskedTextBox txtUnidad;
		private System.Windows.Forms.Label txtKilometraje;
		private System.Windows.Forms.Label txtDescripcion;
		private System.Windows.Forms.BindingSource bsPlantilla;
	}
}