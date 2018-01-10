namespace SICASv20.forms
{
    partial class MecanicoUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.MecanicossDataGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.mecanicoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MecanicoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KilometrajeTextBox = new System.Windows.Forms.TextBox();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CargoAConductorCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MecanicossDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mecanicosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Por favor, seleccione un mecánico";
            // 
            // MecanicossDataGridView
            // 
            this.MecanicossDataGridView.AllowUserToAddRows = false;
            this.MecanicossDataGridView.AllowUserToDeleteRows = false;
            this.MecanicossDataGridView.AutoGenerateColumns = false;
            this.MecanicossDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MecanicossDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.mecanicoIDDataGridViewTextBoxColumn,
            this.apellidosDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn});
            this.MecanicossDataGridView.DataSource = this.mecanicosBindingSource;
            this.MecanicossDataGridView.Location = new System.Drawing.Point(39, 73);
            this.MecanicossDataGridView.Name = "MecanicossDataGridView";
            this.MecanicossDataGridView.ReadOnly = true;
            this.MecanicossDataGridView.Size = new System.Drawing.Size(641, 150);
            this.MecanicossDataGridView.TabIndex = 19;
            this.MecanicossDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MecanicossDataGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // mecanicoIDDataGridViewTextBoxColumn
            // 
            this.mecanicoIDDataGridViewTextBoxColumn.DataPropertyName = "Mecanico_ID";
            this.mecanicoIDDataGridViewTextBoxColumn.HeaderText = "Mecanico_ID";
            this.mecanicoIDDataGridViewTextBoxColumn.Name = "mecanicoIDDataGridViewTextBoxColumn";
            this.mecanicoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.mecanicoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // apellidosDataGridViewTextBoxColumn
            // 
            this.apellidosDataGridViewTextBoxColumn.DataPropertyName = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.HeaderText = "Apellidos";
            this.apellidosDataGridViewTextBoxColumn.Name = "apellidosDataGridViewTextBoxColumn";
            this.apellidosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mecanicosBindingSource
            // 
            this.mecanicosBindingSource.DataSource = typeof(SICASv20.Entities.Mecanicos);
            // 
            // MecanicoTextBox
            // 
            this.MecanicoTextBox.Location = new System.Drawing.Point(108, 38);
            this.MecanicoTextBox.Name = "MecanicoTextBox";
            this.MecanicoTextBox.Size = new System.Drawing.Size(463, 21);
            this.MecanicoTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mecánico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Por favor, capture la información adicional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Kilometraje:";
            // 
            // KilometrajeTextBox
            // 
            this.KilometrajeTextBox.Location = new System.Drawing.Point(142, 283);
            this.KilometrajeTextBox.Name = "KilometrajeTextBox";
            this.KilometrajeTextBox.Size = new System.Drawing.Size(100, 21);
            this.KilometrajeTextBox.TabIndex = 22;
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComentariosTextBox.Location = new System.Drawing.Point(142, 336);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.Size = new System.Drawing.Size(538, 52);
            this.ComentariosTextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Comentarios:";
            // 
            // CargoAConductorCheckBox
            // 
            this.CargoAConductorCheckBox.AutoSize = true;
            this.CargoAConductorCheckBox.Location = new System.Drawing.Point(142, 312);
            this.CargoAConductorCheckBox.Name = "CargoAConductorCheckBox";
            this.CargoAConductorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.CargoAConductorCheckBox.TabIndex = 25;
            this.CargoAConductorCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Cargo a conductor:";
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(500, 512);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 28;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Image = global::SICASv20.Properties.Resources.forward;
            this.SiguienteButton.Location = new System.Drawing.Point(593, 512);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 27;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiguienteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SICASv20.Properties.Resources.search;
            this.BuscarButton.Location = new System.Drawing.Point(590, 33);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(90, 31);
            this.BuscarButton.TabIndex = 29;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // MecanicoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CargoAConductorCheckBox);
            this.Controls.Add(this.ComentariosTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.KilometrajeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MecanicossDataGridView);
            this.Controls.Add(this.MecanicoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "MecanicoUC";
            this.Size = new System.Drawing.Size(694, 557);
            ((System.ComponentModel.ISupportInitialize)(this.MecanicossDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mecanicosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView MecanicossDataGridView;
        private System.Windows.Forms.TextBox MecanicoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KilometrajeTextBox;
        private System.Windows.Forms.TextBox ComentariosTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CargoAConductorCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.BindingSource mecanicosBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn mecanicoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
    }
}
