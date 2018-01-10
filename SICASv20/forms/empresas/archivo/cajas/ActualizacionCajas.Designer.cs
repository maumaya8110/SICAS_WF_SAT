namespace SICASv20.forms
{
    partial class ActualizacionCajas
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
            System.Windows.Forms.Label caja_IDLabel;
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label enClaveLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label impresionDobleLabel;
            System.Windows.Forms.Label imprimirFirmasLabel;
            System.Windows.Forms.Label nombreLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.activaCheckBox = new System.Windows.Forms.CheckBox();
            this.cajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja_IDTextBox = new System.Windows.Forms.TextBox();
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.enClaveCheckBox = new System.Windows.Forms.CheckBox();
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.impresionDobleCheckBox = new System.Windows.Forms.CheckBox();
            this.imprimirFirmasCheckBox = new System.Windows.Forms.CheckBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.selectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            activaLabel = new System.Windows.Forms.Label();
            caja_IDLabel = new System.Windows.Forms.Label();
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
            // activaLabel
            // 
            activaLabel.AutoSize = true;
            activaLabel.Location = new System.Drawing.Point(32, 241);
            activaLabel.Name = "activaLabel";
            activaLabel.Size = new System.Drawing.Size(41, 15);
            activaLabel.TabIndex = 0;
            activaLabel.Text = "Activa:";
            // 
            // caja_IDLabel
            // 
            caja_IDLabel.AutoSize = true;
            caja_IDLabel.Location = new System.Drawing.Point(32, 37);
            caja_IDLabel.Name = "caja_IDLabel";
            caja_IDLabel.Size = new System.Drawing.Size(50, 15);
            caja_IDLabel.TabIndex = 2;
            caja_IDLabel.Text = "Caja ID:";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(32, 91);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 4;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // enClaveLabel
            // 
            enClaveLabel.AutoSize = true;
            enClaveLabel.Location = new System.Drawing.Point(32, 151);
            enClaveLabel.Name = "enClaveLabel";
            enClaveLabel.Size = new System.Drawing.Size(58, 15);
            enClaveLabel.TabIndex = 6;
            enClaveLabel.Text = "En Clave:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(32, 120);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 8;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // impresionDobleLabel
            // 
            impresionDobleLabel.AutoSize = true;
            impresionDobleLabel.Location = new System.Drawing.Point(32, 181);
            impresionDobleLabel.Name = "impresionDobleLabel";
            impresionDobleLabel.Size = new System.Drawing.Size(101, 15);
            impresionDobleLabel.TabIndex = 10;
            impresionDobleLabel.Text = "Impresion Doble:";
            // 
            // imprimirFirmasLabel
            // 
            imprimirFirmasLabel.AutoSize = true;
            imprimirFirmasLabel.Location = new System.Drawing.Point(32, 211);
            imprimirFirmasLabel.Name = "imprimirFirmasLabel";
            imprimirFirmasLabel.Size = new System.Drawing.Size(97, 15);
            imprimirFirmasLabel.TabIndex = 12;
            imprimirFirmasLabel.Text = "Imprimir Firmas:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(32, 64);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 14;
            nombreLabel.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(activaLabel);
            this.groupBox1.Controls.Add(this.activaCheckBox);
            this.groupBox1.Controls.Add(caja_IDLabel);
            this.groupBox1.Controls.Add(this.caja_IDTextBox);
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
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de caja";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(244, 266);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(101, 30);
            this.GuardarButton.TabIndex = 16;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // activaCheckBox
            // 
            this.activaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "Activa", true));
            this.activaCheckBox.Location = new System.Drawing.Point(146, 236);
            this.activaCheckBox.Name = "activaCheckBox";
            this.activaCheckBox.Size = new System.Drawing.Size(121, 24);
            this.activaCheckBox.TabIndex = 1;
            this.activaCheckBox.UseVisualStyleBackColor = true;
            // 
            // cajasBindingSource
            // 
            this.cajasBindingSource.DataSource = typeof(SICASv20.Entities.Cajas);
            // 
            // caja_IDTextBox
            // 
            this.caja_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cajasBindingSource, "Caja_ID", true));
            this.caja_IDTextBox.Location = new System.Drawing.Point(146, 34);
            this.caja_IDTextBox.Name = "caja_IDTextBox";
            this.caja_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.caja_IDTextBox.TabIndex = 3;
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cajasBindingSource, "Empresa_ID", true));
            this.empresa_IDComboBox.DataSource = this.selectEmpresasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(146, 88);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(199, 23);
            this.empresa_IDComboBox.TabIndex = 5;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // enClaveCheckBox
            // 
            this.enClaveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "EnClave", true));
            this.enClaveCheckBox.Location = new System.Drawing.Point(146, 146);
            this.enClaveCheckBox.Name = "enClaveCheckBox";
            this.enClaveCheckBox.Size = new System.Drawing.Size(121, 24);
            this.enClaveCheckBox.TabIndex = 7;
            this.enClaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // estacion_IDComboBox
            // 
            this.estacion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cajasBindingSource, "Estacion_ID", true));
            this.estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(146, 117);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(199, 23);
            this.estacion_IDComboBox.TabIndex = 9;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // impresionDobleCheckBox
            // 
            this.impresionDobleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "ImpresionDoble", true));
            this.impresionDobleCheckBox.Location = new System.Drawing.Point(146, 176);
            this.impresionDobleCheckBox.Name = "impresionDobleCheckBox";
            this.impresionDobleCheckBox.Size = new System.Drawing.Size(121, 24);
            this.impresionDobleCheckBox.TabIndex = 11;
            this.impresionDobleCheckBox.UseVisualStyleBackColor = true;
            // 
            // imprimirFirmasCheckBox
            // 
            this.imprimirFirmasCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.cajasBindingSource, "ImprimirFirmas", true));
            this.imprimirFirmasCheckBox.Location = new System.Drawing.Point(146, 206);
            this.imprimirFirmasCheckBox.Name = "imprimirFirmasCheckBox";
            this.imprimirFirmasCheckBox.Size = new System.Drawing.Size(121, 24);
            this.imprimirFirmasCheckBox.TabIndex = 13;
            this.imprimirFirmasCheckBox.UseVisualStyleBackColor = true;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cajasBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(146, 61);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(199, 21);
            this.nombreTextBox.TabIndex = 15;
            // 
            // selectEmpresasBindingSource
            // 
            this.selectEmpresasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresas);
            // 
            // selectEstacionesBindingSource
            // 
            this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
            // 
            // ActualizacionCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActualizacionCajas";
            this.Text = "ActualizacionCajas";
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
        private System.Windows.Forms.CheckBox activaCheckBox;
        private System.Windows.Forms.BindingSource cajasBindingSource;
        private System.Windows.Forms.TextBox caja_IDTextBox;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.CheckBox enClaveCheckBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.CheckBox impresionDobleCheckBox;
        private System.Windows.Forms.CheckBox imprimirFirmasCheckBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource selectEmpresasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
    }
}