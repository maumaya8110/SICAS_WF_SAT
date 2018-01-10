namespace SICASv20.forms
{
    partial class AltaPlanillasFiscales
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
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DenominacionTextBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SerieTextBox = new System.Windows.Forms.TextBox();
            this.EmpresasComboBox = new System.Windows.Forms.ComboBox();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FolioFinalTextBox = new System.Windows.Forms.TextBox();
            this.FolioInicialTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutPanel2.Controls.Add(this.DenominacionTextBox, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.SerieTextBox, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.EmpresasComboBox, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.PrecioTextBox, 1, 3);
            this.TableLayoutPanel2.Controls.Add(this.EstacionesComboBox, 1, 6);
            this.TableLayoutPanel2.Controls.Add(this.FolioFinalTextBox, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.FolioInicialTextBox, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label1, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label6, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.Label5, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.label3, 0, 5);
            this.TableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.TableLayoutPanel2.Controls.Add(this.label4, 0, 6);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(19, 37);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 7;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28541F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2854F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2854F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2854F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2854F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2854F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28758F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(443, 202);
            this.TableLayoutPanel2.TabIndex = 25;
            // 
            // DenominacionTextBox
            // 
            this.DenominacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DenominacionTextBox.Location = new System.Drawing.Point(135, 115);
            this.DenominacionTextBox.Name = "DenominacionTextBox";
            this.DenominacionTextBox.Size = new System.Drawing.Size(112, 24);
            this.DenominacionTextBox.TabIndex = 5;
            this.DenominacionTextBox.TextChanged += new System.EventHandler(this.DenominacionTextBox_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(46, 18);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "Serie:";
            // 
            // SerieTextBox
            // 
            this.SerieTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SerieTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SerieTextBox.Location = new System.Drawing.Point(135, 3);
            this.SerieTextBox.Name = "SerieTextBox";
            this.SerieTextBox.Size = new System.Drawing.Size(69, 24);
            this.SerieTextBox.TabIndex = 1;
            this.SerieTextBox.TextChanged += new System.EventHandler(this.SerieTextBox_TextChanged);
            // 
            // EmpresasComboBox
            // 
            this.EmpresasComboBox.DataSource = this.empresasBindingSource;
            this.EmpresasComboBox.DisplayMember = "Nombre";
            this.EmpresasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmpresasComboBox.FormattingEnabled = true;
            this.EmpresasComboBox.Location = new System.Drawing.Point(135, 143);
            this.EmpresasComboBox.Name = "EmpresasComboBox";
            this.EmpresasComboBox.Size = new System.Drawing.Size(302, 26);
            this.EmpresasComboBox.TabIndex = 6;
            this.EmpresasComboBox.ValueMember = "Empresa_ID";
            this.EmpresasComboBox.SelectionChangeCommitted += new System.EventHandler(this.EmpresasComboBox_SelectionChangeCommitted);
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrecioTextBox.Location = new System.Drawing.Point(135, 87);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(112, 24);
            this.PrecioTextBox.TabIndex = 4;
            this.PrecioTextBox.TextChanged += new System.EventHandler(this.PrecioTextBox_TextChanged);
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(135, 171);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(302, 26);
            this.EstacionesComboBox.TabIndex = 7;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            this.EstacionesComboBox.SelectionChangeCommitted += new System.EventHandler(this.EstacionesComboBox_SelectionChangeCommitted);
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // FolioFinalTextBox
            // 
            this.FolioFinalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FolioFinalTextBox.Location = new System.Drawing.Point(135, 59);
            this.FolioFinalTextBox.Name = "FolioFinalTextBox";
            this.FolioFinalTextBox.Size = new System.Drawing.Size(112, 24);
            this.FolioFinalTextBox.TabIndex = 3;
            this.FolioFinalTextBox.TextChanged += new System.EventHandler(this.FolioFinalTextBox_TextChanged);
            // 
            // FolioInicialTextBox
            // 
            this.FolioInicialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FolioInicialTextBox.Location = new System.Drawing.Point(135, 31);
            this.FolioInicialTextBox.Name = "FolioInicialTextBox";
            this.FolioInicialTextBox.Size = new System.Drawing.Size(112, 24);
            this.FolioInicialTextBox.TabIndex = 2;
            this.FolioInicialTextBox.TextChanged += new System.EventHandler(this.FolioInicialTextBox_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 84);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 18);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Precio:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 56);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 18);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "Folio Final:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 28);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(85, 18);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Folio Inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Empresa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Denominación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Estacion:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AceptarButton);
            this.groupBox1.Controls.Add(this.TableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 349);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recepción de Planillas Fiscales";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(342, 245);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(120, 32);
            this.AceptarButton.TabIndex = 8;
            this.AceptarButton.Text = "Ingresar planillas";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // AltaPlanillasFiscales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaPlanillasFiscales";
            this.Text = "AltaPlanillasFiscales";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox SerieTextBox;
        internal System.Windows.Forms.TextBox PrecioTextBox;
        internal System.Windows.Forms.TextBox FolioFinalTextBox;
        internal System.Windows.Forms.TextBox FolioInicialTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AceptarButton;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EmpresasComboBox;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        internal System.Windows.Forms.TextBox DenominacionTextBox;
        internal System.Windows.Forms.Label label7;
    }
}