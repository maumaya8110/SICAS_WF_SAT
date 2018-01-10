namespace SICASv20.forms
{
    partial class BuscarServicios
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
            this.BuscarButton = new System.Windows.Forms.Button();
            this.ServiciosDisponiblesDataGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.servicioMantenimientoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ServicioTextBox = new System.Windows.Forms.TextBox();
            this.ServicioRefaccionesRadioButton = new System.Windows.Forms.RadioButton();
            this.SoloServicioRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosDisponiblesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SICASv20.Properties.Resources.search;
            this.BuscarButton.Location = new System.Drawing.Point(569, 12);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(86, 29);
            this.BuscarButton.TabIndex = 21;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // ServiciosDisponiblesDataGridView
            // 
            this.ServiciosDisponiblesDataGridView.AllowUserToAddRows = false;
            this.ServiciosDisponiblesDataGridView.AllowUserToDeleteRows = false;
            this.ServiciosDisponiblesDataGridView.AutoGenerateColumns = false;
            this.ServiciosDisponiblesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosDisponiblesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.servicioMantenimientoIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.familiaDataGridViewTextBoxColumn,
            this.modeloDataGridViewTextBoxColumn,
            this.costoDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn});
            this.ServiciosDisponiblesDataGridView.DataSource = this.vista_ServiciosMantenimientosBindingSource;
            this.ServiciosDisponiblesDataGridView.Location = new System.Drawing.Point(22, 88);
            this.ServiciosDisponiblesDataGridView.Name = "ServiciosDisponiblesDataGridView";
            this.ServiciosDisponiblesDataGridView.ReadOnly = true;
            this.ServiciosDisponiblesDataGridView.Size = new System.Drawing.Size(644, 194);
            this.ServiciosDisponiblesDataGridView.TabIndex = 20;
            this.ServiciosDisponiblesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiciosDisponiblesDataGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // servicioMantenimientoIDDataGridViewTextBoxColumn
            // 
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.DataPropertyName = "ServicioMantenimiento_ID";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.HeaderText = "ServicioMantenimiento_ID";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.Name = "servicioMantenimientoIDDataGridViewTextBoxColumn";
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.servicioMantenimientoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // familiaDataGridViewTextBoxColumn
            // 
            this.familiaDataGridViewTextBoxColumn.DataPropertyName = "Familia";
            this.familiaDataGridViewTextBoxColumn.HeaderText = "Familia";
            this.familiaDataGridViewTextBoxColumn.Name = "familiaDataGridViewTextBoxColumn";
            this.familiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            this.modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            this.modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            this.modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            this.modeloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            this.costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            this.costoDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            this.costoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Format = "N2";
            this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            dataGridViewCellStyle2.Format = "N2";
            this.tipoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vista_ServiciosMantenimientosBindingSource
            // 
            this.vista_ServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosMantenimientos);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Servicio:";
            // 
            // ServicioTextBox
            // 
            this.ServicioTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ServicioTextBox.Location = new System.Drawing.Point(111, 16);
            this.ServicioTextBox.Name = "ServicioTextBox";
            this.ServicioTextBox.Size = new System.Drawing.Size(452, 20);
            this.ServicioTextBox.TabIndex = 19;
            this.ServicioTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ServicioTextBox_KeyUp);
            // 
            // ServicioRefaccionesRadioButton
            // 
            this.ServicioRefaccionesRadioButton.AutoSize = true;
            this.ServicioRefaccionesRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.ServicioRefaccionesRadioButton.Checked = true;
            this.ServicioRefaccionesRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.ServicioRefaccionesRadioButton.FlatAppearance.BorderSize = 3;
            this.ServicioRefaccionesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServicioRefaccionesRadioButton.ForeColor = System.Drawing.Color.Black;
            this.ServicioRefaccionesRadioButton.Location = new System.Drawing.Point(122, 54);
            this.ServicioRefaccionesRadioButton.Name = "ServicioRefaccionesRadioButton";
            this.ServicioRefaccionesRadioButton.Size = new System.Drawing.Size(181, 17);
            this.ServicioRefaccionesRadioButton.TabIndex = 22;
            this.ServicioRefaccionesRadioButton.TabStop = true;
            this.ServicioRefaccionesRadioButton.Text = "REFACCIONES INCLUIDAS";
            this.ServicioRefaccionesRadioButton.UseVisualStyleBackColor = false;
            this.ServicioRefaccionesRadioButton.CheckedChanged += new System.EventHandler(this.ServicioRefaccionesRadioButton_CheckedChanged);
            // 
            // SoloServicioRadioButton
            // 
            this.SoloServicioRadioButton.AutoSize = true;
            this.SoloServicioRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SoloServicioRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.SoloServicioRadioButton.FlatAppearance.BorderSize = 3;
            this.SoloServicioRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoloServicioRadioButton.ForeColor = System.Drawing.Color.Black;
            this.SoloServicioRadioButton.Location = new System.Drawing.Point(347, 54);
            this.SoloServicioRadioButton.Name = "SoloServicioRadioButton";
            this.SoloServicioRadioButton.Size = new System.Drawing.Size(157, 17);
            this.SoloServicioRadioButton.TabIndex = 23;
            this.SoloServicioRadioButton.Text = "SOLO MANO DE OBRA";
            this.SoloServicioRadioButton.UseVisualStyleBackColor = false;
            this.SoloServicioRadioButton.CheckedChanged += new System.EventHandler(this.SoloServicioRadioButton_CheckedChanged);
            // 
            // BuscarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 303);
            this.Controls.Add(this.SoloServicioRadioButton);
            this.Controls.Add(this.ServicioRefaccionesRadioButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ServiciosDisponiblesDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServicioTextBox);
            this.Name = "BuscarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarServicios";
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosDisponiblesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView ServiciosDisponiblesDataGridView;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicioMantenimientoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vista_ServiciosMantenimientosBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServicioTextBox;
        private System.Windows.Forms.RadioButton ServicioRefaccionesRadioButton;
        private System.Windows.Forms.RadioButton SoloServicioRadioButton;

    }
}