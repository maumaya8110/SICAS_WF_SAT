namespace SICASv20.forms
{
    partial class BuscarRefaccion
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
            this.label1 = new System.Windows.Forms.Label();
            this.RefaccionTextBox = new System.Windows.Forms.TextBox();
            this.RefaccionesGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.refaccionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSerialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadInventarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorInventarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntoDeReOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Refaccion";
            // 
            // RefaccionTextBox
            // 
            this.RefaccionTextBox.Location = new System.Drawing.Point(148, 19);
            this.RefaccionTextBox.Name = "RefaccionTextBox";
            this.RefaccionTextBox.Size = new System.Drawing.Size(372, 21);
            this.RefaccionTextBox.TabIndex = 1;            
            // 
            // RefaccionesGridView
            // 
            this.RefaccionesGridView.AutoGenerateColumns = false;
            this.RefaccionesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RefaccionesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.refaccionIDDataGridViewTextBoxColumn,
            this.numeroSerialDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.costoUnitarioDataGridViewTextBoxColumn,
            this.cantidadInventarioDataGridViewTextBoxColumn,
            this.valorInventarioDataGridViewTextBoxColumn,
            this.puntoDeReOrdenDataGridViewTextBoxColumn});
            this.RefaccionesGridView.DataSource = this.refaccionesBindingSource;
            this.RefaccionesGridView.Location = new System.Drawing.Point(15, 55);
            this.RefaccionesGridView.Name = "RefaccionesGridView";
            this.RefaccionesGridView.Size = new System.Drawing.Size(864, 275);
            this.RefaccionesGridView.TabIndex = 3;
            this.RefaccionesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RefaccionesGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // refaccionIDDataGridViewTextBoxColumn
            // 
            this.refaccionIDDataGridViewTextBoxColumn.DataPropertyName = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.HeaderText = "Refaccion_ID";
            this.refaccionIDDataGridViewTextBoxColumn.Name = "refaccionIDDataGridViewTextBoxColumn";
            // 
            // numeroSerialDataGridViewTextBoxColumn
            // 
            this.numeroSerialDataGridViewTextBoxColumn.DataPropertyName = "NumeroSerial";
            this.numeroSerialDataGridViewTextBoxColumn.HeaderText = "NumeroSerial";
            this.numeroSerialDataGridViewTextBoxColumn.Name = "numeroSerialDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // costoUnitarioDataGridViewTextBoxColumn
            // 
            this.costoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.HeaderText = "CostoUnitario";
            this.costoUnitarioDataGridViewTextBoxColumn.Name = "costoUnitarioDataGridViewTextBoxColumn";
            // 
            // cantidadInventarioDataGridViewTextBoxColumn
            // 
            this.cantidadInventarioDataGridViewTextBoxColumn.DataPropertyName = "CantidadInventario";
            this.cantidadInventarioDataGridViewTextBoxColumn.HeaderText = "CantidadInventario";
            this.cantidadInventarioDataGridViewTextBoxColumn.Name = "cantidadInventarioDataGridViewTextBoxColumn";
            // 
            // valorInventarioDataGridViewTextBoxColumn
            // 
            this.valorInventarioDataGridViewTextBoxColumn.DataPropertyName = "ValorInventario";
            this.valorInventarioDataGridViewTextBoxColumn.HeaderText = "ValorInventario";
            this.valorInventarioDataGridViewTextBoxColumn.Name = "valorInventarioDataGridViewTextBoxColumn";
            // 
            // puntoDeReOrdenDataGridViewTextBoxColumn
            // 
            this.puntoDeReOrdenDataGridViewTextBoxColumn.DataPropertyName = "PuntoDeReOrden";
            this.puntoDeReOrdenDataGridViewTextBoxColumn.HeaderText = "PuntoDeReOrden";
            this.puntoDeReOrdenDataGridViewTextBoxColumn.Name = "puntoDeReOrdenDataGridViewTextBoxColumn";
            // 
            // refaccionesBindingSource
            // 
            this.refaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Refacciones);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(526, 15);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(88, 29);
            this.BuscarButton.TabIndex = 5;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // BuscarRefaccion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(907, 358);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.RefaccionesGridView);
            this.Controls.Add(this.RefaccionTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BuscarRefaccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar refacción";
            ((System.ComponentModel.ISupportInitialize)(this.RefaccionesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RefaccionTextBox;
        private System.Windows.Forms.DataGridView RefaccionesGridView;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSerialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadInventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorInventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoDeReOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource refaccionesBindingSource;
        private System.Windows.Forms.Button BuscarButton;
    }
}