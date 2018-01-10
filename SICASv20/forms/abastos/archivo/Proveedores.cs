using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.abastos.archivo
{
	public partial class Proveedores : baseForm
	{
		public Proveedores()
		{
			InitializeComponent();
			this.dgvProveedores.AutoGenerateColumns = false;

			dgvProveedores.DataSource = classes.Entities.Abastos.Proveedor.GetProveedores();
		}
	}
}
