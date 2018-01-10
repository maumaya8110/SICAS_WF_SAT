namespace SICASv20.forms
{
    partial class AltaRefacciones
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
            System.Windows.Forms.Label anioLabel;
            System.Windows.Forms.Label marcaRefaccion_IDLabel;
            System.Windows.Forms.Label modelo_IDLabel;
            System.Windows.Forms.Label numeroSerialLabel;
            System.Windows.Forms.Label tipoRefaccion_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.anioTextBox = new System.Windows.Forms.TextBox();
            this.refaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoRefaccion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.tiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelo_IDComboBox = new System.Windows.Forms.ComboBox();
            this.modelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marcaRefaccion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.marcasRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numeroSerialTextBox = new System.Windows.Forms.TextBox();
            anioLabel = new System.Windows.Forms.Label();
            marcaRefaccion_IDLabel = new System.Windows.Forms.Label();
            modelo_IDLabel = new System.Windows.Forms.Label();
            numeroSerialLabel = new System.Windows.Forms.Label();
            tipoRefaccion_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasRefaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // anioLabel
            // 
            anioLabel.AutoSize = true;
            anioLabel.Location = new System.Drawing.Point(3, 81);
            anioLabel.Name = "anioLabel";
            anioLabel.Size = new System.Drawing.Size(34, 15);
            anioLabel.TabIndex = 0;
            anioLabel.Text = "Anio:";
            // 
            // marcaRefaccion_IDLabel
            // 
            marcaRefaccion_IDLabel.AutoSize = true;
            marcaRefaccion_IDLabel.Location = new System.Drawing.Point(3, 54);
            marcaRefaccion_IDLabel.Name = "marcaRefaccion_IDLabel";
            marcaRefaccion_IDLabel.Size = new System.Drawing.Size(118, 15);
            marcaRefaccion_IDLabel.TabIndex = 4;
            marcaRefaccion_IDLabel.Text = "Marca Refaccion ID:";
            // 
            // modelo_IDLabel
            // 
            modelo_IDLabel.AutoSize = true;
            modelo_IDLabel.Location = new System.Drawing.Point(3, 27);
            modelo_IDLabel.Name = "modelo_IDLabel";
            modelo_IDLabel.Size = new System.Drawing.Size(67, 15);
            modelo_IDLabel.TabIndex = 6;
            modelo_IDLabel.Text = "Modelo ID:";
            // 
            // numeroSerialLabel
            // 
            numeroSerialLabel.AutoSize = true;
            numeroSerialLabel.Location = new System.Drawing.Point(3, 108);
            numeroSerialLabel.Name = "numeroSerialLabel";
            numeroSerialLabel.Size = new System.Drawing.Size(90, 15);
            numeroSerialLabel.TabIndex = 8;
            numeroSerialLabel.Text = "Numero Serial:";
            // 
            // tipoRefaccion_IDLabel
            // 
            tipoRefaccion_IDLabel.AutoSize = true;
            tipoRefaccion_IDLabel.Location = new System.Drawing.Point(3, 0);
            tipoRefaccion_IDLabel.Name = "tipoRefaccion_IDLabel";
            tipoRefaccion_IDLabel.Size = new System.Drawing.Size(107, 15);
            tipoRefaccion_IDLabel.TabIndex = 12;
            tipoRefaccion_IDLabel.Text = "Tipo Refaccion ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta de Refacción";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(425, 194);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(98, 33);
            this.GuardarButton.TabIndex = 15;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.68924F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.31076F));
            this.tableLayoutPanel1.Controls.Add(tipoRefaccion_IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.anioTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(anioLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tipoRefaccion_IDComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(modelo_IDLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.modelo_IDComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(marcaRefaccion_IDLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.marcaRefaccion_IDComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numeroSerialTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(numeroSerialLabel, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 137);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // anioTextBox
            // 
            this.anioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.refaccionesBindingSource, "Anio", true));
            this.anioTextBox.Location = new System.Drawing.Point(141, 84);
            this.anioTextBox.Name = "anioTextBox";
            this.anioTextBox.Size = new System.Drawing.Size(121, 21);
            this.anioTextBox.TabIndex = 1;
            this.anioTextBox.TextChanged += new System.EventHandler(this.anioTextBox_TextChanged);
            // 
            // refaccionesBindingSource
            // 
            this.refaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Refacciones);
            // 
            // tipoRefaccion_IDComboBox
            // 
            this.tipoRefaccion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refaccionesBindingSource, "TipoRefaccion_ID", true));
            this.tipoRefaccion_IDComboBox.DataSource = this.tiposRefaccionesBindingSource;
            this.tipoRefaccion_IDComboBox.DisplayMember = "Nombre";
            this.tipoRefaccion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoRefaccion_IDComboBox.FormattingEnabled = true;
            this.tipoRefaccion_IDComboBox.Location = new System.Drawing.Point(141, 3);
            this.tipoRefaccion_IDComboBox.Name = "tipoRefaccion_IDComboBox";
            this.tipoRefaccion_IDComboBox.Size = new System.Drawing.Size(357, 23);
            this.tipoRefaccion_IDComboBox.TabIndex = 13;
            this.tipoRefaccion_IDComboBox.ValueMember = "TipoRefaccion_ID";
            this.tipoRefaccion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.tipoRefaccion_IDComboBox_SelectionChangeCommitted);
            // 
            // tiposRefaccionesBindingSource
            // 
            this.tiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposRefacciones);
            // 
            // modelo_IDComboBox
            // 
            this.modelo_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refaccionesBindingSource, "Modelo_ID", true));
            this.modelo_IDComboBox.DataSource = this.modelosBindingSource;
            this.modelo_IDComboBox.DisplayMember = "Nombre";
            this.modelo_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelo_IDComboBox.FormattingEnabled = true;
            this.modelo_IDComboBox.Location = new System.Drawing.Point(141, 30);
            this.modelo_IDComboBox.Name = "modelo_IDComboBox";
            this.modelo_IDComboBox.Size = new System.Drawing.Size(357, 23);
            this.modelo_IDComboBox.TabIndex = 7;
            this.modelo_IDComboBox.ValueMember = "Modelo_ID";
            this.modelo_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.modelo_IDComboBox_SelectionChangeCommitted);
            // 
            // modelosBindingSource
            // 
            this.modelosBindingSource.DataSource = typeof(SICASv20.Entities.Modelos);
            // 
            // marcaRefaccion_IDComboBox
            // 
            this.marcaRefaccion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refaccionesBindingSource, "MarcaRefaccion_ID", true));
            this.marcaRefaccion_IDComboBox.DataSource = this.marcasRefaccionesBindingSource;
            this.marcaRefaccion_IDComboBox.DisplayMember = "Nombre";
            this.marcaRefaccion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marcaRefaccion_IDComboBox.FormattingEnabled = true;
            this.marcaRefaccion_IDComboBox.Location = new System.Drawing.Point(141, 57);
            this.marcaRefaccion_IDComboBox.Name = "marcaRefaccion_IDComboBox";
            this.marcaRefaccion_IDComboBox.Size = new System.Drawing.Size(357, 23);
            this.marcaRefaccion_IDComboBox.TabIndex = 5;
            this.marcaRefaccion_IDComboBox.ValueMember = "MarcaRefaccion_ID";
            this.marcaRefaccion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.marcaRefaccion_IDComboBox_SelectionChangeCommitted);
            // 
            // marcasRefaccionesBindingSource
            // 
            this.marcasRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.MarcasRefacciones);
            // 
            // numeroSerialTextBox
            // 
            this.numeroSerialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.refaccionesBindingSource, "NumeroSerial", true));
            this.numeroSerialTextBox.Location = new System.Drawing.Point(141, 111);
            this.numeroSerialTextBox.Name = "numeroSerialTextBox";
            this.numeroSerialTextBox.Size = new System.Drawing.Size(121, 21);
            this.numeroSerialTextBox.TabIndex = 9;
            this.numeroSerialTextBox.TextChanged += new System.EventHandler(this.numeroSerialTextBox_TextChanged);
            // 
            // AltaRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaRefacciones";
            this.Text = "AltaRefacciones";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasRefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox numeroSerialTextBox;
        private System.Windows.Forms.BindingSource refaccionesBindingSource;
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.ComboBox tipoRefaccion_IDComboBox;
        private System.Windows.Forms.ComboBox modelo_IDComboBox;
        private System.Windows.Forms.ComboBox marcaRefaccion_IDComboBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource tiposRefaccionesBindingSource;
        private System.Windows.Forms.BindingSource modelosBindingSource;
        private System.Windows.Forms.BindingSource marcasRefaccionesBindingSource;
    }
}