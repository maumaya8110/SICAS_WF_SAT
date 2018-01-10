using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class ProveedoresEquipoGas : baseForm
	{
		Entities.EquipoGas.Proveedor modelo = new Entities.EquipoGas.Proveedor();
		List<Entities.EquipoGas.Proveedor> lProveedores = new List<Entities.EquipoGas.Proveedor>();

		public ProveedoresEquipoGas()
		{
			InitializeComponent();
			modelo = null;
			dgvProveedores.AutoGenerateColumns = false;
			ActualizaGrid();
			btnExportar.Tag = 0;
		}

		private void ActualizaGrid()
		{
			lProveedores = Entities.EquipoGas.Proveedor.GetProveedores();
			dgvProveedores.DataSource = lProveedores;
			dgvProveedores.Refresh();
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			if ((int)btnExportar.Tag == 0)
				AppHelper.ExportDataGridViewExcel(this.dgvProveedores, this);
			else
				Limpiar();
		}

		private void DoValidate()
		{
			if (txtProveedor.Text.Trim().Length <= 0)
			{
				txtProveedor.Focus();
				throw new Exception("Se requiere una proveedor");
			}
			modelo.Nombre = txtProveedor.Text.Trim();
			modelo.Estatus = chkEstatus.Checked ? 1 : 0;
		}

		private void DoSave()
		{
			Entities.EquipoGas.Proveedor.Inserta(modelo);
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (modelo == null)
			{
				modelo = new Entities.EquipoGas.Proveedor();
				modelo.Id = null;
			}
			AppHelper.DoMethod(
				delegate
				{
					DoValidate();
					DoSave();
					Limpiar();
					ActualizaGrid();
				},
				this
			);
		}

		private void Limpiar()
		{
			modelo = null;
			btnGuardar.Text = "Agregar";
			btnExportar.Text = "Exportar";
			btnExportar.Tag = 0;
			txtProveedor.Clear();
			chkEstatus.Checked = true;
		}

		private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (modelo == null) { modelo = new Entities.EquipoGas.Proveedor(); }
				modelo = lProveedores[e.RowIndex];
				txtProveedor.Text = modelo.Nombre;
				chkEstatus.Checked = modelo.Estatus == 1;
				btnGuardar.Text = "Guardar";

				btnExportar.Tag = 1;
				btnExportar.Text = "Cancelar";
			}
		}
	}
}
