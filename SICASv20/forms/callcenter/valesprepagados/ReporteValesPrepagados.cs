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
    /// Formulario para el reporte de vales prepagados
    /// </summary>
    public partial class ReporteValesPrepagados : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para el reporte de vales prepagados
        /// </summary>
        public ReporteValesPrepagados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al hacer clic en "Consultar", busca la información de vales
        /// y la muestra en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Declaramos las variables
				 //  Empresa Emita
				 int? empresaEmite_id;

                    //  El folio de cliente
                    int? empresacliente_id;

                    //  El estatus de vale
                    int? estatusvaleprepagado_id;

                    //  Las fechas de creación
                    DateTime fechainicial;
                    DateTime fechafinal;

                    //  Obtenemos los datos de los controles
				empresaEmite_id = DB.GetNullableInt32(this.EmpresaComboBox.SelectedValue);
                    empresacliente_id = DB.GetNullableInt32(this.ClienteComboBox.SelectedValue);
                    estatusvaleprepagado_id = DB.GetNullableInt32(this.EstatusComboBox.SelectedValue);
                    fechainicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                    fechafinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);

                    //  Buscamos los vales
                    List<Entities.Vista_ReporteValesPrepagados> vales =
                        Entities.Vista_ReporteValesPrepagados.Get(
                            empresacliente_id,
                            estatusvaleprepagado_id,
                            fechainicial,
                            fechafinal,
					   empresaEmite_id
                        );

                    //  Ligamos los vales a los controles
                    this.vistaReporteValesPrepagadosBindingSource.DataSource = vales;

                    this.IngresosEgresosCajasReportViewer.RefreshReport();

                }
            );
        }

        /// <summary>
        /// Al cargar el formulario, liga los datos de clientes y estatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReporteValesPrepagados_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.selectEmpresasBindingSource.DataSource =
                        Entities.SelectEmpresas.GetClientes();

				this.selectEmpresasCASCOBindingSource.DataSource = new BindingList<Entities.Empresas>(
					  Entities.Empresas.ReadList(DB.Param("TipoEmpresa_ID", 2)));

                    this.estatusValesPrepagadosBindingSource.DataSource =
                        Entities.SelectEstatusValesPrepagados.Get();
                }
            );
        } // end void

    } // end class

} // end namespace
