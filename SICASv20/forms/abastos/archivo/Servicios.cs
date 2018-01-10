using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.abastos.archivo
{
	public partial class Servicios : baseForm
	{
		private List<classes.Entities.Abastos.Proveedor> lProveedores = new List<classes.Entities.Abastos.Proveedor>();
		private List<classes.Entities.Abastos.Servicio> lServicios = new List<classes.Entities.Abastos.Servicio>();

		public Servicios()
		{
			InitializeComponent();
			dgvServicios.AutoGenerateColumns = false;

			lProveedores.Add(new classes.Entities.Abastos.Proveedor(0,0,"Todos"));
			lProveedores.AddRange(classes.Entities.Abastos.Proveedor.GetProveedores());
			bsProveedores.DataSource = lProveedores;
			cmbProveedores.ValueMember = "CID";
			cmbProveedores.DisplayMember = "Nombre";

			bsServicios.DataSource = lServicios;
		}

		private void cmbProveedores_SelectionChangeCommitted(object sender, EventArgs e)
		{
			Consultar();
		}

		private void Consultar()
		{
			classes.Entities.Abastos.Proveedor p = (classes.Entities.Abastos.Proveedor)cmbProveedores.SelectedItem;
			string codigo = txtCodigo.Text.Trim();
			lServicios = classes.Entities.Abastos.Servicio.GetServicios(p.CID, codigo);
			bsServicios.DataSource = lServicios;
			dgvServicios.DataSource = bsServicios;
			dgvServicios.Refresh();
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			AppHelper.ExportDataGridViewExcel(dgvServicios, this);
		}

		private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnConsultar_Click(null, null);
			}
		}

		private void dgvServicios_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("El valor debe ser un número entero");
			e.Cancel = true;
		}

		private void dgvServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			classes.Entities.Abastos.Servicio s = lServicios[e.RowIndex];
			s.Actualiza();
		}
	}
}
