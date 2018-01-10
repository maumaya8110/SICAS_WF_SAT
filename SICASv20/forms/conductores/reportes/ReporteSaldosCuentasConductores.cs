/*
 * ReporteSaldosCuentasConductores
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 * 
 * Se eliminó el método GetEstaciones()
 * Se eliminó el evento EmpresasComboBox_SelectionChangeCommited()
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SICASv20.forms
{

    /// <summary>
    /// Formulario que muestra el reporte de saldos de conductores
    /// </summary>
    public partial class ReporteSaldosCuentasConductores : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de saldos de cuenta conductores
        /// </summary>
        public ReporteSaldosCuentasConductores()
        {
            InitializeComponent();
        }


        /// <summary>
        /// El ID (folio) del conductor a mostrar el reporte
        /// </summary>
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }
        private int _Conductor_ID;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            empresasBindingSource.DataSource = Sesion.EmpresasTodas;

            estacionesBindingSource.DataSource = Sesion.EstacionesTodas;

            base.BindData();
        }

        /// <summary>
        /// Consulta la base de datos y muestra los resultados del reporte
        /// </summary>
        private void DoQuery()
        {
            //  Obtenemos los parámetros del reporte

            //  El numero economico de la unidad asignada al conductor
            int? numeroeconomico = DB.GetNullableInt32(UnidadTextBox.Text);

            //  El nombre del conductor
            string nombre = String.IsNullOrEmpty(ConductorTextBox.Text) ? null : ConductorTextBox.Text;

            //  La empresa operativa
            int? empresa_id = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);

            //  La estación operativa
            int? estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);

		   //Se valida que introduzca por lo menos un filtro --GMD
		  if (!numeroeconomico.HasValue && String.IsNullOrEmpty(nombre) && !empresa_id.HasValue && !estacion_id.HasValue && !ConductorEnContratoCheckBox.Checked)
		  {
			  MessageBox.Show("Es necesario proporcionar al menos un filtro para realizar la consulta.", "Atención...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			  return;
		  }

            //  Obtenemos el reporte y lo ligamos a los controles
            bool activo = ConductorEnContratoCheckBox.Checked;
            this.Reporte_SaldosCuentasConductoresBindingSource.DataSource = 
                Entities.Vista_SaldosConductores.GetDataTable(empresa_id, estacion_id, activo, numeroeconomico, nombre, Sesion.Usuario_ID);
            
            //  Configuramos el reporte
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SICASv20.reports.conductores.Reporte_SaldosConductores.rdlc";

            //  Asignamos los datos
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(
                new ReportDataSource(
                    "SaldosCuentasConductores_DataSet", 
                    this.Reporte_SaldosCuentasConductoresBindingSource
                )
            );

            //  Actualizamosl la interfaz de usuario
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Consulta el reporte y lo muestra en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(DoQuery, this);
        }

        /// <summary>
        /// Al seleccionar un elemento del reporte
        /// navega por el mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportViewer1_Drillthrough(object sender, Microsoft.Reporting.WinForms.DrillthroughEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Obtenemos los parámetros
                    ReportParameterInfoCollection parameters = e.Report.GetParameters();

                    //  Obtenemos ticket_id
                    int conductor_id = Convert.ToInt32(parameters["Conductor_ID"].Values[0]);
                    int cuenta_id = Convert.ToInt32(parameters["Cuenta_ID"].Values[0]);

                    //  Obtenemos los DataSources
                    //  Obtenemos los registros de cuentaCajas
                    List<Entities.Vista_CuentaConductores> cuentaconductores =
                        Entities.Vista_CuentaConductores.Get(conductor_id, cuenta_id);

                    //  Obtenemos el local report
                    LocalReport localReport = (LocalReport)e.Report;

                    //  Le asignamos las datasources
                    localReport.DataSources.Clear();
                    localReport.DataSources.Add(
                        new ReportDataSource(
                            "ReporteCuentaConductores_DataSet",
                            cuentaconductores
                        )
                    );

                    //  Refrescamos el reporte
                    localReport.Refresh();

                } // End delegate
            ); // End method
        }
    } // end class

} // end namespace
