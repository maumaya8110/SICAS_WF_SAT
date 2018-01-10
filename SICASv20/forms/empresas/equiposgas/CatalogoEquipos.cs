using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class CatalogoEquipos : baseForm
	{
		private List<Entities.EquipoGas.Equipo> lEquipos = new List<Entities.EquipoGas.Equipo>();
		private List<Entities.EquipoGas.EquipoGas> lEquiposGas = new List<Entities.EquipoGas.EquipoGas>();
		private List<Entities.EquipoGas.Empresa> lEmpresas = new List<Entities.EquipoGas.Empresa>();
		private List<Entities.EquipoGas.Estacion> lEstaciones = new List<Entities.EquipoGas.Estacion>();
		private List<Entities.EquipoGas.Proveedor> lProveedores = new List<Entities.EquipoGas.Proveedor>();
		
		public CatalogoEquipos()
		{
			InitializeComponent();
			lEquiposGas.Add(new Entities.EquipoGas.EquipoGas { Id = null, Descripcion = "Todos" });
			lEquiposGas.AddRange(Entities.EquipoGas.EquipoGas.GetEquiposGasActivos());
			lProveedores.Add(new Entities.EquipoGas.Proveedor { Id = null, Nombre = "Todos" });
			lProveedores.AddRange(Entities.EquipoGas.Proveedor.GetProveedoresActivos());
			lEmpresas.Add(new Entities.EquipoGas.Empresa { Id = null, Descripcion = "Todos" });
			lEmpresas.AddRange(Entities.EquipoGas.Empresa.GetEmpresas());
			lEstaciones.Add(new Entities.EquipoGas.Estacion { Id = null, Descripcion = "Todos" });
			lEstaciones.AddRange(Entities.EquipoGas.Estacion.GetEstaciones());

			cmbProveedores.DataSource = lProveedores;
			cmbProveedores.DisplayMember = "Nombre";
			cmbProveedores.ValueMember = "Id";

			cmbEquiposGas.DataSource = lEquiposGas;
			cmbEquiposGas.DisplayMember = "Descripcion";
			cmbEquiposGas.ValueMember = "Id";

			cmbEmpresas.DataSource = lEmpresas;
			cmbEmpresas.DisplayMember = "Descripcion";
			cmbEmpresas.ValueMember = "Id";

			cmbEstaciones.DataSource = lEstaciones;
			cmbEstaciones.DisplayMember = "Descripcion";
			cmbEstaciones.ValueMember = "Id";

			dgvCatEquipos.AutoGenerateColumns = false;
			Consultar();
		}

		private void Consultar()
		{
			int? empresa = null;
			if(cmbEmpresas.SelectedValue != null)
				empresa = (int)cmbEmpresas.SelectedValue;

			int? estacion = null;
			if(cmbEstaciones.SelectedValue != null)
				estacion = (int)cmbEstaciones.SelectedValue;

			int? equipogas = null;
			if (cmbEquiposGas.SelectedValue != null)
				equipogas = (int)cmbEquiposGas.SelectedValue;

			int? proveedor = null;
			if(cmbProveedores.SelectedValue != null)
				proveedor = (int)cmbProveedores.SelectedValue;

			string numeroserie = null;
			if (txtNumeroSerie.Text.Trim().Length > 0)
				numeroserie = txtNumeroSerie.Text.Trim();
			double? capacidad = null;
			double aux = 0;
			if (txtCapacidad.Text.Trim().Length > 0 && !double.TryParse(txtCapacidad.Text.Trim(), out aux))
				throw new Exception("La capacidad debe ser númerica");
			if (aux > 0)
				capacidad = aux;

			lEquipos = Entities.EquipoGas.Equipo.GetEquipos(numeroserie, capacidad, equipogas, proveedor, empresa, estacion);
			dgvCatEquipos.DataSource = lEquipos;
			dgvCatEquipos.Refresh();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			AgregaEquipo f = new AgregaEquipo();
			f.Modelo = null;
			DialogResult r = f.ShowDialog();
			if (r == System.Windows.Forms.DialogResult.OK)
				btnConsultar_Click(null, null);
		}

		private void dgvCatEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				AgregaEquipo f = new AgregaEquipo();
				f.Modelo = lEquipos[e.RowIndex];
				DialogResult r = f.ShowDialog();
				if (r == System.Windows.Forms.DialogResult.OK)
					btnConsultar_Click(null, null);
			}
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(delegate { Consultar(); }, this);
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			AppHelper.ExportDataGridViewExcel(this.dgvCatEquipos, this);
		}
	}
}
