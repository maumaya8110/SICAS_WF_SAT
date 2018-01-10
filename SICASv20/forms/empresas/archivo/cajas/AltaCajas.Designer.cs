namespace SICASv20.forms
{
    partial class AltaCajas
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
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label enClaveLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label impresionDobleLabel;
            System.Windows.Forms.Label imprimirFirmasLabel;
            System.Windows.Forms.Label nombreLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.enClaveCheckBox = new System.Windows.Forms.CheckBox();
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.impresionDobleCheckBox = new System.Windows.Forms.CheckBox();
            this.imprimirFirmasCheckBox = new System.Windows.Forms.CheckBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.cajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            empresa_IDLabel = new System.Windows.Forms.Label();
            enClaveLabel = new System.Windows.Forms.Label();
            estacion_IDLabel = new System.Windows.Forms.Label();
            impresionDobleLabel = new System.Windows.Forms.Label();
            imprimirFirmasLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Controls.Add(this.empresa_IDComboBox);
            this.groupBox1.Controls.Add(enClaveLabel);
            this.groupBox1.Controls.Add(this.enClaveCheckBox);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(this.estacion_IDComboBox);
            this.groupBox1.Controls.Add(impresionDobleLabel);
            this.groupBox1.Controls.Add(this.impresionDobleCheckBox);
            this.groupBox1.Controls.Add(imprimirFirmasLabel);
            this.groupBox1.Controls.Add(this.imprimirFirmasCheckBox);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 616);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de caja";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(25, 70);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(60, 15);
            empresa_IDLabel.TabIndex = 4;
            empresa_IDLabel.Text = "Empresa:";
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cajasBindingSource, "Empresa_ID", true));
            this.empresa_IDComboBox.DataSource = this.selectEmpresasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(132, 67);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(184, 23);
            this.empresa_IDComboBox.TabIndex = 5;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // enClaveLabel
            // 
            enClaveLabel.AutoSize = true;
            enClaveLabel.Location = new System.Drawing.Point(25, 130);
            enClaveLabel.Name = "enClaveLabel";
            enClaveLabel.Size = new System.Drawing.Size(58, 15);
            enClaveLabel.TabIndex = 6;
            enClaveLabel.Text = "En Clave:";
            // 
            // enClaveCheckBox
            // 
            this.enClaveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "EnClave", true));
            this.enClaveCheckBox.Location = new System.Drawing.Point(132, 125);
            this.enClaveCheckBox.Name = "enClaveCheckBox";
            this.enClaveCheckBox.Size = new System.Drawing.Size(121, 24);
            this.enClaveCheckBox.TabIndex = 7;
            this.enClaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(25, 99);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(57, 15);
            estacion_IDLabel.TabIndex = 8;
            estacion_IDLabel.Text = "Estacion:";
            // 
            // estacion_IDComboBox
            // 
            this.estacion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cajasBindingSource, "Estacion_ID", true));
            this.estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(132, 96);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(184, 23);
            this.estacion_IDComboBox.TabIndex = 9;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // impresionDobleLabel
            // 
            impresionDobleLabel.AutoSize = true;
            impresionDobleLabel.Location = new System.Drawing.Point(25, 160);
            impresionDobleLabel.Name = "impresionDobleLabel";
            impresionDobleLabel.Size = new System.Drawing.Size(101, 15);
            impresionDobleLabel.TabIndex = 10;
            impresionDobleLabel.Text = "Impresion Doble:";
            // 
            // impresionDobleCheckBox
            // 
            this.impresionDobleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "ImpresionDoble", true));
            this.impresionDobleCheckBox.Location = new System.Drawing.Point(132, 155);
            this.impresionDobleCheckBox.Name = "impresionDobleCheckBox";
            this.impresionDobleCheckBox.Size = new System.Drawing.Size(121, 24);
            this.impresionDobleCheckBox.TabIndex = 11;
            this.impresionDobleCheckBox.UseVisualStyleBackColor = true;
            // 
            // imprimirFirmasLabel
            // 
            imprimirFirmasLabel.AutoSize = true;
            imprimirFirmasLabel.Location = new System.Drawing.Point(25, 190);
            imprimirFirmasLabel.Name = "imprimirFirmasLabel";
            imprimirFirmasLabel.Size = new System.Drawing.Size(97, 15);
            imprimirFirmasLabel.TabIndex = 12;
            imprimirFirmasLabel.Text = "Imprimir Firmas:";
            // 
            // imprimirFirmasCheckBox
            // 
            this.imprimirFirmasCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "ImprimirFirmas", true));
            this.imprimirFirmasCheckBox.Location = new System.Drawing.Point(132, 185);
            this.imprimirFirmasCheckBox.Name = "imprimirFirmasCheckBox";
            this.imprimirFirmasCheckBox.Size = new System.Drawing.Size(121, 24);
            this.imprimirFirmasCheckBox.TabIndex = 13;
            this.imprimirFirmasCheckBox.UseVisualStyleBackColor = true;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(25, 43);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 14;
            nombreLabel.Text = "Nombre:";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cajasBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(132, 40);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(121, 21);
            this.nombreTextBox.TabIndex = 15;
            // 
            // cajasBindingSource
            // 
            this.cajasBindingSource.DataSource = typeof(SICASv20.Entities.Cajas);
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(235, 215);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(81, 31);
            this.GuardarButton.TabIndex = 16;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // AltaCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaCajas";
            this.Text = "AltaCajas";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource cajasBindingSource;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.CheckBox enClaveCheckBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.CheckBox impresionDobleCheckBox;
        private System.Windows.Forms.CheckBox imprimirFirmasCheckBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.Button GuardarButton;
    }
}