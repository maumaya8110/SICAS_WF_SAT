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
    /// Asigna servicios a los conductores
    /// </summary>
    public partial class AsignacionServicios : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de 'AsignacionesServicios'
        /// </summary>
        public AsignacionServicios()
        {
            InitializeComponent();
        }

        private int? _Unidad_ID;

        /// <summary>
        /// El folio de la unidad
        /// </summary>
        public int? Unidad_ID
        {
            get { return _Unidad_ID; }
            set { _Unidad_ID = value; }
        }

        private int _Conductor_ID;

        /// <summary>
        /// El folio del conductor
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private string _Servicio_ID;

        /// <summary>
        /// El numero de servicio
        /// </summary>
        public string Servicio_ID
        {
            get { return _Servicio_ID; }
            set { _Servicio_ID = value; }
        }

        private int? _KilometrajeAnterior;

        /// <summary>
        /// El kilometraje anterior de la unidad
        /// </summary>
        public int? KilometrajeAnterior
        {
            get { return _KilometrajeAnterior; }
            set { _KilometrajeAnterior = value; }
        }

        private decimal _Productividad;

        /// <summary>
        /// La productividad del conductor
        /// </summary>
        public decimal Productividad
        {
            get { return _Productividad; }
            set { _Productividad = value; }
        }

        /// <summary>
        /// El modelo de la caja de servicios
        /// </summary>
        private forms.CajaDeServicios.CajaDeServicios_Model ServiciosModel = new CajaDeServicios.CajaDeServicios_Model();

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            base.BindData();
        }

        /// <summary>
        /// Los datos de la unidad
        /// </summary>
        Entities.DatosConductorUnidad datosUnidad;

        /// <summary>
        /// Consulta los servicios pendientes de pago del conductor
        /// en la base de datos
        /// </summary>
        private void ConsultarServiciosPendientes()
        {
            ServiciosModel.NumeroEconomico = Convert.ToInt32(NumeroEconomicoTextBox.Text);
            ServiciosModel.FechaPago = DB.GetDate();
            ServiciosModel.ObtenerDatosDeUnidad();
            ServiciosModel.ObtenerServiciosPendientes();
            //ServiciosModel.CalcularTotales();
            serviciosPendientesConductorBindingSource.DataSource = ServiciosModel.ServiciosPendientes; 
        }

        /// <summary>
        /// Obtiene los datos del conductor y la unidad
        /// a partir del número económico
        /// </summary>
        private void GetDatosConductorUnidad()
        {
            //  Realizamos las validaciones

            //  Que haya numero economico
            if (string.IsNullOrEmpty(this.NumeroEconomicoTextBox.Text))
            {
                throw new Exception("Debe capturar una unidad");
            }

            //  Que sea numerico
            if (!AppHelper.IsNumeric(this.NumeroEconomicoTextBox.Text))
            { 
                throw new Exception("El número económico debe ser numérico");
            }

            //  Que el usuario tenga una estación única asignada
            if (Sesion.Estacion_ID == null)
            {
                throw new Exception("Se debe tener asignada una estación para utilizar esta opción");
            }
            
            //  Debe de buscarse al conductor operativo
            //  No se hace debido a que en mercados no se busca al conductor operativo
            datosUnidad = Entities.DatosConductorUnidad.GetConductorOperativo(Convert.ToInt32(NumeroEconomicoTextBox.Text), Sesion.Empresa_ID, Sesion.Estacion_ID.Value);
            
            //  Configuramos los datos
            this.Conductor_ID = datosUnidad.Conductor_ID;
            this.Unidad_ID = datosUnidad.Unidad_ID;
            this.KilometrajeAnterior = datosUnidad.Kilometraje;
            this.ConductorTextBox.Text = datosUnidad.Conductor;
            this.KilometrajeAnteriorTextBox.Text = this.KilometrajeAnterior.ToString();

            //  Consultamos los servicios pendientes
            ConsultarServiciosPendientes();

            //  Preparamos la captura del nuevo servicio
            this.Servicio_IDTextBox.Text = "";
            this.Servicio_IDTextBox.Focus();

        } // end void

        /// <summary>
        /// Valida los datos
        /// </summary>
        private void DoValidate()
        { 
            //  Debe tener configurado
            //  todas las propiedades

            if (this.Unidad_ID == 0)
            {
                throw new Exception("Debe capturar una unidad");
            }

            if (this.Conductor_ID == 0)
            {
                throw new Exception("Debe capturar una unidad. La unidad debe tener un conductor asignado.");
            }

            if (String.IsNullOrEmpty(this.Servicio_ID))
            {
                throw new Exception("Debe capturar un servicio");
            }

            if(!DB.Exists("Servicios", DB.Param("Servicio_ID", this.Servicio_ID)))
            {
                throw new Exception("El servicio no existe");
            }

            Entities.Servicios servicio = Entities.Servicios.Read(Servicio_ID);

            if (servicio.Conductor_ID != null)
                AppHelper.ThrowException("El servicio ya ha sido asignado");

            if (servicio.EstatusServicio_ID == 4)
                AppHelper.ThrowException("El servicio ha sido cancelado");
        }

        /// <summary>
        /// Realiza la actualización del servicio en la base de datos
        /// </summary>
        private void ActualizarServicio()
        {
            //  Validar
            DoValidate();

            //  Asignar el servicio
            Entities.Functions.AsignarServicio(this.Servicio_ID, this.Conductor_ID, this.Unidad_ID.Value, DB.GetDate());
            
            //  Clear
            this.Servicio_IDTextBox.Text = string.Empty;
            this.Servicio_IDTextBox.Focus();

            //  Consulta los servicios
            ConsultarServiciosPendientes();

            //  Mensaje
            AppHelper.Info("¡Registro efectuado!");
        }

        /// <summary>
        /// Limpia la forma
        /// </summary>
        private void DoClear()
        {
            datosUnidad = null;
            AppHelper.ClearControl(this);
        }

        /// <summary>
        /// Al hacer enter en la caja de texto 'Numero Economico'
        /// consultamos los datos de la unidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(new AppHelper.HelperDelegate(GetDatosConductorUnidad), this);
            }
        }

        /// <summary>
        /// Al capturar texto en el nuevo kilometraje, solamente permitiremos numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoKilometrajeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }            
        }

        /// <summary>
        /// Solamente permitimos numeros al capturar el código del boleto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Servicio_IDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }            
        }

        /// <summary>
        /// Cada que cambia el texto de código de servicio, actualizamos la variable 'Servicio_ID'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Servicio_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Servicio_IDTextBox.Text))
            {
                this.Servicio_ID = this.Servicio_IDTextBox.Text;
            }            
        }    


        /// <summary>
        /// Al hacer enter en la caja de texto de código de servicio,
        /// mandamos actualizar el servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Servicio_IDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AppHelper.DoMethod(new AppHelper.HelperDelegate(ActualizarServicio), this);
            }            
        }
        
    } // end class

} // end namespace
