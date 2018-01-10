namespace SICASv20.forms
{
    partial class RefaccionesUC
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
            this.RefaccionesDisponiblesDataGridView = new System.Windows.Forms.DataGridView();
            this.SeleccionarRef = new System.Windows.Forms.DataGridViewLinkColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadInventarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioInternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_RefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RefaccionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RefaccionesAgregadasDataGrdiView = new System.Windows.Forms.DataGridView();
            this.EliminarRef = new System.Windows.Forms.DataGridViewLinkColumn();
            this.refaccionDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenesServiciosRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesDisponiblesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesAgregadasDataGrdiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosRefaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RefaccionesDisponiblesDataGridView
            // 
            this.RefaccionesDisponiblesDataGridView.AllowUserToAddRows = false;
            this.RefaccionesDisponiblesDataGridView.AllowUserToDeleteRows = false;
            this.RefaccionesDisponiblesDataGridView.AutoGenerateColumns = false;
            this.RefaccionesDisponiblesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesDisponiblesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeleccionarRef,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.cantidadInventarioDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.precioInternoDataGridViewTextBoxColumn,
            this.precioExternoDataGridViewTextBoxColumn});
            this.RefaccionesDisponiblesDataGridView.DataSource = this.vista_RefaccionesBindingSource;
            this.RefaccionesDisponiblesDataGridView.Location = new System.Drawing.Point(41, 78);
            this.RefaccionesDisponiblesDataGridView.Name = "RefaccionesDisponiblesDataGridView";
            this.RefaccionesDisponiblesDataGridView.ReadOnly = true;
            this.RefaccionesDisponiblesDataGridView.Size = new System.Drawing.Size(634, 118);
            this.RefaccionesDisponiblesDataGridView.TabIndex = 22;
            this.RefaccionesDisponiblesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesDisponiblesDataGridView_CellContentClick);
            // 
            // SeleccionarRef
            // 
            this.SeleccionarRef.HeaderText = "";
            this.SeleccionarRef.Name = "SeleccionarRef";
            this.SeleccionarRef.ReadOnly = true;
            this.SeleccionarRef.Text = "Seleccionar";
            this.SeleccionarRef.UseColumnTextForLinkValue = true;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            this.refaccionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadInventarioDataGridViewTextBoxColumn
            // 
            this.cantidadInventarioDataGridViewTextBoxColumn.DataPropertyName = "CantidadInventario";
            this.cantidadInventarioDataGridViewTextBoxColumn.HeaderText = "CantidadInventario";
            this.cantidadInventarioDataGridViewTextBoxColumn.Name = "cantidadInventarioDataGridViewTextBoxColumn";
            this.cantidadInventarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioInternoDataGridViewTextBoxColumn
            // 
            this.precioInternoDataGridViewTextBoxColumn.DataPropertyName = "PrecioInterno";
            this.precioInternoDataGridViewTextBoxColumn.HeaderText = "PrecioInterno";
            this.precioInternoDataGridViewTextBoxColumn.Name = "precioInternoDataGridViewTextBoxColumn";
            this.precioInternoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioExternoDataGridViewTextBoxColumn
            // 
            this.precioExternoDataGridViewTextBoxColumn.DataPropertyName = "PrecioExterno";
            this.precioExternoDataGridViewTextBoxColumn.HeaderText = "PrecioExterno";
            this.precioExternoDataGridViewTextBoxColumn.Name = "precioExternoDataGridViewTextBoxColumn";
            this.precioExternoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vista_RefaccionesBindingSource
            // 
            this.vista_RefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Refacciones);
            // 
            // RefaccionTextBox
            // 
            this.RefaccionTextBox.Location = new System.Drawing.Point(110, 43);
            this.RefaccionTextBox.Name = "RefaccionTextBox";
            this.RefaccionTextBox.Size = new System.Drawing.Size(473, 21);
            this.RefaccionTextBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Refaccion:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RefaccionesAgregadasDataGrdiView);
            this.groupBox2.Location = new System.Drawing.Point(21, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 283);
            this.groupBox2.TabIndex = 19;
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
            this.refaccionDescripcionDataGridViewTextBoxColumn,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.RefaccionesAgregadasDataGrdiView.DataSource = this.ordenesServiciosRefaccionesBindingSource;
            this.RefaccionesAgregadasDataGrdiView.Location = new System.Drawing.Point(20, 25);
            this.RefaccionesAgregadasDataGrdiView.Name = "RefaccionesAgregadasDataGrdiView";
            this.RefaccionesAgregadasDataGrdiView.ReadOnly = true;
            this.RefaccionesAgregadasDataGrdiView.Size = new System.Drawing.Size(634, 234);
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
            // refaccionDescripcionDataGridViewTextBoxColumn
            // 
            this.refaccionDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_Descripcion";
            this.refaccionDescripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.refaccionDescripcionDataGridViewTextBoxColumn.Name = "refaccionDescripcionDataGridViewTextBoxColumn";
            this.refaccionDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "PrecioUnitario";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenesServiciosRefaccionesBindingSource
            // 
            this.ordenesServiciosRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.OrdenesServiciosRefacciones);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(18, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Por favor, seleccione las refacciones que desee vender";
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(501, 513);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 30;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Image = global::SICASv20.Properties.Resources.forward;
            this.SiguienteButton.Location = new System.Drawing.Point(594, 513);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 29;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiguienteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SICASv20.Properties.Resources.search;
            this.BuscarButton.Location = new System.Drawing.Point(589, 39);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(86, 29);
            this.BuscarButton.TabIndex = 31;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            // 
            // RefaccionesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.RefaccionesDisponiblesDataGridView);
            this.Controls.Add(this.RefaccionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Name = "RefaccionesUC";
            this.Size = new System.Drawing.Size(694, 557);
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesDisponiblesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesAgregadasDataGrdiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesServiciosRefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RefaccionesDisponiblesDataGridView;
        private System.Windows.Forms.TextBox RefaccionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView RefaccionesAgregadasDataGrdiView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.BindingSource vista_RefaccionesBindingSource;
        private System.Windows.Forms.BindingSource ordenesServiciosRefaccionesBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn SeleccionarRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadInventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioInternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EliminarRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    }
}
