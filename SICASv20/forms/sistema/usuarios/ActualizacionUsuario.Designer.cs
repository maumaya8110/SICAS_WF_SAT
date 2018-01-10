namespace SICASv20.forms
{
    partial class ActualizacionUsuario
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
            System.Windows.Forms.Label usuario_IDLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label apellidosLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label activoLabel;
            System.Windows.Forms.Label pwdLabel;
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.UsuariosTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.activoCheckBox = new System.Windows.Forms.CheckBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.getSelectEmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.getSelectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.getEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_EmpresasInternasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter();
            this.get_SelectEmpresasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectEmpresasTableAdapter();
            this.get_SelectEstacionesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectEstacionesTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PermisosDeGrupoButton = new System.Windows.Forms.Button();
            this.SelectNoneButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.PermisosTreeView = new System.Windows.Forms.TreeView();
            this.CambioPwdButton = new System.Windows.Forms.Button();
            this.PerisosCajaButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EmpresasLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EmpresasCheckList = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EstacionesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EstacionesCheckList = new System.Windows.Forms.CheckedListBox();
            usuario_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            activoLabel = new System.Windows.Forms.Label();
            pwdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(29, 37);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 1;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(29, 64);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 3;
            nombreLabel.Text = "Nombre:";
            // 
            // apellidosLabel
            // 
            apellidosLabel.AutoSize = true;
            apellidosLabel.Location = new System.Drawing.Point(29, 91);
            apellidosLabel.Name = "apellidosLabel";
            apellidosLabel.Size = new System.Drawing.Size(60, 15);
            apellidosLabel.TabIndex = 5;
            apellidosLabel.Text = "Apellidos:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(29, 118);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(42, 15);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "Email:";
            // 
            // activoLabel
            // 
            activoLabel.AutoSize = true;
            activoLabel.Location = new System.Drawing.Point(29, 147);
            activoLabel.Name = "activoLabel";
            activoLabel.Size = new System.Drawing.Size(41, 15);
            activoLabel.TabIndex = 9;
            activoLabel.Text = "Activo:";
            // 
            // pwdLabel
            // 
            pwdLabel.AutoSize = true;
            pwdLabel.Location = new System.Drawing.Point(29, 175);
            pwdLabel.Name = "pwdLabel";
            pwdLabel.Size = new System.Drawing.Size(64, 15);
            pwdLabel.TabIndex = 11;
            pwdLabel.Text = "Password:";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArrendamientosTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CajasTableAdapter = null;
            this.tableAdapterManager.ClasesPublicidadTableAdapter = null;
            this.tableAdapterManager.ComisionesServiciosTableAdapter = null;
            this.tableAdapterManager.ConceptosTableAdapter = null;
            this.tableAdapterManager.ConcesionesTableAdapter = null;
            this.tableAdapterManager.ConductoresTableAdapter = null;
            this.tableAdapterManager.ContratosTableAdapter = null;
            this.tableAdapterManager.CuentaCajasTableAdapter = null;
            this.tableAdapterManager.CuentaConductoresTableAdapter = null;
            this.tableAdapterManager.CuentaEmpresasTableAdapter = null;
            this.tableAdapterManager.CuentaFlujoCajasTableAdapter = null;
            this.tableAdapterManager.CuentasTableAdapter = null;
            this.tableAdapterManager.CuentaUnidadesTableAdapter = null;
            this.tableAdapterManager.DiasDeCobrosTableAdapter = null;
            this.tableAdapterManager.Empresas_CuentasTableAdapter = null;
            this.tableAdapterManager.EmpresasTableAdapter = null;
            this.tableAdapterManager.EstacionesTableAdapter = null;
            this.tableAdapterManager.EstatusConductoresTableAdapter = null;
            this.tableAdapterManager.EstatusContratosTableAdapter = null;
            this.tableAdapterManager.EstatusFinancierosTableAdapter = null;
            this.tableAdapterManager.EstatusUnidadesTableAdapter = null;
            this.tableAdapterManager.LocacionesUnidadesTableAdapter = null;
            this.tableAdapterManager.MarcasUnidadesTableAdapter = null;
            this.tableAdapterManager.MediosPublicitariosTableAdapter = null;
            this.tableAdapterManager.MenuesTableAdapter = null;
            this.tableAdapterManager.MercadosTableAdapter = null;
            this.tableAdapterManager.ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.ModulosTableAdapter = null;
            this.tableAdapterManager.MonedasTableAdapter = null;
            this.tableAdapterManager.OpcionesTableAdapter = null;
            this.tableAdapterManager.Servicios_ComisionesTableAdapter = null;
            this.tableAdapterManager.ServiciosTableAdapter = null;
            this.tableAdapterManager.SesionesTableAdapter = null;
            this.tableAdapterManager.StatusFinancierosTableAdapter = null;
            this.tableAdapterManager.TicketsTableAdapter = null;
            this.tableAdapterManager.TiposComisionesTableAdapter = null;
            this.tableAdapterManager.TiposConcesionesTableAdapter = null;
            this.tableAdapterManager.TiposContratosTableAdapter = null;
            this.tableAdapterManager.TiposCuentasTableAdapter = null;
            this.tableAdapterManager.TiposEmpresasTableAdapter = null;
            this.tableAdapterManager.TiposLicenciasTableAdapter = null;
            this.tableAdapterManager.UnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = this.usuariosTableAdapter;
            this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuariosBindingSource, "Usuario_ID", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.usuario_IDTextBox.Location = new System.Drawing.Point(110, 34);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.usuario_IDTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuariosBindingSource, "Nombre", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.nombreTextBox.Location = new System.Drawing.Point(110, 61);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(241, 21);
            this.nombreTextBox.TabIndex = 4;
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuariosBindingSource, "Apellidos", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.apellidosTextBox.Location = new System.Drawing.Point(110, 88);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.Size = new System.Drawing.Size(241, 21);
            this.apellidosTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usuariosBindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.emailTextBox.Location = new System.Drawing.Point(110, 115);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 21);
            this.emailTextBox.TabIndex = 8;
            // 
            // activoCheckBox
            // 
            this.activoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.usuariosBindingSource, "Activo", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.activoCheckBox.Location = new System.Drawing.Point(110, 142);
            this.activoCheckBox.Name = "activoCheckBox";
            this.activoCheckBox.Size = new System.Drawing.Size(121, 24);
            this.activoCheckBox.TabIndex = 10;
            this.activoCheckBox.UseVisualStyleBackColor = true;
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Enabled = false;
            this.pwdTextBox.Location = new System.Drawing.Point(110, 172);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '?';
            this.pwdTextBox.Size = new System.Drawing.Size(121, 21);
            this.pwdTextBox.TabIndex = 12;
            // 
            // getSelectEmpresasBindingSource
            // 
            this.getSelectEmpresasBindingSource.DataMember = "Get_SelectEmpresas";
            this.getSelectEmpresasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getSelectEstacionesBindingSource
            // 
            this.getSelectEstacionesBindingSource.DataMember = "Get_SelectEstaciones";
            this.getSelectEstacionesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(usuario_IDLabel);
            this.groupBox1.Controls.Add(this.usuario_IDTextBox);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(apellidosLabel);
            this.groupBox1.Controls.Add(this.pwdTextBox);
            this.groupBox1.Controls.Add(this.apellidosTextBox);
            this.groupBox1.Controls.Add(pwdLabel);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Controls.Add(this.activoCheckBox);
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(activoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 211);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de usuario";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(405, 104);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(144, 29);
            this.GuardarButton.TabIndex = 18;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // getEmpresasInternasBindingSource
            // 
            this.getEmpresasInternasBindingSource.DataMember = "Get_EmpresasInternas";
            this.getEmpresasInternasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_EmpresasInternasTableAdapter
            // 
            this.get_EmpresasInternasTableAdapter.ClearBeforeFill = true;
            // 
            // get_SelectEmpresasTableAdapter
            // 
            this.get_SelectEmpresasTableAdapter.ClearBeforeFill = true;
            // 
            // get_SelectEstacionesTableAdapter
            // 
            this.get_SelectEstacionesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PermisosDeGrupoButton);
            this.groupBox2.Controls.Add(this.SelectNoneButton);
            this.groupBox2.Controls.Add(this.SelectAllButton);
            this.groupBox2.Controls.Add(this.GuardarButton);
            this.groupBox2.Controls.Add(this.PermisosTreeView);
            this.groupBox2.Location = new System.Drawing.Point(401, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 292);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos de usuario";
            // 
            // PermisosDeGrupoButton
            // 
            this.PermisosDeGrupoButton.Location = new System.Drawing.Point(405, 138);
            this.PermisosDeGrupoButton.Name = "PermisosDeGrupoButton";
            this.PermisosDeGrupoButton.Size = new System.Drawing.Size(144, 28);
            this.PermisosDeGrupoButton.TabIndex = 23;
            this.PermisosDeGrupoButton.Text = "Permisos de grupo";
            this.PermisosDeGrupoButton.UseVisualStyleBackColor = true;
            this.PermisosDeGrupoButton.Click += new System.EventHandler(this.PermisosDeGrupoButton_Click);
            // 
            // SelectNoneButton
            // 
            this.SelectNoneButton.Location = new System.Drawing.Point(405, 70);
            this.SelectNoneButton.Name = "SelectNoneButton";
            this.SelectNoneButton.Size = new System.Drawing.Size(144, 28);
            this.SelectNoneButton.TabIndex = 22;
            this.SelectNoneButton.Text = "Seleccionar ninguno";
            this.SelectNoneButton.UseVisualStyleBackColor = true;
            this.SelectNoneButton.Click += new System.EventHandler(this.SelectNoneButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(405, 37);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(144, 28);
            this.SelectAllButton.TabIndex = 21;
            this.SelectAllButton.Text = "Seleccionar todos";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // PermisosTreeView
            // 
            this.PermisosTreeView.CheckBoxes = true;
            this.PermisosTreeView.Location = new System.Drawing.Point(23, 36);
            this.PermisosTreeView.Name = "PermisosTreeView";
            this.PermisosTreeView.Size = new System.Drawing.Size(376, 240);
            this.PermisosTreeView.TabIndex = 0;
            // 
            // CambioPwdButton
            // 
            this.CambioPwdButton.Location = new System.Drawing.Point(252, 250);
            this.CambioPwdButton.Name = "CambioPwdButton";
            this.CambioPwdButton.Size = new System.Drawing.Size(117, 38);
            this.CambioPwdButton.TabIndex = 20;
            this.CambioPwdButton.Text = "Cambiar contraseña";
            this.CambioPwdButton.UseVisualStyleBackColor = true;
            this.CambioPwdButton.Click += new System.EventHandler(this.CambioPwdButton_Click);
            // 
            // PerisosCajaButton
            // 
            this.PerisosCajaButton.Location = new System.Drawing.Point(126, 250);
            this.PerisosCajaButton.Name = "PerisosCajaButton";
            this.PerisosCajaButton.Size = new System.Drawing.Size(117, 38);
            this.PerisosCajaButton.TabIndex = 21;
            this.PerisosCajaButton.Text = "Establecer permisos de caja";
            this.PerisosCajaButton.UseVisualStyleBackColor = true;
            this.PerisosCajaButton.Click += new System.EventHandler(this.PerisosCajaButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EmpresasLinkLabel);
            this.groupBox3.Controls.Add(this.EmpresasCheckList);
            this.groupBox3.Location = new System.Drawing.Point(12, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 234);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Empresas";
            // 
            // EmpresasLinkLabel
            // 
            this.EmpresasLinkLabel.AutoSize = true;
            this.EmpresasLinkLabel.Location = new System.Drawing.Point(238, 20);
            this.EmpresasLinkLabel.Name = "EmpresasLinkLabel";
            this.EmpresasLinkLabel.Size = new System.Drawing.Size(105, 15);
            this.EmpresasLinkLabel.TabIndex = 1;
            this.EmpresasLinkLabel.TabStop = true;
            this.EmpresasLinkLabel.Text = "Seleccionar todas";
            this.EmpresasLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmpresasLinkLabel_LinkClicked);
            // 
            // EmpresasCheckList
            // 
            this.EmpresasCheckList.CheckOnClick = true;
            this.EmpresasCheckList.FormattingEnabled = true;
            this.EmpresasCheckList.Location = new System.Drawing.Point(19, 43);
            this.EmpresasCheckList.Name = "EmpresasCheckList";
            this.EmpresasCheckList.Size = new System.Drawing.Size(324, 180);
            this.EmpresasCheckList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EstacionesLinkLabel);
            this.groupBox4.Controls.Add(this.EstacionesCheckList);
            this.groupBox4.Location = new System.Drawing.Point(401, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(374, 240);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estaciones";
            // 
            // EstacionesLinkLabel
            // 
            this.EstacionesLinkLabel.AutoSize = true;
            this.EstacionesLinkLabel.Location = new System.Drawing.Point(244, 19);
            this.EstacionesLinkLabel.Name = "EstacionesLinkLabel";
            this.EstacionesLinkLabel.Size = new System.Drawing.Size(105, 15);
            this.EstacionesLinkLabel.TabIndex = 3;
            this.EstacionesLinkLabel.TabStop = true;
            this.EstacionesLinkLabel.Text = "Seleccionar todas";
            this.EstacionesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EstacionesLinkLabel_LinkClicked);
            // 
            // EstacionesCheckList
            // 
            this.EstacionesCheckList.CheckOnClick = true;
            this.EstacionesCheckList.FormattingEnabled = true;
            this.EstacionesCheckList.Location = new System.Drawing.Point(25, 42);
            this.EstacionesCheckList.Name = "EstacionesCheckList";
            this.EstacionesCheckList.Size = new System.Drawing.Size(324, 180);
            this.EstacionesCheckList.TabIndex = 2;
            // 
            // ActualizacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.PerisosCajaButton);
            this.Controls.Add(this.CambioPwdButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ActualizacionUsuario";
            this.Text = "AltaUsuario";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.CambioPwdButton, 0);
            this.Controls.SetChildIndex(this.PerisosCajaButton, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private SICASCentralDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.CheckBox activoCheckBox;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource getEmpresasInternasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter get_EmpresasInternasTableAdapter;
        private System.Windows.Forms.BindingSource getSelectEmpresasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectEmpresasTableAdapter get_SelectEmpresasTableAdapter;
        private System.Windows.Forms.BindingSource getSelectEstacionesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectEstacionesTableAdapter get_SelectEstacionesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView PermisosTreeView;
        private System.Windows.Forms.Button SelectNoneButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button CambioPwdButton;
        private System.Windows.Forms.Button PermisosDeGrupoButton;
        private System.Windows.Forms.Button PerisosCajaButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel EmpresasLinkLabel;
        private System.Windows.Forms.CheckedListBox EmpresasCheckList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel EstacionesLinkLabel;
        private System.Windows.Forms.CheckedListBox EstacionesCheckList;
    }
}