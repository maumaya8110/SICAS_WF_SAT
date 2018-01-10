using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class QuitaBoletosAConductor : baseForm
	{
		private List<classes.Aeropuerto.ConductorNomina> lConductores = null;
		private BindingSource bsConductores = new BindingSource();
		private List<classes.Aeropuerto.BoletoConductor> lBoletos = null;
		private BindingSource bsBoletos = new BindingSource();

		private DateTime Periodo
		{
			get
			{
				DateTime dte = dteFechaPago.Value;
				if (dte.DayOfWeek < DayOfWeek.Friday && dte.DayOfWeek > 0)
				{
					int ndays = DayOfWeek.Friday - dte.DayOfWeek;
					dte = dte.AddDays(ndays);
					dte = dte.AddDays(-7);
				}
				else
				{
					if (dte.DayOfWeek != DayOfWeek.Friday)
					{
						if (dte.DayOfWeek == DayOfWeek.Saturday)
							dte = dte.AddDays(-1);
						else
							dte = dte.AddDays(-2);
					}
				}
				return dte;
			}
		}

		public QuitaBoletosAConductor()
		{
			InitializeComponent();
			dteFechaPago.Value = DateTime.Today;
			dteFechaPago.MaxDate = DateTime.Today;
			dgvDetalleBoletos.AutoGenerateColumns = false;
			dgvDetalleBoletos.DataSource = bsBoletos;
		}

		private void dteFechaPago_ValueChanged(object sender, EventArgs e)
		{
			SetCondutores();
		}

		private void SetCondutores()
		{
			lConductores = Entities.Vista_NominaCAT.GetConductoresAeropuertoPorPeriodo(Periodo);
			bsConductores.DataSource = lConductores;
			cmbConductor.DataSource = bsConductores;
			cmbConductor.ValueMember = "Conductor_ID";
			cmbConductor.DisplayMember = "DisplayConductor";
			if (lConductores.Count <= 0)
			{
				string msg = string.Format("No se ha definido la plantilla para el periodo {0}. Favor de Verificar", Periodo.ToString("dd-MM-yyyy"));
				MessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			bsConductores.MoveFirst();
			cmbConductor_SelectedIndexChanged(null, null);
		}

		void cmbConductor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lConductores.Count > 0)
			{
				classes.Aeropuerto.ConductorNomina cond = (classes.Aeropuerto.ConductorNomina)cmbConductor.SelectedItem;
				lBoletos = Entities.Vista_NominaCAT.GetDetalleBoletosPorConductorFechaPago(cond.Conductor_ID, dteFechaPago.Value);
				bsBoletos.DataSource = lBoletos;
				lblTotaServicios.Text = lBoletos.Count.ToString();
				double dsuma = 0;
				foreach (SICASv20.classes.Aeropuerto.BoletoConductor b in lBoletos)
				{
					dsuma += b.Monto;
				}
				lblTotalMonto.Text = dsuma.ToString("C");
				dgvDetalleBoletos.Refresh();
			}
		}

		private void dgvDetalleBoletos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			classes.Aeropuerto.BoletoConductor boleto = (classes.Aeropuerto.BoletoConductor)bsBoletos.Current;
			classes.Aeropuerto.ConductorNomina cond = (classes.Aeropuerto.ConductorNomina)bsConductores.Current;
			string msg = String.Format("Confirma que desea Quitar el boleto #{0} asignado al conductor {1}?", boleto.Servicio, cond.DisplayConductor);
			if (MessageBox.Show(msg,"Atención",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
			{
				AppHelper.Try(QuitaServicioAConductor);
			}
		}

		private void QuitaServicioAConductor()
		{
			classes.Aeropuerto.BoletoConductor boleto = (classes.Aeropuerto.BoletoConductor)bsBoletos.Current;
			classes.Aeropuerto.ConductorNomina cond = (classes.Aeropuerto.ConductorNomina)bsConductores.Current;
			if (Entities.Vista_NominaCAT.QuitaServicioAConductor(boleto.Servicio, cond.Conductor_ID, Sesion.Usuario_ID))
			{
				cmbConductor_SelectedIndexChanged(null, null);
			}
		}
	}
}