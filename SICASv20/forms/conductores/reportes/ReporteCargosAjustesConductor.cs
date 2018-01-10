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
    /// Formulario para mostrar el registro de cargos y ajustes efectuados
    /// a los conductores
    /// </summary>
    public partial class ReporteCargosAjustesConductor : baseForm
    {
        /// <summary>
        /// Modela la lógica de negocios del reporte de cargos y ajustes efectuados
        /// a los conductores
        /// </summary>
        class ReporteCargosAjustesConductor_Model
        {
            /// <summary>
            /// El listado de cargos y ajustes
            /// </summary>
            public List<Entities.Vista_CuentaConductores> CargosAjustes { get; set; }

            /* LOS PARAMETROS */

            /// <summary>
            /// La empresa a buscar
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La estación a buscar
            /// </summary>
            public int? Estacion_ID { get; set; }

            /// <summary>
            /// La fecha inicial a consultar
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final a buscar
            /// </summary>
            public DateTime FechaFinal { get; set; }

            /// <summary>
            /// Consulta la información en la base de datos
            /// </summary>
            public void ConsultarCargosAjustes()
            {
                this.CargosAjustes = Entities.Vista_CuentaConductores.Get(Empresa_ID, Estacion_ID, FechaInicial, FechaFinal);
            }
        }

        /// <summary>
        /// Crea una nueva instancia del reporte de cargos y ajustes de conductores
        /// </summary>
        public ReporteCargosAjustesConductor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        ReporteCargosAjustesConductor_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Liga las empreas y estaciones
            this.empresasBindingSource.DataSource = Sesion.EmpresasTodas;
            this.estacionesBindingSource.DataSource = Sesion.EstacionesTodas;

            //  Instanciamos el modelo
            this.Model = new ReporteCargosAjustesConductor_Model();

            //  Obtenemos las variables de los controles
            this.Model.Empresa_ID = ((Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem).Empresa_ID;
            this.Model.Estacion_ID = ((Entities.SelectEstaciones)this.EstacionesComboBox.SelectedItem).Estacion_ID;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            
            base.BindData();
        }

        /// <summary>
        /// Consulta la información de cargos y ajustes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.ConsultarCargosAjustes();
                    this.vista_CuentaConductoresBindingSource.DataSource = this.Model.CargosAjustes;
                }
            );
        }

        /// <summary>
        /// Exporta la información a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_CuentaConductoresDataGridView, this);
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
                
    } // end class
} // end namespace
