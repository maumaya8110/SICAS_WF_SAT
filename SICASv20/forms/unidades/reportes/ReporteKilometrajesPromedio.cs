using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteKilometrajesPromedio : baseForm
    {
        #region Model

        public class ReporteKilometrajesPromedio_Model
        {

            #region Constructors

            public ReporteKilometrajesPromedio_Model()
            {
                this.Empresas = Sesion.EmpresasTodas;
                this.Estaciones = Sesion.EstacionesTodas;
                this.Usuario_ID = Sesion.Usuario_ID;
            }

            #endregion


            #region Properties

            /// <summary>
            /// El listado de empresas disponible
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas { get; set; }

            /// <summary>
            /// El listado de estaciones disponible
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones { get; set; }

            /// <summary>
            /// El lista de kilometrajes resultado de la consulta
            /// </summary>
            public DataTable Kilometrajes { get; set; }

            /// <summary>
            /// La Empresa seleccionada
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La Estacion seleccionada
            /// </summary>
            public int? Estacion_ID { get; set; }

            /// <summary>
            /// El usuario que solicita la información
            /// </summary>
            private string Usuario_ID { get; set; }
            
            /// <summary>
            /// La fecha inicial del rango de fechas solicitado
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final del rango de fechas solicitado
            /// </summary>
            public DateTime FechaFinal { get; set; }

            #endregion


            #region Methods

            /// <summary>
            /// Busca la información en la base de datos
            /// </summary>
            public void Buscar()
            {
                //  Verificamos que las fechas esten correctas
                if (this.FechaFinal < this.FechaInicial)
                    throw new Exception("La fecha final debe ser mayor a la fecha inicial");

                //  Obtenemos los datos y los asignamos a la propiedad
                this.Kilometrajes =
                    Entities.Vista_KilometrajesPromedio.GetDataTable(
                        this.Usuario_ID,
                        this.Empresa_ID,
                        this.Estacion_ID,
                        this.FechaInicial,
                        this.FechaFinal
                    );
            }

            #endregion				
				
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Crea un objeto de Reporte de Kilometrajes Promedio
        /// </summary>
        public ReporteKilometrajesPromedio()
        {
            InitializeComponent();

        } // end ReporteKilometrajesPromedio

        #endregion

        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ReporteKilometrajesPromedio_Model Model { get; set; }

        #endregion

        #region Methods

        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ReporteKilometrajesPromedio_Model();

            //  Ligamos los datos de empresas y estaciones
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;

            //  Configuramos los datos al modelo
            this.Model.Empresa_ID = DB.GetNullableInt32(this.EmpresasComboBox.SelectedValue);
            this.Model.Estacion_ID = DB.GetNullableInt32(this.EstacionesComboBox.SelectedValue);
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDatePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDatePicker.Value);

            base.BindData();
        }

        #endregion

        #region Events

        /// <summary>
        /// Actualiza la empresa con el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Empresa_ID = DB.GetNullableInt32(this.EmpresasComboBox.SelectedValue);
                }
            );
        }

        /// <summary>
        /// Actualiza la estación con el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Estacion_ID = DB.GetNullableInt32(this.EstacionesComboBox.SelectedValue);
                }
            );
        }

        /// <summary>
        /// Actualiza la fecha inicial con el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDatePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDatePicker.Value);
                }
            );
        }

        /// <summary>
        /// Actualiza la fecha final con el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDatePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDatePicker.Value);
                }
            );
        }

        /// <summary>
        /// Busca los datos en el sistema y los despliega en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Buscar();
                    this.vista_KilometrajesPromedioBindingSource.DataSource = this.Model.Kilometrajes;
                },
                this
            );
        }

        /// <summary>
        /// Exporta la información de la tabla a Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_KilometrajesPromedioDataGridView, this);
        }

        #endregion

    } // end class ReportekilometrajesPromedio : baseForm
} // end namespace
