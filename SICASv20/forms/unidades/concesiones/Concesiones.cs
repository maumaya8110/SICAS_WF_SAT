using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
	public partial class Concesiones : baseForm
	{
		public Concesiones()
		{
			InitializeComponent();
		}

		private void concesionesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(
			    delegate
			    {
				    this.Validate();
				    this.concesionesBindingSource.EndEdit();
				    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
				    AppHelper.Info("Registros actualizados");
			    },
			    this
			);
		}

		private void Concesiones_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'sICASCentralDataSet.TiposConcesiones' table. You can move, or remove it, as needed.
			this.tiposConcesionesTableAdapter.Fill(this.sICASCentralDataSet.TiposConcesiones);
			// TODO: This line of code loads data into the 'sICASCentralDataSet.Empresas' table. You can move, or remove it, as needed.
			this.empresasTableAdapter.Fill(this.sICASCentralDataSet.Empresas);
			// TODO: This line of code loads data into the 'sICASCentralDataSet.Concesiones' table. You can move, or remove it, as needed.
			this.concesionesTableAdapter.Fill(this.sICASCentralDataSet.Concesiones);
		}

		private void BuscarButton_Click(object sender, EventArgs e)
		{
			AppHelper.DoMethod(
			    delegate
			    {
				    this.concesionesBindingSource.Filter =
					   string.Format(
						  "Placa LIKE '{0}%' OR NumeroConcesion LIKE '{1}%'",
						  this.PlacaTextBox.Text,
						  this.NumeroConcesionTextBox
					   );
			    },
			    this
			);
		}
	}
}
