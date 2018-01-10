using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.abastos.ManttoVehicular
{
	public partial class AsociaServiciosModeloUnidad : baseForm
	{
		private List<classes.Entities.Abastos.ModeloUnidad> lu = new List<classes.Entities.Abastos.ModeloUnidad>();
		private List<classes.Entities.Abastos.ItemPlantilla> lp = new List<classes.Entities.Abastos.ItemPlantilla>();
		private List<classes.Entities.Abastos.Servicio> ls = new List<classes.Entities.Abastos.Servicio>();

		public AsociaServiciosModeloUnidad()
		{
			InitializeComponent();
			lu = classes.Entities.Abastos.ModeloUnidad.GetModelosUnidades();
			cmbModelosUnidades.DataSource = lu;
			cmbModelosUnidades_SelectionChangeCommitted(null, null);

			bsItemsPlantilla.DataSource = lp;
			bsServicios.DataSource = ls;
		}

		private void cmbModelosUnidades_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ls = classes.Entities.Abastos.Servicio.GetServicios();
			classes.Entities.Abastos.ModeloUnidad mu = (classes.Entities.Abastos.ModeloUnidad)cmbModelosUnidades.SelectedItem;
			lp = classes.Entities.Abastos.ItemPlantilla.GetServiciosPorModeloUnidad(mu.ID);
			//Elimina los servicios ya asociados en la plantilla
			foreach (classes.Entities.Abastos.ItemPlantilla p in lp)
			{
				if(ls.Contains(p.Servicio))
					ls.Remove(p.Servicio);
			}
		}

		private void listServiciosDisponibles_DoubleClick(object sender, EventArgs e)
		{
			classes.Entities.Abastos.Servicio servicio_aux = (classes.Entities.Abastos.Servicio)listServiciosDisponibles.SelectedItem;
			int idx = YaExisteServicio(lp, servicio_aux);
			if(idx < 0){
				classes.Entities.Abastos.ItemPlantilla p = new classes.Entities.Abastos.ItemPlantilla();
				p.Servicio = servicio_aux;
				p.Modelo = (classes.Entities.Abastos.ModeloUnidad)cmbModelosUnidades.SelectedItem;
				p.ID = 0;
				bsItemsPlantilla.Add(p);
				bsServicios.Remove(servicio_aux);
			}
			bsItemsPlantilla.ResumeBinding();
			bsServicios.ResumeBinding();
		}

		private static int YaExisteServicio(List<classes.Entities.Abastos.ItemPlantilla> lp, classes.Entities.Abastos.Servicio s)
		{
			int b = -1;
			int pos = 0;
			foreach (classes.Entities.Abastos.ItemPlantilla p in lp)
			{
				if (p.Servicio.ID == s.ID)
				{
					b = pos;
					break;
				}
				pos++;
			}
			return b;
		}
	}
}
