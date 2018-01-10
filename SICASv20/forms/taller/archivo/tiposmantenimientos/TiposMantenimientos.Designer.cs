namespace SICASv20.forms
{
    partial class TiposMantenimientos
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
            this.Vista_TiposMantenimientosDataGridView = new System.Windows.Forms.DataGridView();
            this.Vista_TiposMantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.TipoMantenimiento_IDLabel = new System.Windows.Forms.Label();
            this.TipoMantenimiento_IDTextBox = new System.Windows.Forms.TextBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.TipoMantenimiento_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TiposMantenimientosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TiposMantenimientosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_TiposMantenimientosDataGridView
            // 
            this.Vista_TiposMantenimientosDataGridView.AllowUserToAddRows = false;
            this.Vista_TiposMantenimientosDataGridView.AllowUserToDeleteRows = false;
            this.Vista_TiposMantenimientosDataGridView.AutoGenerateColumns = false;
            this.Vista_TiposMantenimientosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_TiposMantenimientosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.TipoMantenimiento_IDColumn,
            this.NombreColumn,
            this.Activo});
            this.Vista_TiposMantenimientosDataGridView.DataSource = this.Vista_TiposMantenimientosBindingSource;
            this.Vista_TiposMantenimientosDataGridView.Location = new System.Drawing.Point(18, 137);
            this.Vista_TiposMantenimientosDataGridView.Name = "Vista_TiposMantenimientosDataGridView";
            this.Vista_TiposMantenimientosDataGridView.ReadOnly = true;
            this.Vista_TiposMantenimientosDataGridView.Size = new System.Drawing.Size(953, 467);
            this.Vista_TiposMantenimientosDataGridView.TabIndex = 12;
            this.Vista_TiposMantenimientosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_TiposMantenimientosDataGridView_CellContentClick);
            // 
            // Vista_TiposMantenimientosBindingSource
            // 
            this.Vista_TiposMantenimientosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_TiposMantenimientos);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(484, 30);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // TipoMantenimiento_IDLabel
            // 
            this.TipoMantenimiento_IDLabel.AutoSize = true;
            this.TipoMantenimiento_IDLabel.Location = new System.Drawing.Point(29, 30);
            this.TipoMantenimiento_IDLabel.Name = "TipoMantenimiento_IDLabel";
            this.TipoMantenimiento_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.TipoMantenimiento_IDLabel.TabIndex = 1;
            this.TipoMantenimiento_IDLabel.Text = "TipoMantenimiento_ID:";
            // 
            // TipoMantenimiento_IDTextBox
            // 
            this.TipoMantenimiento_IDTextBox.Location = new System.Drawing.Point(214, 30);
            this.TipoMantenimiento_IDTextBox.Name = "TipoMantenimiento_IDTextBox";
            this.TipoMantenimiento_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.TipoMantenimiento_IDTextBox.TabIndex = 2;
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(29, 57);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 3;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(214, 57);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(150, 21);
            this.NombreTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDLabel);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.TipoMantenimiento_IDTextBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de búsqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Vista_TiposMantenimientosDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 628);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipos de mantenimientos";
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // TipoMantenimiento_IDColumn
            // 
            this.TipoMantenimiento_IDColumn.DataPropertyName = "TipoMantenimiento_ID";
            this.TipoMantenimiento_IDColumn.HeaderText = "TipoMantenimiento_ID";
            this.TipoMantenimiento_IDColumn.Name = "TipoMantenimiento_IDColumn";
            this.TipoMantenimiento_IDColumn.ReadOnly = true;
            // 
            // NombreColumn
            // 
            this.NombreColumn.DataPropertyName = "Nombre";
            this.NombreColumn.HeaderText = "Nombre";
            this.NombreColumn.Name = "NombreColumn";
            this.NombreColumn.ReadOnly = true;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            // 
            // TiposMantenimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "TiposMantenimientos";
            this.Text = "TiposMantenimientos";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TiposMantenimientosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TiposMantenimientosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_TiposMantenimientosDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label TipoMantenimiento_IDLabel;
        private System.Windows.Forms.TextBox TipoMantenimiento_IDTextBox;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.BindingSource Vista_TiposMantenimientosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMantenimiento_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;

    }
}