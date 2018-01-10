namespace SICASv20.forms
{
    partial class CortesDeVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vista_CortesDeVentasDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.BoletosEspecialesCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ConsolidadoCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.vista_CortesDeVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConsultarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_CortesDeVentasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_CortesDeVentasBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vista_CortesDeVentasDataGridView);
            this.groupBox1.Controls.Add(this.ConsultarButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cortes de Ventas";
            // 
            // vista_CortesDeVentasDataGridView
            // 
            this.vista_CortesDeVentasDataGridView.AllowUserToAddRows = false;
            this.vista_CortesDeVentasDataGridView.AllowUserToDeleteRows = false;
            this.vista_CortesDeVentasDataGridView.AutoGenerateColumns = false;
            this.vista_CortesDeVentasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_CortesDeVentasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.VentaCol,
            this.BoletosEspecialesCol,
            this.ConsolidadoCol});
            this.vista_CortesDeVentasDataGridView.DataSource = this.vista_CortesDeVentasBindingSource;
            this.vista_CortesDeVentasDataGridView.Location = new System.Drawing.Point(12, 113);
            this.vista_CortesDeVentasDataGridView.Name = "vista_CortesDeVentasDataGridView";
            this.vista_CortesDeVentasDataGridView.ReadOnly = true;
            this.vista_CortesDeVentasDataGridView.Size = new System.Drawing.Size(960, 471);
            this.vista_CortesDeVentasDataGridView.TabIndex = 2;
            this.vista_CortesDeVentasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_CortesDeVentasDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Sesion_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Sesion_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Vendedor";
            this.dataGridViewTextBoxColumn4.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FechaInicial";
            this.dataGridViewTextBoxColumn5.HeaderText = "FechaInicial";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FechaFinal";
            this.dataGridViewTextBoxColumn6.HeaderText = "FechaFinal";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // VentaCol
            // 
            this.VentaCol.HeaderText = "Venta";
            this.VentaCol.Name = "VentaCol";
            this.VentaCol.ReadOnly = true;
            this.VentaCol.Text = "Ver";
            this.VentaCol.UseColumnTextForLinkValue = true;
            // 
            // BoletosEspecialesCol
            // 
            this.BoletosEspecialesCol.HeaderText = "Bol. Esp.";
            this.BoletosEspecialesCol.Name = "BoletosEspecialesCol";
            this.BoletosEspecialesCol.ReadOnly = true;
            this.BoletosEspecialesCol.Text = "Ver";
            this.BoletosEspecialesCol.UseColumnTextForLinkValue = true;
            // 
            // ConsolidadoCol
            // 
            this.ConsolidadoCol.DataPropertyName = "FechaCorte";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ConsolidadoCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.ConsolidadoCol.HeaderText = "Consolidado";
            this.ConsolidadoCol.Name = "ConsolidadoCol";
            this.ConsolidadoCol.ReadOnly = true;
            // 
            // vista_CortesDeVentasBindingSource
            // 
            this.vista_CortesDeVentasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_CortesDeVentas);
            // 
            // ConsultarButton
            // 
            this.ConsultarButton.Location = new System.Drawing.Point(652, 56);
            this.ConsultarButton.Name = "ConsultarButton";
            this.ConsultarButton.Size = new System.Drawing.Size(118, 36);
            this.ConsultarButton.TabIndex = 1;
            this.ConsultarButton.Text = "Consultar";
            this.ConsultarButton.UseVisualStyleBackColor = true;
            this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.FechaInicialDateTimePicker, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.FechaFinalDateTimePicker, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Estacion_IDComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.15254F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.84746F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FechaInicialDateTimePicker
            // 
            this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(453, 3);
            this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
            this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(147, 24);
            this.FechaInicialDateTimePicker.TabIndex = 2;
            this.FechaInicialDateTimePicker.ValueChanged += new System.EventHandler(this.FechaInicialDateTimePicker_ValueChanged);
            // 
            // FechaFinalDateTimePicker
            // 
            this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(453, 31);
            this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
            this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(147, 24);
            this.FechaFinalDateTimePicker.TabIndex = 3;
            this.FechaFinalDateTimePicker.ValueChanged += new System.EventHandler(this.FechaFinalDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Estacion:";
            // 
            // Estacion_IDComboBox
            // 
            this.Estacion_IDComboBox.DataSource = this.estacionesBindingSource;
            this.Estacion_IDComboBox.DisplayMember = "Nombre";
            this.Estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estacion_IDComboBox.FormattingEnabled = true;
            this.Estacion_IDComboBox.Location = new System.Drawing.Point(153, 3);
            this.Estacion_IDComboBox.Name = "Estacion_IDComboBox";
            this.Estacion_IDComboBox.Size = new System.Drawing.Size(144, 26);
            this.Estacion_IDComboBox.TabIndex = 15;
            this.Estacion_IDComboBox.ValueMember = "Estacion_ID";
            this.Estacion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.Estacion_IDComboBox_SelectionChangeCommitted);
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataMember = "Estaciones";
            // 
            // CortesDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "CortesDeVentas";
            this.Text = "CortesDeVentas";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vista_CortesDeVentasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_CortesDeVentasBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConsultarButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.DataGridView vista_CortesDeVentasDataGridView;
        private System.Windows.Forms.BindingSource vista_CortesDeVentasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewLinkColumn VentaCol;
        private System.Windows.Forms.DataGridViewLinkColumn BoletosEspecialesCol;
        private System.Windows.Forms.DataGridViewLinkColumn ConsolidadoCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Estacion_IDComboBox;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
    }
}