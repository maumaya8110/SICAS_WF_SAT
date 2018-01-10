namespace SICASv20.forms
{
    partial class Contratos_DatosUnidad_UC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.DiasDeCobroComboBox = new System.Windows.Forms.ComboBox();
            this.diasDeCobrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FondoResidualTextBox = new System.Windows.Forms.TextBox();
            this.MontoDiarioTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UnidadesGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.unidadIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioListaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSerieMotorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarjetaCirculacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometrajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlacasTextBox = new System.Windows.Forms.TextBox();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.AtrasButton = new System.Windows.Forms.Button();
            this.planesDeRentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlanesDeRentaComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesDeRentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PlanesDeRentaComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.DiasDeCobroComboBox);
            this.groupBox1.Controls.Add(this.FondoResidualTextBox);
            this.groupBox1.Controls.Add(this.MontoDiarioTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UnidadesGridView);
            this.groupBox1.Controls.Add(this.PlacasTextBox);
            this.groupBox1.Controls.Add(this.NumeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1188, 610);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistente de contratos: Unidades";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(656, 65);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(96, 32);
            this.BuscarButton.TabIndex = 12;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // DiasDeCobroComboBox
            // 
            this.DiasDeCobroComboBox.DataSource = this.diasDeCobrosBindingSource;
            this.DiasDeCobroComboBox.DisplayMember = "Nombre";
            this.DiasDeCobroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiasDeCobroComboBox.FormattingEnabled = true;
            this.DiasDeCobroComboBox.Location = new System.Drawing.Point(275, 441);
            this.DiasDeCobroComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DiasDeCobroComboBox.Name = "DiasDeCobroComboBox";
            this.DiasDeCobroComboBox.Size = new System.Drawing.Size(342, 26);
            this.DiasDeCobroComboBox.TabIndex = 11;
            this.DiasDeCobroComboBox.ValueMember = "DiasDeCobro_ID";
            // 
            // diasDeCobrosBindingSource
            // 
            this.diasDeCobrosBindingSource.DataSource = typeof(SICASv20.Entities.DiasDeCobros);
            // 
            // FondoResidualTextBox
            // 
            this.FondoResidualTextBox.Location = new System.Drawing.Point(275, 408);
            this.FondoResidualTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FondoResidualTextBox.Name = "FondoResidualTextBox";
            this.FondoResidualTextBox.Size = new System.Drawing.Size(153, 24);
            this.FondoResidualTextBox.TabIndex = 10;
            // 
            // MontoDiarioTextBox
            // 
            this.MontoDiarioTextBox.Location = new System.Drawing.Point(275, 376);
            this.MontoDiarioTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.MontoDiarioTextBox.Name = "MontoDiarioTextBox";
            this.MontoDiarioTextBox.Size = new System.Drawing.Size(153, 24);
            this.MontoDiarioTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 444);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Capture los días de cobro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 411);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Capture el fondo residual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 379);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Capture un monto diario a cobrar:";
            // 
            // UnidadesGridView
            // 
            this.UnidadesGridView.AllowUserToAddRows = false;
            this.UnidadesGridView.AllowUserToDeleteRows = false;
            this.UnidadesGridView.AutoGenerateColumns = false;
            this.UnidadesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnidadesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.unidadIDDataGridViewTextBoxColumn,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.precioListaDataGridViewTextBoxColumn,
            this.numeroSerieDataGridViewTextBoxColumn,
            this.numeroSerieMotorDataGridViewTextBoxColumn,
            this.tarjetaCirculacionDataGridViewTextBoxColumn,
            this.placasDataGridViewTextBoxColumn,
            this.kilometrajeDataGridViewTextBoxColumn});
            this.UnidadesGridView.DataSource = this.unidadesBindingSource;
            this.UnidadesGridView.Location = new System.Drawing.Point(24, 113);
            this.UnidadesGridView.Margin = new System.Windows.Forms.Padding(4);
            this.UnidadesGridView.Name = "UnidadesGridView";
            this.UnidadesGridView.ReadOnly = true;
            this.UnidadesGridView.Size = new System.Drawing.Size(1139, 214);
            this.UnidadesGridView.TabIndex = 5;
            this.UnidadesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnidadesGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // unidadIDDataGridViewTextBoxColumn
            // 
            this.unidadIDDataGridViewTextBoxColumn.DataPropertyName = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.HeaderText = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.Name = "unidadIDDataGridViewTextBoxColumn";
            this.unidadIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioListaDataGridViewTextBoxColumn
            // 
            this.precioListaDataGridViewTextBoxColumn.DataPropertyName = "PrecioLista";
            this.precioListaDataGridViewTextBoxColumn.HeaderText = "PrecioLista";
            this.precioListaDataGridViewTextBoxColumn.Name = "precioListaDataGridViewTextBoxColumn";
            this.precioListaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroSerieDataGridViewTextBoxColumn
            // 
            this.numeroSerieDataGridViewTextBoxColumn.DataPropertyName = "NumeroSerie";
            this.numeroSerieDataGridViewTextBoxColumn.HeaderText = "NumeroSerie";
            this.numeroSerieDataGridViewTextBoxColumn.Name = "numeroSerieDataGridViewTextBoxColumn";
            this.numeroSerieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroSerieMotorDataGridViewTextBoxColumn
            // 
            this.numeroSerieMotorDataGridViewTextBoxColumn.DataPropertyName = "NumeroSerieMotor";
            this.numeroSerieMotorDataGridViewTextBoxColumn.HeaderText = "NumeroSerieMotor";
            this.numeroSerieMotorDataGridViewTextBoxColumn.Name = "numeroSerieMotorDataGridViewTextBoxColumn";
            this.numeroSerieMotorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tarjetaCirculacionDataGridViewTextBoxColumn
            // 
            this.tarjetaCirculacionDataGridViewTextBoxColumn.DataPropertyName = "TarjetaCirculacion";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.HeaderText = "TarjetaCirculacion";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.Name = "tarjetaCirculacionDataGridViewTextBoxColumn";
            this.tarjetaCirculacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placasDataGridViewTextBoxColumn
            // 
            this.placasDataGridViewTextBoxColumn.DataPropertyName = "Placas";
            this.placasDataGridViewTextBoxColumn.HeaderText = "Placas";
            this.placasDataGridViewTextBoxColumn.Name = "placasDataGridViewTextBoxColumn";
            this.placasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kilometrajeDataGridViewTextBoxColumn
            // 
            this.kilometrajeDataGridViewTextBoxColumn.DataPropertyName = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.HeaderText = "Kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.Name = "kilometrajeDataGridViewTextBoxColumn";
            this.kilometrajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadesBindingSource
            // 
            this.unidadesBindingSource.DataSource = typeof(SICASv20.Entities.Unidades);
            // 
            // PlacasTextBox
            // 
            this.PlacasTextBox.Location = new System.Drawing.Point(445, 71);
            this.PlacasTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PlacasTextBox.Name = "PlacasTextBox";
            this.PlacasTextBox.Size = new System.Drawing.Size(156, 24);
            this.PlacasTextBox.TabIndex = 4;
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(197, 71);
            this.NumeroEconomicoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(153, 24);
            this.NumeroEconomicoTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Placas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero Económico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Por favor, seleccione una unidad";
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Location = new System.Drawing.Point(1080, 620);
            this.SiguienteButton.Margin = new System.Windows.Forms.Padding(4);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(112, 37);
            this.SiguienteButton.TabIndex = 21;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // AtrasButton
            // 
            this.AtrasButton.Location = new System.Drawing.Point(960, 620);
            this.AtrasButton.Margin = new System.Windows.Forms.Padding(4);
            this.AtrasButton.Name = "AtrasButton";
            this.AtrasButton.Size = new System.Drawing.Size(112, 37);
            this.AtrasButton.TabIndex = 22;
            this.AtrasButton.Text = "Atrás";
            this.AtrasButton.UseVisualStyleBackColor = true;
            this.AtrasButton.Click += new System.EventHandler(this.AtrasButton_Click);
            // 
            // planesDeRentaBindingSource
            // 
            this.planesDeRentaBindingSource.DataSource = typeof(SICASv20.Entities.PlanesDeRenta);
            // 
            // PlanesDeRentaComboBox
            // 
            this.PlanesDeRentaComboBox.DataSource = this.planesDeRentaBindingSource;
            this.PlanesDeRentaComboBox.DisplayMember = "Descripcion";
            this.PlanesDeRentaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanesDeRentaComboBox.FormattingEnabled = true;
            this.PlanesDeRentaComboBox.Location = new System.Drawing.Point(275, 335);
            this.PlanesDeRentaComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PlanesDeRentaComboBox.Name = "PlanesDeRentaComboBox";
            this.PlanesDeRentaComboBox.Size = new System.Drawing.Size(352, 26);
            this.PlanesDeRentaComboBox.TabIndex = 15;
            this.PlanesDeRentaComboBox.ValueMember = "Activo";
            this.PlanesDeRentaComboBox.SelectedIndexChanged += new System.EventHandler(this.PlanesDeRentaComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 338);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Plan de renta:";
            // 
            // Contratos_DatosUnidad_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.AtrasButton);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Contratos_DatosUnidad_UC";
            this.Size = new System.Drawing.Size(1207, 679);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesDeRentaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox DiasDeCobroComboBox;
        private System.Windows.Forms.TextBox FondoResidualTextBox;
        private System.Windows.Forms.TextBox MontoDiarioTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView UnidadesGridView;
        private System.Windows.Forms.TextBox PlacasTextBox;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Button AtrasButton;
        private System.Windows.Forms.BindingSource diasDeCobrosBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioListaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSerieMotorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarjetaCirculacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placasDataGridViewTextBoxColumn;
	   private System.Windows.Forms.DataGridViewTextBoxColumn kilometrajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button BuscarButton;
	   internal System.Windows.Forms.BindingSource unidadesBindingSource;
       private System.Windows.Forms.BindingSource planesDeRentaBindingSource;
       private System.Windows.Forms.ComboBox PlanesDeRentaComboBox;
       private System.Windows.Forms.Label label7;
    }
}
