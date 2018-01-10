namespace SICASv20.forms
{
    partial class AltaOpcion
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
            System.Windows.Forms.Label modulo_IDLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label textoLabel;
            System.Windows.Forms.Label imagenLabel;
            System.Windows.Forms.Label esHerramientaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label esActivoLabel;
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.opcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opcionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.OpcionesTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.opcion_IDTextBox = new System.Windows.Forms.TextBox();
            this.menu_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getMenuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.textoTextBox = new System.Windows.Forms.TextBox();
            this.imagenTextBox = new System.Windows.Forms.TextBox();
            this.esHerramientaCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EsActivoCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectImagenButton = new System.Windows.Forms.Button();
            this.modulo_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getModulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_MenuesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter();
            this.get_ModulosTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.ImagenOpenDialog = new System.Windows.Forms.OpenFileDialog();
            opcion_IDLabel = new System.Windows.Forms.Label();
            modulo_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            textoLabel = new System.Windows.Forms.Label();
            imagenLabel = new System.Windows.Forms.Label();
            esHerramientaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            esActivoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getModulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // opcion_IDLabel
            // 
            opcion_IDLabel.AutoSize = true;
            opcion_IDLabel.Location = new System.Drawing.Point(27, 36);
            opcion_IDLabel.Name = "opcion_IDLabel";
            opcion_IDLabel.Size = new System.Drawing.Size(64, 15);
            opcion_IDLabel.TabIndex = 2;
            opcion_IDLabel.Text = "Opcion ID:";
            // 
            // modulo_IDLabel
            // 
            modulo_IDLabel.AutoSize = true;
            modulo_IDLabel.Location = new System.Drawing.Point(27, 63);
            modulo_IDLabel.Name = "modulo_IDLabel";
            modulo_IDLabel.Size = new System.Drawing.Size(67, 15);
            modulo_IDLabel.TabIndex = 4;
            modulo_IDLabel.Text = "Modulo ID:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(27, 118);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 6;
            nombreLabel.Text = "Nombre:";
            // 
            // textoLabel
            // 
            textoLabel.AutoSize = true;
            textoLabel.Location = new System.Drawing.Point(27, 145);
            textoLabel.Name = "textoLabel";
            textoLabel.Size = new System.Drawing.Size(40, 15);
            textoLabel.TabIndex = 8;
            textoLabel.Text = "Texto:";
            // 
            // imagenLabel
            // 
            imagenLabel.AutoSize = true;
            imagenLabel.Location = new System.Drawing.Point(27, 172);
            imagenLabel.Name = "imagenLabel";
            imagenLabel.Size = new System.Drawing.Size(52, 15);
            imagenLabel.TabIndex = 10;
            imagenLabel.Text = "Imagen:";
            // 
            // esHerramientaLabel
            // 
            esHerramientaLabel.AutoSize = true;
            esHerramientaLabel.Location = new System.Drawing.Point(27, 201);
            esHerramientaLabel.Name = "esHerramientaLabel";
            esHerramientaLabel.Size = new System.Drawing.Size(96, 15);
            esHerramientaLabel.TabIndex = 12;
            esHerramientaLabel.Text = "Es Herramienta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 90);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 15);
            label1.TabIndex = 14;
            label1.Text = "Menu ID:";
            // 
            // esActivoLabel
            // 
            esActivoLabel.AutoSize = true;
            esActivoLabel.Location = new System.Drawing.Point(27, 224);
            esActivoLabel.Name = "esActivoLabel";
            esActivoLabel.Size = new System.Drawing.Size(58, 15);
            esActivoLabel.TabIndex = 17;
            esActivoLabel.Text = "Es Activo:";
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
            this.opcion_IDTextBox.Location = new System.Drawing.Point(129, 33);
            this.opcion_IDTextBox.Name = "opcion_IDTextBox";
            this.opcion_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.opcion_IDTextBox.TabIndex = 3;
            // 
            // menu_IDComboBox
            // 
            this.menu_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.opcionesBindingSource, "Menu_ID", true));
            this.menu_IDComboBox.DataSource = this.getMenuesBindingSource;
            this.menu_IDComboBox.DisplayMember = "Nombre";
            this.menu_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menu_IDComboBox.FormattingEnabled = true;
            this.menu_IDComboBox.Location = new System.Drawing.Point(129, 87);
            this.menu_IDComboBox.Name = "menu_IDComboBox";
            this.menu_IDComboBox.Size = new System.Drawing.Size(196, 23);
            this.menu_IDComboBox.TabIndex = 5;
            this.menu_IDComboBox.ValueMember = "Menu_ID";
            // 
            // getMenuesBindingSource
            // 
            this.getMenuesBindingSource.DataMember = "Get_Menues";
            this.getMenuesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(129, 115);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(196, 21);
            this.nombreTextBox.TabIndex = 7;
            // 
            // textoTextBox
            // 
            this.textoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Texto", true));
            this.textoTextBox.Location = new System.Drawing.Point(129, 142);
            this.textoTextBox.Name = "textoTextBox";
            this.textoTextBox.Size = new System.Drawing.Size(196, 21);
            this.textoTextBox.TabIndex = 9;
            // 
            // imagenTextBox
            // 
            this.imagenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opcionesBindingSource, "Imagen", true));
            this.imagenTextBox.Location = new System.Drawing.Point(129, 169);
            this.imagenTextBox.Name = "imagenTextBox";
            this.imagenTextBox.Size = new System.Drawing.Size(196, 21);
            this.imagenTextBox.TabIndex = 11;
            // 
            // esHerramientaCheckBox
            // 
            this.esHerramientaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.opcionesBindingSource, "EsHerramienta", true));
            this.esHerramientaCheckBox.Location = new System.Drawing.Point(129, 196);
            this.esHerramientaCheckBox.Name = "esHerramientaCheckBox";
            this.esHerramientaCheckBox.Size = new System.Drawing.Size(196, 24);
            this.esHerramientaCheckBox.TabIndex = 13;
            this.esHerramientaCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EsActivoCheckBox);
            this.groupBox1.Controls.Add(esActivoLabel);
            this.groupBox1.Controls.Add(this.SelectImagenButton);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.modulo_IDComboBox);
            this.groupBox1.Controls.Add(opcion_IDLabel);
            this.groupBox1.Controls.Add(this.esHerramientaCheckBox);
            this.groupBox1.Controls.Add(this.opcion_IDTextBox);
            this.groupBox1.Controls.Add(esHerramientaLabel);
            this.groupBox1.Controls.Add(modulo_IDLabel);
            this.groupBox1.Controls.Add(this.imagenTextBox);
            this.groupBox1.Controls.Add(this.menu_IDComboBox);
            this.groupBox1.Controls.Add(imagenLabel);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.textoTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(textoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 282);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta de Opciones de Menu";
            // 
            // EsActivoCheckBox
            // 
            this.EsActivoCheckBox.Checked = true;
            this.EsActivoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EsActivoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.opcionesBindingSource, "EsActivo", true));
            this.EsActivoCheckBox.Location = new System.Drawing.Point(129, 219);
            this.EsActivoCheckBox.Name = "EsActivoCheckBox";
            this.EsActivoCheckBox.Size = new System.Drawing.Size(196, 24);
            this.EsActivoCheckBox.TabIndex = 18;
            this.EsActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // SelectImagenButton
            // 
            this.SelectImagenButton.Location = new System.Drawing.Point(331, 169);
            this.SelectImagenButton.Name = "SelectImagenButton";
            this.SelectImagenButton.Size = new System.Drawing.Size(26, 21);
            this.SelectImagenButton.TabIndex = 16;
            this.SelectImagenButton.Text = "...";
            this.SelectImagenButton.UseVisualStyleBackColor = true;
            this.SelectImagenButton.Click += new System.EventHandler(this.SelectImagenButton_Click);
            // 
            // modulo_IDComboBox
            // 
            this.modulo_IDComboBox.DataSource = this.getModulosBindingSource;
            this.modulo_IDComboBox.DisplayMember = "Nombre";
            this.modulo_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modulo_IDComboBox.FormattingEnabled = true;
            this.modulo_IDComboBox.Location = new System.Drawing.Point(129, 60);
            this.modulo_IDComboBox.Name = "modulo_IDComboBox";
            this.modulo_IDComboBox.Size = new System.Drawing.Size(196, 23);
            this.modulo_IDComboBox.TabIndex = 15;
            this.modulo_IDComboBox.ValueMember = "Modulo_ID";
            this.modulo_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.modulo_IDComboBox_SelectionChangeCommitted);
            // 
            // getModulosBindingSource
            // 
            this.getModulosBindingSource.DataMember = "Get_Modulos";
            this.getModulosBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // get_MenuesTableAdapter
            // 
            this.get_MenuesTableAdapter.ClearBeforeFill = true;
            // 
            // get_ModulosTableAdapter
            // 
            this.get_ModulosTableAdapter.ClearBeforeFill = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(351, 300);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 46);
            this.GuardarButton.TabIndex = 15;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // ImagenOpenDialog
            // 
            this.ImagenOpenDialog.FileName = "openFileDialog1";
            this.ImagenOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImagenOpenDialog_FileOk);
            // 
            // AltaOpcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Name = "AltaOpcion";
            this.Text = "AltaOpcion";
            this.Load += new System.EventHandler(this.AltaOpcion_Load);
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMenuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
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
        private System.Windows.Forms.BindingSource getMenuesBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox modulo_IDComboBox;
        private SICASCentralQuerysDataSetTableAdapters.Get_MenuesTableAdapter get_MenuesTableAdapter;
        private System.Windows.Forms.BindingSource getModulosBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModulosTableAdapter get_ModulosTableAdapter;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button SelectImagenButton;
        private System.Windows.Forms.OpenFileDialog ImagenOpenDialog;
        private System.Windows.Forms.CheckBox EsActivoCheckBox;
    }
}