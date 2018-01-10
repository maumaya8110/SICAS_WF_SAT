using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SICASv20.Entities.EquipoGas;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class ConsultarConductoresEquiposGas : baseForm
	{
		private List<Conductor> lConductores = new List<Conductor>();
		private List<Equipo> lEquipos = new List<Equipo>();
		private List<ConductorEquipo> lConductoresEquipos = new List<ConductorEquipo>();

		public ConsultarConductoresEquiposGas()
		{
			InitializeComponent();

			lConductores = Entities.EquipoGas.Conductor.GetConductores();
			lConductores.Insert(0, new Entities.EquipoGas.Conductor { Id = null, Nombre = "Todos" });
			cmbConductores.DataSource = lConductores;
			cmbConductores.DisplayMember = "Nombre";
			cmbConductores.ValueMember = "Id";

			lEquipos = Entities.EquipoGas.Equipo.GetEquipos();
			Entities.EquipoGas.Equipo eaux = new Entities.EquipoGas.Equipo();
			eaux.Id = null;
			eaux.Equipo_Gas.Id = null;
			eaux.Equipo_Gas.Descripcion = "Todos";
			eaux.NumeroSerieKit = "Todos";
			lEquipos.Insert(0, eaux);
			cmbEquiposGas.DataSource = lEquipos;

			dteInicio.Value = DateTime.Now;
			dteFin.Value = DateTime.Now;

			dgvConductoresEquipoGas.AutoGenerateColumns = false;
			dgvConductoresEquipoGas.DataSource = lConductoresEquipos;
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			AppHelper.Try(Consulta);
		}

		private void Consulta()
		{
			int? _conductorId = null;
			Conductor egc = (Conductor)cmbConductores.SelectedItem;
			_conductorId = egc != null ? egc.Id : null;
			int? _equipoGasId = null;
			Equipo eg = (Equipo)cmbEquiposGas.SelectedItem;
			_equipoGasId = eg != null ? eg.Id : null;

			DateTime? dteFInicio = null;
			DateTime? dteFFin = null;
			if (chkFechas.Checked)
			{
				dteFInicio = dteInicio.Value;
				dteFFin = dteFin.Value;
			}

			dgvConductoresEquipoGas.DataSource = null;
			dgvConductoresEquipoGas.Refresh();

			lConductoresEquipos = Entities.EquipoGas.ConductorEquipo.GetConductoresEquipos(_conductorId, _equipoGasId, dteFInicio, dteFFin);
			dgvConductoresEquipoGas.DataSource = lConductoresEquipos;
			dgvConductoresEquipoGas.Refresh();
		}

		private void chkFechas_CheckedChanged(object sender, EventArgs e)
		{
			dteInicio.Enabled = chkFechas.Checked;
			dteFin.Enabled = chkFechas.Checked;
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			AgregaConductorEquipoGas frm = new AgregaConductorEquipoGas();
			frm.Registro = null;
			DialogResult r = frm.ShowDialog();
			btnConsultar_Click(null, null);
		}

		private void dgvConductoresEquipoGas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				ConductorEquipo egc = lConductoresEquipos[e.RowIndex];
				AgregaConductorEquipoGas frm = new AgregaConductorEquipoGas();
				frm.Registro = egc;
				DialogResult r = frm.ShowDialog();
				btnConsultar_Click(null, null);
			}
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			AppHelper.ExportDataGridViewExcel(this.dgvConductoresEquipoGas, this);
		}
	}
}
