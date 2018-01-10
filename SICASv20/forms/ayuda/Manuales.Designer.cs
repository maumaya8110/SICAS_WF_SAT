namespace SICASv20.forms
{
    partial class Manuales
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
            this.ManualesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ManualDeCajaLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ManualCobranzaLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ManualCajasupervisionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.ManualesFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ManualesFlowLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manuales";
            // 
            // ManualesFlowLayoutPanel
            // 
            this.ManualesFlowLayoutPanel.Controls.Add(this.ManualDeCajaLinkLabel);
            this.ManualesFlowLayoutPanel.Controls.Add(this.ManualCobranzaLinkLabel);
            this.ManualesFlowLayoutPanel.Controls.Add(this.ManualCajasupervisionLinkLabel);
            this.ManualesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ManualesFlowLayoutPanel.Location = new System.Drawing.Point(15, 29);
            this.ManualesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(12);
            this.ManualesFlowLayoutPanel.Name = "ManualesFlowLayoutPanel";
            this.ManualesFlowLayoutPanel.Size = new System.Drawing.Size(671, 584);
            this.ManualesFlowLayoutPanel.TabIndex = 0;
            // 
            // ManualDeCajaLinkLabel
            // 
            this.ManualDeCajaLinkLabel.AutoSize = true;
            this.ManualDeCajaLinkLabel.Location = new System.Drawing.Point(7, 7);
            this.ManualDeCajaLinkLabel.Margin = new System.Windows.Forms.Padding(7);
            this.ManualDeCajaLinkLabel.Name = "ManualDeCajaLinkLabel";
            this.ManualDeCajaLinkLabel.Size = new System.Drawing.Size(186, 15);
            this.ManualDeCajaLinkLabel.TabIndex = 0;
            this.ManualDeCajaLinkLabel.TabStop = true;
            this.ManualDeCajaLinkLabel.Text = "1. Manual de Caja Metropolitano";
            this.ManualDeCajaLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ManualDeCajaLinkLabel_LinkClicked);
            // 
            // ManualCobranzaLinkLabel
            // 
            this.ManualCobranzaLinkLabel.AutoSize = true;
            this.ManualCobranzaLinkLabel.Location = new System.Drawing.Point(7, 36);
            this.ManualCobranzaLinkLabel.Margin = new System.Windows.Forms.Padding(7);
            this.ManualCobranzaLinkLabel.Name = "ManualCobranzaLinkLabel";
            this.ManualCobranzaLinkLabel.Size = new System.Drawing.Size(214, 15);
            this.ManualCobranzaLinkLabel.TabIndex = 1;
            this.ManualCobranzaLinkLabel.TabStop = true;
            this.ManualCobranzaLinkLabel.Text = "2. Manual de Cobranza Metropolitano";
            this.ManualCobranzaLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ManualCobranzaLinkLabel_LinkClicked);
            // 
            // ManualCajasupervisionLinkLabel
            // 
            this.ManualCajasupervisionLinkLabel.AutoSize = true;
            this.ManualCajasupervisionLinkLabel.Location = new System.Drawing.Point(7, 65);
            this.ManualCajasupervisionLinkLabel.Margin = new System.Windows.Forms.Padding(7);
            this.ManualCajasupervisionLinkLabel.Name = "ManualCajasupervisionLinkLabel";
            this.ManualCajasupervisionLinkLabel.Size = new System.Drawing.Size(174, 15);
            this.ManualCajasupervisionLinkLabel.TabIndex = 2;
            this.ManualCajasupervisionLinkLabel.TabStop = true;
            this.ManualCajasupervisionLinkLabel.Text = "3. Manual de Caja Supervisión";
            this.ManualCajasupervisionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ManualCajasupervisionLinkLabel_LinkClicked);
            // 
            // Manuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "Manuales";
            this.Text = "Manuales";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.ManualesFlowLayoutPanel.ResumeLayout(false);
            this.ManualesFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel ManualesFlowLayoutPanel;
        private System.Windows.Forms.LinkLabel ManualDeCajaLinkLabel;
        private System.Windows.Forms.LinkLabel ManualCobranzaLinkLabel;
        private System.Windows.Forms.LinkLabel ManualCajasupervisionLinkLabel;
    }
}