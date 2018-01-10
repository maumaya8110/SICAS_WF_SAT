namespace SICASv20.forms
{
    partial class ReporteDeVentasTallerClientes
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
            this.label3 = new System.Windows.Forms.Label();
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FechaTerminacionFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.selectTiposMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FechaTerminacionInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TipoMantenimiento_IDComboBox = new System.Windows.Forms.ComboBox();
            this.TipoMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.Empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.Empresa_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OrdenTrabajoCheckBox = new System.Windows.Forms.CheckBox();
            this.TipoMantenimientoCheckBox = new System.Windows.Forms.CheckBox();
            this.UnidadCheckBox = new System.Windows.Forms.CheckBox();
            this.EmpresaCheckBox = new System.Windows.Forms.CheckBox();
            this.FechaCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReporteVentasDataGridView = new System.Windows.Forms.DataGridView();
            this.ExportarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposMantenimientosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fecha Terminación Final:";
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // FechaTerminacionFinalDateTimePicker
            // 
            this.FechaTerminacionFinalDateTimePicker.Checked = false;
            this.FechaTerminacionFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionFinalDateTimePicker.Location = new System.Drawing.Point(596, 60);
            this.FechaTerminacionFinalDateTimePicker.Name = "FechaTerminacionFinalDateTimePicker";
            this.FechaTerminacionFinalDateTimePicker.ShowCheckBox = true;
            this.FechaTerminacionFinalDateTimePicker.Size = new System.Drawing.Size(129, 21);
            this.FechaTerminacionFinalDateTimePicker.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha Terminación Inicial:";
            // 
            // selectTiposMantenimientosBindingSource
            // 
            this.selectTiposMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposMantenimientos);
            // 
            // FechaTerminacionInicialDateTimePicker
            // 
            this.FechaTerminacionInicialDateTimePicker.Checked = false;
            this.FechaTerminacionInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionInicialDateTimePicker.Location = new System.Drawing.Point(596, 33);
            this.FechaTerminacionInicialDateTimePicker.Name = "FechaTerminacionInicialDateTimePicker";
            this.FechaTerminacionInicialDateTimePicker.ShowCheckBox = true;
            this.FechaTerminacionInicialDateTimePicker.Size = new System.Drawing.Size(129, 21);
            this.FechaTerminacionInicialDateTimePicker.TabIndex = 26;
            // 
            // TipoMantenimiento_IDComboBox
            // 
            this.TipoMantenimiento_IDComboBox.DataSource = this.selectTiposMantenimientosBindingSource;
            this.TipoMantenimiento_IDComboBox.DisplayMember = "Nombre";
            this.TipoMantenimiento_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoMantenimiento_IDComboBox.FormattingEnabled = true;
            this.TipoMantenimiento_IDComboBox.Location = new System.Drawing.Point(175, 54);
            this.TipoMantenimiento_IDComboBox.Name = "TipoMantenimiento_IDComboBox";
            this.TipoMantenimiento_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoMantenimiento_IDComboBox.TabIndex = 25;
            this.TipoMantenimiento_IDComboBox.ValueMember = "TipoMantenimiento_ID";
            // 
            // TipoMantenimiento_IDLabel
            // 
            this.TipoMantenimiento_IDLabel.AutoSize = true;
            this.TipoMantenimiento_IDLabel.Location = new System.Drawing.Point(13, 57);
            this.TipoMantenimiento_IDLabel.Name = "TipoMantenimiento_IDLabel";
            this.TipoMantenimiento_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.TipoMantenimiento_IDLabel.TabIndex = 24;
            this.TipoMantenimiento_IDLabel.Text = "TipoMantenimiento_ID:";
            // 
            // Empresa_IDComboBox
            // 
            this.Empresa_IDComboBox.DataSource = this.selectEmpresasBindingSource;
            this.Empresa_IDComboBox.DisplayMember = "Nombre";
            this.Empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Empresa_IDComboBox.FormattingEnabled = true;
            this.Empresa_IDComboBox.Location = new System.Drawing.Point(175, 27);
            this.Empresa_IDComboBox.Name = "Empresa_IDComboBox";
            this.Empresa_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Empresa_IDComboBox.TabIndex = 23;
            this.Empresa_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // Empresa_IDLabel
            // 
            this.Empresa_IDLabel.AutoSize = true;
            this.Empresa_IDLabel.Location = new System.Drawing.Point(13, 30);
            this.Empresa_IDLabel.Name = "Empresa_IDLabel";
            this.Empresa_IDLabel.Size = new System.Drawing.Size(79, 15);
            this.Empresa_IDLabel.TabIndex = 22;
            this.Empresa_IDLabel.Text = "Empresa_ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Empresa_IDComboBox);
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ConsultarButton);
            this.groupBox1.Controls.Add(this.Empresa_IDLabel);
            this.groupBox1.Controls.Add(this.FechaTerminacionFinalDateTimePicker);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDComboBox);
            this.groupBox1.Controls.Add(this.FechaTerminacionInicialDateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(13, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 93);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de búsqueda";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(831, 33);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(75, 42);
            this.ExportarButton.TabIndex = 33;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(748, 33);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(75, 42);
            this.ConsultarButton.TabIndex = 32;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OrdenTrabajoCheckBox);
            this.groupBox2.Controls.Add(this.TipoMantenimientoCheckBox);
            this.groupBox2.Controls.Add(this.UnidadCheckBox);
            this.groupBox2.Controls.Add(this.EmpresaCheckBox);
            this.groupBox2.Controls.Add(this.FechaCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(917, 65);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agrupar por";
            // 
            // OrdenTrabajoCheckBox
            // 
            this.OrdenTrabajoCheckBox.AutoSize = true;
            this.OrdenTrabajoCheckBox.Checked = true;
            this.OrdenTrabajoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OrdenTrabajoCheckBox.Location = new System.Drawing.Point(420, 27);
            this.OrdenTrabajoCheckBox.Name = "OrdenTrabajoCheckBox";
            this.OrdenTrabajoCheckBox.Size = new System.Drawing.Size(105, 17);
            this.OrdenTrabajoCheckBox.TabIndex = 4;
            this.OrdenTrabajoCheckBox.Text = "Orden de trabajo";
            this.OrdenTrabajoCheckBox.UseVisualStyleBackColor = true;
            // 
            // TipoMantenimientoCheckBox
            // 
            this.TipoMantenimientoCheckBox.AutoSize = true;
            this.TipoMantenimientoCheckBox.Checked = true;
            this.TipoMantenimientoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TipoMantenimientoCheckBox.Location = new System.Drawing.Point(252, 27);
            this.TipoMantenimientoCheckBox.Name = "TipoMantenimientoCheckBox";
            this.TipoMantenimientoCheckBox.Size = new System.Drawing.Size(134, 17);
            this.TipoMantenimientoCheckBox.TabIndex = 3;
            this.TipoMantenimientoCheckBox.Text = "Tipo de Mantenimiento";
            this.TipoMantenimientoCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnidadCheckBox
            // 
            this.UnidadCheckBox.AutoSize = true;
            this.UnidadCheckBox.Checked = true;
            this.UnidadCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnidadCheckBox.Location = new System.Drawing.Point(175, 27);
            this.UnidadCheckBox.Name = "UnidadCheckBox";
            this.UnidadCheckBox.Size = new System.Drawing.Size(60, 17);
            this.UnidadCheckBox.TabIndex = 2;
            this.UnidadCheckBox.Text = "Unidad";
            this.UnidadCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmpresaCheckBox
            // 
            this.EmpresaCheckBox.AutoSize = true;
            this.EmpresaCheckBox.Checked = true;
            this.EmpresaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EmpresaCheckBox.Location = new System.Drawing.Point(91, 27);
            this.EmpresaCheckBox.Name = "EmpresaCheckBox";
            this.EmpresaCheckBox.Size = new System.Drawing.Size(67, 17);
            this.EmpresaCheckBox.TabIndex = 1;
            this.EmpresaCheckBox.Text = "Empresa";
            this.EmpresaCheckBox.UseVisualStyleBackColor = true;
            // 
            // FechaCheckBox
            // 
            this.FechaCheckBox.AutoSize = true;
            this.FechaCheckBox.Checked = true;
            this.FechaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FechaCheckBox.Location = new System.Drawing.Point(16, 27);
            this.FechaCheckBox.Name = "FechaCheckBox";
            this.FechaCheckBox.Size = new System.Drawing.Size(56, 17);
            this.FechaCheckBox.TabIndex = 0;
            this.FechaCheckBox.Text = "Fecha";
            this.FechaCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReporteVentasDataGridView);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(952, 627);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reporte de Ventas";
            // 
            // ReporteVentasDataGridView
            // 
            this.ReporteVentasDataGridView.AllowUserToAddRows = false;
            this.ReporteVentasDataGridView.AllowUserToDeleteRows = false;
            this.ReporteVentasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReporteVentasDataGridView.Location = new System.Drawing.Point(13, 201);
            this.ReporteVentasDataGridView.Name = "ReporteVentasDataGridView";
            this.ReporteVentasDataGridView.ReadOnly = true;
            this.ReporteVentasDataGridView.Size = new System.Drawing.Size(917, 406);
            this.ReporteVentasDataGridView.TabIndex = 34;
            // 
            // ReporteDeVentasTaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox3);
            this.Name = "ReporteDeVentasTaller";
            this.Text = "ReporteDeVentas";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposMantenimientosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteVentasDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.DateTimePicker FechaTerminacionFinalDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource selectTiposMantenimientosBindingSource;
        private System.Windows.Forms.DateTimePicker FechaTerminacionInicialDateTimePicker;
        private System.Windows.Forms.ComboBox TipoMantenimiento_IDComboBox;
        private System.Windows.Forms.Label TipoMantenimiento_IDLabel;
        private System.Windows.Forms.ComboBox Empresa_IDComboBox;
        private System.Windows.Forms.Label Empresa_IDLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox OrdenTrabajoCheckBox;
        private System.Windows.Forms.CheckBox TipoMantenimientoCheckBox;
        private System.Windows.Forms.CheckBox UnidadCheckBox;
        private System.Windows.Forms.CheckBox EmpresaCheckBox;
        private System.Windows.Forms.CheckBox FechaCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView ReporteVentasDataGridView;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.SaveFileDialog ExportarSaveFileDialog;
    }
}