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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 508);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistente de contratos: Unidades";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(510, 54);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 27);
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
            this.DiasDeCobroComboBox.Location = new System.Drawing.Point(214, 348);
            this.DiasDeCobroComboBox.Name = "DiasDeCobroComboBox";
            this.DiasDeCobroComboBox.Size = new System.Drawing.Size(267, 23);
            this.DiasDeCobroComboBox.TabIndex = 11;
            this.DiasDeCobroComboBox.ValueMember = "DiasDeCobro_ID";
            // 
            // diasDeCobrosBindingSource
            // 
            this.diasDeCobrosBindingSource.DataSource = typeof(SICASv20.Entities.DiasDeCobros);
            // 
            // FondoResidualTextBox
            // 
            this.FondoResidualTextBox.Location = new System.Drawing.Point(214, 321);
            this.FondoResidualTextBox.Name = "FondoResidualTextBox";
            this.FondoResidualTextBox.Size = new System.Drawing.Size(120, 21);
            this.FondoResidualTextBox.TabIndex = 10;
            // 
            // MontoDiarioTextBox
            // 
            this.MontoDiarioTextBox.Location = new System.Drawing.Point(214, 294);
            this.MontoDiarioTextBox.Name = "MontoDiarioTextBox";
            this.MontoDiarioTextBox.Size = new System.Drawing.Size(120, 21);
            this.MontoDiarioTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Capture los días de cobro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Capture el fondo residual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
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
            this.UnidadesGridView.Location = new System.Drawing.Point(19, 94);
            this.UnidadesGridView.Name = "UnidadesGridView";
            this.UnidadesGridView.ReadOnly = true;
            this.UnidadesGridView.Size = new System.Drawing.Size(886, 178);
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
            this.PlacasTextBox.Location = new System.Drawing.Point(346, 59);
            this.PlacasTextBox.Name = "PlacasTextBox";
            this.PlacasTextBox.Size = new System.Drawing.Size(122, 21);
            this.PlacasTextBox.TabIndex = 4;
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(153, 59);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(120, 21);
            this.NumeroEconomicoTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Placas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero Económico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Por favor, seleccione una unidad";
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Location = new System.Drawing.Point(840, 517);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 21;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // AtrasButton
            // 
            this.AtrasButton.Location = new System.Drawing.Point(747, 517);
            this.AtrasButton.Name = "AtrasButton";
            this.AtrasButton.Size = new System.Drawing.Size(87, 31);
            this.AtrasButton.TabIndex = 22;
            this.AtrasButton.Text = "Atrás";
            this.AtrasButton.UseVisualStyleBackColor = true;
            this.AtrasButton.Click += new System.EventHandler(this.AtrasButton_Click);
            // 
            // Contratos_DatosUnidad_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.AtrasButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Contratos_DatosUnidad_UC";
            this.Size = new System.Drawing.Size(939, 566);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource unidadesBindingSource;
        private System.Windows.Forms.Button BuscarButton;
    }
}
