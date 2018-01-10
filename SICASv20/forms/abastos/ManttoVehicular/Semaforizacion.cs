using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.abastos.ManttoVehicular
{
	public partial class Semaforizacion : baseForm
	{
		public Semaforizacion()
		{
			InitializeComponent();
		}

		private void txtUnidad_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				AppHelper.DoMethod(CargaCartilla, this);
			}
		}

		private void CargaCartilla()
		{
			Entities.Vista_Unidades u = new Entities.Vista_Unidades();
			int unidad = Convert.ToInt32(txtUnidad.Text.Trim());
			int unidades = Entities.DatosConductorUnidad.GetNumeroUnidades(unidad);

			if (unidades == 0)
			{
				throw new Exception(string.Format("Unidad {0} no esta asignada", unidad));
			}
			else if (unidades == 1) // Si hay una unidad
			{
				List<Entities.Vista_Unidades> lu = Entities.Vista_Unidades.GetActivas(null, unidad, null, null);
				u = lu[0];
			}
			else // Si hay mas de una unidad
			{
				SeleccionarUnidadConductor seleccionarUnidadForm = new SeleccionarUnidadConductor();
				seleccionarUnidadForm.GetUnidades(unidad);
				if (seleccionarUnidadForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					List<Entities.Vista_Unidades> lu = Entities.Vista_Unidades.GetActivas(seleccionarUnidadForm.DatosConductor.Unidad_ID, null, null, null);
					u = lu[0];
				}
				else // Si no
				{
					throw new Exception("Debe seleccionar una unidad");
				}
			}
			txtKilometraje.Text = u.Kilometraje.ToString();
			txtDescripcion.Text = u.ModeloUnidad;

			DataTable dt = classes.Entities.Abastos.ManttoVehicular.ObtienePlantilla(u.Unidad_ID);
			bsPlantilla.DataSource = dt;
		}
	}
}
