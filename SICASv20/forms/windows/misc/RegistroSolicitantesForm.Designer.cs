namespace SICASv20.forms
{
    partial class RegistroSolicitantesForm
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
            System.Windows.Forms.Label conductor_IDLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label apellidosLabel;
            System.Windows.Forms.Label domicilioLabel;
            System.Windows.Forms.Label ciudadLabel;
            System.Windows.Forms.Label entidadLabel;
            System.Windows.Forms.Label telefonoLabel;
            System.Windows.Forms.Label telefono2Label;
            System.Windows.Forms.Label movilLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label rFCLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label cURPLabel;
            System.Windows.Forms.Label codigoPostalLabel;
            System.Windows.Forms.Label fotografiaLabel;
            System.Windows.Forms.Label estatusConductor_IDLabel;
            System.Windows.Forms.Label medioPublicitario_IDLabel;
            System.Windows.Forms.Label cumplioPerfilLabel;
            System.Windows.Forms.Label interesadoLabel;
            System.Windows.Forms.Label mercado_IDLabel;
            System.Windows.Forms.Label comentariosLabel;
            System.Windows.Forms.Label edadLabel;
            System.Windows.Forms.Label estadoCivilLabel;
            System.Windows.Forms.Label añosExperienciaLabel;
            System.Windows.Forms.Label generoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.Windows.Forms.Label usuario_IDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroSolicitantesForm));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.conductoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conductoresTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ConductoresTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.conductoresBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conductoresBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.conductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.apellidosTextBox = new System.Windows.Forms.TextBox();
            this.domicilioTextBox = new System.Windows.Forms.TextBox();
            this.ciudadTextBox = new System.Windows.Forms.TextBox();
            this.entidadTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.telefono2TextBox = new System.Windows.Forms.TextBox();
            this.movilTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.rFCTextBox = new System.Windows.Forms.TextBox();
            this.cURPTextBox = new System.Windows.Forms.TextBox();
            this.codigoPostalTextBox = new System.Windows.Forms.TextBox();
            this.fotografiaTextBox = new System.Windows.Forms.TextBox();
            this.estatusConductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.cumplioPerfilCheckBox = new System.Windows.Forms.CheckBox();
            this.interesadoCheckBox = new System.Windows.Forms.CheckBox();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
            this.edadTextBox = new System.Windows.Forms.TextBox();
            this.estadoCivilTextBox = new System.Windows.Forms.TextBox();
            this.añosExperienciaTextBox = new System.Windows.Forms.TextBox();
            this.generoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.usuario_IDTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Mercado_IDComboBox = new System.Windows.Forms.ComboBox();
            this.mercadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MedioPublicitario_IDComboBox = new System.Windows.Forms.ComboBox();
            this.mediosPublicitariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mediosPublicitariosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.MediosPublicitariosTableAdapter();
            this.mercadosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.MercadosTableAdapter();
            this.estacionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstacionesTableAdapter();
            conductor_IDLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            apellidosLabel = new System.Windows.Forms.Label();
            domicilioLabel = new System.Windows.Forms.Label();
            ciudadLabel = new System.Windows.Forms.Label();
            entidadLabel = new System.Windows.Forms.Label();
            telefonoLabel = new System.Windows.Forms.Label();
            telefono2Label = new System.Windows.Forms.Label();
            movilLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            rFCLabel = new System.Windows.Forms.Label();
            estacion_IDLabel = new System.Windows.Forms.Label();
            cURPLabel = new System.Windows.Forms.Label();
            codigoPostalLabel = new System.Windows.Forms.Label();
            fotografiaLabel = new System.Windows.Forms.Label();
            estatusConductor_IDLabel = new System.Windows.Forms.Label();
            medioPublicitario_IDLabel = new System.Windows.Forms.Label();
            cumplioPerfilLabel = new System.Windows.Forms.Label();
            interesadoLabel = new System.Windows.Forms.Label();
            mercado_IDLabel = new System.Windows.Forms.Label();
            comentariosLabel = new System.Windows.Forms.Label();
            edadLabel = new System.Windows.Forms.Label();
            estadoCivilLabel = new System.Windows.Forms.Label();
            añosExperienciaLabel = new System.Windows.Forms.Label();
            generoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            usuario_IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingNavigator)).BeginInit();
            this.conductoresBindingNavigator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mercadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosPublicitariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // conductor_IDLabel
            // 
            conductor_IDLabel.AutoSize = true;
            conductor_IDLabel.Location = new System.Drawing.Point(23, 328);
            conductor_IDLabel.Name = "conductor_IDLabel";
            conductor_IDLabel.Size = new System.Drawing.Size(81, 15);
            conductor_IDLabel.TabIndex = 1;
            conductor_IDLabel.Text = "Conductor ID:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(16, 29);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 3;
            nombreLabel.Text = "Nombre:";
            // 
            // apellidosLabel
            // 
            apellidosLabel.AutoSize = true;
            apellidosLabel.Location = new System.Drawing.Point(16, 56);
            apellidosLabel.Name = "apellidosLabel";
            apellidosLabel.Size = new System.Drawing.Size(60, 15);
            apellidosLabel.TabIndex = 5;
            apellidosLabel.Text = "Apellidos:";
            // 
            // domicilioLabel
            // 
            domicilioLabel.AutoSize = true;
            domicilioLabel.Location = new System.Drawing.Point(16, 83);
            domicilioLabel.Name = "domicilioLabel";
            domicilioLabel.Size = new System.Drawing.Size(62, 15);
            domicilioLabel.TabIndex = 7;
            domicilioLabel.Text = "Domicilio:";
            // 
            // ciudadLabel
            // 
            ciudadLabel.AutoSize = true;
            ciudadLabel.Location = new System.Drawing.Point(16, 110);
            ciudadLabel.Name = "ciudadLabel";
            ciudadLabel.Size = new System.Drawing.Size(49, 15);
            ciudadLabel.TabIndex = 9;
            ciudadLabel.Text = "Ciudad:";
            // 
            // entidadLabel
            // 
            entidadLabel.AutoSize = true;
            entidadLabel.Location = new System.Drawing.Point(16, 137);
            entidadLabel.Name = "entidadLabel";
            entidadLabel.Size = new System.Drawing.Size(52, 15);
            entidadLabel.TabIndex = 11;
            entidadLabel.Text = "Entidad:";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new System.Drawing.Point(16, 164);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new System.Drawing.Size(58, 15);
            telefonoLabel.TabIndex = 13;
            telefonoLabel.Text = "Telefono:";
            // 
            // telefono2Label
            // 
            telefono2Label.AutoSize = true;
            telefono2Label.Location = new System.Drawing.Point(16, 191);
            telefono2Label.Name = "telefono2Label";
            telefono2Label.Size = new System.Drawing.Size(65, 15);
            telefono2Label.TabIndex = 15;
            telefono2Label.Text = "Telefono2:";
            // 
            // movilLabel
            // 
            movilLabel.AutoSize = true;
            movilLabel.Location = new System.Drawing.Point(16, 218);
            movilLabel.Name = "movilLabel";
            movilLabel.Size = new System.Drawing.Size(39, 15);
            movilLabel.TabIndex = 17;
            movilLabel.Text = "Movil:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(16, 245);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(42, 15);
            emailLabel.TabIndex = 19;
            emailLabel.Text = "Email:";
            // 
            // rFCLabel
            // 
            rFCLabel.AutoSize = true;
            rFCLabel.Location = new System.Drawing.Point(16, 272);
            rFCLabel.Name = "rFCLabel";
            rFCLabel.Size = new System.Drawing.Size(34, 15);
            rFCLabel.TabIndex = 21;
            rFCLabel.Text = "RFC:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(16, 299);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 23;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // cURPLabel
            // 
            cURPLabel.AutoSize = true;
            cURPLabel.Location = new System.Drawing.Point(16, 326);
            cURPLabel.Name = "cURPLabel";
            cURPLabel.Size = new System.Drawing.Size(44, 15);
            cURPLabel.TabIndex = 25;
            cURPLabel.Text = "CURP:";
            // 
            // codigoPostalLabel
            // 
            codigoPostalLabel.AutoSize = true;
            codigoPostalLabel.Location = new System.Drawing.Point(16, 353);
            codigoPostalLabel.Name = "codigoPostalLabel";
            codigoPostalLabel.Size = new System.Drawing.Size(86, 15);
            codigoPostalLabel.TabIndex = 27;
            codigoPostalLabel.Text = "Codigo Postal:";
            // 
            // fotografiaLabel
            // 
            fotografiaLabel.AutoSize = true;
            fotografiaLabel.Location = new System.Drawing.Point(23, 355);
            fotografiaLabel.Name = "fotografiaLabel";
            fotografiaLabel.Size = new System.Drawing.Size(65, 15);
            fotografiaLabel.TabIndex = 29;
            fotografiaLabel.Text = "Fotografia:";
            // 
            // estatusConductor_IDLabel
            // 
            estatusConductor_IDLabel.AutoSize = true;
            estatusConductor_IDLabel.Location = new System.Drawing.Point(23, 436);
            estatusConductor_IDLabel.Name = "estatusConductor_IDLabel";
            estatusConductor_IDLabel.Size = new System.Drawing.Size(124, 15);
            estatusConductor_IDLabel.TabIndex = 31;
            estatusConductor_IDLabel.Text = "Estatus Conductor ID:";
            // 
            // medioPublicitario_IDLabel
            // 
            medioPublicitario_IDLabel.AutoSize = true;
            medioPublicitario_IDLabel.Location = new System.Drawing.Point(23, 33);
            medioPublicitario_IDLabel.Name = "medioPublicitario_IDLabel";
            medioPublicitario_IDLabel.Size = new System.Drawing.Size(124, 15);
            medioPublicitario_IDLabel.TabIndex = 33;
            medioPublicitario_IDLabel.Text = "Medio Publicitario ID:";
            // 
            // cumplioPerfilLabel
            // 
            cumplioPerfilLabel.AutoSize = true;
            cumplioPerfilLabel.Location = new System.Drawing.Point(23, 62);
            cumplioPerfilLabel.Name = "cumplioPerfilLabel";
            cumplioPerfilLabel.Size = new System.Drawing.Size(87, 15);
            cumplioPerfilLabel.TabIndex = 35;
            cumplioPerfilLabel.Text = "Cumplio Perfil:";
            // 
            // interesadoLabel
            // 
            interesadoLabel.AutoSize = true;
            interesadoLabel.Location = new System.Drawing.Point(23, 92);
            interesadoLabel.Name = "interesadoLabel";
            interesadoLabel.Size = new System.Drawing.Size(68, 15);
            interesadoLabel.TabIndex = 37;
            interesadoLabel.Text = "Interesado:";
            // 
            // mercado_IDLabel
            // 
            mercado_IDLabel.AutoSize = true;
            mercado_IDLabel.Location = new System.Drawing.Point(23, 120);
            mercado_IDLabel.Name = "mercado_IDLabel";
            mercado_IDLabel.Size = new System.Drawing.Size(74, 15);
            mercado_IDLabel.TabIndex = 39;
            mercado_IDLabel.Text = "Mercado ID:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.AutoSize = true;
            comentariosLabel.Location = new System.Drawing.Point(23, 147);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(80, 15);
            comentariosLabel.TabIndex = 41;
            comentariosLabel.Text = "Comentarios:";
            // 
            // edadLabel
            // 
            edadLabel.AutoSize = true;
            edadLabel.Location = new System.Drawing.Point(23, 218);
            edadLabel.Name = "edadLabel";
            edadLabel.Size = new System.Drawing.Size(39, 15);
            edadLabel.TabIndex = 43;
            edadLabel.Text = "Edad:";
            // 
            // estadoCivilLabel
            // 
            estadoCivilLabel.AutoSize = true;
            estadoCivilLabel.Location = new System.Drawing.Point(23, 245);
            estadoCivilLabel.Name = "estadoCivilLabel";
            estadoCivilLabel.Size = new System.Drawing.Size(73, 15);
            estadoCivilLabel.TabIndex = 45;
            estadoCivilLabel.Text = "Estado Civil:";
            // 
            // añosExperienciaLabel
            // 
            añosExperienciaLabel.AutoSize = true;
            añosExperienciaLabel.Location = new System.Drawing.Point(23, 272);
            añosExperienciaLabel.Name = "añosExperienciaLabel";
            añosExperienciaLabel.Size = new System.Drawing.Size(105, 15);
            añosExperienciaLabel.TabIndex = 47;
            añosExperienciaLabel.Text = "Años Experiencia:";
            // 
            // generoLabel
            // 
            generoLabel.AutoSize = true;
            generoLabel.Location = new System.Drawing.Point(23, 299);
            generoLabel.Name = "generoLabel";
            generoLabel.Size = new System.Drawing.Size(51, 15);
            generoLabel.TabIndex = 49;
            generoLabel.Text = "Genero:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(23, 384);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(44, 15);
            fechaLabel.TabIndex = 51;
            fechaLabel.Text = "Fecha:";
            // 
            // usuario_IDLabel
            // 
            usuario_IDLabel.AutoSize = true;
            usuario_IDLabel.Location = new System.Drawing.Point(23, 409);
            usuario_IDLabel.Name = "usuario_IDLabel";
            usuario_IDLabel.Size = new System.Drawing.Size(68, 15);
            usuario_IDLabel.TabIndex = 53;
            usuario_IDLabel.Text = "Usuario ID:";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // conductoresBindingSource
            // 
            this.conductoresBindingSource.DataMember = "Conductores";
            this.conductoresBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // conductoresTableAdapter
            // 
            this.conductoresTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArrendamientosTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClasesPublicidadTableAdapter = null;
            this.tableAdapterManager.ConcesionesTableAdapter = null;
            this.tableAdapterManager.ConductoresTableAdapter = this.conductoresTableAdapter;
            this.tableAdapterManager.EmpresasTableAdapter = null;
            this.tableAdapterManager.EstacionesTableAdapter = null;
            this.tableAdapterManager.EstatusConductoresTableAdapter = null;
            this.tableAdapterManager.EstatusFinancierosTableAdapter = null;
            this.tableAdapterManager.EstatusUnidadesTableAdapter = null;
            this.tableAdapterManager.LocacionesUnidadesTableAdapter = null;
            this.tableAdapterManager.MarcasUnidadesTableAdapter = null;
            this.tableAdapterManager.MediosPublicitariosTableAdapter = null;
            this.tableAdapterManager.MercadosTableAdapter = null;
            this.tableAdapterManager.ModelosUnidadesTableAdapter = null;
            this.tableAdapterManager.TiposConcesionesTableAdapter = null;
            this.tableAdapterManager.TiposEmpresasTableAdapter = null;
            this.tableAdapterManager.UnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = null;
            // 
            // conductoresBindingNavigator
            // 
            this.conductoresBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.conductoresBindingNavigator.BindingSource = this.conductoresBindingSource;
            this.conductoresBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.conductoresBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.conductoresBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.conductoresBindingNavigatorSaveItem});
            this.conductoresBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.conductoresBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.conductoresBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.conductoresBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.conductoresBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.conductoresBindingNavigator.Name = "conductoresBindingNavigator";
            this.conductoresBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.conductoresBindingNavigator.Size = new System.Drawing.Size(1036, 25);
            this.conductoresBindingNavigator.TabIndex = 0;
            this.conductoresBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // conductoresBindingNavigatorSaveItem
            // 
            this.conductoresBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.conductoresBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("conductoresBindingNavigatorSaveItem.Image")));
            this.conductoresBindingNavigatorSaveItem.Name = "conductoresBindingNavigatorSaveItem";
            this.conductoresBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.conductoresBindingNavigatorSaveItem.Text = "Save Data";
            this.conductoresBindingNavigatorSaveItem.Click += new System.EventHandler(this.conductoresBindingNavigatorSaveItem_Click);
            // 
            // conductor_IDTextBox
            // 
            this.conductor_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Conductor_ID", true));
            this.conductor_IDTextBox.Enabled = false;
            this.conductor_IDTextBox.Location = new System.Drawing.Point(153, 325);
            this.conductor_IDTextBox.Name = "conductor_IDTextBox";
            this.conductor_IDTextBox.Size = new System.Drawing.Size(200, 21);
            this.conductor_IDTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(146, 26);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(200, 21);
            this.nombreTextBox.TabIndex = 4;
            // 
            // apellidosTextBox
            // 
            this.apellidosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Apellidos", true));
            this.apellidosTextBox.Location = new System.Drawing.Point(146, 53);
            this.apellidosTextBox.Name = "apellidosTextBox";
            this.apellidosTextBox.Size = new System.Drawing.Size(200, 21);
            this.apellidosTextBox.TabIndex = 6;
            // 
            // domicilioTextBox
            // 
            this.domicilioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Domicilio", true));
            this.domicilioTextBox.Location = new System.Drawing.Point(146, 80);
            this.domicilioTextBox.Name = "domicilioTextBox";
            this.domicilioTextBox.Size = new System.Drawing.Size(200, 21);
            this.domicilioTextBox.TabIndex = 8;
            // 
            // ciudadTextBox
            // 
            this.ciudadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Ciudad", true));
            this.ciudadTextBox.Location = new System.Drawing.Point(146, 107);
            this.ciudadTextBox.Name = "ciudadTextBox";
            this.ciudadTextBox.Size = new System.Drawing.Size(200, 21);
            this.ciudadTextBox.TabIndex = 10;
            // 
            // entidadTextBox
            // 
            this.entidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Entidad", true));
            this.entidadTextBox.Location = new System.Drawing.Point(146, 134);
            this.entidadTextBox.Name = "entidadTextBox";
            this.entidadTextBox.Size = new System.Drawing.Size(200, 21);
            this.entidadTextBox.TabIndex = 12;
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Telefono", true));
            this.telefonoTextBox.Location = new System.Drawing.Point(146, 161);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(200, 21);
            this.telefonoTextBox.TabIndex = 14;
            // 
            // telefono2TextBox
            // 
            this.telefono2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Telefono2", true));
            this.telefono2TextBox.Location = new System.Drawing.Point(146, 188);
            this.telefono2TextBox.Name = "telefono2TextBox";
            this.telefono2TextBox.Size = new System.Drawing.Size(200, 21);
            this.telefono2TextBox.TabIndex = 16;
            // 
            // movilTextBox
            // 
            this.movilTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Movil", true));
            this.movilTextBox.Location = new System.Drawing.Point(146, 215);
            this.movilTextBox.Name = "movilTextBox";
            this.movilTextBox.Size = new System.Drawing.Size(200, 21);
            this.movilTextBox.TabIndex = 18;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(146, 242);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 21);
            this.emailTextBox.TabIndex = 20;
            // 
            // rFCTextBox
            // 
            this.rFCTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "RFC", true));
            this.rFCTextBox.Location = new System.Drawing.Point(146, 269);
            this.rFCTextBox.Name = "rFCTextBox";
            this.rFCTextBox.Size = new System.Drawing.Size(200, 21);
            this.rFCTextBox.TabIndex = 22;
            // 
            // cURPTextBox
            // 
            this.cURPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "CURP", true));
            this.cURPTextBox.Location = new System.Drawing.Point(146, 323);
            this.cURPTextBox.Name = "cURPTextBox";
            this.cURPTextBox.Size = new System.Drawing.Size(200, 21);
            this.cURPTextBox.TabIndex = 26;
            // 
            // codigoPostalTextBox
            // 
            this.codigoPostalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "CodigoPostal", true));
            this.codigoPostalTextBox.Location = new System.Drawing.Point(146, 350);
            this.codigoPostalTextBox.Name = "codigoPostalTextBox";
            this.codigoPostalTextBox.Size = new System.Drawing.Size(200, 21);
            this.codigoPostalTextBox.TabIndex = 28;
            // 
            // fotografiaTextBox
            // 
            this.fotografiaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Fotografia", true));
            this.fotografiaTextBox.Enabled = false;
            this.fotografiaTextBox.Location = new System.Drawing.Point(153, 352);
            this.fotografiaTextBox.Name = "fotografiaTextBox";
            this.fotografiaTextBox.Size = new System.Drawing.Size(200, 21);
            this.fotografiaTextBox.TabIndex = 30;
            // 
            // estatusConductor_IDTextBox
            // 
            this.estatusConductor_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "EstatusConductor_ID", true));
            this.estatusConductor_IDTextBox.Enabled = false;
            this.estatusConductor_IDTextBox.Location = new System.Drawing.Point(153, 433);
            this.estatusConductor_IDTextBox.Name = "estatusConductor_IDTextBox";
            this.estatusConductor_IDTextBox.Size = new System.Drawing.Size(44, 21);
            this.estatusConductor_IDTextBox.TabIndex = 32;
            // 
            // cumplioPerfilCheckBox
            // 
            this.cumplioPerfilCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.conductoresBindingSource, "CumplioPerfil", true));
            this.cumplioPerfilCheckBox.Location = new System.Drawing.Point(153, 57);
            this.cumplioPerfilCheckBox.Name = "cumplioPerfilCheckBox";
            this.cumplioPerfilCheckBox.Size = new System.Drawing.Size(200, 24);
            this.cumplioPerfilCheckBox.TabIndex = 36;
            this.cumplioPerfilCheckBox.UseVisualStyleBackColor = true;
            // 
            // interesadoCheckBox
            // 
            this.interesadoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.conductoresBindingSource, "Interesado", true));
            this.interesadoCheckBox.Location = new System.Drawing.Point(153, 87);
            this.interesadoCheckBox.Name = "interesadoCheckBox";
            this.interesadoCheckBox.Size = new System.Drawing.Size(200, 24);
            this.interesadoCheckBox.TabIndex = 38;
            this.interesadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Comentarios", true));
            this.comentariosTextBox.Location = new System.Drawing.Point(153, 144);
            this.comentariosTextBox.Multiline = true;
            this.comentariosTextBox.Name = "comentariosTextBox";
            this.comentariosTextBox.Size = new System.Drawing.Size(200, 61);
            this.comentariosTextBox.TabIndex = 42;
            // 
            // edadTextBox
            // 
            this.edadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Edad", true));
            this.edadTextBox.Location = new System.Drawing.Point(153, 215);
            this.edadTextBox.Name = "edadTextBox";
            this.edadTextBox.Size = new System.Drawing.Size(200, 21);
            this.edadTextBox.TabIndex = 44;
            // 
            // estadoCivilTextBox
            // 
            this.estadoCivilTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "EstadoCivil", true));
            this.estadoCivilTextBox.Location = new System.Drawing.Point(153, 242);
            this.estadoCivilTextBox.Name = "estadoCivilTextBox";
            this.estadoCivilTextBox.Size = new System.Drawing.Size(200, 21);
            this.estadoCivilTextBox.TabIndex = 46;
            // 
            // añosExperienciaTextBox
            // 
            this.añosExperienciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "AñosExperiencia", true));
            this.añosExperienciaTextBox.Location = new System.Drawing.Point(153, 269);
            this.añosExperienciaTextBox.Name = "añosExperienciaTextBox";
            this.añosExperienciaTextBox.Size = new System.Drawing.Size(200, 21);
            this.añosExperienciaTextBox.TabIndex = 48;
            // 
            // generoTextBox
            // 
            this.generoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Genero", true));
            this.generoTextBox.Location = new System.Drawing.Point(153, 296);
            this.generoTextBox.Name = "generoTextBox";
            this.generoTextBox.Size = new System.Drawing.Size(200, 21);
            this.generoTextBox.TabIndex = 50;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.conductoresBindingSource, "Fecha", true));
            this.fechaDateTimePicker.Enabled = false;
            this.fechaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDateTimePicker.Location = new System.Drawing.Point(153, 379);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(106, 21);
            this.fechaDateTimePicker.TabIndex = 52;
            // 
            // usuario_IDTextBox
            // 
            this.usuario_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conductoresBindingSource, "Usuario_ID", true));
            this.usuario_IDTextBox.Enabled = false;
            this.usuario_IDTextBox.Location = new System.Drawing.Point(153, 406);
            this.usuario_IDTextBox.Name = "usuario_IDTextBox";
            this.usuario_IDTextBox.Size = new System.Drawing.Size(200, 21);
            this.usuario_IDTextBox.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Estacion_IDComboBox);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.codigoPostalTextBox);
            this.groupBox1.Controls.Add(codigoPostalLabel);
            this.groupBox1.Controls.Add(this.cURPTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(cURPLabel);
            this.groupBox1.Controls.Add(apellidosLabel);
            this.groupBox1.Controls.Add(this.apellidosTextBox);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(domicilioLabel);
            this.groupBox1.Controls.Add(this.rFCTextBox);
            this.groupBox1.Controls.Add(this.domicilioTextBox);
            this.groupBox1.Controls.Add(rFCLabel);
            this.groupBox1.Controls.Add(ciudadLabel);
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Controls.Add(this.ciudadTextBox);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Controls.Add(entidadLabel);
            this.groupBox1.Controls.Add(this.movilTextBox);
            this.groupBox1.Controls.Add(this.entidadTextBox);
            this.groupBox1.Controls.Add(movilLabel);
            this.groupBox1.Controls.Add(telefonoLabel);
            this.groupBox1.Controls.Add(this.telefono2TextBox);
            this.groupBox1.Controls.Add(this.telefonoTextBox);
            this.groupBox1.Controls.Add(telefono2Label);
            this.groupBox1.Location = new System.Drawing.Point(24, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 389);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // Estacion_IDComboBox
            // 
            this.Estacion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.conductoresBindingSource, "Estacion_ID", true));
            this.Estacion_IDComboBox.DataSource = this.estacionesBindingSource;
            this.Estacion_IDComboBox.DisplayMember = "Nombre";
            this.Estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estacion_IDComboBox.FormattingEnabled = true;
            this.Estacion_IDComboBox.Location = new System.Drawing.Point(146, 295);
            this.Estacion_IDComboBox.Name = "Estacion_IDComboBox";
            this.Estacion_IDComboBox.Size = new System.Drawing.Size(199, 23);
            this.Estacion_IDComboBox.TabIndex = 53;
            this.Estacion_IDComboBox.ValueMember = "Estacion_ID";
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataMember = "Estaciones";
            this.estacionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Mercado_IDComboBox);
            this.groupBox2.Controls.Add(this.MedioPublicitario_IDComboBox);
            this.groupBox2.Controls.Add(conductor_IDLabel);
            this.groupBox2.Controls.Add(this.conductor_IDTextBox);
            this.groupBox2.Controls.Add(medioPublicitario_IDLabel);
            this.groupBox2.Controls.Add(fotografiaLabel);
            this.groupBox2.Controls.Add(this.generoTextBox);
            this.groupBox2.Controls.Add(this.fotografiaTextBox);
            this.groupBox2.Controls.Add(generoLabel);
            this.groupBox2.Controls.Add(estatusConductor_IDLabel);
            this.groupBox2.Controls.Add(this.añosExperienciaTextBox);
            this.groupBox2.Controls.Add(this.estatusConductor_IDTextBox);
            this.groupBox2.Controls.Add(añosExperienciaLabel);
            this.groupBox2.Controls.Add(fechaLabel);
            this.groupBox2.Controls.Add(this.estadoCivilTextBox);
            this.groupBox2.Controls.Add(this.fechaDateTimePicker);
            this.groupBox2.Controls.Add(estadoCivilLabel);
            this.groupBox2.Controls.Add(usuario_IDLabel);
            this.groupBox2.Controls.Add(this.edadTextBox);
            this.groupBox2.Controls.Add(this.usuario_IDTextBox);
            this.groupBox2.Controls.Add(edadLabel);
            this.groupBox2.Controls.Add(this.comentariosTextBox);
            this.groupBox2.Controls.Add(cumplioPerfilLabel);
            this.groupBox2.Controls.Add(comentariosLabel);
            this.groupBox2.Controls.Add(this.cumplioPerfilCheckBox);
            this.groupBox2.Controls.Add(interesadoLabel);
            this.groupBox2.Controls.Add(mercado_IDLabel);
            this.groupBox2.Controls.Add(this.interesadoCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(450, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 474);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Otros datos";
            // 
            // Mercado_IDComboBox
            // 
            this.Mercado_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.conductoresBindingSource, "Mercado_ID", true));
            this.Mercado_IDComboBox.DataSource = this.mercadosBindingSource;
            this.Mercado_IDComboBox.DisplayMember = "Nombre";
            this.Mercado_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mercado_IDComboBox.FormattingEnabled = true;
            this.Mercado_IDComboBox.Location = new System.Drawing.Point(153, 115);
            this.Mercado_IDComboBox.Name = "Mercado_IDComboBox";
            this.Mercado_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.Mercado_IDComboBox.TabIndex = 52;
            this.Mercado_IDComboBox.ValueMember = "Mercado_ID";
            // 
            // mercadosBindingSource
            // 
            this.mercadosBindingSource.DataMember = "Mercados";
            this.mercadosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // MedioPublicitario_IDComboBox
            // 
            this.MedioPublicitario_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.conductoresBindingSource, "MedioPublicitario_ID", true));
            this.MedioPublicitario_IDComboBox.DataSource = this.mediosPublicitariosBindingSource;
            this.MedioPublicitario_IDComboBox.DisplayMember = "Nombre";
            this.MedioPublicitario_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MedioPublicitario_IDComboBox.FormattingEnabled = true;
            this.MedioPublicitario_IDComboBox.Location = new System.Drawing.Point(154, 30);
            this.MedioPublicitario_IDComboBox.Name = "MedioPublicitario_IDComboBox";
            this.MedioPublicitario_IDComboBox.Size = new System.Drawing.Size(199, 23);
            this.MedioPublicitario_IDComboBox.TabIndex = 51;
            this.MedioPublicitario_IDComboBox.ValueMember = "MedioPublicitario_ID";
            // 
            // mediosPublicitariosBindingSource
            // 
            this.mediosPublicitariosBindingSource.DataMember = "MediosPublicitarios";
            this.mediosPublicitariosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // mediosPublicitariosTableAdapter
            // 
            this.mediosPublicitariosTableAdapter.ClearBeforeFill = true;
            // 
            // mercadosTableAdapter
            // 
            this.mercadosTableAdapter.ClearBeforeFill = true;
            // 
            // estacionesTableAdapter
            // 
            this.estacionesTableAdapter.ClearBeforeFill = true;
            // 
            // RegistroSolicitantesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1036, 780);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.conductoresBindingNavigator);
            this.Name = "RegistroSolicitantesForm";
            this.Text = "RegistroSolicitantesForm";
            this.Load += new System.EventHandler(this.RegistroSolicitantesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductoresBindingNavigator)).EndInit();
            this.conductoresBindingNavigator.ResumeLayout(false);
            this.conductoresBindingNavigator.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mercadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosPublicitariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource conductoresBindingSource;
        private SICASCentralDataSetTableAdapters.ConductoresTableAdapter conductoresTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator conductoresBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton conductoresBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox conductor_IDTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidosTextBox;
        private System.Windows.Forms.TextBox domicilioTextBox;
        private System.Windows.Forms.TextBox ciudadTextBox;
        private System.Windows.Forms.TextBox entidadTextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.TextBox telefono2TextBox;
        private System.Windows.Forms.TextBox movilTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox rFCTextBox;
        private System.Windows.Forms.TextBox cURPTextBox;
        private System.Windows.Forms.TextBox codigoPostalTextBox;
        private System.Windows.Forms.TextBox fotografiaTextBox;
        private System.Windows.Forms.TextBox estatusConductor_IDTextBox;
        private System.Windows.Forms.CheckBox cumplioPerfilCheckBox;
        private System.Windows.Forms.CheckBox interesadoCheckBox;
        private System.Windows.Forms.TextBox comentariosTextBox;
        private System.Windows.Forms.TextBox edadTextBox;
        private System.Windows.Forms.TextBox estadoCivilTextBox;
        private System.Windows.Forms.TextBox añosExperienciaTextBox;
        private System.Windows.Forms.TextBox generoTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.TextBox usuario_IDTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox MedioPublicitario_IDComboBox;
        private System.Windows.Forms.BindingSource mediosPublicitariosBindingSource;
        private SICASCentralDataSetTableAdapters.MediosPublicitariosTableAdapter mediosPublicitariosTableAdapter;
        private System.Windows.Forms.ComboBox Mercado_IDComboBox;
        private System.Windows.Forms.BindingSource mercadosBindingSource;
        private SICASCentralDataSetTableAdapters.MercadosTableAdapter mercadosTableAdapter;
        private System.Windows.Forms.ComboBox Estacion_IDComboBox;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private SICASCentralDataSetTableAdapters.EstacionesTableAdapter estacionesTableAdapter;
    }
}