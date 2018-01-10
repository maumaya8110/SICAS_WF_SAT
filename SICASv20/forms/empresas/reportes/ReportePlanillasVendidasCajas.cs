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
    /// Formulario que muestra el reporte de planilas fiscales vendidas por caja
    /// </summary>
    public partial class ReportePlanillasVendidasCajas : baseForm
    {
        public ReportePlanillasVendidasCajas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// La variable del modelo de lógica de negocios.
        /// </summary>
        private ReportePlanillasVendidasCajas_Model Model;

        /// <summary>
        /// Modelo de lógica de negocios, contiene las funciones necesarias
        /// para realizar el reporte de planillas fiscales
        /// </summary>
        class ReportePlanillasVendidasCajas_Model
        {
            /// <summary>
            /// Listado de cajas activas en el sistema
            /// </summary>
            public List<Entities.SelectCajasActivas> Cajas
            {
                get
                {
                    return _Cajas;
                }
                set
                {
                    _Cajas = value;
                }
            }
            private List<Entities.SelectCajasActivas> _Cajas;

            /// <summary>
            /// El listado de planillas fiscales
            /// </summary>
            public List<Entities.Vista_ReportePlanillasVendidas> Planillas
            {
                get { return _Planillas; }
                set { _Planillas = value; }
            }
            private List<Entities.Vista_ReportePlanillasVendidas> _Planillas;

            /// <summary>
            /// Caja seleccionada. En caso de ser "Null", se consultan todas las cajas
            /// </summary>
            public int? Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }
            private int? _Caja;

            /// <summary>
            /// La fecha inicial a consultar en el reporte
            /// </summary>
            public DateTime FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }
            private DateTime _FechaInicial;

            /// <summary>
            /// La fecha final a consultar en el reporte
            /// </summary>
            public DateTime FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }
            private DateTime _FechaFinal;

            /// <summary>
            /// Consulta las cajas en la base de datos
            /// </summary>
            public void ConsultarCajas()
            {
                this.Cajas = Sesion.Cajas;
            }

            /// <summary>
            /// Consulta las planillas fiscales
            /// </summary>
            public void ConsultarPlanillas()
            {
                this.Planillas = Entities.Vista_ReportePlanillasVendidas.Get(this.Caja, this.FechaInicial, this.FechaFinal);
            }
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReportePlanillasVendidasCajas_Model();
            this.Model.ConsultarCajas();
            this.selectCajasActivasBindingSource.DataSource = Model.Cajas;

            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Caja = DB.GetNullableInt32(this.CajasComboBox.SelectedValue);
                    this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                    this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                    this.Model.ConsultarPlanillas();
                    this.Vista_ReportePlanillasVendidasBindingSource.DataSource = this.Model.Planillas;
                    this.reportViewer1.RefreshReport();
                },
                this
            );
        }
    } // end class ReportePlanillasVendidasCajas

} // end namespace SICASv20.forms
