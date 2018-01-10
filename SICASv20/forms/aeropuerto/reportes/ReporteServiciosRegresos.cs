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
    /// Formulario que consulta y muestra en pantalla el reporte
    /// de Servicios de Regreso
    /// </summary>
    public partial class ReporteServiciosRegresos : baseForm
    {
        /// <summary>
        /// Crea una instancia de la clase de reporte de servicios
        /// </summary>
        public ReporteServiciosRegresos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de la lógica de negocios
        /// para el reporte de servicios de regreso
        /// </summary>
        class ReporteServiciosRegresos_Model
        {
            /// <summary>
            /// Listado de Servicios de Regreso
            /// </summary>
            public List<Entities.Vista_ServiciosRegresos> ServiciosRegresos
            {
                get { return _ServiciosRegresos; }
                set { _ServiciosRegresos = value; }
            }
            private List<Entities.Vista_ServiciosRegresos> _ServiciosRegresos;

            /// <summary>
            /// La empresa a consultar los servicios de regreso
            /// </summary>
            public int? Empresa_ID
            {
                get
                {
                    return _Empresa_ID;
                }

                set
                {
                    _Empresa_ID = value;
                }
            }
            private int? _Empresa_ID;

            /// <summary>
            /// Determina la estación parámetro para la consulta
            /// </summary>
            public int? Estacion_ID
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
            private int? _Estacion_ID;

            /// <summary>
            /// Representa el parámetro de fecha inicial
            /// para la consulta
            /// </summary>
            public DateTime FechaInicial
            {
                get
                {
                    return _FechaInicial;
                }

                set
                {
                    _FechaInicial = value;
                }
            }
            private DateTime _FechaInicial;

            /// <summary>
            /// Representa el parámetro de fecha final para la consulta
            /// </summary>
            public DateTime FechaFinal
            {
                get
                {
                    return _FechaFinal;
                }

                set
                {
                    _FechaFinal = value;
                }
            }
            private DateTime _FechaFinal;

            /// <summary>
            /// Realiza la consulta a la base de datos
            /// </summary>
            public void Consultar()
            {
                this.ServiciosRegresos = Entities.Vista_ServiciosRegresos.Get(
                    this.FechaInicial,
                    this.FechaFinal,
                    this.Empresa_ID,
                    this.Estacion_ID
                );
            }
        } // end class

        //  El modelo de la lógica de negocios
        private ReporteServiciosRegresos_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ReporteServiciosRegresos_Model();

            //  Configuramos los parámetros
            this.Model.Empresa_ID = Sesion.Empresa_ID;
            this.Model.Estacion_ID = Sesion.Estacion_ID;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            base.BindData();
        }

        /// <summary>
        /// Al cambiar el valor de la fecha inicial,
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Al cambiar el valor de la fecha final,
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Realiza la consulta a la base de datos
        /// y muestra los resultados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Consultar();
                    this.vista_ServiciosRegresosBindingSource.DataSource = this.Model.ServiciosRegresos;
                },
                this
            );
        }

        /// <summary>
        /// Exporta los datos consultados a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    AppHelper.ExportDataGridViewExcel(this.vista_ServiciosRegresosDataGridView, this);
                },
                this
            );
        } // end ExportarButton_Click

    } // end class

} // end namespace
