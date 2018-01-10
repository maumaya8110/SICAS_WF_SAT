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
    /// Reporte de los servicios (de transportacion terrestre) vendidos
    /// durante la sesión de caja.
    /// </summary>
    public partial class ServiciosDeSesion : Form
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de servicios de sesion
        /// </summary>
        public ServiciosDeSesion()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        /// <summary>
        /// Modelo de la lógica de negocios de la operación de reporte
        /// de servicios de sesion
        /// </summary>
        class ServiciosDeSesion_Model
        {
            #region Properties

            /// <summary>
            /// El listado de servicios de la sesión
            /// </summary>
            public List<Entities.Vista_Servicios> Servicios
            {
                get { return _Servicios; }
                set { _Servicios = value; }
            }
            private List<Entities.Vista_Servicios> _Servicios;

            /// <summary>
            /// El identificador o folio de la sesión de caja
            /// a la cual se consultan los servicios
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
            /// Consulta el listado de servicios vendidos de la sesión de caja
            /// en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.Servicios = Entities.Vista_Servicios.GetVentaBySesion(this.Sesion_ID);
            }

            #endregion

        } // end class ServiciosDeSesion_Model

        /// <summary>
        /// El folio o identificador de sesión de caja a consultar
        /// en el formulario
        /// </summary>
        public int Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }
        private int _Sesion_ID;

        /// <summary>
        /// La variable del modelo de lógica de negocios
        /// </summary>
        private ServiciosDeSesion_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            //  Instancia el modelo
            this.Model = new ServiciosDeSesion_Model();

            //  Configura la sesión
            this.Model.Sesion_ID = this.Sesion_ID;

            //  Realiza la consulta a la base de datos
            this.Model.Consultar();

            //  Muestra los datos consultados en los controles
            this.vista_ServiciosBindingSource.DataSource = this.Model.Servicios;
        }

        /// <summary>
        /// Al cargar la forma liga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiciosDeSesion_Load(object sender, EventArgs e)
        {
            AppHelper.Try
            (
                delegate
                {
                    this.BindData();

                } // end delegate

            ); // end AppHelper.Try

        } // end Servicios de Sesion Load

    } // end class

} // end namespace
