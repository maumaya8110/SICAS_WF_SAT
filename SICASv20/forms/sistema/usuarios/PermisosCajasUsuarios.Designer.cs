namespace SICASv20.forms
{
    partial class PermisosCajasUsuarios
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label activoLabel;
            System.Windows.Forms.Label apellidosLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label empresaLabel;
            System.Windows.Forms.Label estacionLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label usuario_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.vista_UsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.activoCheckBox = new System.Windows.Forms.CheckBox();
            this.estacionTextBox = new System.Windows.Forms.TextBox();
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.empresaTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vista_Usuarios_CajasDataGridView = new System.Windows.Forms.DataGridView();
            this.EliminarColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vista_Usuarios_CajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CajasComboBox = new System.Windows.Forms.ComboBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.cajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            activoLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            empresaLabel = new System.Windows.Forms.Label();
            estacionLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            usuario_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Usuarios_CajasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Usuarios_CajasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(19, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 17;
            label1.Text = "Caja:";
            // 
            // activoLabel
            // 
            activoLabel.AutoSize = true;
            activoLabel.Location = new System.Drawing.Point(30, 201);
            activoLabel.Name = "activoLabel";
            activoLabel.Size = new System.Drawing.Size(41, 15);
            activoLabel.TabIndex = 20;
            activoLabel.Text = "Activo:";
            // 
            // apellidosLabel
            // 
            apellidosLabel.AutoSize = true;
            apellidosLabel.Location = new System.Drawing.Point(30, 89);
            apellidosLabel.Name = "apellidosLabel";
            apellidosLabel.Size = new System.Drawing.Size(60, 15);
            apellidosLabel.TabIndex = 22;
            apellidosLabel.Text = "Apellidos:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(30, 116);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(42, 15);
            emailLabel.TabIndex = 24;
            emailLabel.Text = "Email:";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new System.Drawing.Point(30, 143);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new System.Drawing.Size(60, 15);
            empresaLabel.TabIndex = 26;
            empresaLabel.Text = "Empresa:";
            // 
            // estacionLabel
            // 
            estacionLabel.AutoSize = true;
            estacionLabel.Location = new System.Drawing.Point(30, 170);
            estacionLabel.Name = "estacionLabel";
            estacionLabel.Size = new System.Drawing.Size(57, 15);
            estacionLabel.TabIndex = 28;
            estacionLabel.Text = "Estacion:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(30, 62);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 30;
            nombreLabel.Text = "Nombre:";
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(30, 35);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 32;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos de cajas de usuarios";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(usuario_IDLabel);
            this.groupBox3.Controls.Add(this.usuario_IDTextBox);
            this.groupBox3.Controls.Add(activoLabel);
            this.groupBox3.Controls.Add(this.nombreTextBox);
            this.groupBox3.Controls.Add(this.activoCheckBox);
            this.groupBox3.Controls.Add(nombreLabel);
            this.groupBox3.Controls.Add(apellidosLabel);
            this.groupBox3.Controls.Add(this.estacionTextBox);
            this.groupBox3.Controls.Add(this.apellidosTextBox);
            this.groupBox3.Controls.Add(estacionLabel);
            this.groupBox3.Controls.Add(emailLabel);
            this.groupBox3.Controls.Add(this.empresaTextBox);
            this.groupBox3.Controls.Add(this.emailTextBox);
            this.groupBox3.Controls.Add(empresaLabel);
            this.groupBox3.Location = new System.Drawing.Point(6, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 270);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de usuario";
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Usuario_ID", true));
            this.usuario_IDTextBox.Location = new System.Drawing.Point(104, 32);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.ReadOnly = true;
            this.usuario_IDTextBox.Size = new System.Drawing.Size(104, 21);
            this.usuario_IDTextBox.TabIndex = 33;
            // 
            // vista_UsuariosBindingSource
            // 
            this.vista_UsuariosBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Usuarios);
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(104, 59);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.ReadOnly = true;
            this.nombreTextBox.Size = new System.Drawing.Size(221, 21);
            this.nombreTextBox.TabIndex = 31;
            // 
            // activoCheckBox
            // 
            this.activoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.vista_UsuariosBindingSource, "Activo", true));
            this.activoCheckBox.Location = new System.Drawing.Point(104, 196);
            this.activoCheckBox.Name = "activoCheckBox";
            this.activoCheckBox.Size = new System.Drawing.Size(104, 24);
            this.activoCheckBox.TabIndex = 21;
            this.activoCheckBox.UseVisualStyleBackColor = true;
            // 
            // estacionTextBox
            // 
            this.estacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Estacion", true));
            this.estacionTextBox.Location = new System.Drawing.Point(104, 167);
            this.estacionTextBox.Name = "estacionTextBox";
            this.estacionTextBox.ReadOnly = true;
            this.estacionTextBox.Size = new System.Drawing.Size(192, 21);
            this.estacionTextBox.TabIndex = 29;
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Apellidos", true));
            this.apellidosTextBox.Location = new System.Drawing.Point(104, 86);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.ReadOnly = true;
            this.apellidosTextBox.Size = new System.Drawing.Size(221, 21);
            this.apellidosTextBox.TabIndex = 23;
            // 
            // empresaTextBox
            // 
            this.empresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Empresa", true));
            this.empresaTextBox.Location = new System.Drawing.Point(104, 140);
            this.empresaTextBox.Name = "empresaTextBox";
            this.empresaTextBox.ReadOnly = true;
            this.empresaTextBox.Size = new System.Drawing.Size(192, 21);
            this.empresaTextBox.TabIndex = 27;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_UsuariosBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(104, 113);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(221, 21);
            this.emailTextBox.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vista_Usuarios_CajasDataGridView);
            this.groupBox2.Controls.Add(this.CajasComboBox);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.AgregarButton);
            this.groupBox2.Location = new System.Drawing.Point(512, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 272);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cajas permitidas";
            // 
            // vista_Usuarios_CajasDataGridView
            // 
            this.vista_Usuarios_CajasDataGridView.AllowUserToAddRows = false;
            this.vista_Usuarios_CajasDataGridView.AllowUserToDeleteRows = false;
            this.vista_Usuarios_CajasDataGridView.AutoGenerateColumns = false;
            this.vista_Usuarios_CajasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vista_Usuarios_CajasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarColumn,
            this.dataGridViewTextBoxColumn3});
            this.vista_Usuarios_CajasDataGridView.DataSource = this.vista_Usuarios_CajasBindingSource;
            this.vista_Usuarios_CajasDataGridView.Location = new System.Drawing.Point(22, 63);
            this.vista_Usuarios_CajasDataGridView.Name = "vista_Usuarios_CajasDataGridView";
            this.vista_Usuarios_CajasDataGridView.ReadOnly = true;
            this.vista_Usuarios_CajasDataGridView.Size = new System.Drawing.Size(319, 175);
            this.vista_Usuarios_CajasDataGridView.TabIndex = 18;
            this.vista_Usuarios_CajasDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vista_Usuarios_CajasDataGridView_CellContentClick);
            // 
            // EliminarColumn
            // 
            this.EliminarColumn.HeaderText = "";
            this.EliminarColumn.Name = "EliminarColumn";
            this.EliminarColumn.ReadOnly = true;
            this.EliminarColumn.Text = "Eliminar";
            this.EliminarColumn.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Caja";
            this.dataGridViewTextBoxColumn3.HeaderText = "Caja";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // vista_Usuarios_CajasBindingSource
            // 
            this.vista_Usuarios_CajasBindingSource.DataSource = typeof(SICASv20.Entities.Vista_Usuarios_Cajas);
            // 
            // CajasComboBox
            // 
            this.CajasComboBox.DataSource = this.cajasBindingSource;
            this.CajasComboBox.DisplayMember = "Nombre";
            this.CajasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CajasComboBox.FormattingEnabled = true;
            this.CajasComboBox.Location = new System.Drawing.Point(94, 27);
            this.CajasComboBox.Name = "CajasComboBox";
            this.CajasComboBox.Size = new System.Drawing.Size(166, 23);
            this.CajasComboBox.TabIndex = 19;
            this.CajasComboBox.ValueMember = "Caja_ID";
            this.CajasComboBox.SelectionChangeCommitted += new System.EventHandler(this.CajasComboBox_SelectionChangeCommitted);
            // 
            // AgregarButton
            // 
            this.AgregarButton.Location = new System.Drawing.Point(267, 27);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(74, 23);
            this.AgregarButton.TabIndex = 20;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = true;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // cajasBindingSource
            // 
            this.cajasBindingSource.DataSource = typeof(SICASv20.Entities.Cajas);
            // 
            // PermisosCajasUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "PermisosCajasUsuarios";
            this.Text = "PermisosCajasUsuarios";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_UsuariosBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Usuarios_CajasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_Usuarios_CajasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView vista_Usuarios_CajasDataGridView;
        private System.Windows.Forms.BindingSource vista_Usuarios_CajasBindingSource;
        private System.Windows.Forms.ComboBox CajasComboBox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.DataGridViewLinkColumn EliminarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.CheckBox activoCheckBox;
        private System.Windows.Forms.BindingSource vista_UsuariosBindingSource;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox empresaTextBox;
        private System.Windows.Forms.TextBox estacionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource cajasBindingSource;
    }
}