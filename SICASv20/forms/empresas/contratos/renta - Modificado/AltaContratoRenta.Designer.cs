namespace SICASv20.forms
{
    partial class AltaContratoRenta
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
            System.Windows.Forms.Label comentariosLabel;
            System.Windows.Forms.Label conductorCopia_IDLabel;
            System.Windows.Forms.Label cobroPermanenteLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaContrato));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.contratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contratosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ContratosTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.diasDeCobrosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.DiasDeCobrosTableAdapter();
            this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
            this.estacionesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstacionesTableAdapter();
            this.modelosUnidadesTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ModelosUnidadesTableAdapter();
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
            this.empresa_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.estacion_IDComboBox = new System.Windows.Forms.ComboBox();
            this.estacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoContrato_IDComboBox = new System.Windows.Forms.ComboBox();
            this.tiposContratosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.modeloUnidad_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getModelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelosUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.montoDiarioTextBox = new System.Windows.Forms.TextBox();
            this.diasDeCobro_IDComboBox = new System.Windows.Forms.ComboBox();
            this.diasDeCobrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fondoResidualTextBox = new System.Windows.Forms.TextBox();
            this.conductor_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getConductoresDeEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unidad_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectUnidadesDeEmpresaEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numeroEconomicoTextBox = new System.Windows.Forms.TextBox();
            this.cuenta_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getCuentasDeEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.concepto_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getConceptosDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
            this.conductorCopia_IDComboBox = new System.Windows.Forms.ComboBox();
            this.getSelectConductoresDeEstacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_EmpresasInternasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter();
            this.get_CuentasDeEmpresaTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_CuentasDeEmpresaTableAdapter();
            this.get_ConceptosDeCuentaTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ConceptosDeCuentaTableAdapter();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.get_SelectConductoresDeEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectConductoresDeEstacionTableAdapter();
            this.get_ConductoresDeEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ConductoresDeEstacionTableAdapter();
            this.get_SelectUnidadesDeEmpresaEstacionTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_SelectUnidadesDeEmpresaEstacionTableAdapter();
            this.cobroPermanenteCheckBox = new System.Windows.Forms.CheckBox();
            this.get_ModelosUnidadesTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter();
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
            comentariosLabel = new System.Windows.Forms.Label();
            conductorCopia_IDLabel = new System.Windows.Forms.Label();
            cobroPermanenteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingNavigator)).BeginInit();
            this.contratosBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConductoresDeEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectUnidadesDeEmpresaEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCuentasDeEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConceptosDeCuentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectConductoresDeEstacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contrato_IDLabel
            // 
            contrato_IDLabel.AutoSize = true;
            contrato_IDLabel.Location = new System.Drawing.Point(22, 31);
            contrato_IDLabel.Name = "contrato_IDLabel";
            contrato_IDLabel.Size = new System.Drawing.Size(71, 15);
            contrato_IDLabel.TabIndex = 1;
            contrato_IDLabel.Text = "Contrato ID:";
            // 
            // empresa_IDLabel
            // 
            empresa_IDLabel.AutoSize = true;
            empresa_IDLabel.Location = new System.Drawing.Point(22, 58);
            empresa_IDLabel.Name = "empresa_IDLabel";
            empresa_IDLabel.Size = new System.Drawing.Size(75, 15);
            empresa_IDLabel.TabIndex = 3;
            empresa_IDLabel.Text = "Empresa ID:";
            // 
            // estacion_IDLabel
            // 
            estacion_IDLabel.AutoSize = true;
            estacion_IDLabel.Location = new System.Drawing.Point(22, 87);
            estacion_IDLabel.Name = "estacion_IDLabel";
            estacion_IDLabel.Size = new System.Drawing.Size(72, 15);
            estacion_IDLabel.TabIndex = 5;
            estacion_IDLabel.Text = "Estacion ID:";
            // 
            // tipoContrato_IDLabel
            // 
            tipoContrato_IDLabel.AutoSize = true;
            tipoContrato_IDLabel.Location = new System.Drawing.Point(22, 116);
            tipoContrato_IDLabel.Name = "tipoContrato_IDLabel";
            tipoContrato_IDLabel.Size = new System.Drawing.Size(98, 15);
            tipoContrato_IDLabel.TabIndex = 7;
            tipoContrato_IDLabel.Text = "Tipo Contrato ID:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(22, 145);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(75, 15);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion:";
            // 
            // modeloUnidad_IDLabel
            // 
            modeloUnidad_IDLabel.AutoSize = true;
            modeloUnidad_IDLabel.Location = new System.Drawing.Point(22, 172);
            modeloUnidad_IDLabel.Name = "modeloUnidad_IDLabel";
            modeloUnidad_IDLabel.Size = new System.Drawing.Size(110, 15);
            modeloUnidad_IDLabel.TabIndex = 11;
            modeloUnidad_IDLabel.Text = "Modelo Unidad ID:";
            // 
            // montoDiarioLabel
            // 
            montoDiarioLabel.AutoSize = true;
            montoDiarioLabel.Location = new System.Drawing.Point(22, 201);
            montoDiarioLabel.Name = "montoDiarioLabel";
            montoDiarioLabel.Size = new System.Drawing.Size(81, 15);
            montoDiarioLabel.TabIndex = 13;
            montoDiarioLabel.Text = "Monto Diario:";
            // 
            // diasDeCobro_IDLabel
            // 
            diasDeCobro_IDLabel.AutoSize = true;
            diasDeCobro_IDLabel.Location = new System.Drawing.Point(22, 228);
            diasDeCobro_IDLabel.Name = "diasDeCobro_IDLabel";
            diasDeCobro_IDLabel.Size = new System.Drawing.Size(105, 15);
            diasDeCobro_IDLabel.TabIndex = 15;
            diasDeCobro_IDLabel.Text = "Dias De Cobro ID:";
            // 
            // fondoResidualLabel
            // 
            fondoResidualLabel.AutoSize = true;
            fondoResidualLabel.Location = new System.Drawing.Point(22, 257);
            fondoResidualLabel.Name = "fondoResidualLabel";
            fondoResidualLabel.Size = new System.Drawing.Size(97, 15);
            fondoResidualLabel.TabIndex = 17;
            fondoResidualLabel.Text = "Fondo Residual:";
            // 
            // conductor_IDLabel
            // 
            conductor_IDLabel.AutoSize = true;
            conductor_IDLabel.Location = new System.Drawing.Point(22, 284);
            conductor_IDLabel.Name = "conductor_IDLabel";
            conductor_IDLabel.Size = new System.Drawing.Size(81, 15);
            conductor_IDLabel.TabIndex = 19;
            conductor_IDLabel.Text = "Conductor ID:";
            // 
            // unidad_IDLabel
            // 
            unidad_IDLabel.AutoSize = true;
            unidad_IDLabel.Location = new System.Drawing.Point(22, 313);
            unidad_IDLabel.Name = "unidad_IDLabel";
            unidad_IDLabel.Size = new System.Drawing.Size(65, 15);
            unidad_IDLabel.TabIndex = 21;
            unidad_IDLabel.Text = "Unidad ID:";
            // 
            // numeroEconomicoLabel
            // 
            numeroEconomicoLabel.AutoSize = true;
            numeroEconomicoLabel.Location = new System.Drawing.Point(22, 342);
            numeroEconomicoLabel.Name = "numeroEconomicoLabel";
            numeroEconomicoLabel.Size = new System.Drawing.Size(120, 15);
            numeroEconomicoLabel.TabIndex = 23;
            numeroEconomicoLabel.Text = "Numero Economico:";
            // 
            // cuenta_IDLabel
            // 
            cuenta_IDLabel.AutoSize = true;
            cuenta_IDLabel.Location = new System.Drawing.Point(22, 369);
            cuenta_IDLabel.Name = "cuenta_IDLabel";
            cuenta_IDLabel.Size = new System.Drawing.Size(64, 15);
            cuenta_IDLabel.TabIndex = 25;
            cuenta_IDLabel.Text = "Cuenta ID:";
            // 
            // concepto_IDLabel
            // 
            concepto_IDLabel.AutoSize = true;
            concepto_IDLabel.Location = new System.Drawing.Point(22, 398);
            concepto_IDLabel.Name = "concepto_IDLabel";
            concepto_IDLabel.Size = new System.Drawing.Size(77, 15);
            concepto_IDLabel.TabIndex = 27;
            concepto_IDLabel.Text = "Concepto ID:";
            // 
            // fechaInicialLabel
            // 
            fechaInicialLabel.AutoSize = true;
            fechaInicialLabel.Location = new System.Drawing.Point(22, 428);
            fechaInicialLabel.Name = "fechaInicialLabel";
            fechaInicialLabel.Size = new System.Drawing.Size(79, 15);
            fechaInicialLabel.TabIndex = 29;
            fechaInicialLabel.Text = "Fecha Inicial:";
            // 
            // fechaFinalLabel
            // 
            fechaFinalLabel.AutoSize = true;
            fechaFinalLabel.Location = new System.Drawing.Point(22, 455);
            fechaFinalLabel.Name = "fechaFinalLabel";
            fechaFinalLabel.Size = new System.Drawing.Size(74, 15);
            fechaFinalLabel.TabIndex = 31;
            fechaFinalLabel.Text = "Fecha Final:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.AutoSize = true;
            comentariosLabel.Location = new System.Drawing.Point(22, 508);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(80, 15);
            comentariosLabel.TabIndex = 35;
            comentariosLabel.Text = "Comentarios:";
            // 
            // conductorCopia_IDLabel
            // 
            conductorCopia_IDLabel.AutoSize = true;
            conductorCopia_IDLabel.Location = new System.Drawing.Point(22, 563);
            conductorCopia_IDLabel.Name = "conductorCopia_IDLabel";
            conductorCopia_IDLabel.Size = new System.Drawing.Size(116, 15);
            conductorCopia_IDLabel.TabIndex = 37;
            conductorCopia_IDLabel.Text = "Conductor Copia ID:";
            // 
            // cobroPermanenteLabel
            // 
            cobroPermanenteLabel.AutoSize = true;
            cobroPermanenteLabel.Location = new System.Drawing.Point(22, 480);
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
            this.tableAdapterManager.ModelosUnidadesTableAdapter = this.modelosUnidadesTableAdapter;
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
            // estacionesTableAdapter
            // 
            this.estacionesTableAdapter.ClearBeforeFill = true;
            // 
            // modelosUnidadesTableAdapter
            // 
            this.modelosUnidadesTableAdapter.ClearBeforeFill = true;
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
            this.contrato_IDTextBox.Location = new System.Drawing.Point(148, 28);
            this.contrato_IDTextBox.Name = "contrato_IDTextBox";
            this.contrato_IDTextBox.ReadOnly = true;
            this.contrato_IDTextBox.Size = new System.Drawing.Size(125, 21);
            this.contrato_IDTextBox.TabIndex = 2;
            // 
            // empresa_IDComboBox
            // 
            this.empresa_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Empresa_ID", true));
            this.empresa_IDComboBox.DataSource = this.getEmpresasInternasBindingSource;
            this.empresa_IDComboBox.DisplayMember = "Nombre";
            this.empresa_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa_IDComboBox.FormattingEnabled = true;
            this.empresa_IDComboBox.Location = new System.Drawing.Point(148, 55);
            this.empresa_IDComboBox.Name = "empresa_IDComboBox";
            this.empresa_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.empresa_IDComboBox.TabIndex = 4;
            this.empresa_IDComboBox.ValueMember = "Empresa_ID";
            this.empresa_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.empresa_IDComboBox_SelectionChangeCommitted);
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
            this.estacion_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Estacion_ID", true));
            this.estacion_IDComboBox.DataSource = this.estacionesBindingSource;
            this.estacion_IDComboBox.DisplayMember = "Nombre";
            this.estacion_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estacion_IDComboBox.FormattingEnabled = true;
            this.estacion_IDComboBox.Location = new System.Drawing.Point(148, 84);
            this.estacion_IDComboBox.Name = "estacion_IDComboBox";
            this.estacion_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.estacion_IDComboBox.TabIndex = 6;
            this.estacion_IDComboBox.ValueMember = "Estacion_ID";
            this.estacion_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.estacion_IDComboBox_SelectionChangeCommitted);
            // 
            // estacionesBindingSource
            // 
            this.estacionesBindingSource.DataMember = "Estaciones";
            this.estacionesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // tipoContrato_IDComboBox
            // 
            this.tipoContrato_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "TipoContrato_ID", true));
            this.tipoContrato_IDComboBox.DataSource = this.tiposContratosBindingSource;
            this.tipoContrato_IDComboBox.DisplayMember = "Nombre";
            this.tipoContrato_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoContrato_IDComboBox.FormattingEnabled = true;
            this.tipoContrato_IDComboBox.Location = new System.Drawing.Point(148, 113);
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
            this.descripcionTextBox.Location = new System.Drawing.Point(148, 142);
            this.descripcionTextBox.Name = "descripcionTextBox";
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
            this.modeloUnidad_IDComboBox.Location = new System.Drawing.Point(148, 169);
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
            // modelosUnidadesBindingSource
            // 
            this.modelosUnidadesBindingSource.DataMember = "ModelosUnidades";
            this.modelosUnidadesBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // montoDiarioTextBox
            // 
            this.montoDiarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "MontoDiario", true));
            this.montoDiarioTextBox.Location = new System.Drawing.Point(148, 198);
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
            this.diasDeCobro_IDComboBox.Location = new System.Drawing.Point(148, 225);
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
            this.fondoResidualTextBox.Location = new System.Drawing.Point(148, 254);
            this.fondoResidualTextBox.Name = "fondoResidualTextBox";
            this.fondoResidualTextBox.Size = new System.Drawing.Size(125, 21);
            this.fondoResidualTextBox.TabIndex = 18;
            // 
            // conductor_IDComboBox
            // 
            this.conductor_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Conductor_ID", true));
            this.conductor_IDComboBox.DataSource = this.getConductoresDeEstacionBindingSource;
            this.conductor_IDComboBox.DisplayMember = "Nombre";
            this.conductor_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conductor_IDComboBox.FormattingEnabled = true;
            this.conductor_IDComboBox.Location = new System.Drawing.Point(148, 281);
            this.conductor_IDComboBox.Name = "conductor_IDComboBox";
            this.conductor_IDComboBox.Size = new System.Drawing.Size(363, 23);
            this.conductor_IDComboBox.TabIndex = 20;
            this.conductor_IDComboBox.ValueMember = "Conductor_ID";
            // 
            // getConductoresDeEstacionBindingSource
            // 
            this.getConductoresDeEstacionBindingSource.DataMember = "Get_ConductoresDeEstacion";
            this.getConductoresDeEstacionBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // unidad_IDComboBox
            // 
            this.unidad_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Unidad_ID", true));
            this.unidad_IDComboBox.DataSource = this.getSelectUnidadesDeEmpresaEstacionBindingSource;
            this.unidad_IDComboBox.DisplayMember = "Descripcion";
            this.unidad_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unidad_IDComboBox.FormattingEnabled = true;
            this.unidad_IDComboBox.Location = new System.Drawing.Point(148, 310);
            this.unidad_IDComboBox.Name = "unidad_IDComboBox";
            this.unidad_IDComboBox.Size = new System.Drawing.Size(278, 23);
            this.unidad_IDComboBox.TabIndex = 22;
            this.unidad_IDComboBox.ValueMember = "Unidad_ID";
            // 
            // getSelectUnidadesDeEmpresaEstacionBindingSource
            // 
            this.getSelectUnidadesDeEmpresaEstacionBindingSource.DataMember = "Get_SelectUnidadesDeEmpresaEstacion";
            this.getSelectUnidadesDeEmpresaEstacionBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // numeroEconomicoTextBox
            // 
            this.numeroEconomicoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "NumeroEconomico", true));
            this.numeroEconomicoTextBox.Location = new System.Drawing.Point(148, 339);
            this.numeroEconomicoTextBox.Name = "numeroEconomicoTextBox";
            this.numeroEconomicoTextBox.Size = new System.Drawing.Size(125, 21);
            this.numeroEconomicoTextBox.TabIndex = 24;
            // 
            // cuenta_IDComboBox
            // 
            this.cuenta_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Cuenta_ID", true));
            this.cuenta_IDComboBox.DataSource = this.getCuentasDeEmpresaBindingSource;
            this.cuenta_IDComboBox.DisplayMember = "Nombre";
            this.cuenta_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cuenta_IDComboBox.FormattingEnabled = true;
            this.cuenta_IDComboBox.Location = new System.Drawing.Point(148, 366);
            this.cuenta_IDComboBox.Name = "cuenta_IDComboBox";
            this.cuenta_IDComboBox.Size = new System.Drawing.Size(278, 23);
            this.cuenta_IDComboBox.TabIndex = 26;
            this.cuenta_IDComboBox.ValueMember = "Cuenta_ID";
            this.cuenta_IDComboBox.SelectionChangeCommitted += new System.EventHandler(this.cuenta_IDComboBox_SelectionChangeCommitted);
            // 
            // getCuentasDeEmpresaBindingSource
            // 
            this.getCuentasDeEmpresaBindingSource.DataMember = "Get_CuentasDeEmpresa";
            this.getCuentasDeEmpresaBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // concepto_IDComboBox
            // 
            this.concepto_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contratosBindingSource, "Concepto_ID", true));
            this.concepto_IDComboBox.DataSource = this.getConceptosDeCuentaBindingSource;
            this.concepto_IDComboBox.DisplayMember = "Nombre";
            this.concepto_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.concepto_IDComboBox.FormattingEnabled = true;
            this.concepto_IDComboBox.Location = new System.Drawing.Point(148, 395);
            this.concepto_IDComboBox.Name = "concepto_IDComboBox";
            this.concepto_IDComboBox.Size = new System.Drawing.Size(363, 23);
            this.concepto_IDComboBox.TabIndex = 28;
            this.concepto_IDComboBox.ValueMember = "Concepto_ID";
            // 
            // getConceptosDeCuentaBindingSource
            // 
            this.getConceptosDeCuentaBindingSource.DataMember = "Get_ConceptosDeCuenta";
            this.getConceptosDeCuentaBindingSource.DataSource = this.sICASCentralQuerysDataSet;
            // 
            // fechaInicialDateTimePicker
            // 
            this.fechaInicialDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contratosBindingSource, "FechaInicial", true));
            this.fechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicialDateTimePicker.Location = new System.Drawing.Point(148, 424);
            this.fechaInicialDateTimePicker.Name = "fechaInicialDateTimePicker";
            this.fechaInicialDateTimePicker.Size = new System.Drawing.Size(125, 21);
            this.fechaInicialDateTimePicker.TabIndex = 30;
            // 
            // fechaFinalDateTimePicker
            // 
            this.fechaFinalDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contratosBindingSource, "FechaFinal", true));
            this.fechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinalDateTimePicker.Location = new System.Drawing.Point(148, 451);
            this.fechaFinalDateTimePicker.Name = "fechaFinalDateTimePicker";
            this.fechaFinalDateTimePicker.Size = new System.Drawing.Size(125, 21);
            this.fechaFinalDateTimePicker.TabIndex = 32;
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contratosBindingSource, "Comentarios", true));
            this.comentariosTextBox.Location = new System.Drawing.Point(148, 505);
            this.comentariosTextBox.Multiline = true;
            this.comentariosTextBox.Name = "comentariosTextBox";
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
            this.conductorCopia_IDComboBox.Location = new System.Drawing.Point(148, 560);
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
            // get_EmpresasInternasTableAdapter
            // 
            this.get_EmpresasInternasTableAdapter.ClearBeforeFill = true;
            // 
            // get_CuentasDeEmpresaTableAdapter
            // 
            this.get_CuentasDeEmpresaTableAdapter.ClearBeforeFill = true;
            // 
            // get_ConceptosDeCuentaTableAdapter
            // 
            this.get_ConceptosDeCuentaTableAdapter.ClearBeforeFill = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(585, 15);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 46);
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
            // get_SelectUnidadesDeEmpresaEstacionTableAdapter
            // 
            this.get_SelectUnidadesDeEmpresaEstacionTableAdapter.ClearBeforeFill = true;
            // 
            // cobroPermanenteCheckBox
            // 
            this.cobroPermanenteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.contratosBindingSource, "CobroPermanente", true));
            this.cobroPermanenteCheckBox.Location = new System.Drawing.Point(148, 476);
            this.cobroPermanenteCheckBox.Name = "cobroPermanenteCheckBox";
            this.cobroPermanenteCheckBox.Size = new System.Drawing.Size(104, 24);
            this.cobroPermanenteCheckBox.TabIndex = 41;
            this.cobroPermanenteCheckBox.UseVisualStyleBackColor = true;
            // 
            // get_ModelosUnidadesTableAdapter
            // 
            this.get_ModelosUnidadesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(contrato_IDLabel);
            this.groupBox1.Controls.Add(cobroPermanenteLabel);
            this.groupBox1.Controls.Add(this.conductorCopia_IDComboBox);
            this.groupBox1.Controls.Add(this.cobroPermanenteCheckBox);
            this.groupBox1.Controls.Add(conductorCopia_IDLabel);
            this.groupBox1.Controls.Add(this.comentariosTextBox);
            this.groupBox1.Controls.Add(comentariosLabel);
            this.groupBox1.Controls.Add(this.contrato_IDTextBox);
            this.groupBox1.Controls.Add(empresa_IDLabel);
            this.groupBox1.Controls.Add(this.empresa_IDComboBox);
            this.groupBox1.Controls.Add(this.fechaFinalDateTimePicker);
            this.groupBox1.Controls.Add(estacion_IDLabel);
            this.groupBox1.Controls.Add(fechaFinalLabel);
            this.groupBox1.Controls.Add(this.estacion_IDComboBox);
            this.groupBox1.Controls.Add(this.fechaInicialDateTimePicker);
            this.groupBox1.Controls.Add(tipoContrato_IDLabel);
            this.groupBox1.Controls.Add(fechaInicialLabel);
            this.groupBox1.Controls.Add(this.tipoContrato_IDComboBox);
            this.groupBox1.Controls.Add(this.concepto_IDComboBox);
            this.groupBox1.Controls.Add(descripcionLabel);
            this.groupBox1.Controls.Add(concepto_IDLabel);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Controls.Add(this.cuenta_IDComboBox);
            this.groupBox1.Controls.Add(modeloUnidad_IDLabel);
            this.groupBox1.Controls.Add(cuenta_IDLabel);
            this.groupBox1.Controls.Add(this.modeloUnidad_IDComboBox);
            this.groupBox1.Controls.Add(this.numeroEconomicoTextBox);
            this.groupBox1.Controls.Add(montoDiarioLabel);
            this.groupBox1.Controls.Add(numeroEconomicoLabel);
            this.groupBox1.Controls.Add(this.montoDiarioTextBox);
            this.groupBox1.Controls.Add(this.unidad_IDComboBox);
            this.groupBox1.Controls.Add(diasDeCobro_IDLabel);
            this.groupBox1.Controls.Add(unidad_IDLabel);
            this.groupBox1.Controls.Add(this.diasDeCobro_IDComboBox);
            this.groupBox1.Controls.Add(this.conductor_IDComboBox);
            this.groupBox1.Controls.Add(fondoResidualLabel);
            this.groupBox1.Controls.Add(conductor_IDLabel);
            this.groupBox1.Controls.Add(this.fondoResidualTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 603);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de contrato";
            // 
            // AltaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.contratosBindingNavigator);
            this.Name = "AltaContrato";
            this.Text = "AltaContrato";            
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratosBindingNavigator)).EndInit();
            this.contratosBindingNavigator.ResumeLayout(false);
            this.contratosBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposContratosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getModelosUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelosUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasDeCobrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConductoresDeEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectUnidadesDeEmpresaEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCuentasDeEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getConceptosDeCuentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSelectConductoresDeEstacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
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
        private System.Windows.Forms.ComboBox empresa_IDComboBox;
        private System.Windows.Forms.ComboBox estacion_IDComboBox;
        private System.Windows.Forms.ComboBox tipoContrato_IDComboBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.ComboBox modeloUnidad_IDComboBox;
        private System.Windows.Forms.TextBox montoDiarioTextBox;
        private System.Windows.Forms.ComboBox diasDeCobro_IDComboBox;
        private System.Windows.Forms.TextBox fondoResidualTextBox;
        private System.Windows.Forms.ComboBox conductor_IDComboBox;
        private System.Windows.Forms.ComboBox unidad_IDComboBox;
        private System.Windows.Forms.TextBox numeroEconomicoTextBox;
        private System.Windows.Forms.ComboBox cuenta_IDComboBox;
        private System.Windows.Forms.ComboBox concepto_IDComboBox;
        private System.Windows.Forms.DateTimePicker fechaInicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaFinalDateTimePicker;
        private System.Windows.Forms.TextBox comentariosTextBox;
        private System.Windows.Forms.ComboBox conductorCopia_IDComboBox;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource getEmpresasInternasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter get_EmpresasInternasTableAdapter;
        private SICASCentralDataSetTableAdapters.EstacionesTableAdapter estacionesTableAdapter;
        private System.Windows.Forms.BindingSource estacionesBindingSource;
        private SICASCentralDataSetTableAdapters.TiposContratosTableAdapter tiposContratosTableAdapter;
        private System.Windows.Forms.BindingSource tiposContratosBindingSource;
        private SICASCentralDataSetTableAdapters.ModelosUnidadesTableAdapter modelosUnidadesTableAdapter;
        private System.Windows.Forms.BindingSource modelosUnidadesBindingSource;
        private SICASCentralDataSetTableAdapters.DiasDeCobrosTableAdapter diasDeCobrosTableAdapter;
        private System.Windows.Forms.BindingSource diasDeCobrosBindingSource;
        private System.Windows.Forms.BindingSource getCuentasDeEmpresaBindingSource;
        private System.Windows.Forms.BindingSource getConceptosDeCuentaBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_CuentasDeEmpresaTableAdapter get_CuentasDeEmpresaTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.Get_ConceptosDeCuentaTableAdapter get_ConceptosDeCuentaTableAdapter;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.BindingSource getConductoresDeEstacionBindingSource;
        private System.Windows.Forms.BindingSource getSelectConductoresDeEstacionBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectConductoresDeEstacionTableAdapter get_SelectConductoresDeEstacionTableAdapter;
        private SICASCentralQuerysDataSetTableAdapters.Get_ConductoresDeEstacionTableAdapter get_ConductoresDeEstacionTableAdapter;
        private System.Windows.Forms.BindingSource getSelectUnidadesDeEmpresaEstacionBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_SelectUnidadesDeEmpresaEstacionTableAdapter get_SelectUnidadesDeEmpresaEstacionTableAdapter;
        private System.Windows.Forms.CheckBox cobroPermanenteCheckBox;
        private System.Windows.Forms.BindingSource getModelosUnidadesBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_ModelosUnidadesTableAdapter get_ModelosUnidadesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}