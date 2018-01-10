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
    /// Reporte consolidado de ventas de servicios
    /// </summary>
    public partial class ConsolidadoDeVentasServicios : Form
    {
        /// <summary>
        /// Crea una nueva instancia del reporte consolidado de ventas de servicios
        /// de transportación terrestre
        /// </summary>
        public ConsolidadoDeVentasServicios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de la lógica de negocios del reporte
        /// consolidado de ventas de servicios
        /// </summary>
        class ConsolidadoDeVentasServicios_Model
        {
            /// <summary>
            /// La fecha a consultar
            /// </summary>
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }
            private DateTime _Fecha;

            /// <summary>
            /// Tabla de datos del flujo monetario
            /// en la fecha seleccionada
            /// </summary>
            public DataTable FlujoMonetario
            {
                get { return _FlujoMonetario; }
                set { _FlujoMonetario = value; }
            }
            private DataTable _FlujoMonetario;

            /// <summary>
            /// Tabla de datos de las ventas
            /// de la fecha seleccionada
            /// </summary>
            public DataTable Ventas
            {
                get { return _Ventas; }
                set { _Ventas = value; }
            }
            private DataTable _Ventas;

            /// <summary>
            /// Realiza la consulta de la información
            /// </summary>
            public void Consultar()
            {
                //  Obtenemos las ventas
                this.Ventas = Entities.Vista_VentasServiciosDeSesion_Consolidado.GetDataTableByFecha(this.Fecha);

                //  Obtenemos el flujo de caja
                this.FlujoMonetario = Entities.Vista_FlujoMonetarioDeServiciosDeSesion_Consolidado.GetDataTableByFecha(this.Fecha);
            }
        } // end class ConsolidadoDeVentasServicios_Model

        /// <summary>
        /// Modelo de lógica de negocios a utilizar en el formulario
        /// </summary>
        private ConsolidadoDeVentasServicios_Model Model;

        /// <summary>
        /// La fecha seleccionada para visualizar
        /// </summary>
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private DateTime _Fecha;

        /// <summary>
        /// Al cargar la forma, consulta y muestra la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsolidadoDeVentasServicios_Load(object sender, EventArgs e)
        {
            AppHelper.Try
            (
                delegate
                {
                    //  Instanciamos el modelo
                    this.Model = new ConsolidadoDeVentasServicios_Model();

                    //  Configuramos la fecha
                    this.Model.Fecha = this.Fecha;

                    //  Consultamos la información
                    this.Model.Consultar();

                    //  Desplegamos la información
                    this.Vista_FlujoMonetarioDeServiciosDeSesion_ConsolidadoBindingSource.DataSource = Model.FlujoMonetario;
                    this.Vista_VentasServiciosDeSesion_ConsolidadoBindingSource.DataSource = Model.Ventas;

                    //  Refrescamos el reporte
                    this.reportViewer1.RefreshReport();

                } // end delegate 

            ); // end AppHelper.Try

        } // end Load

    } // end class

} // end namespace