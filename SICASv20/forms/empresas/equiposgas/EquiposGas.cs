using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.empresas.equiposgas
{
	public partial class EquiposGas : baseForm
	{
		Entities.EquipoGas.EquipoGas modelo;
		List<Entities.EquipoGas.EquipoGas> lequipos = new List<Entities.EquipoGas.EquipoGas>();

		public EquiposGas()
		{
			InitializeComponent();
			modelo = null;
			dgvEquipos.AutoGenerateColumns = false;
			ActualizaGrid();
			btnExportar.Tag = 0;
		}

		private void ActualizaGrid()
		{
			lequipos = Entities.EquipoGas.EquipoGas.GetEquiposGas();
			dgvEquipos.DataSource = lequipos;
			dgvEquipos.Refresh();
		}

		private void dgvEquipos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (modelo == null) { modelo = new Entities.EquipoGas.EquipoGas(); }
				modelo = lequipos[e.RowIndex];
				txtDescripcion.Text = modelo.Descripcion;
				txtCapacidad.Text = modelo.Capacidad.ToString();
				chkEstatus.Checked = modelo.EstatusEquipoGas_ID == 1;
				btnGuardar.Text = "Guardar";

				btnExportar.Text = "Cancelar";
				btnExportar.Tag = 1;
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (modelo == null)
			{
				modelo = new Entities.EquipoGas.EquipoGas();
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

		private void DoValidate()
		{
			if (txtDescripcion.Text.Trim().Length <= 0)
			{
				txtDescripcion.Focus();
				throw new Exception("Se requiere una descripción");
			}
			if (txtCapacidad.Text.Trim().Length <= 0)
			{
				txtCapacidad.Focus();
				throw new Exception("Se requiere una Capacidad del Equipo");
			}
			double d;
			if (!double.TryParse(txtCapacidad.Text.Trim(),out d))
			{
				throw new Exception("La capacidad debe ser númerica");
			}
			modelo.Descripcion = txtDescripcion.Text.Trim();
			modelo.Capacidad = Convert.ToDouble(txtCapacidad.Text.Trim());
			modelo.EstatusEquipoGas_ID = chkEstatus.Checked ? 1 : 0;
			modelo.Usuario_ID = Sesion.Usuario_ID;
		}

		private void DoSave()
		{
			Entities.EquipoGas.EquipoGas.Inserta(modelo);
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			if ((int)btnExportar.Tag == 0)
				AppHelper.ExportDataGridViewExcel(this.dgvEquipos, this);
			else
				Limpiar();
		}

		private void Limpiar()
		{
			modelo = null;
			btnGuardar.Text = "Agregar";
			btnExportar.Text = "Exportar";
			btnExportar.Tag = 0;
			txtDescripcion.Clear();
			txtCapacidad.Clear();
			chkEstatus.Checked = true;
		}
	}
}
