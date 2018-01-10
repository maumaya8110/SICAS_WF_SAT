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
    /// Formulario para mostrar los movimientos de recaudación,
    /// por fechas
    /// </summary>
    public partial class ReporteMovimientosRecaudacionPorFechas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de reporte de movmientos
        /// de recaudación
        /// </summary>
        public ReporteMovimientosRecaudacionPorFechas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios del reporte de movimientos de recaudación
        /// por fechas
        /// </summary>
        class ReporteMovimientosRecaudacionPorFechas_Model
        {
            /// <summary>
            /// Almacena los registros de movimientos de recaudación
            /// </summary>
            public DataTable MovimientosRecaudacion { get; set; }

            /// <summary>
            /// La estación a consultar
            /// </summary>
            public int? Estacion_ID { get; set; }

            /// <summary>
            /// La empresa a consultar
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La fecha a consultar
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final a consultar
            /// </summary>
            public DateTime FechaFinal { get; set; }

            /// <summary>
            /// El usuario a consultar
            /// </summary>
            public string Usuario_ID { get; set; }

            /// <summary>
            /// Consulta los movimientos en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.MovimientosRecaudacion = Entities.Vista_MovimientosRecaudacionSesion.GetDataTable(
                    this.Empresa_ID,
                    this.Estacion_ID,
                    this.FechaInicial,
                    this.FechaFinal,
                    this.Usuario_ID
                );
            }
        } // end class

        /// <summary>
        /// El modelo de lógica de neogocios para las operaciones
        /// </summary>
        private ReporteMovimientosRecaudacionPorFechas_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Configura las empresas y estaciones
            this.selectEmpresasBindingSource.DataSource = Sesion.EmpresasTodas;
            this.selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;

            //  Instancia el modelo
            this.Model = new ReporteMovimientosRecaudacionPorFechas_Model();

            //  Actualizamos los datos del modelo
            this.Model.Usuario_ID = Sesion.Usuario_ID;
            this.Model.Empresa_ID = ((Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem).Empresa_ID;
            this.Model.Estacion_ID = ((Entities.SelectEstaciones)this.EstacionesComboBox.SelectedItem).Estacion_ID;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);            

            base.BindData();
        }

        /// <summary>
        /// Exporta la información a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    AppHelper.ExportDataGridViewExcel(this.vista_MovimientosRecaudacionSesionDataGridView, this);
                },
                this
            );
        }

        /// <summary>
        /// Actualiza la empresa en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Empresa_ID = ((Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem).Empresa_ID;
                }
            );
        }

        /// <summary>
        /// Actualiza la estación en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Estacion_ID = ((Entities.SelectEstaciones)this.EstacionesComboBox.SelectedItem).Estacion_ID;
                }
            );
        }

        /// <summary>
        /// Actualiza la fecha inicial en el modelo
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
        /// Actualiza la fecha final en el modelo
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
        /// Consulta la información y la muestra en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Consulta la información
                    this.Model.Consultar();

                    //  La muestra en pantalla
                    this.vista_MovimientosRecaudacionSesionBindingSource.DataSource = this.Model.MovimientosRecaudacion;
                },
                this
            );
        } // end void
    } // end class
} // end namespace
