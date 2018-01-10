namespace SICASv20.forms
{
    partial class ServiciosMantenimientosPrecios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ActualizarButton = new System.Windows.Forms.Button();
            this.ServiciosMantenimientosPreciosDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_PreciosServicioMantenimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.servicioMantenimientoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoClienteTaller_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosMantenimientosPreciosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServicioMantenimientoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ActualizarButton);
            this.groupBox1.Controls.Add(this.ServiciosMantenimientosPreciosDataGridView);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Precios de Servicios Mantenimientos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precios";
            // 
            // ActualizarButton
            // 
            this.ActualizarButton.Location = new System.Drawing.Point(469, 337);
            this.ActualizarButton.Name = "ActualizarButton";
            this.ActualizarButton.Size = new System.Drawing.Size(99, 34);
            this.ActualizarButton.TabIndex = 3;
            this.ActualizarButton.Text = "Actualizar";
            this.ActualizarButton.UseVisualStyleBackColor = true;
            this.ActualizarButton.Click += new System.EventHandler(this.ActualizarButton_Click);
            // 
            // ServiciosMantenimientosPreciosDataGridView
            // 
            this.ServiciosMantenimientosPreciosDataGridView.AllowUserToAddRows = false;
            this.ServiciosMantenimientosPreciosDataGridView.AllowUserToDeleteRows = false;
            this.ServiciosMantenimientosPreciosDataGridView.AutoGenerateColumns = false;
            this.ServiciosMantenimientosPreciosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosMantenimientosPreciosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servicioMantenimientoIDDataGridViewTextBoxColumn,
            this.TipoClienteTaller_ID,
            this.Cliente,
            this.precioDataGridViewTextBoxColumn});
            this.ServiciosMantenimientosPreciosDataGridView.DataSource = this.vista_PreciosServicioMantenimientoBindingSource;
            this.ServiciosMantenimientosPreciosDataGridView.Location = new System.Drawing.Point(20, 91);
            this.ServiciosMantenimientosPreciosDataGridView.Name = "ServiciosMantenimientosPreciosDataGridView";
            this.ServiciosMantenimientosPreciosDataGridView.Size = new System.Drawing.Size(548, 229);
            this.ServiciosMantenimientosPreciosDataGridView.TabIndex = 2;
            // 
            // vista_PreciosServicioMantenimientoBindingSource
            // 
            this.vista_PreciosServicioMantenimientoBindingSource.DataSource = typeof(SICASv20.Entities.Vista_PreciosServicioMantenimiento);
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(162, 38);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(406, 21);
            this.NombreTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicio Mantenimiento:";
            // 
            // servicioMantenimientoIDDataGridViewTextBoxColumn
            // 
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.DataPropertyName = "ServicioMantenimiento_ID";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.HeaderText = "ServicioMantenimiento_ID";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.Name = "servicioMantenimientoIDDataGridViewTextBoxColumn";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // TipoClienteTaller_ID
            // 
            this.TipoClienteTaller_ID.DataPropertyName = "TipoClienteTaller_ID";
            this.TipoClienteTaller_ID.HeaderText = "TipoClienteTaller_ID";
            this.TipoClienteTaller_ID.Name = "TipoClienteTaller_ID";
            this.TipoClienteTaller_ID.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            // 
            // ServiciosMantenimientosPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServiciosMantenimientosPrecios";
            this.Text = "ServiciosMantenimientosPrecios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosMantenimientosPreciosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_PreciosServicioMantenimientoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ActualizarButton;
        private System.Windows.Forms.DataGridView ServiciosMantenimientosPreciosDataGridView;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource vista_PreciosServicioMantenimientoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicioMantenimientoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoClienteTaller_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
    }
}