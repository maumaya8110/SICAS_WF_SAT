namespace SICASv20.forms
{
    partial class ServiciosConductoresDeSesion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vista_ServiciosDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vista_ServiciosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 461);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Servicios Especiales";
            // 
            // vista_ServiciosDataGridView
            // 
            this.vista_ServiciosDataGridView.AllowUserToAddRows = false;
            this.vista_ServiciosDataGridView.AllowUserToDeleteRows = false;
            this.vista_ServiciosDataGridView.AutoGenerateColumns = false;
            this.vista_ServiciosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ServiciosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.HoraCol,
            this.dataGridViewTextBoxColumn15});
            this.vista_ServiciosDataGridView.DataSource = this.vista_ServiciosBindingSource;
            this.vista_ServiciosDataGridView.Location = new System.Drawing.Point(11, 30);
            this.vista_ServiciosDataGridView.Margin = new System.Windows.Forms.Padding(8);
            this.vista_ServiciosDataGridView.Name = "vista_ServiciosDataGridView";
            this.vista_ServiciosDataGridView.ReadOnly = true;
            this.vista_ServiciosDataGridView.Size = new System.Drawing.Size(1008, 420);
            this.vista_ServiciosDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Servicio_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Servicio_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Zona";
            this.dataGridViewTextBoxColumn7.HeaderText = "Destino";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TipoServicio";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn21.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn22.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // HoraCol
            // 
            this.HoraCol.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.HoraCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HoraCol.HeaderText = "Hora";
            this.HoraCol.Name = "HoraCol";
            this.HoraCol.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Usuario_ID";
            this.dataGridViewTextBoxColumn15.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // vista_ServiciosBindingSource
            // 
            this.vista_ServiciosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Servicios);
            // 
            // ServiciosConductoresDeSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 486);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServiciosConductoresDeSesion";
            this.Text = "Detalle de Servicios Especiales";
            this.Load += new System.EventHandler(this.ServiciosConductoresDeSesion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_ServiciosDataGridView;
        private System.Windows.Forms.BindingSource vista_ServiciosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}