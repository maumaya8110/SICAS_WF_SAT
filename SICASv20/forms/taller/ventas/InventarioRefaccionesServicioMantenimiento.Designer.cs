namespace SICASv20.forms
{
    partial class InventarioRefaccionesServicioMantenimiento
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
            this.label1 = new System.Windows.Forms.Label();
            this.ServicioLabel = new System.Windows.Forms.Label();
            this.vista_InventarioRefaccionesServicioDataGridView = new System.Windows.Forms.DataGridView();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_InventarioRefaccionesServicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_InventarioRefaccionesServicioDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_InventarioRefaccionesServicioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vista_InventarioRefaccionesServicioDataGridView);
            this.groupBox1.Controls.Add(this.ServicioLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refacciones de Servicio Matenimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Las siguientes refacciones presentan carencia de inventario, para el servicio:";
            // 
            // ServicioLabel
            // 
            this.ServicioLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ServicioLabel.AutoSize = true;
            this.ServicioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServicioLabel.Location = new System.Drawing.Point(25, 56);
            this.ServicioLabel.Name = "ServicioLabel";
            this.ServicioLabel.Size = new System.Drawing.Size(67, 13);
            this.ServicioLabel.TabIndex = 1;
            this.ServicioLabel.Text = "<Servicio>";
            // 
            // vista_InventarioRefaccionesServicioDataGridView
            // 
            this.vista_InventarioRefaccionesServicioDataGridView.AutoGenerateColumns = false;
            this.vista_InventarioRefaccionesServicioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_InventarioRefaccionesServicioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.vista_InventarioRefaccionesServicioDataGridView.DataSource = this.vista_InventarioRefaccionesServicioBindingSource;
            this.vista_InventarioRefaccionesServicioDataGridView.Location = new System.Drawing.Point(28, 85);
            this.vista_InventarioRefaccionesServicioDataGridView.Name = "vista_InventarioRefaccionesServicioDataGridView";
            this.vista_InventarioRefaccionesServicioDataGridView.Size = new System.Drawing.Size(600, 245);
            this.vista_InventarioRefaccionesServicioDataGridView.TabIndex = 2;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(530, 367);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(132, 39);
            this.AceptarButton.TabIndex = 1;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Refaccion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Refaccion";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Inventario";
            this.dataGridViewTextBoxColumn2.HeaderText = "Inventario";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Requiere";
            this.dataGridViewTextBoxColumn3.HeaderText = "Requiere";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Diferencia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Diferencia";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // vista_InventarioRefaccionesServicioBindingSource
            // 
            this.vista_InventarioRefaccionesServicioBindingSource.DataSource = typeof(SICASv20.Entities.Vista_InventarioRefaccionesServicio);
            // 
            // InventarioRefaccionesServicioMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 416);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventarioRefaccionesServicioMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_InventarioRefaccionesServicioDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_InventarioRefaccionesServicioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_InventarioRefaccionesServicioDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource vista_InventarioRefaccionesServicioBindingSource;
        private System.Windows.Forms.Label ServicioLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AceptarButton;
    }
}