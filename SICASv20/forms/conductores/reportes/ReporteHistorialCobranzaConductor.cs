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
    /// Formulario que muestra el reporte de historial de cobranza
    /// de un conductor
    /// </summary>
    public partial class ReporteHistorialCobranzaConductor : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte
        /// de historial de cobranza del conductor
        /// </summary>
        public ReporteHistorialCobranzaConductor()
        {
            InitializeComponent();
        }

        #region Model

        /// <summary>
        /// Modela la lógica de negocios
        /// del reporte de historial de cobranza
        /// del conductor
        /// </summary>
        class ReporteHistorialCobranzaConductor_Model
        {
            /// <summary>
            /// El folio ID del conductor a consultar el historial
            /// </summary>
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }
            private int _Conductor_ID;

            /// <summary>
            /// Listado de registros de historial de cobranza del conductor
            /// </summary>
            public List<Entities.Vista_HistorialCobranzaConductores> HistorialCobranza
            {
                get { return _HistorialCobranza; }
                set { _HistorialCobranza = value; }
            }
            private List<Entities.Vista_HistorialCobranzaConductores> _HistorialCobranza;

            /// <summary>
            /// Consulta el historial de cobranza del conductor en la base de datos
            /// </summary>
            public void ConsultarHistorial()
            {
                this.HistorialCobranza =
                    Entities.Vista_HistorialCobranzaConductores.Get(
                        this.Conductor_ID
                    );
            }
        } 
        #endregion

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        private ReporteHistorialCobranzaConductor_Model Model;

        /// <summary>
        /// El ID del conductor a consultar el historial
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }
        private int _Conductor_ID;

        /// <summary>
        /// Liga los datos a los controles. Consulta el historial y lo muestra en pantalla
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ReporteHistorialCobranzaConductor_Model();

            //  Configuramos el conductor ID
            this.Model.Conductor_ID = this.Conductor_ID;

            //  Consultamos los datos
            this.Model.ConsultarHistorial();

            //  Ligamos los datos a los controles
            this.Vista_HistorialCobranzaConductoresBindingSource.DataSource = this.Model.HistorialCobranza;

            //  Actualizamos el reporte
            this.HistorialConductorReportViewer.RefreshReport();
            base.BindData();
        }

    } // end class

} // end namespace
