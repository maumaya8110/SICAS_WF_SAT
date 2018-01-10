namespace SICASv20.forms
{
    partial class UnidadUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.NumeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConductorHabitualTextBox = new System.Windows.Forms.TextBox();
            this.PlacasTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UnidadesDataGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroEconomicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conductorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datosUnidadTallerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.ModeloTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ActualizarModeloButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosUnidadTallerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidad (Número económico):";
            // 
            // NumeroEconomicoTextBox
            // 
            this.NumeroEconomicoTextBox.Location = new System.Drawing.Point(197, 41);
            this.NumeroEconomicoTextBox.Name = "NumeroEconomicoTextBox";
            this.NumeroEconomicoTextBox.Size = new System.Drawing.Size(100, 21);
            this.NumeroEconomicoTextBox.TabIndex = 1;
            this.NumeroEconomicoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumeroEconomicoTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conductor habitual:";
            // 
            // ConductorHabitualTextBox
            // 
            this.ConductorHabitualTextBox.Location = new System.Drawing.Point(197, 68);
            this.ConductorHabitualTextBox.Name = "ConductorHabitualTextBox";
            this.ConductorHabitualTextBox.Size = new System.Drawing.Size(437, 21);
            this.ConductorHabitualTextBox.TabIndex = 3;
            // 
            // PlacasTextBox
            // 
            this.PlacasTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PlacasTextBox.Location = new System.Drawing.Point(197, 95);
            this.PlacasTextBox.Name = "PlacasTextBox";
            this.PlacasTextBox.Size = new System.Drawing.Size(100, 21);
            this.PlacasTextBox.TabIndex = 5;
            this.PlacasTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlacasTextBox_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Placas:";
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.Location = new System.Drawing.Point(197, 122);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.Size = new System.Drawing.Size(437, 21);
            this.ClienteTextBox.TabIndex = 7;
            this.ClienteTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClienteTextBox_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(21, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Por favor, capture la unidad a reparar";
            // 
            // UnidadesDataGridView
            // 
            this.UnidadesDataGridView.AllowUserToAddRows = false;
            this.UnidadesDataGridView.AllowUserToDeleteRows = false;
            this.UnidadesDataGridView.AutoGenerateColumns = false;
            this.UnidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnidadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Empresa,
            this.numeroEconomicoDataGridViewTextBoxColumn,
            this.placasDataGridViewTextBoxColumn,
            this.conductorDataGridViewTextBoxColumn,
            this.empresaDataGridViewTextBoxColumn,
            this.unidadIDDataGridViewTextBoxColumn,
            this.empresaIDDataGridViewTextBoxColumn,
            this.conductorIDDataGridViewTextBoxColumn});
            this.UnidadesDataGridView.DataSource = this.datosUnidadTallerBindingSource;
            this.UnidadesDataGridView.Location = new System.Drawing.Point(24, 191);
            this.UnidadesDataGridView.Name = "UnidadesDataGridView";
            this.UnidadesDataGridView.ReadOnly = true;
            this.UnidadesDataGridView.Size = new System.Drawing.Size(656, 314);
            this.UnidadesDataGridView.TabIndex = 10;
            this.UnidadesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnidadesDataGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // numeroEconomicoDataGridViewTextBoxColumn
            // 
            this.numeroEconomicoDataGridViewTextBoxColumn.DataPropertyName = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.HeaderText = "NumeroEconomico";
            this.numeroEconomicoDataGridViewTextBoxColumn.Name = "numeroEconomicoDataGridViewTextBoxColumn";
            this.numeroEconomicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placasDataGridViewTextBoxColumn
            // 
            this.placasDataGridViewTextBoxColumn.DataPropertyName = "Placas";
            this.placasDataGridViewTextBoxColumn.HeaderText = "Placas";
            this.placasDataGridViewTextBoxColumn.Name = "placasDataGridViewTextBoxColumn";
            this.placasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conductorDataGridViewTextBoxColumn
            // 
            this.conductorDataGridViewTextBoxColumn.DataPropertyName = "Conductor";
            this.conductorDataGridViewTextBoxColumn.HeaderText = "Conductor";
            this.conductorDataGridViewTextBoxColumn.Name = "conductorDataGridViewTextBoxColumn";
            this.conductorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empresaDataGridViewTextBoxColumn
            // 
            this.empresaDataGridViewTextBoxColumn.DataPropertyName = "Empresa";
            this.empresaDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.empresaDataGridViewTextBoxColumn.Name = "empresaDataGridViewTextBoxColumn";
            this.empresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadIDDataGridViewTextBoxColumn
            // 
            this.unidadIDDataGridViewTextBoxColumn.DataPropertyName = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.HeaderText = "Unidad_ID";
            this.unidadIDDataGridViewTextBoxColumn.Name = "unidadIDDataGridViewTextBoxColumn";
            this.unidadIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // empresaIDDataGridViewTextBoxColumn
            // 
            this.empresaIDDataGridViewTextBoxColumn.DataPropertyName = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.HeaderText = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.Name = "empresaIDDataGridViewTextBoxColumn";
            this.empresaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.empresaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // conductorIDDataGridViewTextBoxColumn
            // 
            this.conductorIDDataGridViewTextBoxColumn.DataPropertyName = "Conductor_ID";
            this.conductorIDDataGridViewTextBoxColumn.HeaderText = "Conductor_ID";
            this.conductorIDDataGridViewTextBoxColumn.Name = "conductorIDDataGridViewTextBoxColumn";
            this.conductorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.conductorIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // datosUnidadTallerBindingSource
            // 
            this.datosUnidadTallerBindingSource.DataSource = typeof(SICASv20.Entities.DatosUnidadTaller);
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Image = global::SICASv20.Properties.Resources.forward;
            this.SiguienteButton.Location = new System.Drawing.Point(593, 511);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 11;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiguienteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(500, 511);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 12;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // ModeloTextBox
            // 
            this.ModeloTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ModeloTextBox.Location = new System.Drawing.Point(197, 149);
            this.ModeloTextBox.Name = "ModeloTextBox";
            this.ModeloTextBox.Size = new System.Drawing.Size(241, 21);
            this.ModeloTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Modelo:";
            // 
            // ActualizarModeloButton
            // 
            this.ActualizarModeloButton.Location = new System.Drawing.Point(491, 147);
            this.ActualizarModeloButton.Name = "ActualizarModeloButton";
            this.ActualizarModeloButton.Size = new System.Drawing.Size(143, 30);
            this.ActualizarModeloButton.TabIndex = 15;
            this.ActualizarModeloButton.Text = "Actualizar modelo";
            this.ActualizarModeloButton.UseVisualStyleBackColor = true;
            this.ActualizarModeloButton.Click += new System.EventHandler(this.ActualizarModeloButton_Click);
            // 
            // UnidadUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ActualizarModeloButton);
            this.Controls.Add(this.ModeloTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.UnidadesDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ClienteTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PlacasTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConductorHabitualTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumeroEconomicoTextBox);
            this.Controls.Add(this.label1);
            this.Name = "UnidadUC";
            this.Size = new System.Drawing.Size(694, 557);
            ((System.ComponentModel.ISupportInitialize)(this.UnidadesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosUnidadTallerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumeroEconomicoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ConductorHabitualTextBox;
        private System.Windows.Forms.TextBox PlacasTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClienteTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView UnidadesDataGridView;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.BindingSource datosUnidadTallerBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroEconomicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conductorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox ModeloTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ActualizarModeloButton;
    }
}
