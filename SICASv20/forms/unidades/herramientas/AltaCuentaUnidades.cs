using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaCuentaUnidades : baseForm
    {
        public AltaCuentaUnidades()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Su función es realizar el registro de un movimiento a la cuenta de unidades
        /// </summary>
        public class AltaCuentaUnidades_Model
        {
            public AltaCuentaUnidades_Model()
            {
                this.MovimientoCuentaUnidades = new Entities.CuentaUnidades();
            }

            /// <summary>
            /// El NúmeroEconomico de la Unidad
            /// </summary>            
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }
            private int _NumeroEconomico;

            /// <summary>
            /// El Movimiento a efectuar
            /// </summary>            
            public Entities.CuentaUnidades MovimientoCuentaUnidades
            {
                get { return _MovimientoCuentaUnidades; }
                set { _MovimientoCuentaUnidades = value; }
            }
            private Entities.CuentaUnidades _MovimientoCuentaUnidades;

            /// <summary>
            /// Los datos de la unidad
            /// </summary>
            public Entities.DatosConductorUnidad DatosUnidad
            {
                get { return _DatosUnidad; }
                set 
                { _DatosUnidad = value; }
            }
            private Entities.DatosConductorUnidad _DatosUnidad;
            
            /// <summary>
            /// Los Saldos de la unidad
            /// </summary>
            public List<Entities.Vista_SaldosUnidades> Saldos
            {
                get { return _Saldos; }
                set { _Saldos = value; }
            }
            private List<Entities.Vista_SaldosUnidades> _Saldos;

            /// <summary>
            /// Las Cuentas disponibles
            /// </summary>
            public List<Entities.Vista_Empresas_Cuentas> Cuentas
            {
                get { return _Cuentas; }
                set { _Cuentas = value; }
            }
            private List<Entities.Vista_Empresas_Cuentas> _Cuentas;

            /// <summary>
            /// Los Conceptos a partir de la Cuenta
            /// </summary>
            public List<Entities.Vista_Conceptos> Conceptos
            {
                get { return _Conceptos; }
                set { _Conceptos = value; }
            }
            private List<Entities.Vista_Conceptos> _Conceptos;

            /// <summary>
            /// Busca la unidad y configura los datos
            /// </summary>
            public void BuscarUnidad()
            {
                //  Obtenemos los datos de la unidad
                this.DatosUnidad = 
                    Entities.DatosConductorUnidad.Get(
                        this.NumeroEconomico, 
                        this.MovimientoCuentaUnidades.Empresa_ID, 
                        this.MovimientoCuentaUnidades.Estacion_ID,
                        false
                    );

                //  Obtenemos los saldos
                this.Saldos = Entities.Vista_SaldosUnidades.Get(this.DatosUnidad.Unidad_ID, null, null);

                //  Configuramos los datos de unidad y conductor para el movimiento
                this.MovimientoCuentaUnidades.Unidad_ID = this.DatosUnidad.Unidad_ID.Value;
                this.MovimientoCuentaUnidades.Conductor_ID = this.DatosUnidad.Conductor_ID;
            } // end void

            /// <summary>
            /// Configura la empresa actual para el movimiento
            /// </summary>
            /// <param name="empresa_id"></param>
            public void SetEmpresa(int empresa_id)
            {
                this.MovimientoCuentaUnidades.Empresa_ID = empresa_id;
                this.ConsultarCuentas();
            }

            /// <summary>
            /// Configura la cuenta actual para el movimiento
            /// </summary>
            /// <param name="cuenta_id"></param>
            public void SetCuenta(int cuenta_id)
            {
                this.MovimientoCuentaUnidades.Cuenta_ID = cuenta_id;
                this.ConsultarConceptos();
            }

            /// <summary>
            /// Configura el concepto actual para el movimiento
            /// </summary>
            /// <param name="concepto_id"></param>
            public void SetConcepto(int concepto_id)
            {
                this.MovimientoCuentaUnidades.Concepto_ID = concepto_id;
            }

            /// <summary>
            /// Configura la estación actual para el movimiento
            /// </summary>
            /// <param name="estacion_id"></param>
            public void SetEstacion(int estacion_id)
            {
                this.MovimientoCuentaUnidades.Estacion_ID = estacion_id;
            }

            /// <summary>
            /// Configura el cargo actual a ser usado en el movimiento
            /// </summary>
            /// <param name="cargo"></param>
            public void SetCargo(decimal cargo)
            {
                if (cargo > 0)
                {
                    //  Configuramo el abono a 0
                    this.MovimientoCuentaUnidades.Abono = 0;

                    //  Configuramos el cargo
                    this.MovimientoCuentaUnidades.Cargo = cargo;
                } // end if
            } // end void

            /// <summary>
            /// Configura el abono actual a ser usado en el movimiento
            /// </summary>
            /// <param name="abono"></param>
            public void SetAbono(decimal abono)
            {
                if (abono > 0)
                {
                    //  Configuramos el cargo a 0
                    this.MovimientoCuentaUnidades.Cargo = 0;

                    //  Configuramos el abono
                    this.MovimientoCuentaUnidades.Abono = abono;
                } // end if
            } // end void

            /// <summary>
            /// Configura los comentarios en el movimiento actual
            /// </summary>
            /// <param name="comentarios"></param>
            public void SetComentarios(string comentarios)
            {
                this.MovimientoCuentaUnidades.Comentarios = comentarios;
            } // end void

            /// <summary>
            /// Consulta y configura las cuentas a partir de la empresa
            /// </summary>
            private void ConsultarCuentas()
            {
                this.Cuentas = Entities.Vista_Empresas_Cuentas.Get(this.MovimientoCuentaUnidades.Empresa_ID);
            } // end void

            /// <summary>
            /// Consulta y configura los conceptos a partir de la cuenta
            /// </summary>
            private void ConsultarConceptos()
            {
                this.Conceptos = Entities.Vista_Conceptos.Get(null, this.MovimientoCuentaUnidades.Cuenta_ID);
            } // end void

            /// <summary>
            /// Valida los datos para la inseción
            /// </summary>
            private void Validar()
            {
                if (this.MovimientoCuentaUnidades.Concepto_ID == 0)
                {
                    throw new Exception("Debe capturar un concepto");
                }

                if (this.MovimientoCuentaUnidades.Cuenta_ID == 0)
                {
                    throw new Exception("Debe capturar una cuenta");
                }

                if (this.MovimientoCuentaUnidades.Cuenta_ID == 0)
                {
                    throw new Exception("Debe capturar una cuenta");
                }

                if (this.MovimientoCuentaUnidades.Abono == 0 && this.MovimientoCuentaUnidades.Cargo == 0)
                {
                    throw new Exception("Debe capturar una cargo o un abono");
                }

                if (this.MovimientoCuentaUnidades.Empresa_ID == 0)
                {
                    throw new Exception("Debe capturar una empresa");
                }

                if (this.MovimientoCuentaUnidades.Estacion_ID == 0)
                {
                    throw new Exception("Debe capturar una estacion");
                }

                if (this.MovimientoCuentaUnidades.Unidad_ID == 0)
                {
                    throw new Exception("Debe capturar una unidad");
                }

            } // end void Validar

            /// <summary>
            /// Guarda los datos en la base de datos
            /// </summary>
            public void Guardar()
            {
                //  Configuramos la fecha actual
                this.MovimientoCuentaUnidades.Fecha = DB.GetDate();
                this.MovimientoCuentaUnidades.Usuario_ID = Sesion.Usuario_ID;

                // Validamos primero los datos
                this.Validar();
                this.MovimientoCuentaUnidades.Validate();

                // Mandamos insertar el registro en la base de datos
                this.MovimientoCuentaUnidades.Create();

            } // end void Guardar

        } // end class model

        /// <summary>
        /// La instancia local del modelo
        /// </summary>
        private AltaCuentaUnidades_Model Model;

        #region Eventos

        /// <summary>
        /// Ligamos los datos necesarios
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new AltaCuentaUnidades_Model();

            //  Limpiamos la forma
            AppHelper.ClearControl(this);

            //  Cargamos Empresas y Estaciones
            this.selectEmpresasBindingSource.DataSource = Sesion.Empresas;
            this.selectEstacionesBindingSource.DataSource = Sesion.Estaciones;

            //  Mandamos seleccionar la empresa y estacion
            SeleccionarEmpresa();
            SeleccionarEstacion();

            //  Configuramos validación numérica para el número económico
            AppHelper.AddTextBoxOnlyNumbersValidation(ref this.NumeroEconomicoTextBox);

            base.BindData();
        }

        /// <summary>
        /// Al cambiar la empresa, se actualiza en el modelo y se consultan las cuentas
        /// </summary>
        private void SeleccionarEmpresa()
        {
            //  Si la empresa es diferente de null, procedemos
            //  Si la empresa es null, deberá seleccionar una
            if (empresa_IDComboBox.SelectedValue != null)
            {
                //  Obtenemos la empresa que estamos consultando
                int empresa_id = (int)this.empresa_IDComboBox.SelectedValue;

                //  Configuramos la empresa en el modelo
                this.Model.SetEmpresa(empresa_id);

                //  Ligamos los datos
                this.vista_Empresas_CuentasBindingSource.DataSource = this.Model.Cuentas;

                //  Mandamos seleccionar la cuenta
                this.SeleccionarCuenta();
            } // end if
        } // end void

        /// <summary>
        /// Al cambiar la empresa, mandamos llamar la seleccion de la empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empresa_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    SeleccionarEmpresa();
                } // end delegate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Al cambiar la estación, se actualiza en el modelo
        /// </summary>
        private void SeleccionarEstacion()
        {
            //  Si la estación es diferente de null, procedemos
            //  Si la estación es null, deberá seleccionar una
            if (estacion_IDComboBox.SelectedValue != null)
            {
                //  Obtenemos el dato de la estación
                int estacion_id = (int)estacion_IDComboBox.SelectedValue;

                // La configuramos en el modelo
                this.Model.SetEstacion(estacion_id);
            } // end if
        }

        /// <summary>
        /// Al cambiar la estación, mandamos llamar la seleccion de estacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estacion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    SeleccionarEstacion();
                } // end delegate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Consultamos la unidad y sus saldos
        /// y los ligamos a los controles
        /// </summary>
        private void ConsultarUnidad()
        {
            //  Configuramos el número económico en el modelo
            this.Model.NumeroEconomico = Convert.ToInt32(this.NumeroEconomicoTextBox.Text);

            //  Realizamos la búsqueda de la unidad
            this.Model.BuscarUnidad();

            //  Ligamos los datos
            this.vista_SaldosUnidadesBindingSource.DataSource = this.Model.Saldos;
            this.ConductorTextBox.Text = this.Model.DatosUnidad.Conductor;
        } // end if

        /// <summary>
        /// Al hacer enter en la unidad, se consulta la unidad en el modelo y se
        /// actualiza el nombre del conductor, así como los saldos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Si damos enter
                    if (e.KeyData == Keys.Enter)
                    {
                        //  Verificamos que haya datos en la caja de texto de número económico
                        if (string.IsNullOrEmpty(NumeroEconomicoTextBox.Text)) throw new Exception("Debe capturar el número económico");

                        ConsultarUnidad();
                    } // end if
                } // end delegate
            ); // end try
        } // end void

        /// <summary>
        /// Al cambiar la cuenta, se actualizan los conceptos y se actualiza el modelo
        /// </summary>
        private void SeleccionarCuenta()
        {
            if (cuenta_IDComboBox.SelectedValue != null)
            {
                //  Obtenemos el id de la cuenta
                int cuenta_id = (int)this.cuenta_IDComboBox.SelectedValue;

                //  Configuramos la cuenta en el modelo
                this.Model.SetCuenta(cuenta_id);

                //  Ligamos los conceptos
                this.vista_ConceptosBindingSource.DataSource = this.Model.Conceptos;

                //  Mandamos seleccionar el concepto
                this.SeleccionarConcepto();
            } // end if
        } // end void 

        /// <summary>
        /// Al cambiar la cuenta mandamos llamar su procedimiento de seleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuenta_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    SeleccionarCuenta();
                } // end delegate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Al cambiar el concepto se actualiza el modelo
        /// </summary>
        private void SeleccionarConcepto()
        {
            if (this.concepto_IDComboBox.SelectedValue != null)
            {
                //  Obtenemos el id del concepto
                int concepto_id = (int)this.concepto_IDComboBox.SelectedValue;

                //  Configuramo el concepto en el modelo
                this.Model.SetConcepto(concepto_id);
            } // end if
        } // end void

        /// <summary>
        /// Al cambiar el concepto mandamos llamar al procedimiento de seleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void concepto_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    SeleccionarConcepto();
                } // end delegate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Al cambiar el cargo, se actualiza abono a 0 y el modelo tambien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.SetCargo(this.CargoNumericUpDown.Value);
                    this.AbonoNumericUpDown.Value = Model.MovimientoCuentaUnidades.Abono;
                } // end delgate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Al cambiar el abono, se actualiza cargo a 0 y el modelo tambien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbonoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.SetAbono(this.AbonoNumericUpDown.Value);
                    this.CargoNumericUpDown.Value = this.Model.MovimientoCuentaUnidades.Cargo;
                } // end delegate
            ); // end AppHelper.Try
        } // end void

        /// <summary>
        /// Al capturar los comentarios actualizamos el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComentariosTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.SetComentarios(this.ComentariosTextBox.Text);
                } // end delegate
            ); // end AppHelper.Try
        } // end void 

        /// <summary>
        /// Al hacer clic en aceptar, guardamos los datos y limpiamos la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoTransactions(
                delegate
                {
                    //  Guardamos el movimiento en la base de datos
                    this.Model.Guardar();

                    //  Enviamos mensaje
                    AppHelper.Info("El movimiento ha sido registrado");

                    //  Configuramos a 0 los valores
                    this.CargoNumericUpDown.Value = 0;
                    this.AbonoNumericUpDown.Value = 0;
                    this.ComentariosTextBox.Text = string.Empty;

                    //  Volmemos a consultar los saldos de la unidad
                    this.ConsultarUnidad();

                },
                this
            ); // end do transactions
        } // end void

        #endregion

    } // end class form

} // end namespace
