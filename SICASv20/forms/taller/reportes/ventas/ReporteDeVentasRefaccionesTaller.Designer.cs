namespace SICASv20.forms
{
    partial class ReporteDeVentasRefaccionesTaller
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
            this.selectTiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FechaTerminacionFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.selectServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FechaTerminacionInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TipoRefaccion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.TipoMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.Familia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectFamiliasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Empresa_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServicioMantenimiento_IDComboBox = new System.Windows.Forms.ComboBox();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RefaccionCheckBox = new System.Windows.Forms.CheckBox();
            this.ServicioMantenimientoCheckBox = new System.Windows.Forms.CheckBox();
            this.TipoRefaccionCheckBox = new System.Windows.Forms.CheckBox();
            this.FamiliaCheckBox = new System.Windows.Forms.CheckBox();
            this.FechaCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReporteVentasDataGridView = new System.Windows.Forms.DataGridView();
            this.ExportarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectServiciosMantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).BeginInit();
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
            // selectTiposRefaccionesBindingSource
            // 
            this.selectTiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposRefacciones);
            // 
            // FechaTerminacionFinalDateTimePicker
            // 
            this.FechaTerminacionFinalDateTimePicker.Checked = false;
            this.FechaTerminacionFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionFinalDateTimePicker.Location = new System.Drawing.Point(596, 60);
            this.FechaTerminacionFinalDateTimePicker.Name = "FechaTerminacionFinalDateTimePicker";
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
            // selectServiciosMantenimientosBindingSource
            // 
            this.selectServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.SelectServiciosMantenimientos);
            // 
            // FechaTerminacionInicialDateTimePicker
            // 
            this.FechaTerminacionInicialDateTimePicker.Checked = false;
            this.FechaTerminacionInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaTerminacionInicialDateTimePicker.Location = new System.Drawing.Point(596, 33);
            this.FechaTerminacionInicialDateTimePicker.Name = "FechaTerminacionInicialDateTimePicker";
            this.FechaTerminacionInicialDateTimePicker.Size = new System.Drawing.Size(129, 21);
            this.FechaTerminacionInicialDateTimePicker.TabIndex = 26;
            // 
            // TipoRefaccion_IDComboBox
            // 
            this.TipoRefaccion_IDComboBox.DataSource = this.selectTiposRefaccionesBindingSource;
            this.TipoRefaccion_IDComboBox.DisplayMember = "Nombre";
            this.TipoRefaccion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoRefaccion_IDComboBox.FormattingEnabled = true;
            this.TipoRefaccion_IDComboBox.Location = new System.Drawing.Point(175, 54);
            this.TipoRefaccion_IDComboBox.Name = "TipoRefaccion_IDComboBox";
            this.TipoRefaccion_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.TipoRefaccion_IDComboBox.TabIndex = 25;
            this.TipoRefaccion_IDComboBox.ValueMember = "TipoRefaccion_ID";
            // 
            // TipoMantenimiento_IDLabel
            // 
            this.TipoMantenimiento_IDLabel.AutoSize = true;
            this.TipoMantenimiento_IDLabel.Location = new System.Drawing.Point(13, 57);
            this.TipoMantenimiento_IDLabel.Name = "TipoMantenimiento_IDLabel";
            this.TipoMantenimiento_IDLabel.Size = new System.Drawing.Size(87, 15);
            this.TipoMantenimiento_IDLabel.TabIndex = 24;
            this.TipoMantenimiento_IDLabel.Text = "Tipo refaccion:";
            // 
            // Familia_IDComboBox
            // 
            this.Familia_IDComboBox.DataSource = this.selectFamiliasBindingSource;
            this.Familia_IDComboBox.DisplayMember = "Nombre";
            this.Familia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Familia_IDComboBox.FormattingEnabled = true;
            this.Familia_IDComboBox.Location = new System.Drawing.Point(175, 27);
            this.Familia_IDComboBox.Name = "Familia_IDComboBox";
            this.Familia_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Familia_IDComboBox.TabIndex = 23;
            this.Familia_IDComboBox.ValueMember = "Familia_ID";
            // 
            // selectFamiliasBindingSource
            // 
            this.selectFamiliasBindingSource.DataSource = typeof(SICASv20.Entities.SelectFamilias);
            // 
            // Empresa_IDLabel
            // 
            this.Empresa_IDLabel.AutoSize = true;
            this.Empresa_IDLabel.Location = new System.Drawing.Point(13, 30);
            this.Empresa_IDLabel.Name = "Empresa_IDLabel";
            this.Empresa_IDLabel.Size = new System.Drawing.Size(51, 15);
            this.Empresa_IDLabel.TabIndex = 22;
            this.Empresa_IDLabel.Text = "Familia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ServicioMantenimiento_IDComboBox);
            this.groupBox1.Controls.Add(this.Familia_IDComboBox);
            this.groupBox1.Controls.Add(this.ExportarButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ConsultarButton);
            this.groupBox1.Controls.Add(this.Empresa_IDLabel);
            this.groupBox1.Controls.Add(this.FechaTerminacionFinalDateTimePicker);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TipoRefaccion_IDComboBox);
            this.groupBox1.Controls.Add(this.FechaTerminacionInicialDateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(13, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 115);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de búsqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "Servicio mantenimiento:";
            // 
            // ServicioMantenimiento_IDComboBox
            // 
            this.ServicioMantenimiento_IDComboBox.DataSource = this.selectServiciosMantenimientosBindingSource;
            this.ServicioMantenimiento_IDComboBox.DisplayMember = "Nombre";
            this.ServicioMantenimiento_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServicioMantenimiento_IDComboBox.FormattingEnabled = true;
            this.ServicioMantenimiento_IDComboBox.Location = new System.Drawing.Point(175, 83);
            this.ServicioMantenimiento_IDComboBox.Name = "ServicioMantenimiento_IDComboBox";
            this.ServicioMantenimiento_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.ServicioMantenimiento_IDComboBox.TabIndex = 35;
            this.ServicioMantenimiento_IDComboBox.ValueMember = "ServicioMantenimiento_ID";
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
            this.groupBox2.Controls.Add(this.RefaccionCheckBox);
            this.groupBox2.Controls.Add(this.ServicioMantenimientoCheckBox);
            this.groupBox2.Controls.Add(this.TipoRefaccionCheckBox);
            this.groupBox2.Controls.Add(this.FamiliaCheckBox);
            this.groupBox2.Controls.Add(this.FechaCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(917, 65);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agrupar por";
            // 
            // RefaccionCheckBox
            // 
            this.RefaccionCheckBox.AutoSize = true;
            this.RefaccionCheckBox.Checked = true;
            this.RefaccionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RefaccionCheckBox.Location = new System.Drawing.Point(481, 27);
            this.RefaccionCheckBox.Name = "RefaccionCheckBox";
            this.RefaccionCheckBox.Size = new System.Drawing.Size(75, 17);
            this.RefaccionCheckBox.TabIndex = 4;
            this.RefaccionCheckBox.Text = "Refaccion";
            this.RefaccionCheckBox.UseVisualStyleBackColor = true;
            // 
            // ServicioMantenimientoCheckBox
            // 
            this.ServicioMantenimientoCheckBox.AutoSize = true;
            this.ServicioMantenimientoCheckBox.Checked = true;
            this.ServicioMantenimientoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ServicioMantenimientoCheckBox.Location = new System.Drawing.Point(303, 27);
            this.ServicioMantenimientoCheckBox.Name = "ServicioMantenimientoCheckBox";
            this.ServicioMantenimientoCheckBox.Size = new System.Drawing.Size(150, 17);
            this.ServicioMantenimientoCheckBox.TabIndex = 3;
            this.ServicioMantenimientoCheckBox.Text = "Servicio de mantenimiento";
            this.ServicioMantenimientoCheckBox.UseVisualStyleBackColor = true;
            // 
            // TipoRefaccionCheckBox
            // 
            this.TipoRefaccionCheckBox.AutoSize = true;
            this.TipoRefaccionCheckBox.Checked = true;
            this.TipoRefaccionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TipoRefaccionCheckBox.Location = new System.Drawing.Point(175, 27);
            this.TipoRefaccionCheckBox.Name = "TipoRefaccionCheckBox";
            this.TipoRefaccionCheckBox.Size = new System.Drawing.Size(109, 17);
            this.TipoRefaccionCheckBox.TabIndex = 2;
            this.TipoRefaccionCheckBox.Text = "Tipo de refaccion";
            this.TipoRefaccionCheckBox.UseVisualStyleBackColor = true;
            // 
            // FamiliaCheckBox
            // 
            this.FamiliaCheckBox.AutoSize = true;
            this.FamiliaCheckBox.Checked = true;
            this.FamiliaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FamiliaCheckBox.Location = new System.Drawing.Point(91, 27);
            this.FamiliaCheckBox.Name = "FamiliaCheckBox";
            this.FamiliaCheckBox.Size = new System.Drawing.Size(58, 17);
            this.FamiliaCheckBox.TabIndex = 1;
            this.FamiliaCheckBox.Text = "Familia";
            this.FamiliaCheckBox.UseVisualStyleBackColor = true;
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
            this.groupBox3.Text = "Reporte de Ventas de Refacciones";
            // 
            // ReporteVentasDataGridView
            // 
            this.ReporteVentasDataGridView.AllowUserToAddRows = false;
            this.ReporteVentasDataGridView.AllowUserToDeleteRows = false;
            this.ReporteVentasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReporteVentasDataGridView.Location = new System.Drawing.Point(13, 223);
            this.ReporteVentasDataGridView.Name = "ReporteVentasDataGridView";
            this.ReporteVentasDataGridView.ReadOnly = true;
            this.ReporteVentasDataGridView.Size = new System.Drawing.Size(917, 384);
            this.ReporteVentasDataGridView.TabIndex = 34;
            // 
            // ReporteDeVentasRefaccionesTaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox3);
            this.Name = "ReporteDeVentasRefaccionesTaller";
            this.Text = "ReporteDeVentas";
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectServiciosMantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectFamiliasBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource selectTiposRefaccionesBindingSource;
        private System.Windows.Forms.DateTimePicker FechaTerminacionFinalDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource selectServiciosMantenimientosBindingSource;
        private System.Windows.Forms.DateTimePicker FechaTerminacionInicialDateTimePicker;
        private System.Windows.Forms.ComboBox TipoRefaccion_IDComboBox;
        private System.Windows.Forms.Label TipoMantenimiento_IDLabel;
        private System.Windows.Forms.ComboBox Familia_IDComboBox;
        private System.Windows.Forms.Label Empresa_IDLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ServicioMantenimientoCheckBox;
        private System.Windows.Forms.CheckBox TipoRefaccionCheckBox;
        private System.Windows.Forms.CheckBox FamiliaCheckBox;
        private System.Windows.Forms.CheckBox FechaCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView ReporteVentasDataGridView;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.SaveFileDialog ExportarSaveFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServicioMantenimiento_IDComboBox;
        private System.Windows.Forms.BindingSource selectFamiliasBindingSource;
        private System.Windows.Forms.CheckBox RefaccionCheckBox;
    }
}