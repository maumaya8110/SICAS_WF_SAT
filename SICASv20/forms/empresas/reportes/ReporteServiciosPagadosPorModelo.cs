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
    /// Formulario que muestra el reporte de servicios pagados por modelo
    /// </summary>
    public partial class ReporteServiciosPagadosPorModelo : baseForm
    {
        public ReporteServiciosPagadosPorModelo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios que contiene las funciones
        /// para llevar a cabo el reporte de servicios pagados
        /// por modelo.
        /// </summary>
        class ReporteServiciosPagadosPorModelo_Model
        {
            /// <summary>
            /// La empresa seleccionada
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
            /// La estación seleccionada
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
            /// Fecha inicial del reporte
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
            /// Fecha final del reporte
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
            /// El listado de servicios pagados
            /// </summary>
            public List<Entities.Vista_ServiciosPagadosPorModelo> ServiciosPagados
            {
                get
                {
                    return _ServiciosPagados;
                }
                set
                {
                    _ServiciosPagados = value;
                }
            }
            private List<Entities.Vista_ServiciosPagadosPorModelo> _ServiciosPagados;

            /// <summary>
            /// El listado de rentas pagadas por modelo
            /// </summary>
            public List<Entities.Vista_RentasPagadasPorModelo> RentasPagadas
            {
                get
                {
                    return _RentasPagadas;
                }
                set
                {
                    _RentasPagadas = value;
                }
            }
            private List<Entities.Vista_RentasPagadasPorModelo> _RentasPagadas;

            /// <summary>
            /// Consulta los servicios pagados en la base de datos
            /// </summary>
            private void ConsultarServiciosPagados()
            {
                this.ServiciosPagados = Entities.Vista_ServiciosPagadosPorModelo.Get(
                        this.FechaInicial,
                        this.FechaFinal,
                        this.Empresa_ID,
                        this.Estacion_ID
                    );
            }

            /// <summary>
            /// Consulta las rentas pagadas en la base de datos
            /// </summary>
            private void ConsultarRentasPagadas()
            {
                this.RentasPagadas = Entities.Vista_RentasPagadasPorModelo.Get(
                        this.FechaInicial,
                        this.FechaFinal,
                        this.Empresa_ID,
                        this.Estacion_ID
                    );
            }

            /// <summary>
            /// Realiza las consultas de servicios pagados y rentas pagadas en
            /// la base de datos
            /// </summary>
            public void Consultar()
            {
                ConsultarServiciosPagados();
                ConsultarRentasPagadas();
            }
        } // end class

        #region Properties

        /// <summary>
        /// El modelo de lógica de negocios a usar en la forma
        /// </summary>
        private ReporteServiciosPagadosPorModelo_Model Model;

        #endregion


        #region Methods

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReporteServiciosPagadosPorModelo_Model();
            this.Model.Empresa_ID = Sesion.Empresa_ID;
            this.Model.Estacion_ID = Sesion.Estacion_ID;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
        }

        #endregion

        /// <summary>
        /// Maneja el evento "ValueChanged" del control "FechaInicialDateTimePicker"
        /// </summary>
        /// <param name="sender">El control "FechaInicialDateTimePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
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
        /// Maneja el evento "ValueChanged" del control "FechaFinalDateTimePicker"
        /// </summary>
        /// <param name="sender">El control "FechaFinalDateTimePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
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
        /// Maneja el evento "Click" del control "AceptarButton"
        /// </summary>
        /// <param name="sender">El control "AceptarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Consultar();
                    this.vista_ServiciosPagadosPorModeloBindingSource.DataSource = this.Model.ServiciosPagados;
                    this.vista_RentasPagadasPorModeloBindingSource.DataSource = this.Model.RentasPagadas;
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ExportarButton"
        /// </summary>
        /// <param name="sender">El control "ExportarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.ExportDataGridViewExcel(this.vista_ServiciosPagadosPorModeloDataGridView, this);
                }
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ExcelRentasButton"
        /// </summary>
        /// <param name="sender">El control "ExcelRentasButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ExcelRentasButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.ExportDataGridViewExcel(this.vista_RentasPagadasPorModeloDataGridView, this);
                }
            );
        }

    } // end class
} // end namespace
