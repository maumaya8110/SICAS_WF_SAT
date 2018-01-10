namespace SICASv20.forms
{
    partial class Zonas
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
            this.Vista_ZonasDataGridView = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Zona_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoZonaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComisionServicioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vista_ZonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ZonasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ZonasBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_ZonasDataGridView
            // 
            this.Vista_ZonasDataGridView.AllowUserToAddRows = false;
            this.Vista_ZonasDataGridView.AllowUserToDeleteRows = false;
            this.Vista_ZonasDataGridView.AutoGenerateColumns = false;
            this.Vista_ZonasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_ZonasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.Zona_IDColumn,
            this.NombreColumn,
            this.TipoZonaColumn,
            this.ComisionServicioColumn});
            this.Vista_ZonasDataGridView.DataSource = this.Vista_ZonasBindingSource;
            this.Vista_ZonasDataGridView.Location = new System.Drawing.Point(23, 80);
            this.Vista_ZonasDataGridView.Name = "Vista_ZonasDataGridView";
            this.Vista_ZonasDataGridView.ReadOnly = true;
            this.Vista_ZonasDataGridView.Size = new System.Drawing.Size(941, 500);
            this.Vista_ZonasDataGridView.TabIndex = 12;
            this.Vista_ZonasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_ZonasDataGridView_CellContentClick);
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // Zona_IDColumn
            // 
            this.Zona_IDColumn.DataPropertyName = "Zona_ID";
            this.Zona_IDColumn.HeaderText = "Zona_ID";
            this.Zona_IDColumn.Name = "Zona_IDColumn";
            this.Zona_IDColumn.ReadOnly = true;
            // 
            // NombreColumn
            // 
            this.NombreColumn.DataPropertyName = "Nombre";
            this.NombreColumn.HeaderText = "Nombre";
            this.NombreColumn.Name = "NombreColumn";
            this.NombreColumn.ReadOnly = true;
            // 
            // TipoZonaColumn
            // 
            this.TipoZonaColumn.DataPropertyName = "TipoZona";
            this.TipoZonaColumn.HeaderText = "TipoZona";
            this.TipoZonaColumn.Name = "TipoZonaColumn";
            this.TipoZonaColumn.ReadOnly = true;
            // 
            // ComisionServicioColumn
            // 
            this.ComisionServicioColumn.DataPropertyName = "ComisionServicio";
            this.ComisionServicioColumn.HeaderText = "ComisionServicio";
            this.ComisionServicioColumn.Name = "ComisionServicioColumn";
            this.ComisionServicioColumn.ReadOnly = true;
            // 
            // Vista_ZonasBindingSource
            // 
            this.Vista_ZonasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Zonas);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(451, 31);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 31);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(20, 39);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(55, 15);
            this.NombreLabel.TabIndex = 1;
            this.NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(95, 36);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(312, 21);
            this.NombreTextBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.NombreLabel);
            this.groupBox1.Controls.Add(this.Vista_ZonasDataGridView);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 589);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Zonas";
            // 
            // Zonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 613);
            this.Controls.Add(this.groupBox1);
            this.Name = "Zonas";
            this.Text = "Zonas";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ZonasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ZonasBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_ZonasDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zona_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoZonaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComisionServicioColumn;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.BindingSource Vista_ZonasBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;        

    }
}