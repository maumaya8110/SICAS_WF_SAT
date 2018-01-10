namespace SICASv20.forms
{
    partial class ConfiguracionesDeCaja
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
            System.Windows.Forms.Label activaLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label enClaveLabel;
            System.Windows.Forms.Label estacionLabel;
            System.Windows.Forms.Label impresionDobleLabel;
            System.Windows.Forms.Label nombreLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.impresionDobleCheckBox = new System.Windows.Forms.CheckBox();
            this.vista_CajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enClaveCheckBox = new System.Windows.Forms.CheckBox();
            this.activaCheckBox = new System.Windows.Forms.CheckBox();
            this.empresaTextBox = new System.Windows.Forms.TextBox();
            this.estacionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            activaLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            enClaveLabel = new System.Windows.Forms.Label();
            estacionLabel = new System.Windows.Forms.Label();
            impresionDobleLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_CajasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // activaLabel
            // 
            activaLabel.AutoSize = true;
            activaLabel.Location = new System.Drawing.Point(3, 90);
            activaLabel.Name = "activaLabel";
            activaLabel.Size = new System.Drawing.Size(41, 15);
            activaLabel.TabIndex = 0;
            activaLabel.Text = "Activa:";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new System.Drawing.Point(3, 0);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(60, 15);
            empresaLabel.TabIndex = 4;
            empresaLabel.Text = "Empresa:";
            // 
            // enClaveLabel
            // 
            enClaveLabel.AutoSize = true;
            enClaveLabel.Location = new System.Drawing.Point(3, 120);
            enClaveLabel.Name = "enClaveLabel";
            enClaveLabel.Size = new System.Drawing.Size(58, 15);
            enClaveLabel.TabIndex = 6;
            enClaveLabel.Text = "En Clave:";
            // 
            // estacionLabel
            // 
            estacionLabel.AutoSize = true;
            estacionLabel.Location = new System.Drawing.Point(3, 30);
            estacionLabel.Name = "estacionLabel";
            estacionLabel.Size = new System.Drawing.Size(57, 15);
            estacionLabel.TabIndex = 8;
            estacionLabel.Text = "Estacion:";
            // 
            // impresionDobleLabel
            // 
            impresionDobleLabel.AutoSize = true;
            impresionDobleLabel.Location = new System.Drawing.Point(3, 150);
            impresionDobleLabel.Name = "impresionDobleLabel";
            impresionDobleLabel.Size = new System.Drawing.Size(101, 15);
            impresionDobleLabel.TabIndex = 10;
            impresionDobleLabel.Text = "Impresion Doble:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(3, 60);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 12;
            nombreLabel.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuracion de caja";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(325, 243);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(91, 36);
            this.GuardarButton.TabIndex = 15;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(empresaLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.impresionDobleCheckBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(impresionDobleLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.enClaveCheckBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(enClaveLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.activaCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(activaLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.empresaTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(estacionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.estacionTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(nombreLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nombreTextBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 184);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // impresionDobleCheckBox
            // 
            this.impresionDobleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.vista_CajasBindingSource, "ImpresionDoble", true));
            this.impresionDobleCheckBox.Location = new System.Drawing.Point(110, 153);
            this.impresionDobleCheckBox.Name = "impresionDobleCheckBox";
            this.impresionDobleCheckBox.Size = new System.Drawing.Size(36, 24);
            this.impresionDobleCheckBox.TabIndex = 11;
            this.impresionDobleCheckBox.UseVisualStyleBackColor = true;
            // 
            // vista_CajasBindingSource
            // 
            this.vista_CajasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Cajas);
            // 
            // enClaveCheckBox
            // 
            this.enClaveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.vista_CajasBindingSource, "EnClave", true));
            this.enClaveCheckBox.Location = new System.Drawing.Point(110, 123);
            this.enClaveCheckBox.Name = "enClaveCheckBox";
            this.enClaveCheckBox.Size = new System.Drawing.Size(36, 24);
            this.enClaveCheckBox.TabIndex = 7;
            this.enClaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // activaCheckBox
            // 
            this.activaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.vista_CajasBindingSource, "Activa", true));
            this.activaCheckBox.Location = new System.Drawing.Point(110, 93);
            this.activaCheckBox.Name = "activaCheckBox";
            this.activaCheckBox.Size = new System.Drawing.Size(36, 24);
            this.activaCheckBox.TabIndex = 1;
            this.activaCheckBox.UseVisualStyleBackColor = true;
            // 
            // empresaTextBox
            // 
            this.empresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_CajasBindingSource, "Empresa", true));
            this.empresaTextBox.Location = new System.Drawing.Point(110, 3);
            this.empresaTextBox.Name = "empresaTextBox";
            this.empresaTextBox.Size = new System.Drawing.Size(248, 21);
            this.empresaTextBox.TabIndex = 5;
            // 
            // estacionTextBox
            // 
            this.estacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_CajasBindingSource, "Estacion", true));
            this.estacionTextBox.Location = new System.Drawing.Point(110, 33);
            this.estacionTextBox.Name = "estacionTextBox";
            this.estacionTextBox.Size = new System.Drawing.Size(248, 21);
            this.estacionTextBox.TabIndex = 9;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_CajasBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(110, 63);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(248, 21);
            this.nombreTextBox.TabIndex = 13;
            // 
            // ConfiguracionesDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfiguracionesDeCaja";
            this.Text = "ConfiguracionesDeCaja";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_CajasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox impresionDobleCheckBox;
        private System.Windows.Forms.BindingSource vista_CajasBindingSource;
        private System.Windows.Forms.CheckBox enClaveCheckBox;
        private System.Windows.Forms.CheckBox activaCheckBox;
        private System.Windows.Forms.TextBox empresaTextBox;
        private System.Windows.Forms.TextBox estacionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
    }
}