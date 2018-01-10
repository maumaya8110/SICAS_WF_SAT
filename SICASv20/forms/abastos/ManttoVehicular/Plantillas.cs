using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.abastos.ManttoVehicular
{
	public partial class Plantillas : baseForm
	{
		public Plantillas()
		{
			InitializeComponent();
			cmbModelosUnidad.DataSource = classes.Entities.Abastos.ModeloUnidad.GetModelosUnidades();
		}

		private void cmbModelosUnidad_SelectedIndexChanged(object sender, EventArgs e)
		{
			AppHelper.DoMethod(GetPlantilla, this);
		}

		private void GetPlantilla()
		{
			classes.Entities.Abastos.ModeloUnidad mu = (classes.Entities.Abastos.ModeloUnidad)cmbModelosUnidad.SelectedItem;
			lblAnio.Text = mu.Anio.ToString();
			DataTable dt = classes.Entities.Abastos.ManttoVehicular.ObtienePlantilla(mu.ID);
			dgvDetalles.DataSource = dt;
		}
	}
}
