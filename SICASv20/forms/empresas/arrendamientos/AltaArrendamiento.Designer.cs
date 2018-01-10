namespace SICASv20.forms
{
    partial class AltaArrendamiento
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
            System.Windows.Forms.Label arrendamiento_IDLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label referenciaLabel;
            System.Windows.Forms.Label catalogoReferenciaLabel;
            System.Windows.Forms.Label arrendador_IDLabel;
            System.Windows.Forms.Label arrendatario_IDLabel;
            System.Windows.Forms.Label montoAFinanciarLabel;
            System.Windows.Forms.Label valorFacturaLabel;
            System.Windows.Forms.Label plazosLabel;
            System.Windows.Forms.Label mensualidadLabel;
            System.Windows.Forms.Label residualLabel;
            System.Windows.Forms.Label tasaLabel;
            System.Windows.Forms.Label amortizacionResidualLabel;
            System.Windows.Forms.Label estatusFinanciero_IDLabel;
            System.Windows.Forms.Label montoPagadoLabel;
            System.Windows.Forms.Label saldoLabel;
            System.Windows.Forms.Label plazosRestantesLabel;
            System.Windows.Forms.Label fechaInicialLabel;
            System.Windows.Forms.Label fechaFinalLabel;
            System.Windows.Forms.Label ultimaFechaLabel;
            System.Windows.Forms.Label proximaFechaLabel;
            System.Windows.Forms.Label activoLabel;
            System.Windows.Forms.Label comentariosLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaArrendamiento));
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.arrendamientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.arrendamientosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.ArrendamientosTableAdapter();
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
            this.estatusFinancierosTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EstatusFinancierosTableAdapter();
            this.arrendamientosBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.arrendamientosBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getEmpresasInternasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralQuerysDataSet = new SICASv20.SICASCentralQuerysDataSet();
            this.estatusFinancierosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_EmpresasInternasTableAdapter = new SICASv20.SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.PlazosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.arrendamiento_IDTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.referenciaTextBox = new System.Windows.Forms.TextBox();
            this.catalogoReferenciaTextBox = new System.Windows.Forms.TextBox();
            this.arrendador_IDComboBox = new System.Windows.Forms.ComboBox();
            this.arrendatario_IDComboBox = new System.Windows.Forms.ComboBox();
            this.montoAFinanciarTextBox = new System.Windows.Forms.TextBox();
            this.valorFacturaTextBox = new System.Windows.Forms.TextBox();
            this.mensualidadTextBox = new System.Windows.Forms.TextBox();
            this.residualTextBox = new System.Windows.Forms.TextBox();
            this.tasaTextBox = new System.Windows.Forms.TextBox();
            this.amortizacionResidualTextBox = new System.Windows.Forms.TextBox();
            this.estatusFinanciero_IDComboBox = new System.Windows.Forms.ComboBox();
            this.montoPagadoTextBox = new System.Windows.Forms.TextBox();
            this.saldoTextBox = new System.Windows.Forms.TextBox();
            this.plazosRestantesTextBox = new System.Windows.Forms.TextBox();
            this.fechaInicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ultimaFechaTextBox = new System.Windows.Forms.TextBox();
            this.proximaFechaTextBox = new System.Windows.Forms.TextBox();
            this.activoCheckBox = new System.Windows.Forms.CheckBox();
            this.comentariosTextBox = new System.Windows.Forms.TextBox();
            arrendamiento_IDLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            referenciaLabel = new System.Windows.Forms.Label();
            catalogoReferenciaLabel = new System.Windows.Forms.Label();
            arrendador_IDLabel = new System.Windows.Forms.Label();
            arrendatario_IDLabel = new System.Windows.Forms.Label();
            montoAFinanciarLabel = new System.Windows.Forms.Label();
            valorFacturaLabel = new System.Windows.Forms.Label();
            plazosLabel = new System.Windows.Forms.Label();
            mensualidadLabel = new System.Windows.Forms.Label();
            residualLabel = new System.Windows.Forms.Label();
            tasaLabel = new System.Windows.Forms.Label();
            amortizacionResidualLabel = new System.Windows.Forms.Label();
            estatusFinanciero_IDLabel = new System.Windows.Forms.Label();
            montoPagadoLabel = new System.Windows.Forms.Label();
            saldoLabel = new System.Windows.Forms.Label();
            plazosRestantesLabel = new System.Windows.Forms.Label();
            fechaInicialLabel = new System.Windows.Forms.Label();
            fechaFinalLabel = new System.Windows.Forms.Label();
            ultimaFechaLabel = new System.Windows.Forms.Label();
            proximaFechaLabel = new System.Windows.Forms.Label();
            activoLabel = new System.Windows.Forms.Label();
            comentariosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrendamientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrendamientosBindingNavigator)).BeginInit();
            this.arrendamientosBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusFinancierosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlazosNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // arrendamiento_IDLabel
            // 
            arrendamiento_IDLabel.AutoSize = true;
            arrendamiento_IDLabel.Location = new System.Drawing.Point(32, 34);
            arrendamiento_IDLabel.Name = "arrendamiento_IDLabel";
            arrendamiento_IDLabel.Size = new System.Drawing.Size(106, 15);
            arrendamiento_IDLabel.TabIndex = 49;
            arrendamiento_IDLabel.Text = "Arrendamiento ID:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(32, 61);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(75, 15);
            descripcionLabel.TabIndex = 51;
            descripcionLabel.Text = "Descripcion:";
            // 
            // referenciaLabel
            // 
            referenciaLabel.AutoSize = true;
            referenciaLabel.Location = new System.Drawing.Point(32, 88);
            referenciaLabel.Name = "referenciaLabel";
            referenciaLabel.Size = new System.Drawing.Size(70, 15);
            referenciaLabel.TabIndex = 53;
            referenciaLabel.Text = "Referencia:";
            // 
            // catalogoReferenciaLabel
            // 
            catalogoReferenciaLabel.AutoSize = true;
            catalogoReferenciaLabel.Location = new System.Drawing.Point(32, 115);
            catalogoReferenciaLabel.Name = "catalogoReferenciaLabel";
            catalogoReferenciaLabel.Size = new System.Drawing.Size(122, 15);
            catalogoReferenciaLabel.TabIndex = 55;
            catalogoReferenciaLabel.Text = "Catalogo Referencia:";
            // 
            // arrendador_IDLabel
            // 
            arrendador_IDLabel.AutoSize = true;
            arrendador_IDLabel.Location = new System.Drawing.Point(32, 142);
            arrendador_IDLabel.Name = "arrendador_IDLabel";
            arrendador_IDLabel.Size = new System.Drawing.Size(86, 15);
            arrendador_IDLabel.TabIndex = 57;
            arrendador_IDLabel.Text = "Arrendador ID:";
            // 
            // arrendatario_IDLabel
            // 
            arrendatario_IDLabel.AutoSize = true;
            arrendatario_IDLabel.Location = new System.Drawing.Point(32, 171);
            arrendatario_IDLabel.Name = "arrendatario_IDLabel";
            arrendatario_IDLabel.Size = new System.Drawing.Size(92, 15);
            arrendatario_IDLabel.TabIndex = 59;
            arrendatario_IDLabel.Text = "Arrendatario ID:";
            // 
            // montoAFinanciarLabel
            // 
            montoAFinanciarLabel.AutoSize = true;
            montoAFinanciarLabel.Location = new System.Drawing.Point(32, 362);
            montoAFinanciarLabel.Name = "montoAFinanciarLabel";
            montoAFinanciarLabel.Size = new System.Drawing.Size(109, 15);
            montoAFinanciarLabel.TabIndex = 61;
            montoAFinanciarLabel.Text = "Monto A Financiar:";
            // 
            // valorFacturaLabel
            // 
            valorFacturaLabel.AutoSize = true;
            valorFacturaLabel.Location = new System.Drawing.Point(32, 200);
            valorFacturaLabel.Name = "valorFacturaLabel";
            valorFacturaLabel.Size = new System.Drawing.Size(82, 15);
            valorFacturaLabel.TabIndex = 63;
            valorFacturaLabel.Text = "Valor Factura:";
            // 
            // plazosLabel
            // 
            plazosLabel.AutoSize = true;
            plazosLabel.Location = new System.Drawing.Point(32, 227);
            plazosLabel.Name = "plazosLabel";
            plazosLabel.Size = new System.Drawing.Size(47, 15);
            plazosLabel.TabIndex = 65;
            plazosLabel.Text = "Plazos:";
            // 
            // mensualidadLabel
            // 
            mensualidadLabel.AutoSize = true;
            mensualidadLabel.Location = new System.Drawing.Point(32, 254);
            mensualidadLabel.Name = "mensualidadLabel";
            mensualidadLabel.Size = new System.Drawing.Size(82, 15);
            mensualidadLabel.TabIndex = 66;
            mensualidadLabel.Text = "Mensualidad:";
            // 
            // residualLabel
            // 
            residualLabel.AutoSize = true;
            residualLabel.Location = new System.Drawing.Point(32, 281);
            residualLabel.Name = "residualLabel";
            residualLabel.Size = new System.Drawing.Size(59, 15);
            residualLabel.TabIndex = 68;
            residualLabel.Text = "Residual:";
            // 
            // tasaLabel
            // 
            tasaLabel.AutoSize = true;
            tasaLabel.Location = new System.Drawing.Point(32, 308);
            tasaLabel.Name = "tasaLabel";
            tasaLabel.Size = new System.Drawing.Size(37, 15);
            tasaLabel.TabIndex = 70;
            tasaLabel.Text = "Tasa:";
            // 
            // amortizacionResidualLabel
            // 
            amortizacionResidualLabel.AutoSize = true;
            amortizacionResidualLabel.Location = new System.Drawing.Point(32, 335);
            amortizacionResidualLabel.Name = "amortizacionResidualLabel";
            amortizacionResidualLabel.Size = new System.Drawing.Size(133, 15);
            amortizacionResidualLabel.TabIndex = 72;
            amortizacionResidualLabel.Text = "Amortizacion Residual:";
            // 
            // estatusFinanciero_IDLabel
            // 
            estatusFinanciero_IDLabel.AutoSize = true;
            estatusFinanciero_IDLabel.Location = new System.Drawing.Point(32, 389);
            estatusFinanciero_IDLabel.Name = "estatusFinanciero_IDLabel";
            estatusFinanciero_IDLabel.Size = new System.Drawing.Size(126, 15);
            estatusFinanciero_IDLabel.TabIndex = 74;
            estatusFinanciero_IDLabel.Text = "Estatus Financiero ID:";
            // 
            // montoPagadoLabel
            // 
            montoPagadoLabel.AutoSize = true;
            montoPagadoLabel.Location = new System.Drawing.Point(32, 418);
            montoPagadoLabel.Name = "montoPagadoLabel";
            montoPagadoLabel.Size = new System.Drawing.Size(91, 15);
            montoPagadoLabel.TabIndex = 76;
            montoPagadoLabel.Text = "Monto Pagado:";
            // 
            // saldoLabel
            // 
            saldoLabel.AutoSize = true;
            saldoLabel.Location = new System.Drawing.Point(32, 445);
            saldoLabel.Name = "saldoLabel";
            saldoLabel.Size = new System.Drawing.Size(42, 15);
            saldoLabel.TabIndex = 78;
            saldoLabel.Text = "Saldo:";
            // 
            // plazosRestantesLabel
            // 
            plazosRestantesLabel.AutoSize = true;
            plazosRestantesLabel.Location = new System.Drawing.Point(32, 472);
            plazosRestantesLabel.Name = "plazosRestantesLabel";
            plazosRestantesLabel.Size = new System.Drawing.Size(105, 15);
            plazosRestantesLabel.TabIndex = 80;
            plazosRestantesLabel.Text = "Plazos Restantes:";
            // 
            // fechaInicialLabel
            // 
            fechaInicialLabel.AutoSize = true;
            fechaInicialLabel.Location = new System.Drawing.Point(440, 35);
            fechaInicialLabel.Name = "fechaInicialLabel";
            fechaInicialLabel.Size = new System.Drawing.Size(79, 15);
            fechaInicialLabel.TabIndex = 82;
            fechaInicialLabel.Text = "Fecha Inicial:";
            // 
            // fechaFinalLabel
            // 
            fechaFinalLabel.AutoSize = true;
            fechaFinalLabel.Location = new System.Drawing.Point(440, 62);
            fechaFinalLabel.Name = "fechaFinalLabel";
            fechaFinalLabel.Size = new System.Drawing.Size(74, 15);
            fechaFinalLabel.TabIndex = 84;
            fechaFinalLabel.Text = "Fecha Final:";
            // 
            // ultimaFechaLabel
            // 
            ultimaFechaLabel.AutoSize = true;
            ultimaFechaLabel.Location = new System.Drawing.Point(440, 88);
            ultimaFechaLabel.Name = "ultimaFechaLabel";
            ultimaFechaLabel.Size = new System.Drawing.Size(83, 15);
            ultimaFechaLabel.TabIndex = 86;
            ultimaFechaLabel.Text = "Ultima Fecha:";
            // 
            // proximaFechaLabel
            // 
            proximaFechaLabel.AutoSize = true;
            proximaFechaLabel.Location = new System.Drawing.Point(440, 115);
            proximaFechaLabel.Name = "proximaFechaLabel";
            proximaFechaLabel.Size = new System.Drawing.Size(93, 15);
            proximaFechaLabel.TabIndex = 88;
            proximaFechaLabel.Text = "Proxima Fecha:";
            // 
            // activoLabel
            // 
            activoLabel.AutoSize = true;
            activoLabel.Location = new System.Drawing.Point(440, 144);
            activoLabel.Name = "activoLabel";
            activoLabel.Size = new System.Drawing.Size(41, 15);
            activoLabel.TabIndex = 90;
            activoLabel.Text = "Activo:";
            // 
            // comentariosLabel
            // 
            comentariosLabel.AutoSize = true;
            comentariosLabel.Location = new System.Drawing.Point(440, 172);
            comentariosLabel.Name = "comentariosLabel";
            comentariosLabel.Size = new System.Drawing.Size(80, 15);
            comentariosLabel.TabIndex = 92;
            comentariosLabel.Text = "Comentarios:";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // arrendamientosBindingSource
            // 
            this.arrendamientosBindingSource.DataMember = "Arrendamientos";
            this.arrendamientosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // arrendamientosTableAdapter
            // 
            this.arrendamientosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArrendamientosTableAdapter = this.arrendamientosTableAdapter;
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
            this.tableAdapterManager.EmpresasTableAdapter = this.empresasTableAdapter;
            this.tableAdapterManager.EstacionesTableAdapter = null;
            this.tableAdapterManager.EstatusConductoresTableAdapter = null;
            this.tableAdapterManager.EstatusContratosTableAdapter = null;
            this.tableAdapterManager.EstatusFinancierosTableAdapter = this.estatusFinancierosTableAdapter;
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
            // empresasTableAdapter
            // 
            this.empresasTableAdapter.ClearBeforeFill = true;
            // 
            // estatusFinancierosTableAdapter
            // 
            this.estatusFinancierosTableAdapter.ClearBeforeFill = true;
            // 
            // arrendamientosBindingNavigator
            // 
            this.arrendamientosBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.arrendamientosBindingNavigator.BindingSource = this.arrendamientosBindingSource;
            this.arrendamientosBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.arrendamientosBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.arrendamientosBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.arrendamientosBindingNavigatorSaveItem});
            this.arrendamientosBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.arrendamientosBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.arrendamientosBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.arrendamientosBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.arrendamientosBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.arrendamientosBindingNavigator.Name = "arrendamientosBindingNavigator";
            this.arrendamientosBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.arrendamientosBindingNavigator.Size = new System.Drawing.Size(1024, 25);
            this.arrendamientosBindingNavigator.TabIndex = 0;
            this.arrendamientosBindingNavigator.Text = "bindingNavigator1";
            this.arrendamientosBindingNavigator.Visible = false;
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
            // arrendamientosBindingNavigatorSaveItem
            // 
            this.arrendamientosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arrendamientosBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("arrendamientosBindingNavigatorSaveItem.Image")));
            this.arrendamientosBindingNavigatorSaveItem.Name = "arrendamientosBindingNavigatorSaveItem";
            this.arrendamientosBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.arrendamientosBindingNavigatorSaveItem.Text = "Save Data";            
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "Empresas";
            this.empresasBindingSource.DataSource = this.sICASCentralDataSet;
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
            // estatusFinancierosBindingSource
            // 
            this.estatusFinancierosBindingSource.DataMember = "EstatusFinancieros";
            this.estatusFinancierosBindingSource.DataSource = this.sICASCentralDataSet;
            // 
            // get_EmpresasInternasTableAdapter
            // 
            this.get_EmpresasInternasTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(this.PlazosNumericUpDown);
            this.groupBox1.Controls.Add(arrendamiento_IDLabel);
            this.groupBox1.Controls.Add(this.arrendamiento_IDTextBox);
            this.groupBox1.Controls.Add(descripcionLabel);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Controls.Add(referenciaLabel);
            this.groupBox1.Controls.Add(this.referenciaTextBox);
            this.groupBox1.Controls.Add(catalogoReferenciaLabel);
            this.groupBox1.Controls.Add(this.catalogoReferenciaTextBox);
            this.groupBox1.Controls.Add(arrendador_IDLabel);
            this.groupBox1.Controls.Add(this.arrendador_IDComboBox);
            this.groupBox1.Controls.Add(arrendatario_IDLabel);
            this.groupBox1.Controls.Add(this.arrendatario_IDComboBox);
            this.groupBox1.Controls.Add(montoAFinanciarLabel);
            this.groupBox1.Controls.Add(this.montoAFinanciarTextBox);
            this.groupBox1.Controls.Add(valorFacturaLabel);
            this.groupBox1.Controls.Add(this.valorFacturaTextBox);
            this.groupBox1.Controls.Add(plazosLabel);
            this.groupBox1.Controls.Add(mensualidadLabel);
            this.groupBox1.Controls.Add(this.mensualidadTextBox);
            this.groupBox1.Controls.Add(residualLabel);
            this.groupBox1.Controls.Add(this.residualTextBox);
            this.groupBox1.Controls.Add(tasaLabel);
            this.groupBox1.Controls.Add(this.tasaTextBox);
            this.groupBox1.Controls.Add(amortizacionResidualLabel);
            this.groupBox1.Controls.Add(this.amortizacionResidualTextBox);
            this.groupBox1.Controls.Add(estatusFinanciero_IDLabel);
            this.groupBox1.Controls.Add(this.estatusFinanciero_IDComboBox);
            this.groupBox1.Controls.Add(montoPagadoLabel);
            this.groupBox1.Controls.Add(this.montoPagadoTextBox);
            this.groupBox1.Controls.Add(saldoLabel);
            this.groupBox1.Controls.Add(this.saldoTextBox);
            this.groupBox1.Controls.Add(plazosRestantesLabel);
            this.groupBox1.Controls.Add(this.plazosRestantesTextBox);
            this.groupBox1.Controls.Add(fechaInicialLabel);
            this.groupBox1.Controls.Add(this.fechaInicialDateTimePicker);
            this.groupBox1.Controls.Add(fechaFinalLabel);
            this.groupBox1.Controls.Add(this.fechaFinalDateTimePicker);
            this.groupBox1.Controls.Add(ultimaFechaLabel);
            this.groupBox1.Controls.Add(this.ultimaFechaTextBox);
            this.groupBox1.Controls.Add(proximaFechaLabel);
            this.groupBox1.Controls.Add(this.proximaFechaTextBox);
            this.groupBox1.Controls.Add(activoLabel);
            this.groupBox1.Controls.Add(this.activoCheckBox);
            this.groupBox1.Controls.Add(comentariosLabel);
            this.groupBox1.Controls.Add(this.comentariosTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 514);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Arrendamiento";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(704, 246);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 95;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // PlazosNumericUpDown
            // 
            this.PlazosNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.arrendamientosBindingSource, "Plazos", true));
            this.PlazosNumericUpDown.Location = new System.Drawing.Point(171, 225);
            this.PlazosNumericUpDown.Name = "PlazosNumericUpDown";
            this.PlazosNumericUpDown.Size = new System.Drawing.Size(66, 21);
            this.PlazosNumericUpDown.TabIndex = 7;
            this.PlazosNumericUpDown.ValueChanged += new System.EventHandler(this.PlazosNumericUpDown_ValueChanged);
            // 
            // arrendamiento_IDTextBox
            // 
            this.arrendamiento_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Arrendamiento_ID", true));
            this.arrendamiento_IDTextBox.Location = new System.Drawing.Point(171, 31);
            this.arrendamiento_IDTextBox.Name = "arrendamiento_IDTextBox";
            this.arrendamiento_IDTextBox.Size = new System.Drawing.Size(104, 21);
            this.arrendamiento_IDTextBox.TabIndex = 0;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(171, 58);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(200, 21);
            this.descripcionTextBox.TabIndex = 1;
            // 
            // referenciaTextBox
            // 
            this.referenciaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.referenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Referencia", true));
            this.referenciaTextBox.Location = new System.Drawing.Point(171, 85);
            this.referenciaTextBox.Name = "referenciaTextBox";
            this.referenciaTextBox.Size = new System.Drawing.Size(132, 21);
            this.referenciaTextBox.TabIndex = 2;
            // 
            // catalogoReferenciaTextBox
            // 
            this.catalogoReferenciaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.catalogoReferenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "CatalogoReferencia", true));
            this.catalogoReferenciaTextBox.Location = new System.Drawing.Point(171, 112);
            this.catalogoReferenciaTextBox.Name = "catalogoReferenciaTextBox";
            this.catalogoReferenciaTextBox.Size = new System.Drawing.Size(132, 21);
            this.catalogoReferenciaTextBox.TabIndex = 3;
            // 
            // arrendador_IDComboBox
            // 
            this.arrendador_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.arrendamientosBindingSource, "Arrendador_ID", true));
            this.arrendador_IDComboBox.DataSource = this.empresasBindingSource;
            this.arrendador_IDComboBox.DisplayMember = "Nombre";
            this.arrendador_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arrendador_IDComboBox.FormattingEnabled = true;
            this.arrendador_IDComboBox.Location = new System.Drawing.Point(171, 139);
            this.arrendador_IDComboBox.Name = "arrendador_IDComboBox";
            this.arrendador_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.arrendador_IDComboBox.TabIndex = 4;
            this.arrendador_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // arrendatario_IDComboBox
            // 
            this.arrendatario_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.arrendamientosBindingSource, "Arrendatario_ID", true));
            this.arrendatario_IDComboBox.DataSource = this.getEmpresasInternasBindingSource;
            this.arrendatario_IDComboBox.DisplayMember = "Nombre";
            this.arrendatario_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.arrendatario_IDComboBox.FormattingEnabled = true;
            this.arrendatario_IDComboBox.Location = new System.Drawing.Point(171, 168);
            this.arrendatario_IDComboBox.Name = "arrendatario_IDComboBox";
            this.arrendatario_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.arrendatario_IDComboBox.TabIndex = 5;
            this.arrendatario_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // montoAFinanciarTextBox
            // 
            this.montoAFinanciarTextBox.BackColor = System.Drawing.Color.White;
            this.montoAFinanciarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "MontoAFinanciar", true));
            this.montoAFinanciarTextBox.Location = new System.Drawing.Point(171, 359);
            this.montoAFinanciarTextBox.Name = "montoAFinanciarTextBox";
            this.montoAFinanciarTextBox.ReadOnly = true;
            this.montoAFinanciarTextBox.Size = new System.Drawing.Size(132, 21);
            this.montoAFinanciarTextBox.TabIndex = 12;
            this.montoAFinanciarTextBox.TextChanged += new System.EventHandler(this.montoAFinanciarTextBox_TextChanged);
            // 
            // valorFacturaTextBox
            // 
            this.valorFacturaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "ValorFactura", true));
            this.valorFacturaTextBox.Location = new System.Drawing.Point(171, 197);
            this.valorFacturaTextBox.Name = "valorFacturaTextBox";
            this.valorFacturaTextBox.Size = new System.Drawing.Size(132, 21);
            this.valorFacturaTextBox.TabIndex = 6;
            // 
            // mensualidadTextBox
            // 
            this.mensualidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Mensualidad", true));
            this.mensualidadTextBox.Location = new System.Drawing.Point(171, 251);
            this.mensualidadTextBox.Name = "mensualidadTextBox";
            this.mensualidadTextBox.Size = new System.Drawing.Size(132, 21);
            this.mensualidadTextBox.TabIndex = 8;
            this.mensualidadTextBox.TextChanged += new System.EventHandler(this.montoAFinanciarTextBox_TextChanged);
            // 
            // residualTextBox
            // 
            this.residualTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Residual", true));
            this.residualTextBox.Location = new System.Drawing.Point(171, 278);
            this.residualTextBox.Name = "residualTextBox";
            this.residualTextBox.Size = new System.Drawing.Size(132, 21);
            this.residualTextBox.TabIndex = 9;
            this.residualTextBox.TextChanged += new System.EventHandler(this.montoAFinanciarTextBox_TextChanged);
            // 
            // tasaTextBox
            // 
            this.tasaTextBox.BackColor = System.Drawing.Color.White;
            this.tasaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Tasa", true));
            this.tasaTextBox.Location = new System.Drawing.Point(171, 305);
            this.tasaTextBox.Name = "tasaTextBox";
            this.tasaTextBox.ReadOnly = true;
            this.tasaTextBox.Size = new System.Drawing.Size(132, 21);
            this.tasaTextBox.TabIndex = 10;
            this.tasaTextBox.TextChanged += new System.EventHandler(this.montoAFinanciarTextBox_TextChanged);
            // 
            // amortizacionResidualTextBox
            // 
            this.amortizacionResidualTextBox.BackColor = System.Drawing.Color.White;
            this.amortizacionResidualTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "AmortizacionResidual", true));
            this.amortizacionResidualTextBox.Location = new System.Drawing.Point(171, 332);
            this.amortizacionResidualTextBox.Name = "amortizacionResidualTextBox";
            this.amortizacionResidualTextBox.ReadOnly = true;
            this.amortizacionResidualTextBox.Size = new System.Drawing.Size(132, 21);
            this.amortizacionResidualTextBox.TabIndex = 11;
            this.amortizacionResidualTextBox.TextChanged += new System.EventHandler(this.montoAFinanciarTextBox_TextChanged);
            // 
            // estatusFinanciero_IDComboBox
            // 
            this.estatusFinanciero_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.arrendamientosBindingSource, "EstatusFinanciero_ID", true));
            this.estatusFinanciero_IDComboBox.DataSource = this.estatusFinancierosBindingSource;
            this.estatusFinanciero_IDComboBox.DisplayMember = "Nombre";
            this.estatusFinanciero_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estatusFinanciero_IDComboBox.FormattingEnabled = true;
            this.estatusFinanciero_IDComboBox.Location = new System.Drawing.Point(171, 386);
            this.estatusFinanciero_IDComboBox.Name = "estatusFinanciero_IDComboBox";
            this.estatusFinanciero_IDComboBox.Size = new System.Drawing.Size(200, 23);
            this.estatusFinanciero_IDComboBox.TabIndex = 13;
            this.estatusFinanciero_IDComboBox.ValueMember = "EstatusFinanciero_ID";
            // 
            // montoPagadoTextBox
            // 
            this.montoPagadoTextBox.BackColor = System.Drawing.Color.White;
            this.montoPagadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "MontoPagado", true));
            this.montoPagadoTextBox.Location = new System.Drawing.Point(171, 415);
            this.montoPagadoTextBox.Name = "montoPagadoTextBox";
            this.montoPagadoTextBox.ReadOnly = true;
            this.montoPagadoTextBox.Size = new System.Drawing.Size(132, 21);
            this.montoPagadoTextBox.TabIndex = 14;
            // 
            // saldoTextBox
            // 
            this.saldoTextBox.BackColor = System.Drawing.Color.White;
            this.saldoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Saldo", true));
            this.saldoTextBox.Location = new System.Drawing.Point(171, 442);
            this.saldoTextBox.Name = "saldoTextBox";
            this.saldoTextBox.ReadOnly = true;
            this.saldoTextBox.Size = new System.Drawing.Size(132, 21);
            this.saldoTextBox.TabIndex = 15;
            // 
            // plazosRestantesTextBox
            // 
            this.plazosRestantesTextBox.BackColor = System.Drawing.Color.White;
            this.plazosRestantesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "PlazosRestantes", true));
            this.plazosRestantesTextBox.Location = new System.Drawing.Point(171, 469);
            this.plazosRestantesTextBox.Name = "plazosRestantesTextBox";
            this.plazosRestantesTextBox.ReadOnly = true;
            this.plazosRestantesTextBox.Size = new System.Drawing.Size(132, 21);
            this.plazosRestantesTextBox.TabIndex = 16;
            // 
            // fechaInicialDateTimePicker
            // 
            this.fechaInicialDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.arrendamientosBindingSource, "FechaInicial", true));
            this.fechaInicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicialDateTimePicker.Location = new System.Drawing.Point(579, 31);
            this.fechaInicialDateTimePicker.Name = "fechaInicialDateTimePicker";
            this.fechaInicialDateTimePicker.Size = new System.Drawing.Size(132, 21);
            this.fechaInicialDateTimePicker.TabIndex = 17;
            this.fechaInicialDateTimePicker.ValueChanged += new System.EventHandler(this.fechaInicialDateTimePicker_ValueChanged);
            // 
            // fechaFinalDateTimePicker
            // 
            this.fechaFinalDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.arrendamientosBindingSource, "FechaFinal", true));
            this.fechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinalDateTimePicker.Location = new System.Drawing.Point(579, 58);
            this.fechaFinalDateTimePicker.Name = "fechaFinalDateTimePicker";
            this.fechaFinalDateTimePicker.Size = new System.Drawing.Size(132, 21);
            this.fechaFinalDateTimePicker.TabIndex = 18;
            // 
            // ultimaFechaTextBox
            // 
            this.ultimaFechaTextBox.BackColor = System.Drawing.Color.White;
            this.ultimaFechaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "UltimaFecha", true));
            this.ultimaFechaTextBox.Location = new System.Drawing.Point(579, 85);
            this.ultimaFechaTextBox.Name = "ultimaFechaTextBox";
            this.ultimaFechaTextBox.ReadOnly = true;
            this.ultimaFechaTextBox.Size = new System.Drawing.Size(132, 21);
            this.ultimaFechaTextBox.TabIndex = 19;
            // 
            // proximaFechaTextBox
            // 
            this.proximaFechaTextBox.BackColor = System.Drawing.Color.White;
            this.proximaFechaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "ProximaFecha", true));
            this.proximaFechaTextBox.Location = new System.Drawing.Point(579, 112);
            this.proximaFechaTextBox.Name = "proximaFechaTextBox";
            this.proximaFechaTextBox.ReadOnly = true;
            this.proximaFechaTextBox.Size = new System.Drawing.Size(132, 21);
            this.proximaFechaTextBox.TabIndex = 20;
            // 
            // activoCheckBox
            // 
            this.activoCheckBox.Checked = true;
            this.activoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.arrendamientosBindingSource, "Activo", true));
            this.activoCheckBox.Location = new System.Drawing.Point(579, 139);
            this.activoCheckBox.Name = "activoCheckBox";
            this.activoCheckBox.Size = new System.Drawing.Size(200, 24);
            this.activoCheckBox.TabIndex = 21;
            this.activoCheckBox.UseVisualStyleBackColor = true;
            // 
            // comentariosTextBox
            // 
            this.comentariosTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.comentariosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.arrendamientosBindingSource, "Comentarios", true));
            this.comentariosTextBox.Location = new System.Drawing.Point(579, 172);
            this.comentariosTextBox.Multiline = true;
            this.comentariosTextBox.Name = "comentariosTextBox";
            this.comentariosTextBox.Size = new System.Drawing.Size(200, 58);
            this.comentariosTextBox.TabIndex = 22;
            // 
            // AltaArrendamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.arrendamientosBindingNavigator);
            this.Name = "AltaArrendamiento";
            this.Text = "AltaArrendamiento";            
            this.Controls.SetChildIndex(this.arrendamientosBindingNavigator, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrendamientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrendamientosBindingNavigator)).EndInit();
            this.arrendamientosBindingNavigator.ResumeLayout(false);
            this.arrendamientosBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEmpresasInternasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralQuerysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estatusFinancierosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlazosNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SICASCentralDataSet sICASCentralDataSet;
        private System.Windows.Forms.BindingSource arrendamientosBindingSource;
        private SICASCentralDataSetTableAdapters.ArrendamientosTableAdapter arrendamientosTableAdapter;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator arrendamientosBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton arrendamientosBindingNavigatorSaveItem;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private SICASCentralQuerysDataSet sICASCentralQuerysDataSet;
        private System.Windows.Forms.BindingSource getEmpresasInternasBindingSource;
        private SICASCentralQuerysDataSetTableAdapters.Get_EmpresasInternasTableAdapter get_EmpresasInternasTableAdapter;
        private SICASCentralDataSetTableAdapters.EstatusFinancierosTableAdapter estatusFinancierosTableAdapter;
        private System.Windows.Forms.BindingSource estatusFinancierosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.NumericUpDown PlazosNumericUpDown;
        private System.Windows.Forms.TextBox arrendamiento_IDTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox referenciaTextBox;
        private System.Windows.Forms.TextBox catalogoReferenciaTextBox;
        private System.Windows.Forms.ComboBox arrendador_IDComboBox;
        private System.Windows.Forms.ComboBox arrendatario_IDComboBox;
        private System.Windows.Forms.TextBox montoAFinanciarTextBox;
        private System.Windows.Forms.TextBox valorFacturaTextBox;
        private System.Windows.Forms.TextBox mensualidadTextBox;
        private System.Windows.Forms.TextBox residualTextBox;
        private System.Windows.Forms.TextBox tasaTextBox;
        private System.Windows.Forms.TextBox amortizacionResidualTextBox;
        private System.Windows.Forms.ComboBox estatusFinanciero_IDComboBox;
        private System.Windows.Forms.TextBox montoPagadoTextBox;
        private System.Windows.Forms.TextBox saldoTextBox;
        private System.Windows.Forms.TextBox plazosRestantesTextBox;
        private System.Windows.Forms.DateTimePicker fechaInicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaFinalDateTimePicker;
        private System.Windows.Forms.TextBox ultimaFechaTextBox;
        private System.Windows.Forms.TextBox proximaFechaTextBox;
        private System.Windows.Forms.CheckBox activoCheckBox;
        private System.Windows.Forms.TextBox comentariosTextBox;
    }
}