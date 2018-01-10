namespace SICASv20.forms
{
    partial class BuscarRefacciones
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
            this.label5 = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesDisponiblesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesBindingSource)).BeginInit();
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
            this.RefaccionesDisponiblesDataGridView.Location = new System.Drawing.Point(16, 71);
            this.RefaccionesDisponiblesDataGridView.Name = "RefaccionesDisponiblesDataGridView";
            this.RefaccionesDisponiblesDataGridView.ReadOnly = true;
            this.RefaccionesDisponiblesDataGridView.Size = new System.Drawing.Size(654, 210);
            this.RefaccionesDisponiblesDataGridView.TabIndex = 35;
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
            this.refaccionIDDataGridViewTextBoxColumn.Visible = false;
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
            this.RefaccionTextBox.Location = new System.Drawing.Point(105, 36);
            this.RefaccionTextBox.Name = "RefaccionTextBox";
            this.RefaccionTextBox.Size = new System.Drawing.Size(473, 20);
            this.RefaccionTextBox.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Refaccion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Por favor, seleccione las refacciones que desee vender";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SICASv20.Properties.Resources.search;
            this.BuscarButton.Location = new System.Drawing.Point(584, 32);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(86, 29);
            this.BuscarButton.TabIndex = 36;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // BuscarRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 301);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.RefaccionesDisponiblesDataGridView);
            this.Controls.Add(this.RefaccionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "BuscarRefacciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarRefacciones";
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesDisponiblesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_RefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView RefaccionesDisponiblesDataGridView;
        private System.Windows.Forms.BindingSource vista_RefaccionesBindingSource;
        private System.Windows.Forms.TextBox RefaccionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewLinkColumn SeleccionarRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadInventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioInternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioExternoDataGridViewTextBoxColumn;
    }
}