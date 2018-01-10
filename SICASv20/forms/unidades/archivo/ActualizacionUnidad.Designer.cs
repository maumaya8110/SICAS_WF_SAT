namespace SICASv20.forms
{
    partial class ActualizacionUnidad
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
			System.Windows.Forms.Label unidad_IDLabel;
			System.Windows.Forms.Label empresa_IDLabel;
			System.Windows.Forms.Label estacion_IDLabel;
			System.Windows.Forms.Label numeroEconomicoLabel;
			System.Windows.Forms.Label modeloUnidad_IDLabel;
			System.Windows.Forms.Label precioListaLabel;
			System.Windows.Forms.Label numeroSerieLabel;
			System.Windows.Forms.Label numeroSerieMotorLabel;
			System.Windows.Forms.Label tarjetaCirculacionLabel;
			System.Windows.Forms.Label locacionUnidad_IDLabel;
			System.Windows.Forms.Label placasLabel;
			System.Windows.Forms.Label kilometrajeLabel;
			System.Windows.Forms.Label propietario_IDLabel;
			System.Windows.Forms.Label arrendamiento_IDLabel;
			System.Windows.Forms.Label concesion_IDLabel;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizacionUnidad));
			System.Windows.Forms.Label label2;
			this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
			this.unidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.unidadesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.UnidadesTableAdapter();
			this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
			this.estacionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstacionesTableAdapter();
			this.unidadesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
			this.unidadesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.unidad_IDTextBox = new System.Windows.Forms.TextBox();
			this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
			this.selectEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.getEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
			this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
			this.selectEstacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.numeroEconomicoTextBox = new System.Windows.Forms.TextBox();
			this.modeloUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
			this.getModelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.precioListaTextBox = new System.Windows.Forms.TextBox();
			this.numeroSerieTextBox = new System.Windows.Forms.TextBox();
			this.numeroSerieMotorTextBox = new System.Windows.Forms.TextBox();
			this.tarjetaCirculacionTextBox = new System.Windows.Forms.TextBox();
			this.estatusUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.locacionUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
			this.locacionesUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.placasTextBox = new System.Windows.Forms.TextBox();
			this.kilometrajeTextBox = new System.Windows.Forms.TextBox();
			this.propietario_IDComboBox = new System.Windows.Forms.ComboBox();
			this.getEmpresasPropietariasBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.concesion_IDComboBox = new System.Windows.Forms.ComboBox();
			this.getConcesionesDisponiblesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.get_EmpresasInternasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter();
			this.GuardarButton = new System.Windows.Forms.Button();
			this.get_ModelosUnidadesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter();
			this.estatusUnidadesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstatusUnidadesTableAdapter();
			this.locacionesUnidadesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.LocacionesUnidadesTableAdapter();
			this.get_EmpresasPropietariasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasPropietariasTableAdapter();
			this.get_ConcesionesDisponiblesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ConcesionesDisponiblesTableAdapter();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.getArrendamientosDisponiblesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.get_ArrendamientosDisponiblesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ArrendamientosDisponiblesTableAdapter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gpsTextBox = new System.Windows.Forms.TextBox();
			this.dteFechaCompra = new System.Windows.Forms.DateTimePicker();
			unidad_IDLabel = new System.Windows.Forms.Label();
			empresa_IDLabel = new System.Windows.Forms.Label();
			estacion_IDLabel = new System.Windows.Forms.Label();
			numeroEconomicoLabel = new System.Windows.Forms.Label();
			modeloUnidad_IDLabel = new System.Windows.Forms.Label();
			precioListaLabel = new System.Windows.Forms.Label();
			numeroSerieLabel = new System.Windows.Forms.Label();
			numeroSerieMotorLabel = new System.Windows.Forms.Label();
			tarjetaCirculacionLabel = new System.Windows.Forms.Label();
			locacionUnidad_IDLabel = new System.Windows.Forms.Label();
			placasLabel = new System.Windows.Forms.Label();
			kilometrajeLabel = new System.Windows.Forms.Label();
			propietario_IDLabel = new System.Windows.Forms.Label();
			arrendamiento_IDLabel = new System.Windows.Forms.Label();
			concesion_IDLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unidadesBindingNavigator)).BeginInit();
			this.unidadesBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.estatusUnidadesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.locacionesUnidadesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getEmpresasPropietariasBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getConcesionesDisponiblesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.getArrendamientosDisponiblesBindingSource)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// unidad_IDLabel
			// 
			unidad_IDLabel.AutoSize = true;
			unidad_IDLabel.Location = new System.Drawing.Point(37, 34);
			unidad_IDLabel.Name = "unidad_IDLabel";
			unidad_IDLabel.Size = new System.Drawing.Size(76, 18);
			unidad_IDLabel.TabIndex = 1;
			unidad_IDLabel.Text = "Unidad ID:";
			// 
			// empresa_IDLabel
			// 
			empresa_IDLabel.AutoSize = true;
			empresa_IDLabel.Location = new System.Drawing.Point(37, 61);
			empresa_IDLabel.Name = "empresa_IDLabel";
			empresa_IDLabel.Size = new System.Drawing.Size(90, 18);
			empresa_IDLabel.TabIndex = 3;
			empresa_IDLabel.Text = "Empresa ID:";
			// 
			// estacion_IDLabel
			// 
			estacion_IDLabel.AutoSize = true;
			estacion_IDLabel.Location = new System.Drawing.Point(37, 90);
			estacion_IDLabel.Name = "estacion_IDLabel";
			estacion_IDLabel.Size = new System.Drawing.Size(88, 18);
			estacion_IDLabel.TabIndex = 5;
			estacion_IDLabel.Text = "Estacion ID:";
			// 
			// numeroEconomicoLabel
			// 
			numeroEconomicoLabel.AutoSize = true;
			numeroEconomicoLabel.Location = new System.Drawing.Point(37, 119);
			numeroEconomicoLabel.Name = "numeroEconomicoLabel";
			numeroEconomicoLabel.Size = new System.Drawing.Size(147, 18);
			numeroEconomicoLabel.TabIndex = 7;
			numeroEconomicoLabel.Text = "Numero Economico:";
			// 
			// modeloUnidad_IDLabel
			// 
			modeloUnidad_IDLabel.AutoSize = true;
			modeloUnidad_IDLabel.Location = new System.Drawing.Point(37, 146);
			modeloUnidad_IDLabel.Name = "modeloUnidad_IDLabel";
			modeloUnidad_IDLabel.Size = new System.Drawing.Size(130, 18);
			modeloUnidad_IDLabel.TabIndex = 9;
			modeloUnidad_IDLabel.Text = "Modelo Unidad ID:";
			// 
			// precioListaLabel
			// 
			precioListaLabel.AutoSize = true;
			precioListaLabel.Location = new System.Drawing.Point(37, 175);
			precioListaLabel.Name = "precioListaLabel";
			precioListaLabel.Size = new System.Drawing.Size(90, 18);
			precioListaLabel.TabIndex = 11;
			precioListaLabel.Text = "Precio Lista:";
			// 
			// numeroSerieLabel
			// 
			numeroSerieLabel.AutoSize = true;
			numeroSerieLabel.Location = new System.Drawing.Point(37, 202);
			numeroSerieLabel.Name = "numeroSerieLabel";
			numeroSerieLabel.Size = new System.Drawing.Size(104, 18);
			numeroSerieLabel.TabIndex = 13;
			numeroSerieLabel.Text = "Numero Serie:";
			// 
			// numeroSerieMotorLabel
			// 
			numeroSerieMotorLabel.AutoSize = true;
			numeroSerieMotorLabel.Location = new System.Drawing.Point(37, 229);
			numeroSerieMotorLabel.Name = "numeroSerieMotorLabel";
			numeroSerieMotorLabel.Size = new System.Drawing.Size(148, 18);
			numeroSerieMotorLabel.TabIndex = 15;
			numeroSerieMotorLabel.Text = "Numero Serie Motor:";
			// 
			// tarjetaCirculacionLabel
			// 
			tarjetaCirculacionLabel.AutoSize = true;
			tarjetaCirculacionLabel.Location = new System.Drawing.Point(37, 256);
			tarjetaCirculacionLabel.Name = "tarjetaCirculacionLabel";
			tarjetaCirculacionLabel.Size = new System.Drawing.Size(135, 18);
			tarjetaCirculacionLabel.TabIndex = 17;
			tarjetaCirculacionLabel.Text = "Tarjeta Circulacion:";
			// 
			// locacionUnidad_IDLabel
			// 
			locacionUnidad_IDLabel.AutoSize = true;
			locacionUnidad_IDLabel.Location = new System.Drawing.Point(37, 284);
			locacionUnidad_IDLabel.Name = "locacionUnidad_IDLabel";
			locacionUnidad_IDLabel.Size = new System.Drawing.Size(141, 18);
			locacionUnidad_IDLabel.TabIndex = 21;
			locacionUnidad_IDLabel.Text = "Locacion Unidad ID:";
			// 
			// placasLabel
			// 
			placasLabel.AutoSize = true;
			placasLabel.Location = new System.Drawing.Point(37, 313);
			placasLabel.Name = "placasLabel";
			placasLabel.Size = new System.Drawing.Size(57, 18);
			placasLabel.TabIndex = 23;
			placasLabel.Text = "Placas:";
			// 
			// kilometrajeLabel
			// 
			kilometrajeLabel.AutoSize = true;
			kilometrajeLabel.Location = new System.Drawing.Point(37, 340);
			kilometrajeLabel.Name = "kilometrajeLabel";
			kilometrajeLabel.Size = new System.Drawing.Size(86, 18);
			kilometrajeLabel.TabIndex = 25;
			kilometrajeLabel.Text = "Kilometraje:";
			// 
			// propietario_IDLabel
			// 
			propietario_IDLabel.AutoSize = true;
			propietario_IDLabel.Location = new System.Drawing.Point(37, 367);
			propietario_IDLabel.Name = "propietario_IDLabel";
			propietario_IDLabel.Size = new System.Drawing.Size(102, 18);
			propietario_IDLabel.TabIndex = 27;
			propietario_IDLabel.Text = "Propietario ID:";
			// 
			// arrendamiento_IDLabel
			// 
			arrendamiento_IDLabel.AutoSize = true;
			arrendamiento_IDLabel.Location = new System.Drawing.Point(37, 396);
			arrendamiento_IDLabel.Name = "arrendamiento_IDLabel";
			arrendamiento_IDLabel.Size = new System.Drawing.Size(126, 18);
			arrendamiento_IDLabel.TabIndex = 29;
			arrendamiento_IDLabel.Text = "Arrendamiento ID:";
			// 
			// concesion_IDLabel
			// 
			concesion_IDLabel.AutoSize = true;
			concesion_IDLabel.Location = new System.Drawing.Point(37, 423);
			concesion_IDLabel.Name = "concesion_IDLabel";
			concesion_IDLabel.Size = new System.Drawing.Size(102, 18);
			concesion_IDLabel.TabIndex = 31;
			concesion_IDLabel.Text = "Concesion ID:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(37, 452);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 18);
			label1.TabIndex = 37;
			label1.Text = "GPS:";
			// 
			// sICASCentralDataSet
			// 
			this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
			this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// unidadesBindingSource
			// 
			this.unidadesBindingSource.DataSource = typeof(SICASv20.Entities.Unidades);
			// 
			// unidadesTableAdapter
			// 
			this.unidadesTableAdapter.ClearBeforeFill = true;
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
			this.tableAdapterManager.EstacionesTableAdapter = this.estacionesTableAdapter;
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
			this.tableAdapterManager.UnidadesTableAdapter = this.unidadesTableAdapter;
			this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			this.tableAdapterManager.UsuariosTableAdapter = null;
			this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
			// 
			// estacionesTableAdapter
			// 
			this.estacionesTableAdapter.ClearBeforeFill = true;
			// 
			// unidadesBindingNavigator
			// 
			this.unidadesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.unidadesBindingNavigator.BindingSource = this.unidadesBindingSource;
			this.unidadesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.unidadesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.unidadesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.unidadesBindingNavigatorSaveItem});
			this.unidadesBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.unidadesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.unidadesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.unidadesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.unidadesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.unidadesBindingNavigator.Name = "unidadesBindingNavigator";
			this.unidadesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.unidadesBindingNavigator.Size = new System.Drawing.Size(1024, 25);
			this.unidadesBindingNavigator.TabIndex = 0;
			this.unidadesBindingNavigator.Text = "bindingNavigator1";
			this.unidadesBindingNavigator.Visible = false;
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Add new";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 22);
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
			// unidadesBindingNavigatorSaveItem
			// 
			this.unidadesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.unidadesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("unidadesBindingNavigatorSaveItem.Image")));
			this.unidadesBindingNavigatorSaveItem.Name = "unidadesBindingNavigatorSaveItem";
			this.unidadesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.unidadesBindingNavigatorSaveItem.Text = "Save Data";
			this.unidadesBindingNavigatorSaveItem.Click += new System.EventHandler(this.unidadesBindingNavigatorSaveItem_Click);
			// 
			// unidad_IDTextBox
			// 
			this.unidad_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "Unidad_ID", true));
			this.unidad_IDTextBox.Location = new System.Drawing.Point(165, 31);
			this.unidad_IDTextBox.Name = "unidad_IDTextBox";
			this.unidad_IDTextBox.Size = new System.Drawing.Size(121, 24);
			this.unidad_IDTextBox.TabIndex = 2;
			// 
			// empresa_IDComboBox
			// 
			this.empresa_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "Empresa_ID", true));
			this.empresa_IDComboBox.DataSource = this.selectEmpresasInternasBindingSource;
			this.empresa_IDComboBox.DisplayMember = "Nombre";
			this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.empresa_IDComboBox.FormattingEnabled = true;
			this.empresa_IDComboBox.Location = new System.Drawing.Point(165, 58);
			this.empresa_IDComboBox.Name = "empresa_IDComboBox";
			this.empresa_IDComboBox.Size = new System.Drawing.Size(182, 26);
			this.empresa_IDComboBox.TabIndex = 4;
			this.empresa_IDComboBox.ValueMember = "Empresa_ID";
			// 
			// selectEmpresasInternasBindingSource
			// 
			this.selectEmpresasInternasBindingSource.DataSource = typeof(SICASv20.Entities.SelectEmpresasInternas);
			// 
			// getEmpresasInternasBindingSource
			// 
			this.getEmpresasInternasBindingSource.DataMember = "Get_EmpresasInternas";
			this.getEmpresasInternasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
			// 
			// sICASCentralQuerysDataSet
			// 
			this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
			this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// estacion_IDComboBox
			// 
			this.estacion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "Estacion_ID", true));
			this.estacion_IDComboBox.DataSource = this.selectEstacionesBindingSource;
			this.estacion_IDComboBox.DisplayMember = "Nombre";
			this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.estacion_IDComboBox.FormattingEnabled = true;
			this.estacion_IDComboBox.Location = new System.Drawing.Point(165, 87);
			this.estacion_IDComboBox.Name = "estacion_IDComboBox";
			this.estacion_IDComboBox.Size = new System.Drawing.Size(182, 26);
			this.estacion_IDComboBox.TabIndex = 6;
			this.estacion_IDComboBox.ValueMember = "Estacion_ID";
			// 
			// selectEstacionesBindingSource
			// 
			this.selectEstacionesBindingSource.DataSource = typeof(SICASv20.Entities.SelectEstaciones);
			// 
			// estacionesBindingSource
			// 
			this.estacionesBindingSource.DataMember = "Estaciones";
			this.estacionesBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// numeroEconomicoTextBox
			// 
			this.numeroEconomicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "NumeroEconomico", true));
			this.numeroEconomicoTextBox.Location = new System.Drawing.Point(165, 116);
			this.numeroEconomicoTextBox.Name = "numeroEconomicoTextBox";
			this.numeroEconomicoTextBox.Size = new System.Drawing.Size(121, 24);
			this.numeroEconomicoTextBox.TabIndex = 8;
			// 
			// modeloUnidad_IDComboBox
			// 
			this.modeloUnidad_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "ModeloUnidad_ID", true));
			this.modeloUnidad_IDComboBox.DataSource = this.getModelosUnidadesBindingSource;
			this.modeloUnidad_IDComboBox.DisplayMember = "Descripcion";
			this.modeloUnidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modeloUnidad_IDComboBox.FormattingEnabled = true;
			this.modeloUnidad_IDComboBox.Location = new System.Drawing.Point(165, 143);
			this.modeloUnidad_IDComboBox.Name = "modeloUnidad_IDComboBox";
			this.modeloUnidad_IDComboBox.Size = new System.Drawing.Size(266, 26);
			this.modeloUnidad_IDComboBox.TabIndex = 10;
			this.modeloUnidad_IDComboBox.ValueMember = "ModeloUnidad_ID";
			// 
			// getModelosUnidadesBindingSource
			// 
			this.getModelosUnidadesBindingSource.DataMember = "Get_ModelosUnidades";
			this.getModelosUnidadesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
			// 
			// precioListaTextBox
			// 
			this.precioListaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "PrecioLista", true));
			this.precioListaTextBox.Location = new System.Drawing.Point(165, 172);
			this.precioListaTextBox.Name = "precioListaTextBox";
			this.precioListaTextBox.Size = new System.Drawing.Size(121, 24);
			this.precioListaTextBox.TabIndex = 12;
			// 
			// numeroSerieTextBox
			// 
			this.numeroSerieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "NumeroSerie", true));
			this.numeroSerieTextBox.Location = new System.Drawing.Point(165, 199);
			this.numeroSerieTextBox.Name = "numeroSerieTextBox";
			this.numeroSerieTextBox.Size = new System.Drawing.Size(182, 24);
			this.numeroSerieTextBox.TabIndex = 14;
			// 
			// numeroSerieMotorTextBox
			// 
			this.numeroSerieMotorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "NumeroSerieMotor", true));
			this.numeroSerieMotorTextBox.Location = new System.Drawing.Point(165, 226);
			this.numeroSerieMotorTextBox.Name = "numeroSerieMotorTextBox";
			this.numeroSerieMotorTextBox.Size = new System.Drawing.Size(182, 24);
			this.numeroSerieMotorTextBox.TabIndex = 16;
			// 
			// tarjetaCirculacionTextBox
			// 
			this.tarjetaCirculacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "TarjetaCirculacion", true));
			this.tarjetaCirculacionTextBox.Location = new System.Drawing.Point(165, 253);
			this.tarjetaCirculacionTextBox.Name = "tarjetaCirculacionTextBox";
			this.tarjetaCirculacionTextBox.Size = new System.Drawing.Size(121, 24);
			this.tarjetaCirculacionTextBox.TabIndex = 18;
			// 
			// estatusUnidadesBindingSource
			// 
			this.estatusUnidadesBindingSource.DataMember = "EstatusUnidades";
			this.estatusUnidadesBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// locacionUnidad_IDComboBox
			// 
			this.locacionUnidad_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "LocacionUnidad_ID", true));
			this.locacionUnidad_IDComboBox.DataSource = this.locacionesUnidadesBindingSource;
			this.locacionUnidad_IDComboBox.DisplayMember = "Nombre";
			this.locacionUnidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.locacionUnidad_IDComboBox.FormattingEnabled = true;
			this.locacionUnidad_IDComboBox.Location = new System.Drawing.Point(165, 281);
			this.locacionUnidad_IDComboBox.Name = "locacionUnidad_IDComboBox";
			this.locacionUnidad_IDComboBox.Size = new System.Drawing.Size(182, 26);
			this.locacionUnidad_IDComboBox.TabIndex = 22;
			this.locacionUnidad_IDComboBox.ValueMember = "LocacionUnidad_ID";
			// 
			// locacionesUnidadesBindingSource
			// 
			this.locacionesUnidadesBindingSource.DataMember = "LocacionesUnidades";
			this.locacionesUnidadesBindingSource.DataSource = this.sICASCentralDataSet;
			// 
			// placasTextBox
			// 
			this.placasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "Placas", true));
			this.placasTextBox.Location = new System.Drawing.Point(165, 310);
			this.placasTextBox.Name = "placasTextBox";
			this.placasTextBox.Size = new System.Drawing.Size(121, 24);
			this.placasTextBox.TabIndex = 24;
			// 
			// kilometrajeTextBox
			// 
			this.kilometrajeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "Kilometraje", true));
			this.kilometrajeTextBox.Location = new System.Drawing.Point(165, 337);
			this.kilometrajeTextBox.Name = "kilometrajeTextBox";
			this.kilometrajeTextBox.Size = new System.Drawing.Size(121, 24);
			this.kilometrajeTextBox.TabIndex = 26;
			// 
			// propietario_IDComboBox
			// 
			this.propietario_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "Propietario_ID", true));
			this.propietario_IDComboBox.DataSource = this.getEmpresasPropietariasBindingSource;
			this.propietario_IDComboBox.DisplayMember = "Nombre";
			this.propietario_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.propietario_IDComboBox.FormattingEnabled = true;
			this.propietario_IDComboBox.Location = new System.Drawing.Point(165, 364);
			this.propietario_IDComboBox.Name = "propietario_IDComboBox";
			this.propietario_IDComboBox.Size = new System.Drawing.Size(266, 26);
			this.propietario_IDComboBox.TabIndex = 28;
			this.propietario_IDComboBox.ValueMember = "Empresa_ID";
			// 
			// getEmpresasPropietariasBindingSource
			// 
			this.getEmpresasPropietariasBindingSource.DataMember = "Get_EmpresasPropietarias";
			this.getEmpresasPropietariasBindingSource.DataSource = this.sICASCentralQuerysDataSet;
			// 
			// concesion_IDComboBox
			// 
			this.concesion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "Concesion_ID", true));
			this.concesion_IDComboBox.DataSource = this.getConcesionesDisponiblesBindingSource;
			this.concesion_IDComboBox.DisplayMember = "Descripcion";
			this.concesion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.concesion_IDComboBox.FormattingEnabled = true;
			this.concesion_IDComboBox.Location = new System.Drawing.Point(165, 420);
			this.concesion_IDComboBox.Name = "concesion_IDComboBox";
			this.concesion_IDComboBox.Size = new System.Drawing.Size(266, 26);
			this.concesion_IDComboBox.TabIndex = 32;
			this.concesion_IDComboBox.ValueMember = "Concesion_ID";
			// 
			// getConcesionesDisponiblesBindingSource
			// 
			this.getConcesionesDisponiblesBindingSource.DataMember = "Get_ConcesionesDisponibles";
			this.getConcesionesDisponiblesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
			// 
			// get_EmpresasInternasTableAdapter
			// 
			this.get_EmpresasInternasTableAdapter.ClearBeforeFill = true;
			// 
			// GuardarButton
			// 
			this.GuardarButton.Location = new System.Drawing.Point(499, 18);
			this.GuardarButton.Name = "GuardarButton";
			this.GuardarButton.Size = new System.Drawing.Size(75, 40);
			this.GuardarButton.TabIndex = 35;
			this.GuardarButton.Text = "Guardar";
			this.GuardarButton.UseVisualStyleBackColor = true;
			this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
			// 
			// get_ModelosUnidadesTableAdapter
			// 
			this.get_ModelosUnidadesTableAdapter.ClearBeforeFill = true;
			// 
			// estatusUnidadesTableAdapter
			// 
			this.estatusUnidadesTableAdapter.ClearBeforeFill = true;
			// 
			// locacionesUnidadesTableAdapter
			// 
			this.locacionesUnidadesTableAdapter.ClearBeforeFill = true;
			// 
			// get_EmpresasPropietariasTableAdapter
			// 
			this.get_EmpresasPropietariasTableAdapter.ClearBeforeFill = true;
			// 
			// get_ConcesionesDisponiblesTableAdapter
			// 
			this.get_ConcesionesDisponiblesTableAdapter.ClearBeforeFill = true;
			// 
			// comboBox1
			// 
			this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.unidadesBindingSource, "Arrendamiento_ID", true));
			this.comboBox1.DataSource = this.getArrendamientosDisponiblesBindingSource;
			this.comboBox1.DisplayMember = "Descripcion";
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(165, 393);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(266, 26);
			this.comboBox1.TabIndex = 36;
			this.comboBox1.ValueMember = "Arrendamiento_ID";
			// 
			// getArrendamientosDisponiblesBindingSource
			// 
			this.getArrendamientosDisponiblesBindingSource.DataMember = "Get_ArrendamientosDisponibles";
			this.getArrendamientosDisponiblesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
			// 
			// get_ArrendamientosDisponiblesTableAdapter
			// 
			this.get_ArrendamientosDisponiblesTableAdapter.ClearBeforeFill = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dteFechaCompra);
			this.groupBox1.Controls.Add(label2);
			this.groupBox1.Controls.Add(this.gpsTextBox);
			this.groupBox1.Controls.Add(label1);
			this.groupBox1.Controls.Add(this.estacion_IDComboBox);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(unidad_IDLabel);
			this.groupBox1.Controls.Add(this.concesion_IDComboBox);
			this.groupBox1.Controls.Add(this.unidad_IDTextBox);
			this.groupBox1.Controls.Add(concesion_IDLabel);
			this.groupBox1.Controls.Add(empresa_IDLabel);
			this.groupBox1.Controls.Add(arrendamiento_IDLabel);
			this.groupBox1.Controls.Add(this.propietario_IDComboBox);
			this.groupBox1.Controls.Add(this.empresa_IDComboBox);
			this.groupBox1.Controls.Add(propietario_IDLabel);
			this.groupBox1.Controls.Add(estacion_IDLabel);
			this.groupBox1.Controls.Add(this.kilometrajeTextBox);
			this.groupBox1.Controls.Add(kilometrajeLabel);
			this.groupBox1.Controls.Add(numeroEconomicoLabel);
			this.groupBox1.Controls.Add(this.placasTextBox);
			this.groupBox1.Controls.Add(this.numeroEconomicoTextBox);
			this.groupBox1.Controls.Add(placasLabel);
			this.groupBox1.Controls.Add(modeloUnidad_IDLabel);
			this.groupBox1.Controls.Add(this.locacionUnidad_IDComboBox);
			this.groupBox1.Controls.Add(this.modeloUnidad_IDComboBox);
			this.groupBox1.Controls.Add(locacionUnidad_IDLabel);
			this.groupBox1.Controls.Add(precioListaLabel);
			this.groupBox1.Controls.Add(this.precioListaTextBox);
			this.groupBox1.Controls.Add(numeroSerieLabel);
			this.groupBox1.Controls.Add(this.tarjetaCirculacionTextBox);
			this.groupBox1.Controls.Add(this.numeroSerieTextBox);
			this.groupBox1.Controls.Add(tarjetaCirculacionLabel);
			this.groupBox1.Controls.Add(numeroSerieMotorLabel);
			this.groupBox1.Controls.Add(this.numeroSerieMotorTextBox);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 529);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos de la unidad";
			// 
			// gpsTextBox
			// 
			this.gpsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unidadesBindingSource, "GPS", true));
			this.gpsTextBox.Location = new System.Drawing.Point(165, 449);
			this.gpsTextBox.Name = "gpsTextBox";
			this.gpsTextBox.Size = new System.Drawing.Size(121, 24);
			this.gpsTextBox.TabIndex = 38;
			// 
			// dteFechaCompra
			// 
			this.dteFechaCompra.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.unidadesBindingSource, "FechaCompra", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
			this.dteFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dteFechaCompra.Location = new System.Drawing.Point(165, 479);
			this.dteFechaCompra.Name = "dteFechaCompra";
			this.dteFechaCompra.Size = new System.Drawing.Size(121, 24);
			this.dteFechaCompra.TabIndex = 42;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(37, 481);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(131, 18);
			label2.TabIndex = 41;
			label2.Text = "Fecha de Compra:";
			// 
			// ActualizacionUnidad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 680);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.unidadesBindingNavigator);
			this.Controls.Add(this.GuardarButton);
			this.Name = "ActualizacionUnidad";
			this.Text = "AltaUnidad";
			this.Load += new System.EventHandler(this.AltaUnidad_Load);
			this.Controls.SetChildIndex(this.GuardarButton, 0);
			this.Controls.SetChildIndex(this.unidadesBindingNavigator, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unidadesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unidadesBindingNavigator)).EndInit();
			this.unidadesBindingNavigator.ResumeLayout(false);
			this.unidadesBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.selectEmpresasInternasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectEstacionesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.estatusUnidadesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.locacionesUnidadesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getEmpresasPropietariasBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getConcesionesDisponiblesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.getArrendamientosDisponiblesBindingSource)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource unidadesBindingSource;
        private SICASCentralDataSetTableAdapters.UnidadesTableAdapter unidadesTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator unidadesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton unidadesBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox unidad_IDTextBox;
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.TextBox numeroEconomicoTextBox;
        private System.Windows.Forms.ComboBox modeloUnidad_IDComboBox;
        private System.Windows.Forms.TextBox precioListaTextBox;
        private System.Windows.Forms.TextBox numeroSerieTextBox;
        private System.Windows.Forms.TextBox numeroSerieMotorTextBox;
        private System.Windows.Forms.TextBox tarjetaCirculacionTextBox;
        private System.Windows.Forms.ComboBox locacionUnidad_IDComboBox;
        private System.Windows.Forms.TextBox placasTextBox;
        private System.Windows.Forms.TextBox kilometrajeTextBox;
        private System.Windows.Forms.ComboBox propietario_IDComboBox;
        private System.Windows.Forms.ComboBox concesion_IDComboBox;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource getEmpresasInternasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter get_EmpresasInternasTableAdapter;
        private SICASCentralDataSetTableAdapters.EstacionesTableAdapter estacionesTableAdapter;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource getModelosUnidadesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter get_ModelosUnidadesTableAdapter;
        private System.Windows.Forms.BindingSource estatusUnidadesBindingSource;
        private SICASCentralDataSetTableAdapters.EstatusUnidadesTableAdapter estatusUnidadesTableAdapter;
        private System.Windows.Forms.BindingSource locacionesUnidadesBindingSource;
        private SICASCentralDataSetTableAdapters.LocacionesUnidadesTableAdapter locacionesUnidadesTableAdapter;
        private System.Windows.Forms.BindingSource getEmpresasPropietariasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasPropietariasTableAdapter get_EmpresasPropietariasTableAdapter;
        private System.Windows.Forms.BindingSource getConcesionesDisponiblesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ConcesionesDisponiblesTableAdapter get_ConcesionesDisponiblesTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource getArrendamientosDisponiblesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ArrendamientosDisponiblesTableAdapter get_ArrendamientosDisponiblesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource selectEmpresasInternasBindingSource;
        private System.Windows.Forms.BindingSource selectEstacionesBindingSource;
        private System.Windows.Forms.TextBox gpsTextBox;
	   private System.Windows.Forms.DateTimePicker dteFechaCompra;
    }
}