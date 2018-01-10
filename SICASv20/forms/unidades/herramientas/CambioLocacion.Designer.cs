namespace SICASv20.forms
{
    partial class CambioLocacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConductorTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EstacionesComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.GuerdarButton = new System.Windows.Forms.Button();
            this.PlacasTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LocacionComboBox = new System.Windows.Forms.ComboBox();
            this.locacionesUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UnidadTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locacionesUnidadesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComentariosTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ConductorTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EstacionesComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.GuerdarButton);
            this.groupBox1.Controls.Add(this.PlacasTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LocacionComboBox);
            this.groupBox1.Controls.Add(this.UnidadTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 289);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambio de locacion de unidad";
            // 
            // ConductorTextBox
            // 
            this.ConductorTextBox.Location = new System.Drawing.Point(110, 93);
            this.ConductorTextBox.Name = "ConductorTextBox";
            this.ConductorTextBox.Size = new System.Drawing.Size(360, 21);
            this.ConductorTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Conductor:";
            // 
            // EstacionesComboBox
            // 
            this.EstacionesComboBox.DataSource = this.estacionesBindingSource;
            this.EstacionesComboBox.DisplayMember = "Nombre";
            this.EstacionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstacionesComboBox.FormattingEnabled = true;
            this.EstacionesComboBox.Location = new System.Drawing.Point(110, 39);
            this.EstacionesComboBox.Name = "EstacionesComboBox";
            this.EstacionesComboBox.Size = new System.Drawing.Size(360, 23);
            this.EstacionesComboBox.TabIndex = 7;
            this.EstacionesComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataSource = typeof(SICASv20.Entities.Estaciones);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estación:";
            // 
            // GuerdarButton
            // 
            this.GuerdarButton.Location = new System.Drawing.Point(370, 230);
            this.GuerdarButton.Name = "GuerdarButton";
            this.GuerdarButton.Size = new System.Drawing.Size(100, 44);
            this.GuerdarButton.TabIndex = 5;
            this.GuerdarButton.Text = "Guardar";
            this.GuerdarButton.UseVisualStyleBackColor = true;
            this.GuerdarButton.Click += new System.EventHandler(this.GuerdarButton_Click);
            // 
            // PlacasTextBox
            // 
            this.PlacasTextBox.Location = new System.Drawing.Point(216, 68);
            this.PlacasTextBox.Name = "PlacasTextBox";
            this.PlacasTextBox.Size = new System.Drawing.Size(254, 21);
            this.PlacasTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Locación:";
            // 
            // LocacionComboBox
            // 
            this.LocacionComboBox.DataSource = this.locacionesUnidadesBindingSource;
            this.LocacionComboBox.DisplayMember = "Nombre";
            this.LocacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocacionComboBox.FormattingEnabled = true;
            this.LocacionComboBox.Location = new System.Drawing.Point(110, 118);
            this.LocacionComboBox.Name = "LocacionComboBox";
            this.LocacionComboBox.Size = new System.Drawing.Size(360, 23);
            this.LocacionComboBox.TabIndex = 2;
            this.LocacionComboBox.ValueMember = "LocacionUnidad_ID";
            // 
            // locacionesUnidadesBindingSource
            // 
            this.locacionesUnidadesBindingSource.DataSource = typeof(SICASv20.Entities.LocacionesUnidades);
            // 
            // UnidadTextBox
            // 
            this.UnidadTextBox.Location = new System.Drawing.Point(110, 68);
            this.UnidadTextBox.Name = "UnidadTextBox";
            this.UnidadTextBox.Size = new System.Drawing.Size(100, 21);
            this.UnidadTextBox.TabIndex = 1;
            this.UnidadTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UnidadTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidad:";
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.Location = new System.Drawing.Point(110, 147);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(360, 69);
            this.ComentariosTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Comentarios:";
            // 
            // CambioLocacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "CambioLocacion";
            this.Text = "CambioLocacion";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locacionesUnidadesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GuerdarButton;
        private System.Windows.Forms.TextBox PlacasTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LocacionComboBox;
        private System.Windows.Forms.TextBox UnidadTextBox;
        private System.Windows.Forms.BindingSource locacionesUnidadesBindingSource;
        private System.Windows.Forms.ComboBox EstacionesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.TextBox ConductorTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.Label label5;
    }
}