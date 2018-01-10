namespace SICASv20.forms
{
    partial class PlanesDeRenta
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
            this.Vista_PlanesDeRentaDataGridView = new System.Windows.Forms.DataGridView();
            this.Vista_PlanesDeRentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarButton = new System.Windows.Forms.Button();
            this.selectDiasDeCobrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ModeloUnidad_IDLabel = new System.Windows.Forms.Label();
            this.ModeloUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
            this.selectModelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DiasDeCobro_IDLabel = new System.Windows.Forms.Label();
            this.DiasDeCobro_IDComboBox = new System.Windows.Forms.ComboBox();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.RentaBaseLabel = new System.Windows.Forms.Label();
            this.RentaBaseTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EditColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.PlanDeRenta_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasDeCobroColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentaBaseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PlanesDeRentaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PlanesDeRentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectDiasDeCobrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosUnidadesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vista_PlanesDeRentaDataGridView
            // 
            this.Vista_PlanesDeRentaDataGridView.AllowUserToAddRows = false;
            this.Vista_PlanesDeRentaDataGridView.AllowUserToDeleteRows = false;
            this.Vista_PlanesDeRentaDataGridView.AutoGenerateColumns = false;
            this.Vista_PlanesDeRentaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_PlanesDeRentaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.PlanDeRenta_IDColumn,
            this.Estacion,
            this.ModeloColumn,
            this.DiasDeCobroColumn,
            this.DescripcionColumn,
            this.RentaBaseColumn,
            this.Usuario_IDColumn,
            this.FechaColumn});
            this.Vista_PlanesDeRentaDataGridView.DataSource = this.Vista_PlanesDeRentaBindingSource;
            this.Vista_PlanesDeRentaDataGridView.Location = new System.Drawing.Point(6, 147);
            this.Vista_PlanesDeRentaDataGridView.Name = "Vista_PlanesDeRentaDataGridView";
            this.Vista_PlanesDeRentaDataGridView.ReadOnly = true;
            this.Vista_PlanesDeRentaDataGridView.Size = new System.Drawing.Size(942, 387);
            this.Vista_PlanesDeRentaDataGridView.TabIndex = 12;
            this.Vista_PlanesDeRentaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_PlanesDeRentaDataGridView_CellContentClick);
            // 
            // Vista_PlanesDeRentaBindingSource
            // 
            this.Vista_PlanesDeRentaBindingSource.DataSource = typeof(SICASv20.Entities.Vista_PlanesDeRenta);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(647, 30);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 42);
            this.BuscarButton.TabIndex = 11;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // selectDiasDeCobrosBindingSource
            // 
            this.selectDiasDeCobrosBindingSource.DataSource = typeof(SICASv20.Entities.SelectDiasDeCobros);
            // 
            // ModeloUnidad_IDLabel
            // 
            this.ModeloUnidad_IDLabel.AutoSize = true;
            this.ModeloUnidad_IDLabel.Location = new System.Drawing.Point(16, 28);
            this.ModeloUnidad_IDLabel.Name = "ModeloUnidad_IDLabel";
            this.ModeloUnidad_IDLabel.Size = new System.Drawing.Size(112, 15);
            this.ModeloUnidad_IDLabel.TabIndex = 1;
            this.ModeloUnidad_IDLabel.Text = "Modelo de Unidad:";
            // 
            // ModeloUnidad_IDComboBox
            // 
            this.ModeloUnidad_IDComboBox.DataSource = this.selectModelosUnidadesBindingSource;
            this.ModeloUnidad_IDComboBox.DisplayMember = "Nombre";
            this.ModeloUnidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeloUnidad_IDComboBox.FormattingEnabled = true;
            this.ModeloUnidad_IDComboBox.Location = new System.Drawing.Point(142, 24);
            this.ModeloUnidad_IDComboBox.Name = "ModeloUnidad_IDComboBox";
            this.ModeloUnidad_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.ModeloUnidad_IDComboBox.TabIndex = 2;
            this.ModeloUnidad_IDComboBox.ValueMember = "ModeloUnidad_ID";
            // 
            // selectModelosUnidadesBindingSource
            // 
            this.selectModelosUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.SelectModelosUnidades);
            // 
            // DiasDeCobro_IDLabel
            // 
            this.DiasDeCobro_IDLabel.AutoSize = true;
            this.DiasDeCobro_IDLabel.Location = new System.Drawing.Point(16, 55);
            this.DiasDeCobro_IDLabel.Name = "DiasDeCobro_IDLabel";
            this.DiasDeCobro_IDLabel.Size = new System.Drawing.Size(86, 15);
            this.DiasDeCobro_IDLabel.TabIndex = 3;
            this.DiasDeCobro_IDLabel.Text = "Dias de cobro:";
            // 
            // DiasDeCobro_IDComboBox
            // 
            this.DiasDeCobro_IDComboBox.DataSource = this.selectDiasDeCobrosBindingSource;
            this.DiasDeCobro_IDComboBox.DisplayMember = "Nombre";
            this.DiasDeCobro_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiasDeCobro_IDComboBox.FormattingEnabled = true;
            this.DiasDeCobro_IDComboBox.Location = new System.Drawing.Point(142, 51);
            this.DiasDeCobro_IDComboBox.Name = "DiasDeCobro_IDComboBox";
            this.DiasDeCobro_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.DiasDeCobro_IDComboBox.TabIndex = 4;
            this.DiasDeCobro_IDComboBox.ValueMember = "DiasDeCobro_ID";
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Location = new System.Drawing.Point(365, 27);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(75, 15);
            this.DescripcionLabel.TabIndex = 5;
            this.DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(458, 24);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(150, 21);
            this.DescripcionTextBox.TabIndex = 6;
            // 
            // RentaBaseLabel
            // 
            this.RentaBaseLabel.AutoSize = true;
            this.RentaBaseLabel.Location = new System.Drawing.Point(365, 54);
            this.RentaBaseLabel.Name = "RentaBaseLabel";
            this.RentaBaseLabel.Size = new System.Drawing.Size(71, 15);
            this.RentaBaseLabel.TabIndex = 7;
            this.RentaBaseLabel.Text = "RentaBase:";
            // 
            // RentaBaseTextBox
            // 
            this.RentaBaseTextBox.Location = new System.Drawing.Point(458, 51);
            this.RentaBaseTextBox.Name = "RentaBaseTextBox";
            this.RentaBaseTextBox.Size = new System.Drawing.Size(150, 21);
            this.RentaBaseTextBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RentaBaseTextBox);
            this.groupBox1.Controls.Add(this.DescripcionTextBox);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.RentaBaseLabel);
            this.groupBox1.Controls.Add(this.ModeloUnidad_IDLabel);
            this.groupBox1.Controls.Add(this.DescripcionLabel);
            this.groupBox1.Controls.Add(this.DiasDeCobro_IDComboBox);
            this.groupBox1.Controls.Add(this.ModeloUnidad_IDComboBox);
            this.groupBox1.Controls.Add(this.DiasDeCobro_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 121);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.selectEstacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(142, 80);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(200, 23);
            this.EstacionesComboBox.TabIndex = 13;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estacion:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Vista_PlanesDeRentaDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(974, 627);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Planes de Renta";
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "";
            this.EditColumn.Image = global::SICASv20.Properties.Resources.edit;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            // 
            // PlanDeRenta_IDColumn
            // 
            this.PlanDeRenta_IDColumn.DataPropertyName = "PlanDeRenta_ID";
            this.PlanDeRenta_IDColumn.HeaderText = "PlanDeRenta_ID";
            this.PlanDeRenta_IDColumn.Name = "PlanDeRenta_IDColumn";
            this.PlanDeRenta_IDColumn.ReadOnly = true;
            // 
            // Estacion
            // 
            this.Estacion.DataPropertyName = "Estacion";
            this.Estacion.HeaderText = "Estacion";
            this.Estacion.Name = "Estacion";
            this.Estacion.ReadOnly = true;
            // 
            // ModeloColumn
            // 
            this.ModeloColumn.DataPropertyName = "Modelo";
            this.ModeloColumn.HeaderText = "Modelo";
            this.ModeloColumn.Name = "ModeloColumn";
            this.ModeloColumn.ReadOnly = true;
            // 
            // DiasDeCobroColumn
            // 
            this.DiasDeCobroColumn.DataPropertyName = "DiasDeCobro";
            this.DiasDeCobroColumn.HeaderText = "DiasDeCobro";
            this.DiasDeCobroColumn.Name = "DiasDeCobroColumn";
            this.DiasDeCobroColumn.ReadOnly = true;
            // 
            // DescripcionColumn
            // 
            this.DescripcionColumn.DataPropertyName = "Descripcion";
            this.DescripcionColumn.HeaderText = "Descripcion";
            this.DescripcionColumn.Name = "DescripcionColumn";
            this.DescripcionColumn.ReadOnly = true;
            // 
            // RentaBaseColumn
            // 
            this.RentaBaseColumn.DataPropertyName = "RentaBase";
            this.RentaBaseColumn.HeaderText = "RentaBase";
            this.RentaBaseColumn.Name = "RentaBaseColumn";
            this.RentaBaseColumn.ReadOnly = true;
            // 
            // Usuario_IDColumn
            // 
            this.Usuario_IDColumn.DataPropertyName = "Usuario_ID";
            this.Usuario_IDColumn.HeaderText = "Usuario_ID";
            this.Usuario_IDColumn.Name = "Usuario_IDColumn";
            this.Usuario_IDColumn.ReadOnly = true;
            // 
            // FechaColumn
            // 
            this.FechaColumn.DataPropertyName = "Fecha";
            this.FechaColumn.HeaderText = "Fecha";
            this.FechaColumn.Name = "FechaColumn";
            this.FechaColumn.ReadOnly = true;
            // 
            // PlanesDeRenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox2);
            this.Name = "PlanesDeRenta";
            this.Text = "PlanesDeRenta";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PlanesDeRentaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PlanesDeRentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectDiasDeCobrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectModelosUnidadesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView Vista_PlanesDeRentaDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Label ModeloUnidad_IDLabel;
        private System.Windows.Forms.ComboBox ModeloUnidad_IDComboBox;
        private System.Windows.Forms.Label DiasDeCobro_IDLabel;
        private System.Windows.Forms.ComboBox DiasDeCobro_IDComboBox;
        private System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label RentaBaseLabel;
        private System.Windows.Forms.TextBox RentaBaseTextBox;
        private System.Windows.Forms.BindingSource Vista_PlanesDeRentaBindingSource;
        private System.Windows.Forms.BindingSource selectDiasDeCobrosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource selectModelosUnidadesBindingSource;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDeRenta_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasDeCobroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentaBaseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaColumn;




    }
}