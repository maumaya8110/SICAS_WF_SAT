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
	/// Formulario para desplegar el reporte de tickets
	/// </summary>
	public partial class ReporteTicketsDeSesion : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia del reporte de tickets
		/// de sesión
		/// </summary>
		public ReporteTicketsDeSesion()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Liga los datos y ejecuta las operaciones iniciales
		/// necesarias
		/// </summary>
		public override void BindData()
		{
			Entities.Sesiones sesion_aux = Entities.Sesiones.GetUltimaSesionPorUsuarioCaja(Sesion.Usuario_ID, Sesion.Caja_ID);
			reporteTicketsCuentaConductorBindingSource.DataSource = Entities.Vista_TicketsDeSesion.GetDataTable(sesion_aux.Sesion_ID, null);
			this.reportViewer1.RefreshReport();
			base.BindData();
		}

		/// <summary>
		/// Al hacer clic en un control que tenga un "Action"
		/// del tipo "Jump to Report"
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
				    int ticket_id = Convert.ToInt32(parameters["Ticket_ID"].Values[0]);

				    //  Obtenemos los DataSources
				    //  Obtenemos los registros de cuentaCajas
				    List<Entities.Vista_CuentaCajas> cuentaCajas =
					   Entities.Vista_CuentaCajas.Get(ticket_id);

				    //  Obtenemos los registros de cuentaConductores
				    List<Entities.Vista_CuentaConductores> cuentaConductores =
					   Entities.Vista_CuentaConductores.Get(ticket_id);

				    //  Obtenemos el local report
				    LocalReport localReport = (LocalReport)e.Report;

				    //  Le asignamos las datasources
				    localReport.DataSources.Clear();
				    localReport.DataSources.Add(
					   new ReportDataSource(
						  "Vista_CuentaCajasDataSet",
						  cuentaCajas
					   )
				    );

				    localReport.DataSources.Add(
					   new ReportDataSource(
						  "Vista_CuentaConductoresDataSet",
						  cuentaConductores
					   )
				    );

				    //  Refrescamos el reporte
				    localReport.Refresh();

			    } // end delegate

			); // end method

		} // end void

	} // end class

} // end namespace