namespace SICASv20.forms
{
    partial class AltaEstaciones
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
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label domicilioLabel;
            System.Windows.Forms.Label estadoLabel;
            System.Windows.Forms.Label municipioLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label telefono1Label;
            System.Windows.Forms.Label telefono2Label;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telefono2TextBox = new System.Windows.Forms.TextBox();
            this.telefono1TextBox = new System.Windows.Forms.TextBox();
            this.estadoTextBox = new System.Windows.Forms.TextBox();
            this.domicilioTextBox = new System.Windows.Forms.TextBox();
            this.municipioTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            descripcionLabel = new System.Windows.Forms.Label();
            domicilioLabel = new System.Windows.Forms.Label();
            estadoLabel = new System.Windows.Forms.Label();
            municipioLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            telefono1Label = new System.Windows.Forms.Label();
            telefono2Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(3, 27);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(75, 15);
            descripcionLabel.TabIndex = 2;
            descripcionLabel.Text = "Descripcion:";
            // 
            // domicilioLabel
            // 
            domicilioLabel.AutoSize = true;
            domicilioLabel.Location = new System.Drawing.Point(3, 54);
            domicilioLabel.Name = "domicilioLabel";
            domicilioLabel.Size = new System.Drawing.Size(62, 15);
            domicilioLabel.TabIndex = 4;
            domicilioLabel.Text = "Domicilio:";
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new System.Drawing.Point(3, 108);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new System.Drawing.Size(48, 15);
            estadoLabel.TabIndex = 10;
            estadoLabel.Text = "Estado:";
            // 
            // municipioLabel
            // 
            municipioLabel.AutoSize = true;
            municipioLabel.Location = new System.Drawing.Point(3, 81);
            municipioLabel.Name = "municipioLabel";
            municipioLabel.Size = new System.Drawing.Size(64, 15);
            municipioLabel.TabIndex = 12;
            municipioLabel.Text = "Municipio:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(3, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 14;
            nombreLabel.Text = "Nombre:";
            // 
            // telefono1Label
            // 
            telefono1Label.AutoSize = true;
            telefono1Label.Location = new System.Drawing.Point(3, 135);
            telefono1Label.Name = "telefono1Label";
            telefono1Label.Size = new System.Drawing.Size(65, 15);
            telefono1Label.TabIndex = 16;
            telefono1Label.Text = "Telefono1:";
            // 
            // telefono2Label
            // 
            telefono2Label.AutoSize = true;
            telefono2Label.Location = new System.Drawing.Point(3, 162);
            telefono2Label.Name = "telefono2Label";
            telefono2Label.Size = new System.Drawing.Size(65, 15);
            telefono2Label.TabIndex = 18;
            telefono2Label.Text = "Telefono2:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.CancelarButton);
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta de Estación";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(nombreLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.telefono2TextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(telefono2Label, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.telefono1TextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(telefono1Label, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.estadoTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(estadoLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.domicilioTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(domicilioLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.municipioTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(municipioLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.descripcionTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(descripcionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nombreTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 194);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // selectEmpresasInternasBindingSource
            // 
            this.selectEmpresasInternasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
            // 
            // telefono2TextBox
            // 
            this.telefono2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Telefono2", true));
            this.telefono2TextBox.Location = new System.Drawing.Point(84, 165);
            this.telefono2TextBox.Name = "telefono2TextBox";
            this.telefono2TextBox.Size = new System.Drawing.Size(121, 21);
            this.telefono2TextBox.TabIndex = 19;
            // 
            // telefono1TextBox
            // 
            this.telefono1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Telefono1", true));
            this.telefono1TextBox.Location = new System.Drawing.Point(84, 138);
            this.telefono1TextBox.Name = "telefono1TextBox";
            this.telefono1TextBox.Size = new System.Drawing.Size(121, 21);
            this.telefono1TextBox.TabIndex = 17;
            // 
            // estadoTextBox
            // 
            this.estadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Estado", true));
            this.estadoTextBox.Location = new System.Drawing.Point(84, 111);
            this.estadoTextBox.Name = "estadoTextBox";
            this.estadoTextBox.Size = new System.Drawing.Size(171, 21);
            this.estadoTextBox.TabIndex = 11;
            // 
            // domicilioTextBox
            // 
            this.domicilioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Domicilio", true));
            this.domicilioTextBox.Location = new System.Drawing.Point(84, 57);
            this.domicilioTextBox.Name = "domicilioTextBox";
            this.domicilioTextBox.Size = new System.Drawing.Size(226, 21);
            this.domicilioTextBox.TabIndex = 5;
            // 
            // municipioTextBox
            // 
            this.municipioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Municipio", true));
            this.municipioTextBox.Location = new System.Drawing.Point(84, 84);
            this.municipioTextBox.Name = "municipioTextBox";
            this.municipioTextBox.Size = new System.Drawing.Size(171, 21);
            this.municipioTextBox.TabIndex = 13;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(84, 30);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(226, 21);
            this.descripcionTextBox.TabIndex = 3;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.estacionesBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(84, 3);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(171, 21);
            this.nombreTextBox.TabIndex = 15;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(368, 233);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(108, 34);
            this.CancelarButton.TabIndex = 21;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(250, 233);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(108, 34);
            this.GuardarButton.TabIndex = 20;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // AltaEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaEstaciones";
            this.Text = "AltaEstaciones";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.TextBox telefono2TextBox;
        private System.Windows.Forms.TextBox telefono1TextBox;
        private System.Windows.Forms.TextBox estadoTextBox;
        private System.Windows.Forms.TextBox domicilioTextBox;
        private System.Windows.Forms.TextBox municipioTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource selectEmpresasInternasBindingSource;
    }
}