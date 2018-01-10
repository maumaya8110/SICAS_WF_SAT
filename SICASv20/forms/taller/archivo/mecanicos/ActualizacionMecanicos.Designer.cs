namespace SICASv20.forms
{
    partial class ActualizacionMecanicos
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
            this.MecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CategoriasMecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstatusMecanicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.Mecanico_IDLabel = new System.Windows.Forms.Label();
            this.Mecanico_IDTextBox = new System.Windows.Forms.TextBox();
            this.CategoriaMecanico_IDLabel = new System.Windows.Forms.Label();
            this.CategoriaMecanico_IDComboBox = new System.Windows.Forms.ComboBox();
            this.EstatusMecanico_IDLabel = new System.Windows.Forms.Label();
            this.EstatusMecanico_IDComboBox = new System.Windows.Forms.ComboBox();
            this.CodigoBarrasLabel = new System.Windows.Forms.Label();
            this.CodigoBarrasTextBox = new System.Windows.Forms.TextBox();
            this.NombresLabel = new System.Windows.Forms.Label();
            this.NombresTextBox = new System.Windows.Forms.TextBox();
            this.ApellidosLabel = new System.Windows.Forms.Label();
            this.ApellidosTextBox = new System.Windows.Forms.TextBox();
            this.RfcLabel = new System.Windows.Forms.Label();
            this.RfcTextBox = new System.Windows.Forms.TextBox();
            this.CurpLabel = new System.Windows.Forms.Label();
            this.CurpTextBox = new System.Windows.Forms.TextBox();
            this.NSSLabel = new System.Windows.Forms.Label();
            this.NSSTextBox = new System.Windows.Forms.TextBox();
            this.DomicilioLabel = new System.Windows.Forms.Label();
            this.DomicilioTextBox = new System.Windows.Forms.TextBox();
            this.CiudadLabel = new System.Windows.Forms.Label();
            this.CiudadTextBox = new System.Windows.Forms.TextBox();
            this.EntidadLabel = new System.Windows.Forms.Label();
            this.EntidadTextBox = new System.Windows.Forms.TextBox();
            this.CodigoPostalLabel = new System.Windows.Forms.Label();
            this.CodigoPostalTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoLabel = new System.Windows.Forms.Label();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.CorreoElectronicoLabel = new System.Windows.Forms.Label();
            this.CorreoElectronicoTextBox = new System.Windows.Forms.TextBox();
            this.SalarioDiarioLabel = new System.Windows.Forms.Label();
            this.SalarioDiarioTextBox = new System.Windows.Forms.TextBox();
            this.HorarioEntradaLabel = new System.Windows.Forms.Label();
            this.HorarioEntradaTextBox = new System.Windows.Forms.TextBox();
            this.HorarioSalidaLabel = new System.Windows.Forms.Label();
            this.HorarioSalidaTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.MecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasMecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstatusMecanicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MecanicosBindingSource
            // 
            this.MecanicosBindingSource.DataSource = typeof(SICASv20.Entities.Mecanicos);
            // 
            // CategoriasMecanicosBindingSource
            // 
            this.CategoriasMecanicosBindingSource.DataSource = typeof(SICASv20.Entities.CategoriasMecanicos);
            // 
            // EstatusMecanicosBindingSource
            // 
            this.EstatusMecanicosBindingSource.DataSource = typeof(SICASv20.Entities.EstatusMecanicos);
            // 
            // UsuariosBindingSource
            // 
            this.UsuariosBindingSource.DataSource = typeof(SICASv20.Entities.Usuarios);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(511, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(119, 42);
            this.GuardarButton.TabIndex = 43;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(511, 70);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(119, 42);
            this.CancelarButton.TabIndex = 42;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // Mecanico_IDLabel
            // 
            this.Mecanico_IDLabel.AutoSize = true;
            this.Mecanico_IDLabel.Location = new System.Drawing.Point(18, 37);
            this.Mecanico_IDLabel.Name = "Mecanico_IDLabel";
            this.Mecanico_IDLabel.Size = new System.Drawing.Size(83, 15);
            this.Mecanico_IDLabel.TabIndex = 1;
            this.Mecanico_IDLabel.Text = "Mecanico_ID:";
            // 
            // Mecanico_IDTextBox
            // 
            this.Mecanico_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Mecanico_ID", true));
            this.Mecanico_IDTextBox.Location = new System.Drawing.Point(203, 37);
            this.Mecanico_IDTextBox.Name = "Mecanico_IDTextBox";
            this.Mecanico_IDTextBox.ReadOnly = true;
            this.Mecanico_IDTextBox.Size = new System.Drawing.Size(150, 21);
            this.Mecanico_IDTextBox.TabIndex = 2;
            // 
            // CategoriaMecanico_IDLabel
            // 
            this.CategoriaMecanico_IDLabel.AutoSize = true;
            this.CategoriaMecanico_IDLabel.Location = new System.Drawing.Point(18, 64);
            this.CategoriaMecanico_IDLabel.Name = "CategoriaMecanico_IDLabel";
            this.CategoriaMecanico_IDLabel.Size = new System.Drawing.Size(136, 15);
            this.CategoriaMecanico_IDLabel.TabIndex = 3;
            this.CategoriaMecanico_IDLabel.Text = "CategoriaMecanico_ID:";
            // 
            // CategoriaMecanico_IDComboBox
            // 
            this.CategoriaMecanico_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.MecanicosBindingSource, "CategoriaMecanico_ID", true));
            this.CategoriaMecanico_IDComboBox.DataSource = this.CategoriasMecanicosBindingSource;
            this.CategoriaMecanico_IDComboBox.DisplayMember = "Nombre";
            this.CategoriaMecanico_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriaMecanico_IDComboBox.FormattingEnabled = true;
            this.CategoriaMecanico_IDComboBox.Location = new System.Drawing.Point(203, 64);
            this.CategoriaMecanico_IDComboBox.Name = "CategoriaMecanico_IDComboBox";
            this.CategoriaMecanico_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.CategoriaMecanico_IDComboBox.TabIndex = 4;
            this.CategoriaMecanico_IDComboBox.ValueMember = "CategoriaMecanico_ID";
            // 
            // EstatusMecanico_IDLabel
            // 
            this.EstatusMecanico_IDLabel.AutoSize = true;
            this.EstatusMecanico_IDLabel.Location = new System.Drawing.Point(18, 91);
            this.EstatusMecanico_IDLabel.Name = "EstatusMecanico_IDLabel";
            this.EstatusMecanico_IDLabel.Size = new System.Drawing.Size(123, 15);
            this.EstatusMecanico_IDLabel.TabIndex = 5;
            this.EstatusMecanico_IDLabel.Text = "EstatusMecanico_ID:";
            // 
            // EstatusMecanico_IDComboBox
            // 
            this.EstatusMecanico_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.MecanicosBindingSource, "EstatusMecanico_ID", true));
            this.EstatusMecanico_IDComboBox.DataSource = this.EstatusMecanicosBindingSource;
            this.EstatusMecanico_IDComboBox.DisplayMember = "Nombre";
            this.EstatusMecanico_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstatusMecanico_IDComboBox.FormattingEnabled = true;
            this.EstatusMecanico_IDComboBox.Location = new System.Drawing.Point(203, 91);
            this.EstatusMecanico_IDComboBox.Name = "EstatusMecanico_IDComboBox";
            this.EstatusMecanico_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.EstatusMecanico_IDComboBox.TabIndex = 6;
            this.EstatusMecanico_IDComboBox.ValueMember = "EstatusMecanico_ID";
            // 
            // CodigoBarrasLabel
            // 
            this.CodigoBarrasLabel.AutoSize = true;
            this.CodigoBarrasLabel.Location = new System.Drawing.Point(18, 120);
            this.CodigoBarrasLabel.Name = "CodigoBarrasLabel";
            this.CodigoBarrasLabel.Size = new System.Drawing.Size(85, 15);
            this.CodigoBarrasLabel.TabIndex = 12;
            this.CodigoBarrasLabel.Text = "CodigoBarras:";
            // 
            // CodigoBarrasTextBox
            // 
            this.CodigoBarrasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "CodigoBarras", true));
            this.CodigoBarrasTextBox.Location = new System.Drawing.Point(203, 120);
            this.CodigoBarrasTextBox.Name = "CodigoBarrasTextBox";
            this.CodigoBarrasTextBox.Size = new System.Drawing.Size(150, 21);
            this.CodigoBarrasTextBox.TabIndex = 13;
            // 
            // NombresLabel
            // 
            this.NombresLabel.AutoSize = true;
            this.NombresLabel.Location = new System.Drawing.Point(18, 147);
            this.NombresLabel.Name = "NombresLabel";
            this.NombresLabel.Size = new System.Drawing.Size(61, 15);
            this.NombresLabel.TabIndex = 14;
            this.NombresLabel.Text = "Nombres:";
            // 
            // NombresTextBox
            // 
            this.NombresTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Nombres", true));
            this.NombresTextBox.Location = new System.Drawing.Point(203, 147);
            this.NombresTextBox.Name = "NombresTextBox";
            this.NombresTextBox.Size = new System.Drawing.Size(225, 21);
            this.NombresTextBox.TabIndex = 15;
            // 
            // ApellidosLabel
            // 
            this.ApellidosLabel.AutoSize = true;
            this.ApellidosLabel.Location = new System.Drawing.Point(18, 174);
            this.ApellidosLabel.Name = "ApellidosLabel";
            this.ApellidosLabel.Size = new System.Drawing.Size(60, 15);
            this.ApellidosLabel.TabIndex = 16;
            this.ApellidosLabel.Text = "Apellidos:";
            // 
            // ApellidosTextBox
            // 
            this.ApellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Apellidos", true));
            this.ApellidosTextBox.Location = new System.Drawing.Point(203, 174);
            this.ApellidosTextBox.Name = "ApellidosTextBox";
            this.ApellidosTextBox.Size = new System.Drawing.Size(225, 21);
            this.ApellidosTextBox.TabIndex = 17;
            // 
            // RfcLabel
            // 
            this.RfcLabel.AutoSize = true;
            this.RfcLabel.Location = new System.Drawing.Point(18, 201);
            this.RfcLabel.Name = "RfcLabel";
            this.RfcLabel.Size = new System.Drawing.Size(28, 15);
            this.RfcLabel.TabIndex = 18;
            this.RfcLabel.Text = "Rfc:";
            // 
            // RfcTextBox
            // 
            this.RfcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Rfc", true));
            this.RfcTextBox.Location = new System.Drawing.Point(203, 201);
            this.RfcTextBox.Name = "RfcTextBox";
            this.RfcTextBox.Size = new System.Drawing.Size(150, 21);
            this.RfcTextBox.TabIndex = 19;
            // 
            // CurpLabel
            // 
            this.CurpLabel.AutoSize = true;
            this.CurpLabel.Location = new System.Drawing.Point(18, 228);
            this.CurpLabel.Name = "CurpLabel";
            this.CurpLabel.Size = new System.Drawing.Size(36, 15);
            this.CurpLabel.TabIndex = 20;
            this.CurpLabel.Text = "Curp:";
            // 
            // CurpTextBox
            // 
            this.CurpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Curp", true));
            this.CurpTextBox.Location = new System.Drawing.Point(203, 228);
            this.CurpTextBox.Name = "CurpTextBox";
            this.CurpTextBox.Size = new System.Drawing.Size(150, 21);
            this.CurpTextBox.TabIndex = 21;
            // 
            // NSSLabel
            // 
            this.NSSLabel.AutoSize = true;
            this.NSSLabel.Location = new System.Drawing.Point(18, 255);
            this.NSSLabel.Name = "NSSLabel";
            this.NSSLabel.Size = new System.Drawing.Size(35, 15);
            this.NSSLabel.TabIndex = 22;
            this.NSSLabel.Text = "NSS:";
            // 
            // NSSTextBox
            // 
            this.NSSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "NSS", true));
            this.NSSTextBox.Location = new System.Drawing.Point(203, 255);
            this.NSSTextBox.Name = "NSSTextBox";
            this.NSSTextBox.Size = new System.Drawing.Size(150, 21);
            this.NSSTextBox.TabIndex = 23;
            // 
            // DomicilioLabel
            // 
            this.DomicilioLabel.AutoSize = true;
            this.DomicilioLabel.Location = new System.Drawing.Point(18, 282);
            this.DomicilioLabel.Name = "DomicilioLabel";
            this.DomicilioLabel.Size = new System.Drawing.Size(62, 15);
            this.DomicilioLabel.TabIndex = 24;
            this.DomicilioLabel.Text = "Domicilio:";
            // 
            // DomicilioTextBox
            // 
            this.DomicilioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Domicilio", true));
            this.DomicilioTextBox.Location = new System.Drawing.Point(203, 282);
            this.DomicilioTextBox.Name = "DomicilioTextBox";
            this.DomicilioTextBox.Size = new System.Drawing.Size(225, 21);
            this.DomicilioTextBox.TabIndex = 25;
            // 
            // CiudadLabel
            // 
            this.CiudadLabel.AutoSize = true;
            this.CiudadLabel.Location = new System.Drawing.Point(18, 309);
            this.CiudadLabel.Name = "CiudadLabel";
            this.CiudadLabel.Size = new System.Drawing.Size(49, 15);
            this.CiudadLabel.TabIndex = 26;
            this.CiudadLabel.Text = "Ciudad:";
            // 
            // CiudadTextBox
            // 
            this.CiudadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Ciudad", true));
            this.CiudadTextBox.Location = new System.Drawing.Point(203, 309);
            this.CiudadTextBox.Name = "CiudadTextBox";
            this.CiudadTextBox.Size = new System.Drawing.Size(225, 21);
            this.CiudadTextBox.TabIndex = 27;
            // 
            // EntidadLabel
            // 
            this.EntidadLabel.AutoSize = true;
            this.EntidadLabel.Location = new System.Drawing.Point(18, 336);
            this.EntidadLabel.Name = "EntidadLabel";
            this.EntidadLabel.Size = new System.Drawing.Size(52, 15);
            this.EntidadLabel.TabIndex = 28;
            this.EntidadLabel.Text = "Entidad:";
            // 
            // EntidadTextBox
            // 
            this.EntidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Entidad", true));
            this.EntidadTextBox.Location = new System.Drawing.Point(203, 336);
            this.EntidadTextBox.Name = "EntidadTextBox";
            this.EntidadTextBox.Size = new System.Drawing.Size(150, 21);
            this.EntidadTextBox.TabIndex = 29;
            // 
            // CodigoPostalLabel
            // 
            this.CodigoPostalLabel.AutoSize = true;
            this.CodigoPostalLabel.Location = new System.Drawing.Point(18, 363);
            this.CodigoPostalLabel.Name = "CodigoPostalLabel";
            this.CodigoPostalLabel.Size = new System.Drawing.Size(83, 15);
            this.CodigoPostalLabel.TabIndex = 30;
            this.CodigoPostalLabel.Text = "CodigoPostal:";
            // 
            // CodigoPostalTextBox
            // 
            this.CodigoPostalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "CodigoPostal", true));
            this.CodigoPostalTextBox.Location = new System.Drawing.Point(203, 363);
            this.CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            this.CodigoPostalTextBox.Size = new System.Drawing.Size(129, 21);
            this.CodigoPostalTextBox.TabIndex = 31;
            // 
            // TelefonoLabel
            // 
            this.TelefonoLabel.AutoSize = true;
            this.TelefonoLabel.Location = new System.Drawing.Point(18, 390);
            this.TelefonoLabel.Name = "TelefonoLabel";
            this.TelefonoLabel.Size = new System.Drawing.Size(58, 15);
            this.TelefonoLabel.TabIndex = 32;
            this.TelefonoLabel.Text = "Telefono:";
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "Telefono", true));
            this.TelefonoTextBox.Location = new System.Drawing.Point(203, 390);
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.Size = new System.Drawing.Size(129, 21);
            this.TelefonoTextBox.TabIndex = 33;
            // 
            // CorreoElectronicoLabel
            // 
            this.CorreoElectronicoLabel.AutoSize = true;
            this.CorreoElectronicoLabel.Location = new System.Drawing.Point(18, 417);
            this.CorreoElectronicoLabel.Name = "CorreoElectronicoLabel";
            this.CorreoElectronicoLabel.Size = new System.Drawing.Size(108, 15);
            this.CorreoElectronicoLabel.TabIndex = 34;
            this.CorreoElectronicoLabel.Text = "CorreoElectronico:";
            // 
            // CorreoElectronicoTextBox
            // 
            this.CorreoElectronicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "CorreoElectronico", true));
            this.CorreoElectronicoTextBox.Location = new System.Drawing.Point(203, 417);
            this.CorreoElectronicoTextBox.Name = "CorreoElectronicoTextBox";
            this.CorreoElectronicoTextBox.Size = new System.Drawing.Size(225, 21);
            this.CorreoElectronicoTextBox.TabIndex = 35;
            // 
            // SalarioDiarioLabel
            // 
            this.SalarioDiarioLabel.AutoSize = true;
            this.SalarioDiarioLabel.Location = new System.Drawing.Point(18, 444);
            this.SalarioDiarioLabel.Name = "SalarioDiarioLabel";
            this.SalarioDiarioLabel.Size = new System.Drawing.Size(82, 15);
            this.SalarioDiarioLabel.TabIndex = 36;
            this.SalarioDiarioLabel.Text = "SalarioDiario:";
            // 
            // SalarioDiarioTextBox
            // 
            this.SalarioDiarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "SalarioDiario", true));
            this.SalarioDiarioTextBox.Location = new System.Drawing.Point(203, 444);
            this.SalarioDiarioTextBox.Name = "SalarioDiarioTextBox";
            this.SalarioDiarioTextBox.Size = new System.Drawing.Size(106, 21);
            this.SalarioDiarioTextBox.TabIndex = 37;
            // 
            // HorarioEntradaLabel
            // 
            this.HorarioEntradaLabel.AutoSize = true;
            this.HorarioEntradaLabel.Location = new System.Drawing.Point(18, 471);
            this.HorarioEntradaLabel.Name = "HorarioEntradaLabel";
            this.HorarioEntradaLabel.Size = new System.Drawing.Size(94, 15);
            this.HorarioEntradaLabel.TabIndex = 38;
            this.HorarioEntradaLabel.Text = "HorarioEntrada:";
            // 
            // HorarioEntradaTextBox
            // 
            this.HorarioEntradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "HorarioEntrada", true));
            this.HorarioEntradaTextBox.Location = new System.Drawing.Point(203, 471);
            this.HorarioEntradaTextBox.Name = "HorarioEntradaTextBox";
            this.HorarioEntradaTextBox.Size = new System.Drawing.Size(106, 21);
            this.HorarioEntradaTextBox.TabIndex = 39;
            // 
            // HorarioSalidaLabel
            // 
            this.HorarioSalidaLabel.AutoSize = true;
            this.HorarioSalidaLabel.Location = new System.Drawing.Point(18, 498);
            this.HorarioSalidaLabel.Name = "HorarioSalidaLabel";
            this.HorarioSalidaLabel.Size = new System.Drawing.Size(86, 15);
            this.HorarioSalidaLabel.TabIndex = 40;
            this.HorarioSalidaLabel.Text = "HorarioSalida:";
            // 
            // HorarioSalidaTextBox
            // 
            this.HorarioSalidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MecanicosBindingSource, "HorarioSalida", true));
            this.HorarioSalidaTextBox.Location = new System.Drawing.Point(203, 498);
            this.HorarioSalidaTextBox.Name = "HorarioSalidaTextBox";
            this.HorarioSalidaTextBox.Size = new System.Drawing.Size(106, 21);
            this.HorarioSalidaTextBox.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Mecanico_IDLabel);
            this.groupBox1.Controls.Add(this.HorarioSalidaTextBox);
            this.groupBox1.Controls.Add(this.Mecanico_IDTextBox);
            this.groupBox1.Controls.Add(this.HorarioSalidaLabel);
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDLabel);
            this.groupBox1.Controls.Add(this.HorarioEntradaTextBox);
            this.groupBox1.Controls.Add(this.CategoriaMecanico_IDComboBox);
            this.groupBox1.Controls.Add(this.HorarioEntradaLabel);
            this.groupBox1.Controls.Add(this.EstatusMecanico_IDLabel);
            this.groupBox1.Controls.Add(this.SalarioDiarioTextBox);
            this.groupBox1.Controls.Add(this.EstatusMecanico_IDComboBox);
            this.groupBox1.Controls.Add(this.SalarioDiarioLabel);
            this.groupBox1.Controls.Add(this.CorreoElectronicoTextBox);
            this.groupBox1.Controls.Add(this.CorreoElectronicoLabel);
            this.groupBox1.Controls.Add(this.TelefonoTextBox);
            this.groupBox1.Controls.Add(this.TelefonoLabel);
            this.groupBox1.Controls.Add(this.CodigoPostalTextBox);
            this.groupBox1.Controls.Add(this.CodigoBarrasLabel);
            this.groupBox1.Controls.Add(this.CodigoPostalLabel);
            this.groupBox1.Controls.Add(this.CodigoBarrasTextBox);
            this.groupBox1.Controls.Add(this.EntidadTextBox);
            this.groupBox1.Controls.Add(this.NombresLabel);
            this.groupBox1.Controls.Add(this.EntidadLabel);
            this.groupBox1.Controls.Add(this.NombresTextBox);
            this.groupBox1.Controls.Add(this.CiudadTextBox);
            this.groupBox1.Controls.Add(this.ApellidosLabel);
            this.groupBox1.Controls.Add(this.CiudadLabel);
            this.groupBox1.Controls.Add(this.ApellidosTextBox);
            this.groupBox1.Controls.Add(this.DomicilioTextBox);
            this.groupBox1.Controls.Add(this.RfcLabel);
            this.groupBox1.Controls.Add(this.DomicilioLabel);
            this.groupBox1.Controls.Add(this.RfcTextBox);
            this.groupBox1.Controls.Add(this.NSSTextBox);
            this.groupBox1.Controls.Add(this.CurpLabel);
            this.groupBox1.Controls.Add(this.NSSLabel);
            this.groupBox1.Controls.Add(this.CurpTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 587);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de mecánico";
            // 
            // ActualizacionMecanicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionMecanicos";
            this.Text = "AltaMecanicos";
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.CancelarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasMecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstatusMecanicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label Mecanico_IDLabel;
        private System.Windows.Forms.TextBox Mecanico_IDTextBox;
        private System.Windows.Forms.Label CategoriaMecanico_IDLabel;
        private System.Windows.Forms.ComboBox CategoriaMecanico_IDComboBox;
        private System.Windows.Forms.Label EstatusMecanico_IDLabel;
        private System.Windows.Forms.ComboBox EstatusMecanico_IDComboBox;
        private System.Windows.Forms.Label CodigoBarrasLabel;
        private System.Windows.Forms.TextBox CodigoBarrasTextBox;
        private System.Windows.Forms.Label NombresLabel;
        private System.Windows.Forms.TextBox NombresTextBox;
        private System.Windows.Forms.Label ApellidosLabel;
        private System.Windows.Forms.TextBox ApellidosTextBox;
        private System.Windows.Forms.Label RfcLabel;
        private System.Windows.Forms.TextBox RfcTextBox;
        private System.Windows.Forms.Label CurpLabel;
        private System.Windows.Forms.TextBox CurpTextBox;
        private System.Windows.Forms.Label NSSLabel;
        private System.Windows.Forms.TextBox NSSTextBox;
        private System.Windows.Forms.Label DomicilioLabel;
        private System.Windows.Forms.TextBox DomicilioTextBox;
        private System.Windows.Forms.Label CiudadLabel;
        private System.Windows.Forms.TextBox CiudadTextBox;
        private System.Windows.Forms.Label EntidadLabel;
        private System.Windows.Forms.TextBox EntidadTextBox;
        private System.Windows.Forms.Label CodigoPostalLabel;
        private System.Windows.Forms.TextBox CodigoPostalTextBox;
        private System.Windows.Forms.Label TelefonoLabel;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.Label CorreoElectronicoLabel;
        private System.Windows.Forms.TextBox CorreoElectronicoTextBox;
        private System.Windows.Forms.Label SalarioDiarioLabel;
        private System.Windows.Forms.TextBox SalarioDiarioTextBox;
        private System.Windows.Forms.Label HorarioEntradaLabel;
        private System.Windows.Forms.TextBox HorarioEntradaTextBox;
        private System.Windows.Forms.Label HorarioSalidaLabel;
        private System.Windows.Forms.TextBox HorarioSalidaTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.BindingSource MecanicosBindingSource;
        private System.Windows.Forms.BindingSource CategoriasMecanicosBindingSource;
        private System.Windows.Forms.BindingSource EstatusMecanicosBindingSource;
        private System.Windows.Forms.BindingSource UsuariosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;


        

    }
}