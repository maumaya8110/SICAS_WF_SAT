/*
 * Historial
 *  7 de Mayo de 2013, actualizado por Luis Espino
 *      Se modificó el proceso de terminacion de contrato,
 *      se actualiza el estatus de unidad a partir de la
 *      locación, Lineas 208 a 230
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para terminación de contratos
    /// </summary>
    public partial class TerminacionContrato : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="TerminacionContrato"/>
        /// </summary>
        public TerminacionContrato()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        private TerminacionContrato_Model Model { get; set; }

        /// <summary>
        /// El modelo de lógica de negocios, contiene las funciones para llevar a cabo
        /// la terminación de contratos.
        /// </summary>
        class TerminacionContrato_Model
        {
            /// <summary>
            /// Crea una nueva instancia de la clase <see cref="TerminaciónContrato_Model"/>
            /// </summary>
            public TerminacionContrato_Model()
            { 
            }

            /// <summary>
            /// Listado de saldos del conductor cuyo contrato está terminando
            /// </summary>
            public List<Entities.Vista_SaldosConductores> Saldos
            {
                get { return _Saldos; }
                set { _Saldos = value; }
            }
            private List<Entities.Vista_SaldosConductores> _Saldos;

            /// <summary>
            /// Listado de datos del contrato
            /// </summary>
            public List<Entities.Vista_Contratos> DatosContrato
            {
                get { return _DatosContrato; }
                set { _DatosContrato = value; }
            }
            private List<Entities.Vista_Contratos> _DatosContrato;

            /// <summary>
            /// Locaciones disponibles de las unidades
            /// </summary>
            public List<Entities.LocacionesUnidades> Locaciones
            {
                get { return _Locaciones; }
                set { _Locaciones = value; }
            }
            private List<Entities.LocacionesUnidades> _Locaciones;

            /// <summary>
            /// Locación seleccionada de la unidad. A esta locación se enviará la unidad
            /// después de terminar el contrato.
            /// </summary>
            public int LocacionUnidad
            {
                get { return _LocacionUnidad; }
                set { _LocacionUnidad = value; }
            }
            private int _LocacionUnidad;

            /// <summary>
            /// Estatus al que pasará el conductor, después de terminar el contrato. Es
            /// seleccionado por el usuario.
            /// </summary>
            public int EstatusConductor_ID
            {
                get { return _EstatusConductor_ID; }
                set { _EstatusConductor_ID = value; }
            }
            private int _EstatusConductor_ID;

            /// <summary>
            /// Estatus al que pasará el contrato, después de terminado.
            /// </summary>
            public int EstatusContrato_ID
            {
                get { return _EstatusContrato_ID; }
                set { _EstatusContrato_ID = value; }
            }
            private int _EstatusContrato_ID;

            /// <summary>
            /// Contiene la descripción del estatus al que pasará el conductor
            /// después de terminar el contrato.
            /// </summary>
            public string EstatusConductor
            {
                get { return _EstatusConductor; }
                set { _EstatusConductor = value; }
            }
            private string _EstatusConductor;

            /// <summary>
            /// Contiene la descripción del estatus al que pasará el contrato
            /// después de terminado
            /// </summary>
            public string EstatusContrato
            {
                get { return _EstatusContrato; }
                set { _EstatusContrato = value; }
            }
            private string _EstatusContrato;

            /// <summary>
            /// El número de contrato
            /// </summary>
            public int Contrato_ID
            {
                get { return _Contrato_ID; }
                set { _Contrato_ID = value; }
            }
            private int _Contrato_ID;

            /// <summary>
            /// Los comentarios del usuario sobre la terminación del contrato
            /// </summary>
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }
            private string _Comentarios;

            /// <summary>
            /// El saldo total del conductor, considerando los adeudos de todas
            /// las cuentas
            /// </summary>
            private decimal _SaldoTotal;

            /// <summary>
            /// Fecha final del contrato
            /// </summary>
            private DateTime? _FechaFinal;

            /// <summary>
            /// Número de identificación del conductor
            /// </summary>
            private int _Conductor_ID;

            /// <summary>
            /// La entidad de contratos liquidados a registrar en el sistema.
            /// </summary>
            private Entities.ContratosLiquidados ContratoLiquidado;            

            /// <summary>
            /// La unidad asignada en el contrato.
            /// </summary>
            private int Unidad_ID;

            /// <summary>
            /// Realiza la liquidación (terminación) del contrato.            
            /// </summary>            
            public void LiquidarContrato()
            {
                ContratoLiquidado = new Entities.ContratosLiquidados();
                ContratoLiquidado.Comentarios = this.Comentarios;
                ContratoLiquidado.Conductor_ID = this._Conductor_ID;
                ContratoLiquidado.Contrato_ID = this.Contrato_ID;
                ContratoLiquidado.EstatusConductor_ID = this.EstatusConductor_ID;
                ContratoLiquidado.EstatusContrato_ID = this.EstatusContrato_ID;
                ContratoLiquidado.Fecha = DB.GetDate();
                ContratoLiquidado.LocacionUnidad_ID = this.LocacionUnidad;
                ContratoLiquidado.Unidad_ID = this.Unidad_ID;
                ContratoLiquidado.Usuario_ID = Sesion.Usuario_ID;                
                ContratoLiquidado.Create();

                DB.UpdateRow(
                    "Contratos", 
                    DB.GetParams(DB.Param("EstatusContrato_ID", this.EstatusContrato_ID)), 
                    DB.GetParams(DB.Param("Contrato_ID",this.ContratoLiquidado.Contrato_ID))
                );

                DB.UpdateRow(
                    "Conductores",
                    DB.GetParams(DB.Param("EstatusConductor_ID", this.EstatusConductor_ID)),
                    DB.GetParams(DB.Param("Conductor_ID", this.ContratoLiquidado.Conductor_ID))
                );

                /*
                 * Inicia actualización del código
                 * 7 de Mayo de 2013
                 * Se agrega la columna "EstatusUnidad_ID" a la actualización
                 * de la tabla "Unidades"
                 */

                //  Obtenemos el estatus
                Entities.LocacionesUnidades locacionunidad = 
                    Entities.LocacionesUnidades.Read(this.LocacionUnidad);

                //  Actualizamos la tabla de unidades
                DB.UpdateRow(
                    "Unidades",
                    DB.GetParams(
                        DB.Param("LocacionUnidad_ID", this.LocacionUnidad),
                        DB.Param("ConductorOperativo_ID", null),
                        DB.Param("EstatusUnidad_ID", locacionunidad.EstatusUnidad_ID) // Agregamos la actualización a EstatusUnidad_ID
                    ),
                    DB.GetParams(
                        DB.Param("Unidad_ID", this.ContratoLiquidado.Unidad_ID)
                    )
                );
            }

            /// <summary>
            /// Calcula el saldo total del conductor, considerando todas las cuentas
            /// </summary>
            private void ObtenerSaldoTotal()
            {
                if (this.Saldos != null && this.Saldos.Count > 0)
                {
                    this._SaldoTotal = 0;
                    foreach (Entities.Vista_SaldosConductores vs in this.Saldos)
                    {
                        this._SaldoTotal += vs.Saldo;
                    }
                }
            }

            /// <summary>
            /// Realiza las consultas necesarias para llenar todos los datos
            /// de la forma
            /// </summary>
            /// <param name="contrato_id">El número de identificación del contrato</param>
            public void Consultar(int contrato_id)
            {
                this.Contrato_ID = contrato_id;
                ConsultarLocaciones();
                ConsultarContrato();
                ConsultarSaldos();
                ConsultarEstados();
                ConsultarNombresEstados();
            }

            /// <summary>
            /// Realiza las consultas necesarias para llenar todos los datos
            /// de la forma
            /// </summary>
            public void Consultar()
            {
                ConsultarLocaciones();
                ConsultarContrato();
                ConsultarSaldos();
                ConsultarEstados();
                ConsultarNombresEstados();
            }

            /// <summary>
            /// Consulta las locaciones en la base de datos
            /// </summary>
            private void ConsultarLocaciones()
            {
                this.Locaciones = Entities.LocacionesUnidades.ReadButCirculando();
            }

            /// <summary>
            /// Consulta los datos del contrato
            /// </summary>
            private void ConsultarContrato()
            {
                this.DatosContrato = Entities.Vista_Contratos.Get(this.Contrato_ID);
                Entities.Contratos contrato = Entities.Contratos.Read(this.Contrato_ID);

                if (this.DatosContrato != null && contrato != null)
                {
                    this._Conductor_ID = contrato.Conductor_ID;
                    this._FechaFinal = contrato.FechaFinal;
                    this.Unidad_ID = Entities.Contratos.Read(this.Contrato_ID).Unidad_ID.Value;
                }
            }

            /// <summary>
            /// Consulta los saldos del conductor
            /// </summary>
            private void ConsultarSaldos()
            {
                this.Saldos = Entities.Vista_SaldosConductores.Get(this._Conductor_ID);
                this.ObtenerSaldoTotal();
            }

            /// <summary>
            /// Consulta los estatus disponibles, a apartir de los adeudos del conductor
            /// </summary>
            private void ConsultarEstados()
            {
                if (this._SaldoTotal < 0)
                {
                    //  Tiene adeudo
                    this.EstatusConductor_ID = 4 + 4;

                    if (this._FechaFinal != null)
                    {
                        if (this._FechaFinal.Value <= DB.GetDate())
                        {
                            this.EstatusContrato_ID = 3 + 7;
                        }
                        else
                        {
                            this.EstatusContrato_ID = 5 + 7;
                        }
                    }
                    else
                    {
                        this.EstatusContrato_ID = 5 + 7;
                    }
                }
                else
                {
                    //  No tiene adeudo
                    this.EstatusConductor_ID = 5 + 4;

                    if (this._FechaFinal != null)
                    {
                        if (this._FechaFinal.Value <= DB.GetDate())
                        {
                            this.EstatusContrato_ID = 2 + 7;
                        }
                        else
                        {
                            this.EstatusContrato_ID = 4 + 7;
                        }
                    }
                    else
                    {
                        this.EstatusContrato_ID = 4 + 7;
                    }
                }
            }

            /// <summary>
            /// Consulta los nombres de los estatus disponibles, para mostrar al usuario
            /// </summary>
            private void ConsultarNombresEstados()
            {
                this.EstatusConductor = Entities.EstatusConductores.Read(this.EstatusConductor_ID)[0].Nombre;
                this.EstatusContrato = Entities.EstatusContratos.Read(this.EstatusContrato_ID)[0].Nombre;                
            }
        }

        /// <summary>
        /// El número de identificación del contrato
        /// </summary>
        public int Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }
        private int _Contrato_ID;

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            Model = new TerminacionContrato_Model();
            Model.Consultar(this.Contrato_ID);
            this.vista_ContratosBindingSource.DataSource = Model.DatosContrato;
            this.vista_SaldosConductoresBindingSource.DataSource = Model.Saldos;
            this.locacionesUnidadesBindingSource.DataSource = Model.Locaciones;
            this.EstatusConductorTextBox.Text = Model.EstatusConductor;
            this.EstatusContratoTextBox.Text = Model.EstatusContrato;
            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Click" del control "LiquidarContratoButton"
        /// </summary>
        /// <param name="sender">El control "LiquidarContratoButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void LiquidarContratoButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ComentariosTextBox.Text))
            {
                AppHelper.Info("Se deben agregar comentarios descriptivos relacionados a cualquier situación relacionada con la liquidación");
            }
            else
            {
                AppHelper.DoMethod(delegate
                {
                    Model.Comentarios = this.ComentariosTextBox.Text;
                    Model.LocacionUnidad = Convert.ToInt32(this.LocacionUnidadComboBox.SelectedValue);
                    Model.LiquidarContrato();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Contrato liquidado");
                    Padre.SwitchForma("ContratosLiquidados");
                }, this);
            }
        }
    } // end class TerminacionContrato

} // end namespace SICASv20.forms