using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class ConsultaConvenios : baseForm
	{
		private List<classes.Aeropuerto.nomina.convenios.Empresa> lEmpresas = new List<classes.Aeropuerto.nomina.convenios.Empresa>();
		private List<classes.Aeropuerto.nomina.convenios.Estacion> lEstaciones = new List<classes.Aeropuerto.nomina.convenios.Estacion>();
		private List<classes.Aeropuerto.nomina.convenios.Conductor> lConductores = new List<classes.Aeropuerto.nomina.convenios.Conductor>();
		private List<classes.Aeropuerto.nomina.convenios.TipoConvenio> lTiposConvenio = new List<classes.Aeropuerto.nomina.convenios.TipoConvenio>();
		private List<classes.Aeropuerto.nomina.convenios.Convenio> lConvenios = new List<classes.Aeropuerto.nomina.convenios.Convenio>();

		private classes.Aeropuerto.nomina.convenios.Empresa empresa = new classes.Aeropuerto.nomina.convenios.Empresa();
		private classes.Aeropuerto.nomina.convenios.Estacion estacion = new classes.Aeropuerto.nomina.convenios.Estacion();
		private classes.Aeropuerto.nomina.convenios.Conductor conductor = new classes.Aeropuerto.nomina.convenios.Conductor();
		private classes.Aeropuerto.nomina.convenios.TipoConvenio tipoconvenio = new classes.Aeropuerto.nomina.convenios.TipoConvenio();
		private bool ConSaldo = true;

		public ConsultaConvenios()
		{
			InitializeComponent();
			BindingCombos();
			dgvConvenios.AutoGenerateColumns = false;
		}

		private void BindingCombos()
		{
			lEmpresas = classes.Aeropuerto.nomina.convenios.Empresa.GetEmpresas(Sesion.Usuario_ID);
			cmbEmpresa_SelectionChangeCommitted(null,null);
			lEstaciones = classes.Aeropuerto.nomina.convenios.Estacion.GetEstaciones(Sesion.Usuario_ID);
			lTiposConvenio = classes.Aeropuerto.nomina.convenios.TipoConvenio.GetTiposConvenios(null);
			lTiposConvenio.Insert(0, new classes.Aeropuerto.nomina.convenios.TipoConvenio(0, "Todos", 0, "Todos"));
			cmbEmpresa.DataSource = lEmpresas;
			cmbEstacion.DataSource = lEstaciones;
			cmbTipoConvenio.DataSource = lTiposConvenio;
		}

		private void GetValues()
		{
			empresa = (classes.Aeropuerto.nomina.convenios.Empresa)cmbEmpresa.SelectedItem;
			estacion = (classes.Aeropuerto.nomina.convenios.Estacion)cmbEstacion.SelectedItem;
			conductor = (classes.Aeropuerto.nomina.convenios.Conductor)cmbConductor.SelectedItem;
			tipoconvenio = (classes.Aeropuerto.nomina.convenios.TipoConvenio)cmbTipoConvenio.SelectedItem;
			ConSaldo = chkConSaldo.Checked;
		}

		private void cmdConsultar_Click(object sender, EventArgs e)
		{
			GetValues();
			AppHelper.DoMethod(Consultar, this);
		}

		private void Consultar()
		{
			int? cond = null;
			if (conductor.Id > 0)
				cond = conductor.Id;

			int? tipoc = null;
			if (tipoconvenio.Id > 0)
				tipoc = tipoconvenio.Id;

			lConvenios = classes.Aeropuerto.nomina.convenios.Convenio.GetConvenios(empresa.Id, estacion.Id, cond, tipoc, ConSaldo);
			dgvConvenios.DataSource = lConvenios;
			dgvConvenios.Refresh();
		}

		private void cmbEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
		{
			lConductores = classes.Aeropuerto.nomina.convenios.Conductor.GetConductores(lEmpresas[0].Id.ToString());
			lConductores.Insert(0, new classes.Aeropuerto.nomina.convenios.Conductor(0, "Todos"));
			cmbConductor.DataSource = lConductores;
		}

		private void cmdExportar_Click(object sender, EventArgs e)
		{
			AppHelper.ExportDataGridViewExcel(this.dgvConvenios, this);
		}
	}
}
