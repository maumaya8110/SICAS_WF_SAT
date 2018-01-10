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
    /// Formulario para la consulta de servicios pendientes de pago
    /// para un conductor
    /// </summary>
    public partial class CajaDeServicios : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario
        /// de servicios pendientes de pago
        /// </summary>
        public CajaDeServicios()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Modelo de la lógica de negocios de caja de servicios
        /// </summary>
        CajaDeServicios_Model Model;
        #endregion

        #region Model

        /// <summary>
        /// Clase que modela la lógica de negocios
        /// de la consulta de servicios pendientes de pago
        /// a los conductores
        /// </summary>
        public class CajaDeServicios_Model
        {
            /// <summary>
            /// La fecha de pago a consultar
            /// </summary>
            public DateTime FechaPago
            {
                get { return _FechaPago; }
                set { _FechaPago = value; }
            }
            private DateTime _FechaPago;

            /// <summary>
            /// El nombre del conductor
            /// </summary>
            public string NombreConductor
            {
                get { return _NombreConductor; }
                set { _NombreConductor = value; }
            }
            private string _NombreConductor;

		  public decimal? MontoDiario
		  {
			  get
			  {
				  return _montoDiario;
			  }
			  set { _montoDiario = value; }
		  }
		  private decimal? _montoDiario;

            /// <summary>
            /// El numero economico de la unidad que tiene asignada el conductor
            /// </summary>
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }
            private int _NumeroEconomico;

            /// <summary>
            /// La cantidad total a pagar por concepto de servicios
            /// </summary>
            public decimal TotalServicios
            {
                get { return _TotalServicios; }
                set { _TotalServicios = value; }
            }
            private decimal _TotalServicios;

            /// <summary>
            /// El listado de servicios pendientes de pago
            /// </summary>
            public BindingList<Entities.ServiciosPendientesConductor> ServiciosPendientes
            {
                get { return _ServiciosPendientes; }
                set { _ServiciosPendientes = value; }
            }
            private BindingList<Entities.ServiciosPendientesConductor> _ServiciosPendientes;

            /// <summary>
            /// Estructura con los datos del conductor
            /// </summary>
            public Entities.DatosConductorUnidad DatosConductor
            {
                get { return _DatosConductor; }
                set { _DatosConductor = value; }
            }
            private Entities.DatosConductorUnidad _DatosConductor;

            /// <summary>
            /// La estación donde se consultan los servicios
            /// </summary>
            public int Estacion_ID
            {
                get
                {
                    return _Estacion_ID;
                }
                set
                {
                    _Estacion_ID = value;
                }
            }
            private int _Estacion_ID;

            /// <summary>
            /// El número de unidades que tienen el mismo número económico
            /// </summary>
            /// <returns></returns>
            public int NumeroUnidades()
            {
                return Entities.DatosConductorUnidad.GetNumeroUnidades(this.NumeroEconomico);
            }

            /// <summary>
            /// Obtiene los datos del conductor a partir de su unidad asignada
            /// </summary>
            public void ObtenerDatosDeUnidad()
            {
                this.DatosConductor = Entities.DatosConductorUnidad.Get(NumeroEconomico);
                this.NombreConductor = this.DatosConductor.Conductor;
            }

            /// <summary>
            /// Obtiene los datos del conductor, a partir de su unidad asignada
            /// y la estación donde se consulta la información
            /// </summary>
            public void ObtenerDatosDeUnidadEstacion()
            {
                this.DatosConductor = Entities.DatosConductorUnidad.Get(NumeroEconomico, Estacion_ID);
                this.NombreConductor = this.DatosConductor.Conductor;
			 this._montoDiario = this.DatosConductor.MontoDiario;
            }

            /// <summary>
            /// Obtiene los servicios pendientes de pago del conductor
            /// </summary>
            public void ObtenerServiciosPendientes()
            {
                this.ServiciosPendientes =
                    new BindingList<Entities.ServiciosPendientesConductor>(
                            Entities.ServiciosPendientesConductor.Get(DatosConductor.Conductor_ID, FechaPago)
                        );

                CalcularTotales();
            }

            /// <summary>
            /// Calcula el total a pagar al conductor por concepto de servicios
            /// de transportación
            /// </summary>            
            public void CalcularTotales()
            {
                this.TotalServicios = 0;
                foreach (Entities.ServiciosPendientesConductor sp in ServiciosPendientes)
                {
                    this.TotalServicios += sp.PagoConductor.Value;
                } 
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Formulario para seleccionar unidades
        /// </summary>
        SeleccionarUnidadConductor SeleccionarUnidadesForm = new SeleccionarUnidadConductor();

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new CajaDeServicios_Model();
            base.BindData();
        }

        /// <summary>
        /// Al cambiar la fecha de pago, actualiza el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaPagoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Model.FechaPago = FechaPagoDateTimePicker.Value;
        }

        /// <summary>
        /// Si se oprimió "Enter" en la caja de texto "Unidad"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnidadTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //  Si se tecleo enter
                if (e.KeyData == Keys.Enter)
                {
                    //  Si hay daots en la caja de texto
                    if (!string.IsNullOrEmpty(UnidadTextBox.Text))
                    {
                        //  Si NO son numéricos
                        if (!AppHelper.IsNumeric(UnidadTextBox.Text))
                        {
                            //  Lanzamos error
                            throw new Exception("La unidad debe contener solo datos numéricos");
                        }

                        //  Actualizamos el modelo
                        //  Numero economico
                        Model.NumeroEconomico = Convert.ToInt32(UnidadTextBox.Text);
                        //  Fecha de pago
                        Model.FechaPago = FechaPagoDateTimePicker.Value;

                        //  Obtenemos el número de unidad
                        int numerounidades = Model.NumeroUnidades();

                        //  Si es cero
                        if (numerounidades == 0)
                        {
                            //  No hay unidades con ese número economico
                            //  Lanzamos excepción
                            throw new Exception(string.Format("Unidad {0} no esta asignada", Model.NumeroEconomico));
                        }

                        //  Si es uno, obtenemos los datos de la unidad
                        if (numerounidades == 1)
                        {
                            Model.ObtenerDatosDeUnidad();
                        }

                        //  Si es mayor que uno
                        if (numerounidades > 1)
                        {
                            //  Seleccionar una unidad
                            SeleccionarUnidadesForm.GetUnidades(Model.NumeroEconomico);
                            if (SeleccionarUnidadesForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                //  Obtenemos los datos
                                //  Actualizamos el modelo
                                Model.DatosConductor = SeleccionarUnidadesForm.DatosConductor;
                                Model.NombreConductor = Model.DatosConductor.Conductor;
                            }
                        }

                        //  Obtenemos los servicios pendientes
                        Model.ObtenerServiciosPendientes();

                        //  Calculamos los totales
                        Model.CalcularTotales();

                        //  Actualizamos la información en los controles
                        serviciosPendientesConductorBindingSource.DataSource = Model.ServiciosPendientes;            
                        this.NombreConductorTextBox.Text = Model.NombreConductor;
                        this.TotalServiciosTextBox.Text = string.Format("{0:C}", this.Model.TotalServicios);

                        //  Si no tiene servicios pendientes de pago
                        if (Model.ServiciosPendientes.Count == 0)
                        {
                            //  Informamos al usuario
                            AppHelper.Info(string.Format("El conductor no tiene servicios pendientes para fecha {0:d}.", Model.FechaPago));
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Al hacer clic en "Siguiente", navegamos a la caja de cobro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SiguienteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Se pasa al formulario de caja de cobro
                forms.CajaCobro cajaCobro = new CajaCobro();
                cajaCobro.DoBindData();
                
                //  Configura el pago para los servicios
                cajaCobro.Set_ConductorPago(
                    this.Model.DatosConductor, 
                    this.Model.ServiciosPendientes, 
                    this.Model.TotalServicios,
                    this.FechaPagoDateTimePicker.Value
                );

                //  Cambiamos el formulario actual
                Padre.SwitchForma("CajaCobro", cajaCobro);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Al oprimir "Supr" o "Del" en la tabla de servicios pendientes.
        /// eliminamos el registro del servicio actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiciosPendientesGridView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    ServiciosPendientesGridView.Rows.RemoveAt(ServiciosPendientesGridView.CurrentRow.Index);
                    Model.CalcularTotales();
                    this.TotalServiciosTextBox.Text = string.Format("{0:C}", this.Model.TotalServicios);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
        #endregion

    } // end class
  
} // end namespace
