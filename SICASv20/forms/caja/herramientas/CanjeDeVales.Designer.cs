namespace SICASv20.forms.caja.herramientas
{
	partial class CanjeDeVales
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
			this.SaldosGpBox = new System.Windows.Forms.GroupBox();
			this.vista_SaldosFlujoCajaSesionDataGridView = new System.Windows.Forms.DataGridView();
			this.monedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vista_SaldosFlujoCajaSesionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.GuardarButton = new System.Windows.Forms.Button();
			this.MonedasComboBox = new System.Windows.Forms.ComboBox();
			this.monedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.CargoNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.MaskedTextBox();
			this.txtSerie = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SaldosGpBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// SaldosGpBox
			// 
			this.SaldosGpBox.Controls.Add(this.vista_SaldosFlujoCajaSesionDataGridView);
			this.SaldosGpBox.Location = new System.Drawing.Point(489, 12);
			this.SaldosGpBox.Name = "SaldosGpBox";
			this.SaldosGpBox.Size = new System.Drawing.Size(517, 628);
			this.SaldosGpBox.TabIndex = 1;
			this.SaldosGpBox.TabStop = false;
			this.SaldosGpBox.Text = "Saldos";
			// 
			// vista_SaldosFlujoCajaSesionDataGridView
			// 
			this.vista_SaldosFlujoCajaSesionDataGridView.AllowUserToAddRows = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.AllowUserToDeleteRows = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.AutoGenerateColumns = false;
			this.vista_SaldosFlujoCajaSesionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vista_SaldosFlujoCajaSesionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monedaDataGridViewTextBoxColumn,
            this.saldoDataGridViewTextBoxColumn});
			this.vista_SaldosFlujoCajaSesionDataGridView.DataSource = this.vista_SaldosFlujoCajaSesionBindingSource;
			this.vista_SaldosFlujoCajaSesionDataGridView.Location = new System.Drawing.Point(25, 34);
			this.vista_SaldosFlujoCajaSesionDataGridView.Name = "vista_SaldosFlujoCajaSesionDataGridView";
			this.vista_SaldosFlujoCajaSesionDataGridView.ReadOnly = true;
			this.vista_SaldosFlujoCajaSesionDataGridView.Size = new System.Drawing.Size(477, 578);
			this.vista_SaldosFlujoCajaSesionDataGridView.TabIndex = 0;
			// 
			// monedaDataGridViewTextBoxColumn
			// 
			this.monedaDataGridViewTextBoxColumn.DataPropertyName = "Moneda";
			this.monedaDataGridViewTextBoxColumn.HeaderText = "Moneda";
			this.monedaDataGridViewTextBoxColumn.Name = "monedaDataGridViewTextBoxColumn";
			this.monedaDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// saldoDataGridViewTextBoxColumn
			// 
			this.saldoDataGridViewTextBoxColumn.DataPropertyName = "Saldo";
			this.saldoDataGridViewTextBoxColumn.HeaderText = "Saldo";
			this.saldoDataGridViewTextBoxColumn.Name = "saldoDataGridViewTextBoxColumn";
			this.saldoDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// vista_SaldosFlujoCajaSesionBindingSource
			// 
			this.vista_SaldosFlujoCajaSesionBindingSource.DataSource = typeof(SICASv20.Entities.Vista_SaldosFlujoCajaSesion);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(18, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(454, 628);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Movimientos de Flujo de Caja";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.GuardarButton, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.MonedasComboBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.CargoNumericUpDown, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtFolio, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtSerie, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 34);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 190);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tipo de Vale:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 116);
			this.label3.Margin = new System.Windows.Forms.Padding(6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "Monto:";
			// 
			// GuardarButton
			// 
			this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.GuardarButton, 3);
			this.GuardarButton.Location = new System.Drawing.Point(349, 152);
			this.GuardarButton.Margin = new System.Windows.Forms.Padding(6);
			this.GuardarButton.Name = "GuardarButton";
			this.GuardarButton.Size = new System.Drawing.Size(75, 30);
			this.GuardarButton.TabIndex = 8;
			this.GuardarButton.Text = "Guardar";
			this.GuardarButton.UseVisualStyleBackColor = true;
			this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
			// 
			// MonedasComboBox
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.MonedasComboBox, 3);
			this.MonedasComboBox.DataSource = this.monedasBindingSource;
			this.MonedasComboBox.DisplayMember = "Nombre";
			this.MonedasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonedasComboBox.FormattingEnabled = true;
			this.MonedasComboBox.Location = new System.Drawing.Point(111, 6);
			this.MonedasComboBox.Margin = new System.Windows.Forms.Padding(6);
			this.MonedasComboBox.Name = "MonedasComboBox";
			this.MonedasComboBox.Size = new System.Drawing.Size(313, 26);
			this.MonedasComboBox.TabIndex = 1;
			this.MonedasComboBox.ValueMember = "Moneda_ID";
			this.MonedasComboBox.SelectionChangeCommitted += new System.EventHandler(this.MonedasComboBox_SelectionChangeCommitted);
			// 
			// monedasBindingSource
			// 
			this.monedasBindingSource.DataSource = typeof(SICASv20.Entities.Monedas);
			// 
			// CargoNumericUpDown
			// 
			this.CargoNumericUpDown.DecimalPlaces = 2;
			this.CargoNumericUpDown.Location = new System.Drawing.Point(111, 116);
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
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 44);
			this.label5.Margin = new System.Windows.Forms.Padding(6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 18);
			this.label5.TabIndex = 2;
			this.label5.Text = "Serie:";
			// 
			// txtFolio
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.txtFolio, 2);
			this.txtFolio.Location = new System.Drawing.Point(111, 80);
			this.txtFolio.Margin = new System.Windows.Forms.Padding(6);
			this.txtFolio.Mask = "9999999999999999999999";
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(190, 24);
			this.txtFolio.TabIndex = 5;
			this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolio_KeyPress);
			// 
			// txtSerie
			// 
			this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSerie.Location = new System.Drawing.Point(111, 44);
			this.txtSerie.Margin = new System.Windows.Forms.Padding(6);
			this.txtSerie.MaxLength = 1;
			this.txtSerie.Name = "txtSerie";
			this.txtSerie.Size = new System.Drawing.Size(25, 24);
			this.txtSerie.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 80);
			this.label6.Margin = new System.Windows.Forms.Padding(6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 18);
			this.label6.TabIndex = 4;
			this.label6.Text = "Folio:";
			// 
			// CanjeDeVales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.SaldosGpBox);
			this.Controls.Add(this.groupBox1);
			this.Name = "CanjeDeVales";
			this.Text = "CanjeDeVales";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.SaldosGpBox, 0);
			this.SaldosGpBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_SaldosFlujoCajaSesionBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.monedasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CargoNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox SaldosGpBox;
		private System.Windows.Forms.DataGridView vista_SaldosFlujoCajaSesionDataGridView;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button GuardarButton;
		private System.Windows.Forms.ComboBox MonedasComboBox;
		private System.Windows.Forms.NumericUpDown CargoNumericUpDown;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MaskedTextBox txtFolio;
		private System.Windows.Forms.TextBox txtSerie;
		private System.Windows.Forms.BindingSource vista_SaldosFlujoCajaSesionBindingSource;
		private System.Windows.Forms.BindingSource monedasBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn monedaDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn saldoDataGridViewTextBoxColumn;
	}
}