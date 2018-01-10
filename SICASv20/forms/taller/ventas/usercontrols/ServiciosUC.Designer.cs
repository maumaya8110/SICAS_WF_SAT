namespace SICASv20.forms
{
    partial class ServiciosUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.vista_ServiciosMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RefaccionesAgregadasDataGrdiView = new System.Windows.Forms.DataGridView();
            this.EliminarRef = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Refaccion_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenesServiciosRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServiciosAgregadosDataGridView = new System.Windows.Forms.DataGridView();
            this.EliminarOS = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ServicioMantenimiento_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenesServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ServiciosButton = new System.Windows.Forms.Button();
            this.RefaccionesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientosBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesAgregadasDataGrdiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosRefaccionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosAgregadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(499, 518);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 22;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Image = global::SICASv20.Properties.Resources.forward;
            this.SiguienteButton.Location = new System.Drawing.Point(592, 518);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 21;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiguienteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // vista_ServiciosMantenimientosBindingSource
            // 
            this.vista_ServiciosMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosMantenimientos);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RefaccionesAgregadasDataGrdiView);
            this.groupBox2.Location = new System.Drawing.Point(19, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 207);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Refacciones agregadas";
            // 
            // RefaccionesAgregadasDataGrdiView
            // 
            this.RefaccionesAgregadasDataGrdiView.AllowUserToAddRows = false;
            this.RefaccionesAgregadasDataGrdiView.AllowUserToDeleteRows = false;
            this.RefaccionesAgregadasDataGrdiView.AutoGenerateColumns = false;
            this.RefaccionesAgregadasDataGrdiView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesAgregadasDataGrdiView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarRef,
            this.Refaccion_Descripcion,
            this.cantidadDataGridViewTextBoxColumn1,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn1});
            this.RefaccionesAgregadasDataGrdiView.DataSource = this.ordenesServiciosRefaccionesBindingSource;
            this.RefaccionesAgregadasDataGrdiView.Location = new System.Drawing.Point(20, 25);
            this.RefaccionesAgregadasDataGrdiView.Name = "RefaccionesAgregadasDataGrdiView";
            this.RefaccionesAgregadasDataGrdiView.ReadOnly = true;
            this.RefaccionesAgregadasDataGrdiView.Size = new System.Drawing.Size(613, 176);
            this.RefaccionesAgregadasDataGrdiView.TabIndex = 18;
            this.RefaccionesAgregadasDataGrdiView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesAgregadasDataGrdiView_CellContentClick);
            // 
            // EliminarRef
            // 
            this.EliminarRef.HeaderText = "";
            this.EliminarRef.Name = "EliminarRef";
            this.EliminarRef.ReadOnly = true;
            this.EliminarRef.Text = "Eliminar";
            this.EliminarRef.UseColumnTextForLinkValue = true;
            // 
            // Refaccion_Descripcion
            // 
            this.Refaccion_Descripcion.DataPropertyName = "Refaccion_Descripcion";
            this.Refaccion_Descripcion.HeaderText = "Descripcion";
            this.Refaccion_Descripcion.Name = "Refaccion_Descripcion";
            this.Refaccion_Descripcion.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn1
            // 
            this.cantidadDataGridViewTextBoxColumn1.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn1.Name = "cantidadDataGridViewTextBoxColumn1";
            this.cantidadDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle1.Format = "N2";
            this.precioUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn1
            // 
            this.totalDataGridViewTextBoxColumn1.DataPropertyName = "Total";
            dataGridViewCellStyle2.Format = "N2";
            this.totalDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalDataGridViewTextBoxColumn1.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn1.Name = "totalDataGridViewTextBoxColumn1";
            this.totalDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ordenesServiciosRefaccionesBindingSource
            // 
            this.ordenesServiciosRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesServiciosRefacciones);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServiciosAgregadosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(19, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 201);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servicios agregados";
            // 
            // ServiciosAgregadosDataGridView
            // 
            this.ServiciosAgregadosDataGridView.AllowUserToAddRows = false;
            this.ServiciosAgregadosDataGridView.AllowUserToDeleteRows = false;
            this.ServiciosAgregadosDataGridView.AutoGenerateColumns = false;
            this.ServiciosAgregadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosAgregadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarOS,
            this.ServicioMantenimiento_Descripcion,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn1,
            this.totalDataGridViewTextBoxColumn});
            this.ServiciosAgregadosDataGridView.DataSource = this.ordenesServiciosBindingSource;
            this.ServiciosAgregadosDataGridView.Location = new System.Drawing.Point(20, 22);
            this.ServiciosAgregadosDataGridView.Name = "ServiciosAgregadosDataGridView";
            this.ServiciosAgregadosDataGridView.ReadOnly = true;
            this.ServiciosAgregadosDataGridView.Size = new System.Drawing.Size(613, 164);
            this.ServiciosAgregadosDataGridView.TabIndex = 17;
            this.ServiciosAgregadosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiciosAgregadosDataGridView_CellContentClick);
            // 
            // EliminarOS
            // 
            this.EliminarOS.HeaderText = "";
            this.EliminarOS.Name = "EliminarOS";
            this.EliminarOS.ReadOnly = true;
            this.EliminarOS.Text = "Eliminar";
            this.EliminarOS.UseColumnTextForLinkValue = true;
            // 
            // ServicioMantenimiento_Descripcion
            // 
            this.ServicioMantenimiento_Descripcion.DataPropertyName = "ServicioMantenimiento_Descripcion";
            this.ServicioMantenimiento_Descripcion.HeaderText = "Descripcion";
            this.ServicioMantenimiento_Descripcion.Name = "ServicioMantenimiento_Descripcion";
            this.ServicioMantenimiento_Descripcion.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn1
            // 
            this.precioDataGridViewTextBoxColumn1.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.precioDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioDataGridViewTextBoxColumn1.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn1.Name = "precioDataGridViewTextBoxColumn1";
            this.precioDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle4.Format = "N2";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenesServiciosBindingSource
            // 
            this.ordenesServiciosBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesServicios);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Por favor, seleccione los servicios que desee efectuar a la unidad";
            // 
            // ServiciosButton
            // 
            this.ServiciosButton.Location = new System.Drawing.Point(130, 43);
            this.ServiciosButton.Name = "ServiciosButton";
            this.ServiciosButton.Size = new System.Drawing.Size(163, 34);
            this.ServiciosButton.TabIndex = 23;
            this.ServiciosButton.Text = "Elegir Servicios";
            this.ServiciosButton.UseVisualStyleBackColor = true;
            this.ServiciosButton.Click += new System.EventHandler(this.ServiciosButton_Click);
            // 
            // RefaccionesButton
            // 
            this.RefaccionesButton.Location = new System.Drawing.Point(355, 43);
            this.RefaccionesButton.Name = "RefaccionesButton";
            this.RefaccionesButton.Size = new System.Drawing.Size(163, 34);
            this.RefaccionesButton.TabIndex = 24;
            this.RefaccionesButton.Text = "Elegir Refacciones";
            this.RefaccionesButton.UseVisualStyleBackColor = true;
            this.RefaccionesButton.Click += new System.EventHandler(this.RefaccionesButton_Click);
            // 
            // ServiciosUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RefaccionesButton);
            this.Controls.Add(this.ServiciosButton);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Name = "ServiciosUC";
            this.Size = new System.Drawing.Size(694, 557);
            this.Load += new System.EventHandler(this.ServiciosUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientosBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesAgregadasDataGrdiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosRefaccionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosAgregadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ServiciosAgregadosDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView RefaccionesAgregadasDataGrdiView;
        private System.Windows.Forms.BindingSource vista_ServiciosMantenimientosBindingSource;
        private System.Windows.Forms.BindingSource ordenesServiciosBindingSource;
        private System.Windows.Forms.BindingSource ordenesServiciosRefaccionesBindingSource;
        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.DataGridViewLinkColumn EliminarOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicioMantenimiento_Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button ServiciosButton;
        private System.Windows.Forms.Button RefaccionesButton;
        private System.Windows.Forms.DataGridViewLinkColumn EliminarRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refaccion_Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn1;
    }
}
