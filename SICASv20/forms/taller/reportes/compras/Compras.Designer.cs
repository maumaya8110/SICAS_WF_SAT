namespace SICASv20.forms
{
    partial class Compras
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
            this.vista_ComprasAlmacenDataGridView = new System.Windows.Forms.DataGridView();
            this.ordenCompraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasAlmacenDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vista_ComprasAlmacenDataGridView
            // 
            this.vista_ComprasAlmacenDataGridView.AllowUserToAddRows = false;
            this.vista_ComprasAlmacenDataGridView.AllowUserToDeleteRows = false;
            this.vista_ComprasAlmacenDataGridView.AutoGenerateColumns = false;
            this.vista_ComprasAlmacenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_ComprasAlmacenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordenCompraIDDataGridViewTextBoxColumn,
            this.refaccionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn});
            this.vista_ComprasAlmacenDataGridView.DataSource = this.vista_ComprasBindingSource;
            this.vista_ComprasAlmacenDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vista_ComprasAlmacenDataGridView.Location = new System.Drawing.Point(0, 0);
            this.vista_ComprasAlmacenDataGridView.Name = "vista_ComprasAlmacenDataGridView";
            this.vista_ComprasAlmacenDataGridView.ReadOnly = true;
            this.vista_ComprasAlmacenDataGridView.Size = new System.Drawing.Size(878, 565);
            this.vista_ComprasAlmacenDataGridView.TabIndex = 0;
            // 
            // ordenCompraIDDataGridViewTextBoxColumn
            // 
            this.ordenCompraIDDataGridViewTextBoxColumn.DataPropertyName = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.HeaderText = "OrdenCompra_ID";
            this.ordenCompraIDDataGridViewTextBoxColumn.Name = "ordenCompraIDDataGridViewTextBoxColumn";
            this.ordenCompraIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refaccionDataGridViewTextBoxColumn
            // 
            this.refaccionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.HeaderText = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.Name = "refaccionDataGridViewTextBoxColumn";
            this.refaccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            this.costoUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vista_ComprasBindingSource
            // 
            this.vista_ComprasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Compras);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 565);
            this.Controls.Add(this.vista_ComprasAlmacenDataGridView);
            this.Name = "Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasAlmacenDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ComprasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vista_ComprasAlmacenDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vista_ComprasBindingSource;
    }
}