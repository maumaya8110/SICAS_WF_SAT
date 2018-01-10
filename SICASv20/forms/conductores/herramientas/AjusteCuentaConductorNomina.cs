using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para realizar ajustes a conductores
    /// </summary>
    public partial class AjusteCuentaConductorNomina : baseForm
    {
	    System.Data.DataSet dsCuentasUsuario = new DataSet();

        /// <summary>
        /// Crea una nueva instancia del formulario para crear ajustes a los conductores
        /// </summary>
	    public AjusteCuentaConductorNomina()
        {
            InitializeComponent();

            //  Configuramos el valor máximo
            this.AbonoNumericUpDown.Maximum = decimal.MaxValue;
        }

        /// <summary>
        /// La empresa que es dueña de la cuenta deudora
        /// del conductor, sobre la que se efectuará el ajuste
        /// </summary>
        public int Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }
        private int _Empresa_ID;

        /// <summary>
        /// La estación a la que pertenece el conductor
        /// </summary>
        public int Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }
        private int _Estacion_ID;

        /// <summary>
        /// El número de conductor, al cual se efectuará el ajuste
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }
        private int _Conductor_ID;

        /// <summary>
        /// La unidad asignada al conductor, en caso de existir
        /// </summary>
        public int? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }
        private int? _Unidad_ID;

        /// <summary>
        /// La cuenta sobre la que se efectuará el ajuste
        /// </summary>
        public int Cuenta_ID
        {
            get { return _Cuenta_ID; }
            set { _Cuenta_ID = value; }
        }
        private int _Cuenta_ID;

        /// <summary>
        /// El concepto de ajuste
        /// </summary>
        public int Concepto_ID
        {
            get { return _Concepto_ID; }
            set { _Concepto_ID = value; }
        }
        private int _Concepto_ID;

        /// <summary>
        /// El cargo, debe ser 0, ya que es un ajuste
        /// </summary>
        public decimal Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private decimal _Cargo;

        /// <summary>
        /// El monto a ajustar
        /// </summary>
        public decimal Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }
        private decimal _Abono;

        /// <summary>
        /// Los comentarios del movimiento
        /// </summary>
        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }
        private string _Comentarios;

        /// <summary>
        /// El nombre del conductor
        /// </summary>
        public string NombreConductor
        {
            get { return _NombreConductor; }
            set { _NombreConductor = value; }
        }
        private string _NombreConductor;

        /// <summary>
        /// Formulario para buscar conductores
        /// </summary>
        public forms.BusquedaConductor Busqueda
        {
            get { return _Busqueda; }
            set { _Busqueda = value; }
        }
        private forms.BusquedaConductor _Busqueda;

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            //  Condiguramos estaciones y empresas
            estacionesBindingSource.DataSource = Sesion.Estaciones;
            getEmpresasInternasBindingSource.DataSource = Sesion.Empresas;

            //  Obtenemos las empresas y los conceptos
            SelectCuentas();
            SelectConceptos();

            //  Instanciamos el formulario de búsqueda
            this.Busqueda = new forms.BusquedaConductor();           

            base.BindData();
        }

        /// <summary>
        /// Consulta la cuentas en la base de datos
        /// y las liga a los controles
        /// </summary>
        private void SelectCuentas()
        {
            if (empresa_IDComboBox.SelectedValue != null)
            {
			  Hashtable hparams = new Hashtable();
			  hparams.Add("@Usuario_ID",Sesion.Usuario_ID);
			  hparams.Add("@Empresa_ID",(int)empresa_IDComboBox.SelectedValue);
			  dsCuentasUsuario = DB.QueryDS("usp_Obtiene_Cuentas_por_UsuarioEmpresa", hparams);

			  getCuentasDeEmpresaBindingSource.DataSource = dsCuentasUsuario.Tables[0];
            }
        }

        /// <summary>
        /// Consulta los conceptos de la base de datos
        /// y los liga a los controles
        /// </summary>
        private void SelectConceptos()
        {
            if (cuenta_IDComboBox.SelectedValue != null)
            {
                //  Llenar los conceptos

                //  Obtenemos la cuenta
                int cuenta_id = (int)cuenta_IDComboBox.SelectedValue;

                //  Obtenemos los conceptos
                List<Entities.SelectConceptos> conceptos = Entities.SelectConceptos.Get(cuenta_id, null);

                //  Instanciamos los ajustes
                List<Entities.SelectConceptos> ajustes = new List<Entities.SelectConceptos>();

                //  Llenamos los ajustes, a partir del tipo de concepto
                foreach (Entities.SelectConceptos concepto in conceptos)
                {
                    if (concepto.Nombre.Contains("ABONO") || concepto.Nombre.Contains("AJUSTE"))
                    {
                        ajustes.Add(concepto);
                    }
                }

                //  Los ligamos a los controles
                this.getConceptosDeCuentaBindingSource.DataSource = ajustes;
            }
        }

        /// <summary>
        /// Maneja el evento KeyUp en la caja de texto NumeroEconomico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //  Al hacer enter en "NumeroEconomico" o "Unidad"
                // Validar dato de unidad
                if (NumeroEconomicoTextBox.Text != ""
                        && e.KeyData == Keys.Enter)
                {
                    //  Consultar la información y desplegarla mediante el binding ya configurado                    
                    int numeroeconomico = DB.GetNullableInt32(NumeroEconomicoTextBox.Text).Value;

                    //  Obtenemos la estación
                    int estacion;
                    if (this.estacion_IDComboBox.SelectedItem != null)
                    {
                        estacion = Convert.ToInt32(this.estacion_IDComboBox.SelectedValue);
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar una estación");
                    }

                    //  Buscamos la unidad
                    Entities.Unidades unidad =
                        Entities.Unidades.Read(
                            DB.Param("NumeroEconomico", numeroeconomico),
                                DB.Param("EstatusUnidad_ID",2),
                                    DB.Param("Estacion_ID", estacion));

                    //  Verificamos que exista
                    if (unidad == null) throw new Exception("Unidad no existe o no tiene contrato activo");

                    //  Consultamos el contrato
                    Entities.Contratos contrato = 
                        Entities.Contratos.Read(DB.Param("Unidad_ID", unidad.Unidad_ID), DB.Param("EstatusContrato_ID", 1));

                    //  Verificamos que exista el contrato
                    if (contrato == null) throw new Exception("El contrato de la unidad no está activo");

                    //  Obtenemos el conductor
                    Entities.Conductores conductor =
                        Entities.Conductores.Read(contrato.Conductor_ID);

                    //  Verifcamos que la configuración del contrato
                    //  concuerde
                    if (Sesion.Empresa_ID != null)
                    {
                        if (contrato.Empresa_ID != Sesion.Empresa_ID.Value)
                        {
                            throw new Exception("No tiene permisos para consultar la unidad");
                        }
                        else
                        {
                            if (Sesion.Estacion_ID != null)
                            {
                                if (contrato.Estacion_ID != Sesion.Estacion_ID.Value)
                                {
                                    throw new Exception("No tiene permisos para consultar la unidad");
                                }
                            }
                        }
                    }

                    //  Configuramos el conductor y la unidad
                    Conductor_ID = conductor.Conductor_ID;
                    Unidad_ID = unidad.Unidad_ID;

                    //  Actualizamos el nombre
                    this.ConductorTextBox.Text = conductor.Apellidos + " " + conductor.Nombre;

                    //  Consultar los saldos
                    get_SaldosConductorTableAdapter.Fill(sICASCentralQuerysDataSet.Get_SaldosConductor, Conductor_ID);

                    //  Colorear los saldos
                    ColorGrid();
                } 
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }        

        /// <summary>
        /// Maneja el evento de seleccion de empresas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empresa_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  Al seleccionar empresa
            //  Seleccionamos las cuentas
            SelectCuentas();
        }

        /// <summary>
        /// Maneja el evento de seleccion de cuentas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuenta_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  Al seleccionar cuenta
            //  Seleccionamos los conceptos
            SelectConceptos();
        }

        /// <summary>
        /// Maneja el evento de Click en el botón "Aceptar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            //  Grabamos los cambios
            DoSave();
        }

        /// <summary>
        /// Valida los parámetros de entrada de la forma
        /// </summary>
        private void DoValidate()
        {
            //  Configurar las reglas de validación

            AppHelper.ValidateControl(ConductorTextBox,
                AppHelper.ValidateRule.Required);

            AppHelper.ValidateControl(empresa_IDComboBox,
                AppHelper.ValidateRule.Required);

            AppHelper.ValidateControl(estacion_IDComboBox,
                AppHelper.ValidateRule.Required);

            AppHelper.ValidateControl(cuenta_IDComboBox,
                AppHelper.ValidateRule.Required);

            AppHelper.ValidateControl(concepto_IDComboBox,
                AppHelper.ValidateRule.Required);

            AppHelper.ValidateControl(ComentariosTextBox,
                AppHelper.ValidateRule.Required);

            //  Si no hay ni cargo ni abono
            if (AbonoNumericUpDown.Value == 0 )
            {
                throw new Exception("Debe capturar un abono mayor que 0.");
            }
        }

        /// <summary>
        /// Guarda la información en la base de datos
        /// </summary>
        private void DoSave()
        {
            try
            {
                //  Validar la forma
                DoValidate();

                //  Configurar las variables
                Empresa_ID = (int)empresa_IDComboBox.SelectedValue;
                Estacion_ID = (int)estacion_IDComboBox.SelectedValue;
                Abono = AbonoNumericUpDown.Value;
                Cargo = 0;
                Cuenta_ID = (int)cuenta_IDComboBox.SelectedValue;
                Concepto_ID = (int)concepto_IDComboBox.SelectedValue;
                Comentarios = ComentariosTextBox.Text;

                //  Instanciamos un nuevo registro de CuentaConductores
                Entities.CuentaConductores cc = new Entities.CuentaConductores();

                //  Configuramos la información del ajuste
                cc.Abono = Abono;
                cc.Caja_ID = Sesion.Caja_ID;
                cc.Cargo = Cargo;
                cc.Comentarios = Comentarios;
                cc.Concepto_ID = Concepto_ID;
                cc.Conductor_ID = Conductor_ID;
                cc.Cuenta_ID = Cuenta_ID;
                cc.Empresa_ID = Empresa_ID;
                cc.Estacion_ID = Estacion_ID;
                cc.Fecha = DB.GetDate();
                cc.Referencia_ID = null;
                cc.Saldo = 0; // Se calcula solo;
                cc.Ticket_ID = null;
                cc.Unidad_ID = Unidad_ID;
                cc.Usuario_ID = Sesion.Usuario_ID;

                //  Insertar el registro
                cc.Create();

                //  Volver a consultar los saldos
                get_SaldosConductorTableAdapter.Fill(
                    sICASCentralQuerysDataSet.Get_SaldosConductor, 
                        Conductor_ID);

                //  Volver a Colorear los saldos
                ColorGrid();

                DoClear();

                //  Informar de éxito
                AppHelper.Info("Movimiento registrado");

            }
            catch(Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Limpia los controles de la forma
        /// </summary>
        private void DoClear()
        {
            this.AbonoNumericUpDown.Value = 0;
            this.ComentariosTextBox.Text = "";
            //if (this.empresa_IDComboBox.Items.Count>0) this.empresa_IDComboBox.SelectedIndex = 0;
            //if (this.estacion_IDComboBox.Items.Count > 0) this.estacion_IDComboBox.SelectedIndex = 0;
            if (this.cuenta_IDComboBox.Items.Count > 0) this.cuenta_IDComboBox.SelectedIndex = 0;
            if (this.concepto_IDComboBox.Items.Count > 0) this.concepto_IDComboBox.SelectedIndex = 0;
            
            this.Conductor_ID = 0;
            this.Unidad_ID = 0;
            this.NumeroEconomicoTextBox.Text = "";
            this.ConductorTextBox.Text = "";
            this.NumeroEconomicoTextBox.Focus();
        }

        /// <summary>
        /// Aplica claves de colores al DataGridView
        /// </summary>
        private void ColorGrid()
        {
            decimal saldo;

            //  Iteración para cada renglón
            foreach (DataGridViewRow row in this.get_SaldosConductorDataGridView.Rows)
            {
                // Asignar saldo
                saldo = Convert.ToDecimal(row.Cells["SaldoColumn"].Value);
                if (saldo < 0)
                {
                    get_SaldosConductorDataGridView.
                        Rows[row.Index].DefaultCellStyle.BackColor = Color.FromArgb(255, 77, 77);
                    get_SaldosConductorDataGridView.
                        Rows[row.Index].DefaultCellStyle.ForeColor = Color.White;
                    get_SaldosConductorDataGridView.
                        Rows[row.Index].DefaultCellStyle.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                }
            }
        }

        /// <summary>
        /// Maneja el evento Click en el botón "BuscarConductor"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarConductorButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Validad que exista "Busqueda"
                if (Busqueda == null)
                {
                    Busqueda = new forms.BusquedaConductor();
                }
                else if (Busqueda.IsDisposed == true)
                {
                    Busqueda = new forms.BusquedaConductor();
                }

                //  Mostrar el dialogo
                if (Busqueda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DoClear();

                    //  Configurar la variable de conductor
                    Conductor_ID = Busqueda.Conductor_ID;
                    NombreConductor = Busqueda.NombreConductor;
                    this.ConductorTextBox.Text = NombreConductor;

                    //  Buscar los datos a partir de conductor
                    //  La unidad, si la tiene
                    Entities.Contratos contrato = Entities.Contratos.Read(DB.Param("Conductor_ID", Conductor_ID),
                        DB.Param("EstatusContrato_ID", 1), DB.Param("Cuenta_ID",1));
                    if (contrato != null)
                    {
                        //  Obtener la unidad
                        if (contrato.Unidad_ID != null)
                        {
                            this.NumeroEconomicoTextBox.Text = Entities.Unidades.Read(contrato.Unidad_ID.Value).NumeroEconomico.ToString();
                        }
                        else
                        {
                            Unidad_ID = null;
                        }
                    }
                    else
                    {
                        Unidad_ID = null;
                    }

                    //  Consultar los saldos
                    get_SaldosConductorTableAdapter.Fill(sICASCentralQuerysDataSet.Get_SaldosConductor, Conductor_ID);

                    ColorGrid();

                }
            }
            catch(Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        } // end void BuscarConductor_Click

    } // end class

} // end namespace