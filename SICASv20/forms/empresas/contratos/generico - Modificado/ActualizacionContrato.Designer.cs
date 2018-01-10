namespace SICASv20.forms
{
    partial class ActualizacionContrato
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
            System.Windows.Forms.Label contrato_IDLabel;
            System.Windows.Forms.Label empresa_IDLabel;
            System.Windows.Forms.Label estacion_IDLabel;
            System.Windows.Forms.Label tipoContrato_IDLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label modeloUnidad_IDLabel;
            System.Windows.Forms.Label montoDiarioLabel;
            System.Windows.Forms.Label diasDeCobro_IDLabel;
            System.Windows.Forms.Label fondoResidualLabel;
            System.Windows.Forms.Label conductor_IDLabel;
            System.Windows.Forms.Label unidad_IDLabel;
            System.Windows.Forms.Label numeroEconomicoLabel;
            System.Windows.Forms.Label cuenta_IDLabel;
            System.Windows.Forms.Label concepto_IDLabel;
            System.Windows.Forms.Label fechaInicialLabel;
            System.Windows.Forms.Label fechaFinalLabel;
            System.Windows.Forms.Label estatusContrato_IDLabel;
            System.Windows.Forms.Label comentariosLabel;
            System.Windows.Forms.Label conductorCopia_IDLabel;
            System.Windows.Forms.Label cobroPermanenteLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizacionContrato));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.contratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contratosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ContratosTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.diasDeCobrosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.DiasDeCobrosTableAdapter();
            this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
            this.tiposContratosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.TiposContratosTableAdapter();
            this.contratosBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.contratosBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.contrato_IDTextBox = new System.Windows.Forms.TextBox();
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.tipoContrato_IDComboBox = new System.Windows.Forms.ComboBox();
            this.tiposContratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.modeloUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getModelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.montoDiarioTextBox = new System.Windows.Forms.TextBox();
            this.diasDeCobro_IDComboBox = new System.Windows.Forms.ComboBox();
            this.diasDeCobrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fondoResidualTextBox = new System.Windows.Forms.TextBox();
            this.getConductoresDeEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getUnidadesDeEmpresaEstacionParaContratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.fechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
            this.conductorCopia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectConductoresDeEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuardarButton = new System.Windows.Forms.Button();
            this.get_SelectConductoresDeEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectConductoresDeEstacionTableAdapter();
            this.get_ConductoresDeEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ConductoresDeEstacionTableAdapter();
            this.cobroPermanenteCheckBox = new System.Windows.Forms.CheckBox();
            this.get_ModelosUnidadesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter();
            this.estatusContrato_IDcomboBox = new System.Windows.Forms.ComboBox();
            this.estatusContratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estatusContratosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstatusContratosTableAdapter();
            this.get_UnidadesDeEmpresaEstacionParaContratoTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_UnidadesDeEmpresaEstacionParaContratoTableAdapter();
            this.empresa_IDTextBox = new System.Windows.Forms.TextBox();
            this.estacion_IDTextBox = new System.Windows.Forms.TextBox();
            this.conductor_IDTextBox = new System.Windows.Forms.TextBox();
            this.unidad_IDTextBox = new System.Windows.Forms.TextBox();
            this.cuenta_IDTextBox = new System.Windows.Forms.TextBox();
            this.concepto_IDTextBox = new System.Windows.Forms.TextBox();
            this.vista_ContratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_ContratosTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Vista_ContratosTableAdapter();
            this.tableAdapterManager1 = new SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager();
            this.empresaTextBox = new System.Windows.Forms.TextBox();
            this.estacionTextBox = new System.Windows.Forms.TextBox();
            this.conductorTextBox = new System.Windows.Forms.TextBox();
            this.unidadTextBox = new System.Windows.Forms.TextBox();
            this.cuentaTextBox = new System.Windows.Forms.TextBox();
            this.conceptoTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            contrato_IDLabel = new System.Windows.Forms.Label();
            empresa_IDLabel = new System.Windows.Forms.Label();
            estacion_IDLabel = new System.Windows.Forms.Label();
            tipoContrato_IDLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            modeloUnidad_IDLabel = new System.Windows.Forms.Label();
            montoDiarioLabel = new System.Windows.Forms.Label();
            diasDeCobro_IDLabel = new System.Windows.Forms.Label();
            fondoResidualLabel = new System.Windows.Forms.Label();
            conductor_IDLabel = new System.Windows.Forms.Label();
            unidad_IDLabel = new System.Windows.Forms.Label();
            numeroEconomicoLabel = new System.Windows.Forms.Label();
            cuenta_IDLabel = new System.Windows.Forms.Label();
            concepto_IDLabel = new System.Windows.Forms.Label();
            fechaInicialLabel = new System.Windows.Forms.Label();
            fechaFinalLabel = new System.Windows.Forms.Label();
            estatusContrato_IDLabel = new System.Windows.Forms.Label();
            comentariosLabel = new System.Windows.Forms.Label();
            conductorCopia_IDLabel = new System.Windows.Forms.Label();
            cobroPermanenteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingNavigator)).BeginInit();
            this.contratosBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConductoresDeEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getUnidadesDeEmpresaEstacionParaContratoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectConductoresDeEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusContratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ContratosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contrato_IDLabel
            // 
            contrato_IDLabel.AutoSize = true;
            contrato_IDLabel.Location = new System.Drawing.Point(32, 28);
            contrato_IDLabel.Name = "contrato_IDLabel";
            contrato_IDLabel.Size = new System.Drawing.Size(71, 15);
            contrato_IDLabel.TabIndex = 1;
            contrato_IDLabel.Text = "Contrato ID:";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(32, 55);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 3;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(32, 84);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 5;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // tipoContrato_IDLabel
            // 
            tipoContrato_IDLabel.AutoSize = true;
            tipoContrato_IDLabel.Location = new System.Drawing.Point(32, 113);
            tipoContrato_IDLabel.Name = "tipoContrato_IDLabel";
            tipoContrato_IDLabel.Size = new System.Drawing.Size(98, 15);
            tipoContrato_IDLabel.TabIndex = 7;
            tipoContrato_IDLabel.Text = "Tipo Contrato ID:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(32, 142);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(75, 15);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion:";
            // 
            // modeloUnidad_IDLabel
            // 
            modeloUnidad_IDLabel.AutoSize = true;
            modeloUnidad_IDLabel.Location = new System.Drawing.Point(32, 169);
            modeloUnidad_IDLabel.Name = "modeloUnidad_IDLabel";
            modeloUnidad_IDLabel.Size = new System.Drawing.Size(110, 15);
            modeloUnidad_IDLabel.TabIndex = 11;
            modeloUnidad_IDLabel.Text = "Modelo Unidad ID:";
            // 
            // montoDiarioLabel
            // 
            montoDiarioLabel.AutoSize = true;
            montoDiarioLabel.Location = new System.Drawing.Point(32, 198);
            montoDiarioLabel.Name = "montoDiarioLabel";
            montoDiarioLabel.Size = new System.Drawing.Size(81, 15);
            montoDiarioLabel.TabIndex = 13;
            montoDiarioLabel.Text = "Monto Diario:";
            // 
            // diasDeCobro_IDLabel
            // 
            diasDeCobro_IDLabel.AutoSize = true;
            diasDeCobro_IDLabel.Location = new System.Drawing.Point(32, 225);
            diasDeCobro_IDLabel.Name = "diasDeCobro_IDLabel";
            diasDeCobro_IDLabel.Size = new System.Drawing.Size(105, 15);
            diasDeCobro_IDLabel.TabIndex = 15;
            diasDeCobro_IDLabel.Text = "Dias De Cobro ID:";
            // 
            // fondoResidualLabel
            // 
            fondoResidualLabel.AutoSize = true;
            fondoResidualLabel.Location = new System.Drawing.Point(32, 254);
            fondoResidualLabel.Name = "fondoResidualLabel";
            fondoResidualLabel.Size = new System.Drawing.Size(97, 15);
            fondoResidualLabel.TabIndex = 17;
            fondoResidualLabel.Text = "Fondo Residual:";
            // 
            // conductor_IDLabel
            // 
            conductor_IDLabel.AutoSize = true;
            conductor_IDLabel.Location = new System.Drawing.Point(32, 281);
            conductor_IDLabel.Name = "conductor_IDLabel";
            conductor_IDLabel.Size = new System.Drawing.Size(81, 15);
            conductor_IDLabel.TabIndex = 19;
            conductor_IDLabel.Text = "Conductor ID:";
            // 
            // unidad_IDLabel
            // 
            unidad_IDLabel.AutoSize = true;
            unidad_IDLabel.Location = new System.Drawing.Point(32, 310);
            unidad_IDLabel.Name = "unidad_IDLabel";
            unidad_IDLabel.Size = new System.Drawing.Size(65, 15);
            unidad_IDLabel.TabIndex = 21;
            unidad_IDLabel.Text = "Unidad ID:";
            // 
            // numeroEconomicoLabel
            // 
            numeroEconomicoLabel.AutoSize = true;
            numeroEconomicoLabel.Location = new System.Drawing.Point(32, 339);
            numeroEconomicoLabel.Name = "numeroEconomicoLabel";
            numeroEconomicoLabel.Size = new System.Drawing.Size(120, 15);
            numeroEconomicoLabel.TabIndex = 23;
            numeroEconomicoLabel.Text = "Numero Economico:";
            // 
            // cuenta_IDLabel
            // 
            cuenta_IDLabel.AutoSize = true;
            cuenta_IDLabel.Location = new System.Drawing.Point(32, 366);
            cuenta_IDLabel.Name = "cuenta_IDLabel";
            cuenta_IDLabel.Size = new System.Drawing.Size(64, 15);
            cuenta_IDLabel.TabIndex = 25;
            cuenta_IDLabel.Text = "Cuenta ID:";
            // 
            // concepto_IDLabel
            // 
            concepto_IDLabel.AutoSize = true;
            concepto_IDLabel.Location = new System.Drawing.Point(32, 395);
            concepto_IDLabel.Name = "concepto_IDLabel";
            concepto_IDLabel.Size = new System.Drawing.Size(77, 15);
            concepto_IDLabel.TabIndex = 27;
            concepto_IDLabel.Text = "Concepto ID:";
            // 
            // fechaInicialLabel
            // 
            fechaInicialLabel.AutoSize = true;
            fechaInicialLabel.Location = new System.Drawing.Point(32, 425);
            fechaInicialLabel.Name = "fechaInicialLabel";
            fechaInicialLabel.Size = new System.Drawing.Size(79, 15);
            fechaInicialLabel.TabIndex = 29;
            fechaInicialLabel.Text = "Fecha Inicial:";
            // 
            // fechaFinalLabel
            // 
            fechaFinalLabel.AutoSize = true;
            fechaFinalLabel.Location = new System.Drawing.Point(32, 452);
            fechaFinalLabel.Name = "fechaFinalLabel";
            fechaFinalLabel.Size = new System.Drawing.Size(74, 15);
            fechaFinalLabel.TabIndex = 31;
            fechaFinalLabel.Text = "Fecha Final:";
            // 
            // estatusContrato_IDLabel
            // 
            estatusContrato_IDLabel.AutoSize = true;
            estatusContrato_IDLabel.Location = new System.Drawing.Point(32, 478);
            estatusContrato_IDLabel.Name = "estatusContrato_IDLabel";
            estatusContrato_IDLabel.Size = new System.Drawing.Size(114, 15);
            estatusContrato_IDLabel.TabIndex = 33;
            estatusContrato_IDLabel.Text = "Estatus Contrato ID:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.AutoSize = true;
            comentariosLabel.Location = new System.Drawing.Point(32, 505);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(80, 15);
            comentariosLabel.TabIndex = 35;
            comentariosLabel.Text = "Comentarios:";
            // 
            // conductorCopia_IDLabel
            // 
            conductorCopia_IDLabel.AutoSize = true;
            conductorCopia_IDLabel.Location = new System.Drawing.Point(32, 560);
            conductorCopia_IDLabel.Name = "conductorCopia_IDLabel";
            conductorCopia_IDLabel.Size = new System.Drawing.Size(116, 15);
            conductorCopia_IDLabel.TabIndex = 37;
            conductorCopia_IDLabel.Text = "Conductor Copia ID:";
            // 
            // cobroPermanenteLabel
            // 
            cobroPermanenteLabel.AutoSize = true;
            cobroPermanenteLabel.Location = new System.Drawing.Point(32, 590);
            cobroPermanenteLabel.Name = "cobroPermanenteLabel";
            cobroPermanenteLabel.Size = new System.Drawing.Size(114, 15);
            cobroPermanenteLabel.TabIndex = 40;
            cobroPermanenteLabel.Text = "Cobro Permanente:";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contratosBindingSource
            // 
            this.contratosBindingSource.DataMember = "Contratos";
            this.contratosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // contratosTableAdapter
            // 
            this.contratosTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.ContratosTableAdapter = this.contratosTableAdapter;
            this.tableAdapterManager.CuentaCajasTableAdapter = null;
            this.tableAdapterManager.CuentaConductoresTableAdapter = null;
            this.tableAdapterManager.CuentaEmpresasTableAdapter = null;
            this.tableAdapterManager.CuentaFlujoCajasTableAdapter = null;
            this.tableAdapterManager.CuentasTableAdapter = null;
            this.tableAdapterManager.CuentaUnidadesTableAdapter = null;
            this.tableAdapterManager.DiasDeCobrosTableAdapter = this.diasDeCobrosTableAdapter;
            this.tableAdapterManager.Empresas_CuentasTableAdapter = null;
            this.tableAdapterManager.EmpresasTableAdapter = this.empresasTableAdapter;
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
            this.tableAdapterManager.TiposContratosTableAdapter = this.tiposContratosTableAdapter;
            this.tableAdapterManager.TiposCuentasTableAdapter = null;
            this.tableAdapterManager.TiposEmpresasTableAdapter = null;
            this.tableAdapterManager.TiposLicenciasTableAdapter = null;
            this.tableAdapterManager.UnidadesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuariosTableAdapter = null;
            this.tableAdapterManager.ValesPrepagadosTableAdapter = null;
            // 
            // diasDeCobrosTableAdapter
            // 
            this.diasDeCobrosTableAdapter.ClearBeforeFill = true;
            // 
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // tiposContratosTableAdapter
            // 
            this.tiposContratosTableAdapter.ClearBeforeFill = true;
            // 
            // contratosBindingNavigator
            // 
            this.contratosBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.contratosBindingNavigator.BindingSource = this.contratosBindingSource;
            this.contratosBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.contratosBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.contratosBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.contratosBindingNavigatorSaveItem});
            this.contratosBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.contratosBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.contratosBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.contratosBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.contratosBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.contratosBindingNavigator.Name = "contratosBindingNavigator";
            this.contratosBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.contratosBindingNavigator.Size = new System.Drawing.Size(1024, 25);
            this.contratosBindingNavigator.TabIndex = 0;
            this.contratosBindingNavigator.Text = "bindingNavigator1";
            this.contratosBindingNavigator.Visible = false;
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
            // contratosBindingNavigatorSaveItem
            // 
            this.contratosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.contratosBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("contratosBindingNavigatorSaveItem.Image")));
            this.contratosBindingNavigatorSaveItem.Name = "contratosBindingNavigatorSaveItem";
            this.contratosBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.contratosBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // contrato_IDTextBox
            // 
            this.contrato_IDTextBox.BackColor = System.Drawing.Color.White;
            this.contrato_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Contrato_ID", true));
            this.contrato_IDTextBox.Location = new System.Drawing.Point(158, 25);
            this.contrato_IDTextBox.Name = "contrato_IDTextBox";
            this.contrato_IDTextBox.ReadOnly = true;
            this.contrato_IDTextBox.Size = new System.Drawing.Size(125, 21);
            this.contrato_IDTextBox.TabIndex = 2;
            // 
            // sICASCentralQuerysDataSet
            // 
            this.sICASCentralQuerysDataSet.DataSetName = "SICASCentralQuerysDataSet";
            this.sICASCentralQuerysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipoContrato_IDComboBox
            // 
            this.tipoContrato_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "TipoContrato_ID", true));
            this.tipoContrato_IDComboBox.DataSource = this.tiposContratosBindingSource;
            this.tipoContrato_IDComboBox.DisplayMember = "Nombre";
            this.tipoContrato_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoContrato_IDComboBox.FormattingEnabled = true;
            this.tipoContrato_IDComboBox.Location = new System.Drawing.Point(158, 110);
            this.tipoContrato_IDComboBox.Name = "tipoContrato_IDComboBox";
            this.tipoContrato_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.tipoContrato_IDComboBox.TabIndex = 8;
            this.tipoContrato_IDComboBox.ValueMember = "TipoContrato_ID";
            // 
            // tiposContratosBindingSource
            // 
            this.tiposContratosBindingSource.DataMember = "TiposContratos";
            this.tiposContratosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(158, 139);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.ReadOnly = true;
            this.descripcionTextBox.Size = new System.Drawing.Size(200, 21);
            this.descripcionTextBox.TabIndex = 10;
            // 
            // modeloUnidad_IDComboBox
            // 
            this.modeloUnidad_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "ModeloUnidad_ID", true));
            this.modeloUnidad_IDComboBox.DataSource = this.getModelosUnidadesBindingSource;
            this.modeloUnidad_IDComboBox.DisplayMember = "Descripcion";
            this.modeloUnidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeloUnidad_IDComboBox.FormattingEnabled = true;
            this.modeloUnidad_IDComboBox.Location = new System.Drawing.Point(158, 166);
            this.modeloUnidad_IDComboBox.Name = "modeloUnidad_IDComboBox";
            this.modeloUnidad_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.modeloUnidad_IDComboBox.TabIndex = 12;
            this.modeloUnidad_IDComboBox.ValueMember = "ModeloUnidad_ID";
            // 
            // getModelosUnidadesBindingSource
            // 
            this.getModelosUnidadesBindingSource.DataMember = "Get_ModelosUnidades";
            this.getModelosUnidadesBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // montoDiarioTextBox
            // 
            this.montoDiarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "MontoDiario", true));
            this.montoDiarioTextBox.Location = new System.Drawing.Point(158, 195);
            this.montoDiarioTextBox.Name = "montoDiarioTextBox";
            this.montoDiarioTextBox.Size = new System.Drawing.Size(125, 21);
            this.montoDiarioTextBox.TabIndex = 14;
            // 
            // diasDeCobro_IDComboBox
            // 
            this.diasDeCobro_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "DiasDeCobro_ID", true));
            this.diasDeCobro_IDComboBox.DataSource = this.diasDeCobrosBindingSource;
            this.diasDeCobro_IDComboBox.DisplayMember = "Nombre";
            this.diasDeCobro_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diasDeCobro_IDComboBox.FormattingEnabled = true;
            this.diasDeCobro_IDComboBox.Location = new System.Drawing.Point(158, 222);
            this.diasDeCobro_IDComboBox.Name = "diasDeCobro_IDComboBox";
            this.diasDeCobro_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.diasDeCobro_IDComboBox.TabIndex = 16;
            this.diasDeCobro_IDComboBox.ValueMember = "DiasDeCobro_ID";
            // 
            // diasDeCobrosBindingSource
            // 
            this.diasDeCobrosBindingSource.DataMember = "DiasDeCobros";
            this.diasDeCobrosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // fondoResidualTextBox
            // 
            this.fondoResidualTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "FondoResidual", true));
            this.fondoResidualTextBox.Location = new System.Drawing.Point(158, 251);
            this.fondoResidualTextBox.Name = "fondoResidualTextBox";
            this.fondoResidualTextBox.ReadOnly = true;
            this.fondoResidualTextBox.Size = new System.Drawing.Size(125, 21);
            this.fondoResidualTextBox.TabIndex = 18;
            // 
            // getConductoresDeEstacionBindingSource
            // 
            this.getConductoresDeEstacionBindingSource.DataMember = "Get_ConductoresDeEstacion";
            this.getConductoresDeEstacionBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // getUnidadesDeEmpresaEstacionParaContratoBindingSource
            // 
            this.getUnidadesDeEmpresaEstacionParaContratoBindingSource.DataMember = "Get_UnidadesDeEmpresaEstacionParaContrato";
            this.getUnidadesDeEmpresaEstacionParaContratoBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // numeroEconomicoTextBox
            // 
            this.numeroEconomicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "NumeroEconomico", true));
            this.numeroEconomicoTextBox.Location = new System.Drawing.Point(158, 336);
            this.numeroEconomicoTextBox.Name = "numeroEconomicoTextBox";
            this.numeroEconomicoTextBox.ReadOnly = true;
            this.numeroEconomicoTextBox.Size = new System.Drawing.Size(125, 21);
            this.numeroEconomicoTextBox.TabIndex = 24;
            // 
            // fechaInicialDateTimePicker
            // 
            this.fechaInicialDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contratosBindingSource, "FechaInicial", true));
            this.fechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicialDateTimePicker.Location = new System.Drawing.Point(158, 421);
            this.fechaInicialDateTimePicker.Name = "fechaInicialDateTimePicker";
            this.fechaInicialDateTimePicker.Size = new System.Drawing.Size(125, 21);
            this.fechaInicialDateTimePicker.TabIndex = 30;
            // 
            // fechaFinalDateTimePicker
            // 
            this.fechaFinalDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contratosBindingSource, "FechaFinal", true));
            this.fechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinalDateTimePicker.Location = new System.Drawing.Point(158, 448);
            this.fechaFinalDateTimePicker.Name = "fechaFinalDateTimePicker";
            this.fechaFinalDateTimePicker.Size = new System.Drawing.Size(125, 21);
            this.fechaFinalDateTimePicker.TabIndex = 32;
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Comentarios", true));
            this.comentariosTextBox.Location = new System.Drawing.Point(158, 502);
            this.comentariosTextBox.Multiline = true;
            this.comentariosTextBox.Name = "comentariosTextBox";
            this.comentariosTextBox.ReadOnly = true;
            this.comentariosTextBox.Size = new System.Drawing.Size(200, 49);
            this.comentariosTextBox.TabIndex = 36;
            // 
            // conductorCopia_IDComboBox
            // 
            this.conductorCopia_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "ConductorCopia_ID", true));
            this.conductorCopia_IDComboBox.DataSource = this.getSelectConductoresDeEstacionBindingSource;
            this.conductorCopia_IDComboBox.DisplayMember = "Nombre";
            this.conductorCopia_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conductorCopia_IDComboBox.FormattingEnabled = true;
            this.conductorCopia_IDComboBox.Location = new System.Drawing.Point(158, 557);
            this.conductorCopia_IDComboBox.Name = "conductorCopia_IDComboBox";
            this.conductorCopia_IDComboBox.Size = new System.Drawing.Size(363, 23);
            this.conductorCopia_IDComboBox.TabIndex = 38;
            this.conductorCopia_IDComboBox.ValueMember = "Conductor_ID";
            // 
            // getSelectConductoresDeEstacionBindingSource
            // 
            this.getSelectConductoresDeEstacionBindingSource.DataMember = "Get_SelectConductoresDeEstacion";
            this.getSelectConductoresDeEstacionBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "Empresas";
            this.empresasBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(606, 22);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(81, 36);
            this.GuardarButton.TabIndex = 39;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // get_SelectConductoresDeEstacionTableAdapter
            // 
            this.get_SelectConductoresDeEstacionTableAdapter.ClearBeforeFill = true;
            // 
            // get_ConductoresDeEstacionTableAdapter
            // 
            this.get_ConductoresDeEstacionTableAdapter.ClearBeforeFill = true;
            // 
            // cobroPermanenteCheckBox
            // 
            this.cobroPermanenteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.contratosBindingSource, "CobroPermanente", true));
            this.cobroPermanenteCheckBox.Location = new System.Drawing.Point(158, 586);
            this.cobroPermanenteCheckBox.Name = "cobroPermanenteCheckBox";
            this.cobroPermanenteCheckBox.Size = new System.Drawing.Size(104, 24);
            this.cobroPermanenteCheckBox.TabIndex = 41;
            this.cobroPermanenteCheckBox.UseVisualStyleBackColor = true;
            // 
            // get_ModelosUnidadesTableAdapter
            // 
            this.get_ModelosUnidadesTableAdapter.ClearBeforeFill = true;
            // 
            // estatusContrato_IDcomboBox
            // 
            this.estatusContrato_IDcomboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "EstatusContrato_ID", true));
            this.estatusContrato_IDcomboBox.DataSource = this.estatusContratosBindingSource;
            this.estatusContrato_IDcomboBox.DisplayMember = "Nombre";
            this.estatusContrato_IDcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estatusContrato_IDcomboBox.FormattingEnabled = true;
            this.estatusContrato_IDcomboBox.Location = new System.Drawing.Point(158, 475);
            this.estatusContrato_IDcomboBox.Name = "estatusContrato_IDcomboBox";
            this.estatusContrato_IDcomboBox.Size = new System.Drawing.Size(200, 23);
            this.estatusContrato_IDcomboBox.TabIndex = 42;
            this.estatusContrato_IDcomboBox.ValueMember = "EstatusContrato_ID";
            // 
            // estatusContratosBindingSource
            // 
            this.estatusContratosBindingSource.DataMember = "EstatusContratos";
            this.estatusContratosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // estatusContratosTableAdapter
            // 
            this.estatusContratosTableAdapter.ClearBeforeFill = true;
            // 
            // get_UnidadesDeEmpresaEstacionParaContratoTableAdapter
            // 
            this.get_UnidadesDeEmpresaEstacionParaContratoTableAdapter.ClearBeforeFill = true;
            // 
            // empresa_IDTextBox
            // 
            this.empresa_IDTextBox.BackColor = System.Drawing.Color.White;
            this.empresa_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Empresa_ID", true));
            this.empresa_IDTextBox.Location = new System.Drawing.Point(158, 52);
            this.empresa_IDTextBox.Name = "empresa_IDTextBox";
            this.empresa_IDTextBox.ReadOnly = true;
            this.empresa_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.empresa_IDTextBox.TabIndex = 43;
            // 
            // estacion_IDTextBox
            // 
            this.estacion_IDTextBox.BackColor = System.Drawing.Color.White;
            this.estacion_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Estacion_ID", true));
            this.estacion_IDTextBox.Location = new System.Drawing.Point(158, 79);
            this.estacion_IDTextBox.Name = "estacion_IDTextBox";
            this.estacion_IDTextBox.ReadOnly = true;
            this.estacion_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.estacion_IDTextBox.TabIndex = 44;
            // 
            // conductor_IDTextBox
            // 
            this.conductor_IDTextBox.BackColor = System.Drawing.Color.White;
            this.conductor_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Conductor_ID", true));
            this.conductor_IDTextBox.Location = new System.Drawing.Point(158, 278);
            this.conductor_IDTextBox.Name = "conductor_IDTextBox";
            this.conductor_IDTextBox.ReadOnly = true;
            this.conductor_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.conductor_IDTextBox.TabIndex = 45;
            // 
            // unidad_IDTextBox
            // 
            this.unidad_IDTextBox.BackColor = System.Drawing.Color.White;
            this.unidad_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Unidad_ID", true));
            this.unidad_IDTextBox.Location = new System.Drawing.Point(158, 307);
            this.unidad_IDTextBox.Name = "unidad_IDTextBox";
            this.unidad_IDTextBox.ReadOnly = true;
            this.unidad_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.unidad_IDTextBox.TabIndex = 46;
            // 
            // cuenta_IDTextBox
            // 
            this.cuenta_IDTextBox.BackColor = System.Drawing.Color.White;
            this.cuenta_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Cuenta_ID", true));
            this.cuenta_IDTextBox.Location = new System.Drawing.Point(158, 363);
            this.cuenta_IDTextBox.Name = "cuenta_IDTextBox";
            this.cuenta_IDTextBox.ReadOnly = true;
            this.cuenta_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.cuenta_IDTextBox.TabIndex = 47;
            // 
            // concepto_IDTextBox
            // 
            this.concepto_IDTextBox.BackColor = System.Drawing.Color.White;
            this.concepto_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Concepto_ID", true));
            this.concepto_IDTextBox.Location = new System.Drawing.Point(158, 392);
            this.concepto_IDTextBox.Name = "concepto_IDTextBox";
            this.concepto_IDTextBox.ReadOnly = true;
            this.concepto_IDTextBox.Size = new System.Drawing.Size(66, 21);
            this.concepto_IDTextBox.TabIndex = 48;
            // 
            // vista_ContratosBindingSource
            // 
            this.vista_ContratosBindingSource.DataMember = "Vista_Contratos";
            this.vista_ContratosBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // vista_ContratosTableAdapter
            // 
            this.vista_ContratosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Get_ArrendamientosDisponiblesTableAdapter = null;
            this.tableAdapterManager1.Get_EmpresasPropietariasTableAdapter = null;
            this.tableAdapterManager1.Get_MenuesTableAdapter = null;
            this.tableAdapterManager1.Get_ModelosUnidadesTableAdapter = this.get_ModelosUnidadesTableAdapter;
            this.tableAdapterManager1.Get_ModulosTableAdapter = null;
            this.tableAdapterManager1.Get_OpcionesTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = SICASv20.SICASCentralQuerysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // empresaTextBox
            // 
            this.empresaTextBox.BackColor = System.Drawing.Color.White;
            this.empresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Empresa", true));
            this.empresaTextBox.Location = new System.Drawing.Point(230, 52);
            this.empresaTextBox.Name = "empresaTextBox";
            this.empresaTextBox.ReadOnly = true;
            this.empresaTextBox.Size = new System.Drawing.Size(200, 21);
            this.empresaTextBox.TabIndex = 52;
            // 
            // estacionTextBox
            // 
            this.estacionTextBox.BackColor = System.Drawing.Color.White;
            this.estacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Estacion", true));
            this.estacionTextBox.Location = new System.Drawing.Point(230, 79);
            this.estacionTextBox.Name = "estacionTextBox";
            this.estacionTextBox.ReadOnly = true;
            this.estacionTextBox.Size = new System.Drawing.Size(200, 21);
            this.estacionTextBox.TabIndex = 54;
            // 
            // conductorTextBox
            // 
            this.conductorTextBox.BackColor = System.Drawing.Color.White;
            this.conductorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Conductor", true));
            this.conductorTextBox.Location = new System.Drawing.Point(230, 278);
            this.conductorTextBox.Name = "conductorTextBox";
            this.conductorTextBox.ReadOnly = true;
            this.conductorTextBox.Size = new System.Drawing.Size(200, 21);
            this.conductorTextBox.TabIndex = 68;
            // 
            // unidadTextBox
            // 
            this.unidadTextBox.BackColor = System.Drawing.Color.White;
            this.unidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Unidad", true));
            this.unidadTextBox.Location = new System.Drawing.Point(230, 305);
            this.unidadTextBox.Name = "unidadTextBox";
            this.unidadTextBox.ReadOnly = true;
            this.unidadTextBox.Size = new System.Drawing.Size(200, 21);
            this.unidadTextBox.TabIndex = 70;
            // 
            // cuentaTextBox
            // 
            this.cuentaTextBox.BackColor = System.Drawing.Color.White;
            this.cuentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Cuenta", true));
            this.cuentaTextBox.Location = new System.Drawing.Point(230, 363);
            this.cuentaTextBox.Name = "cuentaTextBox";
            this.cuentaTextBox.ReadOnly = true;
            this.cuentaTextBox.Size = new System.Drawing.Size(200, 21);
            this.cuentaTextBox.TabIndex = 72;
            // 
            // conceptoTextBox
            // 
            this.conceptoTextBox.BackColor = System.Drawing.Color.White;
            this.conceptoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vista_ContratosBindingSource, "Concepto", true));
            this.conceptoTextBox.Location = new System.Drawing.Point(230, 390);
            this.conceptoTextBox.Name = "conceptoTextBox";
            this.conceptoTextBox.ReadOnly = true;
            this.conceptoTextBox.Size = new System.Drawing.Size(200, 21);
            this.conceptoTextBox.TabIndex = 74;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(contrato_IDLabel);
            this.groupBox1.Controls.Add(this.empresaTextBox);
            this.groupBox1.Controls.Add(this.conductorCopia_IDComboBox);
            this.groupBox1.Controls.Add(this.estacionTextBox);
            this.groupBox1.Controls.Add(conductorCopia_IDLabel);
            this.groupBox1.Controls.Add(this.conductorTextBox);
            this.groupBox1.Controls.Add(this.comentariosTextBox);
            this.groupBox1.Controls.Add(this.unidadTextBox);
            this.groupBox1.Controls.Add(comentariosLabel);
            this.groupBox1.Controls.Add(this.cuentaTextBox);
            this.groupBox1.Controls.Add(estatusContrato_IDLabel);
            this.groupBox1.Controls.Add(this.conceptoTextBox);
            this.groupBox1.Controls.Add(this.fechaFinalDateTimePicker);
            this.groupBox1.Controls.Add(this.concepto_IDTextBox);
            this.groupBox1.Controls.Add(fechaFinalLabel);
            this.groupBox1.Controls.Add(this.cuenta_IDTextBox);
            this.groupBox1.Controls.Add(this.fechaInicialDateTimePicker);
            this.groupBox1.Controls.Add(this.unidad_IDTextBox);
            this.groupBox1.Controls.Add(fechaInicialLabel);
            this.groupBox1.Controls.Add(this.conductor_IDTextBox);
            this.groupBox1.Controls.Add(concepto_IDLabel);
            this.groupBox1.Controls.Add(this.estacion_IDTextBox);
            this.groupBox1.Controls.Add(cuenta_IDLabel);
            this.groupBox1.Controls.Add(this.empresa_IDTextBox);
            this.groupBox1.Controls.Add(this.numeroEconomicoTextBox);
            this.groupBox1.Controls.Add(this.estatusContrato_IDcomboBox);
            this.groupBox1.Controls.Add(numeroEconomicoLabel);
            this.groupBox1.Controls.Add(cobroPermanenteLabel);
            this.groupBox1.Controls.Add(unidad_IDLabel);
            this.groupBox1.Controls.Add(this.cobroPermanenteCheckBox);
            this.groupBox1.Controls.Add(conductor_IDLabel);
            this.groupBox1.Controls.Add(this.fondoResidualTextBox);
            this.groupBox1.Controls.Add(fondoResidualLabel);
            this.groupBox1.Controls.Add(this.contrato_IDTextBox);
            this.groupBox1.Controls.Add(this.diasDeCobro_IDComboBox);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Controls.Add(diasDeCobro_IDLabel);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(this.montoDiarioTextBox);
            this.groupBox1.Controls.Add(tipoContrato_IDLabel);
            this.groupBox1.Controls.Add(montoDiarioLabel);
            this.groupBox1.Controls.Add(this.tipoContrato_IDComboBox);
            this.groupBox1.Controls.Add(this.modeloUnidad_IDComboBox);
            this.groupBox1.Controls.Add(descripcionLabel);
            this.groupBox1.Controls.Add(modeloUnidad_IDLabel);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 628);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de contrato";
            // 
            // ActualizacionContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.contratosBindingNavigator);
            this.Name = "ActualizacionContrato";
            this.Text = "AltaContrato";
            this.Controls.SetChildIndex(this.contratosBindingNavigator, 0);
            this.Controls.SetChildIndex(this.GuardarButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingNavigator)).EndInit();
            this.contratosBindingNavigator.ResumeLayout(false);
            this.contratosBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConductoresDeEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getUnidadesDeEmpresaEstacionParaContratoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectConductoresDeEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusContratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista_ContratosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource contratosBindingSource;
        private SICASCentralDataSetTableAdapters.ContratosTableAdapter contratosTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator contratosBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton contratosBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox contrato_IDTextBox;
        private System.Windows.Forms.ComboBox tipoContrato_IDComboBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.ComboBox modeloUnidad_IDComboBox;
        private System.Windows.Forms.TextBox montoDiarioTextBox;
        private System.Windows.Forms.ComboBox diasDeCobro_IDComboBox;
        private System.Windows.Forms.TextBox fondoResidualTextBox;
        private System.Windows.Forms.TextBox numeroEconomicoTextBox;
        private System.Windows.Forms.DateTimePicker fechaInicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaFinalDateTimePicker;
        private System.Windows.Forms.TextBox comentariosTextBox;
        private System.Windows.Forms.ComboBox conductorCopia_IDComboBox;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private SICASCentralDataSetTableAdapters.TiposContratosTableAdapter tiposContratosTableAdapter;
        private System.Windows.Forms.BindingSource tiposContratosBindingSource;
        private SICASCentralDataSetTableAdapters.DiasDeCobrosTableAdapter diasDeCobrosTableAdapter;
        private System.Windows.Forms.BindingSource diasDeCobrosBindingSource;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource getConductoresDeEstacionBindingSource;
        private System.Windows.Forms.BindingSource getSelectConductoresDeEstacionBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectConductoresDeEstacionTableAdapter get_SelectConductoresDeEstacionTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.Get_ConductoresDeEstacionTableAdapter get_ConductoresDeEstacionTableAdapter;
        private System.Windows.Forms.CheckBox cobroPermanenteCheckBox;
        private System.Windows.Forms.BindingSource getModelosUnidadesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter get_ModelosUnidadesTableAdapter;
        private System.Windows.Forms.ComboBox estatusContrato_IDcomboBox;
        private System.Windows.Forms.BindingSource estatusContratosBindingSource;
        private SICASCentralDataSetTableAdapters.EstatusContratosTableAdapter estatusContratosTableAdapter;
        private System.Windows.Forms.BindingSource getUnidadesDeEmpresaEstacionParaContratoBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_UnidadesDeEmpresaEstacionParaContratoTableAdapter get_UnidadesDeEmpresaEstacionParaContratoTableAdapter;
        private System.Windows.Forms.TextBox empresa_IDTextBox;
        private System.Windows.Forms.TextBox estacion_IDTextBox;
        private System.Windows.Forms.TextBox conductor_IDTextBox;
        private System.Windows.Forms.TextBox unidad_IDTextBox;
        private System.Windows.Forms.TextBox cuenta_IDTextBox;
        private System.Windows.Forms.TextBox concepto_IDTextBox;
        private System.Windows.Forms.BindingSource vista_ContratosBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Vista_ContratosTableAdapter vista_ContratosTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.TextBox empresaTextBox;
        private System.Windows.Forms.TextBox estacionTextBox;
        private System.Windows.Forms.TextBox conductorTextBox;
        private System.Windows.Forms.TextBox unidadTextBox;
        private System.Windows.Forms.TextBox cuentaTextBox;
        private System.Windows.Forms.TextBox conceptoTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}