namespace SICASv20.forms
{
    partial class AsignacionServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServiciosPendientesGridView = new System.Windows.Forms.DataGridView();
            this.servicioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoConductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviciosPendientesConductorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductividadTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Servicio_IDTextBox = new System.Windows.Forms.TextBox();
            this.KilometrajeAnteriorTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServiciosPendientesGridView);
            this.groupBox1.Controls.Add(this.ProductividadTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Servicio_IDTextBox);
            this.groupBox1.Controls.Add(this.KilometrajeAnteriorTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignación de servicios";
            // 
            // ServiciosPendientesGridView
            // 
            this.ServiciosPendientesGridView.AllowUserToAddRows = false;
            this.ServiciosPendientesGridView.AllowUserToDeleteRows = false;
            this.ServiciosPendientesGridView.AutoGenerateColumns = false;
            this.ServiciosPendientesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosPendientesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.servicioIDDataGridViewTextBoxColumn,
            this.empresaIDDataGridViewTextBoxColumn,
            this.cuentaIDDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.pagoConductorDataGridViewTextBoxColumn,
            this.destinoDataGridViewTextBoxColumn});
            this.ServiciosPendientesGridView.DataSource = this.serviciosPendientesConductorBindingSource;
            this.ServiciosPendientesGridView.Location = new System.Drawing.Point(29, 169);
            this.ServiciosPendientesGridView.Name = "ServiciosPendientesGridView";
            this.ServiciosPendientesGridView.ReadOnly = true;
            this.ServiciosPendientesGridView.Size = new System.Drawing.Size(942, 442);
            this.ServiciosPendientesGridView.TabIndex = 21;
            // 
            // servicioIDDataGridViewTextBoxColumn
            // 
            this.servicioIDDataGridViewTextBoxColumn.DataPropertyName = "Servicio_ID";
            this.servicioIDDataGridViewTextBoxColumn.HeaderText = "Servicio_ID";
            this.servicioIDDataGridViewTextBoxColumn.Name = "servicioIDDataGridViewTextBoxColumn";
            this.servicioIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empresaIDDataGridViewTextBoxColumn
            // 
            this.empresaIDDataGridViewTextBoxColumn.DataPropertyName = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.HeaderText = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.Name = "empresaIDDataGridViewTextBoxColumn";
            this.empresaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.empresaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cuentaIDDataGridViewTextBoxColumn
            // 
            this.cuentaIDDataGridViewTextBoxColumn.DataPropertyName = "Cuenta_ID";
            this.cuentaIDDataGridViewTextBoxColumn.HeaderText = "Cuenta_ID";
            this.cuentaIDDataGridViewTextBoxColumn.Name = "cuentaIDDataGridViewTextBoxColumn";
            this.cuentaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "c";
            this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pagoConductorDataGridViewTextBoxColumn
            // 
            this.pagoConductorDataGridViewTextBoxColumn.DataPropertyName = "PagoConductor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "c";
            this.pagoConductorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.pagoConductorDataGridViewTextBoxColumn.HeaderText = "PagoConductor";
            this.pagoConductorDataGridViewTextBoxColumn.Name = "pagoConductorDataGridViewTextBoxColumn";
            this.pagoConductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destinoDataGridViewTextBoxColumn
            // 
            this.destinoDataGridViewTextBoxColumn.DataPropertyName = "Destino";
            this.destinoDataGridViewTextBoxColumn.HeaderText = "Destino";
            this.destinoDataGridViewTextBoxColumn.Name = "destinoDataGridViewTextBoxColumn";
            this.destinoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviciosPendientesConductorBindingSource
            // 
            this.serviciosPendientesConductorBindingSource.DataSource = typeof(SICASv20.Entities.ServiciosPendientesConductor);
            // 
            // ProductividadTextBox
            // 
            this.ProductividadTextBox.Location = new System.Drawing.Point(155, 88);
            this.ProductividadTextBox.Name = "ProductividadTextBox";
            this.ProductividadTextBox.ReadOnly = true;
            this.ProductividadTextBox.Size = new System.Drawing.Size(100, 21);
            this.ProductividadTextBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Productividad:";
            // 
            // Servicio_IDTextBox
            // 
            this.Servicio_IDTextBox.Location = new System.Drawing.Point(155, 142);
            this.Servicio_IDTextBox.MaxLength = 21;
            this.Servicio_IDTextBox.Name = "Servicio_IDTextBox";
            this.Servicio_IDTextBox.Size = new System.Drawing.Size(241, 21);
            this.Servicio_IDTextBox.TabIndex = 17;
            this.Servicio_IDTextBox.TextChanged += new System.EventHandler(this.Servicio_IDTextBox_TextChanged);
            this.Servicio_IDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Servicio_IDTextBox_KeyPress);
            this.Servicio_IDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Servicio_IDTextBox_KeyUp);
            // 
            // KilometrajeAnteriorTextBox
            // 
            this.KilometrajeAnteriorTextBox.Location = new System.Drawing.Point(155, 115);
            this.KilometrajeAnteriorTextBox.Name = "KilometrajeAnteriorTextBox";
            this.KilometrajeAnteriorTextBox.ReadOnly = true;
            this.KilometrajeAnteriorTextBox.Size = new System.Drawing.Size(100, 21);
            this.KilometrajeAnteriorTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Servicio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Kilometraje anterior:";
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.BackColor = System.Drawing.Color.White;
            this.ConductorTextBox.Location = new System.Drawing.Point(155, 61);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.ReadOnly = true;
            this.ConductorTextBox.Size = new System.Drawing.Size(241, 21);
            this.ConductorTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Conductor:";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(155, 34);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(87, 21);
            this.NumeroEconomicoTextBox.TabIndex = 9;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Unidad:";
            // 
            // AsignacionServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AsignacionServicios";
            this.Text = "AsignacionServicios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ProductividadTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Servicio_IDTextBox;
        private System.Windows.Forms.TextBox KilometrajeAnteriorTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ServiciosPendientesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicioIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagoConductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource serviciosPendientesConductorBindingSource;
    }
}