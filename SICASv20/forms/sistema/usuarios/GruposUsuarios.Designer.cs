namespace SICASv20.forms
{
    partial class GruposUsuarios
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
            this.gruposUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gruposUsuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.EditPermisosColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gruposUsuariosDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 627);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupos de Usuarios";
            // 
            // gruposUsuariosBindingSource
            // 
            this.gruposUsuariosBindingSource.DataSource = typeof(SICASv20.Entities.GruposUsuarios);
            // 
            // gruposUsuariosDataGridView
            // 
            this.gruposUsuariosDataGridView.AllowUserToAddRows = false;
            this.gruposUsuariosDataGridView.AllowUserToDeleteRows = false;
            this.gruposUsuariosDataGridView.AutoGenerateColumns = false;
            this.gruposUsuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gruposUsuariosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditPermisosColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gruposUsuariosDataGridView.DataSource = this.gruposUsuariosBindingSource;
            this.gruposUsuariosDataGridView.Location = new System.Drawing.Point(23, 37);
            this.gruposUsuariosDataGridView.Name = "gruposUsuariosDataGridView";
            this.gruposUsuariosDataGridView.ReadOnly = true;
            this.gruposUsuariosDataGridView.Size = new System.Drawing.Size(944, 572);
            this.gruposUsuariosDataGridView.TabIndex = 0;
            this.gruposUsuariosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gruposUsuariosDataGridView_CellContentClick);
            // 
            // EditPermisosColumn
            // 
            this.EditPermisosColumn.DataPropertyName = "GrupoUsuario_ID";
            this.EditPermisosColumn.HeaderText = "";
            this.EditPermisosColumn.Name = "EditPermisosColumn";
            this.EditPermisosColumn.ReadOnly = true;
            this.EditPermisosColumn.Text = "ActualizarPermisos";
            this.EditPermisosColumn.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GrupoUsuario_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "GrupoUsuario_ID";
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
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // GruposUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "GruposUsuarios";
            this.Text = "GruposUsuarios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gruposUsuariosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gruposUsuariosDataGridView;
        private System.Windows.Forms.BindingSource gruposUsuariosBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn EditPermisosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}