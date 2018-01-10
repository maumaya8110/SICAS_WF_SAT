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
	/// Formulario que muestra el reporte de ingresos y egresos de caja.
	/// </summary>
	public partial class IngresosEgresosCajasPorFechas : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia de la clase <see cref="IngresosEgresosCajasPorFechas"/>
		/// </summary>
		public IngresosEgresosCajasPorFechas()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Proceso llevado a cabo para cargar datos y preparar la forma
		/// </summary>
		public override void BindData()
		{
			selectCajasActivasBindingSource.DataSource = Sesion.CajasActivasPorUsuario;
			base.BindData();
			if (CajasComboBox.Items.Count <= 1)
			{
				FechaInicialDateTimePicker.Value = DateTime.Now.Date.AddDays(-1);
				FechaFinalDateTimePicker.Value = FechaInicialDateTimePicker.Value;

				FechaInicialDateTimePicker.MaxDate = FechaInicialDateTimePicker.Value;
				FechaFinalDateTimePicker.MaxDate = FechaInicialDateTimePicker.Value;
			}
		}

		/// <summary>
		/// Realiza la consulta en la base de datos
		/// </summary>
		private void DoQuery()
		{
			int? caja_id;
			if (CajasComboBox.SelectedItem != null)
			{
				caja_id = DB.GetNullableInt32(CajasComboBox.SelectedValue);

				this.SaldosCuentaCajasPorFechasBindingSource.DataSource =
				    Entities.SaldosCuentaCajasPorFechas.GetDataTable(
					   caja_id,
					   AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value),
					   AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value.Date)
				    );

				this.IngresosEgresosCajasReportViewer.RefreshReport();
			}
		}

		/// <summary>
		/// Maneja el evento "Click" del control "ConsultarButton"
		/// </summary>
		/// <param name="sender">El control "ConsultarButton"</param>
		/// <param name="e">Los argumentos del evento</param>
		private void ConsultarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
		}

	} // end class

} // end namespace
