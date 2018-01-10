namespace SICASv20.forms
{
    partial class ReportePreciosServiciosMantenimientos
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TiposEmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.tiposClientesTallerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExportarButton = new System.Windows.Forms.Button();
            this.vista_PreciosServiciosTiposEmpresasDataGridView = new System.Windows.Forms.DataGridView();
            this.tipoClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposClientesTallerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServiciosTiposEmpresasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de precios de servicios";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.TiposEmpresasComboBox);
            this.flowLayoutPanel1.Controls.Add(this.ExportarButton);
            this.flowLayoutPanel1.Controls.Add(this.vista_PreciosServiciosTiposEmpresasDataGridView);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 601);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un tipo de cliente";
            // 
            // TiposEmpresasComboBox
            // 
            this.TiposEmpresasComboBox.DataSource = this.tiposClientesTallerBindingSource;
            this.TiposEmpresasComboBox.DisplayMember = "Nombre";
            this.TiposEmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiposEmpresasComboBox.FormattingEnabled = true;
            this.TiposEmpresasComboBox.Location = new System.Drawing.Point(5, 30);
            this.TiposEmpresasComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.TiposEmpresasComboBox.Name = "TiposEmpresasComboBox";
            this.TiposEmpresasComboBox.Size = new System.Drawing.Size(200, 23);
            this.TiposEmpresasComboBox.TabIndex = 1;
            this.TiposEmpresasComboBox.ValueMember = "TipoClienteTaller_ID";
            this.TiposEmpresasComboBox.SelectionChangeCommitted += new System.EventHandler(this.TiposEmpresasComboBox_SelectionChangeCommitted);
            // 
            // tiposClientesTallerBindingSource
            // 
            this.tiposClientesTallerBindingSource.DataSource = typeof(SICASv20.Entities.TiposClientesTaller);
            // 
            // ExportarButton
            // 
            this.ExportarButton.Location = new System.Drawing.Point(3, 61);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(154, 29);
            this.ExportarButton.TabIndex = 24;
            this.ExportarButton.Text = "Exportar a MS Excel";
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // vista_PreciosServiciosTiposEmpresasDataGridView
            // 
            this.vista_PreciosServiciosTiposEmpresasDataGridView.AllowUserToAddRows = false;
            this.vista_PreciosServiciosTiposEmpresasDataGridView.AutoGenerateColumns = false;
            this.vista_PreciosServiciosTiposEmpresasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_PreciosServiciosTiposEmpresasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoClienteDataGridViewTextBoxColumn,
            this.servicioDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn});
            this.vista_PreciosServiciosTiposEmpresasDataGridView.DataSource = this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource;
            this.vista_PreciosServiciosTiposEmpresasDataGridView.Location = new System.Drawing.Point(5, 98);
            this.vista_PreciosServiciosTiposEmpresasDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.vista_PreciosServiciosTiposEmpresasDataGridView.Name = "vista_PreciosServiciosTiposEmpresasDataGridView";
            this.vista_PreciosServiciosTiposEmpresasDataGridView.Size = new System.Drawing.Size(958, 464);
            this.vista_PreciosServiciosTiposEmpresasDataGridView.TabIndex = 2;
            // 
            // tipoClienteDataGridViewTextBoxColumn
            // 
            this.tipoClienteDataGridViewTextBoxColumn.DataPropertyName = "TipoCliente";
            this.tipoClienteDataGridViewTextBoxColumn.HeaderText = "TipoCliente";
            this.tipoClienteDataGridViewTextBoxColumn.Name = "tipoClienteDataGridViewTextBoxColumn";
            // 
            // servicioDataGridViewTextBoxColumn
            // 
            this.servicioDataGridViewTextBoxColumn.DataPropertyName = "Servicio";
            this.servicioDataGridViewTextBoxColumn.HeaderText = "Servicio";
            this.servicioDataGridViewTextBoxColumn.Name = "servicioDataGridViewTextBoxColumn";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            // 
            // vista_PreciosServicioMantenimiento_TiposClientesBindingSource
            // 
            this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_PreciosServicioMantenimiento_TiposClientes);
            // 
            // ReportePreciosServiciosMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportePreciosServiciosMantenimientos";
            this.Text = "ReportePreciosServiciosMantenimientos";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposClientesTallerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServiciosTiposEmpresasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServicioMantenimiento_TiposClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TiposEmpresasComboBox;
        private System.Windows.Forms.DataGridView vista_PreciosServiciosTiposEmpresasDataGridView;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.BindingSource tiposClientesTallerBindingSource;
        private System.Windows.Forms.BindingSource vista_PreciosServicioMantenimiento_TiposClientesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
    }
}