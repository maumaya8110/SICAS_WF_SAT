namespace SICASv20.forms
{
    partial class ActualizacionPlanesDeRenta
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
            this.PlanesDeRentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ModelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DiasDeCobrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.PlanDeRenta_IDLabel = new System.Windows.Forms.Label();
            this.PlanDeRenta_IDTextBox = new System.Windows.Forms.TextBox();
            this.ModeloUnidad_IDLabel = new System.Windows.Forms.Label();
            this.ModeloUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
            this.DiasDeCobro_IDLabel = new System.Windows.Forms.Label();
            this.DiasDeCobro_IDComboBox = new System.Windows.Forms.ComboBox();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.RentaBaseLabel = new System.Windows.Forms.Label();
            this.RentaBaseTextBox = new System.Windows.Forms.TextBox();
            this.FondoResidualLabel = new System.Windows.Forms.Label();
            this.FondoResidualTextBox = new System.Windows.Forms.TextBox();
            this.ActivoLabel = new System.Windows.Forms.Label();
            this.ActivoCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EstacionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PlanesDeRentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelosUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiasDeCobrosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanesDeRentaBindingSource
            // 
            this.PlanesDeRentaBindingSource.DataSource = typeof(SICASv20.Entities.PlanesDeRenta);
            // 
            // ModelosUnidadesBindingSource
            // 
            this.ModelosUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.ModelosUnidades);
            // 
            // UsuariosBindingSource
            // 
            this.UsuariosBindingSource.DataSource = typeof(SICASv20.Entities.Usuarios);
            // 
            // DiasDeCobrosBindingSource
            // 
            this.DiasDeCobrosBindingSource.DataSource = typeof(SICASv20.Entities.DiasDeCobros);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(511, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 22;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(511, 70);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 21;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // PlanDeRenta_IDLabel
            // 
            this.PlanDeRenta_IDLabel.AutoSize = true;
            this.PlanDeRenta_IDLabel.Location = new System.Drawing.Point(16, 31);
            this.PlanDeRenta_IDLabel.Name = "PlanDeRenta_IDLabel";
            this.PlanDeRenta_IDLabel.Size = new System.Drawing.Size(105, 15);
            this.PlanDeRenta_IDLabel.TabIndex = 1;
            this.PlanDeRenta_IDLabel.Text = "Plan De Renta ID:";
            // 
            // PlanDeRenta_IDTextBox
            // 
            this.PlanDeRenta_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PlanesDeRentaBindingSource, "PlanDeRenta_ID", true));
            this.PlanDeRenta_IDTextBox.Location = new System.Drawing.Point(201, 31);
            this.PlanDeRenta_IDTextBox.Name = "PlanDeRenta_IDTextBox";
            this.PlanDeRenta_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.PlanDeRenta_IDTextBox.TabIndex = 2;
            // 
            // ModeloUnidad_IDLabel
            // 
            this.ModeloUnidad_IDLabel.AutoSize = true;
            this.ModeloUnidad_IDLabel.Location = new System.Drawing.Point(16, 85);
            this.ModeloUnidad_IDLabel.Name = "ModeloUnidad_IDLabel";
            this.ModeloUnidad_IDLabel.Size = new System.Drawing.Size(112, 15);
            this.ModeloUnidad_IDLabel.TabIndex = 3;
            this.ModeloUnidad_IDLabel.Text = "Modelo de Unidad:";
            // 
            // ModeloUnidad_IDComboBox
            // 
            this.ModeloUnidad_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.PlanesDeRentaBindingSource, "ModeloUnidad_ID", true));
            this.ModeloUnidad_IDComboBox.DataSource = this.ModelosUnidadesBindingSource;
            this.ModeloUnidad_IDComboBox.DisplayMember = "Descripcion";
            this.ModeloUnidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeloUnidad_IDComboBox.FormattingEnabled = true;
            this.ModeloUnidad_IDComboBox.Location = new System.Drawing.Point(201, 85);
            this.ModeloUnidad_IDComboBox.Name = "ModeloUnidad_IDComboBox";
            this.ModeloUnidad_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.ModeloUnidad_IDComboBox.TabIndex = 4;
            this.ModeloUnidad_IDComboBox.ValueMember = "ModeloUnidad_ID";
            // 
            // DiasDeCobro_IDLabel
            // 
            this.DiasDeCobro_IDLabel.AutoSize = true;
            this.DiasDeCobro_IDLabel.Location = new System.Drawing.Point(16, 112);
            this.DiasDeCobro_IDLabel.Name = "DiasDeCobro_IDLabel";
            this.DiasDeCobro_IDLabel.Size = new System.Drawing.Size(87, 15);
            this.DiasDeCobro_IDLabel.TabIndex = 7;
            this.DiasDeCobro_IDLabel.Text = "DiasDeCobro :";
            // 
            // DiasDeCobro_IDComboBox
            // 
            this.DiasDeCobro_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.PlanesDeRentaBindingSource, "DiasDeCobro_ID", true));
            this.DiasDeCobro_IDComboBox.DataSource = this.DiasDeCobrosBindingSource;
            this.DiasDeCobro_IDComboBox.DisplayMember = "Nombre";
            this.DiasDeCobro_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiasDeCobro_IDComboBox.FormattingEnabled = true;
            this.DiasDeCobro_IDComboBox.Location = new System.Drawing.Point(201, 112);
            this.DiasDeCobro_IDComboBox.Name = "DiasDeCobro_IDComboBox";
            this.DiasDeCobro_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.DiasDeCobro_IDComboBox.TabIndex = 8;
            this.DiasDeCobro_IDComboBox.ValueMember = "DiasDeCobro_ID";
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Location = new System.Drawing.Point(16, 139);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(75, 15);
            this.DescripcionLabel.TabIndex = 9;
            this.DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PlanesDeRentaBindingSource, "Descripcion", true));
            this.DescripcionTextBox.Location = new System.Drawing.Point(201, 139);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(150, 21);
            this.DescripcionTextBox.TabIndex = 10;
            // 
            // RentaBaseLabel
            // 
            this.RentaBaseLabel.AutoSize = true;
            this.RentaBaseLabel.Location = new System.Drawing.Point(16, 166);
            this.RentaBaseLabel.Name = "RentaBaseLabel";
            this.RentaBaseLabel.Size = new System.Drawing.Size(74, 15);
            this.RentaBaseLabel.TabIndex = 11;
            this.RentaBaseLabel.Text = "Renta Base:";
            // 
            // RentaBaseTextBox
            // 
            this.RentaBaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PlanesDeRentaBindingSource, "RentaBase", true));
            this.RentaBaseTextBox.Location = new System.Drawing.Point(201, 166);
            this.RentaBaseTextBox.Name = "RentaBaseTextBox";
            this.RentaBaseTextBox.Size = new System.Drawing.Size(150, 21);
            this.RentaBaseTextBox.TabIndex = 12;
            // 
            // FondoResidualLabel
            // 
            this.FondoResidualLabel.AutoSize = true;
            this.FondoResidualLabel.Location = new System.Drawing.Point(16, 193);
            this.FondoResidualLabel.Name = "FondoResidualLabel";
            this.FondoResidualLabel.Size = new System.Drawing.Size(97, 15);
            this.FondoResidualLabel.TabIndex = 13;
            this.FondoResidualLabel.Text = "Fondo Residual:";
            // 
            // FondoResidualTextBox
            // 
            this.FondoResidualTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PlanesDeRentaBindingSource, "FondoResidual", true));
            this.FondoResidualTextBox.Location = new System.Drawing.Point(201, 193);
            this.FondoResidualTextBox.Name = "FondoResidualTextBox";
            this.FondoResidualTextBox.Size = new System.Drawing.Size(150, 21);
            this.FondoResidualTextBox.TabIndex = 14;
            // 
            // ActivoLabel
            // 
            this.ActivoLabel.AutoSize = true;
            this.ActivoLabel.Location = new System.Drawing.Point(13, 219);
            this.ActivoLabel.Name = "ActivoLabel";
            this.ActivoLabel.Size = new System.Drawing.Size(41, 15);
            this.ActivoLabel.TabIndex = 18;
            this.ActivoLabel.Text = "Activo:";
            // 
            // ActivoCheckBox
            // 
            this.ActivoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.PlanesDeRentaBindingSource, "Activo", true));
            this.ActivoCheckBox.Location = new System.Drawing.Point(201, 219);
            this.ActivoCheckBox.Name = "ActivoCheckBox";
            this.ActivoCheckBox.Size = new System.Drawing.Size(21, 21);
            this.ActivoCheckBox.TabIndex = 19;
            this.ActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EstacionComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ModeloUnidad_IDComboBox);
            this.groupBox1.Controls.Add(this.PlanDeRenta_IDLabel);
            this.groupBox1.Controls.Add(this.ActivoCheckBox);
            this.groupBox1.Controls.Add(this.ActivoLabel);
            this.groupBox1.Controls.Add(this.PlanDeRenta_IDTextBox);
            this.groupBox1.Controls.Add(this.ModeloUnidad_IDLabel);
            this.groupBox1.Controls.Add(this.FondoResidualTextBox);
            this.groupBox1.Controls.Add(this.FondoResidualLabel);
            this.groupBox1.Controls.Add(this.DiasDeCobro_IDLabel);
            this.groupBox1.Controls.Add(this.RentaBaseTextBox);
            this.groupBox1.Controls.Add(this.DiasDeCobro_IDComboBox);
            this.groupBox1.Controls.Add(this.RentaBaseLabel);
            this.groupBox1.Controls.Add(this.DescripcionLabel);
            this.groupBox1.Controls.Add(this.DescripcionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 275);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de Plan de Renta";
            // 
            // EstacionComboBox
            // 
            this.EstacionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.PlanesDeRentaBindingSource, "Estacion_ID", true));
            this.EstacionComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionComboBox.DisplayMember = "Nombre";
            this.EstacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionComboBox.FormattingEnabled = true;
            this.EstacionComboBox.Location = new System.Drawing.Point(201, 57);
            this.EstacionComboBox.Name = "EstacionComboBox";
            this.EstacionComboBox.Size = new System.Drawing.Size(200, 23);
            this.EstacionComboBox.TabIndex = 21;
            this.EstacionComboBox.ValueMember = "Estacion_ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Estacion:";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // ActualizacionPlanesDeRenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionPlanesDeRenta";
            this.Text = "AltaPlanesDeRenta";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PlanesDeRentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelosUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiasDeCobrosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label PlanDeRenta_IDLabel;
        private System.Windows.Forms.TextBox PlanDeRenta_IDTextBox;
        private System.Windows.Forms.Label ModeloUnidad_IDLabel;
        private System.Windows.Forms.ComboBox ModeloUnidad_IDComboBox;
        private System.Windows.Forms.Label DiasDeCobro_IDLabel;
        private System.Windows.Forms.ComboBox DiasDeCobro_IDComboBox;
        private System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label RentaBaseLabel;
        private System.Windows.Forms.TextBox RentaBaseTextBox;
        private System.Windows.Forms.Label FondoResidualLabel;
        private System.Windows.Forms.TextBox FondoResidualTextBox;
        private System.Windows.Forms.Label ActivoLabel;
        private System.Windows.Forms.CheckBox ActivoCheckBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource PlanesDeRentaBindingSource;
        private System.Windows.Forms.BindingSource ModelosUnidadesBindingSource;
        private System.Windows.Forms.BindingSource UsuariosBindingSource;
        private System.Windows.Forms.BindingSource DiasDeCobrosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox EstacionComboBox;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.Label label1;

    }
}