namespace SICASv20.forms
{
    partial class ReimprimirTickets
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNombre = new System.Windows.Forms.CheckBox();
            this.TicketIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUnidad = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnidad);
            this.groupBox1.Controls.Add(this.chkNombre);
            this.groupBox1.Controls.Add(this.TicketIDTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reimprimir Ticket";
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Checked = true;
            this.chkNombre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNombre.Location = new System.Drawing.Point(18, 108);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(116, 22);
            this.chkNombre.TabIndex = 3;
            this.chkNombre.Text = "Con Nombre";
            this.chkNombre.UseVisualStyleBackColor = true;
            // 
            // TicketIDTextBox
            // 
            this.TicketIDTextBox.Location = new System.Drawing.Point(81, 65);
            this.TicketIDTextBox.Name = "TicketIDTextBox";
            this.TicketIDTextBox.Size = new System.Drawing.Size(100, 24);
            this.TicketIDTextBox.TabIndex = 2;
            this.TicketIDTextBox.TextChanged += new System.EventHandler(this.TicketIDTextBox_TextChanged);
            this.TicketIDTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TicketIDTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ticket ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teclee el folio (TIcket ID) del ticket y presione \"Enter\"";
            // 
            // chkUnidad
            // 
            this.chkUnidad.AutoSize = true;
            this.chkUnidad.Checked = true;
            this.chkUnidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnidad.Location = new System.Drawing.Point(171, 108);
            this.chkUnidad.Name = "chkUnidad";
            this.chkUnidad.Size = new System.Drawing.Size(125, 22);
            this.chkUnidad.TabIndex = 4;
            this.chkUnidad.Text = "Con Num Eco";
            this.chkUnidad.UseVisualStyleBackColor = true;
            // 
            // ReimprimirTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReimprimirTickets";
            this.Text = "ReimprimirTickets";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TicketIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNombre;
        private System.Windows.Forms.CheckBox chkUnidad;
    }
}