namespace SICASv20.forms
{
    partial class ContratosLiquidados
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
			this.vista_ContratosLiquidadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.vista_ContratosLiquidadosDataGridView = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.FechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.FechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.ConsultarButton = new System.Windows.Forms.Button();
			this.ExportButton = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.vista_ContratosLiquidadosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_ContratosLiquidadosDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// vista_ContratosLiquidadosBindingSource
			// 
			this.vista_ContratosLiquidadosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ContratosLiquidados);
			// 
			// vista_ContratosLiquidadosDataGridView
			// 
			this.vista_ContratosLiquidadosDataGridView.AllowUserToAddRows = false;
			this.vista_ContratosLiquidadosDataGridView.AllowUserToDeleteRows = false;
			this.vista_ContratosLiquidadosDataGridView.AutoGenerateColumns = false;
			this.vista_ContratosLiquidadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vista_ContratosLiquidadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Comentario,
            this.dataGridViewTextBoxColumn8,
            this.Estacion});
			this.vista_ContratosLiquidadosDataGridView.DataSource = this.vista_ContratosLiquidadosBindingSource;
			this.vista_ContratosLiquidadosDataGridView.Location = new System.Drawing.Point(18, 121);
			this.vista_ContratosLiquidadosDataGridView.Name = "vista_ContratosLiquidadosDataGridView";
			this.vista_ContratosLiquidadosDataGridView.ReadOnly = true;
			this.vista_ContratosLiquidadosDataGridView.Size = new System.Drawing.Size(938, 484);
			this.vista_ContratosLiquidadosDataGridView.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.vista_ContratosLiquidadosDataGridView);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(988, 628);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Contratos Liquidados";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Location = new System.Drawing.Point(18, 29);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(938, 73);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Búsqueda";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.FechaInicialDateTimePicker, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.FechaFinalDateTimePicker, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.ConsultarButton, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.ExportButton, 6, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 42);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fecha Inicial:";
			// 
			// FechaInicialDateTimePicker
			// 
			this.FechaInicialDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.FechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FechaInicialDateTimePicker.Location = new System.Drawing.Point(108, 9);
			this.FechaInicialDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
			this.FechaInicialDateTimePicker.Name = "FechaInicialDateTimePicker";
			this.FechaInicialDateTimePicker.Size = new System.Drawing.Size(109, 24);
			this.FechaInicialDateTimePicker.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(227, 12);
			this.label2.Margin = new System.Windows.Forms.Padding(5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Fecha Final:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FechaFinalDateTimePicker
			// 
			this.FechaFinalDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.FechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.FechaFinalDateTimePicker.Location = new System.Drawing.Point(325, 9);
			this.FechaFinalDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
			this.FechaFinalDateTimePicker.Name = "FechaFinalDateTimePicker";
			this.FechaFinalDateTimePicker.Size = new System.Drawing.Size(107, 24);
			this.FechaFinalDateTimePicker.TabIndex = 3;
			// 
			// ConsultarButton
			// 
			this.ConsultarButton.Location = new System.Drawing.Point(442, 5);
			this.ConsultarButton.Margin = new System.Windows.Forms.Padding(5);
			this.ConsultarButton.Name = "ConsultarButton";
			this.ConsultarButton.Size = new System.Drawing.Size(75, 32);
			this.ConsultarButton.TabIndex = 4;
			this.ConsultarButton.Text = "Consultar";
			this.ConsultarButton.UseVisualStyleBackColor = true;
			this.ConsultarButton.Click += new System.EventHandler(this.ConsultarButton_Click);
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(527, 5);
			this.ExportButton.Margin = new System.Windows.Forms.Padding(5);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(127, 32);
			this.ExportButton.TabIndex = 5;
			this.ExportButton.Text = "Exportar a MS Excel";
			this.ExportButton.UseVisualStyleBackColor = true;
			this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Folio";
			this.dataGridViewTextBoxColumn1.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Conductor";
			this.dataGridViewTextBoxColumn2.HeaderText = "Conductor";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Unidad";
			this.dataGridViewTextBoxColumn3.HeaderText = "Unidad";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "LocacionUnidad";
			this.dataGridViewTextBoxColumn4.HeaderText = "LocacionUnidad";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "EstatusConductor";
			this.dataGridViewTextBoxColumn5.HeaderText = "EstatusConductor";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "EstatusContrato";
			this.dataGridViewTextBoxColumn6.HeaderText = "EstatusContrato";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaLiquidacion";
			this.dataGridViewTextBoxColumn7.HeaderText = "FechaLiquidacion";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			// 
			// Comentario
			// 
			this.Comentario.DataPropertyName = "Comentario";
			this.Comentario.HeaderText = "Comentario";
			this.Comentario.Name = "Comentario";
			this.Comentario.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioLiquidacion";
			this.dataGridViewTextBoxColumn8.HeaderText = "UsuarioLiquidacion";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			// 
			// Estacion
			// 
			this.Estacion.DataPropertyName = "Estacion";
			this.Estacion.HeaderText = "Estacion";
			this.Estacion.Name = "Estacion";
			this.Estacion.ReadOnly = true;
			// 
			// ContratosLiquidados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "ContratosLiquidados";
			this.Text = "ContratosLiquidados";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.vista_ContratosLiquidadosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_ContratosLiquidadosDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource vista_ContratosLiquidadosBindingSource;
        private System.Windows.Forms.DataGridView vista_ContratosLiquidadosDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaInicialDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaFinalDateTimePicker;
        private System.Windows.Forms.Button ConsultarButton;
	   private System.Windows.Forms.Button ExportButton;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
	   private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
	   private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
	   private System.Windows.Forms.DataGridViewTextBoxColumn Estacion;
    }
}