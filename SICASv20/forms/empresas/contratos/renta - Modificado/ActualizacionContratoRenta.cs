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
    /// Formulario para actualizar la información de un contrato de renta
    /// </summary>
    public partial class ActualizacionContratoRenta : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de actualización de un contrato de renta
        /// </summary>
        public ActualizacionContratoRenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El modelo de lógica de negocios que contiene la funcionalidad
        /// de la actualización de contratos
        /// </summary>
        ActualizacionContratoRenta_Model Model;

        /// <summary>
        /// El folio del contrato a actualizar
        /// </summary>
        public int Contrato_ID
        {
            get { return _Contrato_ID; }
            set { _Contrato_ID = value; }
        }
        private int _Contrato_ID;

        /// <summary>
        /// El folio del conductor copia del contrato
        /// a modificar
        /// </summary>
        public int? ConductorCopia_ID
        {
            get { return _ConductorCopia_ID; }
            set { _ConductorCopia_ID = value; }
        }
        private int? _ConductorCopia_ID;

        /// <summary>
        /// Formulario para la busqueda de conductores
        /// </summary>
        public forms.BusquedaConductor BusquedaConductorForm
        {
            get 
            {
                if (_BusquedaConductorForm == null)
                    _BusquedaConductorForm = new BusquedaConductor();

                if (_BusquedaConductorForm.IsDisposed)
                    _BusquedaConductorForm = new BusquedaConductor();

                return _BusquedaConductorForm;
            }
            set { _BusquedaConductorForm = value; }
        }
        private forms.BusquedaConductor _BusquedaConductorForm;
 
        #region Model

        /// <summary>
        /// Modela las funciones de lógica de negocios
        /// para la actualización de contratos
        /// </summary>
        class ActualizacionContratoRenta_Model
        {
            /// <summary>
            /// Folio del cnotrato
            /// </summary>
            public int Contrato_ID
            {
                get { return _Contrato_ID; }
                set { _Contrato_ID = value; }
            }
            private int _Contrato_ID;

            /// <summary>
            /// Cojunto de datos del contrato, para visualización
            /// del usuario
            /// </summary>
            public Entities.Vista_Contratos Vista_Contrato
            {
                get { return _Vista_Contrato; }
                set { _Vista_Contrato = value; }
            }
            private Entities.Vista_Contratos _Vista_Contrato;

            /// <summary>
            /// Listado de estaciones, para elegir actualizar en el contrato
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones
            {
                get { return _Estaciones; }
                set { _Estaciones = value; }
            }
            private List<Entities.SelectEstaciones> _Estaciones;

            /// <summary>
            /// Entidad de contrato a modificar
            /// </summary>
            public Entities.Contratos Contrato
            {
                get { return _Contrato; }
                set { _Contrato = value; }
            }
            private Entities.Contratos _Contrato;

            /// <summary>
            /// Listado de planes disponibles para la actualización del contrato
            /// </summary>
            public List<Entities.PlanesDeRenta> PlanesDeRenta
            {
                get { return _PlanesDeRenta; }
                set { _PlanesDeRenta = value; }
            }
            private List<Entities.PlanesDeRenta> _PlanesDeRenta;

            /// <summary>
            /// Listado de tipos de contratos para la actualización del contrato
            /// </summary>
            public List<Entities.TiposContratos> TiposContratos
            {
                get { return _TiposContratos; }
                set { _TiposContratos = value; }
            }
            private List<Entities.TiposContratos> _TiposContratos;

            /// <summary>
            /// Consulta al contrato en la base de datos
            /// </summary>
            public void ConsultarContrato()
            {
                this.Vista_Contrato = Entities.Vista_Contratos.Get(this.Contrato_ID)[0];
                this.Contrato = Entities.Contratos.Read(this.Contrato_ID);
            }

            /// <summary>
            /// Guarda al contrato en la base de datos
            /// </summary>
            public void Guardar()
            {
                this.Contrato.Update();
            }

            /// <summary>
            /// Consulta los planes en la base de datos
            /// </summary>
            public void ConsultarPlanes()
            {
                this.PlanesDeRenta = Entities.PlanesDeRenta.ReadList(
                        DB.Param("Activo", true),
                        DB.Param("Estacion_ID", this.Contrato.Estacion_ID)
                    );
            }

            /// <summary>
            /// Consulta los tipos de contrato en la base de datos
            /// </summary>
            public void ConsultarTiposContratos()
            {
                this.TiposContratos = Entities.TiposContratos.Read();
            }

            /// <summary>
            /// Consulta las estacionles disponibles
            /// </summary>
            public void ConsultarEstaciones()
            {
                this.Estaciones = Sesion.Estaciones;
            }

        }
        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ActualizacionContratoRenta_Model();

            //  Configuramos el folio
            this.Model.Contrato_ID = this.Contrato_ID;

            //  Consultamos el contrato
            this.Model.ConsultarContrato();

            //  Ligamos los datos a los controles
            this.vista_ContratosBindingSource.DataSource = this.Model.Vista_Contrato;
            this.cobroPermanenteCheckBox.Checked = this.Model.Contrato.CobroPermanente;
            this.Model.ConsultarPlanes();
            this.planesDeRentaBindingSource.DataSource = this.Model.PlanesDeRenta;
            this.ConsultarPlan();

            this.Model.ConsultarTiposContratos();
            this.tiposContratosBindingSource.DataSource = this.Model.TiposContratos;
            this.ConsultarTipoContrato();

            this.Model.ConsultarEstaciones();
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;
            this.ConsultarEstacion();
            base.BindData();
        }
        
        /// <summary>
        /// Verifica si el usuario tiene permisos para la estación seleccionada
        /// </summary>
        private void ConsultarEstacion()
        {            
            Entities.Estaciones estacion = Entities.Estaciones.Read(this.Model.Contrato.Estacion_ID);
            Entities.SelectEstaciones selectestacion = new Entities.SelectEstaciones();
            selectestacion.Estacion_ID = estacion.Estacion_ID;
            selectestacion.Nombre = estacion.Nombre;

            bool ExisteEstacion = false;

            foreach (Entities.SelectEstaciones se in this.Model.Estaciones)
            {
                if (se.Estacion_ID == selectestacion.Estacion_ID &&
                    se.Nombre == selectestacion.Nombre)
                {
                    ExisteEstacion = true;
                    break;
                }
            }

            if (ExisteEstacion)
            {
                this.EstacionesComboBox.SelectedValue = selectestacion.Estacion_ID;
            }
            else
            {
                AppHelper.ThrowException("El usuario no tiene permisos para la estación del contrato");
            }
        }

        /// <summary>
        /// Consulta el plan de renta del contrato, para configurarlo en el control
        /// PlanesDeRentaComboBox
        /// </summary>
        private void ConsultarPlan()
        {
            Entities.PlanesDeRenta planderenta = 
                Entities.PlanesDeRenta.Read(
                DB.Param("ModeloUnidad_ID", this.Model.Contrato.ModeloUnidad_ID),
                DB.Param("Estacion_ID", this.Model.Contrato.Estacion_ID),
                DB.Param("RentaBase", this.Model.Contrato.MontoDiario),
                DB.Param("DiasDeCobro_ID", this.Model.Contrato.DiasDeCobro_ID)
            );

            if (planderenta != null)
                this.PlanesDeRentaComboBox.SelectedValue = planderenta.Descripcion;
        }

        /// <summary>
        /// Consulta el tipo de contrato del contrato, para configurarlo en el control
        /// TiposContratosComboBox
        /// </summary>
        private void ConsultarTipoContrato()
        {
            Entities.TiposContratos tipocontrato =
                Entities.TiposContratos.Read(this.Model.Contrato.TipoContrato_ID)[0];

            if (tipocontrato != null)
                this.TipoContratoComboBox.SelectedValue = tipocontrato.TipoContrato_ID;
        }

        /// <summary>
        /// Maneja el evento "Click" del control "CancelarButton"
        /// </summary>
        /// <param name="sender">EL control "CancelarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Padre.CancelCurrentForm();
                }
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "GuardarButton"
        /// </summary>
        /// <param name="sender">EL control "GuardarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Configuramos los datos de los controles
                    this.Model.Contrato.CobroPermanente = this.cobroPermanenteCheckBox.Checked;
                    this.Model.Contrato.FechaFinal = 
                        (this.fechaFinalDateTimePicker.Checked) ? DB.GetNullableDateTime(this.fechaFinalDateTimePicker.Value) : null;
                    this.Model.Contrato.Comentarios = this.comentariosTextBox.Text;
                    this.Model.Contrato.Descripcion = this.descripcionTextBox.Text;
                    this.Model.Contrato.MontoDiario = Convert.ToDecimal(this.montoDiarioTextBox.Text);
                    this.Model.Contrato.FondoResidual = Convert.ToDecimal(this.fondoResidualTextBox.Text);
                    this.Model.Contrato.ConductorCopia_ID = this.ConductorCopia_ID;
                    this.Model.Contrato.TipoContrato_ID = Int32.Parse(this.TipoContratoComboBox.SelectedValue.ToString());

                    //  Guardamos la información
                    this.Model.Guardar();

                    //  Informamos al usuario
                    AppHelper.Info("Registro Actualizado");
                },
                this
            );
            Padre.SwitchForma("ContratosRenta");
        }

        /// <summary>
        /// Maneja el evento "CheckedChanged" del control "cobroPermanenteCheckBox"
        /// </summary>
        /// <param name="sender">EL control "cobroPermanenteCheckBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void cobroPermanenteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.fechaFinalDateTimePicker.Checked = !cobroPermanenteCheckBox.Checked;
                }
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConductorCopiaButton"
        /// Despliega la forma para buscar al conductor copia
        /// </summary>
        /// <param name="sender">EL control "ConductorCopiaButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConductorCopiaButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {                    
                    if (this.BusquedaConductorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ConductorCopia_ID = this.BusquedaConductorForm.Conductor_ID;
                        this.conductorCopiaTextBox.Text = this.BusquedaConductorForm.NombreConductor;
                    }
                }
            );
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" del control "PlanesDeRentaComboBox".
        /// Configura los datos relevantes al plan.
        /// </summary>
        /// <param name="sender">EL control "PlanesDeRentaComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void PlanesDeRentaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {                    
                    Entities.PlanesDeRenta planderenta = (Entities.PlanesDeRenta)this.PlanesDeRentaComboBox.SelectedItem;
                    Entities.DiasDeCobros diasdecobro = Entities.DiasDeCobros.Read(planderenta.DiasDeCobro_ID);
                    this.diasCobroTextBox.Text = diasdecobro.Nombre;
                    this.modeloTextBox.Text = planderenta.Descripcion;
                    this.montoDiarioTextBox.Text = planderenta.RentaBase.ToString();
                    this.Model.Contrato.ModeloUnidad_ID = planderenta.ModeloUnidad_ID;
                    this.Model.Contrato.DiasDeCobro_ID = planderenta.DiasDeCobro_ID;
                    this.Model.Contrato.MontoDiario = planderenta.RentaBase;
                }
            );
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" del control "TipoContratoComboBox".
        /// Configura los datos relevantes al tipo de contrato.
        /// </summary>
        /// <param name="sender">EL control "TipoContratoComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void TipoContratoComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Entities.TiposContratos tipocontarto = (Entities.TiposContratos)this.TipoContratoComboBox.SelectedItem;
                    this.Model.Contrato.TipoContrato_ID = tipocontarto.TipoContrato_ID;
                }
            );
        }

        /// <summary>
        /// Maneja el evento "SelectionChangeCommitted" del control "EstacionesComboBox"
        /// Actualiza la estación en el modelo.
        /// </summary>
        /// <param name="sender">EL control "EstacionesComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Contrato.Estacion_ID = Convert.ToInt32(EstacionesComboBox.SelectedValue);
                }
            );
        } // end void PlanesDeRentaComboBox
    } // end class
    #endregion
} // end namespace
