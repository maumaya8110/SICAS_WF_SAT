using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class CapturaBoletosporPeriodo : baseForm
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

		public CapturaBoletosporPeriodo()
		{
			InitializeComponent();
			dteFechaPago.Value = DateTime.Today;
			dteFechaPago.MaxDate = DateTime.Today;
			dgvDetalleBoletos.AutoGenerateColumns = false;
			dgvDetalleBoletos.DataSource = bsBoletos;
		}

		private void dteFechaPago_ValueChanged(object sender, EventArgs e)
		{
			txtServicio.Clear();
			SetCondutores();
			btnAdd.Enabled = Entities.Vista_NominaCAT.EsPeriodoAbierto(Periodo, Sesion.Usuario_ID);
			btnActKm.Enabled = btnAdd.Enabled;
			txtServicio.Enabled = btnAdd.Enabled;
		}

		private void txtServicio_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnAdd_Click(null, null);
			}
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtServicio.Text.Trim().Length <= 0)
			{
				MessageBox.Show("Es requerido un número de Servicio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtServicio.Focus();
				txtServicio.SelectAll();
				return;
			}

			AppHelper.Try(AgregaServicioAConductor);
		}

		private void AgregaServicioAConductor()
		{
			classes.Aeropuerto.ConductorNomina cond = (classes.Aeropuerto.ConductorNomina)bsConductores.Current;
			if (Entities.Vista_NominaCAT.AgregaServicioAConductorFechaPago(txtServicio.Text.Trim(), cond.Conductor_ID, Periodo, dteFechaPago.Value, Sesion.Usuario_ID))
			{
				cmbConductor_SelectedIndexChanged(null, null);
				txtServicio.Focus();
				txtServicio.Clear();
			}
		}

		private void btnActKm_Click(object sender, EventArgs e)
		{
			Entities.DatosConductorUnidad conductor = new Entities.DatosConductorUnidad();
			conductor = Entities.DatosConductorUnidad.GetFromConductorNomina((int)cmbConductor.SelectedValue);
			forms.aeropuerto.herramientas.ActualizaKilometrajeNomina frm = new aeropuerto.herramientas.ActualizaKilometrajeNomina(conductor);
			frm.ShowDialog();
		}

	}
}