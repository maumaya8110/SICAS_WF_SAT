namespace SICASv20.forms
{
    partial class CobrarAUC
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
            this.ClienteLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientesDataGridView = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.empresaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscarClienteTextBox = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.AnteriorButton = new System.Windows.Forms.Button();
            this.SiguienteButton = new System.Windows.Forms.Button();
            this.ClienteRadioButton = new System.Windows.Forms.RadioButton();
            this.OtroRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "¿A quien se cobrará la reparación?";
            // 
            // ClienteLabel
            // 
            this.ClienteLabel.AutoSize = true;
            this.ClienteLabel.Location = new System.Drawing.Point(40, 52);
            this.ClienteLabel.Name = "ClienteLabel";
            this.ClienteLabel.Size = new System.Drawing.Size(0, 15);
            this.ClienteLabel.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cliente:";
            // 
            // ClientesDataGridView
            // 
            this.ClientesDataGridView.AutoGenerateColumns = false;
            this.ClientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.empresaIDDataGridViewTextBoxColumn,
            this.rFCDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn});
            this.ClientesDataGridView.DataSource = this.empresasBindingSource;
            this.ClientesDataGridView.Location = new System.Drawing.Point(19, 131);
            this.ClientesDataGridView.Name = "ClientesDataGridView";
            this.ClientesDataGridView.Size = new System.Drawing.Size(662, 373);
            this.ClientesDataGridView.TabIndex = 15;
            this.ClientesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientesDataGridView_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseColumnTextForLinkValue = true;
            // 
            // empresaIDDataGridViewTextBoxColumn
            // 
            this.empresaIDDataGridViewTextBoxColumn.DataPropertyName = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.HeaderText = "Empresa_ID";
            this.empresaIDDataGridViewTextBoxColumn.Name = "empresaIDDataGridViewTextBoxColumn";
            // 
            // rFCDataGridViewTextBoxColumn
            // 
            this.rFCDataGridViewTextBoxColumn.DataPropertyName = "RFC";
            this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
            this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataSource = typeof(SICASv20.Entities.Empresas);
            // 
            // BuscarClienteTextBox
            // 
            this.BuscarClienteTextBox.Location = new System.Drawing.Point(70, 95);
            this.BuscarClienteTextBox.Name = "BuscarClienteTextBox";
            this.BuscarClienteTextBox.Size = new System.Drawing.Size(399, 21);
            this.BuscarClienteTextBox.TabIndex = 17;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Image = global::SICASv20.Properties.Resources.search;
            this.BuscarButton.Location = new System.Drawing.Point(475, 91);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(99, 29);
            this.BuscarButton.TabIndex = 18;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuscarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.Image = global::SICASv20.Properties.Resources.back;
            this.AnteriorButton.Location = new System.Drawing.Point(501, 510);
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(87, 31);
            this.AnteriorButton.TabIndex = 20;
            this.AnteriorButton.Text = "Atrás";
            this.AnteriorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AnteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AnteriorButton.UseVisualStyleBackColor = true;
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // SiguienteButton
            // 
            this.SiguienteButton.Image = global::SICASv20.Properties.Resources.forward;
            this.SiguienteButton.Location = new System.Drawing.Point(594, 510);
            this.SiguienteButton.Name = "SiguienteButton";
            this.SiguienteButton.Size = new System.Drawing.Size(87, 31);
            this.SiguienteButton.TabIndex = 19;
            this.SiguienteButton.Text = "Siguiente";
            this.SiguienteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SiguienteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.SiguienteButton.UseVisualStyleBackColor = true;
            this.SiguienteButton.Click += new System.EventHandler(this.SiguienteButton_Click);
            // 
            // ClienteRadioButton
            // 
            this.ClienteRadioButton.AutoSize = true;
            this.ClienteRadioButton.Checked = true;
            this.ClienteRadioButton.Location = new System.Drawing.Point(19, 47);
            this.ClienteRadioButton.Name = "ClienteRadioButton";
            this.ClienteRadioButton.Size = new System.Drawing.Size(14, 13);
            this.ClienteRadioButton.TabIndex = 21;
            this.ClienteRadioButton.TabStop = true;
            this.ClienteRadioButton.UseVisualStyleBackColor = true;
            this.ClienteRadioButton.CheckedChanged += new System.EventHandler(this.ClienteRadioButton_CheckedChanged);
            // 
            // OtroRadioButton
            // 
            this.OtroRadioButton.AutoSize = true;
            this.OtroRadioButton.Location = new System.Drawing.Point(19, 70);
            this.OtroRadioButton.Name = "OtroRadioButton";
            this.OtroRadioButton.Size = new System.Drawing.Size(48, 19);
            this.OtroRadioButton.TabIndex = 22;
            this.OtroRadioButton.TabStop = true;
            this.OtroRadioButton.Text = "Otro";
            this.OtroRadioButton.UseVisualStyleBackColor = true;
            this.OtroRadioButton.CheckedChanged += new System.EventHandler(this.OtroRadioButton_CheckedChanged);
            // 
            // CobrarAUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OtroRadioButton);
            this.Controls.Add(this.ClienteRadioButton);
            this.Controls.Add(this.AnteriorButton);
            this.Controls.Add(this.SiguienteButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.BuscarClienteTextBox);
            this.Controls.Add(this.ClientesDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClienteLabel);
            this.Controls.Add(this.label5);
            this.Name = "CobrarAUC";
            this.Size = new System.Drawing.Size(694, 557);
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ClienteLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ClientesDataGridView;
        private System.Windows.Forms.TextBox BuscarClienteTextBox;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridViewLinkColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.Button AnteriorButton;
        private System.Windows.Forms.Button SiguienteButton;
        private System.Windows.Forms.RadioButton ClienteRadioButton;
        private System.Windows.Forms.RadioButton OtroRadioButton;
    }
}
