using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms.aeropuerto.nomina
{
	public partial class AgregaConductor : Form
	{
		List<classes.Aeropuerto.ConductorNomina> lConductores = null;
		private BindingSource bsConductores = new BindingSource();
		private List<Entities.TipoNomina> TiposNomina = Entities.TipoNomina.GetTiposNomina();

		public classes.Aeropuerto.ConductorTipoNomina Conductor { get; set; }
		public bool SelectConductor { get { return cmbConductor.Enabled; } set { cmbConductor.Enabled = value; } }

		public AgregaConductor()
		{
			InitializeComponent();
			BindingCombos();
		}

		private void BindingCombos()
		{
			lConductores = Entities.Vista_NominaCAT.GetConductoresAeropuerto();

			bsConductores.DataSource = lConductores;
			cmbConductor.DataSource = bsConductores;
			cmbConductor.ValueMember = "Conductor_ID";
			cmbConductor.DisplayMember = "DisplayConductor";

			cmbTiposNomina.DataSource = TiposNomina;
			cmbTiposNomina.DisplayMember = "Nombre";
			cmbTiposNomina.ValueMember = "TipoNomina_ID";
		}

		void cmbConductor_SelectedIndexChanged(object sender, EventArgs e)
		{
			classes.Aeropuerto.ConductorNomina c = (classes.Aeropuerto.ConductorNomina)cmbConductor.SelectedItem;
			if (c != null){
				if (Conductor == null)
					Conductor = new classes.Aeropuerto.ConductorTipoNomina();
				Conductor.Conductor_ID = c.Conductor_ID;
				Conductor.Conductor = c.Conductor;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Conductor.TipoNomina.Tiponomina = (Entities.TipoNomina)cmbTiposNomina.SelectedItem;
			Close();
		}

		private void AgregaConductor_Shown(object sender, EventArgs e)
		{
			if (Conductor.Conductor_ID <= 0)
			{
				Text = "Agrega Conductor";
				btnAdd.Text = "Agregar";
			}
			else
			{
				cmbConductor.SelectedValue = Conductor.Conductor_ID;
				Text = "Actualiza Tipo Nomina";
				btnAdd.Text = "Actualizar";

				if (cmbConductor.SelectedIndex < 0)
				{
					MessageBox.Show("Actualmente el conductor " + Conductor.Conductor + " No cuenta con un contrato Activo.");
					btnCancel_Click(null, null);
				}
			}
		}
	}
}
