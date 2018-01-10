using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteHistorialUnidadesConductores : baseForm
    {
        #region Model

        public class ReporteHistorialUnidadesConductores_Model
        {

            #region Constructors

            public ReporteHistorialUnidadesConductores_Model()
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
            public DataTable Historial { get; set; }

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
            /// El Numero Economico a buscar
            /// </summary>
            public Int32? NumeroEconomico { get; set; }

            #endregion


            #region Methods

            /// <summary>
            /// Busca la información en la base de datos
            /// </summary>
            public void Buscar()
            {
                this.Historial =
                    Entities.Vista_HistorialConductoresUnidades.GetDataTable(
                        this.Usuario_ID,
                        this.Empresa_ID,
                        this.Estacion_ID,
                        this.NumeroEconomico
                    );
            }

            #endregion				
				
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Crea un objeto de Reporte de Kilometrajes Promedio
        /// </summary>
        public ReporteHistorialUnidadesConductores()
        {
            InitializeComponent();

            //  Nos aseguramos que solo se tecleen numeros en la unidad
            AppHelper.AddTextBoxOnlyNumbersValidation(ref this.NumeroEconomicoTextBox);

        } // end ReporteKilometrajesPromedio

        #endregion

        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ReporteHistorialUnidadesConductores_Model Model { get; set; }

        #endregion

        #region Methods

        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ReporteHistorialUnidadesConductores_Model();

            //  Ligamos los datos de empresas y estaciones
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;

            //  Configuramos los datos al modelo
            this.Model.Empresa_ID = DB.GetNullableInt32(this.EmpresasComboBox.SelectedValue);
            this.Model.Estacion_ID = DB.GetNullableInt32(this.EstacionesComboBox.SelectedValue);
            this.Model.NumeroEconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);

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
                    this.vista_HistorialConductoresUnidadesBindingSource.DataSource = this.Model.Historial;
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
            AppHelper.ExportDataGridViewExcel(this.vista_HistorialConductoresUnidadesDataGridView, this);
        }
        
        /// <summary>
        /// Actualiza el numero economico en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NumeroEconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);
                }
            );
        }

        #endregion

    } // end class ReportekilometrajesPromedio : baseForm
} // end namespace
