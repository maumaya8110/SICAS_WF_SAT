namespace SICASv20.forms
{
    partial class AltaValesPrepagados
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
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.EmpresasCASCOComboBox = new System.Windows.Forms.ComboBox();
			this.empresasGrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtDenominacion = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.EmpresasClientesComboBox = new System.Windows.Forms.ComboBox();
			this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.AceptarButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.vista_ValesPrepagadosDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vista_ValesPrepagadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ImprimirButton = new System.Windows.Forms.Button();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.TableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.empresasGrupoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vista_ValesPrepagadosDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_ValesPrepagadosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.TableLayoutPanel1.Controls.Add(this.EmpresasCASCOComboBox, 1, 0);
			this.TableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Label3, 0, 3);
			this.TableLayoutPanel1.Controls.Add(this.txtCantidad, 1, 3);
			this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
			this.TableLayoutPanel1.Controls.Add(this.txtDenominacion, 1, 2);
			this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.EmpresasClientesComboBox, 1, 1);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(21, 36);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 4;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(563, 122);
			this.TableLayoutPanel1.TabIndex = 22;
			// 
			// EmpresasCASCOComboBox
			// 
			this.EmpresasCASCOComboBox.DataSource = this.empresasGrupoBindingSource;
			this.EmpresasCASCOComboBox.DisplayMember = "RazonSocial";
			this.EmpresasCASCOComboBox.FormattingEnabled = true;
			this.EmpresasCASCOComboBox.Location = new System.Drawing.Point(171, 3);
			this.EmpresasCASCOComboBox.Name = "EmpresasCASCOComboBox";
			this.EmpresasCASCOComboBox.Size = new System.Drawing.Size(389, 26);
			this.EmpresasCASCOComboBox.TabIndex = 1;
			this.EmpresasCASCOComboBox.ValueMember = "Empresa_ID";
			this.EmpresasCASCOComboBox.SelectedIndexChanged += new System.EventHandler(this.EmpresasCASCOComboBox_SelectedIndexChanged);
			this.EmpresasCASCOComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresasCASCOComboBox_SelectionChangeCommitted);
			// 
			// empresasGrupoBindingSource
			// 
			this.empresasGrupoBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "Empresa:";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(3, 93);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(70, 18);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Cantidad:";
			// 
			// txtCantidad
			// 
			this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCantidad.Location = new System.Drawing.Point(171, 96);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(100, 24);
			this.txtCantidad.TabIndex = 7;
			this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(3, 62);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(108, 18);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Denominación:";
			// 
			// txtDenominacion
			// 
			this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDenominacion.Location = new System.Drawing.Point(171, 65);
			this.txtDenominacion.Name = "txtDenominacion";
			this.txtDenominacion.Size = new System.Drawing.Size(100, 24);
			this.txtDenominacion.TabIndex = 5;
			this.txtDenominacion.TextChanged += new System.EventHandler(this.txtDenominacion_TextChanged);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 31);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(57, 18);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Cliente:";
			// 
			// EmpresasClientesComboBox
			// 
			this.EmpresasClientesComboBox.DataSource = this.empresasBindingSource;
			this.EmpresasClientesComboBox.DisplayMember = "RazonSocial";
			this.EmpresasClientesComboBox.FormattingEnabled = true;
			this.EmpresasClientesComboBox.Location = new System.Drawing.Point(171, 34);
			this.EmpresasClientesComboBox.Name = "EmpresasClientesComboBox";
			this.EmpresasClientesComboBox.Size = new System.Drawing.Size(389, 26);
			this.EmpresasClientesComboBox.TabIndex = 3;
			this.EmpresasClientesComboBox.ValueMember = "Empresa_ID";
			this.EmpresasClientesComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresas_SelectedIndexChanged);
			this.EmpresasClientesComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresasClientesComboBox_SelectionChangeCommitted);
			// 
			// empresasBindingSource
			// 
			this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
			// 
			// AceptarButton
			// 
			this.AceptarButton.Location = new System.Drawing.Point(353, 182);
			this.AceptarButton.Name = "AceptarButton";
			this.AceptarButton.Size = new System.Drawing.Size(113, 29);
			this.AceptarButton.TabIndex = 0;
			this.AceptarButton.Text = "Crear vales";
			this.AceptarButton.UseVisualStyleBackColor = true;
			this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.vista_ValesPrepagadosDataGridView);
			this.groupBox1.Controls.Add(this.ImprimirButton);
			this.groupBox1.Controls.Add(this.TableLayoutPanel1);
			this.groupBox1.Controls.Add(this.AceptarButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(978, 616);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Creación de vales prepagados";
			// 
			// vista_ValesPrepagadosDataGridView
			// 
			this.vista_ValesPrepagadosDataGridView.AutoGenerateColumns = false;
			this.vista_ValesPrepagadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vista_ValesPrepagadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
			this.vista_ValesPrepagadosDataGridView.DataSource = this.vista_ValesPrepagadosBindingSource;
			this.vista_ValesPrepagadosDataGridView.Location = new System.Drawing.Point(21, 225);
			this.vista_ValesPrepagadosDataGridView.Name = "vista_ValesPrepagadosDataGridView";
			this.vista_ValesPrepagadosDataGridView.Size = new System.Drawing.Size(560, 370);
			this.vista_ValesPrepagadosDataGridView.TabIndex = 2;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
			this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "FolioDiario";
			this.dataGridViewTextBoxColumn2.HeaderText = "FolioDiario";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "RazonSocial";
			this.dataGridViewTextBoxColumn3.HeaderText = "RazonSocial";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Denominacion";
			this.dataGridViewTextBoxColumn4.HeaderText = "Denominacion";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "CantidadConLetra";
			this.dataGridViewTextBoxColumn5.HeaderText = "CantidadConLetra";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "FechaEmision";
			this.dataGridViewTextBoxColumn6.HeaderText = "FechaEmision";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "FechaExpiracion";
			this.dataGridViewTextBoxColumn7.HeaderText = "FechaExpiracion";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "FechaCanje";
			this.dataGridViewTextBoxColumn8.HeaderText = "FechaCanje";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Ticket_ID";
			this.dataGridViewTextBoxColumn9.HeaderText = "Ticket_ID";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Usuario_ID";
			this.dataGridViewTextBoxColumn10.HeaderText = "Usuario_ID";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Estatus";
			this.dataGridViewTextBoxColumn11.HeaderText = "Estatus";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			// 
			// vista_ValesPrepagadosBindingSource
			// 
			this.vista_ValesPrepagadosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ValesPrepagados);
			// 
			// ImprimirButton
			// 
			this.ImprimirButton.Location = new System.Drawing.Point(472, 182);
			this.ImprimirButton.Name = "ImprimirButton";
			this.ImprimirButton.Size = new System.Drawing.Size(113, 29);
			this.ImprimirButton.TabIndex = 1;
			this.ImprimirButton.Text = "Imprimir Vales";
			this.ImprimirButton.UseVisualStyleBackColor = true;
			this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
			// 
			// AltaValesPrepagados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "AltaValesPrepagados";
			this.Text = "AltaValesPrepagados";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.empresasGrupoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vista_ValesPrepagadosDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vista_ValesPrepagadosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.ComboBox EmpresasClientesComboBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtDenominacion;
        internal System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.DataGridView vista_ValesPrepagadosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.BindingSource vista_ValesPrepagadosBindingSource;
	   private System.Windows.Forms.ComboBox EmpresasCASCOComboBox;
	   private System.Windows.Forms.Label label4;
	   private System.Windows.Forms.BindingSource bindingSource1;
	   private System.Windows.Forms.BindingSource empresasGrupoBindingSource;
    }
}