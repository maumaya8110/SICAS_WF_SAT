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
	/// Formulario que muestra el reporte de monitor de rentas,
	/// este reporte muestra los saldos en rentas de los conductores,
	/// además de información relevante a la cobranza
	/// </summary>
	public partial class MonitorDeRentas : baseForm
	{
		/// <summary>
		/// Crea una nueva instancia del monitor de rentas
		/// </summary>
		public MonitorDeRentas()
		{
			InitializeComponent();
		}

		#region Presenter

		/// <summary>
		/// El listado de registros para monitor de rentas
		/// </summary>
		List<Entities.Vista_MonitorRentas> VistaMonitorRentas;

		/// <summary>
		/// Consulta las empresas y las liga a una fuente de datos
		/// </summary>
		private void LoadEmpresas()
		{

			selectEmpresasInternasBindingSource.DataSource = Sesion.EmpresasTodas;
		}

		/// <summary>
		/// Consulta las estaciones y las liga a una fuente de datos
		/// </summary>
		private void LoadEstaciones()
		{
			this.selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;
		}

		/// <summary>
		/// Consulta y muestra el reporte de monitor de rentas
		/// </summary>
		private void LoadVista_MonitorRentas()
		{
			//  Obtenemos la empresa y la estación de los controles de la forma
			int? empresa_id, estacion_id;
			Entities.SelectEmpresas empresa = (Entities.SelectEmpresas)EmpresasComboBox.SelectedItem;
			Entities.SelectEstaciones estacion = (Entities.SelectEstaciones)EstacionesComboBox.SelectedItem;

			empresa_id = empresa.Empresa_ID;
			estacion_id = estacion.Estacion_ID;

			//  Consultamos el reporte
			VistaMonitorRentas = Entities.Vista_MonitorRentas.Get(empresa_id, estacion_id, Sesion.Usuario_ID);

			//  Lo ligamos a los datos
			vista_MonitorRentasBindingSource.DataSource = VistaMonitorRentas;
		}

		#endregion

		#region View

		/// <summary>
		/// Al hacer clic en "Buscar", consulta y muestra el reporte
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuscarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(LoadVista_MonitorRentas, this);
		}

		/// <summary>
		/// Liga los datos a los controles
		/// </summary>
		public override void BindData()
		{
			LoadEmpresas();
			LoadEstaciones();
			base.BindData();
		}

		/// <summary>
		/// Al hacer clic en "Exportar", exporta los datos a formato MS Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExportButton_Click(object sender, EventArgs e)
		{
			AppHelper.ExportDataGridViewExcel(this.dataGridView1, this);
		}
		#endregion

		/// <summary>
		/// Al completarse el llenado de la tabla de reporte,
		/// colorea los saldos negativos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			AppHelper.Try(
			    delegate
			    {
				    //  Revisamos renglon por renglon, y si tiene adeudo, marcamos 
				    //  de rojo el color de la letra

				    foreach (DataGridViewRow row in this.dataGridView1.Rows)
				    {
					    decimal rentas, otroscargos, saldoEquipoDeGas;
					    rentas = Convert.ToDecimal(row.Cells["RentasColumn"].Value);
					    otroscargos = Convert.ToDecimal(row.Cells["OtrosCargosColumn"].Value);
					    saldoEquipoDeGas = Convert.ToDecimal(row.Cells["Saldo_EquipoDeGas"].Value);

					    if (rentas < 0)
					    {
						    row.Cells["RentasColumn"].Style.ForeColor = Color.Red;
					    }

					    if (otroscargos < 0)
					    {
						    row.Cells["OtrosCargosColumn"].Style.ForeColor = Color.Red;
					    }

					    if (saldoEquipoDeGas < 0)
					    {
						    row.Cells["Saldo_EquipoDeGas"].Style.ForeColor = Color.Red;
					    }
				    }
			    }
			);
		}



	} // end class
} // end namespace
