namespace SICASv20.forms
{
    partial class AdendumAltaEdicion
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIndefinido = new System.Windows.Forms.CheckBox();
            this.datePickFin = new System.Windows.Forms.DateTimePicker();
            this.cmbConceptoClasificacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-160, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Clasificacion:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.datePickInicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkIndefinido);
            this.panel1.Controls.Add(this.datePickFin);
            this.panel1.Controls.Add(this.cmbConceptoClasificacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(37, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 389);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(61, 264);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 103);
            this.label5.TabIndex = 8;
            this.label5.Text = "Las fechas de inicio y fin se incluyen dentro del rango que abarcará el adendum.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Concepto:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(327, 312);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Inicio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // datePickInicio
            // 
            this.datePickInicio.Location = new System.Drawing.Point(160, 178);
            this.datePickInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datePickInicio.Name = "datePickInicio";
            this.datePickInicio.Size = new System.Drawing.Size(265, 22);
            this.datePickInicio.TabIndex = 5;
            this.datePickInicio.ValueChanged += new System.EventHandler(this.datePickInicio_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Fin:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkIndefinido
            // 
            this.chkIndefinido.AutoSize = true;
            this.chkIndefinido.Location = new System.Drawing.Point(331, 263);
            this.chkIndefinido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIndefinido.Name = "chkIndefinido";
            this.chkIndefinido.Size = new System.Drawing.Size(91, 21);
            this.chkIndefinido.TabIndex = 9;
            this.chkIndefinido.Text = "Indefinido";
            this.chkIndefinido.UseVisualStyleBackColor = true;
            this.chkIndefinido.CheckedChanged += new System.EventHandler(this.chkIndefinido_CheckedChanged);
            // 
            // datePickFin
            // 
            this.datePickFin.Location = new System.Drawing.Point(160, 220);
            this.datePickFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datePickFin.Name = "datePickFin";
            this.datePickFin.Size = new System.Drawing.Size(265, 22);
            this.datePickFin.TabIndex = 7;
            // 
            // cmbConceptoClasificacion
            // 
            this.cmbConceptoClasificacion.FormattingEnabled = true;
            this.cmbConceptoClasificacion.Location = new System.Drawing.Point(160, 44);
            this.cmbConceptoClasificacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbConceptoClasificacion.Name = "cmbConceptoClasificacion";
            this.cmbConceptoClasificacion.Size = new System.Drawing.Size(265, 24);
            this.cmbConceptoClasificacion.TabIndex = 1;
            this.cmbConceptoClasificacion.SelectedIndexChanged += new System.EventHandler(this.cmbConceptoClasificacion_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(64, 101);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(358, 70);
            this.txtObservaciones.TabIndex = 3;
            // 
            // AdendumAltaEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 389);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdendumAltaEdicion";
            this.Text = "AdendumAltaEdicion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIndefinido;
        private System.Windows.Forms.DateTimePicker datePickFin;
        private System.Windows.Forms.ComboBox cmbConceptoClasificacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
    }
}