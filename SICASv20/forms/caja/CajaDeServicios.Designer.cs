namespace SICASv20.forms
{
    partial class CajaDeServicios
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
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalServiciosTextBox = new System.Windows.Forms.TextBox();
            this.ServiciosPendientesGridView = new System.Windows.Forms.DataGridView();
            this.serviciosPendientesConductorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.NombreConductorTextBox = new System.Windows.Forms.TextBox();
            this.UnidadTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaPagoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoConductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Location = new System.Drawing.Point(855, 567);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(116, 33);
            this.SiguienteButton.TabIndex = 19;
            this.SiguienteButton.Text = "Siguiente >>";
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(726, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total servicios:";
            // 
            // TotalServiciosTextBox
            // 
            this.TotalServiciosTextBox.BackColor = System.Drawing.Color.White;
            this.TotalServiciosTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalServiciosTextBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalServiciosTextBox.Location = new System.Drawing.Point(855, 538);
            this.TotalServiciosTextBox.Name = "TotalServiciosTextBox";
            this.TotalServiciosTextBox.ReadOnly = true;
            this.TotalServiciosTextBox.Size = new System.Drawing.Size(116, 23);
            this.TotalServiciosTextBox.TabIndex = 17;
            this.TotalServiciosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.ServiciosPendientesGridView.Location = new System.Drawing.Point(29, 121);
            this.ServiciosPendientesGridView.Name = "ServiciosPendientesGridView";
            this.ServiciosPendientesGridView.ReadOnly = true;
            this.ServiciosPendientesGridView.Size = new System.Drawing.Size(942, 411);
            this.ServiciosPendientesGridView.TabIndex = 16;
            this.ServiciosPendientesGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ServiciosPendientesGridView_KeyUp);
            // 
            // serviciosPendientesConductorBindingSource
            // 
            this.serviciosPendientesConductorBindingSource.DataSource = typeof(SICASv20.Entities.ServiciosPendientesConductor);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(26, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Conductor:";
            // 
            // NombreConductorTextBox
            // 
            this.NombreConductorTextBox.BackColor = System.Drawing.Color.White;
            this.NombreConductorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreConductorTextBox.Location = new System.Drawing.Point(137, 75);
            this.NombreConductorTextBox.Name = "NombreConductorTextBox";
            this.NombreConductorTextBox.ReadOnly = true;
            this.NombreConductorTextBox.Size = new System.Drawing.Size(357, 22);
            this.NombreConductorTextBox.TabIndex = 14;
            // 
            // UnidadTextBox
            // 
            this.UnidadTextBox.BackColor = System.Drawing.Color.White;
            this.UnidadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnidadTextBox.Location = new System.Drawing.Point(137, 46);
            this.UnidadTextBox.Name = "UnidadTextBox";
            this.UnidadTextBox.Size = new System.Drawing.Size(116, 22);
            this.UnidadTextBox.TabIndex = 13;
            this.UnidadTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UnidadTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Unidad:";
            // 
            // FechaPagoDateTimePicker
            // 
            this.FechaPagoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaPagoDateTimePicker.Location = new System.Drawing.Point(137, 17);
            this.FechaPagoDateTimePicker.Name = "FechaPagoDateTimePicker";
            this.FechaPagoDateTimePicker.Size = new System.Drawing.Size(116, 22);
            this.FechaPagoDateTimePicker.TabIndex = 11;
            this.FechaPagoDateTimePicker.ValueChanged += new System.EventHandler(this.FechaPagoDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha a pagar:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Servicio_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Servicio_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Empresa_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Empresa_ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cuenta_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cuenta_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PagoConductor";
            this.dataGridViewTextBoxColumn5.HeaderText = "PagoConductor";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Destino";
            this.dataGridViewTextBoxColumn6.HeaderText = "Destino";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "c";
            this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pagoConductorDataGridViewTextBoxColumn
            // 
            this.pagoConductorDataGridViewTextBoxColumn.DataPropertyName = "PagoConductor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "c";
            this.pagoConductorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            // CajaDeServicios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TotalServiciosTextBox);
            this.Controls.Add(this.ServiciosPendientesGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NombreConductorTextBox);
            this.Controls.Add(this.UnidadTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaPagoDateTimePicker);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CajaDeServicios";
            this.Text = "CajaDeServicios";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.FechaPagoDateTimePicker, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.UnidadTextBox, 0);
            this.Controls.SetChildIndex(this.NombreConductorTextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ServiciosPendientesGridView, 0);
            this.Controls.SetChildIndex(this.TotalServiciosTextBox, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.SiguienteButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosPendientesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosPendientesConductorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TotalServiciosTextBox;
        private System.Windows.Forms.DataGridView ServiciosPendientesGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NombreConductorTextBox;
        private System.Windows.Forms.TextBox UnidadTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaPagoDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource serviciosPendientesConductorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicioIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagoConductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoDataGridViewTextBoxColumn;


    }
}