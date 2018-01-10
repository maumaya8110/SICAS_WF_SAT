namespace SICASv20.forms
{
    partial class ActualizarCobranzaConductor
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
            System.Windows.Forms.Label saldoATratarLabel;
            System.Windows.Forms.Label cronocascoLabel;
            System.Windows.Forms.Label terminalDatosLabel;
            System.Windows.Forms.Label bloquearConductorLabel;
            System.Windows.Forms.Label mensajeACajaLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label apellidosLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarCobranzaConductor));
            this.Cobranza = new System.Windows.Forms.GroupBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.conductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.saldoATratarTextBox = new System.Windows.Forms.TextBox();
            this.cronocascoCheckBox = new System.Windows.Forms.CheckBox();
            this.terminalDatosCheckBox = new System.Windows.Forms.CheckBox();
            this.bloquearConductorCheckBox = new System.Windows.Forms.CheckBox();
            this.mensajeACajaTextBox = new System.Windows.Forms.TextBox();
            this.ActualizarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            saldoATratarLabel = new System.Windows.Forms.Label();
            cronocascoLabel = new System.Windows.Forms.Label();
            terminalDatosLabel = new System.Windows.Forms.Label();
            bloquearConductorLabel = new System.Windows.Forms.Label();
            mensajeACajaLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            this.Cobranza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saldoATratarLabel
            // 
            saldoATratarLabel.AutoSize = true;
            saldoATratarLabel.Location = new System.Drawing.Point(23, 95);
            saldoATratarLabel.Name = "saldoATratarLabel";
            saldoATratarLabel.Size = new System.Drawing.Size(75, 13);
            saldoATratarLabel.TabIndex = 123;
            saldoATratarLabel.Text = "Saldo ATratar:";
            // 
            // cronocascoLabel
            // 
            cronocascoLabel.AutoSize = true;
            cronocascoLabel.Location = new System.Drawing.Point(23, 124);
            cronocascoLabel.Name = "cronocascoLabel";
            cronocascoLabel.Size = new System.Drawing.Size(67, 13);
            cronocascoLabel.TabIndex = 125;
            cronocascoLabel.Text = "Cronocasco:";
            // 
            // terminalDatosLabel
            // 
            terminalDatosLabel.AutoSize = true;
            terminalDatosLabel.Location = new System.Drawing.Point(23, 154);
            terminalDatosLabel.Name = "terminalDatosLabel";
            terminalDatosLabel.Size = new System.Drawing.Size(81, 13);
            terminalDatosLabel.TabIndex = 127;
            terminalDatosLabel.Text = "Terminal Datos:";
            // 
            // bloquearConductorLabel
            // 
            bloquearConductorLabel.AutoSize = true;
            bloquearConductorLabel.Location = new System.Drawing.Point(23, 184);
            bloquearConductorLabel.Name = "bloquearConductorLabel";
            bloquearConductorLabel.Size = new System.Drawing.Size(104, 13);
            bloquearConductorLabel.TabIndex = 129;
            bloquearConductorLabel.Text = "Bloquear Conductor:";
            // 
            // mensajeACajaLabel
            // 
            mensajeACajaLabel.AutoSize = true;
            mensajeACajaLabel.Location = new System.Drawing.Point(23, 212);
            mensajeACajaLabel.Name = "mensajeACajaLabel";
            mensajeACajaLabel.Size = new System.Drawing.Size(81, 13);
            mensajeACajaLabel.TabIndex = 131;
            mensajeACajaLabel.Text = "Mensaje ACaja:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(23, 40);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(47, 13);
            nombreLabel.TabIndex = 139;
            nombreLabel.Text = "Nombre:";
            // 
            // apellidosLabel
            // 
            apellidosLabel.AutoSize = true;
            apellidosLabel.Location = new System.Drawing.Point(23, 67);
            apellidosLabel.Name = "apellidosLabel";
            apellidosLabel.Size = new System.Drawing.Size(52, 13);
            apellidosLabel.TabIndex = 141;
            apellidosLabel.Text = "Apellidos:";
            // 
            // Cobranza
            // 
            this.Cobranza.Controls.Add(nombreLabel);
            this.Cobranza.Controls.Add(this.nombreTextBox);
            this.Cobranza.Controls.Add(apellidosLabel);
            this.Cobranza.Controls.Add(this.apellidosTextBox);
            this.Cobranza.Controls.Add(saldoATratarLabel);
            this.Cobranza.Controls.Add(this.saldoATratarTextBox);
            this.Cobranza.Controls.Add(cronocascoLabel);
            this.Cobranza.Controls.Add(this.cronocascoCheckBox);
            this.Cobranza.Controls.Add(terminalDatosLabel);
            this.Cobranza.Controls.Add(this.terminalDatosCheckBox);
            this.Cobranza.Controls.Add(bloquearConductorLabel);
            this.Cobranza.Controls.Add(this.bloquearConductorCheckBox);
            this.Cobranza.Controls.Add(mensajeACajaLabel);
            this.Cobranza.Controls.Add(this.mensajeACajaTextBox);
            this.Cobranza.Location = new System.Drawing.Point(13, 13);
            this.Cobranza.Name = "Cobranza";
            this.Cobranza.Size = new System.Drawing.Size(460, 299);
            this.Cobranza.TabIndex = 0;
            this.Cobranza.TabStop = false;
            this.Cobranza.Text = "Datos de Cobranza";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(194, 37);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.ReadOnly = true;
            this.nombreTextBox.Size = new System.Drawing.Size(200, 20);
            this.nombreTextBox.TabIndex = 140;
            // 
            // conductoresBindingSource
            // 
            this.conductoresBindingSource.DataMember = "Conductores";
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Apellidos", true));
            this.apellidosTextBox.Location = new System.Drawing.Point(194, 64);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.ReadOnly = true;
            this.apellidosTextBox.Size = new System.Drawing.Size(200, 20);
            this.apellidosTextBox.TabIndex = 142;
            // 
            // saldoATratarTextBox
            // 
            this.saldoATratarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "SaldoATratar", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.saldoATratarTextBox.Location = new System.Drawing.Point(194, 92);
            this.saldoATratarTextBox.Name = "saldoATratarTextBox";
            this.saldoATratarTextBox.Size = new System.Drawing.Size(200, 20);
            this.saldoATratarTextBox.TabIndex = 124;
            // 
            // cronocascoCheckBox
            // 
            this.cronocascoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.conductoresBindingSource, "Cronocasco", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.cronocascoCheckBox.Location = new System.Drawing.Point(194, 119);
            this.cronocascoCheckBox.Name = "cronocascoCheckBox";
            this.cronocascoCheckBox.Size = new System.Drawing.Size(200, 24);
            this.cronocascoCheckBox.TabIndex = 126;
            this.cronocascoCheckBox.UseVisualStyleBackColor = true;
            // 
            // terminalDatosCheckBox
            // 
            this.terminalDatosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.conductoresBindingSource, "TerminalDatos", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.terminalDatosCheckBox.Location = new System.Drawing.Point(194, 149);
            this.terminalDatosCheckBox.Name = "terminalDatosCheckBox";
            this.terminalDatosCheckBox.Size = new System.Drawing.Size(200, 24);
            this.terminalDatosCheckBox.TabIndex = 128;
            this.terminalDatosCheckBox.UseVisualStyleBackColor = true;
            // 
            // bloquearConductorCheckBox
            // 
            this.bloquearConductorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.conductoresBindingSource, "BloquearConductor", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.bloquearConductorCheckBox.Location = new System.Drawing.Point(194, 179);
            this.bloquearConductorCheckBox.Name = "bloquearConductorCheckBox";
            this.bloquearConductorCheckBox.Size = new System.Drawing.Size(200, 24);
            this.bloquearConductorCheckBox.TabIndex = 130;
            this.bloquearConductorCheckBox.UseVisualStyleBackColor = true;
            // 
            // mensajeACajaTextBox
            // 
            this.mensajeACajaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "MensajeACaja", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.mensajeACajaTextBox.Location = new System.Drawing.Point(194, 209);
            this.mensajeACajaTextBox.Multiline = true;
            this.mensajeACajaTextBox.Name = "mensajeACajaTextBox";
            this.mensajeACajaTextBox.Size = new System.Drawing.Size(200, 59);
            this.mensajeACajaTextBox.TabIndex = 132;
            // 
            // ActualizarButton
            // 
            this.ActualizarButton.Location = new System.Drawing.Point(361, 475);
            this.ActualizarButton.Name = "ActualizarButton";
            this.ActualizarButton.Size = new System.Drawing.Size(112, 27);
            this.ActualizarButton.TabIndex = 1;
            this.ActualizarButton.Text = "Actualizar";
            this.ActualizarButton.UseVisualStyleBackColor = true;
            this.ActualizarButton.Click += new System.EventHandler(this.ActualizarButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComentariosTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 121);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comentarios";
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.Location = new System.Drawing.Point(6, 19);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(448, 86);
            this.ComentariosTextBox.TabIndex = 133;
            // 
            // ActualizarCobranzaConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ActualizarButton);
            this.Controls.Add(this.Cobranza);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualizarCobranzaConductor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Cobranza Conductor";
            this.Cobranza.ResumeLayout(false);
            this.Cobranza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Cobranza;
        private System.Windows.Forms.BindingSource conductoresBindingSource;
        private System.Windows.Forms.Button ActualizarButton;
        private System.Windows.Forms.TextBox saldoATratarTextBox;
        private System.Windows.Forms.CheckBox cronocascoCheckBox;
        private System.Windows.Forms.CheckBox terminalDatosCheckBox;
        private System.Windows.Forms.CheckBox bloquearConductorCheckBox;
        private System.Windows.Forms.TextBox mensajeACajaTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ComentariosTextBox;
    }
}