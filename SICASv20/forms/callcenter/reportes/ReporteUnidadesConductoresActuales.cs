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
    /// Formulario de reporte de unidades y conductores actuales,
    /// consulta unidades y conductores a partir de numero economico
    /// de la unidad o placas
    /// </summary>
    public partial class ReporteUnidadesConductoresActuales : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de unidades y conductores actuales
        /// </summary>
        public ReporteUnidadesConductoresActuales()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clase que modela la lógica de negocios
        /// para el reporte de unidades y conductores actuales
        /// </summary>
        class ReporteUnidadesConductoresActuales_Model
        {
            /// <summary>
            /// Crea una nueva instancia del modelo de lógica de negocios
            /// </summary>
            public ReporteUnidadesConductoresActuales_Model()
            { 
            }

            /// <summary>
            /// El número economico a consultar
            /// </summary>
            public int? NumeroEconomico
            { 
                get { return _NumeroEconomico;}
                set { _NumeroEconomico = value; }
            }
            private int? _NumeroEconomico;

            /// <summary>
            /// Las placas a consultar
            /// </summary>
            public string Placas
            {
                get { return _Placas; }
                set { _Placas = value; }
            }
            private string _Placas;

            /// <summary>
            /// El listado consultado
            /// </summary>
            public List<Entities.Vista_ConductoresUnidadesActuales> ConductoresUnidades
            {
                get { return _ConductoresUnidades; }
                set { _ConductoresUnidades = value; }
            }
            private List<Entities.Vista_ConductoresUnidadesActuales> _ConductoresUnidades;

            /// <summary>
            /// Consulta los datos de conductores y unidades
            /// en la base de datos
            /// </summary>
            public void ConsultarConductoresUnidades()
            {
                this.ConductoresUnidades = Entities.Vista_ConductoresUnidadesActuales.Get(this.NumeroEconomico, this.Placas);
            }
        }

        /// <summary>
        /// Modelo de la lógica de negocios a utilizar en la forma
        /// </summary>
        private ReporteUnidadesConductoresActuales_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReporteUnidadesConductoresActuales_Model();
            base.BindData();
        }
        
        /// <summary>
        /// Al hacer clic en "Buscar", realiza la búsqueda en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {

                    Model.NumeroEconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);
                    Model.Placas = this.PlacasTextBox.Text;
                    Model.ConsultarConductoresUnidades();
                    this.vista_ConductoresUnidadesActualesBindingSource.DataSource = Model.ConductoresUnidades;

                    if (this.Model.ConductoresUnidades.Count == 0)
                    {
                        AppHelper.ThrowException("Unidad {0} no existe o no tiene asignación", Model.NumeroEconomico);
                    }

                }, 
                this
            );
        }

    } // end class

} // end namespace
