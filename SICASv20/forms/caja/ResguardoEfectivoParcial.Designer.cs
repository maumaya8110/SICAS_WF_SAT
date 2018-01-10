namespace SICASv20.forms.caja
{
    partial class ResguardoEfectivoParcial
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
            this.lblMonto = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMsj = new System.Windows.Forms.Label();
            this.lblMontoSinResguardo = new System.Windows.Forms.Label();
            this.lbMontoEstacion = new System.Windows.Forms.Label();
            this.lblMontoPendiente = new System.Windows.Forms.Label();
            this.txtMontoResguardoParcial = new System.Windows.Forms.TextBox();
            this.lblMontoResguardado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMonto
            // 
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(2, 173);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(329, 20);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto a resguardar:";
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SICASv20.Properties.Resources.save;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(234, 227);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 41);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::SICASv20.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(372, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsj
            // 
            this.lblMsj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsj.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMsj.Location = new System.Drawing.Point(1, 31);
            this.lblMsj.Name = "lblMsj";
            this.lblMsj.Size = new System.Drawing.Size(330, 20);
            this.lblMsj.TabIndex = 4;
            this.lblMsj.Text = "Monto Sugerido de Resguardo:";
            this.lblMsj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMontoSinResguardo
            // 
            this.lblMontoSinResguardo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSinResguardo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMontoSinResguardo.Location = new System.Drawing.Point(-1, 72);
            this.lblMontoSinResguardo.Name = "lblMontoSinResguardo";
            this.lblMontoSinResguardo.Size = new System.Drawing.Size(332, 20);
            this.lblMontoSinResguardo.TabIndex = 5;
            this.lblMontoSinResguardo.Text = "Monto Pendiente de Resguado:";
            this.lblMontoSinResguardo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMontoEstacion
            // 
            this.lbMontoEstacion.Location = new System.Drawing.Point(372, 37);
            this.lbMontoEstacion.Name = "lbMontoEstacion";
            this.lbMontoEstacion.Size = new System.Drawing.Size(173, 17);
            this.lbMontoEstacion.TabIndex = 6;
            this.lbMontoEstacion.Text = "0.00";
            this.lbMontoEstacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMontoPendiente
            // 
            this.lblMontoPendiente.Location = new System.Drawing.Point(372, 75);
            this.lblMontoPendiente.Name = "lblMontoPendiente";
            this.lblMontoPendiente.Size = new System.Drawing.Size(173, 17);
            this.lblMontoPendiente.TabIndex = 7;
            this.lblMontoPendiente.Text = "0.00";
            this.lblMontoPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMontoResguardoParcial
            // 
            this.txtMontoResguardoParcial.BackColor = System.Drawing.Color.White;
            this.txtMontoResguardoParcial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoResguardoParcial.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoResguardoParcial.Location = new System.Drawing.Point(372, 166);
            this.txtMontoResguardoParcial.Name = "txtMontoResguardoParcial";
            this.txtMontoResguardoParcial.Size = new System.Drawing.Size(173, 32);
            this.txtMontoResguardoParcial.TabIndex = 8;
            this.txtMontoResguardoParcial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoResguardoParcial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoResguardoParcial_KeyPress);
            // 
            // lblMontoResguardado
            // 
            this.lblMontoResguardado.Location = new System.Drawing.Point(372, 118);
            this.lblMontoResguardado.Name = "lblMontoResguardado";
            this.lblMontoResguardado.Size = new System.Drawing.Size(173, 17);
            this.lblMontoResguardado.TabIndex = 10;
            this.lblMontoResguardado.Text = "0.00";
            this.lblMontoResguardado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMontoResguardado.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(1, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Monto Total Resguardado:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // ResguardoEfectivoParcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(598, 298);
            this.Controls.Add(this.lblMontoResguardado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMontoResguardoParcial);
            this.Controls.Add(this.lblMontoPendiente);
            this.Controls.Add(this.lbMontoEstacion);
            this.Controls.Add(this.lblMontoSinResguardo);
            this.Controls.Add(this.lblMsj);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblMonto);
            this.MinimizeBox = false;
            this.Name = "ResguardoEfectivoParcial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resguardo Caja en Fuerte";
            this.Load += new System.EventHandler(this.ResguardoEfectivoParcial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMsj;
        private System.Windows.Forms.Label lblMontoSinResguardo;
        private System.Windows.Forms.Label lbMontoEstacion;
        private System.Windows.Forms.Label lblMontoPendiente;
        private System.Windows.Forms.TextBox txtMontoResguardoParcial;
        private System.Windows.Forms.Label lblMontoResguardado;
        private System.Windows.Forms.Label label2;
    }
}