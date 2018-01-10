namespace SICASv20.forms
{
    partial class UnidadesConductoresOperativos
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
            this.UnidadTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vista_UnidadesConductoresOperativosDataGridView = new System.Windows.Forms.DataGridView();
            this.vista_UnidadesConductoresOperativosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ActualizarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RegresarTitularColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesConductoresOperativosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesConductoresOperativosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UnidadTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vista_UnidadesConductoresOperativosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unidades Conductores Operativos";
            // 
            // UnidadTextBox
            // 
            this.UnidadTextBox.Location = new System.Drawing.Point(80, 35);
            this.UnidadTextBox.Name = "UnidadTextBox";
            this.UnidadTextBox.Size = new System.Drawing.Size(100, 21);
            this.UnidadTextBox.TabIndex = 2;
            this.UnidadTextBox.TextChanged += new System.EventHandler(this.UnidadTextBox_TextChanged);
            this.UnidadTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UnidadTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unidad:";
            // 
            // vista_UnidadesConductoresOperativosDataGridView
            // 
            this.vista_UnidadesConductoresOperativosDataGridView.AllowUserToAddRows = false;
            this.vista_UnidadesConductoresOperativosDataGridView.AllowUserToDeleteRows = false;
            this.vista_UnidadesConductoresOperativosDataGridView.AutoGenerateColumns = false;
            this.vista_UnidadesConductoresOperativosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_UnidadesConductoresOperativosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActualizarColumn,
            this.RegresarTitularColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.vista_UnidadesConductoresOperativosDataGridView.DataSource = this.vista_UnidadesConductoresOperativosBindingSource;
            this.vista_UnidadesConductoresOperativosDataGridView.Location = new System.Drawing.Point(19, 82);
            this.vista_UnidadesConductoresOperativosDataGridView.Name = "vista_UnidadesConductoresOperativosDataGridView";
            this.vista_UnidadesConductoresOperativosDataGridView.ReadOnly = true;
            this.vista_UnidadesConductoresOperativosDataGridView.Size = new System.Drawing.Size(952, 527);
            this.vista_UnidadesConductoresOperativosDataGridView.TabIndex = 0;
            this.vista_UnidadesConductoresOperativosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_UnidadesConductoresOperativosDataGridView_CellContentClick);
            // 
            // vista_UnidadesConductoresOperativosBindingSource
            // 
            this.vista_UnidadesConductoresOperativosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_UnidadesConductoresOperativos);
            // 
            // ActualizarColumn
            // 
            this.ActualizarColumn.HeaderText = "";
            this.ActualizarColumn.Name = "ActualizarColumn";
            this.ActualizarColumn.ReadOnly = true;
            this.ActualizarColumn.Text = "Actualizar";
            this.ActualizarColumn.UseColumnTextForLinkValue = true;
            // 
            // RegresarTitularColumn
            // 
            this.RegresarTitularColumn.HeaderText = "";
            this.RegresarTitularColumn.Name = "RegresarTitularColumn";
            this.RegresarTitularColumn.ReadOnly = true;
            this.RegresarTitularColumn.Text = "Titular / Liberar";
            this.RegresarTitularColumn.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NumeroEconomico";
            this.dataGridViewTextBoxColumn2.HeaderText = "Unidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ConductorTitular";
            this.dataGridViewTextBoxColumn4.HeaderText = "ConductorTitular";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ConductorOperativo";
            this.dataGridViewTextBoxColumn6.HeaderText = "ConductorOperativo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // UnidadesConductoresOperativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "UnidadesConductoresOperativos";
            this.Text = "UnidadesConductoresOperativos";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesConductoresOperativosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UnidadesConductoresOperativosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_UnidadesConductoresOperativosDataGridView;
        private System.Windows.Forms.BindingSource vista_UnidadesConductoresOperativosBindingSource;
        private System.Windows.Forms.TextBox UnidadTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn ActualizarColumn;
        private System.Windows.Forms.DataGridViewLinkColumn RegresarTitularColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}