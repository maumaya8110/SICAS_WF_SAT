namespace SICASv20.forms
{
    partial class ActualizacionOpcion
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
            System.Windows.Forms.Label opcion_IDLabel;
            System.Windows.Forms.Label menu_IDLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label textoLabel;
            System.Windows.Forms.Label imagenLabel;
            System.Windows.Forms.Label esHerramientaLabel;
            System.Windows.Forms.Label label1;
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.opcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opcionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.OpcionesTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.opcion_IDTextBox = new System.Windows.Forms.TextBox();
            this.menu_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectMenuesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysIIDataSet = new SICASv20.SICASCentralQuerysIIDataSet();
            this.getSelectMenuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.getMenuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.imagenTextBox = new System.Windows.Forms.TextBox();
            this.esHerramientaCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectImagenButton = new System.Windows.Forms.Button();
            this.getModulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.get_MenuesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter();
            this.get_ModulosTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter();
            this.get_SelectMenuesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectMenuesTableAdapter();
            this.get_SelectMenuesTableAdapter1 = new SICASv20.SICASCentralQuerysIIDataSetTableAdapters.Get_SelectMenuesTableAdapter();
            this.ImagenOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.EsActivoCheckBox = new System.Windows.Forms.CheckBox();
            opcion_IDLabel = new System.Windows.Forms.Label();
            menu_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            textoLabel = new System.Windows.Forms.Label();
            imagenLabel = new System.Windows.Forms.Label();
            esHerramientaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectMenuesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysIIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectMenuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getModulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // opcion_IDLabel
            // 
            opcion_IDLabel.AutoSize = true;
            opcion_IDLabel.Location = new System.Drawing.Point(21, 29);
            opcion_IDLabel.Name = "opcion_IDLabel";
            opcion_IDLabel.Size = new System.Drawing.Size(64, 15);
            opcion_IDLabel.TabIndex = 2;
            opcion_IDLabel.Text = "Opcion ID:";
            // 
            // menu_IDLabel
            // 
            menu_IDLabel.AutoSize = true;
            menu_IDLabel.Location = new System.Drawing.Point(21, 56);
            menu_IDLabel.Name = "menu_IDLabel";
            menu_IDLabel.Size = new System.Drawing.Size(57, 15);
            menu_IDLabel.TabIndex = 4;
            menu_IDLabel.Text = "Menu ID:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(21, 85);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 6;
            nombreLabel.Text = "Nombre:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Location = new System.Drawing.Point(21, 112);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(40, 15);
            textoLabel.TabIndex = 8;
            textoLabel.Text = "Texto:";
            // 
            // imagenLabel
            // 
            imagenLabel.AutoSize = true;
            imagenLabel.Location = new System.Drawing.Point(21, 139);
            imagenLabel.Name = "imagenLabel";
            imagenLabel.Size = new System.Drawing.Size(52, 15);
            imagenLabel.TabIndex = 10;
            imagenLabel.Text = "Imagen:";
            // 
            // esHerramientaLabel
            // 
            esHerramientaLabel.AutoSize = true;
            esHerramientaLabel.Location = new System.Drawing.Point(21, 168);
            esHerramientaLabel.Name = "esHerramientaLabel";
            esHerramientaLabel.Size = new System.Drawing.Size(96, 15);
            esHerramientaLabel.TabIndex = 12;
            esHerramientaLabel.Text = "Es Herramienta:";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opcionesBindingSource
            // 
            this.opcionesBindingSource.DataMember = "Opciones";
            this.opcionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // opcionesTableAdapter
            // 
            this.opcionesTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.OpcionesTableAdapter = this.opcionesTableAdapter;
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
            // opcion_IDTextBox
            // 
            this.opcion_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Opcion_ID", true));
            this.opcion_IDTextBox.Location = new System.Drawing.Point(123, 26);
            this.opcion_IDTextBox.Name = "opcion_IDTextBox";
            this.opcion_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.opcion_IDTextBox.TabIndex = 3;
            // 
            // menu_IDComboBox
            // 
            this.menu_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.opcionesBindingSource, "Menu_ID", true));
            this.menu_IDComboBox.DataSource = this.getSelectMenuesBindingSource1;
            this.menu_IDComboBox.DisplayMember = "Nombre";
            this.menu_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menu_IDComboBox.FormattingEnabled = true;
            this.menu_IDComboBox.Location = new System.Drawing.Point(123, 53);
            this.menu_IDComboBox.Name = "menu_IDComboBox";
            this.menu_IDComboBox.Size = new System.Drawing.Size(196, 23);
            this.menu_IDComboBox.TabIndex = 5;
            this.menu_IDComboBox.ValueMember = "Menu_ID";
            // 
            // getSelectMenuesBindingSource1
            // 
            this.getSelectMenuesBindingSource1.DataMember = "Get_SelectMenues";
            this.getSelectMenuesBindingSource1.DataSource = this.sICASCentralQuerysIIDataSet;
            // 
            // sICASCentralQuerysIIDataSet
            // 
            this.sICASCentralQuerysIIDataSet.DataSetName = "SICASCentralQuerysIIDataSet";
            this.sICASCentralQuerysIIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getSelectMenuesBindingSource
            // 
            this.getSelectMenuesBindingSource.DataMember = "Get_SelectMenues";
            this.getSelectMenuesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getMenuesBindingSource
            // 
            this.getMenuesBindingSource.DataMember = "Get_Menues";
            this.getMenuesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(123, 82);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(196, 21);
            this.nombreTextBox.TabIndex = 7;
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(123, 109);
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(196, 21);
            this.textoTextBox.TabIndex = 9;
            // 
            // imagenTextBox
            // 
            this.imagenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Imagen", true));
            this.imagenTextBox.Location = new System.Drawing.Point(123, 136);
            this.imagenTextBox.Name = "imagenTextBox";
            this.imagenTextBox.Size = new System.Drawing.Size(196, 21);
            this.imagenTextBox.TabIndex = 11;
            // 
            // esHerramientaCheckBox
            // 
            this.esHerramientaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.opcionesBindingSource, "EsHerramienta", true));
            this.esHerramientaCheckBox.Location = new System.Drawing.Point(123, 163);
            this.esHerramientaCheckBox.Name = "esHerramientaCheckBox";
            this.esHerramientaCheckBox.Size = new System.Drawing.Size(121, 24);
            this.esHerramientaCheckBox.TabIndex = 13;
            this.esHerramientaCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EsActivoCheckBox);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.SelectImagenButton);
            this.groupBox1.Controls.Add(opcion_IDLabel);
            this.groupBox1.Controls.Add(this.esHerramientaCheckBox);
            this.groupBox1.Controls.Add(this.opcion_IDTextBox);
            this.groupBox1.Controls.Add(esHerramientaLabel);
            this.groupBox1.Controls.Add(menu_IDLabel);
            this.groupBox1.Controls.Add(this.imagenTextBox);
            this.groupBox1.Controls.Add(this.menu_IDComboBox);
            this.groupBox1.Controls.Add(imagenLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.textoTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(textoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 230);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualización de Opción de Menu";
            // 
            // SelectImagenButton
            // 
            this.SelectImagenButton.Location = new System.Drawing.Point(326, 136);
            this.SelectImagenButton.Name = "SelectImagenButton";
            this.SelectImagenButton.Size = new System.Drawing.Size(26, 21);
            this.SelectImagenButton.TabIndex = 18;
            this.SelectImagenButton.Text = "...";
            this.SelectImagenButton.UseVisualStyleBackColor = true;
            this.SelectImagenButton.Click += new System.EventHandler(this.SelectImagenButton_Click);
            // 
            // getModulosBindingSource
            // 
            this.getModulosBindingSource.DataMember = "Get_Modulos";
            this.getModulosBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(305, 248);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 46);
            this.GuardarButton.TabIndex = 17;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // get_MenuesTableAdapter
            // 
            this.get_MenuesTableAdapter.ClearBeforeFill = true;
            // 
            // get_ModulosTableAdapter
            // 
            this.get_ModulosTableAdapter.ClearBeforeFill = true;
            // 
            // get_SelectMenuesTableAdapter
            // 
            this.get_SelectMenuesTableAdapter.ClearBeforeFill = true;
            // 
            // get_SelectMenuesTableAdapter1
            // 
            this.get_SelectMenuesTableAdapter1.ClearBeforeFill = true;
            // 
            // ImagenOpenDialog
            // 
            this.ImagenOpenDialog.FileName = "openFileDialog1";
            this.ImagenOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImagenOpenDialog_FileOk);
            // 
            // EsActivoCheckBox
            // 
            this.EsActivoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.opcionesBindingSource, "EsActivo", true));
            this.EsActivoCheckBox.Location = new System.Drawing.Point(123, 184);
            this.EsActivoCheckBox.Name = "EsActivoCheckBox";
            this.EsActivoCheckBox.Size = new System.Drawing.Size(121, 24);
            this.EsActivoCheckBox.TabIndex = 20;
            this.EsActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 189);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 15);
            label1.TabIndex = 19;
            label1.Text = "Es Activo:";
            // 
            // ActualizacionOpcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "ActualizacionOpcion";
            this.Text = "ActualizacionOpcion";
            this.Load += new System.EventHandler(this.ActualizacionOpcion_Load);
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectMenuesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysIIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectMenuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getModulosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource opcionesBindingSource;
        private SICASCentralDataSetTableAdapters.OpcionesTableAdapter opcionesTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox opcion_IDTextBox;
        private System.Windows.Forms.ComboBox menu_IDComboBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox textoTextBox;
        private System.Windows.Forms.TextBox imagenTextBox;
        private System.Windows.Forms.CheckBox esHerramientaCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource getMenuesBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.Button GuardarButton;
        private SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter get_MenuesTableAdapter;
        private System.Windows.Forms.BindingSource getModulosBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter get_ModulosTableAdapter;
        private System.Windows.Forms.BindingSource getSelectMenuesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectMenuesTableAdapter get_SelectMenuesTableAdapter;
        private SICASCentralQuerysIIDataSet sICASCentralQuerysIIDataSet;
        private System.Windows.Forms.BindingSource getSelectMenuesBindingSource1;
        private SICASCentralQuerysIIDataSetTableAdapters.Get_SelectMenuesTableAdapter get_SelectMenuesTableAdapter1;
        private System.Windows.Forms.Button SelectImagenButton;
        private System.Windows.Forms.OpenFileDialog ImagenOpenDialog;
        private System.Windows.Forms.CheckBox EsActivoCheckBox;
    }
}