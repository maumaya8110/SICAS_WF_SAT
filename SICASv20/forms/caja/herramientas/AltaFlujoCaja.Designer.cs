namespace SICASv20.forms
{
    partial class AltaFlujoCaja
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.GuardarButton = new System.Windows.Forms.Button();
			this.MonedasComboBox = new System.Windows.Forms.ComboBox();
			this.monedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ConceptosComboBox = new System.Windows.Forms.ComboBox();
			this.CargoNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.AbonoNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.vista_SaldosFlujoCajaSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.vista_SaldosFlujoCajaSesionDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SaldosGpBox = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AbonoNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionDataGridView)).BeginInit();
			this.SaldosGpBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(454, 628);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Movimientos de Flujo de Caja";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.GuardarButton, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.MonedasComboBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.ConceptosComboBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.CargoNumericUpDown, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.AbonoNumericUpDown, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 34);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 175);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Moneda:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Margin = new System.Windows.Forms.Padding(6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Concepto:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 80);
			this.label3.Margin = new System.Windows.Forms.Padding(6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cargo:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 116);
			this.label4.Margin = new System.Windows.Forms.Padding(6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "Abono:";
			// 
			// GuardarButton
			// 
			this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GuardarButton.Location = new System.Drawing.Point(334, 152);
			this.GuardarButton.Margin = new System.Windows.Forms.Padding(6);
			this.GuardarButton.Name = "GuardarButton";
			this.GuardarButton.Size = new System.Drawing.Size(75, 30);
			this.GuardarButton.TabIndex = 4;
			this.GuardarButton.Text = "Guardar";
			this.GuardarButton.UseVisualStyleBackColor = true;
			this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
			// 
			// MonedasComboBox
			// 
			this.MonedasComboBox.DataSource = this.monedasBindingSource;
			this.MonedasComboBox.DisplayMember = "Nombre";
			this.MonedasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonedasComboBox.FormattingEnabled = true;
			this.MonedasComboBox.Location = new System.Drawing.Point(95, 6);
			this.MonedasComboBox.Margin = new System.Windows.Forms.Padding(6);
			this.MonedasComboBox.Name = "MonedasComboBox";
			this.MonedasComboBox.Size = new System.Drawing.Size(314, 26);
			this.MonedasComboBox.TabIndex = 5;
			this.MonedasComboBox.ValueMember = "Moneda_ID";
			this.MonedasComboBox.SelectionChangeCommitted += new System.EventHandler(this.MonedasComboBox_SelectionChangeCommitted);
			// 
			// monedasBindingSource
			// 
			this.monedasBindingSource.DataSource = typeof(SICASv20.Entities.Monedas);
			// 
			// ConceptosComboBox
			// 
			this.ConceptosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ConceptosComboBox.FormattingEnabled = true;
			this.ConceptosComboBox.Location = new System.Drawing.Point(95, 43);
			this.ConceptosComboBox.Margin = new System.Windows.Forms.Padding(6);
			this.ConceptosComboBox.Name = "ConceptosComboBox";
			this.ConceptosComboBox.Size = new System.Drawing.Size(314, 26);
			this.ConceptosComboBox.TabIndex = 6;
			this.ConceptosComboBox.SelectionChangeCommitted += new System.EventHandler(this.ConceptosComboBox_SelectionChangeCommitted);
			// 
			// CargoNumericUpDown
			// 
			this.CargoNumericUpDown.DecimalPlaces = 2;
			this.CargoNumericUpDown.Location = new System.Drawing.Point(95, 80);
			this.CargoNumericUpDown.Margin = new System.Windows.Forms.Padding(6);
			this.CargoNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.CargoNumericUpDown.Name = "CargoNumericUpDown";
			this.CargoNumericUpDown.Size = new System.Drawing.Size(120, 24);
			this.CargoNumericUpDown.TabIndex = 7;
			this.CargoNumericUpDown.ValueChanged += new System.EventHandler(this.CargoNumericUpDown_ValueChanged);
			// 
			// AbonoNumericUpDown
			// 
			this.AbonoNumericUpDown.DecimalPlaces = 2;
			this.AbonoNumericUpDown.Location = new System.Drawing.Point(95, 116);
			this.AbonoNumericUpDown.Margin = new System.Windows.Forms.Padding(6);
			this.AbonoNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.AbonoNumericUpDown.Name = "AbonoNumericUpDown";
			this.AbonoNumericUpDown.Size = new System.Drawing.Size(120, 24);
			this.AbonoNumericUpDown.TabIndex = 8;
			this.AbonoNumericUpDown.ValueChanged += new System.EventHandler(this.AbonoNumericUpDown_ValueChanged);
			// 
			// vista_SaldosFlujoCajaSesionBindingSource
			// 
			this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = typeof(SICASv20.Entities.Vista_SaldosFlujoCajaSesion);
			// 
			// vista_SaldosFlujoCajaSesionDataGridView
			// 
			this.vista_SaldosFlujoCajaSesionDataGridView.AllowUserToAddRows = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.AllowUserToDeleteRows = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.AutoGenerateColumns = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vista_SaldosFlujoCajaSesionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
			this.vista_SaldosFlujoCajaSesionDataGridView.DataSource = this.vista_SaldosFlujoCajaSesionBindingSource;
			this.vista_SaldosFlujoCajaSesionDataGridView.Location = new System.Drawing.Point(25, 34);
			this.vista_SaldosFlujoCajaSesionDataGridView.Name = "vista_SaldosFlujoCajaSesionDataGridView";
			this.vista_SaldosFlujoCajaSesionDataGridView.ReadOnly = true;
			this.vista_SaldosFlujoCajaSesionDataGridView.Size = new System.Drawing.Size(477, 578);
			this.vista_SaldosFlujoCajaSesionDataGridView.TabIndex = 1;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Moneda";
			this.dataGridViewTextBoxColumn1.HeaderText = "Moneda";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Saldo";
			this.dataGridViewTextBoxColumn2.HeaderText = "Saldo";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// SaldosGpBox
			// 
			this.SaldosGpBox.Controls.Add(this.vista_SaldosFlujoCajaSesionDataGridView);
			this.SaldosGpBox.Location = new System.Drawing.Point(483, 12);
			this.SaldosGpBox.Name = "SaldosGpBox";
			this.SaldosGpBox.Size = new System.Drawing.Size(517, 628);
			this.SaldosGpBox.TabIndex = 2;
			this.SaldosGpBox.TabStop = false;
			this.SaldosGpBox.Text = "Saldos";
			// 
			// AltaFlujoCaja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.SaldosGpBox);
			this.Controls.Add(this.groupBox1);
			this.Name = "AltaFlujoCaja";
			this.Text = "AltaFlujoCaja";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.SaldosGpBox, 0);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AbonoNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionDataGridView)).EndInit();
			this.SaldosGpBox.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource vista_SaldosFlujoCajaSesionBindingSource;
        private System.Windows.Forms.DataGridView vista_SaldosFlujoCajaSesionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox SaldosGpBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ComboBox MonedasComboBox;
        private System.Windows.Forms.ComboBox ConceptosComboBox;
        private System.Windows.Forms.NumericUpDown CargoNumericUpDown;
        private System.Windows.Forms.NumericUpDown AbonoNumericUpDown;
        private System.Windows.Forms.BindingSource monedasBindingSource;
    }
}