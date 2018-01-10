namespace SICASv20.forms
{
    partial class BusquedaTipoRefaccion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tiposRefaccionesDataGridView = new System.Windows.Forms.DataGridView();
            this.SeleccionarCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tiposRefaccionesDataGridView);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione un tipo de refacción";
            // 
            // tiposRefaccionesDataGridView
            // 
            this.tiposRefaccionesDataGridView.AllowUserToAddRows = false;
            this.tiposRefaccionesDataGridView.AllowUserToDeleteRows = false;
            this.tiposRefaccionesDataGridView.AutoGenerateColumns = false;
            this.tiposRefaccionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tiposRefaccionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeleccionarCol,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.tiposRefaccionesDataGridView.DataSource = this.tiposRefaccionesBindingSource;
            this.tiposRefaccionesDataGridView.Location = new System.Drawing.Point(10, 58);
            this.tiposRefaccionesDataGridView.Name = "tiposRefaccionesDataGridView";
            this.tiposRefaccionesDataGridView.ReadOnly = true;
            this.tiposRefaccionesDataGridView.Size = new System.Drawing.Size(496, 220);
            this.tiposRefaccionesDataGridView.TabIndex = 3;
            this.tiposRefaccionesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tiposRefaccionesDataGridView_CellContentClick);
            // 
            // SeleccionarCol
            // 
            this.SeleccionarCol.HeaderText = "";
            this.SeleccionarCol.Name = "SeleccionarCol";
            this.SeleccionarCol.ReadOnly = true;
            this.SeleccionarCol.Text = "Seleccionar";
            this.SeleccionarCol.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TipoRefaccion_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // tiposRefaccionesBindingSource
            // 
            this.tiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposRefacciones);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(431, 25);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 2;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(75, 26);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(349, 20);
            this.NombreTextBox.TabIndex = 1;
            this.NombreTextBox.TextChanged += new System.EventHandler(this.NombreTextBox_TextChanged);
            this.NombreTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NombreTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // BusquedaTipoRefaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 333);
            this.Controls.Add(this.groupBox1);
            this.Name = "BusquedaTipoRefaccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de tipo de refacción";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tiposRefaccionesDataGridView;
        private System.Windows.Forms.BindingSource tiposRefaccionesBindingSource;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn SeleccionarCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}