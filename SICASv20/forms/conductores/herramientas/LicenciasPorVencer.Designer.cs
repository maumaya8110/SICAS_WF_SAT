namespace SICASv20.forms
{
    partial class LicenciasPorVencer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenciasPorVencer));
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.vista_LicenciasPorVencerDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_LicenciasPorVencerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AceptarButton = new System.Windows.Forms.Button();
            this.MainTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_LicenciasPorVencerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_LicenciasPorVencerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 1;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.Controls.Add(this.vista_LicenciasPorVencerDataGridView, 0, 1);
            this.MainTablePanel.Controls.Add(this.label1, 0, 0);
            this.MainTablePanel.Controls.Add(this.AceptarButton, 0, 2);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTablePanel.Margin = new System.Windows.Forms.Padding(10);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainTablePanel.RowCount = 3;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.274232F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.72577F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.MainTablePanel.Size = new System.Drawing.Size(768, 467);
            this.MainTablePanel.TabIndex = 0;
            // 
            // vista_LicenciasPorVencerDataGridView
            // 
            this.vista_LicenciasPorVencerDataGridView.AllowUserToAddRows = false;
            this.vista_LicenciasPorVencerDataGridView.AllowUserToDeleteRows = false;
            this.vista_LicenciasPorVencerDataGridView.AutoGenerateColumns = false;
            this.vista_LicenciasPorVencerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_LicenciasPorVencerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.vista_LicenciasPorVencerDataGridView.DataSource = this.vista_LicenciasPorVencerBindingSource;
            this.vista_LicenciasPorVencerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vista_LicenciasPorVencerDataGridView.Location = new System.Drawing.Point(13, 46);
            this.vista_LicenciasPorVencerDataGridView.Name = "vista_LicenciasPorVencerDataGridView";
            this.vista_LicenciasPorVencerDataGridView.ReadOnly = true;
            this.vista_LicenciasPorVencerDataGridView.Size = new System.Drawing.Size(742, 360);
            this.vista_LicenciasPorVencerDataGridView.TabIndex = 0;
            this.vista_LicenciasPorVencerDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.vista_LicenciasPorVencerDataGridView_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Licencias Vencidas y Por Vencer";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Conductor_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Conductor_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LicenciaLiberada";
            this.dataGridViewTextBoxColumn3.HeaderText = "LicenciaLiberada";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "VenceLicencia";
            this.dataGridViewTextBoxColumn4.HeaderText = "VenceLicencia";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // vista_LicenciasPorVencerBindingSource
            // 
            this.vista_LicenciasPorVencerBindingSource.DataSource = typeof(SICASv20.Entities.Vista_LicenciasPorVencer);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AceptarButton.Location = new System.Drawing.Point(346, 421);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 2;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // LicenciasPorVencer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(768, 467);
            this.Controls.Add(this.MainTablePanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LicenciasPorVencer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licencias Por Vencer";
            this.Load += new System.EventHandler(this.LicenciasPorVencer_Load);
            this.MainTablePanel.ResumeLayout(false);
            this.MainTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_LicenciasPorVencerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_LicenciasPorVencerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.DataGridView vista_LicenciasPorVencerDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource vista_LicenciasPorVencerBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AceptarButton;
    }
}