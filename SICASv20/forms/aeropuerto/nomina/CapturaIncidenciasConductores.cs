using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class CapturaIncidenciasConductores : baseForm
	{
		List<classes.Aeropuerto.ConductorNomina> lConductores = Entities.Vista_NominaCAT.GetConductoresAeropuerto();
		List<classes.Aeropuerto.TipoIncidenciaConductor> lTiposIncidencias = Entities.Vista_NominaCAT.GetTiposIncidenciasConductor();
		List<classes.Aeropuerto.EstatusIncidenciaConductor> lEstatus = Entities.Vista_NominaCAT.GetEstatusIncidenciaConductor();
		List<classes.Aeropuerto.IncidenciaConductor> lIncidencias = new List<classes.Aeropuerto.IncidenciaConductor>(); 

		private BindingSource bsConductores = new BindingSource();
		private BindingSource bsTiposIncidencias = new BindingSource();
		private BindingSource bsEstatusIncidencia = new BindingSource();
		private BindingSource bsIncidencias = new BindingSource();
		private BindingSource bsPeriodosDesde = new BindingSource();
		private BindingSource bsPeriodosHasta = new BindingSource();

		private DateTime PeriodoActual
		{
			get
			{
				DateTime dt = DateTime.Today;
				if ((int)dt.DayOfWeek < 5)
				{
					int dw = (int)dt.DayOfWeek + 2;
					dt = dt.AddDays(dw * -1);
				}
				else if ((int)dt.DayOfWeek > 5)
				{
					dt = dt.AddDays(-1);
				}
				return dt;
			}
		}

		private DateTime PeriodoDesde
		{
			get
			{
				DateTime p;
				try
				{
					p = (DateTime)cmbPeriodoDesde.SelectedValue;
				}
				catch
				{
					Entities.PeriodoNomina pn = (Entities.PeriodoNomina)cmbPeriodoDesde.SelectedValue;
					p = pn.Periodo;
				}
				return p;
			}
		}

		private DateTime PeriodoHasta
		{
			get
			{
				DateTime p;
				try
				{
					p = (DateTime)cmbPeriodoHasta.SelectedValue;
				}
				catch
				{
					Entities.PeriodoNomina pn = (Entities.PeriodoNomina)cmbPeriodoHasta.SelectedValue;
					p = pn.Periodo;
				}
				return p;
			}
		}
			
		public CapturaIncidenciasConductores()
		{
			InitializeComponent();
			dgvIncidencias.AutoGenerateColumns = false;

			bsPeriodosDesde.DataSource = Entities.PeriodoNomina.GetPeriodosNominaAño(DateTime.Today.Year);
			cmbPeriodoDesde.DataSource = bsPeriodosDesde;
			cmbPeriodoDesde.DisplayMember = "Semana";
			cmbPeriodoDesde.ValueMember = "Periodo";
			cmbPeriodoDesde.SelectedValue = PeriodoActual;

			bsPeriodosHasta.DataSource = Entities.PeriodoNomina.GetPeriodosNominaAño(DateTime.Today.Year);
			cmbPeriodoHasta.DataSource = bsPeriodosHasta;
			cmbPeriodoHasta.DisplayMember = "Semana";
			cmbPeriodoHasta.ValueMember = "Periodo";
			cmbPeriodoHasta.SelectedValue = PeriodoActual;

			lConductores.Insert(0, new classes.Aeropuerto.ConductorNomina(0, "Todos"));
			lTiposIncidencias.Insert(0, new classes.Aeropuerto.TipoIncidenciaConductor(0,"Todos", false, 0));
			lEstatus.Insert(0, new classes.Aeropuerto.EstatusIncidenciaConductor(0, "Todos"));

			bsConductores.DataSource = lConductores;
			cmbConductor.DataSource = bsConductores;
			cmbConductor.ValueMember = "Conductor_ID";
			cmbConductor.DisplayMember = "DisplayConductor";

			bsTiposIncidencias.DataSource = lTiposIncidencias;
			cmbTiposIncidencias.DataSource = bsTiposIncidencias;
			cmbTiposIncidencias.DisplayMember = "Nombre";
			cmbTiposIncidencias.ValueMember = "TipoIncidenciaConductor_ID";

			bsEstatusIncidencia.DataSource = lEstatus;
			cmbEstatus.DataSource = bsEstatusIncidencia;
			cmbEstatus.DisplayMember = "Nombre";
			cmbEstatus.ValueMember = "EstatusIncidenciaConductor_ID";

			bsIncidencias.DataSource = lIncidencias;
			dgvIncidencias.DataSource = bsIncidencias;

			cmbConductor.SelectedValue = 0;
			cmbEstatus.SelectedValue = 0;
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			AgregaIncidenciaConductor ci = new AgregaIncidenciaConductor();
			ci.Incidencia = null;
			ci.ShowDialog();
			btnConsultar_Click(null, null);
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			int? tipo = null;
			int? conductor = null;
			int? estatus = null;

			if(cmbTiposIncidencias.SelectedValue != null && (int)cmbTiposIncidencias.SelectedValue >= 2)
				tipo = (int)cmbTiposIncidencias.SelectedValue;
			try
			{
				if (cmbConductor.SelectedValue != null && (int)cmbConductor.SelectedValue > 0)
					conductor = (int)cmbConductor.SelectedValue;
			}
			catch { }
			try
			{
				if (cmbEstatus.SelectedValue != null && (int)cmbEstatus.SelectedValue > 0)
					estatus = (int)cmbEstatus.SelectedValue;
			}
			catch { }
			lIncidencias = Entities.Vista_NominaCAT.GetIncidenciasConductor(PeriodoDesde, PeriodoHasta, tipo, conductor, estatus);
			bsIncidencias.DataSource = lIncidencias;
			dgvIncidencias.DataSource = bsIncidencias;
			bsIncidencias.ResetBindings(true);
		}

		private void dgvIncidencias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			AgregaIncidenciaConductor ci = new AgregaIncidenciaConductor();
			ci.Incidencia = (classes.Aeropuerto.IncidenciaConductor)bsIncidencias.Current;
			ci.ShowDialog();
		}

		private void cmbConductor_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnConsultar_Click(null, null);
		}
	}
}
