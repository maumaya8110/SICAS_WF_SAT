namespace SICASv20.forms
{
    partial class TarifasEdicion
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
            this.Vista_TarifasDataGridView = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Zona_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZonaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarifaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vista_TarifasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectTiposServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TipoServicio_IDLabel = new System.Windows.Forms.Label();
            this.TipoServicio_IDComboBox = new System.Windows.Forms.ComboBox();
            this.ZonaLabel = new System.Windows.Forms.Label();
            this.ZonaTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TarifasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TarifasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposServiciosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_TarifasDataGridView
            // 
            this.Vista_TarifasDataGridView.AllowUserToAddRows = false;
            this.Vista_TarifasDataGridView.AllowUserToDeleteRows = false;
            this.Vista_TarifasDataGridView.AutoGenerateColumns = false;
            this.Vista_TarifasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_TarifasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.Zona_IDColumn,
            this.TipoServicio_IDColumn,
            this.ZonaColumn,
            this.TipoServicioColumn,
            this.TarifaColumn});
            this.Vista_TarifasDataGridView.DataSource = this.Vista_TarifasBindingSource;
            this.Vista_TarifasDataGridView.Location = new System.Drawing.Point(19, 100);
            this.Vista_TarifasDataGridView.Name = "Vista_TarifasDataGridView";
            this.Vista_TarifasDataGridView.ReadOnly = true;
            this.Vista_TarifasDataGridView.Size = new System.Drawing.Size(948, 492);
            this.Vista_TarifasDataGridView.TabIndex = 12;
            this.Vista_TarifasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_TarifasDataGridView_CellContentClick);
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
            // TipoServicio_IDColumn
            // 
            this.TipoServicio_IDColumn.DataPropertyName = "TipoServicio_ID";
            this.TipoServicio_IDColumn.HeaderText = "TipoServicio_ID";
            this.TipoServicio_IDColumn.Name = "TipoServicio_IDColumn";
            this.TipoServicio_IDColumn.ReadOnly = true;
            // 
            // ZonaColumn
            // 
            this.ZonaColumn.DataPropertyName = "Zona";
            this.ZonaColumn.HeaderText = "Zona";
            this.ZonaColumn.Name = "ZonaColumn";
            this.ZonaColumn.ReadOnly = true;
            // 
            // TipoServicioColumn
            // 
            this.TipoServicioColumn.DataPropertyName = "TipoServicio";
            this.TipoServicioColumn.HeaderText = "TipoServicio";
            this.TipoServicioColumn.Name = "TipoServicioColumn";
            this.TipoServicioColumn.ReadOnly = true;
            // 
            // TarifaColumn
            // 
            this.TarifaColumn.DataPropertyName = "Tarifa";
            this.TarifaColumn.HeaderText = "Tarifa";
            this.TarifaColumn.Name = "TarifaColumn";
            this.TarifaColumn.ReadOnly = true;
            // 
            // Vista_TarifasBindingSource
            // 
            this.Vista_TarifasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Tarifas);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(502, 32);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectTiposServiciosBindingSource
            // 
            this.selectTiposServiciosBindingSource.DataSource = typeof(SICASv20.Entities.SelectTiposServicios);
            // 
            // TipoServicio_IDLabel
            // 
            this.TipoServicio_IDLabel.AutoSize = true;
            this.TipoServicio_IDLabel.Location = new System.Drawing.Point(16, 35);
            this.TipoServicio_IDLabel.Name = "TipoServicio_IDLabel";
            this.TipoServicio_IDLabel.Size = new System.Drawing.Size(80, 15);
            this.TipoServicio_IDLabel.TabIndex = 1;
            this.TipoServicio_IDLabel.Text = "Tipo Servicio:";
            // 
            // TipoServicio_IDComboBox
            // 
            this.TipoServicio_IDComboBox.DataSource = this.selectTiposServiciosBindingSource;
            this.TipoServicio_IDComboBox.DisplayMember = "Nombre";
            this.TipoServicio_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoServicio_IDComboBox.FormattingEnabled = true;
            this.TipoServicio_IDComboBox.Location = new System.Drawing.Point(143, 32);
            this.TipoServicio_IDComboBox.Name = "TipoServicio_IDComboBox";
            this.TipoServicio_IDComboBox.Size = new System.Drawing.Size(307, 23);
            this.TipoServicio_IDComboBox.TabIndex = 2;
            this.TipoServicio_IDComboBox.ValueMember = "TipoServicio_ID";
            // 
            // ZonaLabel
            // 
            this.ZonaLabel.Location = new System.Drawing.Point(16, 62);
            this.ZonaLabel.Name = "ZonaLabel";
            this.ZonaLabel.Size = new System.Drawing.Size(50, 15);
            this.ZonaLabel.TabIndex = 3;
            this.ZonaLabel.Text = "Zona:";
            // 
            // ZonaTextBox
            // 
            this.ZonaTextBox.Location = new System.Drawing.Point(143, 59);
            this.ZonaTextBox.Name = "ZonaTextBox";
            this.ZonaTextBox.Size = new System.Drawing.Size(307, 21);
            this.ZonaTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Vista_TarifasDataGridView);
            this.groupBox1.Controls.Add(this.TipoServicio_IDLabel);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.TipoServicio_IDComboBox);
            this.groupBox1.Controls.Add(this.ZonaTextBox);
            this.groupBox1.Controls.Add(this.ZonaLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 609);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarifas";
            // 
            // Tarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 633);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tarifas";
            this.Text = "Tarifas";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TarifasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_TarifasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectTiposServiciosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_TarifasDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zona_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZonaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarifaColumn;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label TipoServicio_IDLabel;
        private System.Windows.Forms.ComboBox TipoServicio_IDComboBox;
        private System.Windows.Forms.Label ZonaLabel;
        private System.Windows.Forms.TextBox ZonaTextBox;
        private System.Windows.Forms.BindingSource Vista_TarifasBindingSource;
        private System.Windows.Forms.BindingSource selectTiposServiciosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;        

    }
}