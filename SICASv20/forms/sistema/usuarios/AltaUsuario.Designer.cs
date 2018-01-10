namespace SICASv20.forms
{
    partial class AltaUsuario
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
            System.Windows.Forms.Label pwdLabel;
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
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
            this.EmpresasLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EmpresasCheckList = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EstacionesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EstacionesCheckList = new System.Windows.Forms.CheckedListBox();
            usuario_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            pwdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // pwdLabel
            // 
            pwdLabel.AutoSize = true;
            pwdLabel.Location = new System.Drawing.Point(29, 145);
            pwdLabel.Name = "pwdLabel";
            pwdLabel.Size = new System.Drawing.Size(64, 15);
            pwdLabel.TabIndex = 11;
            pwdLabel.Text = "Password:";
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
            this.tableAdapterManager.Connection = null;
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
            this.tableAdapterManager.UsuariosTableAdapter = null;
            this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.Location = new System.Drawing.Point(110, 34);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.usuario_IDTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(110, 61);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(241, 21);
            this.nombreTextBox.TabIndex = 4;
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.Location = new System.Drawing.Point(110, 88);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.Size = new System.Drawing.Size(241, 21);
            this.apellidosTextBox.TabIndex = 6;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(110, 115);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 21);
            this.emailTextBox.TabIndex = 8;
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(110, 142);
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
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 184);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de usuario";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(294, 209);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 38);
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
            this.groupBox2.Controls.Add(this.EmpresasLinkLabel);
            this.groupBox2.Controls.Add(this.EmpresasCheckList);
            this.groupBox2.Location = new System.Drawing.Point(394, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 234);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empresas";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EstacionesLinkLabel);
            this.groupBox3.Controls.Add(this.EstacionesCheckList);
            this.groupBox3.Location = new System.Drawing.Point(394, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 240);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estaciones";
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
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "AltaUsuario";
            this.Text = "AltaUsuario";
            this.Load += new System.EventHandler(this.AltaUsuario_Load);
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectEstacionesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel EmpresasLinkLabel;
        private System.Windows.Forms.CheckedListBox EmpresasCheckList;
        private System.Windows.Forms.LinkLabel EstacionesLinkLabel;
        private System.Windows.Forms.CheckedListBox EstacionesCheckList;
    }
}