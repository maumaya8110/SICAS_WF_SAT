namespace SICASv20.forms.aeropuerto.herramientas
{
	partial class Programacion
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvProgramacion = new System.Windows.Forms.DataGridView();
			this.periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MiDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MiProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.JDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.JProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SProgramados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DDisponibles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DProgramado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnActualizar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dgvProgramacion)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvProgramacion
			// 
			this.dgvProgramacion.AllowUserToAddRows = false;
			this.dgvProgramacion.AllowUserToDeleteRows = false;
			this.dgvProgramacion.AllowUserToResizeColumns = false;
			this.dgvProgramacion.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvProgramacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvProgramacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProgramacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.periodo,
            this.LDisponibles,
            this.LProgramados,
            this.MDisponibles,
            this.MProgramados,
            this.MiDisponibles,
            this.MiProgramados,
            this.JDisponibles,
            this.JProgramados,
            this.VDisponibles,
            this.VProgramados,
            this.SDisponibles,
            this.SProgramados,
            this.DDisponibles,
            this.DProgramado});
			this.dgvProgramacion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProgramacion.Location = new System.Drawing.Point(3, 3);
			this.dgvProgramacion.MultiSelect = false;
			this.dgvProgramacion.Name = "dgvProgramacion";
			this.dgvProgramacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvProgramacion.Size = new System.Drawing.Size(1310, 486);
			this.dgvProgramacion.TabIndex = 0;
			this.dgvProgramacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgramacion_CellEndEdit);
			this.dgvProgramacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgramacion_CellEnter);
			this.dgvProgramacion.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgramacion_CellLeave);
			this.dgvProgramacion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProgramacion_CellValidating);
			// 
			// periodo
			// 
			this.periodo.DataPropertyName = "Periodo";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.periodo.DefaultCellStyle = dataGridViewCellStyle2;
			this.periodo.Frozen = true;
			this.periodo.HeaderText = "Periodo";
			this.periodo.Name = "periodo";
			this.periodo.ReadOnly = true;
			this.periodo.Width = 70;
			// 
			// LDisponibles
			// 
			this.LDisponibles.HeaderText = "Lunes Disponibles";
			this.LDisponibles.MaxInputLength = 4;
			this.LDisponibles.Name = "LDisponibles";
			this.LDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.LDisponibles.Width = 80;
			// 
			// LProgramados
			// 
			this.LProgramados.HeaderText = "Lunes Programados";
			this.LProgramados.Name = "LProgramados";
			this.LProgramados.ReadOnly = true;
			this.LProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.LProgramados.Width = 80;
			// 
			// MDisponibles
			// 
			this.MDisponibles.HeaderText = "Martes Disponibles";
			this.MDisponibles.Name = "MDisponibles";
			this.MDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.MDisponibles.Width = 80;
			// 
			// MProgramados
			// 
			this.MProgramados.HeaderText = "Martes Programados";
			this.MProgramados.Name = "MProgramados";
			this.MProgramados.ReadOnly = true;
			this.MProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.MProgramados.Width = 80;
			// 
			// MiDisponibles
			// 
			this.MiDisponibles.HeaderText = "Miércoles Disponibles";
			this.MiDisponibles.Name = "MiDisponibles";
			this.MiDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.MiDisponibles.Width = 80;
			// 
			// MiProgramados
			// 
			this.MiProgramados.HeaderText = "Miércoles Programados";
			this.MiProgramados.Name = "MiProgramados";
			this.MiProgramados.ReadOnly = true;
			this.MiProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.MiProgramados.Width = 80;
			// 
			// JDisponibles
			// 
			this.JDisponibles.HeaderText = "Jueves Disponibles";
			this.JDisponibles.Name = "JDisponibles";
			this.JDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.JDisponibles.Width = 80;
			// 
			// JProgramados
			// 
			this.JProgramados.HeaderText = "Jueves Programados";
			this.JProgramados.Name = "JProgramados";
			this.JProgramados.ReadOnly = true;
			this.JProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.JProgramados.Width = 80;
			// 
			// VDisponibles
			// 
			this.VDisponibles.HeaderText = "Viernes Disponibles";
			this.VDisponibles.Name = "VDisponibles";
			this.VDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VDisponibles.Width = 80;
			// 
			// VProgramados
			// 
			this.VProgramados.HeaderText = "Viernes Programados";
			this.VProgramados.Name = "VProgramados";
			this.VProgramados.ReadOnly = true;
			this.VProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VProgramados.Width = 80;
			// 
			// SDisponibles
			// 
			this.SDisponibles.HeaderText = "Sábado Disponibles";
			this.SDisponibles.Name = "SDisponibles";
			this.SDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// SProgramados
			// 
			this.SProgramados.HeaderText = "Sábado Programados";
			this.SProgramados.Name = "SProgramados";
			this.SProgramados.ReadOnly = true;
			this.SProgramados.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.SProgramados.Width = 80;
			// 
			// DDisponibles
			// 
			this.DDisponibles.HeaderText = "Domingo Disponibles";
			this.DDisponibles.Name = "DDisponibles";
			this.DDisponibles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.DDisponibles.Width = 80;
			// 
			// DProgramado
			// 
			this.DProgramado.HeaderText = "Domingo Programado";
			this.DProgramado.Name = "DProgramado";
			this.DProgramado.ReadOnly = true;
			this.DProgramado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.DProgramado.Width = 80;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1324, 523);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvProgramacion);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1316, 492);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Programa";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnActualizar
			// 
			this.btnActualizar.Location = new System.Drawing.Point(1072, 23);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(106, 56);
			this.btnActualizar.TabIndex = 1;
			this.btnActualizar.Text = "Actualizar";
			this.toolTip1.SetToolTip(this.btnActualizar, "Actualiza la información de Pistas, si no se han guardado los cambios estos se pe" +
        "rderán.");
			this.btnActualizar.UseVisualStyleBackColor = true;
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(1184, 23);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(106, 56);
			this.btnGuardar.TabIndex = 0;
			this.btnGuardar.Text = "Guardar";
			this.toolTip1.SetToolTip(this.btnGuardar, "Almacena la información de la Programación de Pistas");
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnActualizar);
			this.panel1.Controls.Add(this.btnGuardar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 523);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1324, 100);
			this.panel1.TabIndex = 1;
			// 
			// Programacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1324, 668);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Name = "Programacion";
			this.Text = "Programacion";
			this.Controls.SetChildIndex(this.tabControl1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			((System.ComponentModel.ISupportInitialize)(this.dgvProgramacion)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvProgramacion;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnActualizar;
		private System.Windows.Forms.DataGridViewTextBoxColumn periodo;
		private System.Windows.Forms.DataGridViewTextBoxColumn LDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn LProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn MDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn MProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn MiDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn MiProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn JDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn JProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn VDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn VProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn SDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn SProgramados;
		private System.Windows.Forms.DataGridViewTextBoxColumn DDisponibles;
		private System.Windows.Forms.DataGridViewTextBoxColumn DProgramado;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel1;
	}
}