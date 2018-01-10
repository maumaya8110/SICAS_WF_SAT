using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SICASv20.Entities;
using System.Data.SqlClient;

namespace SICASv20.forms
{
	public partial class Adendums : baseForm
	{
		//public int ContratoAltaModif { get; set; }
		int RowActual = -1;
		internal DateTime FechaInicialContrato { get; set; }
		internal DateTime FechaFinalContrato { get; set; }

		public Adendums()
		{
			InitializeComponent();
		}

		public override void BindData()
		{
			base.BindData();
		}

		private void ObtenerContratos()
		{
			DataTable dt = Vista_ContratosAdendum.GetDataTable();
			if (dt != null && dt.Rows.Count > 0)
			{
				this.contratosBindingSource.DataSource = dt;
				this.adendumBindingSource.DataSource = Vista_ContratosAdendumDetalle.GetDataTable(int.Parse(dt.Rows[0]["Contrato"].ToString()));
				RowActual = 0;
			}
		}

		private void ObtenerContratos(int ContratoId)
		{
			this.adendumBindingSource.DataSource = Vista_ContratosAdendumDetalle.GetDataTable(ContratoId);
		}

		private void Addendums_Load(object sender, EventArgs e)
		{
			this.ObtenerContratos();
		}


		private void dgvContratosAdendums_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (RowActual > -1 && RowActual != e.RowIndex)
			{
				int ContratoId = 0;
				if (int.TryParse(this.dgvContratosAdendums.Rows[e.RowIndex].Cells["contratoDataGridViewTextBoxColumn1"].Value.ToString(), out ContratoId))
				{
					DataTable dt = this.contratosBindingSource.DataSource as DataTable;
					this.FechaInicialContrato = DateTime.Parse(dt.Rows[e.RowIndex]["FechaInicial"].ToString());
					this.FechaFinalContrato = DateTime.Parse(dt.Rows[e.RowIndex]["FechaFinal"].ToString());
					this.adendumBindingSource.DataSource = Vista_ContratosAdendumDetalle.GetDataTable(ContratoId);
					RowActual = e.RowIndex;
				}
			}
		}

		private void dgvAdendum_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				#region click en la columna actualizar
				//  Si se hizo click en la columna "Actualizar"
				if (dgvAdendum.Columns[e.ColumnIndex].Name == "ActualizarColumn" && e.RowIndex > -1)
				{
					//  Mostramos la pantalla de actualización de contrato                    
					DataRowView adendum =
					    dgvAdendum.Rows[e.RowIndex].DataBoundItem as DataRowView;

					DateTime? dtFin = null;

					if (adendum == null) return;

					//if (adendum["FechaFin"] != null && !string.IsNullOrEmpty(adendum["FechaFin"].ToString()))
					if (adendum["FechaFin"] != null && !string.IsNullOrEmpty(adendum["FechaFin"].ToString()))
					{
						dtFin = DateTime.Parse(adendum["FechaFin"].ToString());
						//if (dtFin.Value.Date == DateTime.Now.Date)
						//{
						//    MessageBox.Show("Este adendum vence hoy, puede agregar un adendum el dia de mañana", "Edicion de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						//    return;
						//}
						if (dtFin.Value.Date < DateTime.Now.Date)
						{
							MessageBox.Show("Este adendum ya ha vencido", "Edicion de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
					}

					AdendumAltaEdicion altaEd = new AdendumAltaEdicion(int.Parse(adendum["Adendum_ID"].ToString()),
					    int.Parse(adendum["Contrato_ID"].ToString()), int.Parse(adendum["ClasificacionAdendum_ID"].ToString()),
					    DateTime.Parse(adendum["FechaInicio"].ToString()), dtFin, bool.Parse(adendum["Indefinido"].ToString())
					    , adendum["Observaciones"].ToString(), true);
					altaEd.FechaInicialContrato = this.FechaInicialContrato;
					altaEd.FechaFinalContrato = this.FechaFinalContrato;
					altaEd.ShowDialog(this);
					//this.ObtenerContratos();
					this.ObtenerContratos(int.Parse(adendum["Contrato_ID"].ToString()));

				}
				#endregion click en la columna acutalizar

				#region click en la columna Imprimir
				//  Si se hizo click en la columna "Actualizar"
				if (dgvAdendum.Columns[e.ColumnIndex].Name == "Imprimir" && e.RowIndex > -1)
				{
					//  Mostramos la pantalla de actualización de contrato                    
					DataRowView adendum =
					    dgvAdendum.Rows[e.RowIndex].DataBoundItem as DataRowView;

					int adId = int.Parse(adendum["Adendum_ID"].ToString());

					DataTable adendums = this.adendumBindingSource.DataSource as DataTable;
					DataRow[] adnVigente = adendums.Select(string.Format("Adendum_ID = {0} AND  FechaFin > '{1}'", adId, DateTime.Now.Date));
					if (adnVigente.Length > 0)
					{
						if (Convert.ToInt32(adnVigente[0].ItemArray[7]) != 9)
						{
							MessageBox.Show("Para poder imprimir primero finalize este adendum", "alta de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
					}

					adnVigente = adendums.Select(string.Format("Adendum_ID = {0} AND Indefinido = 1 AND FechaFin IS NULL", adId));
					if (adnVigente.Length > 0)
					{
						MessageBox.Show("Para poder imprimir primero finalize este adendum", "alta de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					AdendumPreview preview = new AdendumPreview();
					preview.AdendumId = adId;
					preview.ShowDialog(this);
				}
				#endregion click en la columna Imprimir
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (this.dgvContratosAdendums.SelectedCells != null && this.dgvContratosAdendums.SelectedCells.Count == 0)
			{
				MessageBox.Show("Por favor seleccione un contrato en la tabla de contratos", "Alta de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			int indexRow = this.dgvContratosAdendums.SelectedCells[0].RowIndex;
			DataRowView contrato = this.dgvContratosAdendums.Rows[indexRow].DataBoundItem as DataRowView;

			int contratoId = int.Parse(contrato["Contrato"].ToString());
			DataTable adendums = this.adendumBindingSource.DataSource as DataTable;
			DataRow[] adnVigente = adendums.Select(string.Format("Contrato_ID = {0} AND  FechaFin >= '{1}'", contratoId, DateTime.Now.Date));
			if (adnVigente.Length > 0)
			{
				if (MessageBox.Show("Este contrato cuenta con un Adendums Vigentes" + Environment.NewLine + "Desea agregar uno más?", "Alta de Adendum", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
					return;
			}

			adnVigente = adendums.Select(string.Format("Contrato_ID = {0} AND Indefinido = 1", contratoId));
			if (adnVigente.Length > 0 && string.IsNullOrEmpty(adnVigente[0]["FechaFin"].ToString()))
			{
				MessageBox.Show("Este contrato cuenta con un adendum indefinido", "alta de adendums", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			AdendumAltaEdicion altaEd = new AdendumAltaEdicion(0, contratoId, null, null,
					  null, null, null, false);
			altaEd.tablaAdendums = new DataTable();
			altaEd.tablaAdendums = adendums;
			altaEd.FechaInicialContrato = this.FechaInicialContrato;
			altaEd.FechaFinalContrato = this.FechaFinalContrato;
			altaEd.ShowDialog(this);

			this.ObtenerContratos(contratoId);
		}

		private void btnHistorialAdendum_Click(object sender, EventArgs e)
		{
			ReporteAdendums rep = new ReporteAdendums();
			rep.EsllamadoDesdeAdendums = true;
			Padre.SwitchForma("ReporteAdendums", rep);

		}
	}
}
