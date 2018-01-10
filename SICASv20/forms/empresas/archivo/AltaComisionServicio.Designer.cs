namespace SICASv20.forms
{
    partial class AltaComisionServicio
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
            System.Windows.Forms.Label comisionista_IDLabel;
            System.Windows.Forms.Label comisionServicio_IDLabel;
            System.Windows.Forms.Label montoLabel;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label tipoComision_IDLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.comisionista_IDComboBox = new System.Windows.Forms.ComboBox();
            this.comisionesServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sICASCentralDataSet = new SICASv20.SICASCentralDataSet();
            this.comisionServicio_IDTextBox = new System.Windows.Forms.TextBox();
            this.montoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.tipoComision_IDComboBox = new System.Windows.Forms.ComboBox();
            this.tiposComisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new SICASv20.SICASCentralDataSetTableAdapters.TableAdapterManager();
            this.empresasTableAdapter = new SICASv20.SICASCentralDataSetTableAdapters.EmpresasTableAdapter();
            comisionista_IDLabel = new System.Windows.Forms.Label();
            comisionServicio_IDLabel = new System.Windows.Forms.Label();
            montoLabel = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            tipoComision_IDLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposComisionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comisionista_IDLabel
            // 
            comisionista_IDLabel.AutoSize = true;
            comisionista_IDLabel.Location = new System.Drawing.Point(33, 119);
            comisionista_IDLabel.Name = "comisionista_IDLabel";
            comisionista_IDLabel.Size = new System.Drawing.Size(96, 15);
            comisionista_IDLabel.TabIndex = 0;
            comisionista_IDLabel.Text = "Comisionista ID:";
            // 
            // comisionServicio_IDLabel
            // 
            comisionServicio_IDLabel.AutoSize = true;
            comisionServicio_IDLabel.Location = new System.Drawing.Point(33, 36);
            comisionServicio_IDLabel.Name = "comisionServicio_IDLabel";
            comisionServicio_IDLabel.Size = new System.Drawing.Size(123, 15);
            comisionServicio_IDLabel.TabIndex = 2;
            comisionServicio_IDLabel.Text = "Comision Servicio ID:";
            // 
            // montoLabel
            // 
            montoLabel.AutoSize = true;
            montoLabel.Location = new System.Drawing.Point(33, 148);
            montoLabel.Name = "montoLabel";
            montoLabel.Size = new System.Drawing.Size(45, 15);
            montoLabel.TabIndex = 4;
            montoLabel.Text = "Monto:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(33, 63);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(55, 15);
            nombreLabel.TabIndex = 6;
            nombreLabel.Text = "Nombre:";
            // 
            // tipoComision_IDLabel
            // 
            tipoComision_IDLabel.AutoSize = true;
            tipoComision_IDLabel.Location = new System.Drawing.Point(33, 90);
            tipoComision_IDLabel.Name = "tipoComision_IDLabel";
            tipoComision_IDLabel.Size = new System.Drawing.Size(104, 15);
            tipoComision_IDLabel.TabIndex = 8;
            tipoComision_IDLabel.Text = "Tipo Comision ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GuardarButton);
            this.groupBox1.Controls.Add(comisionista_IDLabel);
            this.groupBox1.Controls.Add(this.comisionista_IDComboBox);
            this.groupBox1.Controls.Add(comisionServicio_IDLabel);
            this.groupBox1.Controls.Add(this.comisionServicio_IDTextBox);
            this.groupBox1.Controls.Add(montoLabel);
            this.groupBox1.Controls.Add(this.montoTextBox);
            this.groupBox1.Controls.Add(nombreLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(tipoComision_IDLabel);
            this.groupBox1.Controls.Add(this.tipoComision_IDComboBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(987, 617);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comisiones de Servicios";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(468, 185);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 10;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // comisionista_IDComboBox
            // 
            this.comisionista_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesServiciosBindingSource, "Comisionista_ID", true));
            this.comisionista_IDComboBox.DataSource = this.empresasBindingSource;
            this.comisionista_IDComboBox.DisplayMember = "Nombre";
            this.comisionista_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comisionista_IDComboBox.FormattingEnabled = true;
            this.comisionista_IDComboBox.Location = new System.Drawing.Point(162, 116);
            this.comisionista_IDComboBox.Name = "comisionista_IDComboBox";
            this.comisionista_IDComboBox.Size = new System.Drawing.Size(295, 23);
            this.comisionista_IDComboBox.TabIndex = 1;
            this.comisionista_IDComboBox.ValueMember = "Empresa_ID";
            // 
            // comisionesServiciosBindingSource
            // 
            this.comisionesServiciosBindingSource.DataSource = typeof(SICASv20.Entities.ComisionesServicios);
            // 
            // empresasBindingSource
            // 
            this.empresasBindingSource.DataMember = "Empresas";
            this.empresasBindingSource.DataSource = this.sICASCentralDataSet;
            this.empresasBindingSource.Filter = "Activo = 1";
            this.empresasBindingSource.Sort = "Nombre";
            // 
            // sICASCentralDataSet
            // 
            this.sICASCentralDataSet.DataSetName = "SICASCentralDataSet";
            this.sICASCentralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comisionServicio_IDTextBox
            // 
            this.comisionServicio_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.comisionesServiciosBindingSource, "ComisionServicio_ID", true));
            this.comisionServicio_IDTextBox.Location = new System.Drawing.Point(162, 33);
            this.comisionServicio_IDTextBox.Name = "comisionServicio_IDTextBox";
            this.comisionServicio_IDTextBox.Size = new System.Drawing.Size(121, 21);
            this.comisionServicio_IDTextBox.TabIndex = 3;
            // 
            // montoTextBox
            // 
            this.montoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.comisionesServiciosBindingSource, "Monto", true));
            this.montoTextBox.Location = new System.Drawing.Point(162, 145);
            this.montoTextBox.Name = "montoTextBox";
            this.montoTextBox.Size = new System.Drawing.Size(121, 21);
            this.montoTextBox.TabIndex = 5;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.comisionesServiciosBindingSource, "Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(162, 60);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(121, 21);
            this.nombreTextBox.TabIndex = 7;
            // 
            // tipoComision_IDComboBox
            // 
            this.tipoComision_IDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesServiciosBindingSource, "TipoComision_ID", true));
            this.tipoComision_IDComboBox.DataSource = this.tiposComisionesBindingSource;
            this.tipoComision_IDComboBox.DisplayMember = "Nombre";
            this.tipoComision_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComision_IDComboBox.FormattingEnabled = true;
            this.tipoComision_IDComboBox.Location = new System.Drawing.Point(162, 87);
            this.tipoComision_IDComboBox.Name = "tipoComision_IDComboBox";
            this.tipoComision_IDComboBox.Size = new System.Drawing.Size(161, 23);
            this.tipoComision_IDComboBox.TabIndex = 9;
            this.tipoComision_IDComboBox.ValueMember = "TipoComision_ID";
            // 
            // tiposComisionesBindingSource
            // 
            this.tiposComisionesBindingSource.DataSource = typeof(SICASv20.Entities.TiposComisiones);
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
            // AltaComisionServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 652);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaComisionServicio";
            this.Text = "AltaComisionServicio";            
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sICASCentralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposComisionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ComboBox comisionista_IDComboBox;
        private System.Windows.Forms.BindingSource comisionesServiciosBindingSource;
        private System.Windows.Forms.TextBox comisionServicio_IDTextBox;
        private System.Windows.Forms.TextBox montoTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.ComboBox tipoComision_IDComboBox;
        private SICASCentralDataSet sICASCentralDataSet;
        private SICASCentralDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private SICASCentralDataSetTableAdapters.EmpresasTableAdapter empresasTableAdapter;
        private System.Windows.Forms.BindingSource empresasBindingSource;
        private System.Windows.Forms.BindingSource tiposComisionesBindingSource;
    }
}