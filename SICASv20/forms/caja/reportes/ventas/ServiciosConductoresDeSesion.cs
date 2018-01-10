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
    /// Reporte de los servicios pagados directamente a los conductores
    /// a partir de la sesión actual de caja
    /// </summary>
    public partial class ServiciosConductoresDeSesion : Form
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de servicios de conductores
        /// de la sesión
        /// </summary>
        public ServiciosConductoresDeSesion()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        /// <summary>
        /// Modelo de la lógica de negocios para la operación del reporte
        /// de servicios de conductores de la sesión
        /// </summary>
        class ServiciosDeSesion_Model
        {
            #region Properties

            /// <summary>
            /// La lista de servicios de la sesión
            /// </summary>
            public List<Entities.Vista_Servicios> Servicios
            {
                get { return _Servicios; }
                set { _Servicios = value; }
            }
            private List<Entities.Vista_Servicios> _Servicios;

            /// <summary>
            /// El identificador o folio de la sesión
            /// </summary>
            public int Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }
            private int _Sesion_ID;

            #endregion

            #region Methods

            /// <summary>
            /// Consulta los datos de los servicios
            /// en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.Servicios = Entities.Vista_Servicios.GetServiciosConductorBySesion(this.Sesion_ID);
            }
            #endregion
        }

        /// <summary>
        /// El folio o identificador de la sesión
        /// a utilizar conla forma
        /// </summary>
        public int Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }
        private int _Sesion_ID;

        /// <summary>
        /// La variable de modelo de lógica de negocios
        /// a utilizar en la forma
        /// </summary>
        private ServiciosDeSesion_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ServiciosDeSesion_Model();

            //  Configuramos la sesión
            this.Model.Sesion_ID = this.Sesion_ID;

            //  Consultamos los datos
            this.Model.Consultar();

            //  Mostramos los datos
            this.vista_ServiciosBindingSource.DataSource = this.Model.Servicios;
        }

        /// <summary>
        /// Al cargar la forma ligamos los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiciosConductoresDeSesion_Load(object sender, EventArgs e)
        {
            AppHelper.Try
            (
                delegate
                {
                    this.BindData();

                } // end delegate

            ); // end AppHelper.Try

        } // end Load

    } // end class

} // end namespace
