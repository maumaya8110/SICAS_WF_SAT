namespace SICASv20.forms
{
    partial class CancelacionValesPrepagados
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
			this.cboEmpresa = new System.Windows.Forms.ComboBox();
			this.empresasCASCOBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtFolioFinal = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtFolioInicial = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
			this.Label1 = new System.Windows.Forms.Label();
			this.cboClientes = new System.Windows.Forms.ComboBox();
			this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CancelarButton = new System.Windows.Forms.Button();
			this.TableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.empresasCASCOBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.TableLayoutPanel1.Controls.Add(this.cboEmpresa, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.label5, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Label3, 0, 4);
			this.TableLayoutPanel1.Controls.Add(this.txtFolioFinal, 1, 4);
			this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 3);
			this.TableLayoutPanel1.Controls.Add(this.txtFolioInicial, 1, 3);
			this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 2);
			this.TableLayoutPanel1.Controls.Add(this.dtpFechaEmision, 1, 2);
			this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.cboClientes, 1, 1);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(24, 38);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 5;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(563, 159);
			this.TableLayoutPanel1.TabIndex = 29;
			// 
			// cboEmpresa
			// 
			this.cboEmpresa.DataSource = this.empresasCASCOBindingSource;
			this.cboEmpresa.DisplayMember = "RazonSocial";
			this.cboEmpresa.FormattingEnabled = true;
			this.cboEmpresa.Location = new System.Drawing.Point(171, 3);
			this.cboEmpresa.Name = "cboEmpresa";
			this.cboEmpresa.Size = new System.Drawing.Size(389, 26);
			this.cboEmpresa.TabIndex = 9;
			this.cboEmpresa.ValueMember = "Empresa_ID";
			// 
			// empresasCASCOBindingSource
			// 
			this.empresasCASCOBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Empresa:";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(3, 124);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(80, 18);
			this.Label3.TabIndex = 3;
			this.Label3.Text = "Folio Final:";
			// 
			// txtFolioFinal
			// 
			this.txtFolioFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFolioFinal.Location = new System.Drawing.Point(171, 127);
			this.txtFolioFinal.Name = "txtFolioFinal";
			this.txtFolioFinal.Size = new System.Drawing.Size(100, 24);
			this.txtFolioFinal.TabIndex = 5;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(3, 93);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(85, 18);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Folio Inicial:";
			// 
			// txtFolioInicial
			// 
			this.txtFolioInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFolioInicial.Location = new System.Drawing.Point(171, 96);
			this.txtFolioInicial.Name = "txtFolioInicial";
			this.txtFolioInicial.Size = new System.Drawing.Size(100, 24);
			this.txtFolioInicial.TabIndex = 4;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(3, 62);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(111, 18);
			this.Label4.TabIndex = 6;
			this.Label4.Text = "Fecha Emisión:";
			// 
			// dtpFechaEmision
			// 
			this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaEmision.Location = new System.Drawing.Point(171, 65);
			this.dtpFechaEmision.Name = "dtpFechaEmision";
			this.dtpFechaEmision.Size = new System.Drawing.Size(146, 24);
			this.dtpFechaEmision.TabIndex = 7;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 31);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(57, 18);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Cliente:";
			// 
			// cboClientes
			// 
			this.cboClientes.DataSource = this.empresasBindingSource;
			this.cboClientes.DisplayMember = "RazonSocial";
			this.cboClientes.FormattingEnabled = true;
			this.cboClientes.Location = new System.Drawing.Point(171, 34);
			this.cboClientes.Name = "cboClientes";
			this.cboClientes.Size = new System.Drawing.Size(389, 26);
			this.cboClientes.TabIndex = 0;
			this.cboClientes.ValueMember = "Empresa_ID";
			// 
			// empresasBindingSource
			// 
			this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CancelarButton);
			this.groupBox1.Controls.Add(this.TableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(987, 321);
			this.groupBox1.TabIndex = 32;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cancelación de Vales Prepagados";
			// 
			// CancelarButton
			// 
			this.CancelarButton.Location = new System.Drawing.Point(463, 218);
			this.CancelarButton.Name = "CancelarButton";
			this.CancelarButton.Size = new System.Drawing.Size(121, 31);
			this.CancelarButton.TabIndex = 30;
			this.CancelarButton.Text = "Cancelar Vales";
			this.CancelarButton.UseVisualStyleBackColor = true;
			this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
			// 
			// CancelacionValesPrepagados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 652);
			this.Controls.Add(this.groupBox1);
			this.Name = "CancelacionValesPrepagados";
			this.Text = "CancelacionValesPrepagados";
			this.Load += new System.EventHandler(this.CancelacionValesPrepagados_Load);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.empresasCASCOBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.ComboBox cboClientes;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtFolioFinal;
        internal System.Windows.Forms.TextBox txtFolioInicial;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker dtpFechaEmision;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource empresasBindingSource;
	   internal System.Windows.Forms.ComboBox cboEmpresa;
	   internal System.Windows.Forms.Label label5;
	   private System.Windows.Forms.BindingSource empresasCASCOBindingSource;
    }
}