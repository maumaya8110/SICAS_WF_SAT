namespace SICASv20.forms
{
    partial class ServiciosMantenimientosTiposRefacciones
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreServicioTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EliminarCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.TipoRefaccionTextBox = new System.Windows.Forms.TextBox();
            this.TipoRefaccionButton = new System.Windows.Forms.Button();
            this.refaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tiposRefaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 559);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de refacciones por servicio de mantenimiento";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.NombreServicioTextBox);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.Controls.Add(this.GuardarButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 497);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicio";
            // 
            // NombreServicioTextBox
            // 
            this.NombreServicioTextBox.Location = new System.Drawing.Point(6, 33);
            this.NombreServicioTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.NombreServicioTextBox.Name = "NombreServicioTextBox";
            this.NombreServicioTextBox.ReadOnly = true;
            this.NombreServicioTextBox.Size = new System.Drawing.Size(499, 21);
            this.NombreServicioTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de refacción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 16, 6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipos de refacciones del servicio";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarCol,
            this.refaccionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 169);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(499, 150);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EliminarCol
            // 
            this.EliminarCol.HeaderText = "";
            this.EliminarCol.Name = "EliminarCol";
            this.EliminarCol.Text = "Eliminar";
            this.EliminarCol.UseColumnTextForLinkValue = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.GuardarButton.Location = new System.Drawing.Point(405, 331);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(6);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(100, 34);
            this.GuardarButton.TabIndex = 6;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.TipoRefaccionTextBox);
            this.flowLayoutPanel2.Controls.Add(this.TipoRefaccionButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 90);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(502, 33);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // TipoRefaccionTextBox
            // 
            this.TipoRefaccionTextBox.Location = new System.Drawing.Point(6, 6);
            this.TipoRefaccionTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.TipoRefaccionTextBox.Name = "TipoRefaccionTextBox";
            this.TipoRefaccionTextBox.ReadOnly = true;
            this.TipoRefaccionTextBox.Size = new System.Drawing.Size(447, 21);
            this.TipoRefaccionTextBox.TabIndex = 8;
            // 
            // TipoRefaccionButton
            // 
            this.TipoRefaccionButton.Location = new System.Drawing.Point(462, 3);
            this.TipoRefaccionButton.Name = "TipoRefaccionButton";
            this.TipoRefaccionButton.Size = new System.Drawing.Size(31, 23);
            this.TipoRefaccionButton.TabIndex = 9;
            this.TipoRefaccionButton.Text = "...";
            this.TipoRefaccionButton.UseVisualStyleBackColor = true;
            this.TipoRefaccionButton.Click += new System.EventHandler(this.TipoRefaccionButton_Click);
            // 
            // refaccionDataGridViewTextBoxColumn
            // 
            this.refaccionDataGridViewTextBoxColumn.DataPropertyName = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.HeaderText = "Refaccion";
            this.refaccionDataGridViewTextBoxColumn.Name = "refaccionDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // vista_ServiciosMantenimientos_TiposRefaccionesBindingSource
            // 
            this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.Vista_ServiciosMantenimientos_TiposRefacciones);
            // 
            // tiposRefaccionesBindingSource
            // 
            this.tiposRefaccionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposRefacciones);
            // 
            // ServiciosMantenimientosTiposRefacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServiciosMantenimientosTiposRefacciones";
            this.Text = "ServiciosMantenimientosTiposRefacciones";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ServiciosMantenimientos_TiposRefaccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposRefaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NombreServicioTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource vista_ServiciosMantenimientos_TiposRefaccionesBindingSource;
        private System.Windows.Forms.BindingSource tiposRefaccionesBindingSource;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.DataGridViewLinkColumn EliminarCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox TipoRefaccionTextBox;
        private System.Windows.Forms.Button TipoRefaccionButton;
    }
}